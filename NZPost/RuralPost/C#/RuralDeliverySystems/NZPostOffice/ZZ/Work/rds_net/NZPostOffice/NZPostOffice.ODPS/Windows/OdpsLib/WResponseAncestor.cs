using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    public partial class WResponseAncestor : FormBase
    {
        public WResponseAncestor()
        {
            InitializeComponent();
        }

        public override void open()
        {
            wf_setposition();
        }

        public virtual void wf_setposition()
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
        }

        public virtual void Catch_open(object sender, EventArgs e)
        {
            this.open();
        }
    }
}