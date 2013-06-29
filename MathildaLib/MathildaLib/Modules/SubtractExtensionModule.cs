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
	/// 	SL	3
	/// 	PL	
	/// 
	/// </summary>
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

		public static ListNode Subtract (this NumberNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a,
				new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}

		public static ListNode Subtract (this NumberNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a,
				b});
			list.SetInverted (1, true);
			return list;
		}

		public static ListNode Subtract (this NumberNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Sum) {
				b.InsertNode (0, a);
				int n = b.NodeCount;
				for (int i = 1; i < n; i++) {
					b.SetInverted (i, !b.GetInverted (i));
				}
				return b;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                     new List<Node> () {
				a, b});
			list.SetInverted (1, true);
			return list;
		}

		public static ListNode Subtract (this VariableNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new NumberNode (-b)});
			return list;
		}

		public static ListNode Subtract (this VariableNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new NumberNode (-b.Value)});
			return list;
		}

		public static ListNode Subtract (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}

		public static ListNode Subtract (this VariableNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			list.SetInverted (1, true);
			return list;
		}

		public static ListNode Subtract (this VariableNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Sum) {
				b.InsertNode (0, a);
				int n = b.NodeCount;
				for (int i = 1; i < n; i++) {
					b.SetInverted (i, !b.GetInverted (i));
				}
				return b;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			list.SetInverted (1, true);
			return list;
		}

		public static ListNode Subtract (this ListNode a, double b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (new NumberNode (-b));
				return a;
			}

			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new NumberNode (-b)});
			return list;
		}

		public static ListNode Subtract (this ListNode a, NumberNode b) {
			if (a.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (new NumberNode (-b.Value));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, new NumberNode (-b.Value)});
			return list;
		}
	}
}

