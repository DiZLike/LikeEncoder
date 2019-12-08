using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib
{
    public struct Values
    {
        private Dictionary<object, object> _params;

        public object this[string key]
        {
            get
            {
                if (_params == null)
                    _params = new Dictionary<object, object>();
                if (_params.ContainsKey(key))
                    return _params[key];
                else
                    return new object();
            }
            set
            {
                if (_params == null)
                    _params = new Dictionary<object, object>();
                if (_params.ContainsKey(key))
                    _params[key] = value;
                else
                    _params.Add(key, value);
            }
        }



    }
}
