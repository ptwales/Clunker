using System;
using System.Runtime.InteropServices;

namespace Clunker
{
   
    public interface Maybe : Monadic, Showable
    {
        bool isSome();
        bool isNone();
        object getItem();
        object getOrElse(object other);
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    class Some : Maybe
    {
        /// <summary>
        /// Single value contained by the Maybe object.
        /// </summary>
        private object _boxed;

        public Some(object boxed) {
            if (boxed != null) {
                _boxed = boxed;
            } else {
                throw new ArgumentNullException("boxed", "Cannot create some of null object, use maybe instead.");
            }
        }

        public bool isSome() {
            return true;
        }

        public bool isNone() {
            return false;
        }

        public object getItem() {
            return _boxed;
        }

        public object getOrElse(object other) {
            return _boxed;
        }

        public Monadic map(Applicable f) {
            var result = f.apply(_boxed);
            return new Some(result);
        }

        public Monadic flatMap(Applicable f) {
            return (Maybe) f.apply (_boxed);
        }

        public string show() {
            return "Some(" + _boxed + ")";
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    class None : Maybe 
    {
        public None() {
          // nothing to do.    
        }

        public bool isSome() {
            return false;
        }

        public bool isNone() {
            return true;
        }

        public object getItem() {
            throw new NullReferenceException ("Calling getItem on None object");
        }

        public object getOrElse(object other) { 
            return other; 
        }

        public Monadic map (Applicable f) {
            return new None ();
        }

        public Monadic flatMap (Applicable f) {
            return new None ();
        }

        public string show() {
            return "None()";
        }
    }
}
