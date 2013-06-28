using System;

namespace MathildaLib
{
	public static class EqualityModule
	{
		public static bool IsEqualTo (this IComparable a, IComparable b, SearchModule.OperatorDelegate[] operators = null) {
			if (operators == null) {
				operators = SearchModule.CreateOperators ();
			}

			a = a.Minimize (null, operators);
			b = b.Minimize (null, operators);
			return a.CompareTo (b) == 0;
		}
	}
}

