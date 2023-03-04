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
    // Display history of a vehicle allowance rate

    public class WVehicleAllowanceRatesHistory : FormBase   //WResponse
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public DVehicleAllowanceRatesHistory dw_vehicleallowancerateshistory;
        public Label st_1;
        public Button cb_close;

        public WVehicleAllowanceRatesHistory(int var_id)
        {
            this.InitializeComponent();
            //!this.of_bypass_security(true);
            this.st_1.Text = "WVehicleAllowanceRatesHistory";

            dw_vehicleallowancerateshistory.Retrieve(var_id);
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
            this.dw_vehicleallowancerateshistory = new NZPostOffice.RDSAdmin.DataControls.Security.DVehicleAllowanceRatesHistory();
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
            this.st_1.Text = "WVehicleAllowanceRatesHistory";
            // 
            // cb_close
            // 
            this.cb_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_close.Location = new System.Drawing.Point(1044, 267);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 4;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_vehicleallowancerateshistory
            // 
            this.dw_vehicleallowancerateshistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_vehicleallowancerateshistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dw_vehicleallowancerateshistory.CausesValidation = false;
            this.dw_vehicleallowancerateshistory.FilterString = "";
            this.dw_vehicleallowancerateshistory.Location = new System.Drawing.Point(12, 12);
            this.dw_vehicleallowancerateshistory.Name = "dw_vehicleallowancerateshistory";
            this.dw_vehicleallowancerateshistory.Size = new System.Drawing.Size(1107, 244);
            this.dw_vehicleallowancerateshistory.SortString = "";
            this.dw_vehicleallowancerateshistory.TabIndex = 1;
            // 
            // WVehicleAllowanceRatesHistory
            // 
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1127, 302);
            this.ControlBox = false;
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.dw_vehicleallowancerateshistory);
            this.Controls.Add(this.cb_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WVehicleAllowanceRatesHistory";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Vehicle Allowance Rates History";
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.dw_vehicleallowancerateshistory, 0);
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
