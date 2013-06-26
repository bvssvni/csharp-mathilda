using System;

namespace MathildaLib
{
	public class SumOperator : Operator
	{
		public SumOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}

			return list.Operation == ListNode.ListOperation.Sum;
		}

		public override void Do(Node node)
		{
			var list = node as ListNode;
			list.Sum ();
		}
	}
}

