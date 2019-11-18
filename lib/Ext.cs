using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib
{
    public static class Ext
    {
        public static int ToInt(this object value)
        {
            int result = 0;
            bool ok = int.TryParse(value.ToString(), out result);
            return result;
        }
        public static bool ToBool(this object value)
        {
            bool result = false;
            bool ok = bool.TryParse(value.ToString(), out result);
            if (!ok)
            {
                if (value.ToString() == "1")
                    result = true;
                else
                    result = false;
            }
            return result;
        }
    }
}
