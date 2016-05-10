using System;

namespace Clunker
{
	public interface Applicable
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
		/// <summary>
		/// Vararg wrapper for `applyOnArray`
		/// </summary>
		/// <returns>The result of this function</returns>
		/// <param name="args">Arguments as varargs.</param>
		public object apply(params object[] args) {
			return applyOnArray(args);
		}

		public abstract object applyOnArray(object[] args);

		/// <summary>
		/// Vararg wrapper for `asPartial`
		/// </summary>
		/// <returns>A partially applied function.</returns>
		/// <param name="partialArgs">Partial arguments as varargs</param>
		public Applicable partial(params object[] partialArgs) {
			return asPartial(partialArgs);
		}

		/// <summary>
		/// Create a partial function with partial arguments.
		/// </summary>
		/// <remarks>Use `null` to represent missing arguments.</remarks>
		/// <example>
		/// // given f(x, y) = x + y
		/// Applicable p = f.asPartial({null, 1});
		/// int a = p.apply(12); // 13
		/// int b = p.apply(-3); // -2
		/// </example>
		/// <returns>A partially applied function.</returns>
		/// <param name="partialArgs">Some arguments with null for missing args.</param>
		public Applicable asPartial(object[] partialArgs) {
			return new Partial(this, partialArgs);
		}

		/// <summary>
		/// Compose another function inside this function.
		/// </summary>
		/// <remarks>See andThen for reverse.</remarks>
		/// <example>
		/// // given f(x, y) = x + y
		/// // and g(x) = x * x
		/// Applicable h = g.compose(f);
		/// // h(x, y) = (x + y) * (x + y)
		/// int a = h(3, 5); // 64
		/// int b = h(-2, 12); // 100
		/// </example>
		/// <returns>A Composed, where this function is the outer function.</returns>
		/// <param name="inner">Function to compose.</param>
		public Applicable compose(Applicable inner) {
			return new Composed(this, inner);
		}

		/// <summary>
		/// Compose this function inside another function.
		/// </summary>
		/// <returns>A Composed where this function is the inner function.</returns>
		/// <param name="outer">Function with this will be composed.</param>
		public Applicable andThen(Applicable outer) {
			return outer.compose(this);
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

		/// <summary>
		/// Applies the inner function on the args then uses the result
		/// as the only arg for the outer function and returns that result.
		/// </summary>
		/// <returns>The result of outer(inner(args)).</returns>
		/// <param name="args">Arguments for the inner function.</param>
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

		/// <summary>
		/// Applies this function on an array of arguments.
		/// </summary>
		/// <remarks>
		/// Uses args to replace all null values in the stored arguments,
		/// then applies the function with that array as the arguments
		/// </remarks>
		/// <exception cref="ArgumentException">Throws and exception if args is 
		/// too big or too small to replace all null values in the stored args.</exception>
		/// <returns>The result of the partial function with the given arguments.</returns>
		/// <param name="args">Remaining arguments.</param>
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

