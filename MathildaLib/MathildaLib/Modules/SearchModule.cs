using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SearchModule
	{
		public delegate void OperatorDelegate (Search search);

		private static OperatorDelegate[] StandardOperations = new OperatorDelegate [] {
			LiftOperator.Lift,
			FixSignOperator.FixSign,
			SumOperator.Sum,
			ZeroMultiplyOperator.ZeroMultiply,
			ZeroAddOperator.ZeroAdd,
			MultiplyOneOperator.MultiplyOne,
			ScalarProductOperator.Product,
			NegativeProductOperator.NegativeProduct,
			MultiplyOperator.Multiply,
			AddOperator.Add,
			CancelVariableOperator.CancelVariable,
			SwapOperator.Swap,
		};

		public static OperatorDelegate[] CreateOperators (params OperatorDelegate[] ops) {
			int n = StandardOperations.Length + ops.Length;
			var newOps = new OperatorDelegate [n];
			StandardOperations.CopyTo (newOps, 0);
			ops.CopyTo (newOps, StandardOperations.Length);

			return newOps;
		}

		public struct Search {
			public SortedList<Node, bool> History;
			public Node Node;
			public ListNode.Address Address;
			public SortedList<Node, Operator> States;

			public ListNode ActiveNode {
				get {
					return Address == null 
						? Node as ListNode :
							((ListNode)Node) [Address] as ListNode;
				}
			}

			public void Alternative (Operator op) {
				if (Address == null) {
					// Get operator directly on node.
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
				} else {
					// Get operator on sub nodes of node.
					var list = Node as ListNode;
					var subNode = list [Address];
					if (!op.Can (subNode)) {
						return;
					}

					var copy = Node.Copy () as ListNode;
					var inverted = copy.GetInvertedByAddress (Address);
					subNode = copy [Address];
					op.Do (ref subNode);
					copy [Address] = subNode;
					copy.SetInvertedByAddress (Address, inverted);
					if (History.ContainsKey (copy)) {
						return;
					}
					if (States.ContainsKey (copy)) {
						return;
					}

					States.Add (copy, op);
				}
			}
		}

		public static Node Minimize (this Node node, OperatorDelegate[] operators,
		                         SortedList<Node, bool> history = null) {
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

			var list = node as ListNode;
			if (list != null) {
				list.ForEachNode ((ListNode.Address address) => {
					var subSearch = new Search () {
						History = history,
						Node = list,
						Address = address,
						States = states
					};
					for (int i = 0; i < n; i++) {
						operators [i] (subSearch);
					}
				});
			}

			while (states.Count > 0) {
				var min = states.Keys [0];

				if (min.CompareTo (node) < 0 && !history.ContainsKey (min)) {

					// TEST
					Console.WriteLine ("{0}: {1}", states.Values [0], min);

					history.Add (min, true);
					node = Minimize (min, operators, history);
				}

				states.RemoveAt (0);
			}

			return node;
		}
	}
}

