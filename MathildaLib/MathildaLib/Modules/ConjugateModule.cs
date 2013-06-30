using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class ConjugateModule
	{
		public static Node Conjugate (this Node a, string b) {
			return Conjugate (a, new VariableNode (b));
		}

		public static Node Conjugate (this Node a, VariableNode v) {
			var name = v.Name;
			var b = a.Copy ();
			if (b is NumberNode) {
				return b;
			}
			if (b is VariableNode) {
				var bn = b as VariableNode;
				if (bn.Name == name) {
					var list = new ListNode (ListNode.ListOperation.Sum,
					                         new List<Node> () {
						b});
					list.SetInverted (0, true);
					return list;
				}

				return b;
			}
			if (b is ListNode) {
				var bn = b as ListNode;
				bn.ForEachNode ((ListNode.Address address) => {
					var subNode = bn [address] as VariableNode;
					if (subNode == null) {
						return;
					}
					if (subNode.Name != name) {
						return;
					}

					var list = new ListNode (ListNode.ListOperation.Sum,
					                         new List<Node> () {
						subNode});
					list.SetInverted (0, true);
					bn [address] = list;
				});

				return b;
			}

			throw new NotImplementedException ();
		}
	}
}

