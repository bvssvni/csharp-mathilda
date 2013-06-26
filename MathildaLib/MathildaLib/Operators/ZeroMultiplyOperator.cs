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
			if (list.Operation == ListNode.ListOperation.List) {
				return false;
			}

			foreach (var item in list.List) {
				var number = item as NumberNode;
				if (number == null) {
					continue;
				}

				if (number.Value == 0) return true;
			}

			return false;
		}

		public override void Do(Node node, out Node result)
		{
			result = new NumberNode (0);
		}

		public static void ZeroMultiply (SearchModule.Search search) {
			search.Alternative (new ZeroMultiplyOperator ());
		}
	}
}

