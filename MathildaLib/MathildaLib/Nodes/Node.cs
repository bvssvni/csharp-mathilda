using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public abstract class Node : IComparable
	{
		public abstract int CompareTo(object other);
		public abstract Node Copy ();
		public abstract override string ToString();
	}
}

