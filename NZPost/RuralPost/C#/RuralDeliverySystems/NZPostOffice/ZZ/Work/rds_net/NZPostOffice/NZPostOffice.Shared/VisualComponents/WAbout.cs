namespace NZPostOffice.Shared.VisualComponents
{
    // TJB  Release 7.1.13.3  May-2015
    // Changed Version string in WAbout() to improve clarity.

    using System;
    using System.Reflection;
    using System.Configuration;
    using System.Windows.Forms;
    using NZPostOffice.Shared.Managers;

    // Class:   WAbout
    // Purpose: generic "About" window for NZ Post applications
    //
    // Notes:   Information to be displayed is passed to the constructor
    //          in an AboutAttrib object.

    public class WAbout : Form
    {
        private PictureBox pbAbout;
        private Label lblApplication;
        private Label lblVersion;
        private Label lblCopyright;
        private Button btnOk;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public WAbout(/*AboutAttrib aboutAttribs*/)
        {
            this.InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            string sBuiltOn = AppManager.ApplicationBuiltOn;
            // TJB  Release 7.1.13.3  May-2015
            // Changed Version string to improve clarity.
            // Used by RDSAdmin
            lblVersion.Text = "Version " + AppManager.ApplicationVersion + ", " + sBuiltOn;
                                   // + " Built on " + string.Format("{0: dd/MM/yyyy HH:mm:ss}"
                                   //      , System.IO.File.GetLastWriteTime(string.Format(System.Reflection.Assembly.GetEntryAssembly().Location))) + ")" + "\n"
                                   // + "AppMgr builton = " + sBuiltOn;
                //!AppManager.ApplicationBuiltOn;
            lblApplication.Text = ((AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
            lblCopyright.Text = ((AssemblyCopyrightAttribute)assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
            //if (aboutAttribs.imageLocation.Length > 0)
            //{
            //    pbAbout.ImageLocation = aboutAttribs.imageLocation;
            //}
            //else
            //{
            //    pbAbout.Visible = false;
            //}
            //lblVersion.Text = ConfigurationSettings.AppSettings["Version"].ToString();
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblApplication = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbAbout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // lblApplication
            // 
            this.lblApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.Location = new System.Drawing.Point(104, 33);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(248, 23);
            this.lblApplication.TabIndex = 0;
            this.lblApplication.Text = "Application...";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(104, 56);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(248, 23);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version...";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(104, 79);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(248, 72);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright...";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(277, 159);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbAbout
            // 
            this.pbAbout.Image = global::NZPostOffice.Shared.Properties.Resources.Logo;
            this.pbAbout.Location = new System.Drawing.Point(0, 0);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(88, 56);
            this.pbAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAbout.TabIndex = 3;
            this.pbAbout.TabStop = false;
            // 
            // WAbout
            // 
            this.ClientSize = new System.Drawing.Size(375, 194);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblApplication);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.pbAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 290);
            this.MinimizeBox = false;
            this.Name = "WAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).EndInit();
            this.ResumeLayout(false);

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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
