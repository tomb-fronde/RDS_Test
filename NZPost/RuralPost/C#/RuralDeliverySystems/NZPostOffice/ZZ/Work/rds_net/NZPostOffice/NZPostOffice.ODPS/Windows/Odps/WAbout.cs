using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.Windows.OdpsPayrun;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class WAbout : WMaster
    {
        public WAbout()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        #region Events
        public virtual void WAbout_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                System.Configuration.ConfigurationUserLevel.None);
            this.Text = "About " + config.AppSettings.Settings["AppName"].Value.ToString();
            this.st_company.Text = config.AppSettings.Settings["Company"].Value.ToString();

            this.st_version.Text = "Version " + 
                //!config.AppSettings.Settings["Version"].Value.ToString() + " (Built on " + config.AppSettings.Settings["BuildDate"].Value.ToString() + ")"
                System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() +
                " (Built on " + string.Format("{0: dd/MM/yyyy HH:mm:ss}", 
                    System.IO.File.GetLastWriteTime(string.Format(System.Reflection.Assembly.GetEntryAssembly().Location))) + ")";
            
            this.st_application.Text = config.AppSettings.Settings["AppName"].Value.ToString();
            this.st_copyright.Text = config.AppSettings.Settings["CopyRight"].Value.ToString();


            //!string gs_build_date = System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly().Location).ToString("MM/dd/yyyy");           
            //!int igv_build = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Build;
            //!string gs_build_number = string.Format("(Build {0})", igv_build);

        }

        public virtual void pb_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void p_about_doubleclicked(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Shift))
            {
                Cursor.Current = Cursors.WaitCursor;
                WEmergency w_emergency = new WEmergency();
                w_emergency.show();
            }
            else
            {
                //? w_odps_mdiframe.SetMicroHelp("ctrl-shift-dblclk for emergency");
            }
        }
        #endregion
    }
}