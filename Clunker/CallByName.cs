using System;
using System.Reflection;

namespace Clunker
{
    class OnArgs : AbstractApplicable
    {
        private object _obj;
        private MethodInfo _method;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clunker.OnArgs"/> 
		/// class.
        /// </summary>
		/// <param name="obj">Object to call the method.</param>
        /// <param name="method">Name of method to call on object.</param>
        public OnArgs(object obj, string method) {
            Type objType = obj.GetType();
            _method = objType.GetMethod(method);
            _obj = obj;
        }

        /// <summary>
        /// Calls the stored method on the stored object with the given
		/// arguments.
        /// </summary>
		/// <remarks><c>obj.method(args)</c></remarks>
		/// <returns>The result of applying this method to args.</returns>
        /// <param name="args">Arguments for the method</param>
        public override object applyOnArray(object[] args) {
            return _method.Invoke(_obj, args);
        }
    }

    class OnObject : AbstractApplicable 
    {
        private object[] _args;
        private string _method;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clunker.OnObject"/>
		/// class.
        /// </summary>
        /// <param name="method">Name of method to call.</param>
        /// <param name="args">Provided arguments for the method.</param>
        public OnObject(string method, object[] args) {
            _args = args;
            _method = method;
        }

        /// <summary>
		/// Calls the stored method with the stored arguments on a given
		/// object.  Will error if the array is larger than 1.
        /// </summary>
        /// <returns>The result of applying the method.</returns>
        /// <param name="args">An array of a single object.</param>
        public override object applyOnArray(object[] args) {
            // TODO: assert args is size 1;
            var obj = args[0];
            Type objType = obj.GetType();
            MethodInfo method = objType.GetMethod(_method);
            return method.Invoke(obj, _args);
        }

    }
}

