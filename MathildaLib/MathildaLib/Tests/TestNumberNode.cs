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
			Assert.True (NumberNode.d.ToString () == "d");
		}

		[Test()]
		public void TestComplexDualToString () {
			var a = NumberNode.i * NumberNode.d;
			Assert.True (a.ToString () == "id");
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

			Assert.True ((NumberNode.d * NumberNode.d) == new NumberNode (0));
		}

		[Test()]
		public void TestComplexAdd () {
			var a = NumberNode.Complex (1, 2);
			var b = NumberNode.Complex (2, 3);
			var c = NumberNode.Complex (3, 5);
			Assert.True ((a + b) == c);
		}

		[Test()]
		public void TestDualAdd () {
			var a = NumberNode.Dual (1, 2);
			var b = NumberNode.Dual (2, 3);
			var c = NumberNode.Dual (3, 5);
			Assert.True ((a + b) == c);
		}

		[Test()]
		public void TestComplexMultiply () {
			var a = NumberNode.Complex (1, 2);
			var b = NumberNode.Complex (2, 3);
			var c = NumberNode.Complex (1*2-2*3, 2*2+1*3);
			Assert.True (a * b == c);
		}

		[Test()]
		public void TestDualMultiply () {
			var a = NumberNode.Dual (1, 2);
			var b = NumberNode.Dual (2, 3);
			var c = NumberNode.Dual (1*2, 2*2+1*3);
			Assert.True (a * b == c);
		}
	}
}

