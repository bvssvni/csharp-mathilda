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
	public static class DivideExtensionModule
	{
		public static ListNode Divide (this NumberNode a, NumberNode b) {
			b.Value = 1.0 / b.Value;
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			return list;
		}
		
		public static ListNode Divide (this NumberNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a,
				new NumberNode (1.0 / b)});
			return list;
		}
		
		public static ListNode Divide (this NumberNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a,
				new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this NumberNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a,
				b});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this NumberNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Product) {
				b.InsertNode (0, a);
				int n = b.NodeCount;
				for (int i = 1; i < n; i++) {
					b.SetInverted (i, !b.GetInverted (i));
				}
				return b;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this VariableNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new NumberNode (1.0 / b)});
			return list;
		}
		
		public static ListNode Divide (this VariableNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new NumberNode (1.0 / b.Value)});
			return list;
		}
		
		public static ListNode Divide (this VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this VariableNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this VariableNode a, ListNode b) {
			if (b.Operation == ListNode.ListOperation.Product) {
				b.InsertNode (0, a);
				int n = b.NodeCount;
				for (int i = 1; i < n; i++) {
					b.SetInverted (i, !b.GetInverted (i));
				}
				return b;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this ListNode a, double b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (new NumberNode (1.0 / b));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new NumberNode (1.0 / b)});
			return list;
		}
		
		public static ListNode Divide (this ListNode a, NumberNode b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (new NumberNode (1.0 / b.Value));
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new NumberNode (1.0 / b.Value)});
			return list;
		}
		
		public static ListNode Divide (this ListNode a, string b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (new VariableNode (b));
				a.SetInverted (a.NodeCount - 1, true);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, new VariableNode (b)});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this ListNode a, VariableNode b) {
			if (a.Operation == ListNode.ListOperation.Product) {
				a.AddNode (b);
				a.SetInverted (a.NodeCount - 1, true);
				return a;
			}
			
			var list = new ListNode (ListNode.ListOperation.Product,
			                         new List<Node> () {
				a, b});
			list.SetInverted (1, true);
			return list;
		}
		
		public static ListNode Divide (this ListNode a, ListNode b) {
			if (a.Operation == ListNode.ListOperation.Sum &&
			    b.Operation == ListNode.ListOperation.Sum) {
				var list = new ListNode (ListNode.ListOperation.Product,
				                         new List<Node> () {
					a, b});
				list.SetInverted (1, true);
				return list;
			}
			if (a.Operation == ListNode.ListOperation.Sum &&
			    b.Operation == ListNode.ListOperation.Product) {
				int n = b.NodeCount;
				for (int i = 0; i < n; i++) {
					b.SetInverted (i, !b.GetInverted (i));
				}

				b.InsertNode (0, a);
				return b;
			}
			if (a.Operation == ListNode.ListOperation.Product &&
			    b.Operation == ListNode.ListOperation.Sum) {
				a.AddNode (b);
				a.SetInverted (a.NodeCount - 1, true);
				return a;
			}
			if (a.Operation == ListNode.ListOperation.Product &&
			    b.Operation == ListNode.ListOperation.Product) {
				int n = b.NodeCount;
				for (int i = 0; i < n; i++) {
					b.SetInverted (i, !b.GetInverted (i));
				}

				int m = a.NodeCount;
				for (int i = 0; i < m; i++) {
					b.AddNode (a [i]);
				}

				return b;
			}

			throw new NotImplementedException ();
		}
		
		public static ListNode Divide (this Node a, Node b) {
			if (a is NumberNode && b is NumberNode) {
				var an = a as NumberNode;
				var bn = b as NumberNode;
				return an.Divide (bn);
			}
			if (a is NumberNode && b is VariableNode) {
				var an = a as NumberNode;
				var bn = b as VariableNode;
				return an.Divide (bn);
			}
			if (a is NumberNode && b is ListNode) {
				var an = a as NumberNode;
				var bn = b as ListNode;
				return an.Divide (bn);
			}
			if (a is VariableNode && b is NumberNode) {
				var an = a as VariableNode;
				var bn = b as NumberNode;
				return an.Divide (bn);
			}
			if (a is VariableNode && b is VariableNode) {
				var an = a as VariableNode;
				var bn = b as VariableNode;
				return an.Divide (bn);
			}
			if (a is VariableNode && b is ListNode) {
				var an = a as VariableNode;
				var bn = b as ListNode;
				return an.Divide (bn);
			}
			if (a is ListNode && b is NumberNode) {
				var an = a as ListNode;
				var bn = b as NumberNode;
				return an.Divide (bn);
			}
			if (a is ListNode && b is VariableNode) {
				var an = a as ListNode;
				var bn = b as VariableNode;
				return an.Divide (bn);
			}
			if (a is ListNode && b is ListNode) {
				var an = a as ListNode;
				var bn = b as ListNode;
				return an.Divide (bn);
			}
			
			throw new NotImplementedException ();
		}
	}
}

