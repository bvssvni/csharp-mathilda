using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestPower
	{
		[Test()]
		public void TestScalar()
		{
			var a = new Scalar(2);
			var b = a.Pow(new Scalar(3));

			Assert.True(b.Value == 8);
		}

		[Test()]
		public void TestDual()
		{
			var a = new Dual<Scalar>(new Scalar(1), new Scalar(2));
			var b = a.Pow(new Dual<Scalar>(new Scalar(2), new Scalar(2)));

			Assert.AreEqual(1, b.A.Value);
			Assert.AreEqual(4, b.B.Value);

			var c = a.Log();
			Assert.True(c.A.Value == 0);
			Assert.True(c.B.Value == 2);
		}
	}
}

