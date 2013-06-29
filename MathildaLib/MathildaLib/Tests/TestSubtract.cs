using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestSubtract
	{
		[Test()]
		public void TestSubtract1()
		{
			var a = new NumberNode (1).Subtract (1);
			Assert.True (a.IsEqualTo (new NumberNode (0)));
		}

		[Test()]
		public void TestSubtract2 () 
		{
			var a = new NumberNode (1).Subtract ("a");
			Assert.True (a.ToString () == "(+1-a)");
		}

		[Test()]
		public void TestSubtract3 ()
		{
			// 1 - (2 + 3)
			var a = new NumberNode (1).Subtract (
				new NumberNode (2).Add (3));
			var b = new NumberNode (-4);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestSubtract4 () {
			// 1 - (2 * 3)
			var a = new NumberNode (1).Subtract (
				new NumberNode (2).Multiply (3));
			var b = new NumberNode (-5);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestSubtract5 () {
			// a - 1
			var a = new VariableNode ("a").Subtract (1);
			Assert.True (a.ToString () == "(+a+-1)");
		}

		[Test()]
		public void TestSubtract6 () {
			// a - b
			var a = new VariableNode ("a").Subtract ("b");
			Assert.True (a.ToString () == "(+a-b)");
		}

		[Test()]
		public void TestSubtract7 () {
			// a - (1 + 2)
			var a = new VariableNode ("a").Subtract (
				new NumberNode (1).Add (2));
			var b = new VariableNode ("a").Add (-3);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestSubtract8 () {
			// a - (1 * 2)
			var a = new VariableNode ("a").Subtract (
				new NumberNode (1).Multiply (2));
			var b = new VariableNode ("a").Subtract (2);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestSubtract9 () {
			// (1 + 2) - 3
			var a = new NumberNode (1).Add (2).Subtract (3);
			var b = new NumberNode (0);
			Assert.True (a.IsEqualTo (b));
		}

		[Test()]
		public void TestSubtract10 () {
			// (1 + 3) - a
			var a = new NumberNode (1).Add (3).Subtract ("a");
			var b = new NumberNode (4).Subtract ("a");
			Assert.True (a.IsEqualTo (b));
		}
	}
}

