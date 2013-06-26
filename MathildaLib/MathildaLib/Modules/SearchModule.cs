using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SearchModule
	{
		public static Node Minimize (this Node node, 
		                         SortedList<Node, bool> history = null) {
			if (history == null) {
				history = new SortedList<Node, bool> ();
				history.Add (node, true);
			}
			
			var states = new SortedList<Node, Operator> ();
			SwapOperator.Swap (states, node, history);

			while (states.Count > 0) {
				var min = states.Keys [0];
				if (min.CompareTo (node) < 0) {
					history.Add (min, true);
					node = Minimize (min, history);
				}

				states.RemoveAt (0);
			}

			return node;
		}
	}
}

