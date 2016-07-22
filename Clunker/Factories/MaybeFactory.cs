using System;

namespace Clunker.Factories
{
    public class MaybeFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Clunker.Maybe"/> class.
        /// Maybe will be none if object is null and some otherwise
        /// </summary>
        /// <param name="boxed">Object to contain, may be null.</param>
        public Maybe maybe(object boxed)
        {
            if (boxed != null)
            {
                return new Some(boxed);
            }
            else
            {
                return new None();
            }
        }

        /// <summary>
        /// Creates a <see cref="Some"/> that contains a non-null object.
        /// Will error if null.
        /// </summary>
        /// <param name="boxed">Non-null object to contain.</param>
        public Maybe some(object boxed)
        {
            return new Some(boxed);
        }

        /// <summary>
        /// Creates an instance of a <see cref="None"/>.
        /// </summary>
        /// <returns>A <see cref="None"/> object.</returns>
        public Maybe none()
        {
            return new None();
        }
    }
}

