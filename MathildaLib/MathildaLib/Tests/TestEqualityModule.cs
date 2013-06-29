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
			var a = Node.Number (1).Add (2).Add (3).Add (4);
			var b = Node.Number (10);
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

		[Test()]
		public void TestMultiply () {
			var a = new NumberNode (2).Multiply (5).Multiply (3);
			var b = new NumberNode (30);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestNested1 () {
			var a = new VariableNode ("a").Add ("b").Multiply ("c");
			var b = new VariableNode ("a").Multiply ("c").Add (
				new VariableNode ("b").Multiply ("c"));
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestNested2 () {
			var a = new VariableNode ("a").Multiply (new VariableNode ("b").Add (2));
			var b = new VariableNode ("a").Multiply ("b").Add (
				new VariableNode ("a").Multiply (2));
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestNested3 () {
			// a*(b+(c*d))
			var a = new VariableNode ("a").Multiply (
				new VariableNode ("b").Add (
				new VariableNode ("c").Multiply ("d")));
			// (a*b)+(a*c*d)
			var b = new VariableNode ("a").Multiply ("b").Add (
				new VariableNode ("a").Multiply ("c").Multiply ("d"));
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDuplicates () {
			// a + a
			var a = new VariableNode ("a").Add ("a");
			// 2 * a
			var b = new NumberNode (2).Multiply ("a");
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestVariableCancellingSum () {
			// a - a = 0
			var a = new VariableNode ("a").Subtract ("a");
			var b = new NumberNode (0);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestVariableCancellingProduct () {
			// a / a = 1
			var a = new VariableNode ("a").Divide ("a");
			var b = new NumberNode (1);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestInvertedInequality () {
			// a * b != a / b
			var a = new VariableNode ("a").Multiply ("b");
			var b = new VariableNode ("a").Divide ("b");
			Assert.False (a.IsEqualTo (b));
		}
	}
}

