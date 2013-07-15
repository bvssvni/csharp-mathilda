using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MathildaLib
{
	[TestFixture()]
	public class TestReal
	{
		[Test()]
		public void TestScalarToString ()
		{
			var s = Real.Scalar (2);
			Assert.True (s.ToString () == "(+2)/(+1)");
		}

		[Test()]
		public void TestVariableToString () {
			var s = Real.Variable ("x");
			Assert.True (s.ToString () == "(+1*x^1)/(+1)");
		}

		[Test()]
		public void TestAdd () {
			var a = Real.Variable ("a");
			var b = Real.Variable ("a");
			var c = a + b;
			Assert.True (c.ToString () == "(+2*a^1)/(+1)");
		}

		[Test()]
		public void TestMultiply () {
			var a = Real.Variable ("a");
			var b = Real.Variable ("a");
			var c = a * b;
			Assert.True (c.ToString() == "(+1*a^2)/(+1)");
		}

		[Test()]
		public void TestMultiply2 () {
			var ab = Real.Variable ("a") + Real.Variable ("b");
			var cd = Real.Variable ("c") + Real.Variable ("d");
			var sum = ab * cd;
			Assert.True (sum.ToString () == "(+1*a^1*c^1+1*a^1*d^1+1*b^1*c^1+1*b^1*d^1)/(+1)");
		}

		[Test()]
		public void TestDivide () {
			var a = Real.Variable ("a") / Real.Variable ("b");
			Assert.True (a.ToString () == "(+1*a^1)/(+1*b^1)");
		}

		[Test()]
		public void TestMultiplyZero () {
			var a = Real.Variable ("a");
			var b = Real.Scalar (0);
			var c = a * b;
			Assert.True (c.ToString (ExpressionFormat.Simplified) == "0");
		}

		[Test()]
		public void TestZeroPlusOne () {
			var a = Real.Scalar (0);
			var b = Real.Scalar (1);
			var c = a + b;
			Assert.True (c.ToString (ExpressionFormat.Simplified) == "1");
			var d = b + a;
			Assert.True (d.ToString (ExpressionFormat.Simplified) == "1");
		}

		[Test()]
		public void TestZeroPlusVariable () {
			var a = Real.Scalar (0);
			var b = Real.Variable ("a");
			var c = a + b;
			Assert.True (c.ToString (ExpressionFormat.Simplified) == "(a)");
			var d = b + a;
			Assert.True (d.ToString (ExpressionFormat.Simplified) == "(a)");
		}
	}
}

