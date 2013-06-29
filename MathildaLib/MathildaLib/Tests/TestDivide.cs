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
			var b = new NumberNode (1).Divide ("a");

			// TEST
			Console.WriteLine (a);

			Assert.True (a.IsEqualTo (b));
		}
	}
}

