using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace CodesCounter
{
	class ScanInfo
	{

		public int RawLinesCount{ get; set; }
        public int CuttedLinesCount { get; set; }
        public int UsefullLineCount { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

		public ScanInfo() {
		}
	}
}
