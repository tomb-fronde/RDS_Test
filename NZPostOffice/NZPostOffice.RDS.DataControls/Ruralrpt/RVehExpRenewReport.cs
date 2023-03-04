using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using CrystalDecisions.CrystalReports.Engine;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RVehExpRenewReport : Metex.Windows.DataUserControl
	{
        //! two controctors to show different reports with identical data fileds within one data window
		public RVehExpRenewReport()
		{
            this.reRVehExpRenewReport = new NZPostOffice.RDS.DataControls.Report.RERVehExpRenewReport();
			InitializeComponent();
		}

        public RVehExpRenewReport(bool expiryRecords)
        {
            this.reRVehExpRenewReport = new NZPostOffice.RDS.DataControls.Report.RERVehExpRegReport();
            InitializeComponent();
        }

        public CrystalDecisions.CrystalReports.Engine.ReportClass ReRVehExpRenewReport
        {
            get
            {
                return reRVehExpRenewReport;
            }
        }

        public void ChangeHeaderText(string ls_header)
        { 
            TextObject text = ((ReportDocument)reRVehExpRenewReport).ReportDefinition.ReportObjects["st_header_text"] as TextObject;

            if (text != null)
            {
                text.Text = ls_header;
            }
        }

        public int Retrieve(int? renew_id, bool expiryRecords)
        {
            if (!expiryRecords)
            {
                return RetrieveCore<VehExpRenewReport>(new List<VehExpRenewReport>(VehExpRenewReport.GetAllVehExpRenewReport(renew_id)));
            }
            else
            {
                return RetrieveCore<VehExpRenewReport>(new List<VehExpRenewReport>(VehExpRenewReport.GetAllVehExpiryReport(renew_id)));
            }
		}
        
	}
}
