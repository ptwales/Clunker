using System;

namespace Clunker.Factories
{
    public class SeqFactory
    {
        /// <summary>
        /// Creates a Sequence (<see cref="Seq"/>) containing the given
        /// elements.
        /// </summary>
        /// <returns>A new Seq</returns>
        /// <param name="elements">Elements to be contained in the new Sequence.
        /// </param>
        public Collections.Seq make(params object[] elements)
        {
            return new Collections.List(elements);
        }
    }
}

