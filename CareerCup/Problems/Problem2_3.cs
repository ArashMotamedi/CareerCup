using CareerCup.Types.SinglyLinkedList;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Problems
{
	class Problem2_3 : IProblem
	{
		public string Id()
		{
			return "2.3";
		}

		public string Statement()
		{
			return "Delete a given node from the middle of a singly linked list.";
		}

		public string[] TestArgs()
		{
			Node head = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, new Node(6, new Node(7, new Node(8))))))));

			var list = JsonConvert.SerializeObject(head);

			return new string[] {
				"3/" + list
			};
		}

		public void Run(string args)
		{
			var arg = args.Split(new char[] { '/' });
			var nth = Convert.ToInt16(arg[0]);
			var head = JsonConvert.DeserializeObject<Node>(arg[1]);
			var node = head;
			for (int i = 0; i < nth; i++)
			{
				node = node.Next;
			}
			Util.PrintList(head);
			Console.WriteLine("Deleting node " + node.Value);

			while (node.Next != null)
			{
				node.Value = node.Next.Value;
				if (node.Next.Next == null)
					node.Next = null;
				else
					node = node.Next;
			}

			Util.PrintList(head);
		}
	}
}
