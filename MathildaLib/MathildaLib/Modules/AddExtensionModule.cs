using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class AddExtensionModule
	{
		public static ListNode Add (this VariableNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a,
				b});
			return list;
		}

		public static ListNode Add (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, 
				new VariableNode (b)});
			return list;
		}

		public static ListNode Add (this VariableNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, double b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, Node b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, string b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (new VariableNode (b));
				return a;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, new VariableNode (b)});
			return list;
		}

		public static ListNode Add (this VariableNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Sum) {
				b.InsertNode (0, a);
				return b;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, VariableNode b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<IComparable> () {
				a, b});
			return list;
		}
	}
}

