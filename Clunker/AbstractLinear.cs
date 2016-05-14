using System;
using Clunker;

namespace Clunker.Collections
{
    public abstract class AbstractLinear : Linear
    {
        public int size()
        {
            return upperBound() - lowerBound() + 1;
        }

        public object head()
        {
            return item(lowerBound());
        }

        public object last()
        {
            return item(upperBound());
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public Maybe maybeHead()
        {
            if (!isEmpty()) {
                return new Some(head());
            } else {
                return new None();
            }
        }

        public Maybe maybeLast() 
        {
            if (!isEmpty()) {
                return new Some(last());
            } else {
                return new None();
            }
        }

        public Maybe indexOf(object val)
        {
            Splat eq = a => a[0] == val;
			return indexWhere(new InternalDelegate(eq).asPredicate());
        }

        public Maybe lastIndexOf(object val)
        {
            Splat eq = a => a[0] == val;
			return lastIndexWhere(new InternalDelegate(eq).asPredicate());
        }

		public Maybe find(Pred pred)
        {
            return indexWhere(pred).map(new OnArgs(this, "item"));
        }

		public Maybe findLast(Pred pred)
        {
            return lastIndexWhere(pred).map(new OnArgs(this, "item"));
        }

        protected Maybe findResult(int result, int invalid)
        {
            if (result != invalid) {
                return new Some(result);
            } else {
                return new None();
            }
        }

        public abstract int lowerBound();

        public abstract int upperBound();

        public abstract object item(int index);

        public abstract Linear tail();

        public abstract Linear init();

        public abstract object[] toArray();

		public abstract Maybe indexWhere(Pred pred);

		public abstract Maybe lastIndexWhere(Pred pred);

		public abstract int countWhere(Pred pred);

    }
}

