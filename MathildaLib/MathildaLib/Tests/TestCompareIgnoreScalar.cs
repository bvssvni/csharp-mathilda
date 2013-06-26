using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestCompareIgnoreScalar
	{
		[Test()]
		public void TestTwoVSOne()
		{
			var a = new NumberNode (2).Multiply ("a");
			var b = new NumberNode (1).Multiply ("a");
			Assert.True (a.CompareToIgnoreScalar (b) == 0);
			Assert.True (b.CompareToIgnoreScalar (a) == 0);
		}

		[Test()]
		public void TestTwoVSNone () {
			var a = new NumberNode (2).Multiply ("a");
			var b = new ListNode (ListNode.ListOperation.Product, new VariableNode ("a"));
			Assert.True (a.CompareToIgnoreScalar (b) == 0);
			Assert.True (b.CompareToIgnoreScalar (a) == 0);
		}
	}
}

