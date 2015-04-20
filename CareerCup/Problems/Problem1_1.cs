using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	class Problem1_1 : IProblem
	{
		public string Id()
		{
			return "1.1";
		}

		public string DefaultArgs()
		{
			return "Are there only unique characters in this string? (the answer is no)";
		}
	
		public string Statement() { return "Is string all unique characters? Solve without additional DS."; }

		public void Run(string args) {
			var allUnique = true;
			var chars = new HashSet<char>();
			foreach (var c in args.ToCharArray())
			{
				if (chars.Contains(c))
				{
					allUnique = false;
					break;
				}
				chars.Add(c);
			}

			if (allUnique)
			{
				Console.WriteLine("All unique characters");
			}
			else
			{
				Console.WriteLine("Repeated character found");
			}
		}
	}
}
