using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestDivide
	{
		[Test()]
		public void TestDivide1()
		{
			var a = new NumberNode (1).Divide (2);
			var b = new NumberNode (0.5);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide2 () {
			var a = new NumberNode (1).Divide ("a");
			Assert.True (a.ToString () == "(*1/a)");
		}

		[Test()]
		public void TestDivide3 () {
			var a = new NumberNode (4).Divide (
				new NumberNode (1).Add (3));
			var b = new NumberNode (1);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide4 () {
			var a = new NumberNode (1).Divide (
				new NumberNode (2).Multiply (3));
			var b = new NumberNode (1.0 / 6.0);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide5 () {
			var a = new VariableNode ("a").Divide (2);
			var b = new NumberNode (0.5).Multiply ("a");
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide6 () {
			var a = new VariableNode ("a").Divide ("a");
			Assert.True (a.IsEqualTo (new NumberNode (1)));
		}

		[Test()]
		public void TestDivide7 () {
			var a = new VariableNode ("a").Divide (
				new VariableNode ("a").Add ("a"));
			var b = new NumberNode (0.5);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide8 () {
			var a = new VariableNode ("a").Divide (
				new VariableNode ("b").Multiply ("a"));
			var b = new NumberNode (1).Divide ("b");
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide9 () {
			var a = new VariableNode ("a").Add (2).Divide (2);
			var b = new NumberNode (0.5).Multiply ("a").Add (1);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide10 () {
			// (a + 2) / a
			var a = new VariableNode ("a").Add (2).Divide ("a");
			// 1 + 2 / a
			var b = new NumberNode (1).Add (
				new NumberNode (2).Divide ("a"));
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide11 () {
			// (a + 2) / (a + 2)
			var a = new VariableNode ("a").Add (2).Divide (
				new VariableNode ("a").Add (2));
			var b = new NumberNode (1);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide12 () {
			// (a + 2) / (a * 2)
			var a = new VariableNode ("a").Add (2).Divide (
				new VariableNode ("a").Multiply (2));
			// 0.5 + 1/a
			var b = new NumberNode (0.5).Add (
				new NumberNode (1).Divide ("a"));
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestDivide13 () {
			// (a * 2) / 2
			var a = new VariableNode ("a").Multiply (2).Divide (2);
			Assert.True (a.IsEqualTo (new VariableNode ("a")));
		}

		[Test()]
		public void TestDivide14 () {
			// (a * 2) / a
			var a = new VariableNode ("a").Multiply (2).Divide ("a");
			Assert.True (a.IsEqualTo (new NumberNode (2)));
		}

		[Test()]
		public void TestDivide15 () {
			// (a * 2) / (a + a)
			var a = new VariableNode ("a").Multiply (2).Divide (
				new VariableNode ("a").Add ("a"));
			Assert.True (a.IsEqualTo (new NumberNode (1)));
		}

		[Test()]
		public void TestDivide16 () {
			// (a * 2) / (a * 2)
			var a = new VariableNode ("a").Multiply (2).Divide (
				new VariableNode ("a").Multiply (2));
			Assert.True (a.IsEqualTo (new NumberNode (1)));
		}
	}
}

