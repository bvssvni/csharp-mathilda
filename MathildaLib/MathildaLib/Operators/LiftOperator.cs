using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class LiftOperator : Operator
	{
		public LiftOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.List.Count != 1) {
				return false;
			}
			if (list.Operation == ListNode.ListOperation.List) {
				return false;
			}

			return true;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			node = list.List [0];
		}

		public static void Lift (SearchModule.Search search) {
			search.Alternative (new LiftOperator ());
		}
	}
}

