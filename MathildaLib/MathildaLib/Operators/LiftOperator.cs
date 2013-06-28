using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class LiftOperator : Operator
	{
		public LiftOperator()
		{
		}

		public override bool Can(IComparable node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.NodeCount != 1) {
				return false;
			}

			return true;
		}

		public override IComparable Do(IComparable node)
		{
			var list = node as ListNode;
			node = list [0];
			return node;
		}

		public static void Lift (SearchModule.Search search) {
			search.Alternative (new LiftOperator ());
		}
	}
}

