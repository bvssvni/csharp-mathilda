using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestVariableNode
	{
		[Test()]
		public void TestCase()
		{
			var a = new VariableNode ("a");
			var b = new VariableNode ("b");
			Assert.True (a.CompareTo (b) == -1);
			Assert.True (b.CompareTo (a) == 1);

			var c = new ListNode (ListNode.ListOperation.List, new List<Node> ());
			Assert.True (a.CompareTo (c) == -1);
		}
	}
}

