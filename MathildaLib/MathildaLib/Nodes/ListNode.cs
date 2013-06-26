using System;
using System.Text;
using System.Collections.Generic;

namespace MathildaLib
{
	public class ListNode : Node
	{
		private List<Node> m_list;

		public ListNode(List<Node> list)
		{
			m_list = list;
		}

		public void Swap (int i, int j) {
			var tmp = m_list [i];
			m_list [i] = m_list [j];
			m_list [j] = tmp;
		}

		public delegate void ForeachPairDelegate (int i, int j);

		public void ForeachPair (ForeachPairDelegate f) {
			int n = m_list.Count;
			for (int i = 0; i < n; i++) {
				for (int j = i + 1; j < n; j++) {
					f (i, j);
				}
			}
		}

		public override Node Copy()
		{
			var newList = new List<Node> ();
			foreach (var item in m_list) {
				newList.Add (item.Copy ());
			}

			return new ListNode (newList);
		}

		public override int CompareTo(Node other)
		{
			var otherNode = other as ListNode;
			if (otherNode == null) {
				// Return 2 to tell we do not know how to handle comparison.
				return 2;
			}

			var compareCount = m_list.Count.CompareTo (otherNode.m_list.Count);
			if (compareCount != 0) {
				return compareCount;
			}

			int n = m_list.Count;
			for (int i = 0; i < n; i++) {
				var compareItem = m_list [i].CompareTo (otherNode.m_list [i]);
				if (compareItem != 0) {
					return compareItem;
				}
			}

			return 0;
		}

		public override string ToString()
		{
			var strb = new StringBuilder ();
			strb.Append ("{");
			int n = m_list.Count;
			for (int i = 0; i < n; i++) {
				if (i != 0) {
					strb.Append (",");
				}

				strb.Append (m_list [i].ToString ());
			}

			strb.Append ("}");
			return strb.ToString ();
		}
	}
}

