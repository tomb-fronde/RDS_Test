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
    public partial class WDeedComp : WReportAncestor
    {
        public WDeedComp()
        {
            InitializeComponent();

            this.dw_report.DataObject = new RDeedCompliance();
            this.dw_report.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        public override void ue_report()
        {
            base.ue_report();
            ((RDeedCompliance)dw_report.DataObject).Retrieve();
            //?st_label.Text = "RPTDCOMP";
            //?st_label.Dock = DockStyle.Bottom;
            //?st_label.Visible = false;


        }

        public virtual void dw_report_constructor()
        {
            //?base.constructor();
        }
    }
}