using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin2;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralwin2;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    partial class WContractRate2001
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_1;

        public TabControl tab_override_rates;

        public TabPage tabpage_vehicle_rates;

        public URdsDw dw_vehicle_rates;

        public TabPage tabpage_non_vehicle_rates;

        public URdsDw dw_non_vehicle_rates;

        public TabPage tabpage_other_rates;

        public URdsDw dw_other_rates;

        public Button cb_ok;

        public Button cb_cancel;

        public Button cb_newrates;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.st_1 = new System.Windows.Forms.Label();
            this.tab_override_rates = new System.Windows.Forms.TabControl();
            this.tabpage_vehicle_rates = new System.Windows.Forms.TabPage();
            this.dw_vehicle_rates = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_non_vehicle_rates = new System.Windows.Forms.TabPage();
            this.dw_non_vehicle_rates = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_other_rates = new System.Windows.Forms.TabPage();
            this.dw_other_rates = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.cb_newrates = new System.Windows.Forms.Button();
            this.tab_override_rates.SuspendLayout();
            this.tabpage_vehicle_rates.SuspendLayout();
            this.tabpage_non_vehicle_rates.SuspendLayout();
            this.tabpage_other_rates.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_1.ForeColor = System.Drawing.Color.Gray;
            this.st_1.Location = new System.Drawing.Point(119, 358);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(117, 16);
            this.st_1.TabIndex = 1;
            this.st_1.Text = "WContract _rate2001";
            this.st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab_override_rates
            // 
            this.tab_override_rates.Controls.Add(this.tabpage_vehicle_rates);
            this.tab_override_rates.Controls.Add(this.tabpage_non_vehicle_rates);
            this.tab_override_rates.Controls.Add(this.tabpage_other_rates);
            this.tab_override_rates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tab_override_rates.Location = new System.Drawing.Point(7, 6);
            this.tab_override_rates.Name = "tab_override_rates";
            this.tab_override_rates.SelectedIndex = 0;
            this.tab_override_rates.Size = new System.Drawing.Size(355, 340);
            this.tab_override_rates.TabIndex = 1;
            this.tab_override_rates.SelectedIndexChanged += new System.EventHandler(this.tab_override_rates_selectionchanged);
            // 
            // tabpage_vehicle_rates
            // 
            this.tabpage_vehicle_rates.Controls.Add(this.dw_vehicle_rates);
            this.tabpage_vehicle_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_vehicle_rates.Location = new System.Drawing.Point(4, 22);
            this.tabpage_vehicle_rates.Name = this.tabpage_vehicle_rates.Text;
            this.tabpage_vehicle_rates.Size = new System.Drawing.Size(347, 314);
            this.tabpage_vehicle_rates.TabIndex = 0;
            this.tabpage_vehicle_rates.Text = "Vehicle Rates";
            // 
            // dw_vehicle_rates
            // 
            this.dw_vehicle_rates.DataObject = null;
            this.dw_vehicle_rates.FireConstructor = false;
            this.dw_vehicle_rates.Location = new System.Drawing.Point(3, 5);
            this.dw_vehicle_rates.Name = "dw_vehicle_rates";
            this.dw_vehicle_rates.Size = new System.Drawing.Size(352, 325);
            this.dw_vehicle_rates.TabIndex = 2;
            // 
            // tabpage_non_vehicle_rates
            // 
            this.tabpage_non_vehicle_rates.Controls.Add(this.dw_non_vehicle_rates);
            this.tabpage_non_vehicle_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_non_vehicle_rates.Location = new System.Drawing.Point(4, 22);
            this.tabpage_non_vehicle_rates.Name = this.tabpage_non_vehicle_rates.Text;
            this.tabpage_non_vehicle_rates.Size = new System.Drawing.Size(347, 314);
            this.tabpage_non_vehicle_rates.TabIndex = 1;
            this.tabpage_non_vehicle_rates.Text = "Non Vehicle Rates";
            // 
            // dw_non_vehicle_rates
            // 
            this.dw_non_vehicle_rates.DataObject = null;
            this.dw_non_vehicle_rates.FireConstructor = false;
            this.dw_non_vehicle_rates.Location = new System.Drawing.Point(1, 11);
            this.dw_non_vehicle_rates.Name = "dw_non_vehicle_rates";
            this.dw_non_vehicle_rates.Size = new System.Drawing.Size(296, 256);
            this.dw_non_vehicle_rates.TabIndex = 2;
            // 
            // tabpage_other_rates
            // 
            this.tabpage_other_rates.Controls.Add(this.dw_other_rates);
            this.tabpage_other_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_other_rates.Location = new System.Drawing.Point(4, 22);
            this.tabpage_other_rates.Name = "tabpage_other_rates";
            this.tabpage_other_rates.Size = new System.Drawing.Size(347, 314);
            this.tabpage_other_rates.TabIndex = 2;
            this.tabpage_other_rates.Text = "Other Rates";
            this.tabpage_other_rates.Visible = false;
            // 
            // dw_other_rates
            // 
            this.dw_other_rates.DataObject = null;
            this.dw_other_rates.FireConstructor = false;
            this.dw_other_rates.Location = new System.Drawing.Point(5, 7);
            this.dw_other_rates.Name = "dw_other_rates";
            this.dw_other_rates.Size = new System.Drawing.Size(382, 315);
            this.dw_other_rates.TabIndex = 2;
            // 
            // cb_ok
            // 
            this.cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_ok.Location = new System.Drawing.Point(241, 350);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(57, 22);
            this.cb_ok.TabIndex = 2;
            this.cb_ok.Text = "&Ok";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(303, 350);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(57, 22);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "&Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // cb_newrates
            // 
            this.cb_newrates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_newrates.Location = new System.Drawing.Point(5, 350);
            this.cb_newrates.Name = "cb_newrates";
            this.cb_newrates.Size = new System.Drawing.Size(112, 22);
            this.cb_newrates.TabIndex = 4;
            this.cb_newrates.Text = "&New Override Rates";
            this.cb_newrates.Click += new System.EventHandler(this.cb_newrates_clicked);
            // 
            // WContractRate2001
            // 
            this.AcceptButton = this.cb_ok;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(372, 378);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.tab_override_rates);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.cb_newrates);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WContractRate2001";
            this.Tag = "ComponentName=Renewal Rates;";
            this.Text = "Override Rates";
            this.Controls.SetChildIndex(this.cb_newrates, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.tab_override_rates, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.tab_override_rates.ResumeLayout(false);
            this.tabpage_vehicle_rates.ResumeLayout(false);
            this.tabpage_non_vehicle_rates.ResumeLayout(false);
            this.tabpage_other_rates.ResumeLayout(false);
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
    }
}
