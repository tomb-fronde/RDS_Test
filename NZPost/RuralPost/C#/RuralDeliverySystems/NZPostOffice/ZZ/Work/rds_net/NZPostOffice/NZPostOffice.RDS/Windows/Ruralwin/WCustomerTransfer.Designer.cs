using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WCustomerTransfer
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw /*DCustomerTransfer*/ dw_transfer;

        public Label st_1;

        public Button cb_transfer;

        public Button cb_cancel;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_transfer = new URdsDw();
            //!dw_transfer.DataObject = new DCustomerTransfer();
            this.st_1 = new Label();
            this.cb_transfer = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_transfer);
            Controls.Add(st_1);
            Controls.Add(cb_transfer);
            Controls.Add(cb_cancel);
            this.Text = "Customer Contract Transfer";
            this.Height = 124;
            this.Width = 221;
            this.Top = 155;
            this.Left = 213;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // 
            // dw_transfer
            // 
            //?dw_transfer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_transfer.TabIndex = 1;
            dw_transfer.Height = 25;
            dw_transfer.Width = 175;
            dw_transfer.Top = 29;
            dw_transfer.Left = 24;
            dw_transfer.LostFocus += new EventHandler(dw_transfer_losefocus);
            //dw_transfer.URdsDwEditChanged +=new NZPostOffice.RDS.Controls.EventDelegate(dw_transfer_editchanged);
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_1.Text = "#### Customers exists for contract #####.";

            //?st_1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Height = 18;
            st_1.Width = 209;
            st_1.Top = 8;
            st_1.Left = 7;
            // 
            // cb_transfer
            // 
            cb_transfer.Text = "Transfer";
            cb_transfer.Enabled = false;
            cb_transfer.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_transfer.TabIndex = 2;
            cb_transfer.Height = 27;
            cb_transfer.Width = 53;
            cb_transfer.Top = 64;
            cb_transfer.Left = 42;
            cb_transfer.Click += new EventHandler(cb_transfer_clicked);
            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 3;
            cb_cancel.Height = 27;
            cb_cancel.Width = 53;
            cb_cancel.Top = 64;
            cb_cancel.Left = 111;
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
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

    }
}
