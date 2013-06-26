using System;

namespace MathildaLib
{
	public static class EqualityModule
	{
		public static bool IsEqualTo (this Node a, Node b) {
			a = a.Minimize (null, SearchModule.StandardOperations);
			b = b.Minimize (null, SearchModule.StandardOperations);
			return a.CompareTo (b) == 0;
		}
	}
}

