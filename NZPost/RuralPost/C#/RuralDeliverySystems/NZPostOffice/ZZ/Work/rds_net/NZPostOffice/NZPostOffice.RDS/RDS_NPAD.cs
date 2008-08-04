using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NZPostOffice.DataService;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared.LogicUnits;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS
{
    public class RDS_NPAD : ApplicationContext
    {
        public RDS_NPAD()
        {
            StaticVariables.CurAppContext = this;
            Cursor.Current = Cursors.WaitCursor;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
              System.Configuration.ConfigurationUserLevel.None);

            // Add an entry to appSettings.
            NZPostOffice.Shared.Security.Identity threadId = new NZPostOffice.Shared.Security.Identity(
                config.AppSettings.Settings["DefaultLoginId"].Value.ToString(),
               config.AppSettings.Settings["DefaultLoginPassword"].Value.ToString(), "NZPO");
            System.Threading.Thread.CurrentPrincipal = new NZPostOffice.Shared.Security.Principal(threadId);

            bool ret = LoginService.TryConnectNZPO();
            LogonAttrib lg = new LogonAttrib();
            lg.appName = config.AppSettings.Settings["AppName"].Value.ToString();
            lg.version = "Version " + config.AppSettings.Settings["Version"].Value.ToString() + " ( Built on " + config.AppSettings.Settings["BuildDate"].Value.ToString() + ")";
            lg.userID = config.AppSettings.Settings["DefaultUserName"].Value.ToString();
            WLogon wLogonDlg = new WLogon(lg);
            if (wLogonDlg.ShowDialog() == DialogResult.Yes)
            {
                StaticVariables.DisplayName = "Rural Delivery System with NPAD Extensions(enabled)";
                WMainMdi wMainForm = new WMainMdi();
                this.MainForm = wMainForm;
                wMainForm.Show();
            }
            else
            {
                //?MessageBox.Show("Unable to logon at this time", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Windows.Forms.Application.Exit();
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new RDS_NPAD());
        }
    }
}
