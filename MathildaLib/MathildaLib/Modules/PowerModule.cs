using System;

namespace MathildaLib
{
	public static class PowerModule
	{
		public static Scalar Pow(this Scalar a, Scalar b)
		{
			return new Scalar(Math.Pow(a.Value, b.Value));
		}

		public static Dual<T> Pow<T>(this Dual<T> a, Dual<T> b) where T : Logarithm<T>, Power<T>, Number<T>
		{
			var pow = a.A.Pow(b.A);
			return new Dual<T>(
				pow,
				a.B.Multiply(b.A.Multiply(a.A.Pow(b.A.Subtract(1))))
				.Add(b.B.Multiply(pow.Multiply(a.A.Log())))
				);
		}

		public static Complex<T> Pow<T>(this Complex<T> a, Complex<T> b) 
			where T : Exponent<T>, Logarithm<T>, Arctangent<T>, Number<T>
		{
			var lnR = a.A.Multiply(a.A).Add(a.B.Multiply(a.B)).Log().Multiply(0.5);
			var angle = a.B.Atan2(a.A);
			return new Complex<T>(b.A.Multiply(lnR).Subtract(b.B.Multiply(angle)).Exp(),
			                      b.A.Multiply(angle).Add(b.B.Multiply(lnR)));
		}

		public static Dual<T> Log<T>(this Dual<T> a) where T : Logarithm<T>, Number<T>
		{
			return new Dual<T>(a.A.Log(), a.B.Divide(a.A));
		}

		public static Complex<T> Log<T>(this Complex<T> a) where T : Logarithm<T>, Arctangent<T>, Number<T>
		{
			return new Complex<T>(a.A.Multiply(a.A).Add(a.B.Multiply(a.B)).Log().Multiply(0.5),
			                      a.B.Atan2(a.A));
		}
	}
}

