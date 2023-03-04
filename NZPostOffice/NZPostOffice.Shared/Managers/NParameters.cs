using System;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.Shared.Managers
{
    public class NParameters
    {
        public string stringparm = String.Empty;

        public int? longparm;

        public int? integerparm;

        public int? intparm;

        public DateTime? dateparm = DateTime.MinValue;

        public object anyparm;

        public double? doubleparm;

        public bool booleanparm;

        public Metex.Windows.DataUserControl dwparm;

        public bool? printedonparm;

        public int? regionparm;

        public int? outletparm;

        public string contractorparm = String.Empty;

        public int? contracttypeparm;

        public int? renewalgroupparm;

        public string miscstringparm = String.Empty;

        public Metex.Windows.DataUserControl miscdwparm;

        public Metex.Windows.DataUserControl resultdwparm;          //added by ygu

        public FormBase windowparm;

        public int? privacyparm;

        public DateTime? dateparm2 = DateTime.MinValue;

        public int? regionIdPram;

        public int? outletIdParm;

        public DateTime? monthyearParm = DateTime.MinValue;

        public NParameters()
        {
        }

        public virtual int of_set_booleanparm(bool ab_Parm)
        {
            booleanparm = ab_Parm;
            return 1;
        }

        public virtual string of_get_stringparm()
        {
            return stringparm;
        }
    }
}
