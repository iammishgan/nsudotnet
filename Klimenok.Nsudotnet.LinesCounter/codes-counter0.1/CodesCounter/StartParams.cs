using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace CodesCounter
{

	class StartParams
	{
		public string[] Filters=new string[0];
		public string Path="";


	    private const string PathFlag = "-p";
	    private static string FilterFlag = "-f";

		public override string ToString()
		{
			string res = "";

			res += "[Path \'" + Path + "\' Filters: ";

			for (int i = 0; i < Filters.Length; i++) {
				res += Filters[i] + (i == Filters.Length - 1 ? "]" : "|");
			}

			
			return res;
		}

		public bool CheckForAcceptedExtension(string ext) {
			if (Filters.Length == 0) {
				return true;
			}

			foreach (string filter in Filters) {
				if (ext == filter) return true;
			}

			return false;

		}

		public static StartParams Parse(string[] args) {
			StartParams res = new StartParams();
			List<String> filters = new List<string>();
			String path = "";

			const int start = 0, pathFlagS = 1, filterFlagS = 2, pathReading = 3, filterReading = 4;

			string currArg;
			int state = start;
			int i = 0;
			while (i != args.Length)
			{
				currArg = args[i];

				switch (state)
				{
					case start:
						if (currArg == PathFlag)
						{
							state = pathFlagS;
						}
						break;

					case pathFlagS:
						if (currArg != FilterFlag)
						{
							path += currArg + " ";
						}
						else
						{
							state = filterFlagS;
						}

						break;

					case filterFlagS:
						filters.Add("."+currArg);
						break;
				}

				i++;
			}

			string[] fils = new string[filters.Count];
			i=0;
			foreach (string s in filters) {
				fils[i] = s;
				i++;
			}

			res.Filters = fils;
			res.Path=path;

			return res;
		}

	}
}
