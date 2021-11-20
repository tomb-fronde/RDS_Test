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

namespace NZPostOffice.RDS.Windows.Ruralbase
{
    public partial class WPassword : WMaster
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public TextBox sle_1;

        public TextBox sle_2;

        public Button cb_2;

        public Button cb_1;
        #endregion

        public WPassword()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public override void open()
        {
            base.open();
            sle_1.Focus();
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.sle_1 = new TextBox();
            this.sle_2 = new TextBox();
            this.cb_2 = new Button();
            this.cb_1 = new Button();
            Controls.Add(sle_1);
            Controls.Add(sle_2);
            Controls.Add(cb_2);
            Controls.Add(cb_1);
            this.Text = "Password Encryptor";
            this.ControlBox = true;
            this.Size = new Size(297, 94);
            this.Location = new Point(318, 329);
            // 
            // sle_1
            // 
            sle_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_1.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_1.TabIndex = 3;
            sle_1.Size = new Size(223, 23);
            sle_1.Location = new Point(5, 6);
            // 
            // sle_2
            // 
            sle_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_2.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_2.TabIndex = 1;
            sle_2.Size = new Size(222, 23);
            sle_2.Location = new Point(5, 37);
            // 
            // cb_2
            // 
            cb_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_2.Text = "Decrypt";
            cb_2.TabIndex = 2;
            cb_2.Size = new Size(54, 27);
            cb_2.Location = new Point(232, 35);
            cb_2.Click += new EventHandler(cb_2_clicked);
            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_1.Text = "Encrypt";
            cb_1.TabIndex = 3;
            cb_1.Size = new Size(54, 27);
            cb_1.Location = new Point(232, 4);
            cb_1.Click += new EventHandler(cb_1_clicked);
            this.ResumeLayout();
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
        public virtual void cb_2_clicked(object sender, EventArgs e)
        {
            string ls_pass;
            ls_pass = sle_1.Text;
            sle_2.Text = StaticFunctions.f_decrypt(ls_pass);
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            string ls_pass;
            ls_pass = sle_1.Text.ToUpper();
            sle_2.Text = StaticFunctions.f_encrypt(ls_pass);
        }
        #endregion
    }
}