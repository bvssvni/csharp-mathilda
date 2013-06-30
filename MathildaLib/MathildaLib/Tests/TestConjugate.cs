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

			// i(b + ci)
			var a = new VariableNode ("i").Multiply (bplusc);
			var res = a.Minimize (rules);

			Assert.True (res.ToString () == "(-c+(*b*i))");

			var ac = a.Conjugate ("i");

			// TEST
			Console.WriteLine ("WHAT");
			Console.WriteLine (ac);
			Console.Clear ();

			var resConjugate = ac.Minimize (rules);

			// TEST
			Console.WriteLine (resConjugate);

			Assert.False (true);
		}
	}
}

