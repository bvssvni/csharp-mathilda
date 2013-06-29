using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestAdd
	{
		[Test()]
		public void TestAdd1()
		{
			// 1 + 1
			var a = new NumberNode (1).Add (1);
			var b = new NumberNode (2);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestAdd2 () {
			// 1 + a
			var a = new NumberNode (1).Add ("a");
			Assert.True (a.ToString () == "(+1+a)");
		}

		[Test()]
		public void TestAdd3 () {
			// 1 + (2 + 3)
			var a = new NumberNode (1).Add (
				new NumberNode (2).Add (3));
			Assert.True (a.IsEqualTo (new NumberNode (6)));
		}

		[Test()]
		public void TestAdd4 () {
			// 1 + (2 * 3)
			var a = new NumberNode (1).Add (
				new NumberNode (2).Multiply (3));
			Assert.True (a.IsEqualTo (new NumberNode (7)));
		}

		[Test()]
		public void TestAdd5 () {
			// a + 1
			var a = new VariableNode ("a").Add (1);
			Assert.True (a.ToString () == "(+a+1)");
		}

		[Test()]
		public void TestAdd6 () {
			// a + b
			var a = new VariableNode ("a").Add ("b");
			Assert.True (a.ToString () == "(+a+b)");
		}

		[Test()]
		public void TestAdd7 () {
			// a + (b + c)
			var a = new VariableNode ("a").Add (
				new VariableNode ("b").Add ("c"));
			Assert.True (a.ToString () == "(+a+b+c)");
		}

		[Test()]
		public void TestAdd8 () {
			// a + (1 * 2)
			var a = new VariableNode ("a").Add (
				new NumberNode (1).Multiply (2));
			var b = new VariableNode ("a").Add (2);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestAdd9 () {
			// (1 + 2) + 3
			var a = new NumberNode (1).Add (2).Add (3);
			Assert.True (a.ToString () == "(+1+2+3)");
		}

		[Test()]
		public void TestAdd10 () {
			// (1 + 2) + a
			var a = new NumberNode (1).Add (2).Add ("a");
			Assert.True (a.ToString () == "(+1+2+a)");
		}

		[Test()]
		public void TestAdd11 () {
			// (1 + 2) + (3 + 4).
			var a = new NumberNode (1).Add (2).Add (
				new NumberNode (3).Add (4));
			Assert.True (a.IsEqualTo (new NumberNode (10)));
		}

		[Test()]
		public void TestAdd12 () {
			// (1 + 2) + (3 * 4)
			var a = new NumberNode (1).Add (2).Add (
				new NumberNode (3).Multiply (4));
			Assert.True (a.IsEqualTo (new NumberNode (15)));
		}

		[Test()]
		public void TestAdd13 () {
			// (1 * 2) + 3
			var a = new NumberNode (1).Multiply (2).Add (3);
			Assert.True (a.IsEqualTo (new NumberNode (5)));
		}

		[Test()]
		public void TestAdd14 () {
			// (1 * 2) + a
			var a = new NumberNode (1).Multiply (2).Add ("a");
			var b = new NumberNode (2).Add ("a");
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestAdd15 () {
			// (1 * 2) + (3 + 4)
			var a = new NumberNode (1).Multiply (2).Add (
				new NumberNode (3).Add (4));
			var b = new NumberNode (9);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestAdd16 () {
			// (1 * 2) + (3 * 4)
			var a = new NumberNode (1).Multiply (2).Add (
				new NumberNode (3).Multiply (4));
			var b = new NumberNode (14);
			Assert.True (a.IsEqualTo (b));
		}
	}
}

