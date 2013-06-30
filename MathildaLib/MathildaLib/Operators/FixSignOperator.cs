using System;

namespace MathildaLib
{
	public class FixSignOperator : Operator
	{
		public FixSignOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				if (list.GetInverted (i) && list [i] is NumberNode) {
					return true;
				}
			}

			return false;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				if (list.GetInverted (i) && list [i] is NumberNode) {
					var number = list [i] as NumberNode;
					if (list.Operation == ListNode.ListOperation.Sum) {
						number.Value = -number.Value;
					} else {
						if (number.Value == 0.0) {
							continue;
						}

						number.Value = 1.0 / number.Value;
					}

					list.SetInverted (i, false);
				}
			}
		}

		public static void FixSign (SearchModule.Search search) {
			var list = search.ActiveNode as ListNode;
			if (list == null) {
				return;
			}

			search.Alternative (new FixSignOperator ());
		}
	}
}

