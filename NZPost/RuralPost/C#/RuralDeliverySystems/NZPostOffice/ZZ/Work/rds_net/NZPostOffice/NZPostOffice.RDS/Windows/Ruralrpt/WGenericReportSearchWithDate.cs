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
    public partial class WGenericReportSearchWithDate : WGenericReportSearch
    {
        public WGenericReportSearchWithDate()
        {
            InitializeComponent();

            this.dw_criteria.DataObject = new DReportGenericCriteriaWithMonth();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            //jlwang
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            //jlwang:end
            ((DReportGenericCriteriaWithMonth)dw_criteria.DataObject).TextBoxLostFocus += new System.EventHandler(dw_criteria_ItemChange);
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).GotFocus += new EventHandler(dw_criteria_GotFocus);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            DateTime dDate = DateTime.MaxValue;
            dDate = DateTime.Today.AddDays(0 - DateTime.Today.Day);//StaticMethods.RelativeDate(Today(), 0 - Day(Today()));
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).Enabled = false;
            //?dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).Monthyear = dDate;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            StaticVariables.gnv_app.of_get_parameters().dateparm = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).Monthyear;
            string sTitle;
            dw_criteria.AcceptText();
            if (dw_results.GetSelectedRow(0) > 0)
            {
                sTitle = dw_criteria.GetControlByName("st_report").Text;
                StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
                //StaticVariables.gnv_app.of_get_parameters().dwparm = dw_results.DataObject;
                StaticVariables.window = dw_results;
                //add by mkwang
                string date;
                DateTime? dt_edate;
                date = ((System.Windows.Forms.TextBox)dw_criteria.GetControlByName("monthyear1")).Text;
                if (date != "")
                {
                    dt_edate = System.Convert.ToDateTime(("01" + "," + date.Substring(0, 2) + "," + "20" + date.Substring(3, 2)));
                    StaticVariables.gnv_app.of_get_parameters().monthyearParm = dt_edate;
                }
                else
                {
                    StaticVariables.gnv_app.of_get_parameters().monthyearParm = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).Monthyear;
                }
                Cursor.Current = Cursors.WaitCursor;
                //OpenSheetWithParm(w_generic_report_preview_with_date, sTitle, w_main_mdi, 0, original);
                StaticMessage.PowerObjectParm = sTitle;
                WGenericReportPreviewWithDate w_generic_report_preview_with_date = new WGenericReportPreviewWithDate();
                w_generic_report_preview_with_date.MdiParent = StaticVariables.MainMDI;
                w_generic_report_preview_with_date.Show();
            }
        }

        public virtual void dw_criteria_ItemChange(object sender, EventArgs e)
        {
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).Text = dw_criteria.GetControlByName("monthyear").Text;
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).BringToFront();
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).Enabled = true;
        }

        void dw_criteria_GotFocus(object sender, EventArgs e)
        {
            ((MaskedTextBox)dw_criteria.GetControlByName("monthyear")).BringToFront();
            dw_criteria.GetControlByName("monthyear").Text = ((System.Windows.Forms.TextBox)dw_criteria.GetControlByName("monthyear1")).Text;
            ((MaskedTextBox)dw_criteria.GetControlByName("monthyear")).Focus();
        }
    }
}