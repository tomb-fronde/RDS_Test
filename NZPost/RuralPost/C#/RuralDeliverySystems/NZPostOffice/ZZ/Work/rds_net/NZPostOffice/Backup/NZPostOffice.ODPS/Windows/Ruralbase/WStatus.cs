using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WStatus : Form
    {
        public WStatus()
        {
            InitializeComponent();

            this.Icon = new System.Drawing.Icon("Information!");
        }

        public virtual void open(object sender, EventArgs e) 
        {
            //Environment env;
            //GetEnvironment(env);
            //this.Left  = PixelsToUnits(env.ScreenWidth - UnitsToPixels(this.Width, xunitstopixels!), xpixelstounits!) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;    
            //this.Top  = PixelsToUnits(env.ScreenHeight - UnitsToPixels(this.Height, yunitstopixels!), ypixelstounits!) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;  
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
            st_message.Text = as_message;
            // setredraw ( true)
            return 0;
        }
    }
}