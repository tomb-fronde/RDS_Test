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
using System;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WGenericReportPreview
    {

        private System.ComponentModel.IContainer components = null;

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
         
            // 
            // st_label
            // 
            st_label.Text = "RDRPTPV";
            st_label.Height = 15;
            st_label.Location=new Point(3,330);
            st_label.Visible = false;

            // 
            // dw_report
            // 
            //? dw_report.Size = new Size(547, 400); //316
            //?dw_report.Location = new Point(2, 5);
            dw_report.Dock = DockStyle.Fill;
            //? dw_report.Error += new EventHandler(dw_report_dberror);
            this.ResumeLayout();
        }

        #endregion
    }
}