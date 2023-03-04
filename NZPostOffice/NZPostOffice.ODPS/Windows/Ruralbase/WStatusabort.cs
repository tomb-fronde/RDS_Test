using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WStatusabort : WMaster
    {
        public WMaster iw_Parent = new WMaster();

        public WStatusabort()
        {
            this.InitializeComponent();

            this.Icon = new System.Drawing.Icon("Information!");
        }

        public virtual void ue_abort()
        {
            bool lb_valid;
            // Tell parent window that we are aborting
            //? lb_valid = IsValid(iw_Parent);
            /*? if (lb_valid)
               {
                   //iw_Parent.TriggerEvent("Ue_Abort");
                   ue_abort();
               }*/
            this.Close();
        }

        public virtual void pfc_preopen()
        {
            //? this.of_setbase(true);
            //? this.inv_base.of_center();
            iw_Parent = (WMaster)StaticMessage.PowerObjectParm;
        }

        public virtual int of_draw(int lcount, int llimit)
        {
            int limit;
            limit = st_limit.Width - 20;
            st_bar.Width = lcount / llimit * limit;
            return 0;
        }

        public virtual int of_draw(int lcount, int llimit, string as_message)
        {
            // setredraw ( false)
            int limit;
            limit = st_limit.Width - 20;
            st_bar.Width = lcount / llimit * limit;
            // st_message.text=as_message
            // setredraw ( true)
            return 0;
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            // parent.TriggerEvent("Ue_Abort");
            ue_abort();
        }
    }
}