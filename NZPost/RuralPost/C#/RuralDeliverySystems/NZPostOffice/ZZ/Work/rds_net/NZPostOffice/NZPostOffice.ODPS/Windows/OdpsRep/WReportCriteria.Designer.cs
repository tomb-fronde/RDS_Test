using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
using System;
using NZPostOffice.ODPS.DataControls.Odps;
namespace NZPostOffice.ODPS.Windows.OdpsRep
{
    partial class WReportCriteria
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WReportCriteria";

            this.SuspendLayout();


            this.cb_ok = new UCb();
            this.cb_cancel = new UCb();

            this.dw_1 = new URdsDw();
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(dw_1);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.Text = "";
            this.Location = new System.Drawing.Point(318, 289);
            this.Size = new System.Drawing.Size(258, 193);
            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&Ok";
            cb_ok.TabIndex = 2;
            cb_ok.Size=new System.Drawing.Size(60, 23);
            cb_ok.Location = new System.Drawing.Point(8, 140);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "Ca&ncel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Size=new System.Drawing.Size(60,23);
            cb_cancel.Location = new System.Drawing.Point(78, 140);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);

            // 
            // dw_1
            // 
            dw_1.DataObject = new DwReportCriteria();
            dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_1.VerticalScroll.Visible = false;
            dw_1.TabIndex = 1;
            dw_1.Size = new System.Drawing.Size(247, 132);
            dw_1.Top = 8;
            dw_1.ItemChanged += new EventHandler(dw_1_itemchanged);
            this.MaximizeBox = false;
            this.ResumeLayout();
        }

        public UCb cb_ok;

        public UCb cb_cancel;

        public URdsDw dw_1;

    }
}