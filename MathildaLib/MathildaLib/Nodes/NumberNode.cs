using System;
using System.Collections.Generic;

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

		public ListNode Add (double b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				this,
				new NumberNode (b)});
			return list;
		}

		public ListNode Multiply (double b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				this,
				new NumberNode (b)});
			return list;
		}

		public ListNode Add (NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				this, b});
			return list;
		}

		public ListNode Multiply (NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				this, b});
			return list;
		}

		public ListNode Add (string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				this,
				new VariableNode (b)});
			return list;
		}

		public ListNode Multiply (string b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				this,
				new VariableNode (b)});
			return list;
		}

		public ListNode Add (VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				this, b});
			return list;
		}

		public ListNode Multiply (VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Multiply,
			                         new List<Node> () {
				this, b});
			return list;
		}
	}
}

