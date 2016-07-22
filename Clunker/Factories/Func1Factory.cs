using System;

namespace Clunker.Factories
{
    public class Func1Factory
    {
        /// <summary>
        /// Creates an instance of an <see cref="OnObject"/>.
        /// </summary>
        /// <returns>A new <see cref="Clunker.OnObject"/>.</returns>
        /// <param name="method">Name of method to call</param>
        /// <param name="args">Arguments to call with the method.</param>
        public Func1 onObject(string method, params object[] args)
        {
            return new OnObject(method, args);
        }
    }
}

