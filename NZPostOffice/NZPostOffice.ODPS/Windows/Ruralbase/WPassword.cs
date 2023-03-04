using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WPassword : WMaster
    {
        public WPassword()
        {
            InitializeComponent();
        }

        public override void open()
        {
            base.open();
            sle_1.Focus();
        }

        public virtual void cb_2_clicked(object sender, EventArgs e)
        {
            string ls_pass;
            ls_pass = sle_1.Text;
            sle_2.Text = StaticFunctions.f_decrypt(ls_pass);
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            string ls_pass;
            ls_pass = sle_1.Text.ToUpper();
            sle_2.Text = StaticFunctions.f_encrypt(ls_pass);
        }
    }
}
