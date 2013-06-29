using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SubtractExtensionModule
	{
		public static ListNode Subtract (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}
	}
}

