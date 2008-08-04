using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WContractVehicalForm
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw /*DContractVehicalForm*/ dw_1;

        public Button cb_ok;

        public Button cb_cancel;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_1 = new URdsDw();
            dw_1.DataObject = new DContractVehicalForm();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_1);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Height = 186;
            this.Width = 394;
            // 
            // dw_1
            // 
           
            //? dw_1.vscrollbar = false;
           
            dw_1.TabIndex = 1;
            dw_1.Height = 118;
            dw_1.Width = 375;
            dw_1.Top = 4;
            dw_1.Left = 3;
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 3;
            cb_ok.Height = 22;
            cb_ok.Width = 54;
            cb_ok.Top = 129;
            cb_ok.Left = 126;
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 2;
            cb_cancel.Height = 22;
            cb_cancel.Width = 54;
            cb_cancel.Top = 129;
            cb_cancel.Left = 186;
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
