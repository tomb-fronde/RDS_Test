using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WPrintAbort : WMaster
    {
        public WPrintAbort()
        {
            InitializeComponent();
        }

        public virtual void ue_abort()
        {
            if (iw_Parent != null)
            {
                //?iw_Parent.TriggerEvent("ue_Abort");
            }
            this.Close();
        }

        public override void open()
        {
            base.open();
            //?this.of_setbase(true);
            //?this.inv_base.of_center();
        }

        public override void pfc_preopen()
        {
            iw_Parent = (WAncestorWindow)StaticMessage.PowerObjectParm;
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            //?parent.TriggerEvent("Ue_Abort");
        }
    }
}