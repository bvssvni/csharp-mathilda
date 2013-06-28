using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class SumNode : ListBaseNode
	{
		public SumNode (List<Node> list) : base (list) {

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

		public override Node Copy()
		{
			var newList = new List<Node> ();
			foreach (var item in m_list) {
				newList.Add (item.Copy ());
			}
			
			return new ListNode (newList);
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
	}
}

