using System;

namespace MathildaLib
{
	public static class DualQuaternionModule
	{
		public static Quaternion<Dual<Real>> Create (string name) {
			return new Quaternion<Dual<Real>> () {
				W = new Dual<Real> () {
					Re = Real.Variable (name + "[0]"),
					Eps = Real.Variable (name + "[1]"),
				},
				X = new Dual<Real> () {
					Re = Real.Variable (name + "[2]"),
					Eps = Real.Variable (name + "[3]"),
				},
				Y = new Dual<Real> () {
					Re = Real.Variable (name + "[4]"),
					Eps = Real.Variable (name + "[5]"),
				},
				Z = new Dual<Real> () {
					Re = Real.Variable (name + "[6]"),
					Eps = Real.Variable (name + "[7]"),
				},
			};
		}

		public static Quaternion<Dual<Real>> CreateFromAngleAndAxis (string angle,
		                                                             Real x,
		                                                             Real y,
		                                                             Real z) {
			return new Quaternion<Dual<Real>> () {
				W = new Dual<Real> () {
					Re = Real.Variable ("cos(" + angle + "/2)"),
					Eps = Real.Scalar (0),
				},
				X = new Dual<Real> () {
					Re = Real.Variable ("sin(" + angle + "/2)") * x,
					Eps = Real.Scalar (0),
				},
				Y = new Dual<Real> () {
					Re = Real.Variable ("sin(" + angle + "/2)") * y,
					Eps = Real.Scalar (0),
				},
				Z = new Dual<Real> () {
					Re = Real.Variable ("sin(" + angle + "/2)") * z,
					Eps = Real.Scalar (0),
				},
			};
		}

		public static Quaternion<Dual<Real>> CreateFromPosition (Real x, Real y, Real z) {
			return new Quaternion<Dual<Real>> () {
				W = new Dual<Real> () {
					Re = Real.Scalar (1),
					Eps = Real.Scalar (0),
				},
				X = new Dual<Real> () {
					Re = Real.Scalar (0),
					Eps = x,
				},
				Y = new Dual<Real> () {
					Re = Real.Scalar (0),
					Eps = y,
				},
				Z = new Dual<Real> () {
					Re = Real.Scalar (0),
					Eps = z,
				},
			};
		}

		public static Quaternion<Dual<Real>> Transform (Quaternion<Dual<Real>> transform,
		                                             Quaternion<Dual<Real>> position) {
			return transform * position * transform.Inverted ();
		}
	}
}

