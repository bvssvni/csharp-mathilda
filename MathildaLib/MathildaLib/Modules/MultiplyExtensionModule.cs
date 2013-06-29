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

		public static ListNode Multiply (this ListNode a, ListNode b) {
			if (a.Operation == ListNode.ListOperation.Sum &&
			    b.Operation == ListNode.ListOperation.Sum) {
				var newList = new List<Node> ();
				int n = a.NodeCount;
				int m = b.NodeCount;
				for (int i = 0; i < n; i++) {
					for (int j = 0; j < m; j++) {
						var ai = a [i];
						var bj = b [j];
						newList.Add (ai.Multiply (bj));
					}
				}

				return new ListNode (ListNode.ListOperation.Sum, newList);
			}

			if (a.Operation == ListNode.ListOperation.Sum &&
			    b.Operation == ListNode.ListOperation.Product) {
				var newList = new List<Node> ();
				int n = a.NodeCount;
				for (int i = 0; i < n; i++) {
					var copy = b.Copy () as ListNode;
					copy.InsertNode (0, a [i].Copy ());
					newList.Add (copy);
				}

				return new ListNode (ListNode.ListOperation.Sum, newList);
			}

			throw new NotImplementedException ();
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
			if (a is ListNode && b is ListNode) {
				var an = a as ListNode;
				var bn = b as ListNode;
				return an.Multiply (bn);
			}

			throw new NotImplementedException ();
		}
	}
}

