using System;

namespace MathildaLib
{
	public abstract class Operator
	{
		public abstract bool Can (Node node);
		public abstract void Do (Node node, out Node result);
	}
}

