using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	class Problem1_2 : IProblem
	{

		public string Id()
		{
			return "1.2";
		}

		public string DefaultArgs()
		{
			return "invert this\0";
		}

		public string Statement()
		{
			return "Reverse a C-Style String";
		}

		public void Run(string args)
		{
			if (string.IsNullOrEmpty(args))
			{
				Console.WriteLine("Null or empty string");
				return;
			}

			if (args.Last() != '\0') {
				Console.WriteLine("Not a C-String. Last character must be \\0");
				return;
			}

			var inputChars = args.ToCharArray();
			foreach (var c in inputChars)
				Console.Write(Convert.ToInt16(c) + " ");

			Console.WriteLine();

			var inputLength = inputChars.Length;
			for (int i = 0; i < (inputLength - 1) / 2; i++)
			{
				char tmp = inputChars[i];
				inputChars[i] = inputChars[inputLength - 2 - i];
				inputChars[inputLength - 2 - i] = tmp;
			}

			foreach (var c in inputChars)
				Console.Write(Convert.ToInt16(c) + " ");

			Console.WriteLine();
			Console.WriteLine(new string(inputChars));
		}
	}
}
