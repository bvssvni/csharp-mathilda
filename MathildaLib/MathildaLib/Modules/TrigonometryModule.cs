using System;

namespace MathildaLib
{
	public static class TrigonometryModule
	{
		public static Dual<T> Tan<T>(this Dual<T> a) where T : Number<T>, Tangent<T>, Secant<T>
		{
			var sec = a.A.Sec();
			return new Dual<T>(a.A.Tan(), a.B.Multiply(sec.Multiply(sec)));
		}

	}
}

