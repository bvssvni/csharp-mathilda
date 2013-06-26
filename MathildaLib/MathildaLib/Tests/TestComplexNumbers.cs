using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestComplexNumbers
	{
		[Test()]
		public void TestISquared()
		{
			var iRule = new ComplexRule ("i", -1);
			var ops = SearchModule.CreateOperators (iRule.Operator);
			var a = new VariableNode ("i").Multiply ("i");
			var b = new NumberNode (-1);
			Assert.True (a.IsEqualTo (b, ops));
		}

		[Test()]
		public void TestABA () {
			var aRule = new ComplexRule ("a", 1);
			var ops = SearchModule.CreateOperators (aRule.Operator);
			var a = new VariableNode ("a").Multiply ("b").Multiply ("a");
			var b = new VariableNode ("b");
			Assert.True (a.IsEqualTo (b, ops));
		}
	}
}

