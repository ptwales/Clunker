using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	public delegate bool Predicate(object arg);

	public interface Pred
	{
		bool apply(object arg);

		Func1 asUnary();

		Predicate asDelegate();
	}

	[ClassInterface(ClassInterfaceType.AutoDual)]
	class PredFunc : Pred
	{
		Predicate _pred;

		public PredFunc(Predicate pred)
		{
			_pred = pred;
		}

		public PredFunc(Unary func)
		{
			_pred = x => (bool)func(x);
		}

		public PredFunc(Func1 func)
			: this(func.asDelegate())
		{
		}

		public bool apply(object arg)
		{
			return (bool)_pred(arg);
		}

		public Func1 asUnary()
		{
			return new UnaryFunction(x => (object)_pred(x));
		}

		public Predicate asDelegate()
		{
			return _pred;
		}
	}
}

