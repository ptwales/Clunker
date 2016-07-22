using System;
using System.Runtime.InteropServices;

using Clunker.Factories;

namespace Clunker
{
	/// <summary>
	/// Clunker uses immutable classes that require dependency injection.  Since
    /// COM doesn't allow constructors with arguments, all objects are created
    /// by an instance of the factory class.
	/// </summary>
	public class Factory
	{
        public readonly MaybeFactory Maybe = new MaybeFactory();
        public readonly AssocFactory Assoc = new AssocFactory();
        public readonly TupFactory   Tup   = new TupFactory();
        public readonly SeqFactory   Seq   = new SeqFactory(); 
        public readonly Func1Factory Func1 = new Func1Factory();
        public readonly FuncNFactory FuncN = new FuncNFactory();
  	}
}

