using System;
using System.Reflection;

namespace Clunker
{
    class OnObject : AbstractApplicable
    {
        private object _obj;
        private MethodInfo _method;

        public OnObject(object obj, string method) {
            Type objType = obj.GetType();
            _method = objType.GetMethod(method);
            _obj = obj;
        }

        public override object applyOnArray(object[] args) {
            return _method.Invoke(_obj, args);
        }
    }
}

