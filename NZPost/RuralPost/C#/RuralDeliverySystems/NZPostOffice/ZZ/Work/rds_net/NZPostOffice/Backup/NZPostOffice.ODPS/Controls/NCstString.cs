using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.ODPS.Controls
{
    public class NCstString
    {
        public string of_gettoken(ref string as_source, string as_separator)
        {
            int li_pos;
            string ls_ret;

            if (as_source == null || as_separator == null)
            {
                return null;
            }
            li_pos = as_source.IndexOf(as_separator);
            if (li_pos == -1)
            {
                ls_ret = as_source;
                as_source = "";
            }
            else
            {
                ls_ret = as_source.Substring(0, li_pos );//- 1);
                as_source = as_source.Substring(li_pos + as_separator.Length);//as_source.Length - (li_pos + as_separator.Length ));//- 1));
            }
            return ls_ret;
        }
    }
}
