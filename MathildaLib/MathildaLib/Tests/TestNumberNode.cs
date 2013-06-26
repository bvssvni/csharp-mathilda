using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestNumberNode
	{
		[Test()]
		public void TestCase()
		{
			var a = new NumberNode (5);
			var b = new NumberNode (4);
			Assert.True (a.CompareTo (b) == 1);
			Assert.True (b.CompareTo (a) == -1);

			var c = new ListNode (new List<Node> ());
			Assert.True (a.CompareTo (c) == 2);
		}
	}
}

