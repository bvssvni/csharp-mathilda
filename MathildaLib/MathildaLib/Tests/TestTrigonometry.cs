using System;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestTrigonometry
	{
		[Test()]
		public void TestCase()
		{
			var a = new Scalar(0.5);
			var b = new Complex<Scalar>(new Scalar(0.5), new Scalar(0.0));
			var c = new Dual<Scalar>(new Scalar(0.5), new Scalar(0.0));

			var aSin = a.Sin();
			var bSin = b.Sin();
			var cSin = c.Sin();
			Assert.True(aSin.Value == bSin.A.Value);
			Assert.True(aSin.Value == cSin.A.Value);

			var aCos = a.Cos();
			var bCos = b.Cos();
			var cCos = c.Cos();
			Assert.True(aCos.Value == bCos.A.Value);
			Assert.True(aCos.Value == cCos.A.Value);

			var aSinh = a.Sinh();
			var bSinh = b.Sinh();
			var cSinh = c.Sinh();
			Assert.True(aSinh.Value == bSinh.A.Value);
			Assert.True(aSinh.Value == cSinh.A.Value);

			var aCosh = a.Cosh();
			var bCosh = b.Cosh();
			var cCosh = c.Cosh();
			Assert.True(aCosh.Value == bCosh.A.Value);
			Assert.True(aCosh.Value == cCosh.A.Value);

			var aExp = a.Exp();
			var bExp = b.Exp();
			var cExp = c.Exp();
			Assert.True(aExp.Value == bExp.A.Value);
			Assert.True(aExp.Value == cExp.A.Value);
		}
	}
}

