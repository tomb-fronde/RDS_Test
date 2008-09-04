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

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WGenericReportSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_criteria;

        public URdsDw dw_results;

        public Button pb_search;

        public Button pb_open;

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
            this.dw_criteria = new URdsDw();
            //!this.dw_criteria.DataObject = new DReportGenericCriteria();
            this.dw_results = new URdsDw();
            //!this.dw_results.DataObject = new DReportGenericResults();
            this.pb_search = new Button();
            this.pb_open = new Button();
           
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Report Search";
            this.Name = "w_generic_report_search";
            this.Size = new Size(378, 384);
            // 
            // st_label
            // 
            st_label.Text = "RDRPTGS";
            st_label.Location = new Point(5, 340);
            st_label.Size = new Size(171, 15);
            st_label.BringToFront();
            // 
            // dw_criteria
            // 
            dw_criteria.VerticalScroll.Visible = false;
            dw_criteria.TabIndex = 1;
            dw_criteria.Location = new Point(3, 7);
            dw_criteria.Size = new Size(293, 140);
            //!dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_criteria.GotFocus += new EventHandler(dw_criteria_getfocus);
            dw_criteria.ItemChanged += new EventHandler(dw_criteria_itemchanged);

            //dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);
            //dw_criteria.URdsDwItemFocuschanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_criteria_itemfocuschanged); 
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);

            // 
            // dw_results
            // 
            dw_results.TabIndex = 4;
            dw_results.Location = new Point(3, 150);
            dw_results.Size = new Size(293, 190);
            //!dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_results.Click += new EventHandler(dw_results_clicked); 
            dw_results.GotFocus += new EventHandler(dw_results_getfocus);

            //((DReportGenericResults)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
            //dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
            // 
            // pb_search
            // 
            pb_search.TextAlign = ContentAlignment.MiddleCenter;
            pb_search.Image = global::NZPostOffice.Shared.Properties.Resources.SEARCH;
            this.AcceptButton = pb_search;
            pb_search.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_search.TabIndex = 2;
            pb_search.Location = new Point(302, 9);
            pb_search.Size = new Size(59, 31);
            pb_search.Click += new EventHandler(pb_search_clicked);
            // 
            // pb_open
            // 
            pb_open.TextAlign = ContentAlignment.MiddleCenter;
            pb_open.Image = global::NZPostOffice.Shared.Properties.Resources.OPEN;
            pb_open.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_open.TabIndex = 3;
            pb_open.Location = new Point(302, 147);
            pb_open.Size = new Size(59, 31);
            pb_open.Click += new EventHandler(pb_open_clicked);
            Controls.Add(dw_criteria);
            Controls.Add(dw_results);
            Controls.Add(pb_search);
            Controls.Add(pb_open);
            this.ResumeLayout();
        }

        #endregion
    }
}
