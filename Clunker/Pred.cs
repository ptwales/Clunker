using System;

namespace Clunker
{
	//public delegate bool Predicate(object arg);

	public interface Pred
	{
		bool apply(object arg);

		Func1 asUnary();
	}

	class PredFunc : Pred
	{
		Func1 _f;

		public PredFunc(Func1 f)
		{
			_f = f;
		}

		//public PredFunc(Predicate p)
		//{
		//}

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

