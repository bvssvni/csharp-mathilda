using System;

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

		public override void Do(Node node)
		{
			var list = node as ListNode;
			list.Swap (m_i, m_j);
		}

		public override void Undo(Node node)
		{
			var list = node as ListNode;
			list.Swap (m_j, m_i);
		}
	}
}

