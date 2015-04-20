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

		public string[] TestArgs()
		{
			return new string[] {
				"Is this all unique character? The answer is no",
				"Unique? Yah"
			};
		}
	
		public string Statement() { return "Is string all unique characters? Solve without additional DS."; }

		public void Run(string args) {
			var allUnique = true;
			var chars = new bool[256];

			foreach (var c in args.ToCharArray())
			{
				if (chars[c])
				{
					allUnique = false;
					break;
				}
				chars[c] = true;
			}

			if (allUnique)
			{
				Console.WriteLine("Yes! All unique.");
			}
			else
			{
				Console.WriteLine("No! Repeated characters.");
			}
		}
	}
}
