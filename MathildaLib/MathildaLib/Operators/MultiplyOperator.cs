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

			return true;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			var a = list.List [m_i];
			var b = list.List [m_j];
			if (a is NumberNode && b is NumberNode) {
				var an = a as NumberNode;
				var bn = b as NumberNode;
				an.Value *= bn.Value;
				list.List.RemoveAt (m_j);
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
			if (!(a is ListNode) && b is ListNode) {
				var an = a as VariableNode;
				var bn = b as ListNode;
				if (bn.Operation == ListNode.ListOperation.Sum) {
					var newList = new List<Node> ();
					foreach (var item in bn.List) {
						newList.Add (an.Multiply (item));
					}

					list.List.RemoveAt (m_j);
					list.List.RemoveAt (m_i);
					list.List.Insert (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
					return;
				}
			}
			if (a is ListNode) {
				var an = a as ListNode;
				if (an.Operation == ListNode.ListOperation.Sum) {
					var newList = new List<Node> ();
					foreach (var item in an.List) {
						newList.Add (item.Multiply (b));
					}

					list.List.RemoveAt (m_j);
					list.List.RemoveAt (m_i);
					list.List.Insert (m_i, new ListNode (ListNode.ListOperation.Sum, newList));
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

