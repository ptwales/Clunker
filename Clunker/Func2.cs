using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	using Accum = Func<object, object, object>;

    /// <summary>
    /// Binary function, used for combining or accumulating values often in a 
    /// reduce or fold method.
    /// </summary>
	public interface Func2
	{
        /// <summary>
        /// Apply this function on two arguments and return the value.
        /// </summary>
        /// <param name="x">First argument.</param>
        /// <param name="y">Second argument.</param>
		object apply(object x, object y);

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

		//Func1 tupled();
	}

	public abstract class AbstractBinaryFunction : Func2
	{
		public abstract object apply(object x, object y);

		public virtual object asLambda()
		{
			Accum result = (x, y) => this.apply(x, y);
            return result; // casting BS
        }

	}

	[ClassInterface(ClassInterfaceType.AutoDual)]
    public class BinaryFunction : AbstractBinaryFunction
	{
		Accum _a;

		public BinaryFunction(Accum a)
		{
			_a = a;
		}

		public override object apply(object x, object y)
		{
			return _a(x, y);
		}

		public override object asLambda()
		{
			return _a;
		}
	}
}



