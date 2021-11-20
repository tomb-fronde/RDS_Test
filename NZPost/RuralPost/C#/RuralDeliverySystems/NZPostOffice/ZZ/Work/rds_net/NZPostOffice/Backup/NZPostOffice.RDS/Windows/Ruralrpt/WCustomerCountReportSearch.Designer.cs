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
    partial class WCustomerCountReportSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.cb_export = new Button();
            this.dw_export = new URdsDw();
            //!this.dw_export.DataObject = new DCustCountExport();
            //!this.dw_criteria.DataObject = new DCustCountcriteria();
            Controls.Add(cb_export);
            Controls.Add(dw_export);
            this.Height = 189;
            this.Width = 390;
            this.Name = "w_customer_count_report_search";
            // 
            // st_label
            // 
            st_label.Text = "RDRPTCCR";
            st_label.Top = 142;
            st_label.Width = 200;
            // 
            // dw_criteria
            // 
           
            dw_criteria.Height = 140;
            dw_criteria.Width = 312;
            dw_criteria.Top = 0;
            dw_criteria.Left = 0;
            //!dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
           
            // 
            // dw_results
            // 
            dw_results.Enabled = false;
            dw_results.Top = 192;
            dw_results.Left = 16;
            dw_results.Visible = false;
           
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            pb_search.Enabled = false;
            pb_search.Visible = false;
            pb_search.Tag = "ComponentName=Disabled;";

            // 
            // pb_open
            // 
            pb_open.Height = 32;
            pb_open.Width = 64;
            pb_open.Top = 8;
            pb_open.Left = 315;
            // 
            // cb_export
            // 
            cb_export.Text = "Export";
            cb_export.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_export.TabIndex = 3;
            cb_export.Height = 31;
            cb_export.Width = 64;
            cb_export.Top = 48;
            cb_export.Left = 315;
           
            cb_export.Tag = "Export report data to Excel file";
            cb_export.Click += new EventHandler(cb_export_clicked);
          
            // 
            // dw_export
            // 
            dw_export.TabIndex = 1;
            dw_export.Top = 8;
            dw_export.Left = 425;
            dw_export.Visible = false;
            this.ResumeLayout();
        }

        #endregion
    }
}