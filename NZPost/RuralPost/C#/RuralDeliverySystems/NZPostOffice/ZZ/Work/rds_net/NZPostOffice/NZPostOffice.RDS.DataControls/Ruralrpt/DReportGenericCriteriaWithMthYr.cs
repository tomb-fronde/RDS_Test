using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DReportGenericCriteriaWithMthYr : Metex.Windows.DataUserControl
	{
        // TJB  RPCR_057  Jan-2014: NEW
        // Created from DReportGenericCriteriaWithMonth
        //
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

		public DReportGenericCriteriaWithMthYr()
		{
			InitializeComponent();
			//!InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }

            base.OnHandleCreated(e);
        }

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			sf_key.AssignDropdownType<DDddwStandardFrequency>();
			region_id.AssignDropdownType<DDddwRegions>();
			region_id_ro.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

        public event EventHandler TextBoxLostFocus;

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }
/*
		public override int Retrieve( )
        {
            return RetrieveCore<ReportGenericCriteriaWithMthYr>(new List<ReportGenericCriteriaWithMonth>(ReportGenericCriteriaWithMthYr.GetAllReportGenericCriteriaWithMthYr()));
		}
*/
	}
}
