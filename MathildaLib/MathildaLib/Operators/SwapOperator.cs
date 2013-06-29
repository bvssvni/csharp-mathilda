using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class SwapOperator : Operator
	{
		private int m_i;
		private int m_j;

		public SwapOperator(int i, int j)
		{
			m_i = i;
			m_j = j;
		}

		public override bool Can(IComparable node)
		{
			return node is ListNode;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			list.Swap (m_i, m_j);
			return node;
		}

		public static void Swap (SearchModule.Search search) {
			var list = search.ActiveNode;
			if (list == null) {
				return;
			}

			ListNode.ForEachPairDelegate swap = (int i, int j) => {
				var op = new SwapOperator (i, j);
				search.Alternative (op);
			};
			list.ForEachPair (swap);
		}
	}
}

