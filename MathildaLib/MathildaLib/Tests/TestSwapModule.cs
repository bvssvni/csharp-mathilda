using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestSwapModule
	{
		[Test()]
		public void TestCase()
		{
			var a = new ListNode (new List<Node> () {
					new NumberNode (3),
					new NumberNode (2),
				new NumberNode (1)});
			var b = SwapModule.Sort (a);
			Console.WriteLine (b.ToString ());
			var c = new ListNode (new List<Node> () {
				new NumberNode (1),
				new NumberNode (2),
				new NumberNode (3)});
			Assert.True (a.CompareTo (c) == 1);
			Assert.True (b.CompareTo (c) == 0);
		}
	}
}

