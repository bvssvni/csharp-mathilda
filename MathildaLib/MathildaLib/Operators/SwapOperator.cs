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

		public override bool Can(Node node)
		{
			return node is ListNode;
		}

		public override void Do(Node node, out Node result)
		{
			var list = node as ListNode;
			list.Swap (m_i, m_j);
			result = list;
		}

		public static void Swap (SortedList<Node, Operator> states, 
		                         Node node, 
		                         SortedList<Node, bool> history) {
			var list = node as ListNode;
			if (list == null) {
				return;
			}

			ListNode.ForeachPairDelegate swap = (int i, int j) => {
				var op = new SwapOperator (i, j);
				if (!op.Can (node)) {
					return;
				}
				
				var copy = node.Copy ();
				op.Do (copy, out copy);
				if (history.ContainsKey (copy)) {
					return;
				}
				if (states.ContainsKey (copy)) {
					return;
				}
				
				states.Add (copy, op);
			};
			list.ForeachPair (swap);
		}
	}
}

