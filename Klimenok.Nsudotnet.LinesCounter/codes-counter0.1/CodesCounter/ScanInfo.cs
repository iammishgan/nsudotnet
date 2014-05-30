using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace CodesCounter
{
	class ScanInfo
	{

		public int rawLinesCount{ get; set; }
        public int cuttedLinesCount { get; set; }
        public int usefullLineCount { get; set; }
        public string fileName { get; set; }
        public string path { get; set; }

		public ScanInfo() {
		}
	}
}
