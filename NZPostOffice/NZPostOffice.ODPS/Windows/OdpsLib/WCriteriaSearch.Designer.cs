using NZPostOffice.Shared.VisualComponents;
using System;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class WCriteriaSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.Size = new System.Drawing.Size(340, 240);
            this.Text = "Search";


            this.dw_search = new URdsDw(); 
            this.cb_search = new UCb();
            this.cb_open = new UCb();
            this.dw_results = new URdsDw(); 
            this.cb_cancel = new UCb();

            Controls.Add(dw_search);
            Controls.Add(cb_search);
            Controls.Add(cb_open);
            Controls.Add(dw_results);
            Controls.Add(cb_cancel);

            // 
            // dw_search
            // 

            // 
            // cb_search
            // 
            this.AcceptButton = cb_search;
            cb_search.Text = "&Search";
            cb_search.TabIndex = 2;
            cb_search.Location = new System.Drawing.Point(268, 10);
            cb_search.Size = new System.Drawing.Size(60, 23);
            cb_search.Click += new EventHandler(cb_search_clicked);

            // 
            // cb_open
            // 
            cb_open.Text = "Ope&n";
            cb_open.TabIndex = 4;
            cb_open.Location = new System.Drawing.Point(268, 112);
            cb_open.Size = new System.Drawing.Size(60, 23);
            cb_open.Click += new EventHandler(cb_open_clicked);

            // 
            // dw_results
            // 
            //? dw_results.vscrollbar = false;
            dw_results.TabIndex = 3;
            dw_results.Location = new System.Drawing.Point(8, 112);
            dw_results.Size = new System.Drawing.Size(252, 96);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 5;
            cb_cancel.Location = new System.Drawing.Point(268, 143);
            cb_cancel.Size = new System.Drawing.Size(60, 23);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ResumeLayout();
        }

        #endregion

        public URdsDw dw_search;
        public UCb cb_search;
        public UCb cb_open;
        public URdsDw dw_results;
        public UCb cb_cancel;
    }
}