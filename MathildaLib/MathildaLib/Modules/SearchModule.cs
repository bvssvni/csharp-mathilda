using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class SearchModule
	{
		public delegate void OperatorDelegate (Search search);

		private static OperatorDelegate[] StandardOperations = new OperatorDelegate [] {
			SumOperator.Sum,
			ZeroMultiplyOperator.ZeroMultiply,
			ZeroAddOperator.ZeroAdd,
			MultiplyOneOperator.MultiplyOne,
			ScalarProductOperator.Product,
			MultiplyOperator.Multiply,
			AddOperator.Add,
			CancelVariableOperator.CancelVariable,
			LiftOperator.Lift,
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
			public SortedList<IComparable, bool> History;
			public IComparable Node;
			public ListNode.Address Address;
			public SortedList<IComparable, Operator> States;

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
					
					IComparable copy = CopyModule.Copy (Node);
					copy = op.Do (copy);

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

					var copy = CopyModule.Copy (Node) as ListNode;
					subNode = copy [Address] as Node;
					subNode = op.Do (subNode);
					copy [Address] = subNode;
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

		public static IComparable Minimize (this IComparable node, 
		                         SortedList<IComparable, bool> history = null,
		                             params OperatorDelegate[] operators) {
			if (history == null) {
				history = new SortedList<IComparable, bool> ();
				history.Add (node, true);
			}

			// Collect the operations.
			var states = new SortedList<IComparable, Operator> ();
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

