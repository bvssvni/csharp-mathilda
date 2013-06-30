using System;

namespace MathildaLib
{
	public class ZeroMultiplyOperator : Operator
	{
		public ZeroMultiplyOperator()
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

			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				var item = list [i];
				var number = item as NumberNode;
				if (number == null) {
					continue;
				}

				if (number == 0 && !list.GetInverted (i)) {
					return true;
				}
			}

			return false;
		}

		public override void Do(ref Node node)
		{
			node = new NumberNode (0);
		}

		public static void ZeroMultiply (SearchModule.Search search) {
			search.Alternative (new ZeroMultiplyOperator ());
		}
	}
}

