using System;

namespace MathildaLib
{
	public class Complex<T> : Algebra<Complex<T>> where T : Algebra<T>
	{
		public T Re;
		public T Img;

		public override Complex<T> Add (Complex<T> b) {
			var a = this;
			return new Complex<T> () {
				Re = a.Re + b.Re,
				Img = a.Img + b.Img
			};
		}

		public override Complex<T> Multiply (Complex<T> b) {
			var a = this;
			return new Complex<T> () {
				Re = a.Re * b.Re - a.Img * b.Img,
				Img = a.Re * b.Img + a.Img * b.Re
			};
		}

		public override Complex<T> Inverted()
		{
			var sq = Re * Re + Img * Img;
			return new Complex<T> () {
				Re = this.Re / sq,
				Img = this.Img / Img
			};
		}

		public override Complex<T> Negative()
		{
			return new Complex<T> () {
				Re = this.Re.Negative (),
				Img = this.Img.Negative ()
			};
		}

		public override string ToString()
		{
			return "{" + Re.ToString () + "," + Img.ToString () + "}";
		}

		public override string ToString (ExpressionFormat format) {
			return "{" + Re.ToString (format) + "," + Img.ToString (format) + "}";
		}
	}
}

