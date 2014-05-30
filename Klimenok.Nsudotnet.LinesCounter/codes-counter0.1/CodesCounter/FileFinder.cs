﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
namespace CodesCounter
{
	class FileFinder
	{

		public static List<FileConteiner> Find(StartParams startParams){
			string[] files;
			try
			{
				files = Directory.GetFiles(startParams.Path, "*.*", SearchOption.AllDirectories);
			}

			catch (Exception e) {
				throw e;
			}
			FileInfo fileInfo;
			List<FileConteiner> filesList = new List<FileConteiner>();
			foreach (string filePath in files) {
				fileInfo = new FileInfo(filePath);
				if (startParams.CheckForAcceptedExtension(fileInfo.Extension)) {
					filesList.Add(new FileConteiner(filePath));
				}
			}

			return filesList;

		}
	}
}
