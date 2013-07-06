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
			var a = new Complex<Real> () {
				Re = Real.Variable ("a"),
				Img = Real.Variable ("b")
			};
			Assert.True (a.ToString () == "{(+1*a^1)/(+1),(+1*b^1)/(+1)}");
		}

		[Test()]
		public void TestComplexMultiply ()
		{
			var a = new Complex<Real> () {
				Re = Real.Variable ("a"),
				Img = Real.Variable ("b")
			};
			var b = new Complex<Real> () {
				Re = Real.Variable ("c"),
				Img = Real.Variable ("d")
			};
			var c = a * b;
			Assert.True (c.ToString () == "{(+1*a^1*c^1+-1*b^1*d^1)/(+1),(+1*a^1*d^1+1*b^1*c^1)/(+1)}");
			Assert.True (c.ToString (ExpressionFormat.Simplified) == "{(a*c-b*d),(a*d+b*c)}");
		}

		[Test()]
		public void TestComplexComplexMultiply () {
			var a = new Complex<Complex<Real>> () {
				Re = new Complex<Real> () {
					Re = Real.Scalar (0),
					Img = Real.Variable ("a1")
				},
				Img = new Complex<Real> () {
					Re = Real.Variable ("a2"),
					Img = Real.Variable ("a3")
				}
			};

			var b = new Complex<Complex<Real>> () {
				Re = new Complex<Real> () {
					Re = Real.Scalar (0),
					Img = Real.Variable ("b1")
				},
				Img = new Complex<Real> () {
					Re = Real.Variable ("b2"),
					Img = Real.Variable ("b3")
				}
			};

			var c = a * b;
			Assert.True (c.ToString (ExpressionFormat.Simplified) == "{{(-a1*b1-a2*b2+a3*b3),(-a2*b3-a3*b2)},{(-a1*b3-a3*b1),(a1*b2+a2*b1)}}");
		}
	}
}

