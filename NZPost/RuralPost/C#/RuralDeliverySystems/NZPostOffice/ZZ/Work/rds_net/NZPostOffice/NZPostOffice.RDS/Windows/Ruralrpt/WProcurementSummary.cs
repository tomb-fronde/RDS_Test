using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WProcurementSummary : WGenericReportPreview
    {
        public WProcurementSummary()
        {
            InitializeComponent();
        }

        public override  void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB  SR4672  January 2006  - New
            //  See also 
            //      w_procurement_select
            //      w_procurement_detail, r_contractor_procurement_detail
            dw_report.DataObject.Reset();
            ((RContractorProcurementSummary)dw_report.DataObject).Retrieve();
            dw_report.DataObject.ResumeLayout(false);
        }
    }
}