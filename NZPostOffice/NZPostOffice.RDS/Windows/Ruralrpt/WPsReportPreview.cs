using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WPsReportPreview : WGenericReportPreview
    {
        private const string DEFAULT_ASSEMBLY = "NZPostOffice.RDS.DataControls";
        private const string DEFAULT_VERSION = "1.0.0.0";

        public WPsReportPreview()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // wf_setposition  ( )
            this.Text = StaticMessage.StringParm;

            this.dw_report.SetDataObject(DEFAULT_ASSEMBLY, DEFAULT_VERSION, StaticVariables.gnv_app.of_get_parameters().stringparm);
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";
            //?dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().dateparm);
        }
    }
}