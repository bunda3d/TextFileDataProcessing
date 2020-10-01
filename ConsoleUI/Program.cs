using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

using CsvHelper;
using CsvHelper.Configuration;
using System.Linq.Expressions;

namespace ConsoleUI
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Out.NewLine = "\r\n\r\n";               // dbl space writelines
			WriteLine("Starting Parse Mode...");    // show app is running

			// set up raw logs folders just like this or change the URIs here
			string inputFilePath = @"C:\ftpint_logs\_input";
			string outputFilePath = @"C:\ftpint_logs\_output\";
			string ouputFileName = @"ftpuser_iopen_logs.csv";

			// chars starting lines we don't want to parse
			string hashtag = "#";       // logs notes
			string whtSpace = " ";      // white space char
			string ctrlChar = "\0";     // "NUL" in notepad++

			// FTP codes we filter for
			string ftpCmd1 = "CWD";     // iopen ftpuser log export
			string ftpCmd2 = "sent";    // iopen ftpuser log import
			string ftpCmd3 = "created"; // iopen ftpuser log

			try
			{
				var files =
				from file in Directory.EnumerateFiles(inputFilePath, "*.log", SearchOption.TopDirectoryOnly)
				from line in File.ReadLines(file)
					// filter parts of the log lines away
				where !line.StartsWith(hashtag) &&
				!line.StartsWith(whtSpace) &&
				line != null &&
				!string.IsNullOrWhiteSpace(line) &&
				!line.StartsWith(ctrlChar) &&
				(   // line contains FTP code
				line.Contains(ftpCmd1) ||
				line.Contains(ftpCmd2) ||
				line.Contains(ftpCmd3)
				)   // edit log lines, make comma delimited
				let delims = line.Replace(' ', ',')
				let parts = delims.Split(']')
				from part in parts
				let lineB = parts[1]
				orderby file descending
				// now set edited log line equal to loop terms
				select new
				{
					File = file,
					Line = lineB
				};
				// writes lines to output file
				using (StreamWriter writer = new StreamWriter(outputFilePath + ouputFileName, true))
				{
					foreach (var f in files)
					{
						// write to txt or csv file
						writer.WriteLine($"{Path.GetFileName(f.File)},{f.Line}");
						// console output
						WriteLine($"{f.File},{f.Line}");
					}
					// console output
					WriteLine($"{files.Count()} lines found.");
					ReadLine(); // keep console open...
				}
			}
			catch (UnauthorizedAccessException uAEx)
			{
				Console.WriteLine(uAEx.Message);
			}
			catch (PathTooLongException pathEx)
			{
				Console.WriteLine(pathEx.Message);
			}
		}
	}
}