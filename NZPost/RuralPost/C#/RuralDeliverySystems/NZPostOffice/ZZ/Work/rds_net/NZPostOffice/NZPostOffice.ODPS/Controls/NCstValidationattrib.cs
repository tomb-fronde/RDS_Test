using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Controls
{
    public class NCstValidationattrib
    {
        public URdsDw idw_WithError;

        public int ii_ErrorColumn;

        public int ii_SeverityLevel;

        //public IntArray il_ErrorRow = new IntArray();
        public List<int> il_ErrorRow = new List<int>();

        //public StringArray is_ErrorMsg = new StringArray();
        public List<string> is_ErrorMsg = new List<string>();

        public FormBase iw_Parent;

        public NCstValidationattrib()
        {
        }
    }
}
