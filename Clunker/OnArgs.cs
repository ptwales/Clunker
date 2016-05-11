using System;
using System.Reflection;

namespace Clunker
{
    class OnArgs : AbstractApplicable
    {
        private object _obj;
        private MethodInfo _method;

        public OnArgs(object obj, string method) {
            Type objType = obj.GetType();
            _method = objType.GetMethod(method);
            _obj = obj;
        }

        public override object applyOnArray(object[] args) {
            return _method.Invoke(_obj, args);
        }
    }

    class OnObject : AbstractApplicable 
    {
        private object[] _args;
        private string _method;

        public OnObject(string method, object[] args) {
            _args = args;
            _method = method;
        }

        public override object applyOnArray(object[] args) {
            // TODO: assert args is size 1;
            var obj = args[0];
            Type objType = obj.GetType();
            MethodInfo method = objType.GetMethod(_method);
            return method.Invoke(obj, _args);
        }

    }
}

