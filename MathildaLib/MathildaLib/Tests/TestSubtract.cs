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
	}
}

