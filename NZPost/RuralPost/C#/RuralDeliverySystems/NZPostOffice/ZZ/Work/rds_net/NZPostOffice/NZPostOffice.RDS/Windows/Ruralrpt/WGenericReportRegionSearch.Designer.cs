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
    partial class WGenericReportRegionSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CheckBox cbx_phy_address;

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
            this.cbx_phy_address = new CheckBox();
            this.dw_criteria.DataObject = new DReportGenericCriteriaWithRegion();
            Controls.Add(cbx_phy_address);
            this.Height = 153;
            this.Name = "w_generic_report_region_search";
            // 
            // st_label
            // 
            st_label.Text = "RDRPTRS";
            st_label.Location = new Point(0, 106);
            // 
            // dw_criteria
            // 
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_criteria.Height = 50;
            dw_criteria.Top = 5;
            // 
            // dw_results
            // 
            dw_results.TabIndex = 5;
            dw_results.Height = 259;
            dw_results.Top = 79;
            dw_results.Visible = false;
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            pb_search.Top = 32;
            pb_search.Left = 301;
            pb_search.Visible = false;
            pb_search.Tag = "ComponentName=Disabled;";
            // 
            // pb_open
            // 
            pb_open.TabIndex = 4;
            pb_open.Location = new Point(309, 31);
            // 
            // cbx_phy_address
            // 
            cbx_phy_address.Text = "Use physical address if available";
            //?cbx_phy_address.BackColor = System.Drawing.Color.FromArgb(4, 213, 212, 212);
            cbx_phy_address.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_phy_address.TabIndex = 3;
            cbx_phy_address.Location = new Point(112, 64);
            cbx_phy_address.Size = new Size(184, 16);
            this.ResumeLayout();
        }
        #endregion
    }
}