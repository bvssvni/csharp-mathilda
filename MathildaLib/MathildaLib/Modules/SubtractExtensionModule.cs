using System;
using System.Collections.Generic;
using NumberNode = MathildaLib.ListNode.NumberNode;

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

		public static ListNode Subtract (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}
	}
}

