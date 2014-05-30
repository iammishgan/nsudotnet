using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodesCounter
{
	class ScanParameters
	{
		private static ScanParameters _cPlusPlus;
		private static ScanParameters _text;

		
		private static ScanParameters XML;

		private static Dictionary<string, ScanParameters> extenstionToNotation = InitEtnDictionary();

		private static Dictionary<string, ScanParameters> InitEtnDictionary()
		{
			Dictionary<string, ScanParameters> res = new Dictionary<string, ScanParameters>();

			_cPlusPlus = new ScanParameters();
			_cPlusPlus.SetUselessChars(new char[] { '\t', ' ', '\n', '{', '}', '(', ')', ';', '\r' });
			_cPlusPlus.SetCommentRegex("(/\\*[^\\*]*[^/]*/|\\/\\/[^\\n]*)");

			_text = new ScanParameters();
			_text.SetUselessChars(new char[]{});

			res.Add("*", _text);

			res.Add(".java", _cPlusPlus);
			res.Add(".cs", _cPlusPlus);
			res.Add(".as", _cPlusPlus);
			res.Add(".cpp", _cPlusPlus);
			res.Add(".h", _cPlusPlus);
			res.Add(".c", _cPlusPlus);



			return res;
		}

		public static ScanParameters GetScanParametersForExtension(string ext) {
			ScanParameters p;
			if(extenstionToNotation.ContainsKey(ext)){
				p = extenstionToNotation[ext];
			}else{
				p = extenstionToNotation["*"];
			}
			return p;
		}

        public char[] UselessSymbols { get; set; }
        public Regex CommentRegExp { get; set; }

		public void SetUselessChars(char[] chars) {
			UselessSymbols = chars;
		}

		public void SetCommentRegex(string regexString) {
			CommentRegExp = new Regex(regexString);
		}
        }
}
