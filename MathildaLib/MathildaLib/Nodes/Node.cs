using System;
using System.Collections.Generic;
using NumberNode = MathildaLib.ListNode.NumberNode;

namespace MathildaLib
{
	public abstract class Node : IComparable<Node>
	{
		public abstract int CompareTo(Node other);
		public abstract Node Copy ();
		public abstract override string ToString();

		public static Node Number (double value) {
			return new NumberNode (value);
		}
	}
}

