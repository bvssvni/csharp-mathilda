using System;

namespace MathildaLib
{
	public abstract class Algebra<T> where T : Algebra<T>
	{
		public abstract T Add (T b);
		public abstract T Multiply (T b);
		public abstract T Inverted ();
		public abstract T Negative ();
		public abstract string ToString (ExpressionFormat format);
		
		public T Subtract (T b) {
			var bNegative = b.Negative ();
			return this.Add (bNegative);
		}

		public T Divide (T b) {
			var invB = b.Inverted ();
			return this.Multiply (invB);
		}

		public static T operator + (Algebra<T> a, T b) {
			return a.Add (b);
		}
		
		public static T operator - (Algebra<T> a, T b) {
			return a.Subtract (b);
		}
		
		public static T operator * (Algebra<T> a, T b) {
			return a.Multiply (b);
		}
		
		public static T operator / (Algebra<T> a, T b) {
			return a.Divide (b);
		}
	}
}

