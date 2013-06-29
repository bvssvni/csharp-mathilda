using System;

namespace MathildaLib
{
	public class AddOperator : Operator
	{
		private int m_i;
		private int m_j;

		public AddOperator(int i, int j)
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
			if (list.Operation != ListNode.ListOperation.Sum) {
				return false;
			}
			if (list.GetInverted (m_i) != list.GetInverted (m_j)) {
				// Do not add nodes that are not in same direction.
				return false;
			}

			return true;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			var a = list [m_i];
			var b = list [m_j];
			if (a is VariableNode && b is VariableNode) {
				var an = a as VariableNode;
				var bn = b as VariableNode;
				if (an.Name != bn.Name) {
					return node;
				}

				var newNode = new ListNode (ListNode.ListOperation.Product,
				                            new NumberNode (2), a);
				list.RemoveNodeAt (m_j);
				list.RemoveNodeAt (m_i);
				list.InsertNode (m_i, newNode);
				return node;
			}
			if (a is ListNode && b is ListNode) {
				var an = a as ListNode;
				var bn = b as ListNode;
				if (an.Operation != ListNode.ListOperation.Sum ||
				    bn.Operation != ListNode.ListOperation.Sum) {
					return node;
				}
				if (an.CompareToIgnoreScalar (bn) != 0) {
					return node;
				}

				// Add numbers together.
				var aIndex = an [0] is NumberNode ? 0 : -1;
				var aValue = aIndex == 0 ? ((NumberNode)an [0]).Value : 0;
				var bValue = bn [0] is NumberNode ? ((NumberNode)bn [0]).Value : 0;
				list.RemoveNodeAt (m_j);
				if (aIndex == -1) {
					an.InsertNode (0, new NumberNode (aValue + bValue));
				} else {
					an [0] = new NumberNode (aValue + bValue);
				}

				return node;
			}

			return node;
		}

		public static void Add (SearchModule.Search search) {
			var list = search.ActiveNode as ListNode;
			if (list == null) {
				return;
			}

			list.ForEachNeighborPair ((int i, int j) => {
				search.Alternative (new AddOperator (i, j));
			});
		}
	}
}

