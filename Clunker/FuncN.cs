using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	using Splat = Func<object[], object>;

    /// <summary>
    /// A variadic function.
    /// </summary>
    /// <remarks>
    /// Whereas <see cref="Clunker.Func1"/> and <see cref="Clunker.Func2"/>
    /// specify their argument count, FuncN covers all other cases as a simple
    /// variadic function.  That doesn't mean the function it wraps or represent
    /// really is variadic so Be careful to provide the correct argument count 
    /// to prevent runtime errors.
    /// </remarks>
    public interface FuncN
	{
		/// <summary>
		/// Apply as a variadic function.
		/// </summary>
		/// <param name="args">Arguments for the function as <c>params</c>
		/// </param>
		object apply(params object[] args);

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
		FuncN asPartial(params object[] partialArgs);

        /// <summary>
        /// Returns this function as a <see cref="Clunker.Func1"/>
        /// </summary>
        /// <remarks>
        /// Caution as there is not compile time checks if the contained
        /// is really an unary function.
        /// </remarks>
        /// <returns>The contained function as an unary function.</returns>
		Func1 asUnary();

        /// <summary>
        /// Converts this instance into a <see cref="Clunker.Func1"/> that
        /// expects a <see cref="Clunker.Tuple"/> of args for the variadic
        /// function.
        /// </summary>
		Func1 tupled();
	}

    public abstract class AbstractFunction : FuncN
	{
		/// <summary>
		/// Applies this function to the array of arguments.
		/// </summary>
		/// <returns>The result of applying this function to args.</returns>
		/// <param name="args">Arguments for the function</param>
		public abstract object apply(params object[] args);

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
		public FuncN asPartial(object[] partialArgs)
		{
			return new Partial(this, partialArgs);
		}

		public Func1 asUnary()
		{
			return new UnaryFunction(x => this.apply(x));
		}

		public Func1 tupled()
		{
			return new UnaryFunction(t => this.apply(((Tup)t).explode()));
		}
	}

	
	public class VariadicFunction : AbstractFunction
	{
		Splat _splat;

		public VariadicFunction(Splat splat)
		{
			_splat = splat;
		}

		public override object apply(params object[] args)
		{
			return _splat(args);
		}
	}

	
	class Partial : AbstractFunction
	{
		private FuncN _function;
		private object[] _partialArgs;
		private int _argCount;

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Partial"/> 
		/// class.
		/// </summary>
		/// <param name="function">Function to preset some arguments.</param>
		/// <param name="partialArgs">Partial arguments, use <c>null</c> for
		/// missing arguments.</param>
		public Partial(FuncN function, object[] partialArgs)
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
		public override object apply(params object[] args)
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

			if (a == args.Length) {
				return _function.apply(usedArgs);
			} else {
				var message = string.Format("Too many arguments received.  Expected: {0}, recieved: {1}",
					              a,
					              args.Length);
				throw new ArgumentException(message, "args");
			}
                
		}

	}
}

