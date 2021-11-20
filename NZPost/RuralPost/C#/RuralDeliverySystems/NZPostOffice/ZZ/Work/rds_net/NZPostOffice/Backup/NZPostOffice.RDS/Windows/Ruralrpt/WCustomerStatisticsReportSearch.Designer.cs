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
    partial class WCustomerStatisticsReportSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_list;

        public CheckBox cbx_privacy;

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
            this.dw_list = new URdsDw();
            //!this.dw_list.DataObject = new DOccupationlist();
            //!this.dw_criteria.DataObject = new DReportCustomerStatisticsCriteria();
            this.cbx_privacy = new CheckBox();
            Controls.Add(dw_list);
            Controls.Add(cbx_privacy);
            this.Height = 408;
            this.Width = 366;
            // 
            // st_label
            // 
            st_label.Text = "RDRPTCSR";
            st_label.Height = 14;
            st_label.Top = 356;
            st_label.Width = 250;
            st_label.Left = 7;
            // 
            // dw_criteria
            // 
            dw_criteria.TabIndex = 2;
            //!dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_criteria.Height = 132;
            dw_criteria.Width = 294;
            dw_criteria.Top = 5;
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
         
            // 
            // dw_results
            // 
            dw_results.Tag = "ComponentName=Disabled;";
            dw_results.Visible = false;
            dw_results.TabIndex = 6;
            dw_results.Height = 259;
            dw_results.Top = 106;
            dw_results.Left = 89;
            // 
            // pb_search
            // 
            pb_search.Image = global::NZPostOffice.Shared.Properties.Resources.SEARCH;
            pb_search.Tag = "ComponentName=Disabled;";
            pb_search.Enabled = false;
            pb_search.Visible = false;
            pb_search.TabIndex = 3;
            pb_search.Top = 23;
            // 
            // pb_open
            // 
            pb_open.TabIndex = 5;
            pb_open.Top = 5;
            pb_open.Left = 301;
            // 
            // dw_list
            // 
            dw_list.TabIndex = 1;
            dw_list.Height = 210;
            dw_list.Width = 294;
            dw_list.Top = 140;
            dw_list.Left = 3;
            //!dw_list.DataObject.BorderStyle = BorderStyle.Fixed3D;
            // 
            // cbx_privacy
            // 
            cbx_privacy.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_privacy.BackColor = System.Drawing.SystemColors.ButtonFace;
            cbx_privacy.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_privacy.CheckAlign = ContentAlignment.MiddleRight;
            cbx_privacy.Text = "Include Privacy Customers? ";
            cbx_privacy.TabIndex = 4;
            cbx_privacy.Height = 17;
            cbx_privacy.Width = 176;
            cbx_privacy.Top = 121;
            cbx_privacy.Left = 118;
            this.ResumeLayout();
            this.Name = "w_customer_statistics_report_search";
        }
        #endregion
    }
}