using System;

namespace MathildaLib
{
	public class Dual<T> : Number<Dual<T>> where T : Number<T>
	{
		public T A;
		public T B;

		public Dual(T a, T b)
		{
			A = a;
			B = b;
		}

		public Dual<T> Add(Dual<T> b)
		{
			return new Dual<T>(A.Add(b.A), B.Add(b.B));
		}

		public Dual<T> Subtract(Dual<T> b)
		{
			return new Dual<T>(A.Subtract(b.A), B.Subtract(b.B));
		}

		public Dual<T> Subtract(double b)
		{
			return new Dual<T>(A.Subtract(b), B);
		}

		public Dual<T> Multiply(Dual<T> b)
		{
			return new Dual<T>(A.Multiply(b.A), A.Multiply(b.B).Add(B.Multiply(b.A)));
		}

		public Dual<T> Divide(Dual<T> b)
		{
			return new Dual<T>(A.Divide(b.A),
			                   B.Multiply(b.A).Subtract(A.Multiply(b.B)).Divide(b.A.Multiply(b.A)));
		}

	}
}

