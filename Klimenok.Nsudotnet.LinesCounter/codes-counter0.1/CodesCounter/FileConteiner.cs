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
		public string raw { get; set; }
        public string computed { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }

		

		public FileConteiner(string path){
		    using (StreamReader reader = new StreamReader(path)){
		        raw = reader.ReadToEnd();
		    }

		    FileInfo fileInfo = new FileInfo(path);
			fileName = fileInfo.Name;
			fileType = fileInfo.Extension;
			this.path = path;
		}
	}
}
