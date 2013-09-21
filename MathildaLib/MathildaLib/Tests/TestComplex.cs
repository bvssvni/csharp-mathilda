using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestComplex
	{
		[Test()]
		public void TestMultiply()
		{
			var a = new Complex<Scalar>(new Scalar(2), new Scalar(3));
			var b = new Complex<Scalar>(new Scalar(5), new Scalar(7));
			var c = a.Multiply(b);

			Assert.True(c.A.Value == 2*5 - 3*7);
			Assert.True(c.B.Value == 2*7 + 3*5);
		}

		[Test()]
		public void TestDivide()
		{
			var a = new Complex<Scalar>(new Scalar(2*5 - 3*7), new Scalar(2*7 + 3*5));
			var b = new Complex<Scalar>(new Scalar(5), new Scalar(7));
			var c = a.Divide(b);

			Assert.True(c.A.Value == 2);
			Assert.True(c.B.Value == 3);
		}
	}
}

