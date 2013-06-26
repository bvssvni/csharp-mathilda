using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SearchModule
	{
		public delegate void OperatorDelegate (SortedList<Node, Operator> states,
		                                       Node node,
		                                       SortedList<Node, bool> history);

		public static Node Minimize (this Node node, 
		                         SortedList<Node, bool> history = null,
		                             params OperatorDelegate[] operators) {
			if (history == null) {
				history = new SortedList<Node, bool> ();
				history.Add (node, true);
			}

			// Collect the operations.
			var states = new SortedList<Node, Operator> ();
			int n = operators.Length;
			for (int i = 0; i < n; i++) {
				operators [i] (states, node, history);
			}

			while (states.Count > 0) {
				var min = states.Keys [0];
				if (min.CompareTo (node) < 0) {
					history.Add (min, true);
					node = Minimize (min, history, operators);
				}

				states.RemoveAt (0);
			}

			return node;
		}
	}
}

