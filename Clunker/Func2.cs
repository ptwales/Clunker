using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	public delegate object Accum(object x,object y);

	public interface Func2
	{
		object apply(object x, object y);

		Accum asDelegate();
		//Func1 tupled();
	}

	abstract class AbstractBinaryFunction : Func2
	{
		public abstract object apply(object x, object y);

		public virtual Accum asDelegate()
		{
			return (x, y) => this.apply(x, y);
		}

	}

	[ClassInterface(ClassInterfaceType.AutoDual)]
	class BinaryFunction : AbstractBinaryFunction
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

		public override Accum asDelegate()
		{
			return _a;
		}
	}
}



