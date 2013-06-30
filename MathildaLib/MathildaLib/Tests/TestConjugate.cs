using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestConjugate
	{
		[Test()]
		public void TestCase()
		{
			// i(b + ci) -> -c + bi
			// (-i)(b + c*(-i)) -> -c - bi
			var rules = SearchModule.CreateOperators (new ComplexRule ("i", -1).Operator);

			var bplusc = new VariableNode ("b").Add (
				new VariableNode ("c").Multiply ("i"));

			var a = new VariableNode ("i").Multiply (bplusc);


			var res = a.Minimize (rules);
			Assert.True (res.ToString () == "(-c+(*b*i))");

			var ac = a.Conjugate ("i");
			var resConjugate = ac.Minimize (rules);
			Assert.False (true);
		}
	}
}

