using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralrpt;


namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WOutletReportSearch : WGenericReportSearch
    {
        public WOutletReportSearch()
        {
            InitializeComponent();

            dw_criteria.DataObject = new DOutletReportCriteria();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            
            dw_results.DataObject = new DReportGenericResults();
            //_menu.SetFunctionalPart();
            //_toolbar.SetFunctionalPart();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB  SR4647  ( part 2)  June 2005  - New
            DataUserControl dwChild;
            dw_criteria.AcceptText();
            dwChild = dw_criteria.GetChild("region_id");//, dwChild);
            if (dwChild != null)
                dwChild.Reset();
        }

        public virtual string wf_getparms()
        {
            string ls_Parm;
            string ls_Temp = string.Empty;
            int? ll_regionId;
            int ll_rgCode;
            int ll_ctKey;
            int sqlCode = -1;
            string sqlErrText = string.Empty;

            ll_regionId = dw_criteria.GetItem<OutletReportCriteria>(0).Regionid;
            // get region description
            if (ll_regionId == null)
            {
                ls_Parm = "All Regions";
            }
            else
            {
                //SELECT rgn_name  INTO :ls_Temp  FROM region  WHERE region_id = :ll_regionId;
                ls_Temp = RDSDataService.GetRegionValue(ll_regionId, ref sqlCode, ref sqlErrText);
                ls_Parm = ls_Temp + " Region";
            }
            return ls_Parm;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            //w_outlet_report wNewReport;
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
            OpenSheet<WOutletReport>(StaticVariables.MainMDI);//OpenSheet(wNewReport, w_main_mdi, 0, original!);
        }
    }
}