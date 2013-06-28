using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class SumOperator : Operator
	{
		public SumOperator()
		{
		}

		public override bool Can(Node node)
		{
			var sum = node as SumNode;
			if (sum == null) {
				return false;
			}

			return true;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			list.Sum ();
		}

		public static void Sum (SearchModule.Search search) {
			var op = new SumOperator ();
			search.Alternative (op);
		}
	}
}

