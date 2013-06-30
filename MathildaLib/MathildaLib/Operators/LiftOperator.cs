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
			if (list.NodeCount != 1) {
				return false;
			}
			if (list.GetInverted (0)) {
				return false;
			}

			return true;
		}

		public static Node Lift (Node node, out int times) {
			times = 0;
			var list = node as ListNode;
			while (list != null && list.NodeCount == 1 && !list.GetInverted (0)) {
				node = list [0];
				list = node as ListNode;
				times++;
			}

			return node;
		}

		public override void Do(ref Node node)
		{
			int times = 0;
			node = Lift (node, out times);
		}

		public static void Lift (SearchModule.Search search) {
			search.Alternative (new LiftOperator ());
		}
	}
}

