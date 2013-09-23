using System;

namespace MathildaLib
{
	public static class TrigonometryModule
	{
		public static Dual<T> Sin<T>(this Dual<T> a) where T : Number<T>, Sinus<T>, Cosinus<T>
		{
			return new Dual<T>(a.A.Sin(), a.B.Multiply(a.A.Cos()));
		}

		public static Dual<T> Cos<T>(this Dual<T> a) where T : Number<T>, Sinus<T>, Cosinus<T>
		{
			return new Dual<T>(a.A.Cos(), a.B.Multiply(-1.0).Multiply(a.A.Sin()));
		}

		public static Dual<T> Tan<T>(this Dual<T> a) where T : Number<T>, Tangent<T>, Secant<T>
		{
			var sec = a.A.Sec();
			return new Dual<T>(a.A.Tan(), a.B.Multiply(sec.Multiply(sec)));
		}

		public static Dual<T> Atan<T>(this Dual<T> a) where T : Arctangent<T>, Number<T>
		{
			var dx = a.A.FromReal(1.0).Divide(a.A.FromReal(1.0).Add(a.A.Multiply(a.A)));
			return new Dual<T>(a.A.Atan(), a.B.Multiply(dx));
		}

		public static Dual<T> Atan2<T>(this Dual<T> a, Dual<T> b) where T : Arctangent<T>, Number<T>
		{
			int x = b.CompareReal(0.0);
			int y = a.CompareReal(0.0);
			if (x > 0) {return a.Divide(b).Atan();}
			if (y >= 0 && x < 0) {return a.Divide(b).Atan().Add(Math.PI);}
			if (y < 0 && x < 0) {return a.Divide(b).Atan().Subtract(Math.PI);}
			if (y > 0 && x == 0) {return a.FromReal(Math.PI * 0.5);}
			if (y < 0 && x == 0) {return a.FromReal(-Math.PI * 0.5);}
			return a.FromReal(0.0);
		}
	}
}

