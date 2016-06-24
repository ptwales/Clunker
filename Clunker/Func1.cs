using System.Runtime.InteropServices;

namespace Clunker
{
    using Unary = System.Func<object, object>;

    /// <summary>
    /// A simple function that takes one argument and outputs one argument.
    /// </summary>
    public interface Func1
    {
        /// <summary>
        /// Apply this function to a single argument and return the result.
        /// </summary>
        /// <param name="x">An argument for the function.</param>
        object apply(object x);

        /// <summary>
        /// Converts this function into a predicate.
        /// </summary>
        /// <remarks> 
        /// Using the resulting predicate may not work if it's actual return
        /// type cannot be casted to a boolean
        /// </remarks>  
        /// <returns>A new <see cref="Clunker.Pred"/> object.</returns>
        Pred asPredicate();

        /// <summary>
        /// Converts this object to an anonymous function.  This method is 
        /// mostly for internal use only.  COM client code shouldn't bother with
        /// this method.
        /// </summary>
        /// <remarks>
        /// The return type is object because it would otherwise be of type
        /// <c>Func<object, object></c> which would exclude this function from 
        /// COM as COM doesn't allow generics.
        /// </remarks>
        /// <returns>This function as a C# lambda.</returns>
        object asLambda();

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

    public abstract class AbstractUnaryFunction : Func1
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

        public virtual object asLambda()
        {
            Unary result = x => this.apply(x);
            return result;
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class UnaryFunction : AbstractUnaryFunction
    {
        Unary _unary;

        public UnaryFunction(Unary unary)
        {
            _unary = unary;
        }

        public override object apply(object arg)
        {
            return _unary(arg);
        }

        public override object asLambda()
        {
            return _unary;
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
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

