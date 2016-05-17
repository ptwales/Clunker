using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	
	public interface Pred : Applicable<bool>
	{
		Func asFunction();
	}

	public abstract class AbstractPredicate : Pred
	{
		public bool apply(params object[] args)
		{
			return applyOnArray(args);
		}

		public abstract bool applyOnArray(object[] args);
		public abstract Func asFunction();
	}

	class PredFunc : AbstractPredicate
	{
		Func _f;

		public PredFunc(Func f)
		{
			_f = f;
		}

		public override bool applyOnArray(object[] args)
		{
			return (bool)_f.applyOnArray(args);
		}

		public override Func asFunction()
		{
			return _f;
		}
	}
}

