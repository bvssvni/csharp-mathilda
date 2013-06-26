using System;

namespace MathildaLib
{
	public static class EqualityModule
	{
		public static bool IsEqualTo (this Node a, Node b) {
			var ops = new SearchModule.OperatorDelegate [] {
				SwapOperator.Swap,
			};
			a = a.Minimize (null, ops);
			b = b.Minimize (null, ops);
			return a.CompareTo (b) == 0;
		}
	}
}

