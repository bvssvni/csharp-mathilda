using System;

namespace MathildaLib
{
	public class NegativeProductOperator : Operator
	{
		public NegativeProductOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.Operation != ListNode.ListOperation.Sum) {
				return false;
			}

			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				var subList = list [i] as ListNode;
				if (subList == null) {
					continue;
				}
				if (subList.Operation != ListNode.ListOperation.Product) {
					continue;
				}
				if (subList.NodeCount == 1) {
					continue;
				}

				var num = subList [0] as NumberNode;
				if (num == null) {
					continue;
				}
				if (num != -1) {
					continue;
				}

				return true;
			}

			return false;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			int n = list.NodeCount;
			for (int i = 0; i < n; i++) {
				var subList = list [i] as ListNode;
				if (subList == null) {
					continue;
				}
				if (subList.Operation != ListNode.ListOperation.Product) {
					continue;
				}
				if (subList.NodeCount == 1) {
					continue;
				}
				
				var num = subList [0] as NumberNode;
				if (num == null) {
					continue;
				}
				if (num != -1) {
					continue;
				}

				subList.RemoveNodeAt (0);
				list.SetInverted (i, !list.GetInverted (i));
			}
		}

		public static void NegativeProduct (SearchModule.Search search) {
			search.Alternative (new NegativeProductOperator ());
		}
	}
}

