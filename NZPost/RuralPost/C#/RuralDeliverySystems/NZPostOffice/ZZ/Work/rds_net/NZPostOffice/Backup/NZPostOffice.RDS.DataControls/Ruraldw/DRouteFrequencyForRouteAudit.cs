using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DRouteFrequencyForRouteAudit : Metex.Windows.DataUserControl
	{
		public DRouteFrequencyForRouteAudit()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!this.DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }


		private void InitializeDropdown()
		{
			sf_key.AssignDropdownType<DddwStandardFrequency>();
		}

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<RouteFrequencyForRouteAudit>(new List<RouteFrequencyForRouteAudit>
				(RouteFrequencyForRouteAudit.GetAllRouteFrequencyForRouteAudit(in_Contract )), null, 
                new Predicate<RouteFrequencyForRouteAudit>(this.DefaultFilter));
        }

        private bool DefaultFilter(RouteFrequencyForRouteAudit e)
        {
            //  rf_active = 'Y'
            return e.RfActive == "Y";
        }
	}
}
