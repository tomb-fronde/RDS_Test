using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WSystemAbout : WResponse
    {
        public WSystemAbout()
        {
            this.InitializeComponent();
        }

        public virtual void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_bypass_security(true);
            st_title.Text = StaticVariables.gnv_app.of_get_title();
            st_version.Text = StaticVariables.gnv_app.of_getversion();
        }

        public virtual void timer()
        {
            //? p_icon.setredraw(false);
            //  p_icon.Move(new Random(this.Width), new Random(this.Height));
            p_icon.Location = new Point(Convert.ToInt32(new Random(this.Width)), Convert.ToInt32(new Random(this.Height)));
            p_icon.ResumeLayout(false);
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void p_icon_doubleclicked(object sender, EventArgs e)
        {
            // ole_1.activate ( inplace!)
            //? timer(0.5);
            timer();
        }
    }
}