using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SwapModule
	{
		public static Node Sort (Node node, 
		                         Dictionary<Node, bool> history = null) {
			if (history == null) {
				history = new Dictionary<Node, bool> ();
			}

			var list = node as ListNode;
			if (list == null) {
				return node;
			}

			var states = new SortedList<Node, Operator> ();
			ListNode.ForeachPairDelegate swap = (int i, int j) => {
				var copy = list.Copy () as ListNode;
				var op = new SwapOperator (i, j);
				op.Do (copy);
				if (history.ContainsKey (copy)) {
					return;
				}
				if (states.ContainsKey (copy)) {
					return;
				}

				states.Add (copy, op);
			};
			list.ForeachPair (swap);

			while (states.Count > 0) {
				var min = states.Keys [0];
				if (min.CompareTo (node) < 0) {
					history.Add (min, true);
					node = Sort (min, history);
				}

				states.RemoveAt (0);
			}

			return node;
		}
	}
}

