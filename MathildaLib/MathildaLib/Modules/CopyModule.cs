using System;

namespace MathildaLib
{
	public static class CopyModule
	{
		public static IComparable Copy (IComparable obj) {
			if (obj is Node) {
				var node = obj as Node;
				return node.Copy ();
			}

			return obj;
		}
	}
}

