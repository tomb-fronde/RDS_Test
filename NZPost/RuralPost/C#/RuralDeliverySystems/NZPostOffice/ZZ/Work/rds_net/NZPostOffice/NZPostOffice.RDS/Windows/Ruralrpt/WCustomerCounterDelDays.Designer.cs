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
    partial class WCustomerCounterDelDays
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
            dw_export = new URdsDw();
            this.dw_export.DataObject = new DCustDetailsExport();
            Controls.Add(st_max);
            Controls.Add(cb_export);
            Controls.Add(dw_export);
            this.Text = "Customer Listing Search  ( by Delivery Day of Week)";
            this.Height = 495;
            this.Width = 485;
            // 
            // st_label
            // 
            st_label.Text = "w_customer_counter_del_days";
            st_label.Font = new System.Drawing.Font("Arial Narrow", st_label.Font.Size, st_label.Font.Style);
            st_label.Width = 134;
            st_label.Height = 20;
            st_label.Top = 440;
            st_label.Left = 0;
            // 
            // dw_criteria
            // 
            dw_criteria.Height = 435;      
            dw_criteria.Width = 415;
            dw_criteria.Top = 0;
            dw_criteria.Left = 0;
            dw_criteria.DataObject = new DCustCriteriaDeldays();
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new EventHandler(dw_criteria_clicked);
            //((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("use_printedon"))).CheckedChanged += new EventHandler(dw_criteria_CheckBoxCheckedChanged);
            //((System.Windows.Forms.RadioButton)(dw_criteria.GetControlByName("detailed_report3"))).CheckedChanged += new EventHandler(dw_criteria_RadioButtonCheckedChanged);

            // 
            // dw_results
            // 
            dw_results.Enabled = false;
            dw_results.Height = 117;
            dw_results.Width = 173;
            dw_results.Top = 129;
            dw_results.Left = 149;
            dw_results.Visible = false;
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            pb_search.Width = 63;
            pb_search.Top = 4;
            pb_search.Left = 415;
            // 
            // pb_open
            // 
            pb_open.Width = 63;
            pb_open.Top = 240;
            pb_open.Left = 415;
            pb_open.Tag = "ComponentName=Disabled;";
            // 
            // st_max
            // 
            st_max.TabStop = false;
            st_max.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            st_max.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_max.ForeColor = System.Drawing.Color.Red;
            st_max.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_max.Height = 20;
            st_max.Width = 280;
            st_max.Top = 440;
            st_max.Left = 135;
            // 
            // cb_export
            // 
            cb_export.Text = "Export";
            cb_export.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_export.TabIndex = 5;
            cb_export.Height = 27;
            cb_export.Width = 63;
            cb_export.Top = 276;
            cb_export.Left = 415;
            cb_export.Click += new EventHandler(cb_export_clicked);
            // 
            // dw_export
            // 
            //dw_export.HorizontalScroll.Visible = true;
            dw_export.TabIndex = 1;
            dw_export.Height = 166;
            dw_export.Width = 383;
            dw_export.Top = 59;
            dw_export.Left = 552;
            dw_export.Visible = false;
            this.Name = "w_customer_counter_del_days";
            this.ResumeLayout();
        }
        #endregion
    }
}