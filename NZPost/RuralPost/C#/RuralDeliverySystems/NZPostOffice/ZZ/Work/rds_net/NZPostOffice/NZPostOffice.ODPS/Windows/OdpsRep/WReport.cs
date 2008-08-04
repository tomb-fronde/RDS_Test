using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Menus;

namespace NZPostOffice.ODPS.Windows.OdpsRep
{
    public partial class WReport : WMaster
    {
        #region Define
        private const string DEFAULT_ASSEMBLY = "NZPostOffice.ODPS.DataControls";
        private const string DEFAULT_VERSION = "1.0.0.0";

        private MOdpsReport m_odps_report;

        #endregion

        public WReport()
        {
            m_odps_report = new MOdpsReport(this);
            this.InitializeComponent();
        }

        public virtual void pfc_pagesetup()
        {
            //? return dw_report.pfc_pagesetup();
        }

        public virtual void pfc_printimmediate()
        {
            //? return dw_report.Print();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // m_odps_report m_menu
            // m_menu=menuid
            // if isvalid ( m_menu) then
            // 	if f_hqaccess ( )  then
            // 		m_menu.m_reports.m_post-taxadjustment.visible=true
            // 		m_menu.m_reports.m_volumesvalues.visible=true
            // 	else
            // 		m_menu.m_reports.m_post-taxadjustments2.visible=true
            // 		m_menu.m_reports.m_volumesvalues2.visible=true
            // 	end if
            // end if
            // 
            object any_var = null;
            bool bnational;
            DateTime sdate;
            DateTime edate;
            DateTime? fsdate;
            DateTime? fedate;
            string s_datawindow_object;
            int lregion;
            string ctype;
            bool rc;
            // 	start the resize service
            //? this.of_setresize(true);

            //gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "DatawindowObject", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "DatawindowObject", ref any_var, "Y");
            s_datawindow_object = Convert.ToString(any_var);

            // gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "StartDate", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "StartDate", ref any_var, "Y");
      
            sdate = System.Convert.ToDateTime(any_var.ToString());

            //gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "EndDate", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "EndDate", ref any_var, "Y");
            edate = System.Convert.ToDateTime(any_var.ToString());

            //gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "FinStartDate", any_var);
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "FinStartDate", ref any_var, "Y");
            if ((any_var.ToString() != "") && (any_var != null))
            {
                fsdate = System.Convert.ToDateTime(any_var.ToString());
            }
            else
            {
                fsdate = null;
            }

            // gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "FinEndDate", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "FinEndDate", ref any_var, "Y");
            if ((any_var.ToString() != "") && (any_var != null))
            {
                fedate = System.Convert.ToDateTime(any_var.ToString());
            }
            else
            {
                fedate = null;
            }

            // gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "Title", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "Title", ref any_var, "Y");
            this.Text = any_var.ToString();

            //  'National' isn't used but is here to stop a potential memory overflow

            // gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "National", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "National", ref any_var, "Y");

            // gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "Region", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "Region", ref any_var, "Y");
            lregion = Convert.ToInt32(any_var);

            //  TJB SR4638  10-Nov-2004
            //  ctype may contain a list of contract type keys
            //  Only the payment summary sets a ctype value.  Need to check 
            //  whether one was found when other reports requested.
            //rc = gnv_app.inv_ObjectMsg.of_GetMsg("w_report", "Ctype", any_var, 'Y');
            rc = StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_report", "Ctype", ref any_var, "Y");
            if (rc)
            {
                ctype = Convert.ToString(any_var);
            }
            else
            {
                ctype = "";
            }
            // dw_report.dataobject = s_datawindow_object;
            dw_report.SetDataObject(DEFAULT_ASSEMBLY, DEFAULT_VERSION, StaticFunctions.migrateName(s_datawindow_object));

            //  retrieve the report
            Cursor.Current = Cursors.WaitCursor;
            //? SetMicroHelp("Retrieving Report .  .  .");
            //  TJB SR4638
            //  If contract types were specified, run the payment summary
            //  report with the ctype list as a parameter.


            if (lregion == -(1))
            {
                if (ctype.Length > 0)
                {
                    dw_report.Retrieve(new object[] { sdate, edate, lregion, ctype });
                }
                else if (fsdate == null || fsdate <= System.Convert.ToDateTime("1900-01-01"))
                {
                    dw_report.Retrieve(new object[] { sdate, edate });
                }
                else
                {
                    dw_report.Retrieve(new object[] { sdate, edate, fsdate, fedate });
                }
            }
            else if (ctype.Length > 0)
            {
                dw_report.Retrieve(new object[] { sdate, edate, lregion, ctype });
            }
            else if (fsdate == null || fsdate <= System.Convert.ToDateTime("1900-01-01"))
            {
                if (dw_report.DataObject.ToString().Substring(dw_report.DataObject.ToString().LastIndexOf(".") + 1) == "DwAuditLogAddresschange")
                {
                    dw_report.Retrieve(new object[] { sdate, edate });
                }
                else
                {
                    dw_report.Retrieve(new object[] { sdate, edate, lregion });
                }
            }
            else
            {
                dw_report.Retrieve(new object[] { sdate, edate, fsdate, fedate, lregion });
            }

            dw_report.Focus();

            /*? SetMicroHelp("Ready");
            if (bnational && g_security.access_groups[7] == -(1))
            {
               this.Close();
            }*/
        }

        public virtual void constructor()
        {
            //? dw_report.of_setreport(true);
            //? dw_report.of_setprintpreview(true);
        }

        //?public virtual void pfc_zoom()
        //{
        //     // 
        //     int b_parentret;
        //    // triggerevent ( "pfc_printpreview")
        //    if (!(inv_printpreview.of_GetEnabled()))
        //    {
        //        inv_printpreview.of_SetEnabled(true);
        //    }
        //    b_parentret = base.dw_report_pfc_zoom();
        //    return b_parentret;
        //}
    }
}
