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

			int n = a.List.Count;
			int m = b.List.Count;
			if (n != m) {
				throw new Exception ("Lists not of same size");
			}
			
			var list = new List<Node> ();
			for (int i = 0; i < n; i++) {
				var aItem = a.List [i];
				var bItem = b.List [i];
				list.Add (aItem.Multiply (bItem));
			}
			
			return new ListNode (ListNode.ListOperation.Sum, list);
		}
	}
}

