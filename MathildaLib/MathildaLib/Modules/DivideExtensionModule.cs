using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class DivideExtensionModule
	{
		public static ListNode Divide (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, 
				new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}
	}
}

