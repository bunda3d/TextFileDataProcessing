using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq.Expressions;
using static System.Console;

namespace ConsoleUI
{
	internal class FileConsolidator
	{
		//		// dbl space writelines
		//		Out.NewLine = "\r\n\r\n";

		//		private WriteLine("Starting Parse Mode...");

		//		private string inputFilePath = @"C:\ftpint_logs\_input";

		//		private string outputFilePath = @"C:\ftpint_logs\_output\";

		//		private string ouputFileName = @"ftpuser_iopen_logs.txt";

		//		// chars starting lines we don't want to parse
		//		private string hashtag = "#";       // logs notes

		//		private string whtSpace = " ";      // white space char
		//		private string ctrlChar = "\0";     // "NUL" in notepad++
		//		private string ftpCmd1 = "CWD";     // iopen ftpuser log export
		//		private string ftpCmd2 = "sent";    // iopen ftpuser log import
		//		private string ftpCmd3 = "created"; // iopen ftpuser log import

		//		try
		//		{
		//			private string[] files = Directory.GetFiles(inputFilePath, "*.log", SearchOption.TopDirectoryOnly);

		//			using (var output = File.Create(outputFilePath + ouputFileName))
		//			{
		//				foreach (var file in files)
		//				{
		//					using (var data = File.OpenRead(file))
		//					{
		//						data.CopyTo(output);
		//					}

		//WriteLine($"{file}");
		//				}
		//			}
		//			ReadLine();
		//		}
		//		catch (UnauthorizedAccessException uAEx)
		//{
		//	Console.WriteLine(uAEx.Message);
		//}
		//catch (PathTooLongException pathEx)
		//{
		//	Console.WriteLine(pathEx.Message);
		//}
	}
}