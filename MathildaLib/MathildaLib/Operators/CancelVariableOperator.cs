using System;

namespace MathildaLib
{
	public class CancelVariableOperator : Operator
	{
		private int m_i;
		private int m_j;

		public CancelVariableOperator(int i, int j)
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
			if (list.Operation != ListNode.ListOperation.Sum &&
			    list.Operation != ListNode.ListOperation.Product) {
				return false;
			}
			if (list.GetInverted (m_i) == list.GetInverted (m_j)) {
				return false;
			}

			var a = list [m_i] as VariableNode;
			var b = list [m_j] as VariableNode;
			if (a == null || b == null) {
				return false;
			}
			if (a.Name != b.Name) {
				return false;
			}

			return true;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			list.RemoveNodeAt (m_j);
			list.RemoveNodeAt (m_i);
			if (list.Operation == ListNode.ListOperation.Sum) {
				list.InsertNode (m_i, new NumberNode (0));
			} else if (list.Operation == ListNode.ListOperation.Product) {
				list.InsertNode (m_i, new NumberNode (1));
			}

			return node;
		}

		public static void CancelVariable (SearchModule.Search search) {
			var node = search.ActiveNode as ListNode;
			if (node == null) {
				return;
			}

			node.ForEachNeighborPair ((int i, int j) => {
				search.Alternative (new CancelVariableOperator (i, j));
			});
		}
	}
}

