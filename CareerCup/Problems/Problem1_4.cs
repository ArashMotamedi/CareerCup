using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	class Problem1_4 : IProblem
	{
		public string Id()
		{
			return "1.4";
		}

		public string Statement()
		{
			return "Determine if two strings are anagrams.";
		}

		public string[] TestArgs()
		{
			return new string[] { "listen,silent", "eleven plus two,twelve plus one", "how about these,clearly not" };
		}

		public void Run(string args)
		{
			string[] strs = args.Split(new char[] { ',' });
			if (strs.Length != 2)
				throw new ArgumentException("Enter two strings separated by comma.");

			// Convert to char array
			var chars1 = strs[0].ToCharArray();
			var chars2 = strs[1].ToCharArray();
			
			bool areAnagrams = true;
			// Keep count of every character per string, exclude space
			int[] charCount1 = new int[256];
			int[] charCount2 = new int[256];

			//TODO: Try to combine the for loops below
			for (int i = 0; i < chars1.Length; i++)
			{
				var c = chars1[i];
				if (c != ' ')
					charCount1[c]++;
			}

			for (int i = 0; i < chars2.Length; i++)
			{
				var c = chars2[i];
				if (c != ' ')
					charCount2[c]++;
			}

			// Now compare if we have equal number of every character in both strings
			// if (!chars1.SequenceEqual(chars2)) areAnagrams = false;
			for (int i = 0; i < 256; i++)
				if (charCount1[i] != charCount2[i])
				{
					areAnagrams = false;
					break;
				}

			if (areAnagrams) Console.WriteLine("Anagrams");
			else Console.WriteLine("Not anagrams");

		}
	}
}
