using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public abstract class ListBaseNode : Node
	{
		protected List<Node> m_list;
		
		public List<Node> List {
			get {
				return m_list;
			}
		}

		protected ListBaseNode () {

		}

		public ListBaseNode (List<Node> list)
		{
			m_list = list;
		}

		public ListBaseNode (params Node[] items) {
			m_list = new List<Node> (items);
		}
	}
}

