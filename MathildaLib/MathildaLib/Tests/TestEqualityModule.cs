using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestEqualityModule
	{
		[Test()]
		public void TestABvsBA()
		{
			var a = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new VariableNode ("a"),
				new VariableNode ("b")});
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new VariableNode ("b"),
				new VariableNode ("a")});
			Assert.True (a.IsEqualTo (b));
		}
	}
}

