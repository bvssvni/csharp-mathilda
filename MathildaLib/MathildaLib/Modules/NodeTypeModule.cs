using System;
using NumberNode = MathildaLib.ListNode.NumberNode;

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
				return 2;
			}

			return -1;
		}
	}
}

