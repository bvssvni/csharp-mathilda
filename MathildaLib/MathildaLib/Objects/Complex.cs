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

		public Complex<T> Add(double b)
		{
			return new Complex<T>(A.Add(b), B);
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

		public Complex<T> Multiply(double b)
		{
			return new Complex<T>(A.Multiply(b), B.Multiply(b));
		}

		public Complex<T> Divide(Complex<T> b)
		{
			var dot = b.A.Multiply(b.A).Add(b.B.Multiply(b.B));
			return new Complex<T>(
				A.Multiply(b.A).Add(B.Multiply(b.B)).Divide(dot),
				B.Multiply(b.A).Subtract(A.Multiply(b.B)).Divide(dot)
				);
		}

		public Complex<T> FromReal(double b)
		{
			return new Complex<T>(this.A.FromReal(b), this.A.FromReal(0.0));
		}

		public Complex<T> FromImaginary(double b)
		{
			return new Complex<T>(this.A.FromReal(0.0), this.A.FromReal(b));
		}

		public int CompareReal(double b)
		{
			return A.CompareReal(b);
		}

		public Complex<T> Log()
		{
			var a = this;
			return new Complex<T>(a.A.Multiply(a.A).Add(a.B.Multiply(a.B)).Log().Multiply(0.5),
			                      a.B.Atan2(a.A));
		}

		public Complex<T> Atan()
		{
			var a = this;
			var i = a.FromImaginary(1.0);
			return a.FromImaginary(-0.5).Multiply(a.FromReal(1.0).Add(i.Multiply(a)).Divide(a.FromReal(1.0).Subtract(i.Multiply(a))).Log());
		}

		public Complex<T> Atan2(Complex<T> b)
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

		public Complex<T> Exp()
		{
			var r = A.Exp();
			return new Complex<T>(r.Multiply(B.Cos()), r.Multiply(B.Sin()));
		}

		public Complex<T> Cosh()
		{
			return new Complex<T>(A.Cosh().Multiply(B.Cos()),
			                      A.Sinh().Multiply(B.Sin()));
		}

		public Complex<T> Cos()
		{
			return new Complex<T>(A.Cos().Multiply(B.Cosh()),
			                      A.Sin().Multiply(B.Sinh()).Multiply(-1.0));
		}

		public Complex<T> Sinh()
		{
			return new Complex<T>(A.Sinh().Multiply(B.Cos()),
			                      A.Cosh().Multiply(B.Sin()));
		}

		public Complex<T> Sin()
		{
			return new Complex<T>(A.Sin().Multiply(B.Cosh()),
			                      A.Cos().Multiply(B.Sinh()));
		}

		public Complex<T> Pow(Complex<T> b)
		{
			var a = this;
			var lnR = a.A.Multiply(a.A).Add(a.B.Multiply(a.B)).Log().Multiply(0.5);
			var angle = a.B.Atan2(a.A);
			var r = b.A.Multiply(lnR).Subtract(b.B.Multiply(angle)).Exp();
			var r_angle = b.A.Multiply(angle).Add(b.B.Multiply(lnR));
			return new Complex<T>(r.Multiply(r_angle.Cos()),
			                      r.Multiply(r_angle.Sin()));
		}
	}
}

