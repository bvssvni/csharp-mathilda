using System;

namespace MathildaLib
{
	public class ComplexRule : Rule
	{
		private string m_name;
		private double m_value;

		public ComplexRule(string name, double value)
		{
			m_name = name;
			m_value = value;
		}

		public override void Operator(SearchModule.Search search)
		{
			var list = search.ActiveNode as ListNode;
			if (list == null) {
				return;
			}
			if (list.Operation != ListNode.ListOperation.Product) {
				return;
			}

			list.ForEachNeighborPair ((int i, int j) => {
				var a = list.List [i] as VariableNode;
				var b = list.List [j] as VariableNode;
				if (a == null || b == null) {
					return;
				}
				if (a.Name != m_name || b.Name != m_name) {
					return;
				}

				search.Alternative (new ReplaceOperator (i, j, new NumberNode (m_value)));
			});
		}
	}
}

