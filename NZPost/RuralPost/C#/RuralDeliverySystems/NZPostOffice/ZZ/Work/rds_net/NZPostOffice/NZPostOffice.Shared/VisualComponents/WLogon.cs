namespace NZPostOffice.Shared.VisualComponents
{
    // TJB  Apr-2014
    // Added Application.ProductName == "Rural Delivery System Administration"
    // to btnLogin_Click to give user grace login attempts.

    using System;
    using System.Configuration;
    using System.Windows.Forms;
    using NZPostOffice.Shared.LogicUnits;

    // Class:   WLogon
    // Purpose: generic "Log-in" window for NZ Post applications
    //
    // Notes:   Information to be displayed is passed to the constructor
    //          in an LogonAttrib object.
    //          Version, Build Date and Database profile name are retrieved from the 
    //          application's Configuration.AppSettings
    //          A Web Service called SecurityManagerService is used to confirm 
    //          user's access

    public class WLogon : Form
    {
        private int graceLoginsRemaining;
        public int graceLogins
        {
            get { return graceLoginsRemaining; }
            set { graceLoginsRemaining = value; }
        }

        private int loginAttemptsRemaining = 3;
        public int loginAttempts
        {
            get { return loginAttemptsRemaining; }
            set { loginAttemptsRemaining = value; }
        }

        private PictureBox pbLogo;
        private Label lblCopyright;
        private Button btnLogin;
        private Button btnExit;
        private Label lblUserID;
        private Label lblPassword;
        private TextBox tbUserID;
        private TextBox tbPassword;
        private Label lblApplicationName;
        private Label lblApplicationVersion;

        private string version = "";
        private string buildDate = "";
        private string dbName = "";
        public string userID = "";
        private PictureBox pictureBox1;

        //! flag used to show farmers picture and logo on top of login screen - set to false to move back to the previous state of the logon screen
        private bool newLogoFlag = true;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public WLogon(LogonAttrib LogonAttribs)
        {
            this.InitializeComponent();
            //for ODPS - all three applications have new logos now
            //! if (LogonAttribs.appName == "Owner-Driver Payment System")
            //!    newLogoFlag = false;

            //! change the flag to show the old version of logon screen
            if (newLogoFlag)
            {
                this.pbLogo.Image = global::NZPostOffice.Shared.Properties.Resources.farmer_2_c;
                this.pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.Image = global::NZPostOffice.Shared.Properties.Resources.Logo_slim;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.Visible = true;
            }
            else {
                this.pbLogo.Image = global::NZPostOffice.Shared.Properties.Resources.Logo;
                this.pictureBox1.Visible = false;
            }

            // may move the following out into LogicUnitWLogon.Preopen()...
            lblApplicationName.Text = LogonAttribs.appName;

            if (LogonAttribs != null)
            {
                // grab information from logonAttribs...
                tbUserID.Text = LogonAttribs.userID;
                // set Application Name...
                //? if (LogonAttribs.appName.Length > 0)
                lblApplicationName.Text = LogonAttribs.appName;
                lblApplicationVersion.Text = LogonAttribs.version;
                if (lblApplicationName.Text == "Owner-Driver Payment System")
                    this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;
            }

            // set initial control focus...
            if (tbUserID.Text.Length > 0)
                if (tbPassword.Text.Length > 0)
                    btnLogin.Focus();
                else
                    tbPassword.Focus();
            else
                tbUserID.Focus();
        }

        public WLogon()
        {
            this.InitializeComponent();

            if (newLogoFlag)
            {
                this.pbLogo.Image = global::NZPostOffice.Shared.Properties.Resources.farmer_2_c;
                this.pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.Image = global::NZPostOffice.Shared.Properties.Resources.Logo_slim;
                this.pictureBox1.Visible = true;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;                
            }
            else
            {
                this.pbLogo.Image = global::NZPostOffice.Shared.Properties.Resources.Logo;
                this.pictureBox1.Visible = false;
            }

            // may move the following out into LogicUnitWLogon.Preopen()...
            lblApplicationName.Text = "Rural Delivery System Administration";

            // get Version info from App.Config...
            version = ConfigurationManager.AppSettings["Version"].ToString();
            buildDate = ConfigurationManager.AppSettings["BuildDate"].ToString();
            tbUserID.Text = ConfigurationManager.AppSettings["DefaultUserName"].ToString();
            //!dbName = ConfigurationManager.AppSettings["DBName"].ToString();
            lblApplicationVersion.Text = "Version " + version + " Built on (" + buildDate + ")";

            // set initial control focus...
            if (tbUserID.Text.Length > 0)
                if (tbPassword.Text.Length > 0)
                    btnLogin.Focus();
                else
                    tbPassword.Focus();
            else
                tbUserID.Focus();

            // end of Preopen...
        }

        #region  Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WLogon));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblApplicationVersion = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(319, 155);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(251, 99);
            this.lblCopyright.TabIndex = 10;
            this.lblCopyright.Text = resources.GetString("lblCopyright.Text");
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(370, 121);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(452, 121);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(374, 68);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(46, 13);
            this.lblUserID.TabIndex = 4;
            this.lblUserID.Text = "User ID:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(364, 96);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // tbUserID
            // 
            this.tbUserID.Location = new System.Drawing.Point(424, 64);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(100, 20);
            this.tbUserID.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPassword.Location = new System.Drawing.Point(424, 92);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationName.Location = new System.Drawing.Point(3, 207);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(298, 23);
            this.lblApplicationName.TabIndex = 8;
            this.lblApplicationName.Text = "Application Name";
            this.lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApplicationVersion
            // 
            this.lblApplicationVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationVersion.Location = new System.Drawing.Point(3, 234);
            this.lblApplicationVersion.Name = "lblApplicationVersion";
            this.lblApplicationVersion.Size = new System.Drawing.Size(298, 23);
            this.lblApplicationVersion.TabIndex = 9;
            this.lblApplicationVersion.Text = "Application Version";
            this.lblApplicationVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::NZPostOffice.Shared.Properties.Resources.Logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(298, 203);
            this.pbLogo.TabIndex = 11;
            this.pbLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(344, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 54);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // WLogon
            // 
            this.AcceptButton = this.btnLogin;
            this.ClientSize = new System.Drawing.Size(582, 263);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblApplicationVersion);
            this.Controls.Add(this.lblApplicationName);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserID);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 290);
            this.MinimizeBox = false;
            this.Name = "WLogon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logon";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private void UpdateAppSettings(string DefaultUserName)
        {
            // Get the configuration file.
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.None);

            // Add an entry to appSettings.
            config.AppSettings.Settings["DefaultUserName"].Value = DefaultUserName;

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified, true);

            // Force a reload of the changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int retValue;
            loginAttempts--;
            retValue = LogonUser(dbName, tbUserID.Text, StaticFunctions.f_encrypt(tbPassword.Text));
            switch (retValue)
            {
                case 1: //success
                    userID = StaticVariables.LoginId;
                    UpdateAppSettings(userID);
                    DialogResult = DialogResult.Yes;

                    break;
                case -1:    //failed
                    if (loginAttempts > 0)
                        tbPassword.Focus();
                    else
                    {
                        // number of login attempts exceeded
                        // lock this account!
                        MessageBox.Show("Sorry, you do not have access to this system.\n" 
                                        + " The account '" + tbUserID.Text + "' has been disabled."
                                        , ""
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //!DisableAccount(uID);
                        userID = StaticVariables.LoginId;
                        UpdateAppSettings(userID);
                        NZPostOffice.DataService.LoginService.UpdateRdsUserIdUILockedDate(userID);
                        DialogResult = DialogResult.No;
                    }
                    break;
                case -3:
                    MessageBox.Show("Your password has expired.  \n" 
                                    + "You must change the password before you can run the system."
                                    , "Password Expired"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // inv_logonattrib.ii_rc = -1;
                    DialogResult = DialogResult.No;
                    break;
                case -9:    //exception raised
                    DialogResult = DialogResult.No;
                    break;
                case -99:   //security service unavailable
                    DialogResult = DialogResult.No;
                    break;
                default:
                    // if > 10, user has correct pwd, but it has expired.
                    userID = tbUserID.Text;
                    if (retValue >= 10)
                        DialogResult = DialogResult.Yes;
                    else
                        DialogResult = DialogResult.No;
                    break;
            }
            if (DialogResult == DialogResult.No)
            {
                Close();
                return;
            }
            if (Application.ProductName == "Rural Delivery System" ||
                Application.ProductName == "Owner Driver Payment System" ||
                Application.ProductName == "Rural Delivery System Administration")
                return;

            NZPostOffice.Shared.Security.SecurityManager securitymanager = new NZPostOffice.Shared.Security.SecurityManager();
            string ErrorMessage = securitymanager.Initialize();
            if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
            }
            if (!securitymanager.CheckPrivilege("Security"))
            {
                MessageBox.Show("Sorry, You have no access right to this application.", "Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // User aborted logon process...
            DialogResult = DialogResult.Abort;
            System.Windows.Forms.Application.Exit();
        }

        private int LogonUser(string db, string uID, string pwd)
        {
            //retValue:
            //   1: Success
            //  -1: Invalid pwd or userid
            //  -2: Correct pwd, but Account disabled
            // 10+: Correct pwd, password expired
            //      (return code - 10) gives # grace logins remaining
            // -99: Service Unavailable
            //
            //  Note: passwords are received in encrypted format.

            int retValue = 0;
            DateTime? ldt_ExpiryDate = null;
            DateTime? ldt_LockedDate = null;
            int li_GraceLogins = 0;
            DateTime ld_today;
            ld_today = DateTime.Today;
            // create an instance of the security webservice
            //wsSecurityService.SecurityService wsSecurity =
            //            new wsSecurityService.SecurityService();
            //SecurityManagerService wsSecurity = new SecurityManagerService();

            //if (wsSecurity != null)
            //{
            try
            {
                //while (loginAttempts > 0)
                //{
                //loginAttempts--;
                NZPostOffice.DataService.LoginService ret = NZPostOffice.DataService.LoginService.LoginUser(uID, pwd, ref StaticVariables.userId);
                li_GraceLogins = ret.GraceLoginsRemaining;
                ldt_ExpiryDate = ret.PasswordExpiryDate;
                ldt_LockedDate = ret.AccountLockedDate;
                retValue = ret.RetValue;
                if (retValue == -1)
                {
                   // MessageBox.Show("Invalid userid or password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show("The user id or password entered is incorrect", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    //tbPassword.Focus();
                    //return (retValue);
                    return retValue;
                }
                //else
                //{
                //    break;
                //}
                //}
                switch (retValue)
                {
                    case 1:
                        // success
                        break;
                    case -1:
                        break;
                    case -2:
                        MessageBox.Show("Unable to login at this time.\n Please contact a system administrator", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    case -99:
                        MessageBox.Show("Unable to connect to database.\nPlease try again later.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    default:
                        break;
                }

                //added by jlwang -needed
                StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
                StaticVariables.gnv_app.of_get_parameters().stringparm = pwd;

                //StaticMessage.BooleanParm = false;
                //StaticMessage.StringParm = pwd;

                StaticVariables.LoginId = tbUserID.Text;

                if (retValue >= 10)
                {
                    // password has expired, user has "retValue - 10" 
                    // grace logins remaining
                    if (li_GraceLogins <= 0)
                    {
                        WPasswordChange w_password_change = new WPasswordChange();
                        w_password_change.ShowDialog();

                        if (StaticMessage.BooleanParm)
                        {
                            li_GraceLogins = 4;
                            ldt_ExpiryDate = ld_today.AddDays(40);
                        }
                        else
                        {
                            return -3;
                        }
                    }
                    else if (MessageBox.Show("Your password has expired.\nYou have " +
                        li_GraceLogins.ToString() + " grace logins remaining.\n\n" +
                        "Do you want to change your password now?", "Password expired",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        WPasswordChange w_password_change = new WPasswordChange();
                        w_password_change.ShowDialog();

                        if (StaticMessage.BooleanParm)
                        {
                            li_GraceLogins = 4;
                            ldt_ExpiryDate = ld_today.AddDays(40);
                            retValue = 1;
                        }
                        else
                        {
                            li_GraceLogins--;
                        }
                    }
                    else
                    {
                        li_GraceLogins--;
                    }
                }
                NZPostOffice.DataService.LoginService.UpdateUser(uID, li_GraceLogins, ldt_ExpiryDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                retValue = -9;
            }
            //}
            //else
            //{
            //    MessageBox.Show("Unable to connect to security service. Please try again later");
            //    retValue = -99;
            //}
            return (retValue);
        }
    }
}
