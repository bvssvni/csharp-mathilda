using System;

namespace MathildaLib
{
	public static class NodeTypeModule
	{
		public static int TypeId (this Node obj) {
			if (obj is NumberNode) {
				return 0;
			}
			if (obj is VariableNode) {
				return 1;
			}
			if (obj is ListNode) {
				if (obj is ProductListNode) {
					return 3;
				} else if (obj is SumListNode) {
					return 4;
				}

				return 2;
			}

			return -1;
		}
	}
}

