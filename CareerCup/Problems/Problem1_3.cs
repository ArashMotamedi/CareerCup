using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	class Problem1_3 : IProblem
	{
		public string Id()
		{
			return "1.3";
		}

		public string Statement()
		{
			return "Remove duplicate characters from a string without any additional buffer.";
		}

		public string[] TestArgs()
		{
			return new string[] {"Remove duplicates. Remov duplicats."};
		}

		public void Run(string args)
		{
			var chars = args.ToCharArray();

			// We'll mark visited chars here
			var visitedChars = new bool[256];
			var numRetainedChars = 0;

			for (int i = 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (!visitedChars[c])
				{
					// copy this character to the beginning, after existing retained characters
					chars[numRetainedChars] = c;
					visitedChars[c] = true;
					numRetainedChars++;
				}
			}

			// Truncate
			chars = chars.Take(numRetainedChars).ToArray();

			// Confirm the new duplicate-free string
			Console.WriteLine(new string(chars));
		}
	}
}
