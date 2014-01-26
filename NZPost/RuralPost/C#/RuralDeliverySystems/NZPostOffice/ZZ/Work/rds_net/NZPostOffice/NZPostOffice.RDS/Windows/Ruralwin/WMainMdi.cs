using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using NZPostOffice.Shared.Security;
using NZPostOffice.Shared.Ruralsec;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WMainMdi : WMaster
    {
        // TJB  Aug2009
        // Changed content of Toolstrip StatusLabel4 to show purpose of app
        //
        // TJB  Dec-2009
        // Changed the 'Environment' value to the RDS version number

        #region Define
        private System.ComponentModel.IContainer components = null;

        public MMainMenu m_main_menu;

        private WMdiClock w_mdi_clock = null;

        public StatusStrip statusStrip;

        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        #endregion

        public WMainMdi()
        {
            this.InitializeComponent();
            m_main_menu = new MMainMenu(this);
            this.Text = "Rural Delivery System";
            this.toolStripStatusLabel4.Text = "Production Version";
            //this.toolStripStatusLabel4.Text = "DEV Version";
            //this.toolStripStatusLabel4.Text = "Test Version";
            // since its value was meaningless (just like the clock).
            //this.oolStripStatusLabel3.Text = "Environment 8.0.00";
            this.toolStripStatusLabel3.Text = "RDS 7.1.11.3";
            this.toolStripStatusLabel6.Text = "27-Jan-2014 11:00";
            this.toolStripStatusLabel6.Text = string.Format("{0:dd-MMM-yyyy HH:mm}",
                       System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly().Location));
        }

        public virtual void reset_clock()
        {
            if (w_mdi_clock != null)
            {
                w_mdi_clock.Visible = true;
                w_mdi_clock.of_parent_resized();
                w_mdi_clock.TopMost = true;
            }
        }

        public override int closequery()
        {
            return base.closequery();
            // long nMessageReturn
            // if messagebox(this.title, "Do you really want to exit now?",question!,yesno!) = 2 then
            // 	nMessageReturn = 1
            // else
            // 	g_system.CloseDown = True
            // end if
            // 
            //  Stop the DDE Server
            // StopServerDDE(w_main_mdi, "RURAL32","System")
            // //
            // Message.ReturnValue = nMessageReturn
        }

        public virtual void remoteexec()
        {
            // string ls_command
            // 
            // if GetCommandDDE(ls_command) < 0 then
            // 	messagebox("Error","Error receiving the DDE message")
            // end if
            // 
            // ls_command = trim(ls_command)
            // 
            // choose case ls_command
            // 
            // 	case "Contract Search"
            // 		opensheet(w_contract_search, w_main_mdi, 0, original!)
            // 
            // 	case "Owner Driver"
            // 		opensheet(w_Contractor_Search, w_main_mdi, 0, originaL!)
            // 
            // 	case "Piece Rates Import"
            // 		if g_Security.Access_Groups[1] = 7 then
            // 			opensheet(w_piece_rate_import, w_main_mdi, 0, original!)
            // 		else
            // 			MessageBox("Renewal Process","Your UserID does not have access to this window.")
            // 		end if		
            // end choose
            // 
        }

        public override void close()
        {
            /*?
            base.close();
            // Close the MDI clock
            if (IsValid(w_mdi_clock)) {
                close(w_mdi_clock);
            }
             */
        }

        public virtual void move()
        {
            //?base.move();
            reset_clock();
        }

        public override void pfc_preopen()
        {
            //  Start the DDE Server
            /*?
            StartServerDDE(w_main_mdi, "RURAL32", "System");
            this.Title = StaticVariables.gnv_app.of_gettitle();
            if (IsValid(w_opening_screen)) {
                close(w_opening_screen);
            }*/
            int li_Success;
            // Set up other appmanager stuff
            StaticVariables.gnv_app.of_setframe(this);
            StaticVariables.gnv_app.of_initialise_security();
            StaticVariables.gnv_app.of_get_securitymanager().of_enable_component_menuitems(m_main_menu.MenuStrip);

            //jlwang:for display the information of log in user
            this.toolStripStatusLabel5.Text = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_username() 
                + " (" + StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionname() + ")";
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // Check if user has contract privilege. If so, open contract search window
            int ll_Temp_ComponenId;
            bool lb_HasPrivilege = true;
            SecurityManager lnv_RSM;
            NRdsUser lnv_User;
            lnv_RSM = StaticVariables.gnv_app.of_get_securitymanager();
            lnv_User = lnv_RSM.of_get_user();
            //  TJB 6 July 2004
            //  Removed condition: was always TRUE prior to adding commandline parameters 
            //  but failed when user specified connection to use.  This meant the default 
            //  contract search screen didn't display.
            //  if	gnv_App.of_get_commandline()= "" or not(gnv_App.ib_Secure)  then
            lb_HasPrivilege = lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Contract")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Customer")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Renewal")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Frequency")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Route Audit")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Contract Type")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Allowance")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Article Count")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Piece Rate")) || lnv_User.of_hasprivilege(lnv_RSM.of_get_componentid("Fixed Asset"));
            if (lb_HasPrivilege)
            {
                OpenSheet<WContractSearch>(this);
            }
            //jlwang :replaced by statusStrip 
            //?if (w_mdi_clock == null)
            //{
            //    w_mdi_clock = new WMdiClock();
            //    w_mdi_clock.Show();
            //    reset_clock();
            //}
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMainMdi));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.AutoToolTip = true;
            this.toolStripStatusLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.DoubleClickEnabled = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeftAutoMirrorImage = true;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel2.Text = "OK";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel3.Text = "Environment 8.0.00";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel4.Text = "Production Version";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.AutoSize = false;
            this.toolStripStatusLabel5.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(170, 17);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.AutoSize = false;
            this.toolStripStatusLabel6.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel6.Text = "12/12/12 09:12 pm";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip.Location = new System.Drawing.Point(0, 545);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(795, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // WMainMdi
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(795, 567);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "WMainMdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WMainMdi_Load);
            this.Move += new System.EventHandler(this.WMainMdi_Move);
            this.Resize += new System.EventHandler(this.WMainMdi_Resize);
            this.Controls.SetChildIndex(this.statusStrip, 0);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void WMainMdi_Resize(object sender, EventArgs e)
        {
            if ((toolStripStatusLabel1.Width + toolStripStatusLabel2.Width + toolStripStatusLabel3.Width
                + toolStripStatusLabel4.Width + toolStripStatusLabel5.Width + toolStripStatusLabel6.Width)
                < this.ClientSize.Width)
                toolStripStatusLabel1.Width = this.ClientSize.Width - 520;
            else
                toolStripStatusLabel1.Width = this.ClientSize.Width - toolStripStatusLabel2.Width -
                    toolStripStatusLabel3.Width - toolStripStatusLabel4.Width - toolStripStatusLabel5.Width -
                    toolStripStatusLabel6.Width - 80;
        }

        private void WMainMdi_Move(object sender, EventArgs e)
        {
            reset_clock();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        public override void resize(object sender, EventArgs args)
        {
            base.resize(sender, args);
        //    reset_clock();
        }

        private void WMainMdi_Load(object sender, EventArgs e)
        {

        }
    }
}