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
			var rules = SearchModule.CreateOperators (new ComplexRule ("i", -1).Operator);

			var bplusc = new VariableNode ("b").Add (
				new VariableNode ("c").Multiply ("i"));

			// a + i(b + ci)
			var a = new VariableNode ("a").Add (
				new VariableNode ("i").Multiply (bplusc));

			var res = a.Minimize (rules);

			// TEST
			Console.WriteLine (res.ToString ());
			Assert.False (true);

			var ac = a.Conjugate ("i");
			// a - c - bi
			var c = new VariableNode ("a").Subtract ("c").Subtract (
				new VariableNode ("b").Multiply ("i"));

			Assert.True (ac.IsEqualTo (c, rules));


			// TEST
			Assert.False (true);
		}
	}
}

