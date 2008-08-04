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

namespace NZPostOffice.RDS.Windows.Ruralwin
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
            this.SuspendLayout();
            this.st_1 = new Label();
            this.tab_override_rates = new TabControl();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            this.cb_newrates = new Button();
            Controls.Add(st_1);
            Controls.Add(tab_override_rates);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(cb_newrates);
           
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Override Rates";
            this.Height = 412;
            this.Width = 380;
            this.Top = 55;
            this.Left = 46;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Tag = "ComponentName=Renewal Rates;";
           
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_1.Text = "w_contract _rate2001";
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Height = 32;
            st_1.Width = 64;
            st_1.Top = 350;
            st_1.Left = 128;
           
            // 
            // tab_override_rates
            // 
            this.tabpage_vehicle_rates = new TabPage();
            this.tabpage_non_vehicle_rates = new TabPage();
            this.tabpage_other_rates = new TabPage();
            tab_override_rates.Controls.Add(tabpage_vehicle_rates);
            tab_override_rates.Controls.Add(tabpage_non_vehicle_rates);
            tab_override_rates.Controls.Add(tabpage_other_rates);
            tab_override_rates.SelectedIndex = 0;
            tab_override_rates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_override_rates.TabIndex = 1;
            tab_override_rates.Height = 340;
            tab_override_rates.Width = 355;
            tab_override_rates.Top = 6;
            tab_override_rates.Left = 7;
            tab_override_rates.SelectedIndexChanged += new EventHandler(tab_override_rates_selectionchanged);
         
            // 
            // tabpage_vehicle_rates
            // 
            dw_vehicle_rates = new URdsDw();
            dw_vehicle_rates.DataObject = new DVehicleOverrideRates();
            tabpage_vehicle_rates.Controls.Add(dw_vehicle_rates);
            tabpage_vehicle_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_vehicle_rates.Text = "Vehicle Rates";
            tabpage_vehicle_rates.Name = tabpage_vehicle_rates.Text;//

            tabpage_vehicle_rates.Size = new System.Drawing.Size(355, 332);
            tabpage_vehicle_rates.Top = 25;
            tabpage_vehicle_rates.Left = 3;
            
            // 
            // dw_vehicle_rates
            // 
            dw_vehicle_rates.TabIndex = 2;
            dw_vehicle_rates.Size = new System.Drawing.Size(352, 325);
            dw_vehicle_rates.Top = 5;
            dw_vehicle_rates.Location = new System.Drawing.Point(3, 5);
            
            dw_vehicle_rates.DataObject.GotFocus += new EventHandler(dw_vehicle_rates_getfocus);
            ((DVehicleOverrideRates)dw_vehicle_rates.DataObject).TextBoxLostFocus += new EventHandler(dw_vehicle_rates_itemchanged);
            
            //dw_vehicle_rates.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_vehicle_constructor);
            //dw_vehicle_rates.PfcUpdate +=new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_vehicle_rates_pfc_update);
            //dw_vehicle_rates.PfcValidation += new UserEventDelegate1(dw_vehicle_rates_pfc_validation);
          
            // 
            // tabpage_non_vehicle_rates
            // 
            dw_non_vehicle_rates = new URdsDw();
            dw_non_vehicle_rates.DataObject = new DNonVehicleOverrideRates();
            tabpage_non_vehicle_rates.Controls.Add(dw_non_vehicle_rates);
            tabpage_non_vehicle_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_non_vehicle_rates.Text = "Non Vehicle Rates";
            tabpage_non_vehicle_rates.Name = tabpage_non_vehicle_rates.Text;//

            tabpage_non_vehicle_rates.Size = new System.Drawing.Size(313, 332);
            tabpage_non_vehicle_rates.Top = 25;
            tabpage_non_vehicle_rates.Left = 3;
         
            // 
            // dw_non_vehicle_rates
            // 
            dw_non_vehicle_rates.VerticalScroll.Visible = false;
            dw_non_vehicle_rates.TabIndex = 2;
 
            dw_non_vehicle_rates.Size = new System.Drawing.Size(296, 256);
            dw_non_vehicle_rates.Location = new System.Drawing.Point(1, 11);    
            
            dw_non_vehicle_rates.DataObject.GotFocus += new EventHandler(dw_non_vehicle_rates_getfocus);
            dw_non_vehicle_rates.ItemChanged+= new EventHandler(dw_non_vehicle_rates_itemchanged);

            //dw_non_vehicle_rates.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_non_vehicle_ratesconstructor);
            //dw_non_vehicle_rates.PfcPostUpdate +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_non_vehicle_rates_pfc_postupdate);

            // 
            // tabpage_other_rates
            // 
            dw_other_rates = new URdsDw();
            dw_other_rates.DataObject = new DOtherOverrideRates();
            tabpage_other_rates.Controls.Add(dw_other_rates);
            tabpage_other_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_other_rates.Text = "Other Rates";
            tabpage_other_rates.Size = new System.Drawing.Size(313, 296);
            tabpage_other_rates.Top = 25;
            tabpage_other_rates.Left = 3;
            tabpage_other_rates.Visible = false;
            // 
            // dw_other_rates
            // 
            dw_other_rates.VerticalScroll.Visible = false;
            dw_other_rates.TabIndex = 2;
            dw_other_rates.Size = new System.Drawing.Size(382, 315);
            dw_other_rates.Location = new System.Drawing.Point(5, 7);
            //dw_other_rates.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_other_rates_constructor);
            //dw_other_rates.URdsDwEditChanged +=new NZPostOffice.RDS.Controls.EventDelegate(dw_other_rateseditchanged);
            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&Ok";
            cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_ok.TabIndex = 2;
            cb_ok.Height = 22;
            cb_ok.Width = 57;
            cb_ok.Top = 350;
            cb_ok.Left = 207;
            cb_ok.Name = "OK";
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 3;
            cb_cancel.Height = 22;
            cb_cancel.Width = 57;
            cb_cancel.Top = 350;
            cb_cancel.Left = 269;
            cb_cancel.Name = "Cancel";
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // cb_newrates
            // 
            cb_newrates.Text = "&New Override Rates";
            cb_newrates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_newrates.TabIndex = 4;
            cb_newrates.Height = 22;
            cb_newrates.Width = 112;
            cb_newrates.Location = new System.Drawing.Point(5, 350);
            cb_newrates.Click += new EventHandler(cb_newrates_clicked);
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
