using System;

namespace Clunker
{
	interface Applicable
	{
		object apply(params object[] args);
		object applyOnArray(object[] args);
		Applicable compose(Applicable inner);
		Applicable andThen(Applicable outer);
		Applicable partial(params object[] partialArgs);
		Applicable asPartial(object[] partialArgs);
	}

	abstract class AbstractApplicable : Applicable
	{ 
		public object apply(params object[] args) {
			return applyOnArray(args);
		}

		public abstract object applyOnArray(object[] args);

		public Applicable partial(params object[] partialArgs) {
			return asPartial(partialArgs);
		}

		public Applicable asPartial(object[] partialArgs) {
			return new Partial(this, partialArgs);
		}

		public Applicable compose(Applicable inner) {
			return new Composed(this, inner);
		}

		public Applicable andThen(Applicable outer) {
			return new Composed(outer, this);
		}
	}

	class Composed : AbstractApplicable
	{
		private Applicable _inner;
		private Applicable _outer;

		public Composed(Applicable outer, Applicable inner) {
			_inner = inner;
			_outer = outer;
		}

		public override object applyOnArray(object[] args) {
			var x = _inner.applyOnArray(args);
			return _outer.apply (x);
		}
	}

	class Partial : AbstractApplicable
	{
		private Applicable _function;
		private object[] _partialArgs;
		private int _argCount;

		public Partial(Applicable function, object[] partialArgs) {
			_function = function;
			_partialArgs = partialArgs;
			_argCount = _partialArgs.Length;
		}

		public override object applyOnArray(object[] args) {

			object[] usedArgs = new object[_argCount];
			var a = 0;

			for (int p = 0; p < _argCount; ++p) {

				if (_partialArgs [p] == null) {
					usedArgs [p] = args [a];
					++a;
				} else {
					usedArgs [p] = _partialArgs [p];
				}
			}

			if (a == args.Length - 1) {
				return _function.applyOnArray (usedArgs);
			} else {
				var message = string.Format("Too many arguments received.  Expected: {0}, recieved: {1}",
					a + 1,
					args.Length);
				throw new ArgumentException (message, "args");
			}
				
		}
	}
}

