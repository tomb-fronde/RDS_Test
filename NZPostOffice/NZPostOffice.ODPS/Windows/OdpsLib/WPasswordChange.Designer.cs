using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.DataControls.OdpsLib;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class WPasswordChange
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
            this.dw_1 = new URdsDw();
            //!this.dw_1.DataObject = new DPassword();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_1);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Password Change";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(226, 142);
            this.Location = new System.Drawing.Point(10, 10);
            
            // 
            // dw_1
            // 
            dw_1.TabIndex = 1;
            dw_1.Size = new System.Drawing.Size(212, 85);
     
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Size = new System.Drawing.Size(54, 22);
            cb_ok.Location = new System.Drawing.Point(50, 88);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(111, 88);
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            this.ResumeLayout();
        }

        public URdsDw dw_1;
        public Button cb_ok;
        public Button cb_cancel;

        #endregion
    }
}