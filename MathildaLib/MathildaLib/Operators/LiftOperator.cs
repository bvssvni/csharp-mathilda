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

		public override void Do(Node node, out Node result)
		{
			var list = node as ListNode;
			result = list.List [0];
		}

		public static void Lift (SortedList<Node, Operator> states, 
		                  Node node, 
		                  SortedList<Node, bool> history) {
			var op = new LiftOperator ();
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

