using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CodesCounter
{
	class FileConteiner
	{
		public string Raw { get; set; }
        public string Computed { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

		

		public FileConteiner(string path){
		    using (StreamReader reader = new StreamReader(path)){
		        Raw = reader.ReadToEnd();
		    }

		    FileInfo fileInfo = new FileInfo(path);
			FileName = fileInfo.Name;
			FileType = fileInfo.Extension;
			this.Path = path;
		}
	}
}
