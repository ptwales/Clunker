﻿using System;

namespace Clunker
{
	delegate object Splat(object[] args);

    class InternalDelegate : AbstractFunc
    {
		Splat _splat;

		public InternalDelegate(Splat splat)
        {
			_splat = splat;
        }

		public override object applyOnArray(object[] args)
		{
			return _splat(args);
		}
    }
}

