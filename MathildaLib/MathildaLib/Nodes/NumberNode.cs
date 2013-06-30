using System;
using System.Collections.Generic;

namespace MathildaLib
{
	/// <summary>
	/// Number node.
	/// 
	/// 				Complex		Dual
	/// 	+			1
	/// 	*
	/// 	==
	/// 	!=
	/// 	ToString
	/// </summary>
	public class NumberNode : Node
	{
		private double m_value;
		private double m_complexValue;
		private double m_dualValue;

		public static readonly NumberNode i = Complex (0, 1);
		public static readonly NumberNode ε = Dual (0, 1);

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public NumberNode (double value)
		{
			m_value = value;
		}

		public static NumberNode Complex (double a, double b) {
			var num = new NumberNode (a);
			num.m_complexValue = b;
			return num;
		}

		public static NumberNode Dual (double a, double b) {
			var num = new NumberNode (a);
			num.m_dualValue = b;
			return num;
		}

		public override Node Copy()
		{
			return new NumberNode (m_value);
		}

		public static NumberNode operator - (NumberNode a) {
			return new NumberNode (-a.m_value);
		}

		public static NumberNode operator - (NumberNode a, NumberNode b) {
			var num = new NumberNode (a.m_value - b.m_value);
			num.m_complexValue = a.m_complexValue - b.m_complexValue;
			num.m_dualValue = a.m_dualValue - b.m_dualValue;
			return num;
		}

		public static NumberNode operator + (NumberNode a, NumberNode b) {
			var num = new NumberNode (a.m_value + b.m_value);
			num.m_complexValue = a.m_complexValue + b.m_complexValue;
			num.m_dualValue = a.m_dualValue + b.m_dualValue;
			return num;
		}

		public static NumberNode operator / (double a, NumberNode b) {
			return new NumberNode (a / b.m_value);
		}

		public static NumberNode operator / (NumberNode a, NumberNode b) {
			return new NumberNode (a.m_value / b.m_value);
		}

		public static NumberNode operator * (NumberNode a, NumberNode b) {
			var num = new NumberNode (a.m_value * b.m_value);
			num.m_value -= a.m_complexValue * b.m_complexValue;
			num.m_complexValue += a.m_value * b.m_complexValue;
			num.m_complexValue += a.m_complexValue * b.m_value;
			return num;
		}

		public static bool operator == (NumberNode a, double b) {
			return a.m_value == b && a.m_complexValue == 0 && a.m_dualValue == 0;
		}

		public static bool operator != (NumberNode a, double b) {
			return a.m_value != b || a.m_complexValue != 0 || a.m_dualValue != 0;
		}

		public static bool operator == (NumberNode a, NumberNode b) {
			if (ReferenceEquals (a, null) || ReferenceEquals (b, null)) {
				return ReferenceEquals (a, b);
			}

			return a.m_value == b.m_value && a.m_complexValue == b.m_complexValue &&
				a.m_dualValue == b.m_dualValue;
		}

		public static bool operator != (NumberNode a, NumberNode b) {
			return a.m_value != b.m_value || a.m_complexValue != b.m_complexValue ||
				a.m_dualValue != b.m_dualValue;
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
			if (this.m_complexValue == 0 && this.m_dualValue == 0) {
				return m_value.ToString (System.Globalization.CultureInfo.InvariantCulture);
			}

			if (this.m_value == 0 && this.m_dualValue == 0) {
				if (m_complexValue == 1) {
					return "i";
				}

				return m_complexValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "i";
			}

			if (this.m_value == 0 && this.m_complexValue == 0) {
				if (m_dualValue == 1) {
					return "ε";
				}

				return m_dualValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "ε";
			}

			if (m_dualValue == 0) {
				return "(" + m_value.ToString (System.Globalization.CultureInfo.InvariantCulture) + "+" +
					m_complexValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "i)";
			}

			if (m_complexValue == 0) {
				return "(" + m_value.ToString (System.Globalization.CultureInfo.InvariantCulture) + "+" +
					m_dualValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "ε)";
			}

			return "(" + m_value.ToString (System.Globalization.CultureInfo.InvariantCulture) + "+" +
				m_complexValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "i+" +
				m_dualValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "ε)";
		}
	}
}

