using System;

namespace MathildaLib
{
	public class MultiplyOneOperator : Operator
	{
		public MultiplyOneOperator()
		{
		}

		public override bool Can(IComparable node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.Operation != ListNode.ListOperation.Product) {
				return false;
			}

			return true;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			list.RemoveOnes ();
			return node;
		}

		public static void MultiplyOne (SearchModule.Search search) {
			search.Alternative (new MultiplyOneOperator ());
		}
	}
}

