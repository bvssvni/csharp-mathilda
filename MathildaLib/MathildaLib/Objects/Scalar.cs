using System;

namespace MathildaLib
{
	public class Scalar : 
		Number<Scalar>, 
		SquareRoot<Scalar>,
		Tangent<Scalar>,
		Secant<Scalar>
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

		public Scalar Add(double b)
		{
			return new Scalar(Value + b);
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

		public Scalar Multiply(double b)
		{
			return new Scalar(Value * b);
		}

		public Scalar Divide(Scalar b)
		{
			return new Scalar(Value / b.Value);
		}

		public Scalar Pow(Scalar b)
		{
			return new Scalar(Math.Pow(Value, b.Value));
		}

		public Scalar Exp()
		{
			return new Scalar(Math.Exp(Value));
		}

		public Scalar Log()
		{
			return new Scalar(Math.Log(Value));
		}

		public Scalar Sqrt()
		{
			return new Scalar(Math.Sqrt(Value));
		}
		
		public Scalar Sin()
		{
			return new Scalar(Math.Sin(Value));
		}

		public Scalar Sinh()
		{
			return new Scalar(Math.Sinh(Value));
		}

		public Scalar Cos()
		{
			return new Scalar(Math.Cos(Value));
		}

		public Scalar Cosh()
		{
			return new Scalar(Math.Cosh(Value));
		}

		public Scalar Tan()
		{
			return new Scalar(Math.Tan(Value));
		}

		public Scalar Sec()
		{
			return new Scalar(1.0 / Math.Cos(Value));
		}

		public Scalar Atan()
		{
			return new Scalar(Math.Atan(Value));
		}

		public Scalar Atan2(Scalar x)
		{
			return new Scalar(Math.Atan2(Value, x.Value));
		}

		public Scalar FromReal(double b)
		{
			return new Scalar(b);
		}

		public int CompareReal(double b)
		{
			return Value.CompareTo(b);
		}
	}
}

