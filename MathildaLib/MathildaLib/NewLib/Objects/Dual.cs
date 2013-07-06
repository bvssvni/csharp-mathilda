using System;

namespace MathildaLib
{
	public class Dual<T> : Algebra<Dual<T>> where T : Algebra<T>
	{
		public T Re;
		public T Eps;

		public override Dual<T> Add(Dual<T> b)
		{
			var a = this;
			return new Dual<T> () {
				Re = a.Re + b.Re,
				Eps = a.Eps + b.Eps
			};
		}

		public override Dual<T> Inverted()
		{
			var a = this;
			return new Dual<T> () {
				Re = a.Re.Inverted (),
				Eps = a.Eps.Negative () / (a.Re * a.Re)
			};
		}

		public override Dual<T> Negative()
		{
			var a = this;
			return new Dual<T> () {
				Re = a.Re.Negative (),
				Eps = a.Eps.Negative ()
			};
		}

		public override Dual<T> Multiply(Dual<T> b)
		{
			var a = this;
			return new Dual<T> () {
				Re = a.Re * b.Re,
				Eps = a.Re * b.Eps + a.Eps * b.Re
			};
		}

		public override string ToString(ExpressionFormat format)
		{
			return "{" + this.Re.ToString (format) + "," + this.Eps.ToString () + "}";
		}
	}
}

