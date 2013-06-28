using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SubtractExtensionModule
	{
		public static ListNode Subtract (this NumberNode a, NumberNode b) {
			b.Value = -b.Value;
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}
		
		public static ListNode Subtract (this NumberNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a,
				new NumberNode (-b)});
			return list;
		}
	}
}

