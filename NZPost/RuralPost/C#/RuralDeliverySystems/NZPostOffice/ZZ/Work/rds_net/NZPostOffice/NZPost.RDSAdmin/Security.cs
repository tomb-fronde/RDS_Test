namespace NZPostOffice.RDSAdmin
{
    using System;
    using System.Data.OleDb;
    using System.Windows.Forms;
    using NZPostOffice.Shared;
    using NZPostOffice.Shared.VisualComponents;
    using NZPostOffice.DataService;    
    
    // Security Application
    public class Security : ApplicationContext
    {
        
        //!private NSecurityTr sqlca;
        
        //private NRdssecAppmanager gnv_app;
        
        /// <summary>
        /// reference to the global variables/methods of the PB application
        /// </summary>
        //!public Cl_GlobalDeclarations app;
        
        public Security() {
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
            Cursor.Current = Cursors.WaitCursor;
            //!DisplayName = "Rural Delivery System Administration";
            //!gnv_app = new NRdssecAppmanager();
            //  TJB SR4630 5 July 2004
            //  Pass the commandline into the system so it can be used
            //  gnv_app.TriggerEvent ( 'pfc_open')
            //!gnv_app.pfc_open(commandline);

            // test the new logon window...
            //note - there are 2 versions of the constructor -
            // the second accepts LogonAttrib as an argument (created by appmanager)
            System.Configuration.Configuration config =
              System.Configuration.ConfigurationManager.OpenExeConfiguration(
              System.Configuration.ConfigurationUserLevel.None);

            // Add an entry to appSettings.

            NZPostOffice.Shared.Security.Identity threadId = new NZPostOffice.Shared.Security.Identity(
                config.AppSettings.Settings["DefaultLoginId"].Value.ToString(),
               config.AppSettings.Settings["DefaultLoginPassword"].Value.ToString(), "NZPO");
            System.Threading.Thread.CurrentPrincipal = new NZPostOffice.Shared.Security.Principal(threadId);
            bool ret = LoginService.TryConnectNZPO();
            WLogon wLogonDlg = new WLogon();
            if (wLogonDlg.ShowDialog() == DialogResult.Yes)
            {            
                WMainMdi wMainForm = new WMainMdi();
                wMainForm.Show();
            }
            else
            {
                MessageBox.Show("Unable to logon at this time", "RDSAdmin");
                Application.Exit();
            }
            //end testing of logon window
        }
        
        public virtual void security_close(object sender, System.ComponentModel.CancelEventArgs e) {
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
        
        public virtual void systemerror() {
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
