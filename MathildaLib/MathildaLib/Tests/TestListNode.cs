using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestListNode
	{
		[Test()]
		public void TestComparison()
		{
			var a = new ListNode (ListNode.ListOperation.List, new List<Node> () {new NumberNode (1)});
			var b = new ListNode (ListNode.ListOperation.List, new List<Node> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == -1);
			Assert.True (b.CompareTo (a) == 1);

			var c = new NumberNode (4);
			Assert.True (a.CompareTo (c) == 2);
		}

		[Test()]
		public void TestToString () {
			var a = new ListNode (ListNode.ListOperation.List, new List<Node> () {
				new NumberNode (1), new VariableNode ("hello")});
			Assert.True (a.ToString () == "{1,hello}");
		}
	}
}

