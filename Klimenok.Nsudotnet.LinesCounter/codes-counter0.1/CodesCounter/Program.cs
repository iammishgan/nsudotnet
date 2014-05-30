using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;

namespace CodesCounter
{
	class Program
	{

		static void Main(string[] args)
		{

			StartParams startArgs = StartParams.Parse(args);


			if (startArgs.Path.Length==0) {
				startArgs.Path=Directory.GetCurrentDirectory();	
			}

			List<FileConteiner> files;
			try
			{
				files = FileFinder.Find(startArgs);
			}
			catch (Exception e) {
				Console.WriteLine("Error: "+e.Message);
				Console.Read();
				return;
			}


			Console.WriteLine("Files founded: " + files.Count);


			int totalLines = 0;
			int totalCuttedLines = 0;
			int totalCommentLines = 0;
			int totalUsefullLines = 0;


			List<ScanInfo> infos = new List<ScanInfo>();
			ScanInfo info;
			foreach (FileConteiner file in files) {
				info = Scanner.Scan(file, ScanParameters.GetScanParametersForExtension(file.FileType));
				infos.Add(info);

				totalLines += info.RawLinesCount;
				totalCuttedLines += info.CuttedLinesCount;
				totalUsefullLines += info.UsefullLineCount;
				totalCommentLines += (info.RawLinesCount - info.CuttedLinesCount);

			}

			Console.WriteLine("Total lines: " + totalLines);
			Console.WriteLine("Total cutted lines(without comment): " + totalCuttedLines);
			Console.WriteLine("Total useful lines: " + totalUsefullLines);
			Console.WriteLine("Total commented lines: " + totalCommentLines);

            Console.Read();

		}
	}
}
