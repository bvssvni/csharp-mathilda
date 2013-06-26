using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class MultiplyExtensionModule
	{
		public static ListNode Multiply (this NumberNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static ListNode Multiply (this Node a, string b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a,
				new VariableNode (b)});
			return list;
		}

		public static ListNode Multiply (this Node a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this NumberNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a, 
				new VariableNode (b)});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				a, b});
			return list;
		}
		
		public static Node Multiply (this Node a, Node b) {
			if (a is NumberNode && b is NumberNode) {
				var an = a as NumberNode;
				var bn = b as NumberNode;
				return an.Multiply (bn);
			}
			
			return null;
		}
	}
}

