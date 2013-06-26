using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestDotProduct
	{
		[Test()]
		public void Test1 () {
			var a = new ListNode (1, 2, 3);
			var b = new ListNode (2, 3, 4);
			var c = new ListNode (
				ListNode.ListOperation.Sum,
				new NumberNode (1).Multiply (2),
				new NumberNode (2).Multiply (3),
				new NumberNode (3).Multiply (4));
			var d = a.DotProduct (b);
			Assert.True (c.CompareTo (d) == 0);
		}
	}
}

