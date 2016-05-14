using System;

namespace Clunker
{
	public interface Func : Applicable<object>
	{
		/// <summary>
		/// Compose another function inside this function.
		/// </summary>
		/// <remarks> <see cref="Clunker.Applicable.andThen"/> for reverse.
		/// </remarks>
		/// <example>
		/// // given f(x, y) = x + y
		/// // and g(x) = x * x
		/// Applicable h = g.compose(f);
		/// // h(x, y) = (x + y) * (x + y)
		/// int a = h(3, 5); // 64
		/// int b = h(-2, 12); // 100
		/// </example>
		/// <returns>A <see cref="Clunker.Composed"/> , where this function is 
		/// the outer function.</returns>
		/// <param name="inner">Function to compose.</param>
		Func compose(Func inner);

		/// <summary>
		/// Compose this function inside another function.
		/// </summary>
		/// <remarks><see cref="Clunker.Applicable.compse"/> for reverse.
		/// </remarks>
		/// <returns>A Composed where this function is the inner function.
		/// </returns>
		/// <param name="outer">Function with this will be composed.</param>
		Func andThen(Func outer);

		/// <summary>
		/// Vararg wrapper for <see cref="Clunker.Applicable.asPartial"/>
		/// </summary>
		/// <returns>A partially applied function.</returns>
		/// <param name="partialArgs">Partial arguments as varargs</param>
		Func partial(params object[] partialArgs);

		/// <summary>
		/// Create a <see cref="Clunker.Partial"/> function with stored 
		/// arguments.
		/// </summary>
		/// <remarks>Use <c>null</c> to represent missing arguments.</remarks>
		/// <example>
		/// // given f(x, y) = x + y
		/// Applicable p = f.asPartial({null, 1});
		/// int a = p.apply(12); // 13
		/// int b = p.apply(-3); // -2
		/// </example>
		/// <returns>A partially applied function.</returns>
		/// <param name="partialArgs">Some arguments with <c>null</c> for 
		/// missing args.</param>
		Func asPartial(object[] partialArgs);

		Pred asPredicate();
	}

	abstract class AbstractFunction : Func
	{
		/// <summary>
		/// Varag wrapper to <see cref="Clunker.Applicable.applyOnArray"/>
		/// </summary>
		/// <param name="args">Arguments for the function as <c>params</c>
		/// </param>
		public object apply(params object[] args)
		{
			return applyOnArray(args);
		}

		/// <summary>
		/// Applies this function to the array of arguments.
		/// </summary>
		/// <returns>The result of applying this function to args.</returns>
		/// <param name="args">Arguments for the function</param>
		public abstract object applyOnArray(object[] args);

		/// <summary>
		/// Compose another function inside this function.
		/// </summary>
		/// <remarks> <see cref="Clunker.Applicable.andThen"/> for reverse.
		/// </remarks>
		/// <example>
		/// // given f(x, y) = x + y
		/// // and g(x) = x * x
		/// Applicable h = g.compose(f);
		/// // h(x, y) = (x + y) * (x + y)
		/// int a = h(3, 5); // 64
		/// int b = h(-2, 12); // 100
		/// </example>
		/// <returns>A <see cref="Clunker.Composed"/> , where this function is 
		/// the outer function.</returns>
		/// <param name="inner">Function to compose.</param>
		public Func compose(Func inner)
		{
			return new Composed(this, inner);
		}

		/// <summary>
		/// Compose this function inside another function.
		/// </summary>
		/// <remarks><see cref="Clunker.Applicable.compse"/> for reverse.
		/// </remarks>
		/// <returns>A Composed where this function is the inner function.
		/// </returns>
		/// <param name="outer">Function with this will be composed.</param>
		public Func andThen(Func outer)
		{
			return outer.compose(this);
		}

		/// <summary>
		/// Vararg wrapper for <see cref="Clunker.Applicable.asPartial"/>
		/// </summary>
		/// <returns>A partially applied function.</returns>
		/// <param name="partialArgs">Partial arguments as varargs</param>
		public Func partial(params object[] partialArgs)
		{
			return asPartial(partialArgs);
		}

		/// <summary>
		/// Create a <see cref="Clunker.Partial"/> function with stored 
		/// arguments.
		/// </summary>
		/// <remarks>Use <c>null</c> to represent missing arguments.</remarks>
		/// <example>
		/// // given f(x, y) = x + y
		/// Applicable p = f.asPartial({null, 1});
		/// int a = p.apply(12); // 13
		/// int b = p.apply(-3); // -2
		/// </example>
		/// <returns>A partially applied function.</returns>
		/// <param name="partialArgs">Some arguments with <c>null</c> for 
		/// missing args.</param>
		public Func asPartial(object[] partialArgs)
		{
			return new Partial(this, partialArgs);
		}

		public Pred asPredicate()
		{
			return new PredFunc(this);
		}
	}

	class Composed : AbstractFunction
	{
		private Func _inner;
		private Func _outer;

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Composed"/> 
		/// class.
		/// </summary>
		/// <param name="outer">Function to apply last.</param>
		/// <param name="inner">Function to apply first.</param>
		public Composed(Func outer, Func inner)
		{
			_inner = inner;
			_outer = outer;
		}

		/// <summary>
		/// Applies the inner function on the args then uses the result
		/// as the only arg for the outer function and returns that result.
		/// </summary>
		/// <returns>The result of outer(inner(args)).</returns>
		/// <param name="args">Arguments for the inner function.</param>
		public override object applyOnArray(object[] args)
		{
			var x = _inner.applyOnArray(args);
			return _outer.apply(x);
		}
	}

	class Partial : AbstractFunction
	{
		private Func _function;
		private object[] _partialArgs;
		private int _argCount;

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Partial"/> 
		/// class.
		/// </summary>
		/// <param name="function">Function to preset some arguments.</param>
		/// <param name="partialArgs">Partial arguments, use <c>null</c> for
		/// missing arguments.</param>
		public Partial(Func function, object[] partialArgs)
		{
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
		/// too big or too small to replace all null values in the stored args.
		/// </exception>
		/// <returns>The result of the partial function with the given arguments.
		/// </returns>
		/// <param name="args">Remaining arguments.</param>
		public override object applyOnArray(object[] args)
		{

			object[] usedArgs = new object[_argCount];
			var a = 0;

			for (int p = 0; p < _argCount; ++p) {

				if (_partialArgs[p] == null) {
					usedArgs[p] = args[a];
					++a;
				} else {
					usedArgs[p] = _partialArgs[p];
				}
			}

			if (a == args.Length - 1) {
				return _function.applyOnArray(usedArgs);
			} else {
				var message = string.Format("Too many arguments received.  Expected: {0}, recieved: {1}",
					                          a + 1,
					                          args.Length);
				throw new ArgumentException(message, "args");
			}
                
		}

	}
}

