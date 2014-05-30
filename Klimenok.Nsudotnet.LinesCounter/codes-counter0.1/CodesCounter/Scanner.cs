using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodesCounter
{
	class Scanner
	{

		public static ScanInfo Scan(FileConteiner file, ScanParameters param) {
			ScanInfo info = new ScanInfo();
			info.Path = file.Path;
			info.FileName = file.FileName;

			string[] rawLines = file.Raw.Split('\n');
            string[] cuttedLines = GetContentWithoutComments(file.Raw, param.CommentRegExp).Split('\n');

			info.RawLinesCount = rawLines.Length;
			info.CuttedLinesCount = cuttedLines.Length;

			int usefullLinesCount = 0;

			foreach (string line in cuttedLines) {
                if (IsUsefulLine(line, param.UselessSymbols))
                {
					usefullLinesCount++;
				}
			}

			info.UsefullLineCount = usefullLinesCount;

			return info;
		}

		private static string GetContentWithoutComments(string content, Regex commentRegex) {
			string res = content;
			try
			{
				res = commentRegex.Replace(res, "");
			}
			catch (Exception e) {
				return content;
			}
			return res;
		}

		private static bool IsUsefulLine(String line, char[] uselessChars) {
			int scanTo = line.Length;
			for (int i = 0; i < scanTo; i++)
			{
				char c = line[i];
				if (!IsSpecialSymbol(c, uselessChars))
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsSpecialSymbol(char checkingChar, char[] uselessChars)
		{
			foreach (char symbol in uselessChars)
			{
				if (symbol == checkingChar)
				{
					return true;
				}
			}
			return false;
		}
	}
}
