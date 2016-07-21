using System;

namespace Clunker
{
    static class Internals
    {
        public static Maybe option(object x)
        {
            if (x != null)
            {
                return new Some(x);
            }
            else
            {
                return new None();
            }
        }
    }
}

