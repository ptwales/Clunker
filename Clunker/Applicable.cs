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
		object apply(params object[] args) {
			return applyOnArray(args);
		}

		abstract object applyOnArray(object[] args);

		Applicable partial(params object[] partialArgs) {
			return asPartial(partialArgs);
		}

		Applicable asPartial(object[] partialArgs) {
			return new Partial(partialArgs);
		}

		Applicable compose(Applicable inner) {
			return new Composed(this, inner);
		}

		Applicable andThen(Applicable outer) {
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

		override object applyOnArray(object[] args) {
			var x = _inner.applyOnArray(args);
			return _outer.apply (x);
		}
	}

	class Partial : AbstractApplicable
	{
		private Applicable _function;
		private object[] _args;

		public Partial(Applicable function, object[] args) {
			_function = function;
			_args = args;
		}

		override object applyOnArray(object[] args) {
			return null;
		}
	}
}

