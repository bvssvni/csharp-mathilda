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

		public static ListNode operator + (VariableNode a, double b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a,
				new NumberNode (b)});
			return list;
		}

		public static ListNode operator + (VariableNode a, NumberNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}

		public static ListNode operator + (VariableNode a, string b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, 
				new VariableNode (b)});
			return list;
		}

		public static ListNode operator + (VariableNode a, VariableNode b) {
			var list = new ListNode (ListNode.ListOperation.Sum,
			                         new List<Node> () {
				a, b});
			return list;
		}
	}
}

