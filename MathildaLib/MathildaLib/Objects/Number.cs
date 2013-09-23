using System;

namespace MathildaLib
{
	public interface Number<T> : Hyperbolic<T>
	{
		T Add(T b);
		T Add(double b);
		T Subtract(T b);
		T Subtract(double b);
		T Multiply(T b);
		T Multiply(double b);
		T Divide(T b);
		T FromReal(double b);
		int CompareReal(double b);
		T Log();
		T Sin();
		T Cos();
		T Atan2(T x);
		T Atan();
		T Exp();
		T Pow(T b);
	}
}

