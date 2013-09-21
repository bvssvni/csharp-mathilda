using System;

namespace MathildaLib
{
	public static class PowerModule
	{
		public static Scalar Pow(this Scalar a, Scalar b)
		{
			return new Scalar(Math.Pow(a.Value, b.Value));
		}

		public static Dual<T> Pow<T>(this Dual<T> a, Dual<T> b) where T : Log<T>, Power<T>, Number<T>
		{
			var pow = a.A.Pow(b.A);
			return new Dual<T>(
				pow,
				a.B.Multiply(b.A.Multiply(a.A.Pow(b.A.Subtract(1))))
				.Add(b.B.Multiply(pow.Multiply(a.A.Log())))
				);
		}

		public static Dual<T> Log<T>(this Dual<T> a) where T : Log<T>, Number<T>
		{
			return new Dual<T>(a.A.Log(), a.B.Divide(a.A));
		}
	}
}

