using System;

namespace MathildaLib
{
	public interface Number<T>
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
	}
}

