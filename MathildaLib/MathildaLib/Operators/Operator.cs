using System;

namespace MathildaLib
{
	public abstract class Operator
	{
		public abstract bool Can (IComparable node);
		public abstract IComparable Do (IComparable node);
	}
}

