using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class NumberNode : Node
	{
		private double m_value;

		public NumberNode(double value)
		{
			m_value = value;
		}

		public override Node Copy()
		{
			return new NumberNode (m_value);
		}

		public static NumberNode operator - (NumberNode a) {
			return new NumberNode (-a.m_value);
		}

		public static NumberNode operator - (NumberNode a, NumberNode b) {
			return new NumberNode (a.m_value - b.m_value);
		}

		public static NumberNode operator + (NumberNode a, NumberNode b) {
			return new NumberNode (a.m_value + b.m_value);
		}

		public static NumberNode operator / (double a, NumberNode b) {
			return new NumberNode (a / b.m_value);
		}

		public static NumberNode operator / (NumberNode a, NumberNode b) {
			return new NumberNode (a.m_value / b.m_value);
		}

		public static NumberNode operator * (NumberNode a, NumberNode b) {
			return new NumberNode (a.m_value * b.m_value);
		}

		public static bool operator == (NumberNode a, double b) {
			return a.m_value == b;
		}

		public static bool operator != (NumberNode a, double b) {
			return a.m_value != b;
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

