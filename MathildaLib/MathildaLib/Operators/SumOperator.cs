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
			var list = node as ListNode;
			if (list == null) {
				return false;
			}

			return list.Operation == ListNode.ListOperation.Sum;
		}

		public override void Do(Node node, out Node result)
		{
			var list = node as ListNode;
			list.Sum ();
			result = list;
		}

		public static void Sum (SortedList<Node, Operator> states, 
		                        Node node, 
		                        SortedList<Node, bool> history) {
			var op = new SumOperator ();
			if (!op.Can (node)) {
				return;
			}

			var copy = node.Copy ();
			op.Do (copy, out copy);
			if (history.ContainsKey (copy)) {
				return;
			}
			if (states.ContainsKey (copy)) {
				return;
			}
			
			states.Add (copy, op);
		}
	}
}

