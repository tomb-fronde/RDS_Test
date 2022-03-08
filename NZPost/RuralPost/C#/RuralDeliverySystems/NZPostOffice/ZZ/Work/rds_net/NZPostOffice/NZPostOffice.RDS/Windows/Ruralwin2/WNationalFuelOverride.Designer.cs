using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    partial class WNationalFuelOverride
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_1;

        public UCb cb_ok;

        public UCb cb_cancel;

        public TabControl tab_rates;

        public TabPage tabpage_fuel;

        public Label description_10;

        public Label description_9;

        public Label description_8;

        public Label description_7;

        public Label description_6;

        public Label description_5;

        public Label description_4;

        public Label description_3;

        public Label description_2;

        public UGb gb_fuel;

        public URdsDw dw_details;

        public Label description_1;

        public TabPage tabpage_other_rates;

        public URdsDw dw_rates;

        public UGb gb_other;

        public URdsDw dw_criteria;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_ok = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_cancel = new NZPostOffice.Shared.VisualComponents.UCb();
            this.tab_rates = new System.Windows.Forms.TabControl();
            this.tabpage_fuel = new System.Windows.Forms.TabPage();
            this.description_10 = new System.Windows.Forms.Label();
            this.description_9 = new System.Windows.Forms.Label();
            this.description_8 = new System.Windows.Forms.Label();
            this.description_7 = new System.Windows.Forms.Label();
            this.description_6 = new System.Windows.Forms.Label();
            this.description_5 = new System.Windows.Forms.Label();
            this.description_4 = new System.Windows.Forms.Label();
            this.description_3 = new System.Windows.Forms.Label();
            this.description_2 = new System.Windows.Forms.Label();
            this.dw_details = new NZPostOffice.RDS.Controls.URdsDw();
            this.description_1 = new System.Windows.Forms.Label();
            this.gb_fuel = new NZPostOffice.Shared.VisualComponents.UGb();
            this.tabpage_other_rates = new System.Windows.Forms.TabPage();
            this.dw_rates = new NZPostOffice.RDS.Controls.URdsDw();
            this.gb_other = new NZPostOffice.Shared.VisualComponents.UGb();
            this.dw_criteria = new NZPostOffice.RDS.Controls.URdsDw();
            this.tab_rates.SuspendLayout();
            this.tabpage_fuel.SuspendLayout();
            this.tabpage_other_rates.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(5, 390);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(130, 13);
            this.st_1.TabIndex = 1;
            this.st_1.Text = "w_national_fuel_override";
            // 
            // cb_ok
            // 
            this.cb_ok.Location = new System.Drawing.Point(100, 360);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(75, 23);
            this.cb_ok.TabIndex = 3;
            this.cb_ok.Text = "OK";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_cancel.Location = new System.Drawing.Point(182, 360);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 4;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // tab_rates
            // 
            this.tab_rates.Controls.Add(this.tabpage_fuel);
            this.tab_rates.Controls.Add(this.tabpage_other_rates);
            this.tab_rates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tab_rates.Location = new System.Drawing.Point(3, 54);
            this.tab_rates.Name = "tab_rates";
            this.tab_rates.SelectedIndex = 0;
            this.tab_rates.Size = new System.Drawing.Size(256, 299);
            this.tab_rates.TabIndex = 2;
            this.tab_rates.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tab_rates_selectionchanging);
            // 
            // tabpage_fuel
            // 
            this.tabpage_fuel.Controls.Add(this.description_10);
            this.tabpage_fuel.Controls.Add(this.description_9);
            this.tabpage_fuel.Controls.Add(this.description_8);
            this.tabpage_fuel.Controls.Add(this.description_7);
            this.tabpage_fuel.Controls.Add(this.description_6);
            this.tabpage_fuel.Controls.Add(this.description_5);
            this.tabpage_fuel.Controls.Add(this.description_4);
            this.tabpage_fuel.Controls.Add(this.description_3);
            this.tabpage_fuel.Controls.Add(this.description_2);
            this.tabpage_fuel.Controls.Add(this.dw_details);
            this.tabpage_fuel.Controls.Add(this.description_1);
            this.tabpage_fuel.Controls.Add(this.gb_fuel);
            this.tabpage_fuel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_fuel.Location = new System.Drawing.Point(4, 22);
            this.tabpage_fuel.Name = this.tabpage_fuel.Text;
            this.tabpage_fuel.Size = new System.Drawing.Size(248, 273);
            this.tabpage_fuel.TabIndex = 0;
            this.tabpage_fuel.Text = "Fuel Rates";
            // 
            // description_10
            // 
            this.description_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_10.Location = new System.Drawing.Point(16, 228);
            this.description_10.Name = "description_10";
            this.description_10.Size = new System.Drawing.Size(120, 16);
            this.description_10.TabIndex = 0;
            this.description_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_9
            // 
            this.description_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_9.Location = new System.Drawing.Point(16, 205);
            this.description_9.Name = "description_9";
            this.description_9.Size = new System.Drawing.Size(120, 16);
            this.description_9.TabIndex = 1;
            this.description_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_8
            // 
            this.description_8.BackColor = System.Drawing.SystemColors.Control;
            this.description_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_8.Location = new System.Drawing.Point(16, 182);
            this.description_8.Name = "description_8";
            this.description_8.Size = new System.Drawing.Size(120, 16);
            this.description_8.TabIndex = 2;
            this.description_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_7
            // 
            this.description_7.BackColor = System.Drawing.SystemColors.Control;
            this.description_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_7.Location = new System.Drawing.Point(16, 159);
            this.description_7.Name = "description_7";
            this.description_7.Size = new System.Drawing.Size(120, 16);
            this.description_7.TabIndex = 3;
            this.description_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_6
            // 
            this.description_6.BackColor = System.Drawing.SystemColors.Control;
            this.description_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_6.Location = new System.Drawing.Point(16, 136);
            this.description_6.Name = "description_6";
            this.description_6.Size = new System.Drawing.Size(120, 16);
            this.description_6.TabIndex = 4;
            this.description_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_5
            // 
            this.description_5.BackColor = System.Drawing.SystemColors.Control;
            this.description_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_5.Location = new System.Drawing.Point(16, 113);
            this.description_5.Name = "description_5";
            this.description_5.Size = new System.Drawing.Size(120, 16);
            this.description_5.TabIndex = 5;
            this.description_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_4
            // 
            this.description_4.BackColor = System.Drawing.SystemColors.Control;
            this.description_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_4.Location = new System.Drawing.Point(16, 90);
            this.description_4.Name = "description_4";
            this.description_4.Size = new System.Drawing.Size(120, 16);
            this.description_4.TabIndex = 6;
            this.description_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_3
            // 
            this.description_3.BackColor = System.Drawing.SystemColors.Control;
            this.description_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_3.Location = new System.Drawing.Point(16, 67);
            this.description_3.Name = "description_3";
            this.description_3.Size = new System.Drawing.Size(120, 16);
            this.description_3.TabIndex = 7;
            this.description_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // description_2
            // 
            this.description_2.BackColor = System.Drawing.SystemColors.Control;
            this.description_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_2.Location = new System.Drawing.Point(16, 44);
            this.description_2.Name = "description_2";
            this.description_2.Size = new System.Drawing.Size(120, 16);
            this.description_2.TabIndex = 8;
            this.description_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dw_details
            // 
            this.dw_details.DataObject = null;
            this.dw_details.FireConstructor = false;
            this.dw_details.Location = new System.Drawing.Point(144, 17);
            this.dw_details.Name = "dw_details";
            this.dw_details.Size = new System.Drawing.Size(88, 224);
            this.dw_details.TabIndex = 9;
            this.dw_details.LostFocus += new System.EventHandler(this.dw_details_losefocus);
            // 
            // description_1
            // 
            this.description_1.BackColor = System.Drawing.SystemColors.Control;
            this.description_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.description_1.Location = new System.Drawing.Point(9, 20);
            this.description_1.Name = "description_1";
            this.description_1.Size = new System.Drawing.Size(135, 16);
            this.description_1.TabIndex = 10;
            this.description_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_fuel
            // 
            this.gb_fuel.Location = new System.Drawing.Point(8, 5);
            this.gb_fuel.Name = "gb_fuel";
            this.gb_fuel.Size = new System.Drawing.Size(232, 256);
            this.gb_fuel.TabIndex = 0;
            this.gb_fuel.TabStop = false;
            // 
            // tabpage_other_rates
            // 
            this.tabpage_other_rates.Controls.Add(this.dw_rates);
            this.tabpage_other_rates.Controls.Add(this.gb_other);
            this.tabpage_other_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_other_rates.Location = new System.Drawing.Point(4, 22);
            this.tabpage_other_rates.Name = this.tabpage_other_rates.Text;
            this.tabpage_other_rates.Size = new System.Drawing.Size(248, 273);
            this.tabpage_other_rates.TabIndex = 1;
            this.tabpage_other_rates.Text = "Other Vehicle Rates";
            // 
            // dw_rates
            // 
            this.dw_rates.DataObject = null;
            this.dw_rates.FireConstructor = false;
            this.dw_rates.Location = new System.Drawing.Point(16, 19);
            this.dw_rates.Name = "dw_rates";
            this.dw_rates.Size = new System.Drawing.Size(208, 72);
            this.dw_rates.TabIndex = 0;
            this.dw_rates.LostFocus += new System.EventHandler(this.dw_rates_losefocus);
            // 
            // gb_other
            // 
            this.gb_other.Location = new System.Drawing.Point(8, 5);
            this.gb_other.Name = "gb_other";
            this.gb_other.Size = new System.Drawing.Size(232, 256);
            this.gb_other.TabIndex = 1;
            this.gb_other.TabStop = false;
            // 
            // dw_criteria
            // 
            this.dw_criteria.DataObject = null;
            this.dw_criteria.FireConstructor = false;
            this.dw_criteria.Location = new System.Drawing.Point(7, 3);
            this.dw_criteria.Name = "dw_criteria";
            this.dw_criteria.Size = new System.Drawing.Size(239, 46);
            this.dw_criteria.TabIndex = 1;
            // 
            // WNationalFuelOverride
            // 
            this.AcceptButton = this.cb_ok;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(256, 413);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.tab_rates);
            this.Controls.Add(this.dw_criteria);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WNationalFuelOverride";
            this.Text = "National Rates Overrides";
            this.Controls.SetChildIndex(this.dw_criteria, 0);
            this.Controls.SetChildIndex(this.tab_rates, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.tab_rates.ResumeLayout(false);
            this.tabpage_fuel.ResumeLayout(false);
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
