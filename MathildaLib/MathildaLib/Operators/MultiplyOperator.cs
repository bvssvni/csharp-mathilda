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

		public override bool Can(IComparable node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}

			return true;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			var a = list [m_i];
			var b = list [m_j];
			if (a is NumberNode && b is NumberNode) {
				var an = a as NumberNode;
				var bn = b as NumberNode;
				an.Value *= bn.Value;
				list.RemoveNodeAt (m_j);
				return node;
			}
			if (a is NumberNode && b is VariableNode) {
				return node;
			}
			if (a is VariableNode && b is NumberNode) {
				return node;
			}
			if (a is VariableNode && b is VariableNode) {
				return node;
			}
			if (a is NumberNode && b is ListNode) {
				var an = a as NumberNode;
				var bn = b as ListNode;
				if (bn.Operation == ListNode.ListOperation.Sum) {
					var newList = new List<IComparable> ();
					int n = bn.NodeCount;
					for (int i = 0; i < n; i++) {
						var item = bn [i];
						var mul = an.Multiply (item);

						newList.Add (mul);
					}
					
					list.RemoveNodeAt (m_j);
					list.RemoveNodeAt (m_i);
					list.InsertNode (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
					return node;
				}
			}
			if (a is VariableNode && b is ListNode) {
				var an = a as VariableNode;
				var bn = b as ListNode;
				if (bn.Operation == ListNode.ListOperation.Sum) {
					var newList = new List<IComparable> ();
					int n = bn.NodeCount;
					for (int i = 0; i < n; i++) {
						var item = bn [i];
						var mul = an.Multiply (item);

						newList.Add (mul);
					}

					list.RemoveNodeAt (m_j);
					list.RemoveNodeAt (m_i);
					list.InsertNode (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
					return node;
				}
			}
			if (a is ListNode) {
				var an = a as ListNode;
				if (an.Operation == ListNode.ListOperation.Sum) {
					var newList = new List<IComparable> ();
					int n = an.NodeCount;
					for (int i = 0; i < n; i++) {
						var item = an [i];
						newList.Add (item.Multiply (b));
					}

					list.RemoveNodeAt (m_j);
					list.RemoveNodeAt (m_i);
					list.InsertNode (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
					return node;
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

