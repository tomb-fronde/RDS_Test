using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.RDS.Controls
{
    // TJB  Frequencies & Vehicles 7-Feb-2021: NEW
    // Used to pass info that the route_frequency table has been updated
    // from the WRenewal2001 form to the WContract2001 form so the 
    // Frequencies tab can tell that it should refresh itself.
    // See 
    // https://www.dreamincode.net/forums/topic/206458-the-right-way-to-get-values-from-form1-to-form2/
    
    public class StatusUpdatedEventArgs : EventArgs
    {
        private bool? _rf_updated;

        public virtual bool? RfUpdated
        {
            get
            {
                return _rf_updated;
            }
            set
            {
                if (_rf_updated != value)
                {
                    _rf_updated = value;
                }
            }
        }
    }
}
