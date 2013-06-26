using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SearchModule
	{
		public delegate void OperatorDelegate (Search search);

		public static OperatorDelegate[] StandardOperations = new OperatorDelegate [] {
			SumOperator.Sum,
			ZeroMultiplyOperator.ZeroMultiply,
			ZeroAddOperator.ZeroAdd,
			ScalarProductOperator.Product,
			MultiplyOperator.Multiply,
			LiftOperator.Lift,
			SwapOperator.Swap,
		};

		public struct Search {
			public SortedList<Node, bool> History;
			public Node Node;
			public SortedList<Node, Operator> States;

			public void Alternative (Operator op) {
				if (!op.Can (Node)) {
					return;
				}
				
				var copy = Node.Copy ();
				op.Do (ref copy);
				if (History.ContainsKey (copy)) {
					return;
				}
				if (States.ContainsKey (copy)) {
					return;
				}
				
				States.Add (copy, op);
			}
		}

		public static Node Minimize (this Node node, 
		                         SortedList<Node, bool> history = null,
		                             params OperatorDelegate[] operators) {
			if (history == null) {
				history = new SortedList<Node, bool> ();
				history.Add (node, true);
			}

			// Collect the operations.
			var states = new SortedList<Node, Operator> ();
			var search = new Search () {
				History = history,
				Node = node,
				States = states
			};
			int n = operators.Length;
			for (int i = 0; i < n; i++) {
				operators [i] (search);
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

