using System;

namespace MathildaLib
{
	/// <summary>
	/// Negative variable operator.
	/// 
	/// (*-1*a) -> (-a)
	/// </summary>
	public class NegativeVariableOperator : Operator
	{
		public NegativeVariableOperator()
		{
		}

		public override bool Can(Node node)
		{
			var list = node as ListNode;
			if (list == null) {
				return false;
			}
			if (list.NodeCount != 2) {
				return false;
			}
			if (list.Operation != ListNode.ListOperation.Product) {
				return false;
			}

			var num = list [0] as NumberNode;
			if (num == null) {
				return false;
			}
			if (num != -1) {
				return false;
			}

			return true;
		}

		public override void Do(ref Node node)
		{
			var list = node as ListNode;
			var newList = new ListNode (ListNode.ListOperation.Sum,
			                            list [1]);
			newList.SetInverted (0, true);
			node = newList;
		}

		public static void NegativeVariable (SearchModule.Search search) {
			search.Alternative (new NegativeVariableOperator ());
		}
	}
}

