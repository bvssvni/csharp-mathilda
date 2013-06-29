using System;
using System.Collections.Generic;
using NumberNode = MathildaLib.ListNode.NumberNode;

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
	/// 		N	V	LL	SL	PL
	/// 	N	3	3	3	3	3
	/// 	V	3	3	3	3	3
	/// 	LL	2	2	-
	/// 	SL
	/// 	PL
	/// 
	/// </summary>
	public static class MultiplyExtensionModule
	{
		public static ListNode Multiply (this NumberNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static ListNode Multiply (this Node a, string b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a,
				new VariableNode (b)});
			return list;
		}

		public static ListNode Multiply (this Node a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this NumberNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this NumberNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, 
				new VariableNode (b)});
			return list;
		}

		public static ListNode Multiply (this VariableNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this ListNode a, double b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (new NumberNode (b));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new NumberNode (b)});
			return list;
		}

		public static ListNode Multiply (this ListNode a, NumberNode b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (b);
				return a;
			}

			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this ListNode a, string b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (new VariableNode (b));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new VariableNode (b)});
			return list;
		}

		public static ListNode Multiply (this ListNode a, VariableNode b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this NumberNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Product) {
				b.InsertNode (0, a);
				return b;
			}
			
			return new ListNode (ListNode.ListOperation.Product, a, b);
		}

		public static ListNode Multiply (this VariableNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Product) {
				b.InsertNode (0, a);
				return b;
			}

			return new ListNode (ListNode.ListOperation.Product, a, b);
		}

		public static Node Multiply (this Node a, Node b) {
			if (a is NumberNode && b is NumberNode) {
				var an = a as NumberNode;
				var bn = b as NumberNode;
				return an.Multiply (bn);
			}
			if (a is NumberNode && b is VariableNode) {
				var an = a as NumberNode;
				var bn = b as VariableNode;
				return an.Multiply (bn);
			}
			if (a is NumberNode && b is ListNode) {
				var an = a as NumberNode;
				var bn = b as ListNode;
				return an.Multiply (bn);
			}
			if (a is VariableNode && b is NumberNode) {
				var an = a as VariableNode;
				var bn = b as NumberNode;
				return an.Multiply (bn);
			}
			if (a is VariableNode && b is VariableNode) {
				var an = a as VariableNode;
				var bn = b as VariableNode;
				return an.Multiply (bn);
			}
			if (a is VariableNode && b is ListNode) {
				var an = a as VariableNode;
				var bn = b as ListNode;
				return an.Multiply (bn);
			}
			if (a is ListNode && b is NumberNode) {
				var an = a as ListNode;
				var bn = b as NumberNode;
				return an.Multiply (bn);
			}
			if (a is ListNode && b is VariableNode) {
				var an = a as ListNode;
				var bn = b as VariableNode;
				return an.Multiply (bn);
			}

			throw new NotImplementedException ();
		}
	}
}

