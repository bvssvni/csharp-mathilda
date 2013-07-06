using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestComplex
	{
		[Test()]
		public void TestComplexToString()
		{
			var a = new Complex () {
				Re = Real.Variable ("a"),
				Img = Real.Variable ("b")
			};
			Assert.True (a.ToString () == "{(+1*a^1)/(+1),(+1*b^1)/(+1)}");
		}

		[Test()]
		public void TestComplexMultiply ()
		{
			var a = new Complex () {
				Re = Real.Variable ("a"),
				Img = Real.Variable ("b")
			};
			var b = new Complex () {
				Re = Real.Variable ("c"),
				Img = Real.Variable ("d")
			};
			var c = a * b;
			Assert.True (c.ToString () == "{(+1*a^1*c^1+-1*b^1*d^1)/(+1),(+1*a^1*d^1+1*b^1*c^1)/(+1)}");

			// TEST
			Console.WriteLine (c.ToStringSimplified ());

			Assert.True (c.ToStringSimplified () == "{(+a*c+-1*b*d)/(+),(+a*d+b*c)/(+)}");
		}
	}
}

