using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WProcurementSelect : WAncestorWindow
    {
        public WProcurementSelect()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB  SR4672  January 2006  - New
            //  See also 
            //      w_procurement_summary, r_contractor_procurement_summary
            //      w_procurement_detail,  r_contractor_procurement_detail
            this.of_set_componentname(this.Tag ==null ?"":this.Tag.ToString());
            cb_summary.Focus();
        }

        #region Events
        public virtual void cb_detail_clicked(object sender, EventArgs e)
        {
            //WProcurementDetail wNewReport;
            OpenSheet<WProcurementDetail>(StaticVariables.MainMDI);//OpenSheet(wNewReport, w_main_mdi, 0, original!);
        }

        public virtual void cb_summary_clicked(object sender, EventArgs e)
        {
            // WProcurementSummary wNewReport;
            OpenSheet<WProcurementSummary>(StaticVariables.MainMDI);//OpenSheet(wNewReport, w_main_mdi, 0, original!);
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}