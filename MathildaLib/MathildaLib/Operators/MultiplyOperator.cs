using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class MultiplyOperator : Operator
	{
		private int m_i;
		private int m_j;

		public MultiplyOperator(int i, int j)
		{
			m_i = i;
			m_j = j;
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.Operation != ListNode.ListOperation.Product) {
				return false;
			}

			return true;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			var a = list [m_i];
			var b = list [m_j];
			if (a is NumberNode && b is NumberNode) {
				var an = a as NumberNode;
				var bn = b as NumberNode;
				an.Value *= bn.Value;
				list.RemoveNodeAt (m_j);
				return;
			}
			if (a is NumberNode && b is VariableNode) {
				return;
			}
			if (a is VariableNode && b is NumberNode) {
				return;
			}
			if (a is VariableNode && b is VariableNode) {
				return;
			}
			if (a is NumberNode && b is ListNode) {
				var an = a as NumberNode;
				var bn = b as ListNode;
				if (bn.Operation == ListNode.ListOperation.Sum) {
					if (list.GetInverted (m_j)) {
						return;
					}

					var newList = new List<Node> ();
					int n = bn.NodeCount;
					for (int i = 0; i < n; i++) {
						var item = bn [i];
						var mul = an.Multiply (item);
						newList.Add (mul);
					}
					
					list.RemoveNodeAt (m_j);
					list.RemoveNodeAt (m_i);
					list.InsertNode (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
					return;
				}
			}
			if (a is VariableNode && b is ListNode) {
				var an = a as VariableNode;
				var bn = b as ListNode;
				if (bn.Operation == ListNode.ListOperation.Sum) {
					if (list.GetInverted (m_j)) {
						return;
					}

					var newList = new List<Node> ();
					int n = bn.NodeCount;
					for (int i = 0; i < n; i++) {
						var item = bn [i];
						var mul = an.Multiply (item);

						newList.Add (mul);
					}

					list.RemoveNodeAt (m_j);
					list.RemoveNodeAt (m_i);
					list.InsertNode (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
					return;
				}
				if (bn.Operation == ListNode.ListOperation.Product) {
					if (list.GetInverted (m_j)) {
						var bIndex = bn [0] is NumberNode ? 1 : 0;
						if (bIndex == 1 && bn.NodeCount == 2 && bn [1] is VariableNode) {
							var bvar = bn [1] as VariableNode;
							if (bvar.Name != an.Name) {
								return;
							}

							// (*a/(*2*a)) -> (/(*1*a))
							var scalar = bn [0] as NumberNode;
							scalar.Value -= 1;
							list.RemoveNodeAt (m_i);
							return;
						}
					}
				}
			}
			if (a is ListNode) {
				var an = a as ListNode;
				if (an.Operation == ListNode.ListOperation.Sum) {
					var newList = new List<Node> ();
					var bInverted = list.GetInverted (m_j);
					if (bInverted && an.CompareTo (b) == 0) {
						// (a + 1) / (a + 1) -> 1
						list.RemoveNodeAt (m_j);
						list.RemoveNodeAt (m_i);
						list.InsertNode (m_i, new NumberNode (1));
						return;
					}

					int n = an.NodeCount;
					for (int i = 0; i < n; i++) {
						var item = an [i];
						if (bInverted) {
							newList.Add (item.Divide (b));
						} else {
							newList.Add (item.Multiply (b));
						}
					}

					list.RemoveNodeAt (m_j);
					list.RemoveNodeAt (m_i);
					list.InsertNode (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
					return;
				}
			}

			throw new NotImplementedException ();
		}

		public static void Multiply (SearchModule.Search search) {
			var list = search.ActiveNode as ListNode;
			if (list == null) {
				return;
			}
			if (list.Operation != ListNode.ListOperation.Product) {
				return;
			}
			
			ListNode.ForEachPairDelegate multiply = (int i, int j) => {
				var op = new MultiplyOperator (i, j);
				search.Alternative (op);
			};
			list.ForEachNeighborPair (multiply);
		}
	}
}

