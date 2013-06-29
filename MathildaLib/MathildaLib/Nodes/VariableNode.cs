using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class VariableNode : Node
	{
		private string m_name;

		public string Name {
			get {
				return m_name;
			}
		}

		public VariableNode(string name)
		{
			m_name = name;
		}

		public override Node Copy()
		{
			return new VariableNode (m_name);
		}

		public override int CompareTo(object other)
		{
			var otherNode = other as VariableNode;
			if (otherNode == null) {
				return this.TypeId ().CompareTo (other.TypeId ());
			}

			return m_name.CompareTo (otherNode.m_name);
		}

		public override string ToString()
		{
			return m_name;
		}
	}
}

