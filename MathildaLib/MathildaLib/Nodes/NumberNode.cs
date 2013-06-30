using System;
using System.Collections.Generic;

namespace MathildaLib
{
	/// <summary>
	/// Number node.
	/// 
	/// 		i	d	id
	/// 	i	+
	/// 	d		+
	/// 	id
	/// 
	/// </summary>
	public class NumberNode : Node
	{
		private double m_value;
		private double m_complexValue;
		private double m_dualValue;
		private double m_complexDualValue;

		public static readonly NumberNode i = Complex (0, 1);
		public static readonly NumberNode d = Dual (0, 1);

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
			num.m_dualValue += a.m_value * b.m_dualValue;
			num.m_dualValue += a.m_dualValue * b.m_value;
			num.m_complexDualValue += a.m_complexValue * b.m_dualValue;
			num.m_complexDualValue += a.m_dualValue * b.m_complexValue;
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
			if (this.m_complexValue == 0 && this.m_dualValue == 0 && this.m_complexDualValue == 0) {
				return m_value.ToString (System.Globalization.CultureInfo.InvariantCulture);
			}
			if (this.m_value == 0 && this.m_dualValue == 0 && this.m_complexDualValue == 0) {
				if (m_complexValue == 1) {
					return "i";
				}

				return m_complexValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "i";
			}
			if (this.m_value == 0 && this.m_complexValue == 0 && this.m_complexDualValue == 0) {
				if (m_dualValue == 1) {
					return "d";
				}

				return m_dualValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "d";
			}
			if (this.m_value == 0 && this.m_complexValue == 0 && this.m_dualValue == 0) {
				if (m_complexDualValue == 1) {
					return "id";
				}

				return m_complexDualValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "id";
			}

			var str = "(";
			bool prev = false;
			if (m_value != 0) {
				str += m_value.ToString (System.Globalization.CultureInfo.InvariantCulture);
				prev = true;
			}
			if (m_complexValue != 0) {
				if (prev) {
					str += "+";
				}

				str += m_complexValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "i";
				prev = true;
			}
			if (m_dualValue != 0) {
				if (prev) {
					str += "+";
				}

				str += m_dualValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "d";
				prev = true;
			}
			if (m_complexDualValue != 0) {
				if (prev) {
					str += "+";
				}

				str += m_complexDualValue.ToString (System.Globalization.CultureInfo.InvariantCulture) + "id";
				prev = true;
			}

			str += ")";
			return str;
		}
	}
}

