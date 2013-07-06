using System;

namespace MathildaLib
{
	public class Complex
	{
		public Real Re;
		public Real Img;

		public Complex Add (Complex b) {
			var a = this;
			return new Complex () {
				Re = a.Re + b.Re,
				Img = a.Img + b.Img
			};
		}

		public Complex Multiply (Complex b) {
			var a = this;
			return new Complex () {
				Re = a.Re * b.Re - a.Img * b.Img,
				Img = a.Re * b.Img + a.Img * b.Re
			};
		}

		public static Complex operator + (Complex a, Complex b) {
			return a.Add (b);
		}

		public static Complex operator * (Complex a, Complex b) {
			return a.Multiply (b);
		}

		public override string ToString()
		{
			return "{" + Re.ToString () + "," + Img.ToString () + "}";
		}

		public string ToString (ExpressionFormat format) {
			return "{" + Re.ToString (format) + "," + Img.ToString (format) + "}";
		}
	}
}

