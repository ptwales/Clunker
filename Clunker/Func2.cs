using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	using Accum = Func<object, object, object>;

	public interface Func2
	{
		object apply(object x, object y);

        object asDelegate();
		//Func1 tupled();
	}

	public abstract class AbstractBinaryFunction : Func2
	{
		public abstract object apply(object x, object y);

		public virtual object asDelegate()
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

		public override object asDelegate()
		{
			return _a;
		}
	}
}



