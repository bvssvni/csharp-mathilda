using System;

namespace MathildaLib
{
	public class Scalar : Number<Scalar>, Power<Scalar>, Log<Scalar>, SquareRoot<Scalar>
	{
		public double Value;

		public Scalar(double value)
		{
			Value = value;
		}

		public Scalar Add(Scalar b)
		{
			return new Scalar(Value + b.Value);
		}

		public Scalar Subtract(Scalar b)
		{
			return new Scalar(Value - b.Value);
		}

		public Scalar Subtract(double b)
		{
			return new Scalar(Value - b);
		}

		public Scalar Multiply(Scalar b)
		{
			return new Scalar(Value * b.Value);
		}

		public Scalar Divide(Scalar b)
		{
			return new Scalar(Value / b.Value);
		}

		public Scalar Pow(Scalar b)
		{
			return new Scalar(Math.Pow(Value, b.Value));
		}

		public Scalar Log()
		{
			return new Scalar(Math.Log(Value));
		}

		public Scalar Sqrt()
		{
			return new Scalar(Math.Sqrt(Value));
		}
	}
}

