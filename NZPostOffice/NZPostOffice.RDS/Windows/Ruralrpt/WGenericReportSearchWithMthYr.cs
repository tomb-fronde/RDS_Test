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


namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    // TJB  RPCR_057  Jan-2014: Bug fixes
    // Check date in pb_search_clicked
    // Fix not allowing first row to be selected
    //
    // TJB  RPCR_057  Jan-2014:  NEW
    // Variation on WGenericReportSearchWithDate for ScheduleB reports
    // Change date from dd/mm to mm/yy and from datetime to text
    // Added 'select a contract' warning (in pb_open_clicked)
    // Added bAllowAll parameter in wf_gosearch

    public partial class WGenericReportSearchWithMthYr : WGenericReportSearch
    {
        public WGenericReportSearchWithMthYr()
        {
            InitializeComponent();

            this.dw_criteria.DataObject = new DReportGenericCriteriaWithMthYr();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
//            ((DReportGenericCriteriaWithMthYr)dw_criteria.DataObject).TextBoxLostFocus += new System.EventHandler(dw_criteria_ItemChange);
            ((TextBox)dw_criteria.GetControlByName("mth_yr1")).GotFocus += new EventHandler(dw_criteria_GotFocus);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            DateTime dDate = DateTime.MaxValue;
            dDate = DateTime.Today.AddDays(0 - DateTime.Today.Day);//StaticMethods.RelativeDate(Today(), 0 - Day(Today()));
            ((TextBox)dw_criteria.GetControlByName("mth_yr1")).Enabled = false;
            //?dw_criteria.GetItem<ReportGenericCriteriaWithMthYr>(0).mth_yr = dDate;
        }

        // TJB  RPCR_057  Jan-2014: NEW
        // Moved from pb_open_clicked and added calls in pb_search_clicked and pb_open_clicked
        private DateTime? checkdate()
        {
            DateTime? ReportDate;
            string sReportMthYr, sReportDay, sReportMth, sReportYr;
            int nReportMth = 1, nReportYr = 14;
            bool bDateOK;

            sReportDay = "01";
            sReportMthYr = dw_criteria.GetItem<ReportGenericCriteriaWithMthYr>(0).MthYr;
            if (sReportMthYr == null || sReportMthYr == "00/00")
            {
                sReportMthYr = DateTime.Today.Month.ToString("D2") + "/" + (DateTime.Today.Year - 2000).ToString("D2");
            }
            sReportMth = sReportMthYr.Substring(0, 2);
            sReportYr = sReportMthYr.Substring(3, 2);
            bDateOK = true;
            try
            {
                nReportMth = Convert.ToInt32(sReportMth);
                nReportYr = Convert.ToInt32(sReportYr);
            }
            catch (FormatException)
            {
                bDateOK = false;
            }
            if (nReportMth < 0 || nReportMth > 12)
            {
                bDateOK = false;
            }
            if (bDateOK == false)
            {
                MessageBox.Show("Invalid date \n"
                               + "\n"
                               + "Please enter a date in month/year (mm/yy) format."
                               , "Error");
                return null;
            }

            sReportYr = "20" + sReportMthYr.Substring(3, 2);
            ReportDate = Convert.ToDateTime(sReportDay + "/" + sReportMth + "/" + sReportYr);
            //            ReportDate = Convert.ToDateTime("01/"+sReportDate.Substring(0, 2) + "/20" + sReportDate.Substring(3, 2));

            return ReportDate;
        }

        // TJB  RPCR_057  Jan-2014
        // Added call to checkdate()
        public override void pb_search_clicked(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (checkdate() == null) return;

            wf_gosearch(false);
        }

        // TJB  RPCR_057  Jan-2014
        // Moved date check to checkdate() replaced with call to it
        // Bug fix: use selectedrow >= 0 - was not allowing first row
        public override void pb_open_clicked(object sender, EventArgs e)
        {
            // StaticVariables.gnv_app.of_get_parameters().dateparm = dw_criteria.GetItem<ReportGenericCriteriaWithMthYr>(0).mth_yr;
            DateTime? ReportDate;
            ReportDate = checkdate();
            if (ReportDate == null) return;
            StaticVariables.gnv_app.of_get_parameters().dateparm = ReportDate;
            string sTitle;
            dw_criteria.AcceptText();
            int nRow = dw_results.GetSelectedRow(0);
            if (nRow >= 0)  // TJB RPCR_057 27-Jan-2014: bug fix: added "="
            {
                sTitle = dw_criteria.GetControlByName("st_report").Text;
                StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
                //StaticVariables.gnv_app.of_get_parameters().dwparm = dw_results.DataObject;
                StaticVariables.window = dw_results;
                //add by mkwang
                string date;
                DateTime? dt_edate;
                date = ((System.Windows.Forms.TextBox)dw_criteria.GetControlByName("mth_yr1")).Text;
                if (date != "")
                {
                    dt_edate = System.Convert.ToDateTime(("01" + "," + date.Substring(0, 2) + "," + "20" + date.Substring(3, 2)));
                    StaticVariables.gnv_app.of_get_parameters().monthyearParm = dt_edate;
                }
                else
                {
                    //StaticVariables.gnv_app.of_get_parameters().monthyearParm = dw_criteria.GetItem<ReportGenericCriteriaWithMthYr>(0).MthYr;
                    string sDMY;
                    DateTime? dDMY;
                    sDMY = dw_criteria.GetItem<ReportGenericCriteriaWithMthYr>(0).MthYr;
                    if (sDMY == null || sDMY == "00/00")
                        sDMY = "01/" + DateTime.Today.Month.ToString("D2") + "/" + DateTime.Today.Year.ToString("D2");
                    else
                        sDMY = "01/" + sDMY.Substring(0, 2) + "/20" + sDMY.Substring(3, 2);
                    dDMY = Convert.ToDateTime(sDMY);
                    StaticVariables.gnv_app.of_get_parameters().monthyearParm = dDMY;
                }
                Cursor.Current = Cursors.WaitCursor;
                //OpenSheetWithParm(w_generic_report_preview_with_date, sTitle, w_main_mdi, 0, original);
                StaticMessage.PowerObjectParm = sTitle;
                WGenericReportPreviewWithMthYr w_generic_report_preview_with_mthyr = new WGenericReportPreviewWithMthYr();
                w_generic_report_preview_with_mthyr.MdiParent = StaticVariables.MainMDI;
                w_generic_report_preview_with_mthyr.Show();
            }
            else
            {
                MessageBox.Show("Please select a contract", "Warning");
            }
        }

        public virtual void dw_criteria_ItemChange(object sender, EventArgs e)
        {
            ((TextBox)dw_criteria.GetControlByName("mth_yr1")).Text = dw_criteria.GetControlByName("mth_yr").Text;
            ((TextBox)dw_criteria.GetControlByName("mth_yr1")).BringToFront();
            ((TextBox)dw_criteria.GetControlByName("mth_yr1")).Enabled = true;
        }

        void dw_criteria_GotFocus(object sender, EventArgs e)
        {
            ((MaskedTextBox)dw_criteria.GetControlByName("mth_yr")).BringToFront();
            dw_criteria.GetControlByName("mth_yr").Text = ((System.Windows.Forms.TextBox)dw_criteria.GetControlByName("mth_yr1")).Text;
            ((MaskedTextBox)dw_criteria.GetControlByName("mth_yr")).Focus();
        }
    }
}