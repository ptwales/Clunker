using System;
using System.Collections.Generic;
using System.Text;

namespace Clunker
{
    public class Maybe
    {
        private object _boxed;

        public Maybe(object boxed)
        {
            _boxed = boxed;
        }

        public Maybe some(object boxed)
        {
            if (boxed != null)
            {
                return new Maybe(boxed);
            }
            else
            {
                throw new ArgumentNullException("boxed", "Cannot create some of null object, use maybe instead.");
            }
        }

        public Maybe none()
        {
            return new Maybe(null);
        }

        public Maybe maybe(object unknown)
        {
            return new Maybe(unknown);
        }

        public bool isSome()
        {
            return (_boxed != null);
        }

        public bool isNone()
        {
            return !isSome();
        }

    }
}
