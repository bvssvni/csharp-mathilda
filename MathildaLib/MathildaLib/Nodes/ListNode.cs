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
			Product = 1,
			Sum = 2,
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

		public void RemoveOnes () {
			int n = m_list.Count;
			for (int i = 0; i < n; i++) {
				var item = m_list [i] as NumberNode;
				if (item == null) {
					continue;
				}
				
				if (item.Value != 1) {
					continue;
				}
				
				m_list.RemoveAt (i);
				n--;
				i--;
			}
		}

		public delegate void ForEachPairDelegate (int i, int j);

		public void ForEachPair (ForEachPairDelegate f) {
			int n = m_list.Count;
			for (int i = 0; i < n; i++) {
				for (int j = i + 1; j < n; j++) {
					f (i, j);
				}
			}
		}

		public void ForEachNeighborPair (ForEachPairDelegate f) {
			int n = m_list.Count;
			for (int i = 0; i < n - 1; i++) {
				f (i, i + 1);
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

		public int CompareToIgnoreScalar (Node other)
		{
			var otherNode = other as ListNode;
			if (otherNode == null) {
				return this.TypeId ().CompareTo (other.TypeId ());
			}
			
			var thisSubLists = this.NumberOfNonProductSubLists ();
			var otherSubLists = otherNode.NumberOfNonProductSubLists ();
			var compareSubLists = thisSubLists.CompareTo (otherSubLists);
			if (compareSubLists != 0) {
				return compareSubLists;
			}
			
			var compareOperation = m_listOperation.CompareTo (otherNode.m_listOperation);
			if (compareOperation != 0) {
				return compareOperation;
			}
			if (this.Operation != ListOperation.Product) {
				throw new Exception ("Requires product list to compare ignored");
			}

			var thisIndex = this.List [0] is NumberNode ? 1 : 0;
			var otherIndex = otherNode.List [0] is NumberNode ? 1 : 0;

			var thisCount = this.List.Count - thisIndex;
			var otherCount = otherNode.List.Count - otherIndex;
			var compareCount = thisCount.CompareTo (otherCount);
			if (compareCount != 0) {
				return compareCount;
			}

			int n = thisCount;
			for (int i = 0; i < n; i++) {
				var compareItem = m_list [i + thisIndex].CompareTo (otherNode.m_list [i + otherIndex]);
				if (compareItem != 0) {
					return compareItem;
				}
			}

			return 0;
		}

		public int NumberOfNonProductSubLists () {
			int count = 0;
			foreach (var item in m_list) {
				var subList = item as ListNode;
				if (subList == null) {
					continue;
				}
				if (subList.Operation == ListOperation.Product) {
					continue;
				}

				count++;
			}

			return count;
		}

		public override int CompareTo (Node other)
		{
			var otherNode = other as ListNode;
			if (otherNode == null) {
				return this.TypeId ().CompareTo (other.TypeId ());
			}

			var thisSubLists = this.NumberOfNonProductSubLists ();
			var otherSubLists = otherNode.NumberOfNonProductSubLists ();
			var compareSubLists = thisSubLists.CompareTo (otherSubLists);
			if (compareSubLists != 0) {
				return compareSubLists;
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
			strb.Append (m_listOperation.ToString() + " ");
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

		public delegate void ForEachNodeDelegate (Address address);

		public void ForEachNode (ForEachNodeDelegate f, Address address = null) {
			if (address == null) {
				address = new Address ();
			}

			int n = m_list.Count;
			for (int i = 0; i < n; i++) {
				address.Add (i);
				f (address);
				var subList = m_list [i] as ListNode;
				if (subList != null) {
					subList.ForEachNode (f, address);
				}

				address.RemoveAt (address.Count - 1);
			}
		}

		private Node GetByAddress (Address address, int i = 0) {
			var remainder = address.Count - i;
			if (remainder == 1) {
				return m_list [address [i]];
			} else {
				var subList = m_list [address [i]] as ListNode;
				return subList.GetByAddress (address, i + 1);
			}
		}

		private void SetByAddress (Address address, Node node, int i = 0) {
			var remainder = address.Count - i;
			if (remainder == 1) {
				m_list [address [i]] = node;
			} else {
				var subList = m_list [address [i]] as ListNode;
				subList.SetByAddress (address, node, i + 1);
			}
		}

		public Node this [Address address] {
			get {
				return GetByAddress (address, 0);
			}
			set {
				SetByAddress (address, value, 0);
			}
		}

		public class Address : List<int> {
			public Address (params int[] items) : base (items) {

			}

			public Address () {

			}

			public bool IsEqualTo (Address b) {
				var compareCount = this.Count.CompareTo (b.Count);
				if (compareCount != 0) {
					return false;
				}

				int n = this.Count;
				for (int i = 0; i < n; i++) {
					var compareItem = this [i].CompareTo (b [i]);
					if (compareItem != 0) {
						return false;
					}
				}

				return true;
			}

			public override string ToString()
			{
				var strb = new StringBuilder ();
				strb.Append ("{");
				int n = this.Count;
				for (int i = 0; i < n; i++) {
					if (i > 0) {
						strb.Append (",");
					}

					strb.Append (this [i]);
				}

				strb.Append ("}");
				return strb.ToString ();
			}
		}
	}
}

