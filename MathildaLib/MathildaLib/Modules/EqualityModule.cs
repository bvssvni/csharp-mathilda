using System;

namespace MathildaLib
{
	public static class EqualityModule
	{
		public static bool IsEqualTo (this Node a, Node b, SearchModule.OperatorDelegate[] operators = null) {
			if (operators == null) {
				operators = SearchModule.CreateOperators ();
			}

			a = a.Minimize (operators);

			// TEST
			Console.WriteLine ("========");

			b = b.Minimize (operators);
			return a.CompareTo (b) == 0;
		}
	}
}

