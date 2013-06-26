using System;
using System.Text;
using System.Collections.Generic;

namespace MathildaLib
{
	public class ListNode : Node
	{
		public enum ListOperation : int
		{
			List = 0,
			Sum = 1,
			Product = 2,
		}

		private ListOperation m_listOperation;
		private List<Node> m_list;

		public ListOperation Operation {
			get {
				return m_listOperation;
			}
		}

		public List<Node> List {
			get {
				return m_list;
			}
		}

		public ListNode(ListOperation listOperation, List<Node> list)
		{
			m_listOperation = listOperation;
			m_list = list;
		}

		public ListNode (ListOperation listOperation, params Node[] items) {
			m_listOperation = listOperation;
			m_list = new List<Node> (items);
		}

		public ListNode (params Node[] items) {
			m_listOperation = ListOperation.List;
			m_list = new List<Node> (items);
		}

		public ListNode (params double[] numbers) {
			m_listOperation = ListOperation.List;
			int n = numbers.Length;
			m_list = new List<Node> (n);
			for (int i = 0; i < n; i++) {
				m_list.Add (new NumberNode (numbers [i]));
			}
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
					break;
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

		public void Product () {
			int n = m_list.Count;
			var firstNumberIndex = -1;
			for (int i = 0; i < n - 1; i++) {
				if (m_list [i] is NumberNode) {
					firstNumberIndex = i;
					break;
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
				
				a.Value *= b.Value;
				m_list.RemoveAt (i);
				n--;
				i--;
			}
		}

		/*
		public void Flatten () {
			int n = m_list.Count;
			var firstNumberIndex = -1;
			for (int i = 0; i < n - 1; i++) {
				if (m_list [i] is ListNode && ((ListNode)m_list [i]).m_listOperation == ListOperation.Sum) {
					firstNumberIndex = i;
					break;
				}
			}

			if (firstNumberIndex == -1) {
				return;
			}

			var subList = ((ListNode)m_list [firstNumberIndex]).m_list;
			var newList = new List<Node> ();
			int m = subList.Count;
			for (int j = 0; j < m; j++) {
				var subItem = subList [j];
				for (int i = 0; i < n; i++) {

				}
			}
		}
		*/

		public void RemoveZeroes () {
			int n = m_list.Count;
			for (int i = 0; i < n; i++) {
				var item = m_list [i] as NumberNode;
				if (item == null) {
					continue;
				}

				if (item.Value != 0) {
					continue;
				}

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
				return this.TypeId ().CompareTo (other.TypeId ());
			}

			var compareOperation = m_listOperation.CompareTo (otherNode.m_listOperation);
			if (compareOperation != 0) {
				return compareOperation;
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

			if (m_listOperation == ListOperation.List) {
				strb.Append ("{");
				int n = m_list.Count;
				for (int i = 0; i < n; i++) {
					if (i != 0) {
						strb.Append (",");
					}

					strb.Append (m_list [i].ToString ());
				}

				strb.Append ("}");
			} else if (m_listOperation == ListOperation.Sum) {
				strb.Append ("(");
				int n = m_list.Count;
				for (int i = 0; i < n; i++) {
					if (i != 0) {
						strb.Append ("+");
					}
					
					strb.Append (m_list [i].ToString ());
				}
				
				strb.Append (")");
			} else if (m_listOperation == ListOperation.Product) {
				strb.Append ("(");
				int n = m_list.Count;
				for (int i = 0; i < n; i++) {
					if (i != 0) {
						strb.Append ("*");
					}
					
					strb.Append (m_list [i].ToString ());
				}
				
				strb.Append (")");
			}

			return strb.ToString ();
		}


	}
}

