using System;

namespace MathildaLib
{
	public class ZeroAddOperator : Operator
	{
		public ZeroAddOperator()
		{
		}

		public override bool Can(IComparable node)
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
				var item = list [i];
				var number = item as NumberNode;
				if (number == null) {
					continue;
				}
				
				if (number.Value == 0) return true;
			}
			
			return false;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			list.RemoveZeroes ();
			return list;
		}

		public static void ZeroAdd (SearchModule.Search search) {
			search.Alternative (new ZeroAddOperator ());
		}
	}
}

