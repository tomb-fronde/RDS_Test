using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NZPostOffice.DataService;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared.LogicUnits;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.Shared;

using System.Configuration;
using System.Reflection;

namespace NZPostOffice.RDS
{
    // TJB  14-Feb-2016
    // Added TESTING MessageBoxes to trace handling of alternate config file
    // under Windows 10
    //
    // TJB  Feb 2016 (assisted by Richard Renouf)
    // Added startup option: parameter references an alternate config file, 
    // used to provide an alternate database connection.  No parameter reverts 
    // to using the default.
    //
    // TJB  May-2011
    // Changed 'built on' value from config file to file build timestamp
    //
    public class RDS_NPAD : ApplicationContext
    {
        public RDS_NPAD()
        {
            string msg;
            string arg1 = null;
            Configuration config = null;
            bool TESTING = false;

            StaticVariables.CurAppContext = this;
            Cursor.Current = Cursors.WaitCursor;

            // Get the commendline arguments (if any)
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                arg1 = args[1];
                if (TESTING) MessageBox.Show("Arg1 = " + arg1 + "\n", "Get parameter(s)");
            }

            // Check to see if the file exists
            // If not, tell the user and quit
            if (arg1 != null && arg1.Length > 0)
                if (!System.IO.File.Exists(arg1))
                {
                    MessageBox.Show("File " + arg1 + " passed as parameter 1, not found. \n"
                                    + "Unable to run program."
                                    , "Error");
                    Environment.Exit(0);
                }

            if (arg1 != null && arg1.Length > 0)
            {
                if (TESTING) MessageBox.Show("Using config file " + arg1, "Parameter startup");
                try
                {
                    //config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                    //    System.Configuration.ConfigurationUserLevel.None);

                    // we have an arg passed to exe, and it's not any of the above so should be config file path!
                    UpdateConfiguration(arg1, ref config);

//                    msg = "config.FilePath = " + arg1 + "\n\n";
//                    msg += ConfigurationManager.ConnectionStrings["NZPO"].ConnectionString;
//                    MessageBox.Show("Connection strings from in-memory config: \n\n" + msg);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error getting default config file: \n\n"
                                    + e.Message + "\n\n"
                                    + "Unable to continue."
                                    , "UpdateConfiguration Error");
                    Environment.Exit(0);
                }
            }
            else
            {
//                MessageBox.Show("Using default config file.","No parameter startup");

                config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                    System.Configuration.ConfigurationUserLevel.None);
            }

/* Original code
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                System.Configuration.ConfigurationUserLevel.None);
*/
            // Add an entry to appSettings.
            NZPostOffice.Shared.Security.Identity threadId = new NZPostOffice.Shared.Security.Identity(
                config.AppSettings.Settings["DefaultLoginId"].Value.ToString(),
                config.AppSettings.Settings["DefaultLoginPassword"].Value.ToString(), "NZPO");
            System.Threading.Thread.CurrentPrincipal = new NZPostOffice.Shared.Security.Principal(threadId);

            bool ret = LoginService.TryConnectNZPO();
            if (!ret)  // TJB Feb-2016: Added
            {
                MessageBox.Show("Error attempting TryConnectNZPO \n\n"
                                + "Unable to continue."
                                , "Fatal Error");
                Environment.Exit(0);
            }

            LogonAttrib lg = new LogonAttrib();
            lg.appName = config.AppSettings.Settings["AppName"].Value.ToString();
            // TJB  May-2011: Changed 'Built on' value to file build timestamp
            //lg.version = "Version " + config.AppSettings.Settings["Version"].Value.ToString() + " (Built on " + config.AppSettings.Settings["BuildDate"].Value.ToString() + ")";
            lg.version = "Version " + config.AppSettings.Settings["Version"].Value.ToString() 
                         + " (Built on " 
                         + string.Format("{0:dd-MMM-yyyy HH:mm}", System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly().Location))
                         + ")";
            lg.userID = config.AppSettings.Settings["DefaultUserName"].Value.ToString();

            WLogon wLogonDlg = new WLogon(lg);
            if (wLogonDlg.ShowDialog() == DialogResult.Yes)
            {
                StaticVariables.DisplayName = lg.appName + " (enabled)";
                WMainMdi wMainForm = new WMainMdi();
                this.MainForm = wMainForm;
                wMainForm.Show();
            }
            else
            {
                //?MessageBox.Show("Unable to logon at this time"
                //               , "Rural Delivery System with NPAD Extensions"
                //               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
        }

        // TJB  Feb-2016: Added  (Richard Renouf author)
        /// <summary>
        /// Update default (in-memory) config with input settings
        /// </summary>
        /// <param name="configFilePath">The full path to the config file</param>
        private void UpdateConfiguration(string configFilePath, ref Configuration config)
        {
            // Author: Richard Renouf from David Gardiner blog
            bool TESTING = false;
            if (TESTING) MessageBox.Show("Get ConnectionStringSettingsCollection conns", "Testing");

            // force access/load of config
            ConnectionStringSettingsCollection conns = ConfigurationManager.ConnectionStrings;

            if (TESTING) 
                MessageBox.Show("New ExeConfigurationFileMap configFileMap", "Testing");

            // get our input config
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFilePath;

            if (TESTING) MessageBox.Show("Get the mapped configuration file\n", "Testing");
            // Get the mapped configuration file.
            //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(
            config = ConfigurationManager.OpenMappedExeConfiguration(
                configFileMap, ConfigurationUserLevel.None);

            if (TESTING) MessageBox.Show("Now change the mapped configuration file\n"
                             + "Get ConnectionStringSettings settings", "Testing");
            // now change it
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["NZPO"];
            if (TESTING) MessageBox.Show("Get FieldInfo fi", "Testing");
            FieldInfo fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            if (TESTING) MessageBox.Show("Make FieldInfo fi writeable", "Testing");
            // make writeable
            fi.SetValue(settings, false);
            if (TESTING) MessageBox.Show("Set settings.ConnectionString", "Testing");
            // set new value
            settings.ConnectionString = config.ConnectionStrings.ConnectionStrings["NZPO"].ConnectionString;

            string connString = ConfigurationManager.ConnectionStrings["NZPO"].ConnectionString;
            if (TESTING) MessageBox.Show("ConfigurationManager.ConnectionStrings[\"NZPO\"].ConnectionString = "+connString,"TESTING");
            // check our new value
            //System.Diagnostics.Debug.Print(ConfigurationManager.ConnectionStrings["NZPO"].ConnectionString);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new RDS_NPAD());
        }
    }
}
