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
			Assert.True (a.CompareTo (c) == 1);
		}

		[Test()]
		public void TestToString () {
			var a = new ListNode (ListNode.ListOperation.List, new List<Node> () {
				new NumberNode (1), new VariableNode ("hello")});
			Assert.True (a.ToString () == "{1,hello}");
		}

		[Test()]
		public void TestSumIsMoreThanList () {
			var a = new ListNode (ListNode.ListOperation.List, new List<Node> ());
			var b = new ListNode (ListNode.ListOperation.Sum, new List<Node> ());
			Assert.True (a.CompareTo (b) == -1);
			Assert.True (b.CompareTo (a) == 1);
		}

		[Test()]
		public void TestForEachNode () {
			var a = new ListNode (1, 2, 3);
			var expected = new ListNode.Address[] {
				new ListNode.Address (0),
				new ListNode.Address (1),
				new ListNode.Address (2)};
			int i = 0;
			a.ForEachNode ((ListNode.Address address) => {
				Assert.True (address.IsEqualTo (expected [i++]));
			});

			Assert.True (i == 3);
		}

		[Test()]
		public void TestForEachNode2 () {
			var a = new ListNode (
				new NumberNode (1),
				new ListNode (2, 3));
			var expected = new ListNode.Address [] {
				new ListNode.Address (0),
				new ListNode.Address (1),
				new ListNode.Address (1, 0),
				new ListNode.Address (1, 1)};
			int i = 0;
			a.ForEachNode ((ListNode.Address address) => {
				Assert.True (address.IsEqualTo (expected [i++]));
			});

			Assert.True (i == 4);
		}
	}
}

