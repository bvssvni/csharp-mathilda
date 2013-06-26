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
	/// 		N	V	LL	SL	PL
	/// 	N	2	2	2	2	2
	/// 	V	2	2	2	2	2
	/// 	LL
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
				a.List.Add (new NumberNode (b));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new NumberNode (b)});
			return list;
		}

		public static ListNode Multiply (this ListNode a, Node b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.List.Add (b);
				return a;
			}

			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this ListNode a, string b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.List.Add (new VariableNode (b));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new VariableNode (b)});
			return list;
		}

		public static ListNode Multiply (this ListNode a, VariableNode b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.List.Add (b);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode Multiply (this NumberNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.List) {
				var list = new List<Node> ();
				foreach (var item in b.List) {
					list.Add (a.Multiply (item));
				}

				return new ListNode (ListNode.ListOperation.List, list);
			}
			if (b.Operation == ListNode.ListOperation.Sum) {
				var list = new List<Node> ();
				foreach (var item in b.List) {
					list.Add (a.Multiply (item));
				}
				
				return new ListNode (ListNode.ListOperation.Sum, list);
			}
			if (b.Operation == ListNode.ListOperation.Product) {
				b.List.Insert (0, a);
				return b;
			}

			return null;
		}

		public static ListNode Multiply (this VariableNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.List) {
				var list = new List<Node> ();
				foreach (var item in b.List) {
					list.Add (a.Multiply (item));
				}
				
				return new ListNode (ListNode.ListOperation.List, list);
			}
			if (b.Operation == ListNode.ListOperation.Sum) {
				var list = new List<Node> ();
				foreach (var item in b.List) {
					list.Add (a.Multiply (item));
				}
				
				return new ListNode (ListNode.ListOperation.Sum, list);
			}
			if (b.Operation == ListNode.ListOperation.Product) {
				b.List.Insert (0, a);
				return b;
			}
			
			return null;
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
			
			return null;
		}
	}
}

