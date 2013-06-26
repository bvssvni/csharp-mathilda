using System;

namespace MathildaLib
{
	public static class EqualityModule
	{
		public static bool IsEqualTo (this Node a, Node b) {
			var ops = new SearchModule.OperatorDelegate [] {
				SumOperator.Sum,
				ZeroMultiplyOperator.ZeroMultiply,
				ZeroAddOperator.ZeroAdd,
				ProductOperator.Product,
				LiftOperator.Lift,
				SwapOperator.Swap,
			};
			a = a.Minimize (null, ops);
			b = b.Minimize (null, ops);

			// TEST
			Console.WriteLine (a);
			Console.WriteLine (b);

			return a.CompareTo (b) == 0;
		}
	}
}

