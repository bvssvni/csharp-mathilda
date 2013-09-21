using System;

namespace MathildaLib
{
	public interface Number<T>
	{
		T Add(T b);
		T Subtract(T b);
		T Subtract(double b);
		T Multiply(T b);
		T Divide(T b);
	}
}

