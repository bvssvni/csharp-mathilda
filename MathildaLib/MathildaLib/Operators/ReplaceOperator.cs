using System;

namespace MathildaLib
{
	/// <summary>
	/// Replace operator.
	/// 
	/// Used by ComplexRule to replace two variables with a constant.
	/// </summary>
	public class ReplaceOperator : Operator
	{
		private int m_i;
		private int m_j;
		private Node m_node;

		public ReplaceOperator(int i, int j, Node node)
		{
			m_i = i;
			m_j = j;
			m_node = node;
		}

		public override bool Can(Node node)
		{
			return node is ListNode;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			list.List.RemoveAt (m_j);
			list.List.RemoveAt (m_i);
			list.List.Insert (m_i, m_node);
		}
	}
}

