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
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(382, 241);
            this.Load += new EventHandler(WAbout_Load);
            // 
            // p_about
            // 
            p_about = new PictureBox();
            p_about.Image = global::NZPostOffice.Shared.Properties.Resources.Logo;
            p_about.SizeMode = PictureBoxSizeMode.StretchImage;
            p_about.Size = new System.Drawing.Size(63, 44);
            p_about.Location = new System.Drawing.Point(4, 7);
            p_about.DoubleClick += new EventHandler(p_about_doubleclicked);

            // 
            // st_company
            // 
            st_company = new Label();
            st_company.Location = new System.Drawing.Point(106, 12);
            st_company.Size = new System.Drawing.Size(260, 30);
            st_company.Font = new System.Drawing.Font("Ms Sans Serif ", 13, System.Drawing.FontStyle.Bold);

            // 
            // st_application
            // 
            st_application = new Label();
            st_application.Location = new System.Drawing.Point(106, 50);
            st_application.Size = new System.Drawing.Size(250, 30);
            st_application.Font = new System.Drawing.Font("Ms Sans Serif ", 10);

            // 
            // st_version
            // 
            st_version = new Label();
            st_version.Location = new System.Drawing.Point(106, 88);
            st_version.Size = new System.Drawing.Size(250, 35);
            st_version.Font = new System.Drawing.Font("Ms Sans Serif ", 10);

            // 
            // st_copyright
            // 
            st_copyright = new Label();
            st_copyright.Location = new System.Drawing.Point(106, 125);
            st_copyright.Size = new System.Drawing.Size(250, 50);
            st_copyright.Font = new System.Drawing.Font("Ms Sans Serif ", 10);

            // 
            // pb_ok
            // 
            pb_ok = new Button();
            pb_ok.Text = "&Ok";
            pb_ok.Location = new System.Drawing.Point(153, 185);
            pb_ok.Click += new EventHandler(pb_ok_Click);

            this.Controls.Add(p_about);
            this.Controls.Add(st_application);
            this.Controls.Add(st_version);
            this.Controls.Add(st_copyright);
            this.Controls.Add(st_company);
            this.Controls.Add(pb_ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout();
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