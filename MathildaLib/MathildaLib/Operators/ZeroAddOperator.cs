using System;

namespace MathildaLib
{
	public class ZeroAddOperator : Operator
	{
		public ZeroAddOperator()
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
			var list = node as ListNode;
			list.RemoveZeroes ();
			result = list;
		}

		public static void ZeroAdd (SearchModule.Search search) {
			search.Alternative (new ZeroAddOperator ());
		}
	}
}

