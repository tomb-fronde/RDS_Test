using System;
using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Entity.Ruraldw;
using Metex.Windows;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WContractSearch
    {
        /// Required designer variable.
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

        public URdsDw dw_results;

        public URdsDw dw_criteria;

        public Button pb_search;

        public Button pb_new;

        public Button pb_open;

        public UCb cb_clear;

        public System.Windows.Forms.Panel l_2;

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WContractSearch));
            this.l_2 = new System.Windows.Forms.Panel();
            this.dw_results = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_criteria = new NZPostOffice.RDS.Controls.URdsDw();
            this.pb_search = new System.Windows.Forms.Button();
            this.pb_new = new System.Windows.Forms.Button();
            this.pb_open = new System.Windows.Forms.Button();
            this.cb_clear = new NZPostOffice.Shared.VisualComponents.UCb();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(1, 408);
            this.st_label.Text = "w_contract_search";
            // 
            // l_2
            // 
            this.l_2.BackColor = System.Drawing.Color.Black;
            this.l_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.l_2.Location = new System.Drawing.Point(4, 230);
            this.l_2.Name = "l_2";
            this.l_2.Size = new System.Drawing.Size(347, 1);
            this.l_2.TabIndex = 4;
            // 
            // dw_results
            // 
            this.dw_results.DataObject = null;
            this.dw_results.FireConstructor = false;
            this.dw_results.Location = new System.Drawing.Point(4, 237);
            this.dw_results.Name = "dw_results";
            this.dw_results.Size = new System.Drawing.Size(350, 168);
            this.dw_results.TabIndex = 5;
            this.dw_results.RowFocusChanged += new System.EventHandler(this.dw_results_rowfocuschanged);
            this.dw_results.GotFocus += new System.EventHandler(this.dw_results_getfocus);
            // 
            // dw_criteria
            // 
            this.dw_criteria.DataObject = null;
            this.dw_criteria.FireConstructor = false;
            this.dw_criteria.Location = new System.Drawing.Point(3, 4);
            this.dw_criteria.Name = "dw_criteria";
            this.dw_criteria.Size = new System.Drawing.Size(350, 220);
            this.dw_criteria.TabIndex = 6;
            this.dw_criteria.GotFocus += new System.EventHandler(this.dw_criteria_getfocus);
            // 
            // pb_search
            // 
            this.pb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_search.Image = ((System.Drawing.Image)(resources.GetObject("pb_search.Image")));
            this.pb_search.Location = new System.Drawing.Point(363, 4);
            this.pb_search.Name = "pb_search";
            this.pb_search.Size = new System.Drawing.Size(59, 31);
            this.pb_search.TabIndex = 2;
            this.pb_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pb_search.Click += new System.EventHandler(this.pb_search_clicked);
            // 
            // pb_new
            // 
            this.pb_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_new.Image = ((System.Drawing.Image)(resources.GetObject("pb_new.Image")));
            this.pb_new.Location = new System.Drawing.Point(363, 45);
            this.pb_new.Name = "pb_new";
            this.pb_new.Size = new System.Drawing.Size(59, 31);
            this.pb_new.TabIndex = 3;
            this.pb_new.Tag = "ComponentPrivilege=C;";
            this.pb_new.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pb_new.Visible = false;
            this.pb_new.Click += new System.EventHandler(this.pb_new_clicked);
            // 
            // pb_open
            // 
            this.pb_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_open.Image = ((System.Drawing.Image)(resources.GetObject("pb_open.Image")));
            this.pb_open.Location = new System.Drawing.Point(363, 195);
            this.pb_open.Name = "pb_open";
            this.pb_open.Size = new System.Drawing.Size(59, 31);
            this.pb_open.TabIndex = 4;
            this.pb_open.Tag = "ComponentPrivilege=C;ComponentPrivilege=R;ComponentPrivilege=M;ComponentPrivilege" +
                "=D;";
            this.pb_open.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pb_open.Click += new System.EventHandler(this.pb_open_clicked);
            // 
            // cb_clear
            // 
            this.cb_clear.Location = new System.Drawing.Point(363, 86);
            this.cb_clear.Name = "cb_clear";
            this.cb_clear.Size = new System.Drawing.Size(59, 31);
            this.cb_clear.TabIndex = 4;
            this.cb_clear.Text = "&Clear";
            this.cb_clear.Click += new System.EventHandler(this.cb_clear_clicked);
            // 
            // WContractSearch
            // 
            this.AcceptButton = this.pb_search;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(430, 428);
            this.Controls.Add(this.dw_criteria);
            this.Controls.Add(this.pb_search);
            this.Controls.Add(this.pb_new);
            this.Controls.Add(this.pb_open);
            this.Controls.Add(this.cb_clear);
            this.Controls.Add(this.dw_results);
            this.Controls.Add(this.l_2);
            this.MaximizeBox = false;
            this.Name = "WContractSearch";
            this.Text = "Contract Search";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WContractSearch_KeyDown);
            this.Controls.SetChildIndex(this.l_2, 0);
            this.Controls.SetChildIndex(this.dw_results, 0);
            this.Controls.SetChildIndex(this.cb_clear, 0);
            this.Controls.SetChildIndex(this.pb_open, 0);
            this.Controls.SetChildIndex(this.pb_new, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.pb_search, 0);
            this.Controls.SetChildIndex(this.dw_criteria, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}
