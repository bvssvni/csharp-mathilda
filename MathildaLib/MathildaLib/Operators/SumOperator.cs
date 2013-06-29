using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class SumOperator : Operator
	{
		public SumOperator()
		{
		}

		public override bool Can(IComparable node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}

			return list.Operation == ListNode.ListOperation.Sum;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			list.Sum ();
			return node;
		}

		public static void Sum (SearchModule.Search search) {
			var op = new SumOperator ();
			search.Alternative (op);
		}
	}
}

