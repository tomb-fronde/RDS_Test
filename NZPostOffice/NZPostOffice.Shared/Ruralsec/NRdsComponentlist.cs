using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Entity;
using NZPostOffice.DataControls;

namespace NZPostOffice.Shared.Ruralsec
{
    public class NRdsComponentlist : Metex.Windows.DataUserControlContainer
    {

        public NRdsComponentlist()
        {
            constructor();
        }

        public virtual void constructor()
        {
            this.DataObject = new DComponentlist();// "d_componentlist";
            ((DComponentlist)(this.DataObject)).Retrieve();
        }

        public virtual int of_get_componentid(string as_componentname)
        {
            int ll_Ctr;
            int ll_Row;
            int ll_Id;
            if (as_componentname.Length == 0 || as_componentname == null)
            {
                return 0;
            }
            for (ll_Ctr = 1; ll_Ctr <= this.RowCount; ll_Ctr++)
            {
                ll_Row = this.DataObject.Find(true, new KeyValuePair<string, object>("name", as_componentname));//this.Find( "Upper ( name)=Upper ( \'" + as_componentname + +("\')") ).Length);
                if (ll_Row > -1)
                {
                    ll_Id = this.DataObject.GetItem<Componentlist>(ll_Row).Id.GetValueOrDefault(); //this.Object.id[ll_Row];
                    return ll_Id;
                }
            }
            return 0;
        }
    }

}
