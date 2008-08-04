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
    partial class WCustomerUnconfirmedReportSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //public USt st_label;
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
            this.Height = 383;
            this.Width = 380;
            this.dw_criteria.DataObject = new DReportGenericRegOutletContcriteria();
            this.dw_results.DataObject = new DReportRegionoutletcontractResults();
            // 
            // st_label
            // 
            st_label.Text = "RDRPTUCR";
            st_label.Top = 324;
            // 
            // dw_criteria
            // 
           
            dw_criteria.Height = 116;
            dw_criteria.Width = 301;
            // 
            // dw_results
            // 
           
            dw_results.Visible = true;
            dw_results.Height = 192;
            dw_results.Width = 301;
            dw_results.Top = 128;
            // 
            // pb_search
            // 
            pb_search.Visible = true;
            pb_search.Left = 313;
            // 
            // pb_open
            // 
            pb_open.Top = 123;
            pb_open.Left = 314;
            this.ResumeLayout();
        }

        #endregion
    }
}