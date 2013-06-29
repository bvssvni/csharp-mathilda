using System;

namespace MathildaLib
{
	public static class NodeTypeModule
	{
		public static int TypeId (this object obj) {
			if (obj is double) {
				return 0;
			}
			if (obj is VariableNode) {
				return 1;
			}
			if (obj is ListNode) {
				return 2;
			}

			return -1;
		}
	}
}

