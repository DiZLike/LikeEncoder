using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tagslib
{
    public class ParamArray
    {
        private Dictionary<object, object> _params = new Dictionary<object, object>();

        public object this[string key]
        {
            get
            {
                if (_params.ContainsKey(key))
                    return _params[key];
                else
                    return new object();
            }
            set
            {
                if (_params.ContainsKey(key))
                    _params[key] = value;
                else
                    _params.Add(key, value);
            }
        }

        public ParamArray()
        {

        }



    }
}
