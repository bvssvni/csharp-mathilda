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

		public override void Do(ref Node node)
		{
			
			// TEST
			Console.WriteLine ("Lift {0}", node);

			var list = node as ListNode;
			node = list [0];
		}

		public static void Lift (SearchModule.Search search) {
			search.Alternative (new LiftOperator ());
		}
	}
}

