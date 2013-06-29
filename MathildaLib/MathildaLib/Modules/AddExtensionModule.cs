using System;
using System.Collections.Generic;

namespace MathildaLib
{
	/// <summary>
	/// Multiply extension module.
	/// 
	/// N - number
	/// V - variable
	/// LL - list
	/// SL - sum list
	/// PL - multiply list
	/// 
	/// 1: Added code.
	/// 2: Added to overriding extension operator.
	/// 3: Added unit test for native type.
	/// 4: Added unit test for overridden type.
	/// 
	/// 		N	V	SL	PL
	/// 	N	3	3	3	3
	/// 	V	3	3	3	3
	/// 	SL	3	3	3	3
	/// 	PL	3	3	3	3
	/// 
	/// </summary>
	public static class AddExtensionModule
	{
		public static ListNode Add (this NumberNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this NumberNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static ListNode Add (this NumberNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a,
				new VariableNode (b)});
			return list;
		}

		public static ListNode Add (this NumberNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this VariableNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static ListNode Add (this VariableNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, 
				new VariableNode (b)});
			return list;
		}

		public static ListNode Add (this VariableNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, double b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (new NumberNode (b));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new NumberNode (b)});
			return list;
		}

		public static ListNode Add (this NumberNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Sum) {
				b.InsertNode (0, a);
				return b;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, Node b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, string b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (new VariableNode (b));
				return a;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new VariableNode (b)});
			return list;
		}

		public static ListNode Add (this VariableNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Sum) {
				b.InsertNode (0, a);
				return b;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Add (this ListNode a, VariableNode b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}
	}
}

