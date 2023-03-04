using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RDetailedCustomerListing : Metex.Windows.DataUserControl
	{
		public RDetailedCustomerListing()
		{
			InitializeComponent();
		}

		public override int Retrieve()
        {
            return RetrieveCore<DetailedCustomerListing>(new List<DetailedCustomerListing>(DetailedCustomerListing.GetAllDetailedCustomerListing()));
		}

        public CrystalDecisions.CrystalReports.Engine.ReportClass ReportDocument
        {
            get { return this.report; }
        }
        public void RefreshReport()
        {
            this.viewer.RefreshReport();
        }
	}
}
