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
            this.SuspendLayout();
            this.l_2 = new Panel();
            this.dw_results = new URdsDw();
            //!this.dw_results.DataObject = new DContractListing();
            this.dw_criteria = new URdsDw();
            //!this.dw_criteria.DataObject = new DContractSearch();

            this.pb_search = new Button();
            this.pb_new = new Button();
            this.pb_open = new Button();
            this.cb_clear = new UCb();
            Controls.Add(l_2);
            Controls.Add(dw_results);
            Controls.Add(dw_criteria);
            Controls.Add(pb_search);
            Controls.Add(pb_new);
            Controls.Add(pb_open);
            Controls.Add(cb_clear);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.MaximizeBox = false;
            this.Text = "Contract Search";
            this.ClientSize = new System.Drawing.Size(430, 380);
            // 
            // st_label
            // 
            st_label.Text = "w_contract_search";
            this.st_label.Location = new System.Drawing.Point(5, 364);
            // 
            // l_2
            //
            l_2.Height = 1;
            l_2.Width = 347;
            l_2.BackColor = System.Drawing.Color.Black;
            l_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            l_2.Location = new System.Drawing.Point(4, 214);
            // 
            // dw_results
            // 
            dw_results.TabIndex = 5;
            this.dw_results.Location = new System.Drawing.Point(3, 195);
            this.dw_results.Size = new System.Drawing.Size(350, 168);
            dw_results.RowFocusChanged += new EventHandler(dw_results_rowfocuschanged);
            dw_results.GotFocus += new EventHandler(dw_results_getfocus);

            //dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
            //((DContractListing)dw_results.DataObject).CellDoubleClick += new EventHandler(this.dw_results_doubleclicked);

            // 
            // dw_criteria
            // 
            //!this.dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_criteria.Size = new System.Drawing.Size(350,185);
            this.dw_criteria.Location = new System.Drawing.Point(3, 4);
            dw_criteria.GotFocus += new EventHandler(dw_criteria_getfocus);
            //dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_criteria_constructor);
            // 
            // pb_search
            // 
            pb_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pb_search.Image = global::NZPostOffice.Shared.Properties.Resources.SEARCH;
            this.AcceptButton = pb_search;
            pb_search.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_search.TabIndex = 2;
            this.pb_search.Location = new System.Drawing.Point(363, 4);
            this.pb_search.Size = new System.Drawing.Size(59, 31);
            pb_search.Click += new EventHandler(pb_search_clicked);
            // 
            // pb_new
            // 
            pb_new.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pb_new.Image = global::NZPostOffice.Shared.Properties.Resources.NEW;
            pb_new.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_new.TabIndex = 3;
            this.pb_new.Location = new System.Drawing.Point(363, 45);
            this.pb_new.Size = new System.Drawing.Size(59, 31);
            pb_new.Visible = false;
            pb_new.Tag = "ComponentPrivilege=C;";
            pb_new.Click += new EventHandler(pb_new_clicked);
            // 
            // pb_open
            // 
            pb_open.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pb_open.Image = global::NZPostOffice.Shared.Properties.Resources.OPEN;
            pb_open.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_open.TabIndex = 4;
            this.pb_open.Location = new System.Drawing.Point(363, 195);
            this.pb_open.Size = new System.Drawing.Size(59, 31);
            pb_open.Tag = "ComponentPrivilege=C;ComponentPrivilege=R;ComponentPrivilege=M;ComponentPrivilege=D;";
            pb_open.Click += new EventHandler(pb_open_clicked);
            // 
            // cb_clear
            // 
            cb_clear.Text = "&Clear";
            cb_clear.TabIndex = 4;
            this.cb_clear.Location = new System.Drawing.Point(363, 86);
            this.cb_clear.Size = new System.Drawing.Size(59, 31);
            this.KeyDown += new KeyEventHandler(WContractSearch_KeyDown);
            cb_clear.Click += new EventHandler(cb_clear_clicked);
            this.ResumeLayout();
        }

        #endregion

    }
}
