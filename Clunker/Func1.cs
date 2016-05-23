using System;

namespace Clunker
{
	public interface Func1 : Applicable<object, object>
    {
		
		Pred asPredicate();
		
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
		Func1 compose(Func1 inner);

		/// <summary>
		/// Compose this function inside another function.
		/// </summary>
		/// <remarks><see cref="Clunker.Applicable.compse"/> for reverse.
		/// </remarks>
		/// <returns>A Composed where this function is the inner function.
		/// </returns>
		/// <param name="outer">Function with this will be composed.</param>
		Func1 andThen(Func1 outer);
 	}

	abstract class AbstractUnaryFunction : Func1
	{
		public abstract object apply(object arg);

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
		public Func1 compose(Func1 inner)
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
		public Func1 andThen(Func1 outer)
		{
			return outer.compose(this);
		}

		public Pred asPredicate()
		{
			return new PredFunc(this);
		}
	}
		
	class Composed : AbstractUnaryFunction
	{
		private Func1 _inner;
		private Func1 _outer;

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Composed"/> 
		/// class.
		/// </summary>
		/// <param name="outer">Function to apply last.</param>
		/// <param name="inner">Function to apply first.</param>
		public Composed(Func1 outer, Func1 inner)
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
		public override object apply(object args)
		{
			var x = _inner.apply(args);
			return _outer.apply(x);
		}
	}
}

