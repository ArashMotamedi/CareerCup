using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	class Problem1_5 : IProblem
	{
		public string Id()
		{
			return "1.5";
		}

		public string Statement()
		{
			return "Replace all spaces with '%20'";
		}

		public string[] TestArgs()
		{
			return new string[] { "Replace spaces in this string" };
		}

		public void Run(string args)
		{
			var inputChars = args.ToCharArray();
			var inputLength = inputChars.Length;
			// Worst case allocation
			// This solution optimizes for running the loop only once
			// For memory optimization, run the loop twice, cound the spaces, and allocate memory accordingly
			var outputChars = new char[inputLength * 3];
			int j = 0;
			for (int i = 0; i < inputLength; i++)
			{
				char c = inputChars[i];
				if (c == ' ')
				{
					outputChars[i + j++] = '%';
					outputChars[i + j++] = '2';
					outputChars[i + j] = '0';
				}
				else
				{
					outputChars[i + j] = c;
				}
			}

			// Truncate
			outputChars = outputChars.Take(inputLength + j).ToArray();

			Console.WriteLine(new string(outputChars));
			Console.WriteLine(string.Format("Original length: {0}, New length: {1}", inputLength, outputChars.Length));

		}
	}
}
