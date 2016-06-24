using System;

namespace Clunker
{
	public interface Pred
	{
		bool apply(object arg);

		Func1 asUnary();

		object asLambda();
	}

	public class PredFunc : Pred
	{
		Predicate<object> _pred;

		public PredFunc(Predicate<object> pred)
		{
			_pred = pred;
		}

		public PredFunc(Func<object, object> func)
		{
			_pred = x => (bool)func(x);
		}

		public PredFunc(Func1 func)
			: this((Func<object, object>)func.asLambda())
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

		public object asLambda()
		{
			return _pred;
		}
	}
}

