using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class WSearch
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            Controls.Add(st_id);
            Controls.Add(cb_1);
            Controls.Add(cb_2);
            Controls.Add(dw_search);
            Controls.Add(dw_result);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "w_master_ancestor";
            this.Size = new System.Drawing.Size(394, 395);
            // 
            // st_id
            // 
            st_id = new Label();
            st_id.Text = "";
            st_id.Width = 268;
            st_id.Location = new System.Drawing.Point(0, 352);
            // 
            // cb_1
            // 
            cb_1 = new Button();
            cb_1.Text = "Search";
            cb_1.TabIndex = 4;
            cb_1.Location = new System.Drawing.Point(292, 16);
            cb_1.Click += new EventHandler(cb_1_clicked);
            // 
            // cb_2
            // 
            cb_2 = new Button();
            cb_2.Text = "Open";
            cb_2.TabIndex = 3;
            cb_2.Location = new System.Drawing.Point(292, 182);
            // 
            // dw_search
            // 
            dw_search = new URdsDw();
            dw_search.TabIndex = 2;
            dw_search.Location = new System.Drawing.Point(16, 16);
            dw_search.Size = new System.Drawing.Size(268, 160);
            //dw_search.SqlPreview += new SqlEventHandler(dw_search_sqlpreview);
            // 
            // dw_result
            // 
            dw_result = new URdsDw();

            dw_result.TabIndex = 1;
            dw_result.Location = new System.Drawing.Point(16,182);
            dw_result.Size = new System.Drawing.Size(268, 160);
            this.ResumeLayout();
        }

        public str_search_details istr_search_details;
        public Label st_id;
        public Button cb_1;
        public Button cb_2;
        public URdsDw dw_search;
        public URdsDw dw_result;
    }
}