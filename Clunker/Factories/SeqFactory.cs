using Clunker.Collections;

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
        public Seq make(params object[] elements)
        {
            return new List(elements);
        }
    }
}

