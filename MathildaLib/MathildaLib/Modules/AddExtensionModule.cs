using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class AddExtensionModule
	{
		public static SumNode Add (this NumberNode a, NumberNode b) {
			var list = new SumNode (new List<Node> () {
				a, b});
			return list;
		}

		public static SumNode Add (this NumberNode a, double b) {
			var list = new SumNode (new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static SumNode Add (this NumberNode a, string b) {
			var list = new SumNode (new List<Node> () {
				a,
				new VariableNode (b)});
			return list;
		}

		public static SumNode Add (this NumberNode a, VariableNode b) {
			var list = new SumNode (new List<Node> () {
				a, b});
			return list;
		}

		public static SumNode Add (this VariableNode a, double b) {
			var list = new SumNode (new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static SumNode Add (this VariableNode a, NumberNode b) {
			var list = new SumNode (new List<Node> () {
				a, b});
			return list;
		}

		public static SumNode Add (this VariableNode a, string b) {
			var list = new SumNode (new List<Node> () {
				a, 
				new VariableNode (b)});
			return list;
		}

		public static SumNode Add (this VariableNode a, VariableNode b) {
			var list = new SumNode (new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, double b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.List.Add (new NumberNode (b));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new NumberNode (b)});
			return list;
		}

		public static ListNode Add (this ListNode a, Node b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.List.Add (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, string b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.List.Add (new VariableNode (b));
				return a;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new VariableNode (b)});
			return list;
		}

		public static ListNode Add (this VariableNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Sum) {
				b.List.Insert (0, a);
				return b;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, VariableNode b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.List.Add (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}
	}
}

