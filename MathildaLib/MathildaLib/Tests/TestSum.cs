using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestSum
	{
		[Test()]
		public void TestCase()
		{
			var a = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new NumberNode (1),
				new NumberNode (2)});
			a.Sum ();
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new NumberNode (3)});
			Assert.True (a.CompareTo (b) == 0);
		}
	}
}

