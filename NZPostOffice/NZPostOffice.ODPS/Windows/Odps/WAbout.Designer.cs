using System;
using System.Windows.Forms;

namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class WAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WAbout));
            this.p_about = new System.Windows.Forms.PictureBox();
            this.st_company = new System.Windows.Forms.Label();
            this.st_application = new System.Windows.Forms.Label();
            this.st_version = new System.Windows.Forms.Label();
            this.st_copyright = new System.Windows.Forms.Label();
            this.pb_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.p_about)).BeginInit();
            this.SuspendLayout();
            // 
            // p_about
            // 
            this.p_about.Image = ((System.Drawing.Image)(resources.GetObject("p_about.Image")));
            this.p_about.Location = new System.Drawing.Point(4, 7);
            this.p_about.Name = "p_about";
            this.p_about.Size = new System.Drawing.Size(96, 44);
            this.p_about.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p_about.TabIndex = 1;
            this.p_about.TabStop = false;
            this.p_about.DoubleClick += new System.EventHandler(this.p_about_doubleclicked);
            // 
            // st_company
            // 
            this.st_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.st_company.Location = new System.Drawing.Point(106, 12);
            this.st_company.Name = "st_company";
            this.st_company.Size = new System.Drawing.Size(260, 30);
            this.st_company.TabIndex = 5;
            // 
            // st_application
            // 
            this.st_application.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.st_application.Location = new System.Drawing.Point(106, 50);
            this.st_application.Name = "st_application";
            this.st_application.Size = new System.Drawing.Size(250, 30);
            this.st_application.TabIndex = 2;
            // 
            // st_version
            // 
            this.st_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.st_version.Location = new System.Drawing.Point(106, 88);
            this.st_version.Name = "st_version";
            this.st_version.Size = new System.Drawing.Size(250, 35);
            this.st_version.TabIndex = 3;
            // 
            // st_copyright
            // 
            this.st_copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.st_copyright.Location = new System.Drawing.Point(106, 125);
            this.st_copyright.Name = "st_copyright";
            this.st_copyright.Size = new System.Drawing.Size(250, 50);
            this.st_copyright.TabIndex = 4;
            // 
            // pb_ok
            // 
            this.pb_ok.Location = new System.Drawing.Point(153, 185);
            this.pb_ok.Name = "pb_ok";
            this.pb_ok.Size = new System.Drawing.Size(75, 23);
            this.pb_ok.TabIndex = 6;
            this.pb_ok.Text = "&Ok";
            this.pb_ok.Click += new System.EventHandler(this.pb_ok_Click);
            // 
            // WAbout
            // 
            this.ClientSize = new System.Drawing.Size(374, 214);
            this.Controls.Add(this.p_about);
            this.Controls.Add(this.st_application);
            this.Controls.Add(this.st_version);
            this.Controls.Add(this.st_copyright);
            this.Controls.Add(this.st_company);
            this.Controls.Add(this.pb_ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WAbout";
            this.Load += new System.EventHandler(this.WAbout_Load);
            this.Controls.SetChildIndex(this.pb_ok, 0);
            this.Controls.SetChildIndex(this.st_company, 0);
            this.Controls.SetChildIndex(this.st_copyright, 0);
            this.Controls.SetChildIndex(this.st_version, 0);
            this.Controls.SetChildIndex(this.st_application, 0);
            this.Controls.SetChildIndex(this.p_about, 0);
            ((System.ComponentModel.ISupportInitialize)(this.p_about)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private PictureBox p_about;
        private Label st_application;
        private Label st_version;
        private Label st_copyright;
        private Button pb_ok;
        private Label st_company;
        #endregion
    }
}