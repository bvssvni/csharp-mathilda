using System;

namespace MathildaLib
{
	public class ZeroMultiplyOperator : Operator
	{
		public ZeroMultiplyOperator()
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

			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				var item = list [i];
				if (!(item is double)) {
					continue;
				}

				var number = (double)item;
				if (number == 0) return true;
			}

			return false;
		}

		public override IComparable Do(IComparable node)
		{
			node = 0.0;
			return node;
		}

		public static void ZeroMultiply (SearchModule.Search search) {
			search.Alternative (new ZeroMultiplyOperator ());
		}
	}
}

