using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestOperatorOverloading
	{
		[Test()]
		public void TestNumberAddNumber()
		{
			var a = new NumberNode (1) + 2;
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new NumberNode (1),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1) + new NumberNode (2);
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestNumberAddVariable ()
		{
			var a = new NumberNode (1) + new VariableNode ("a");
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
			    new NumberNode (1),
				new VariableNode ("a")});
			Assert.True (a.CompareTo (b) == 0);
			var c = new NumberNode (1) + "a";
			Assert.True (c.CompareTo (b) == 0);
		}

		[Test()]
		public void TestVariableAddNumber () {
			var a = new VariableNode ("a") + 2;
			var b = new ListNode (ListNode.ListOperation.Sum,
			                      new List<Node> () {
				new VariableNode ("a"),
				new NumberNode (2)});
			Assert.True (a.CompareTo (b) == 0);
		}
	}
}

