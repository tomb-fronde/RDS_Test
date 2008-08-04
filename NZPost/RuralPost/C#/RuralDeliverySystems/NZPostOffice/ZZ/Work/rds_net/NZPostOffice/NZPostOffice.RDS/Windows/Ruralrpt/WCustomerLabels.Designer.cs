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
    partial class WCustomerLabels
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_cust;

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
            this.dw_cust = new URdsDw();
            Controls.Add(dw_cust);
            Controls.Add(st_label);
           
           //? this.toolbarvisible = false;
            this.Text = "Customer Labels";
            // 
            // st_label
            // 
            st_label.Text = "w_customer_labels";
            st_label.Height = 15;
            st_label.Visible = false;
            // 
            // dw_parameters
            // 
            dw_parameters.TabIndex = 3;
            // 
            // cb_getreport
            // 
            cb_getreport.TabIndex = 4;
            // 
            // dw_report
            // 
            dw_report.DataObject = new RCustlistLabelFast();
            dw_report.Dock = DockStyle.Fill;
            dw_report.TabIndex = 1;
            // 
            // dw_cust
            // 
            dw_cust.TabIndex = 2;
            dw_cust.Height = 172;
            dw_cust.Width = 108;
            dw_cust.Top = 67;
            dw_cust.Left = 389;
            dw_cust.Visible = false;
           
            dw_cust.Tag = "d_customers_all";
            this.ResumeLayout();
        }

        #endregion
    }
}