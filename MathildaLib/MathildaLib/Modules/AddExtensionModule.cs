using System;
using System.Collections.Generic;

namespace MathildaLib
{
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
	}
}

