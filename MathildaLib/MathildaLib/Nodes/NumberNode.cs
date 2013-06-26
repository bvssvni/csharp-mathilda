using System;

namespace MathildaLib
{
	public class NumberNode : Node
	{
		private double m_value;

		public double Value {
			get {
				return m_value;
			}
			set {
				m_value = value;
			}
		}

		public NumberNode(double value)
		{
			m_value = value;
		}

		public override Node Copy()
		{
			return new NumberNode (m_value);
		}

		public override int CompareTo(Node other)
		{
			var otherNode = other as NumberNode;
			if (otherNode == null) {
				return this.TypeId ().CompareTo (other.TypeId ());
			}

			return m_value.CompareTo (otherNode.m_value);
		}

		public override string ToString()
		{
			return m_value.ToString (System.Globalization.CultureInfo.InvariantCulture);
		}
	}
}

