using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustomerUnconfirmedReportSearch : WCustomerCountReportSearch
    {
        public WCustomerUnconfirmedReportSearch()
        {
            InitializeComponent();
        }

        public override int wf_gosearch()
        {
            int? loutlet;
            int? lregion;
            int? lcontract;
            dw_criteria.AcceptText();
            lregion = dw_criteria.GetItem<ReportGenericRegOutletContcriteria>(0).RegionId;
            loutlet = dw_criteria.GetItem<ReportGenericRegOutletContcriteria>(0).OutletId;
            lcontract = dw_criteria.GetItem<ReportGenericRegOutletContcriteria>(0).ContractNo;
            if (lcontract > 0)
            {
                lregion = 0;
                loutlet = 0;
            }
            if (loutlet == null)
            {
                loutlet = 0;
            }
            if (lregion == null)
            {
                lregion = 0;
            }
            if (lcontract == null)
            {
                lcontract = 0;
            }
            ((DReportRegionoutletcontractResults)dw_results.DataObject).Retrieve(lregion, loutlet, lcontract);
            if (dw_results.RowCount == 0)
            {
                MessageBox.Show("Search Unsuccessful", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return 1;
        }

        public virtual void dw_results_ue_setuprow()
        {
            if (dw_results.RowCount == 1)
            {
                dw_results.DeleteItemAt(0);
            }
        }

        public override void dw_results_constructor()
        {
            //? base.constructor();
            dw_results.of_SetStyle(0);// inv_rowselect.of_SetStyle(0);
        }

        public virtual void pb_open_clicked()
        {
            Cursor.Current = Cursors.WaitCursor;
            string sTitle;
            dw_criteria.AcceptText();
            if (dw_results.RowCount == 0)
            {
                return;
            }
            //!if (dw_results.GetSelectedRow(0) == 0)
            if (dw_results.GetSelectedRow(0) < 0)
            {
                return;
            }
            StaticVariables.gnv_app.of_get_parameters().regionparm = Convert.ToInt32(dw_criteria.GetItem<ReportGenericRegOutletContcriteria>(0).RegionId);
            StaticVariables.gnv_app.of_get_parameters().outletparm = Convert.ToInt32(dw_criteria.GetItem<ReportGenericRegOutletContcriteria>(0).OutletId);
            StaticVariables.gnv_app.of_get_parameters().longparm = Convert.ToInt32(dw_results.GetItem<ReportGenericRegOutletContcriteria>(dw_results.GetSelectedRow(0)).ContractNo);
            if (StaticVariables.gnv_app.of_get_parameters().longparm == 0)
            {
                int? ll;
                ll = dw_criteria.GetItem<ReportGenericRegOutletContcriteria>(0).ContractNo;
                if (ll > 0)
                {
                    StaticVariables.gnv_app.of_get_parameters().longparm = Convert.ToInt32(ll);
                }
            }
            StaticVariables.gnv_app.of_get_parameters().dateparm = Convert.ToDateTime(dw_criteria.GetItem<ReportGenericRegOutletContcriteria>(0).DateCommenced);
            if (StaticVariables.gnv_app.of_get_parameters().dateparm != null)
            {
                //if (MessageBox.Show(this.Text, "You have specified a date criteria.SEARCH WILL BE VERY SLOW.\r\nDo you want to co" +
                //   "ntinue?", question!, yesno 2) == 2) {
                if (MessageBox.Show(this.Text + "You have specified a date criteria.SEARCH WILL BE VERY SLOW.\r\nDo you want to co" + "ntinue?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().regionparm))
            {
                StaticVariables.gnv_app.of_get_parameters().regionparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().outletparm))
            {
                StaticVariables.gnv_app.of_get_parameters().outletparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().longparm))
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            }
            Cursor.Current = Cursors.WaitCursor;
            // gnv_App.of_Get_Parameters ( ).MiscStringParm = wf_getparms ( )
            //OpenSheetWithParm(w_customer_unconfirmed_report, parent, w_main_mdi, 0, original);
            StaticMessage.PowerObjectParm = this;
            OpenSheet<WCustomerUnconfirmedReport>(StaticVariables.MainMDI);
        }
    }
}
