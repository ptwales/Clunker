using System;

namespace Clunker
{
	public interface Pred : Applicable<bool> {}

	public abstract class AbstractPredicate : Pred
	{
		public bool apply(params object[] args)
		{
			return applyOnArray(args);
		}

		public abstract bool applyOnArray(object[] args);
	}

	public class PredFunc : AbstractPredicate
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
	}
}

