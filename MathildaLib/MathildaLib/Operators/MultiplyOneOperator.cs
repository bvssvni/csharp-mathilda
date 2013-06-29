using System;

namespace MathildaLib
{
	public class MultiplyOneOperator : Operator
	{
		public MultiplyOneOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.Operation != ListNode.ListOperation.Product) {
				return false;
			}
			if (list.NodeCount == 1) {
				return false;
			}

			return true;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			list.RemoveOnes ();
		}

		public static void MultiplyOne (SearchModule.Search search) {
			search.Alternative (new MultiplyOneOperator ());
		}
	}
}

