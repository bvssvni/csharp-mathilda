using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestNumberNode
	{
		[Test()]
		public void TestZeroToString () {
			Assert.True (new NumberNode (0).ToString () == "0");
		}

		[Test()]
		public void TestComplexIdentityToString () {
			Assert.True (NumberNode.i.ToString () == "i");
		}

		[Test()]
		public void TestDualIdentityToString () {
			Assert.True (NumberNode.ε.ToString () == "ε");
		}

		[Test()]
		public void TestComplexIndentity()
		{
			var a = NumberNode.Complex (0, 1);
			var b = a * a;
			Assert.True (b == new NumberNode (-1));

			Assert.True ((NumberNode.i * NumberNode.i) == new NumberNode (-1));
		}

		[Test()]
		public void TestDualIdentity () {
			var a = NumberNode.Dual (0, 1);
			var b = a * a;
			Assert.True (b == new NumberNode (0));

			Assert.True ((NumberNode.ε * NumberNode.ε) == new NumberNode (0));
		}

		[Test()]
		public void TestComplexAdd () {
			var a = NumberNode.Complex (1, 2);
			var b = NumberNode.Complex (2, 3);
			var c = NumberNode.Complex (3, 5);
			Assert.True ((a + b) == c);
		}
	}
}

