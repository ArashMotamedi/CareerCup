using CareerCup.Types.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	static class Util
	{
		public static void PrintMatrix(int[][] matrix)
		{
			for (int row = 0; row < matrix.Length; row++)
			{
				for (int col = 0; col < matrix[row].Length; col++)
				{
					Console.Write(matrix[row][col] + " ");
				}
				Console.WriteLine();
			}
		}

		public static void PrintList(Node head)
		{
			var node = head;
			while (node != null)
			{
				Console.Write(node.Value + " => ");
				node = node.Next;
			}
			Console.WriteLine("NULL");
		}


	}
}
