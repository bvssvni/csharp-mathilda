using System;

namespace MathildaLib
{
	public class Dual<T> : 
		Number<Dual<T>>
			where T : Number<T>
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

		public Dual<T> Add(double b)
		{
			return new Dual<T>(A.Add(b), B);
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

		public Dual<T> Multiply(double b)
		{
			return new Dual<T>(A.Multiply(b), B.Multiply(b));
		}

		public Dual<T> Divide(Dual<T> b)
		{
			return new Dual<T>(A.Divide(b.A),
			                   B.Multiply(b.A).Subtract(A.Multiply(b.B)).Divide(b.A.Multiply(b.A)));
		}

		public Dual<T> FromReal(double b)
		{
			return new Dual<T>(A.FromReal(b), A.FromReal(0.0));
		}

		public int CompareReal(double b)
		{
			return A.CompareReal(b);
		}

		public Dual<T> Log()
		{
			var a = this;
			return new Dual<T>(a.A.Log(), a.B.Divide(a.A));
		}

		public Dual<T> Atan()
		{
			var a = this;
			var dx = a.A.FromReal(1.0).Divide(a.A.FromReal(1.0).Add(a.A.Multiply(a.A)));
			return new Dual<T>(a.A.Atan(), a.B.Multiply(dx));
		}

		public Dual<T> Atan2(Dual<T> b)
		{
			var a = this;
			int x = b.CompareReal(0.0);
			int y = a.CompareReal(0.0);
			if (x > 0) {return a.Divide(b).Atan();}
			if (y >= 0 && x < 0) {return a.Divide(b).Atan().Add(Math.PI);}
			if (y < 0 && x < 0) {return a.Divide(b).Atan().Subtract(Math.PI);}
			if (y > 0 && x == 0) {return a.FromReal(Math.PI * 0.5);}
			if (y < 0 && x == 0) {return a.FromReal(-Math.PI * 0.5);}
			return a.FromReal(0.0);
		}

		public Dual<T> Exp()
		{
			var a = this;
			var aExp = a.A.Exp();
			return new Dual<T>(aExp, a.B.Multiply(aExp));
		}

		public Dual<T> Sin()
		{
			var a = this;
			return new Dual<T>(a.A.Sin(), a.B.Multiply(a.A.Cos()));
		}

		public Dual<T> Sinh()
		{
			var a = this;
			return new Dual<T>(a.A.Sinh(), a.B.Cosh());
		}

		public Dual<T> Cos()
		{
			var a = this;
			return new Dual<T>(a.A.Cos(), a.B.Multiply(-1.0).Multiply(a.A.Sin()));
		}

		public Dual<T> Cosh()
		{
			var a = this;
			return new Dual<T>(a.A.Cosh(), a.B.Sinh());
		}

		public Dual<T> Pow(Dual<T> b)
		{
			var a = this;
			var pow = a.A.Pow(b.A);
			return new Dual<T>(
				pow,
				a.B.Multiply(b.A.Multiply(a.A.Pow(b.A.Subtract(1))))
				.Add(b.B.Multiply(pow.Multiply(a.A.Log())))
				);
		}
	}
}

