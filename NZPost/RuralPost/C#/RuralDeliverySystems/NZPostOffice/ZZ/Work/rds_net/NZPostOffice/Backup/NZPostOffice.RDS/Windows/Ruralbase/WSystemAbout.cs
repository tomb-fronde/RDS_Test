using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralbase;
using NZPostOffice.RDS.Entity.Ruralbase;
using System.Reflection;
using System.Configuration;

namespace NZPostOffice.RDS.Windows.Ruralbase
{
    // TJB Rebranding 2021
    // Changed image to Logo_slim

    public class WSystemAbout : WMaster
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_resource;

        public Label st_1;

        public Button cb_ok;

        public Label st_copyright;

        public Label st_version;

        public Label st_title;

        public PictureBox p_icon;

        public Panel ln_top;

        public Panel ln_bottom;
        #endregion

        public WSystemAbout()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_bypass_security(true);
            //st_title.Text = StaticVariables.gnv_app.of_get_title();
            st_title.Text = StaticVariables.DisplayName.Remove(StaticVariables.DisplayName.Length - 9);
            //st_version.Text = StaticVariables.gnv_app.of_getversion();

            #region added by ylwang
            // get Version info from App.Config...
            //!string version = System.Configuration.ConfigurationManager.AppSettings["Version"].ToString();            
            //!string buildDate = System.Configuration.ConfigurationManager.AppSettings["BuildDate"].ToString();            
            //!dbName = ConfigurationManager.AppSettings["DBName"].ToString();
            #endregion

            //! changed to get information from AssemblyInfo and AppManager         
            //!version = NZPostOffice.Shared.Managers.AppManager.ApplicationVersion;
            //!buildDate = NZPostOffice.Shared.Managers.AppManager.ApplicationBuiltOn;

            st_version.Text = "Version "
                              + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()
                              + " (Built on " 
                              + string.Format("{0:dd-MMM-yyyy HH:mm}", 
                                           System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly().Location))
                              + ")";
            this.st_copyright.Text = "Copyright © 2021, all rights reserved";
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WSystemAbout));
            this.st_resource = new System.Windows.Forms.Label();
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_ok = new System.Windows.Forms.Button();
            this.st_copyright = new System.Windows.Forms.Label();
            this.st_version = new System.Windows.Forms.Label();
            this.st_title = new System.Windows.Forms.Label();
            this.p_icon = new System.Windows.Forms.PictureBox();
            this.ln_top = new System.Windows.Forms.Panel();
            this.ln_bottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.p_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // st_resource
            // 
            this.st_resource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.st_resource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_resource.Location = new System.Drawing.Point(53, 165);
            this.st_resource.Name = "st_resource";
            this.st_resource.Size = new System.Drawing.Size(182, 18);
            this.st_resource.TabIndex = 1;
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_1.Location = new System.Drawing.Point(70, 104);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(236, 45);
            this.st_1.TabIndex = 2;
            this.st_1.Text = "Please contact your nearest user support representive for information about this " +
                "application.";
            // 
            // cb_ok
            // 
            this.cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cb_ok.Location = new System.Drawing.Point(134, 186);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(65, 22);
            this.cb_ok.TabIndex = 1;
            this.cb_ok.Text = "&OK";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // st_copyright
            // 
            this.st_copyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.st_copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_copyright.Location = new System.Drawing.Point(74, 61);
            this.st_copyright.Name = "st_copyright";
            this.st_copyright.Size = new System.Drawing.Size(212, 18);
            this.st_copyright.TabIndex = 3;
            // 
            // st_version
            // 
            this.st_version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.st_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_version.Location = new System.Drawing.Point(74, 25);
            this.st_version.Name = "st_version";
            this.st_version.Size = new System.Drawing.Size(242, 37);
            this.st_version.TabIndex = 4;
            this.st_version.Text = "Version";
            // 
            // st_title
            // 
            this.st_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.st_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_title.Location = new System.Drawing.Point(74, 8);
            this.st_title.Name = "st_title";
            this.st_title.Size = new System.Drawing.Size(256, 14);
            this.st_title.TabIndex = 5;
            this.st_title.Text = "System Title";
            // 
            // p_icon
            // 
            this.p_icon.Image = ((System.Drawing.Image)(resources.GetObject("p_icon.Image")));
            this.p_icon.Location = new System.Drawing.Point(3, 4);
            this.p_icon.Name = "p_icon";
            this.p_icon.Size = new System.Drawing.Size(65, 36);
            this.p_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p_icon.TabIndex = 6;
            this.p_icon.TabStop = false;
            this.p_icon.DoubleClick += new System.EventHandler(this.p_icon_doubleclicked);
            // 
            // ln_top
            // 
            this.ln_top.BackColor = System.Drawing.Color.Black;
            this.ln_top.Location = new System.Drawing.Point(60, 95);
            this.ln_top.Name = "ln_top";
            this.ln_top.Size = new System.Drawing.Size(250, 2);
            this.ln_top.TabIndex = 7;
            // 
            // ln_bottom
            // 
            this.ln_bottom.BackColor = System.Drawing.Color.Black;
            this.ln_bottom.Location = new System.Drawing.Point(60, 150);
            this.ln_bottom.Name = "ln_bottom";
            this.ln_bottom.Size = new System.Drawing.Size(250, 2);
            this.ln_bottom.TabIndex = 8;
            // 
            // WSystemAbout
            // 
            this.ClientSize = new System.Drawing.Size(339, 217);
            this.Controls.Add(this.st_resource);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.st_copyright);
            this.Controls.Add(this.st_version);
            this.Controls.Add(this.st_title);
            this.Controls.Add(this.p_icon);
            this.Controls.Add(this.ln_top);
            this.Controls.Add(this.ln_bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WSystemAbout";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About System";
            this.Controls.SetChildIndex(this.ln_bottom, 0);
            this.Controls.SetChildIndex(this.ln_top, 0);
            this.Controls.SetChildIndex(this.p_icon, 0);
            this.Controls.SetChildIndex(this.st_title, 0);
            this.Controls.SetChildIndex(this.st_version, 0);
            this.Controls.SetChildIndex(this.st_copyright, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.st_resource, 0);
            ((System.ComponentModel.ISupportInitialize)(this.p_icon)).EndInit();
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

        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            this.Close(); // close(parent)
        }

        public virtual void p_icon_doubleclicked(object sender, EventArgs e)
        {
            // ole_1.activate ( inplace!)
            System.Timers.Timer timer = new System.Timers.Timer(0.5);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }  
        
        public virtual void timer_Elapsed(object send, System.Timers.ElapsedEventArgs args)
        {
            Random random = new Random();
            p_icon.SuspendLayout();
            p_icon.Location = new Point(random.Next(this.Width), random.Next(this.Height));
            p_icon.ResumeLayout();
        }
        #endregion
    }
}