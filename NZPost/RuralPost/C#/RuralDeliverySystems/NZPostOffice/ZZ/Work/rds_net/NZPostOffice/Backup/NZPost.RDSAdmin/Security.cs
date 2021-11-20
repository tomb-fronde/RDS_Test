using System;
using System.Data.OleDb;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.DataService;

using System.Configuration;
using System.Reflection;

namespace NZPostOffice.RDSAdmin
{
    // TJB  Feb 2016 (assisted by Richard Renouf)
    // Added startup option: parameter references an alternate config file, 
    // used to provide an alternate database connection.  No parameter reverts 
    // to using the default.
    //

    // Security Application and logon
    public class Security : ApplicationContext
    {
        //!private NSecurityTr sqlca;
        
        //private NRdssecAppmanager gnv_app;
        
        /// <summary>
        /// reference to the global variables/methods of the PB application
        /// </summary>
        //!public Cl_GlobalDeclarations app;
        
        public Security() 
        {
            //!app = new GlobalDeclarations();
            //// Statements from the PB create() event
            //app.message = new Unknown_security_message_message();
            //sqlca = new NSecurityTr();
            //app.sqlda = new DynamicDescriptionArea();
            //app.sqlsa = new DynamicStagingArea();
            //app.error = new Unknown_security_error_error();
            // Statements from the PB open() event
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:
            // 	open
            // 
            // 	Arguments:
            // 	None
            // 
            // 	Returns:
            // 	None
            // 
            // 	Description:	
            // 
            //  Creates the Application Manager, n_exampleappmanager, as gnv_app,
            //  then triggers its pfc_open event.
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	1.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            
            //!DisplayName = "Rural Delivery System Administration";
            //!gnv_app = new NRdssecAppmanager();
            //  TJB SR4630 5 July 2004
            //  Pass the commandline into the system so it can be used
            //  gnv_app.TriggerEvent('pfc_open')
            //!gnv_app.pfc_open(commandline);

            Cursor.Current = Cursors.WaitCursor;

            // TJB  Feb-2016: Added
            string msg;
            string arg1 = null;
            Configuration config = null;

            // Get the commendline arguments (if any)
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                arg1 = args[1];
                //MessageBox.Show("Arg1 = " + arg1 + "\n","Get parameter(s)");
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
                //MessageBox.Show("Using config file " + arg1,"Parameter startup");

                try
                {
                    //config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                    //    System.Configuration.ConfigurationUserLevel.None);

                    // we have an arg passed to exe, and it's not any of the above so should be config file path!
                    UpdateConfiguration(arg1, ref config);

                    //msg = "config.FilePath = " + arg1 + "\n\n";
                    //msg += ConfigurationManager.ConnectionStrings["NZPO"].ConnectionString;
                    //MessageBox.Show("Connection strings from in-memory config: \n\n" + msg);
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
                //MessageBox.Show("Using default config file.","No parameter startup");

                config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                    System.Configuration.ConfigurationUserLevel.None);
            }

/* Original code
            // test the new logon window...
            //note - there are 2 versions of the constructor -
            // the second accepts LogonAttrib as an argument (created by appmanager)
            System.Configuration.Configuration config =
              System.Configuration.ConfigurationManager.OpenExeConfiguration(
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

            WLogon wLogonDlg = new WLogon();
            if (wLogonDlg.ShowDialog() == DialogResult.Yes)
            {            
                WMainMdi wMainForm = new WMainMdi();
                wMainForm.Show();
            }
            else
            {
                //MessageBox.Show("Unable to logon at this time", "RDSAdmin");
                Environment.Exit(0);
            }
            //end testing of logon window
        }

        // TJB  Feb-2016: Added  (Richard Renouf author)
        /// <summary>
        /// Update default (in-memory) config with input settings
        /// </summary>
        /// <param name="configFilePath">The full path to the config file</param>
        private void UpdateConfiguration(string configFilePath, ref Configuration config)
        {
            // Author: Richard Renouf from David Gardiner blog
            // force access/load of config
            ConnectionStringSettingsCollection conns = ConfigurationManager.ConnectionStrings;

            // get our input config
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFilePath;

            // Get the mapped configuration file.
            //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(
            config = ConfigurationManager.OpenMappedExeConfiguration(
                configFileMap, ConfigurationUserLevel.None);

            // now change it
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["NZPO"];
            FieldInfo fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            // make writeable
            fi.SetValue(settings, false);
            // set new value
            settings.ConnectionString = config.ConnectionStrings.ConnectionStrings["NZPO"].ConnectionString;

            // check our new value
            //System.Diagnostics.Debug.Print(ConfigurationManager.ConnectionStrings["NZPO"].ConnectionString);
        }

        public virtual void security_close(object sender, System.ComponentModel.CancelEventArgs e) 
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:
            // 	close
            // 
            // 	Arguments:
            // 	None
            // 
            // 	Returns:
            // 	None
            // 
            // 	Description:	
            // 
            //  Triggers the pfc_close event on gnv_app, then destroys the Application
            // 	Manager.
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	1.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            //!gnv_app.TriggerEvent("pfc_close");
            //if (IsValid(gnv_app)) {
            //    // PB 'Destroy' Statement
            //    gnv_app = null;
            //}
        }
        
        public virtual void systemerror() 
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:
            // 	systemerror
            // 
            // 	Arguments:
            // 	None
            // 
            // 	Returns:
            // 	None
            // 
            // 	Description:	
            // 
            //  Triggers the pfc_systemerror event on the Application Manager  ( gnv_app).
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	1.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            //!gnv_app.pfc_systemerror();
        }
        
        [STAThread()]
        public static void Main() 
        {
            Application.EnableVisualStyles();
            Application.Run(new Security());
        }
    }
}
