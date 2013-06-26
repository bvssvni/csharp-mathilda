using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public abstract class Node : IComparable<Node>
	{
		public abstract int CompareTo(Node other);
		public abstract Node Copy ();
		public abstract override string ToString();
	}
}

