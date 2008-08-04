using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WCustomerCounterDelFreq
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Label st_max;

        public Button cb_export;

        public URdsDw dw_export;

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
            this.st_max = new Label();
            this.cb_export = new Button();
            this.dw_export = new URdsDw();
            this.dw_export.DataObject = new DCustDetailsExport();
            Controls.Add(st_max);
            Controls.Add(cb_export);
            Controls.Add(dw_export);
            this.Text = "Customer Listing Search  ( by Frequency)";
            this.Size = new Size(485, 500);
            // 
            // st_label
            // 
            st_label.Text = "w_customer_counter_del_freq";
            st_label.Font = new System.Drawing.Font("Arial Narrow", st_label.Font.Size, st_label.Font.Style);
            st_label.Location = new Point(0, 450);
            st_label.Size = new Size(132, 20);
            // 
            // dw_criteria
            // 
            dw_criteria.Size = new Size(410, 440);                        
            dw_criteria.LostFocus += new EventHandler(dw_criteria_losefocus);

            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new EventHandler(dw_criteria_clicked);
            //((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("use_printedon"))).CheckedChanged += new EventHandler(dw_criteria_CheckBoxCheckedChanged);
            //((System.Windows.Forms.RadioButton)(dw_criteria.GetControlByName("detailed_report3"))).CheckedChanged += new EventHandler(dw_criteria_RadioButtonCheckedChanged);
            //((System.Windows.Forms.RadioButton)(dw_criteria.GetControlByName("cust_de_type2"))).CheckedChanged += new EventHandler(dw_criteria_RadioButtonCheckedchanged);
            
            // 
            // dw_results
            // 
            dw_results.Height = 138;
            dw_results.Top = 200;
            dw_results.Visible = false;
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            pb_search.Top = 5;
            pb_search.Left = 417;
            // 
            // pb_open
            // 
            pb_open.Top = 240;
            pb_open.Left = 417;
            pb_open.Tag = "ComponentName=Disabled;";
            // 
            // st_max
            // 
            st_max.TabStop = false;           
            st_max.ForeColor = System.Drawing.Color.Red;
            st_max.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_max.Location = new Point(135, 450);
            st_max.Size = new Size(280, 20);
            // 
            // cb_export
            // 
            cb_export.Text = "Export";
            cb_export.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_export.TabIndex = 5;
            cb_export.Location = new Point(417, 283);
            cb_export.Size = new Size(59, 27);
            cb_export.Click += new EventHandler(cb_export_clicked);
            // 
            // dw_export
            // 
            dw_export.TabIndex = 1;
            dw_export.Location = new Point(552, 59);
            dw_export.Size = new Size(383, 166);
            dw_export.Visible = false;
            this.Name = "w_customer_counter_del_freq";
            this.ResumeLayout();
        }

        #endregion
    }
}