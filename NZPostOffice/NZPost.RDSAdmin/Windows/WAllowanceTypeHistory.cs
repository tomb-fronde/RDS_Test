using System;
using System.Data;
using System.Windows.Forms;
using NZPostOffice.Shared.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDSAdmin.DataControls.Security;
using NZPostOffice.RDSAdmin.Entity.Security;
using NZPostOffice.RDSAdmin.DataService;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDSAdmin
{
    // TJB  Allowances  1-June-2021: New
    // Display history of an allowance type

    public class WAllowanceTypeHistory : WResponse
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public DAllowanceTypeHistory dw_allowancetypehistory;
        public Label st_1;
        public Button cb_close;

        public WAllowanceTypeHistory(int alt_key)
        {
            this.InitializeComponent();
            //!this.of_bypass_security(true);
            this.st_1.Text = "WAllowanceTypeHistory";

            dw_allowancetypehistory.Retrieve(alt_key);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
        }

        public override void close()
        {
            base.close();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_close = new System.Windows.Forms.Button();
            this.dw_allowancetypehistory = new NZPostOffice.RDSAdmin.DataControls.Security.DAllowanceTypeHistory();
            this.SuspendLayout();
            // 
            // st_1
            // 
            this.st_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Arial", 7F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(8, 284);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(177, 13);
            this.st_1.TabIndex = 9;
            this.st_1.Text = "WAllowanceTypeHistory";
            // 
            // cb_close
            // 
            this.cb_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_close.Location = new System.Drawing.Point(713, 267);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 4;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_allowancetypehistory
            // 
            this.dw_allowancetypehistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_allowancetypehistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dw_allowancetypehistory.FilterString = "";
            this.dw_allowancetypehistory.Location = new System.Drawing.Point(12, 12);
            this.dw_allowancetypehistory.Name = "dw_allowancetypehistory";
            this.dw_allowancetypehistory.Size = new System.Drawing.Size(776, 244);
            this.dw_allowancetypehistory.SortString = "";
            this.dw_allowancetypehistory.TabIndex = 1;
            // 
            // WAllowanceTypeHistory
            // 
            this.ClientSize = new System.Drawing.Size(796, 302);
            this.ControlBox = false;
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.dw_allowancetypehistory);
            this.Controls.Add(this.cb_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WAllowanceTypeHistory";
            this.Text = "Allowance Type History";
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.dw_allowancetypehistory, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
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

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
