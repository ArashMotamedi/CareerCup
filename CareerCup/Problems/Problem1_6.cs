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
			printImage(image);

			int width = image.Length;
			for (int row = 0; row < width / 2; row++)
			{
				for (int col = row; col < width - 1 - (row * 2); col++)
				{
					// Remember 4 pixels
					// TODO, probably don't need as many temps
					int tmp = image[row][col];
					image[row][col] = image[col][row];
					image[col][row] = tmp;

					tmp = image[row][col];
					image[row][col] = image[width - 1 - row][width - 1 - col];
					image[width - 1 - row][width - 1 - col] = tmp;

					tmp = image[row][col];



				}
			}

			Console.WriteLine("Rotated:");
			printImage(image);
		}

		private void printImage(int[][] image)
		{
			for (int row = 0; row < image.Length; row++)
			{
				for (int col = 0; col < image[row].Length; col++)
				{
					Console.Write(image[row][col] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
