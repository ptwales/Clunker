using Clunker.Collections;

namespace Clunker.Factories
{
    public class ListFactory
    {
        /// <summary>
        /// Creates a List (<see cref="List"/>) containing the given 
        /// elements.
        /// </summary>
        /// <returns>A new List</returns>
        /// <param name="elements">Elements to be contained in the new List.
        /// </param>
        public List make(params object[] elements)
        {
            return new List(elements);
        }
    }
}

