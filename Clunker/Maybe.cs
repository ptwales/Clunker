using System;
using System.Runtime.InteropServices;

namespace Clunker
{
   
    public interface Maybe : Monadic, Showable
    {
        Maybe maybe(object boxed);
        Maybe some(object boxed);
        Maybe none();
        bool isSome();
        bool isNone();
        object getItem();
        object getOrElse(object other);
    }

    abstract class AbstractMaybe : Maybe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Clunker.Maybe"/> class.
        /// Maybe will be none if object is null and some otherwise
        /// </summary>
        /// <param name="boxed">Object to contain, may be null.</param>
        public Maybe maybe(object boxed) {
            if (boxed != null) {
                return new Some(boxed);
            } else {
                return new None();
            }
        }

        /// <summary>
        /// Returns a Maybe that contain's a non-null object.
        /// Will error if null.
        /// </summary>
        /// <param name="boxed">Non-null object to contain.</param>
        public Maybe some(object boxed) {
            return new Some (boxed);
        }

        public Maybe none() {
            return new None();
        }

        public abstract bool isSome();
        public abstract bool isNone();
        public abstract object getItem();
        public abstract object getOrElse(object other);
        public abstract Monadic map(Applicable f);
        public abstract Monadic flatMap(Applicable f);
        public abstract string show();
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    class Some : AbstractMaybe
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

        public override bool isSome() {
            return true;
        }

        public override bool isNone() {
            return false;
        }

        public override object getItem() {
            return _boxed;
        }

        public override object getOrElse(object other) {
            return _boxed;
        }

        public override Monadic map(Applicable f) {
            var result = f.apply(_boxed);
            return new Some(result);
        }

        public override Monadic flatMap(Applicable f) {
            return (Maybe) f.apply (_boxed);
        }

        public override string show() {
            return "Some(" + _boxed + ")";
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    class None : AbstractMaybe 
    {
        public None() {
          // nothing to do.    
        }

        public override bool isSome() {
            return false;
        }

        public override bool isNone() {
            return true;
        }

        public override object getItem() {
            throw new NullReferenceException ("Calling getItem on None object");
        }

        public override object getOrElse(object other) { 
            return other; 
        }

        public override Monadic map (Applicable f) {
            return new None ();
        }

        public override Monadic flatMap (Applicable f) {
            return new None ();
        }

        public override string show() {
            return "None()";
        }
    }
}
