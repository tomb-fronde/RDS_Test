using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WRouteFrequencyReportSearch : WGenericReportSearch
    {
        public WRouteFrequencyReportSearch()
        {
            InitializeComponent();
            dw_criteria.DataObject = new DReportGenericCriteria();
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_results.DataObject = new DReportGenericResults();
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            ((DReportGenericResults)dw_results.DataObject).DoubleClick += new EventHandler(this.dw_results_doubleclicked);
            //jlwang:end
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
            if (StaticVariables.gnv_app.of_get_parameters().stringparm == "r_mail_carried_single_contract")
            {
                cbx_printkms.Visible = false;
                dw_criteria.Height = dw_criteria.Height - cbx_printkms.Height;
                dw_results.Height = dw_results.Height + cbx_printkms.Height;
                dw_results.Top = dw_results.Top - cbx_printkms.Height;
            }
            //dw_criteria.SetValue(0, "ceffectivedate", System.DateTime.Today);// Today());
            dw_criteria.AcceptText();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            if (StaticVariables.gnv_app.of_get_parameters().stringparm != "r_mail_carried_single_contract")
            {
                cbx_printkms.Visible = true;
                cbx_printkms.BringToFront();
            }
        }

        #region Events
        public override void pb_open_clicked(object sender, EventArgs e)
        {
            StaticVariables.gnv_app.of_get_parameters().dateparm = dw_criteria.GetItem<ReportGenericCriteria>(0).Ceffectivedate;
            //?base.clicked();
            string sTitle;
            WGenericReportPreview wNewWindow;
            Form lw_FindWindow;
            if (dw_results.GetSelectedRow(0) >= 0)
            {

                sTitle = dw_criteria.GetControlByName("st_report").Text;
                StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
                //StaticVariables.gnv_app.of_get_parameters().dwparm = dw_results.DataObject;
                StaticVariables.window = dw_results;
                Cursor.Current = Cursors.WaitCursor;
                // OpenSheetWithParm(wNewWindow, sTitle, w_main_mdi, 0, original);
                StaticMessage.PowerObjectParm = sTitle;
                wNewWindow = new WGenericReportPreview();
                wNewWindow.MdiParent = StaticVariables.MainMDI;
                wNewWindow.Show();
            }
        }

        public virtual void cbx_printkms_clicked(object sender, EventArgs e)
        {
            if (cbx_printkms.Checked)
            {
                StaticVariables.gnv_app.of_get_parameters().booleanparm = true;
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
            }
        }
        #endregion
    }
}