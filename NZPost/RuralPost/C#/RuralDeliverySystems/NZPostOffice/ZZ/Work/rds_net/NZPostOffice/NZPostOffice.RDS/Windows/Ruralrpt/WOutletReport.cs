using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WOutletReport : WGenericReportPreview
    {
        #region Define
        public int il_region_Id;

        public  WOutletReportSearch w_outlet_report_search = null;
        #endregion

        public WOutletReport()
        {
            InitializeComponent();
            this.Load += new EventHandler(WOutletReport_Load);
            this.Activated += new EventHandler(WOutletReport_Activated);
        }

        public virtual string wf_getregionname(int? inregionid)
        {
            string ls_temp;
            int sqlCode = -1;
            string sqlErrText = string.Empty;

            // get region description
            if (inregionid == null || inregionid == 0)
            {
                ls_temp = "All Regions";
            }
            else
            {
                // SELECT rgn_name  INTO :ls_temp  FROM region  WHERE region_id = :inRegionId;
                ls_temp = RDSDataService.GetRegionValue(inregionid, ref sqlCode, ref sqlErrText);
                ls_temp = ls_temp + " Region";
            }
            return ls_temp;
        }

        #region Events
        public void WOutletReport_Load(object sender, EventArgs args)
        {
            base.open();
            int? ll_regionId;
            string ls_rgnName;
            DataUserControl dwDetail;

            Cursor.Current = Cursors.WaitCursor;
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            ll_regionId = w_outlet_report_search.dw_criteria.GetItem<OutletReportCriteria>(0).Regionid;
            if (ll_regionId == null)
            {
                ll_regionId = 0;
            }
            ls_rgnName = wf_getregionname(ll_regionId);
            //  dw_report.Modify ( "stParms.text='"+gnv_App.of_Get_Parameters ( ).miscstringparm+"'")
            dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";
            ((ROutletBaseOfficeReport)dw_report.DataObject).Retrieve(ll_regionId);
        }

        public void WOutletReport_Activated(object sender, EventArgs e)
        {
            base.activate();
            if (m_sheet != null)
            {
                //m_sheet._m_contractors.Visible = false;
                //m_sheet._m_contracts.Visible = false;
                //m_sheet._m_addresses.Visible = false;
            }
        }
        #endregion
    }
}