﻿using System;
using System.Collections.Generic;
using System.Linq;
using Clunker;

namespace Clunker.Collections
{
    using DotNetCollections = System.Collections.Generic;

    public class List : AbstractLinear, Showable
    {
        private DotNetCollections.List<object> _list;

        public List(IEnumerable<object> sequence)
        {
            _list = new DotNetCollections.List<object>(sequence);
        }

        // --------------- Linear ------------------------

        public override int lowerBound()
        {
            return 0;
        }

        public override int upperBound()
        {
            return _list.Count - 1;
        }

        public override object item(int index)
        {
            return _list[index];
        }

        public override Linear tail()
        {
            return new List(_list.GetRange(1, upperBound()));
        }

        public override Linear init()
        {
            return new List(_list.GetRange(0, upperBound()));
        }

        public override  object[] toArray()
        {
            return _list.ToArray();
        }

		public override Maybe indexWhere(Pred pred)
        {
            var result = _list.FindIndex(x => pred.apply(x));
            return findResult(result, -1);
        }

		public override Maybe lastIndexWhere(Pred pred)
        {
            var result = _list.FindLastIndex(x => pred.apply(x));
            return findResult(result, -1);
        }

		public override int countWhere(Pred pred)
        {
            return _list.Count(x => pred.apply(x));
        }

        // ---------------- Showable ---------------------

        public string show()
        {
            return DefShow.showBySequence(this, _list);
        }
    }
}

