using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public static class DotProductFlatteningModule
	{
		public static ListNode DotProduct (this ListNode a, ListNode b) {
			if (a.Operation != ListNode.ListOperation.List) {
				throw new Exception ("Expected list type in parameter 'a'");
			}
			if (b.Operation != ListNode.ListOperation.List) {
				throw new Exception ("Expected list type in parameter 'b'");
			}

			int n = a.NodeCount;
			int m = b.NodeCount;
			if (n != m) {
				throw new Exception ("Lists not of same size");
			}
			
			var list = new List<Node> ();
			for (int i = 0; i < n; i++) {
				var aItem = a [i];
				var bItem = b [i];
				list.Add (aItem.Multiply (bItem));
			}
			
			return new ListNode (ListNode.ListOperation.Sum, list);
		}
	}
}

