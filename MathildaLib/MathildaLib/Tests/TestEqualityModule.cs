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

		[Test()]
		public void TestSumNumbers () {
			var a = new NumberNode (1).Add (2).Add (3).Add (4);
			var b = new NumberNode (10);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiplyNumbers () {
			var a = new NumberNode (1).Multiply (2).Multiply (3).Multiply (4);
			var b = new NumberNode (24);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestZeroMultiply () {
			var a = new VariableNode ("a").Multiply (0);
			var b = new NumberNode (0);
			Assert.True (a.IsEqualTo (b));

			var c = new VariableNode ("a").Add (0);
			Assert.False (a.IsEqualTo (c));
		}

		[Test()]
		public void TestZeroAdd () {
			var a = new VariableNode ("a").Add (0);
			var b = new VariableNode ("a");
			Assert.True (a.IsEqualTo (b));

			var c = new VariableNode ("a").Multiply (0);
			Assert.False (c.IsEqualTo (b));
		}

		/*
		[Test()]
		public void TestNested1 () {
			var a = new VariableNode ("a").Add ("b").Multiply ("c");
			var b = new VariableNode ("a").Multiply ("c").Add (
				new VariableNode ("b").Multiply ("c"));
			Assert.True (a.IsEqualTo (b));
		}
		*/
	}
}

