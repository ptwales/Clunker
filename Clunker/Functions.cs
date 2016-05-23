using System;

namespace Clunker
{
	public delegate object Splat(object[] args);

    class VariadicFunction : AbstractFunction
    {
		Splat _splat;

		public VariadicFunction(Splat splat)
        {
			_splat = splat;
        }

		public override object apply(params object[] args)
		{
			return _splat(args);
		}
    }

	public delegate object Unary(object arg);

	class UnaryFunction : AbstractUnaryFunction
	{
		Unary _unary;

		public UnaryFunction(Unary unary)
		{
			_unary = unary;
		}

		public override object apply(object arg)
		{
			return _unary(arg);
		}
	}

	class PredFunc : Pred
	{
		Func1 _f;

		public PredFunc(Func1 f)
		{
			_f = f;
		}

		public PredFunc(Unary f)
		{
			_f = new UnaryFunction(f);
		}

		public bool apply(object arg)
		{
			return (bool)_f.apply(arg);
		}

		public  Func1 asUnary()
		{
			return _f;
		}
	}
}

