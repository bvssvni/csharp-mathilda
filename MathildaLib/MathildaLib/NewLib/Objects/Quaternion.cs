using System;

namespace MathildaLib
{
	public class Quaternion<T> : Algebra<Quaternion<T>> where T : Algebra<T>
	{
		public T X;
		public T Y;
		public T Z;
		public T W;

		public override Quaternion<T> Add(Quaternion<T> b)
		{
			var a = this;
			return new Quaternion<T> () {
				X = a.X + b.X,
				Y = a.Y + b.Y,
				Z = a.Z + b.Z,
				W = a.W + b.W
			};
		}

		public override Quaternion<T> Multiply(Quaternion<T> b)
		{
			var a = this;
			var a1 = a.W;
			var b1 = a.X;
			var c1 = a.Y;
			var d1 = a.Z;
			var a2 = b.W;
			var b2 = b.X;
			var c2 = b.Y;
			var d2 = b.Z;
			return new Quaternion<T> () {
				W = a1 * a2 - b1 * b2 - c1 * c2 - d1 * d2,
				X = a1 * b2 + b1 * a2 + c1 * d2 - d1 * c2,
				Y = a1 * c2 - b1 * d2 + c1 * a2 + d1 * b2,
				Z = a1 * d2 + b1 * c2 - c1 * b2 + d1 * a2
			};
		}

		public override Quaternion<T> Inverted()
		{
			var a = this;
			var sq = a.X * a.X + a.Y * a.Y + a.Z * a.Z + a.W * a.W;
			return new Quaternion<T> () {
				X = a.X.Negative () / sq,
				Y = a.Y.Negative () / sq,
				Z = a.Z.Negative () / sq,
				W = a.W.Negative () / sq
			};
		}

		public override Quaternion<T> Negative()
		{
			var a = this;
			return new Quaternion<T> () {
				X = a.X.Negative (),
				Y = a.Y.Negative (),
				Z = a.Z.Negative (),
				W = a.W.Negative ()
			};
		}

		public override string ToString(ExpressionFormat format)
		{
			return "{" + 
					W.ToString (format) + "," +
					X.ToString (format) + "," + 
					Y.ToString (format) + "," +
					Z.ToString (format) + "}";
		}
	}
}

