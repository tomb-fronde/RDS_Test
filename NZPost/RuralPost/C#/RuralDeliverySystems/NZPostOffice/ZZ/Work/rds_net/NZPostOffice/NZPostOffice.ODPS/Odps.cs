using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.DataService;
using NZPostOffice.Shared.LogicUnits;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.Windows.Odps;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS
{
    public class Odps : ApplicationContext
    {
        public Odps()
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.CurAppContext = this;
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
            lg.version = "Version " + config.AppSettings.Settings["Version"].Value.ToString() + " (Built on " + config.AppSettings.Settings["BuildDate"].Value.ToString() + ")";
            lg.userID = config.AppSettings.Settings["DefaultUserName"].Value.ToString();
            WLogon wLogonDlg = new WLogon(lg);
            if (wLogonDlg.ShowDialog() == DialogResult.Yes)
            {
                StaticVariables.DisplayName = config.AppSettings.Settings["AppName"].Value.ToString();
                WOdpsMdiframe wMdiFrame = new WOdpsMdiframe();
                this.MainForm = wMdiFrame;
                wMdiFrame.show();
            }
            else
            {
                //?MessageBox.Show("Unable to logon at this time", "ODPS");
                Application.Exit();
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Odps());
        }
    }
}