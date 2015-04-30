using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Types.SinglyLinkedList
{
	public class Node
	{
		public int Value;
		public Node Next;

		public Node() { }

		public Node(int value) : this(value, null) { }

		public Node(int value, Node next)
		{
			Value = value;
			Next = next;
		}
	}
}
