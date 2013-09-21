using System;

namespace MathildaLib
{
	public class Complex<T> : Number<Complex<T>> where T : Number<T>
	{
		public T A;
		public T B;

		public Complex(T a, T b)
		{
			A = a;
			B = b;
		}

		public Complex<T> Add(Complex<T> b)
		{
			return new Complex<T>(A.Add(b.A), B.Add(b.B));
		}

		public Complex<T> Subtract(Complex<T> b)
		{
			return new Complex<T>(A.Subtract(b.A), B.Subtract(b.B));
		}

		public Complex<T> Subtract(double b)
		{
			return new Complex<T>(A.Subtract(b), B);
		}

		public Complex<T> Multiply(Complex<T> b)
		{
			return new Complex<T>(A.Multiply(b.A).Subtract(B.Multiply(b.B)),
			                      A.Multiply(b.B).Add(B.Multiply(b.A)));
		}

		public Complex<T> Divide(Complex<T> b)
		{
			var dot = b.A.Multiply(b.A).Add(b.B.Multiply(b.B));
			return new Complex<T>(
				A.Multiply(b.A).Add(B.Multiply(b.B)).Divide(dot),
				B.Multiply(b.A).Subtract(A.Multiply(b.B)).Divide(dot)
				);
		}
	}
}

