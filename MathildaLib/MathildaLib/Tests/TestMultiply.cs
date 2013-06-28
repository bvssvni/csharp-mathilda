using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestMultiply
	{
		[Test()]
		public void TestMultiply1 () {
			// 2 * 3 = 6
			var a = new NumberNode (2).Multiply (3);
			var b = new NumberNode (6);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply2 () {
			// 2 * a
			var a = new NumberNode (2).Multiply ("a");
			Assert.True (a.ToString () == "(*2*a)");
		}

		[Test()]
		public void TestMultiply3 () {
			// 2 * (a + b)
			var a = new NumberNode (2).Multiply (
				new VariableNode ("a").Add ("b"));
			var b = new NumberNode (2).Multiply ("a").Add (
				new NumberNode (2).Multiply ("b"));

			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestMultiply4 () {
			// a * 2
			var a = new VariableNode ("a").Multiply (2);
			Assert.True (a.ToString () == "(*a*2)");
		}

		[Test()]
		public void TestMultiply5 () {
			// a * b
			var a = new VariableNode ("a").Multiply ("b");
			Assert.True (a.ToString () == "(*a*b)");
		}

		[Test()]
		public void TestMultiply6 () {
			// a * (1 + 2)
			var a = new VariableNode ("a").Multiply (
				new NumberNode (1).Add (2));
			var b = new VariableNode ("a").Add (
				new NumberNode (2).Multiply ("a"));
			Assert.True (a.IsEqualTo (b));
		}
	}
}

