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
            this.SuspendLayout();
            this.st_1 = new Label();
            this.cb_ok = new UCb();
            this.cb_cancel = new UCb();
            this.tab_rates = new TabControl();
            this.dw_criteria = new URdsDw();
            //!this.dw_criteria.DataObject = new DFuelOverrideFields();
            Controls.Add(st_1);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(tab_rates);
            Controls.Add(dw_criteria);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "National Rates Overrides";
            this.Size = new System.Drawing.Size(272, 432);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.Text = "w_national_fuel_override";
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Location = new System.Drawing.Point(5, 390);
            st_1.Size = new System.Drawing.Size(130, 13);
            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "OK";
            cb_ok.TabIndex = 3;
            cb_ok.Location = new System.Drawing.Point(100, 360);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "Cancel";
            cb_cancel.TabIndex = 4;
            cb_cancel.Location = new System.Drawing.Point(182, 360);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // tab_rates
            // 
            tabpage_fuel = new TabPage();
            tabpage_other_rates = new TabPage();
            tab_rates.TabPages.Add(tabpage_fuel);
            tab_rates.TabPages.Add(tabpage_other_rates);
            tab_rates.SelectedIndex = 0;
            tab_rates.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_rates.TabIndex = 2;
            tab_rates.Location = new System.Drawing.Point(3, 54);
            tab_rates.Size = new System.Drawing.Size(256, 299);
            tab_rates.Selecting += new TabControlCancelEventHandler(tab_rates_selectionchanging);
            // 
            // tabpage_fuel
            // 
            description_10 = new Label();
            description_9 = new Label();
            description_8 = new Label();
            description_7 = new Label();
            description_6 = new Label();
            description_5 = new Label();
            description_4 = new Label();
            description_3 = new Label();
            description_2 = new Label();
            gb_fuel = new UGb();
            dw_details = new URdsDw();
            //!dw_details.DataObject = new DwNationalFuelOverride();
            description_1 = new Label();
            tabpage_fuel.Controls.Add(description_10);
            tabpage_fuel.Controls.Add(description_9);
            tabpage_fuel.Controls.Add(description_8);
            tabpage_fuel.Controls.Add(description_7);
            tabpage_fuel.Controls.Add(description_6);
            tabpage_fuel.Controls.Add(description_5);
            tabpage_fuel.Controls.Add(description_4);
            tabpage_fuel.Controls.Add(description_3);
            tabpage_fuel.Controls.Add(description_2);
            tabpage_fuel.Controls.Add(dw_details);
            tabpage_fuel.Controls.Add(description_1);
            tabpage_fuel.Controls.Add(gb_fuel);
            tabpage_fuel.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_fuel.Text = "Fuel Rates";
            tabpage_fuel.Name = tabpage_fuel.Text; //

            tabpage_fuel.Size = new System.Drawing.Size(248, 270);
            tabpage_fuel.Top = 25;
            tabpage_fuel.Left = 3;
            // 
            // description_10
            // 
            description_10.TabStop = false;
            description_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_10.ForeColor = System.Drawing.SystemColors.WindowText;
            description_10.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_10.Location = new System.Drawing.Point(16, 228);
            description_10.Size = new System.Drawing.Size(120, 16);
            // 
            // description_9
            // 
            description_9.TabStop = false;
            description_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_9.ForeColor = System.Drawing.SystemColors.WindowText;
            description_9.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_9.Location = new System.Drawing.Point(16, 205);
            description_9.Size = new System.Drawing.Size(120, 16);
            // 
            // description_8
            // 
            description_8.TabStop = false;
            description_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_8.BackColor = System.Drawing.SystemColors.Control;
            description_8.ForeColor = System.Drawing.SystemColors.WindowText;
            description_8.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_8.Location = new System.Drawing.Point(16, 182);  
            description_8.Size = new System.Drawing.Size(120, 16);
            // 
            // description_7
            // 
            description_7.TabStop = false;
            description_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_7.BackColor = System.Drawing.SystemColors.Control;
            description_7.ForeColor = System.Drawing.SystemColors.WindowText;
            description_7.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_7.Location = new System.Drawing.Point(16, 159);
            description_7.Size = new System.Drawing.Size(120, 16);
            // 
            // description_6
            // 
            description_6.TabStop = false;
            description_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_6.BackColor = System.Drawing.SystemColors.Control;
            description_6.ForeColor = System.Drawing.SystemColors.WindowText;
            description_6.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_6.Location = new System.Drawing.Point(16, 136);
            description_6.Size = new System.Drawing.Size(120, 16);
            // 
            // description_5
            // 
            description_5.TabStop = false;
            description_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_5.BackColor = System.Drawing.SystemColors.Control;
            description_5.ForeColor = System.Drawing.SystemColors.WindowText;
            description_5.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_5.Location = new System.Drawing.Point(16, 113);
            description_5.Size = new System.Drawing.Size(120, 16);
            // 
            // description_4
            // 
            description_4.TabStop = false;
            description_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_4.BackColor = System.Drawing.SystemColors.Control;
            description_4.ForeColor = System.Drawing.SystemColors.WindowText;
            description_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_4.Location = new System.Drawing.Point(16, 90);
            description_4.Size = new System.Drawing.Size(120, 16);
            // 
            // description_3
            // 
            description_3.TabStop = false;
            description_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_3.BackColor = System.Drawing.SystemColors.Control;
            description_3.ForeColor = System.Drawing.SystemColors.WindowText;
            description_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_3.Location = new System.Drawing.Point(16, 67);
            description_3.Size = new System.Drawing.Size(120, 16);
            // 
            // description_2
            // 
            description_2.TabStop = false;
            description_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_2.BackColor = System.Drawing.SystemColors.Control;
            description_2.ForeColor = System.Drawing.SystemColors.WindowText;
            description_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_2.Location = new System.Drawing.Point(16, 44);
            description_2.Size = new System.Drawing.Size(120, 16);
            // 
            // gb_fuel
            // 
            gb_fuel.Text = "";
            gb_fuel.TabIndex = 0;
            gb_fuel.Location = new System.Drawing.Point(8, 5);
            gb_fuel.Size = new System.Drawing.Size(232, 256);
            // 
            // dw_details
            // 
            //!dw_details.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_details.Location = new System.Drawing.Point(144, 17);
            dw_details.Size = new System.Drawing.Size(88, 224);
            dw_details.LostFocus += new EventHandler(dw_details_losefocus);
            //dw_details.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_details_constructor);
            // 
            // description_1
            // 
            description_1.TabStop = false;
            description_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            description_1.BackColor = System.Drawing.SystemColors.Control;
            description_1.ForeColor = System.Drawing.SystemColors.WindowText;
            description_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            description_1.Location = new System.Drawing.Point(9, 20);
            description_1.Size = new System.Drawing.Size(135, 16);
            // 
            // tabpage_other_rates
            // 
            dw_rates = new URdsDw();
            //!dw_rates.DataObject = new DNationalRatesOverrideFields();
            gb_other = new UGb();
            tabpage_other_rates.Controls.Add(dw_rates);
            tabpage_other_rates.Controls.Add(gb_other);
            tabpage_other_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_other_rates.Text = "Other Vehicle Rates";
            tabpage_other_rates.Name = tabpage_other_rates.Text;//

            tabpage_other_rates.Size=new System.Drawing.Size(248,270);
            tabpage_other_rates.Top = 25;
            tabpage_other_rates.Left = 3;
            // 
            // dw_rates
            // 
            //!dw_rates.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_rates.Location = new System.Drawing.Point(16, 19);
            dw_rates.Size = new System.Drawing.Size(208, 72);
            dw_rates.LostFocus += new EventHandler(dw_rates_losefocus);
            //dw_rates.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_rates_constructor);
            // 
            // gb_other
            // 
            gb_other.Text = "";
            gb_other.TabIndex = 1;
            gb_other.Location = new System.Drawing.Point(8, 5);
            gb_other.Size = new System.Drawing.Size(232, 256);
            // 
            // dw_criteria
            // 
            //!dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_criteria.TabIndex = 1;
            dw_criteria.Location = new System.Drawing.Point(7, 3);
            dw_criteria.Size = new System.Drawing.Size(239, 46);
            //dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);
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
