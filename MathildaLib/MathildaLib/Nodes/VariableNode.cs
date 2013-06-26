using System;
using System.Collections.Generic;

namespace MathildaLib
{
	public class VariableNode : Node
	{
		private string m_name;

		public VariableNode(string name)
		{
			m_name = name;
		}

		public override Node Copy()
		{
			return new VariableNode (m_name);
		}

		public override int CompareTo(Node other)
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

