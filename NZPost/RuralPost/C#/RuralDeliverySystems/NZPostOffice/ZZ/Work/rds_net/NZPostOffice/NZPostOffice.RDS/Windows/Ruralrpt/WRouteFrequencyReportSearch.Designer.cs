using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using System;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WRouteFrequencyReportSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CheckBox cbx_printkms;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.SuspendLayout();
            this.Name = "w_route_frequency_report_search";
            this.cbx_printkms = new CheckBox();
            Controls.Add(cbx_printkms);
            // 
            // st_label
            // 
            st_label.Text = "RDRPTGS";
            st_label.Width = 200;
            // 
            // dw_criteria
            // 
            //!dw_criteria.DataObject = new DReportGenericCriteria();
            dw_criteria.Height = 181;
            dw_criteria.Width = 294;
            //!dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_criteria.Top = 5;
            //  ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            // 
            // dw_results
            // 
            //!dw_results.DataObject = new DReportGenericResults();
            dw_results.Height = 144;
            dw_results.Top = 189;
            //!dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //((DReportGenericResults)dw_results.DataObject).DoubleClick += new EventHandler(this.dw_results_doubleclicked);

            // 
            // pb_search
            // 
            pb_search.TabIndex = 3;
            pb_search.Top = 5;
            // 
            // pb_open
            // 
            pb_open.TabIndex = 5;
            pb_open.Top = 184;
            // 
            // cbx_printkms
            // 
            cbx_printkms.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_printkms.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            cbx_printkms.Text = "Suppress Printing of Running Total";
            cbx_printkms.TabIndex = 2;
            cbx_printkms.Location = new System.Drawing.Point(93, 165);
            cbx_printkms.Size = new System.Drawing.Size(200, 18);
            cbx_printkms.Click += new EventHandler(cbx_printkms_clicked);
            this.ResumeLayout();
        }

        #endregion
    }
}