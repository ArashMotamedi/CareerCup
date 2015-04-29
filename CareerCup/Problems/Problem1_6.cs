using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	class Problem1_6 : IProblem
	{

		public string Id()
		{
			return "1.6";
		}

		public string Statement()
		{
			return "Rotate image in NxN matrix 90 degrees. Each pixel is 4 bytes.";
		}

		public string[] TestArgs()
		{
			return new string[] { 
				JsonConvert.SerializeObject(new int[][] {
					new int[] { 11, 12, 13, 14, 15 },
					new int[] { 21, 22, 23, 24, 25 },
					new int[] { 31, 32, 33, 34, 35 }, 
					new int[] { 41, 42, 43, 44, 45 },
					new int[] { 51, 52, 53, 54, 55 }
				}),

				JsonConvert.SerializeObject(new int[][] {
					new int[] { 11, 12, 13, 14 },
					new int[] { 21, 22, 23, 24 },
					new int[] { 31, 32, 33, 34 }, 
					new int[] { 41, 42, 43, 44 },
				})

			};
		}

		public void Run(string args)
		{
			var image = JsonConvert.DeserializeObject<int[][]>(args);
			Util.PrintMatrix(image);

			int last = image.Length - 1;
			for (int row = 0; row < last; row++)
			{
				for (int col = row; col < last; col++)
				{
					// Rotate 4 corners
					
					// Corner 1
					int tmp = image[col][last];
					image[col][last] = image[row][col];

					// Corner 2
					int tmp2 = image[last][last - col + row];
					image[last][last - col + row] = tmp;

					// Corner 3
					tmp = image[last - col + row][row];
					image[last - col + row][row] = tmp2;

					// Corner 4
					image[row][col] = tmp;
				}

				last--;
			}

			Console.WriteLine("Rotated:");
			Util.PrintMatrix(image);
		}
	}
}
