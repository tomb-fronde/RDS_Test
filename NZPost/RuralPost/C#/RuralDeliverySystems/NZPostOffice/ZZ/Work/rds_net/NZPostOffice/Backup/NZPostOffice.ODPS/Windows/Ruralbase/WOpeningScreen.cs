using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using NZPostOffice.ODPS.DataControls.Ruralbase;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WOpeningScreen : WMaster
    {
        public DSystemTitle dw_title;

        public WOpeningScreen()
        {
            InitializeComponent();
        }

        public override void open()
        {
            this.Left = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2;
            this.Top = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2;

            this.Text = StaticVariables.gnv_app.of_get_title();
            dw_title.SetValue(0, "SystemTitle", StaticVariables.gnv_app.of_get_title());
            this.Text = StaticVariables.gnv_app.of_getversion();
            dw_title.SetValue(0, "SystemVersion", StaticVariables.gnv_app.of_getversion());
            this.show();
        }
    }
}
