using System;

namespace Clunker
{
    public class AssocFactory
    {
        /// <summary>
        /// Creates a new instance of an <see cref="Assoc"/> class.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="val">Value.</param>
        public Assoc assoc(object key, object val)
        {
            return new Assoc(key, val);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Assoc"/> class,
        /// where the value is the result of op applied to the key.
        /// </summary>
        /// <param name="op">Function to apply to the key to get the value.
        /// </param>
        /// <param name="key">Key.</param>
        public Assoc memeo(Func1 op, object key)
        {
            return new Assoc(key, op.apply(key));
        }
    }
}

