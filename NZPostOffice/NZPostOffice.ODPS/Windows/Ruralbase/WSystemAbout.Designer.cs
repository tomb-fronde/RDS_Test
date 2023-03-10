using System.Windows.Forms;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WSystemAbout
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.st_resource = new Label();
            this.st_1 = new Label();
            this.cb_ok = new Button();
            this.st_copyright = new Label();
            this.st_version = new Label();
            this.st_title = new Label();
            this.ln_top = new Panel();
            this.ln_bottom = new Panel();
            this.p_icon = new PictureBox();
            Controls.Add(st_resource);
            Controls.Add(st_1);
            Controls.Add(cb_ok);
            Controls.Add(st_copyright);
            Controls.Add(st_version);
            Controls.Add(st_title);
            Controls.Add(ln_top);
            Controls.Add(ln_bottom);
            Controls.Add(p_icon);
            this.Text = "About System";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(347, 244);
            this.Location = new System.Drawing.Point(149, 120);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 
            // st_resource
            // 
            st_resource.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_resource.TabStop = false;
            st_resource.Size = new System.Drawing.Size(182, 18);
            st_resource.Location = new System.Drawing.Point(53, 165);
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_1.TabStop = false;
            st_1.Text = "Please contact your nearest user support representive for information about this application.";
            st_1.Size = new System.Drawing.Size(236, 45);
            st_1.Location = new System.Drawing.Point(70, 104);
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 1;
            cb_ok.Size = new System.Drawing.Size(65, 22);
            cb_ok.Location = new System.Drawing.Point(134, 186);
            // cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // st_copyright
            // 
            st_copyright.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_copyright.TabStop = false;
            st_copyright.Text = "Copyright © 2014, all rights reserved";
            st_copyright.Size = new System.Drawing.Size(212, 18);
            st_copyright.Location = new System.Drawing.Point(80, 61);
            // 
            // st_version
            // 
            st_version.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_version.TabStop = false;
            st_version.Text = "Version";
            st_version.Size = new System.Drawing.Size(250, 37);
            st_version.Location = new System.Drawing.Point(80, 25);
            // 
            // st_title
            // 
            st_title.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_title.TabStop = false;
            st_title.Text = "System Title";
            st_title.Size = new System.Drawing.Size(250, 14);
            st_title.Location = new System.Drawing.Point(80, 8);
            // 
            // ln_top
            // 
            //ln_top.LineThickness = 8;
            //ln_top.EndY = 93;
            //ln_top.EndX = 317;
            //ln_top.BeginY = 93;
            //ln_top.BeginX = 50;
            ln_top.Location = new System.Drawing.Point(50, 90);
            ln_top.Height = 1;
            ln_top.BackColor = System.Drawing.Color.Black;
            ln_top.Enabled = false;
            // 
            // ln_bottom
            // 
            //ln_bottom.LineThickness = 8;
            //ln_bottom.EndY = 154;
            //ln_bottom.EndX = 319;
            //ln_bottom.BeginY = 154;
            //ln_bottom.BeginX = 52;
            ln_bottom.Enabled = false;
            // 
            // p_icon
            // 
            p_icon.TabStop = false;
            p_icon.Image = global::NZPostOffice.Shared.Properties.Resources.Logo_slim;
            p_icon.SizeMode = PictureBoxSizeMode.CenterImage;
            p_icon.Size = new System.Drawing.Size(64, 48);
            p_icon.Location = new System.Drawing.Point(3, 4);
            // p_icon.DoubleClick += new EventHandler(p_icon_doubleclicked);
            this.ResumeLayout();
        }

        private Label st_resource;

        private Label st_1;

        private Button cb_ok;

        private Label st_copyright;

        private Label st_version;

        private Label st_title;

        private PictureBox p_icon;

        public Panel ln_top;

        public Panel ln_bottom;
    }
}