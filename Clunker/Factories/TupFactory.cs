using System;

namespace Clunker.Factories
{
    public class TupFactory
    {
        /// <summary>
        /// Creates a instance of an <see cref="Tuple"/>, containing 
        /// the given elements.
        /// </summary>
        /// <returns>A new <see cref="Clunker.Tuple"/>
        /// <param name="elements">Elements to include in the tuple.</param>
        public Tup pack(params object[] elements)
        {
            return new Tup(elements);
        }
    }
}

