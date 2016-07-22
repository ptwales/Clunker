using System;

namespace Clunker
{
    public class FuncNFactory
    {
        /// <summary>
        /// Creates an instance of an <see cref="OnArgs"/>.
        /// </summary>
        /// <returns>A new <see cref="OnArgs"/> object.</returns>
        /// <param name="obj">Object to call on.</param>
        /// <param name="method">Name of method to call.</param>
        public FuncN onArgs(object obj, string method)
        {
            return new OnArgs(obj, method);
        }
    }
}

