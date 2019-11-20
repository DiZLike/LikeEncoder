using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tagslib
{
    public class ParamArray
    {
        private Dictionary<string, string> _params = new Dictionary<string, string>();

        public string this[string key]
        {
            get
            {
                if (_params.ContainsKey(key))
                    return _params[key];
                else
                    return String.Empty;
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
