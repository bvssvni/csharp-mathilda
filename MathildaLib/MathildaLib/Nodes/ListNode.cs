using System;
using System.Text;
using System.Collections.Generic;

namespace MathildaLib
{
	public class ListNode : Node
	{
		public enum ListOperation
		{
			List,
			Sum
		}

		private ListOperation m_listOperation;
		private List<Node> m_list;

		public ListOperation Operation {
			get {
				return m_listOperation;
			}
		}

		public ListNode(ListOperation listOperation, List<Node> list)
		{
			m_listOperation = listOperation;
			m_list = list;
		}

		public void Swap (int i, int j) {
			var tmp = m_list [i];
			m_list [i] = m_list [j];
			m_list [j] = tmp;
		}

		public void Sum () {
			int n = m_list.Count;
			var firstNumberIndex = -1;
			for (int i = 0; i < n - 1; i++) {
				if (m_list [i] is NumberNode) {
					firstNumberIndex = i;
				}
			}

			if (firstNumberIndex == -1) {
				return;
			}

			var a = m_list [firstNumberIndex] as NumberNode;
			for (int i = firstNumberIndex + 1; i < n; i++) {
				var b = m_list [i] as NumberNode;
				if (b == null) {
					continue;
				}

				a.Value += b.Value;
				m_list.RemoveAt (i);
				n--;
				i--;
			}
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

			return new ListNode (m_listOperation, newList);
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

