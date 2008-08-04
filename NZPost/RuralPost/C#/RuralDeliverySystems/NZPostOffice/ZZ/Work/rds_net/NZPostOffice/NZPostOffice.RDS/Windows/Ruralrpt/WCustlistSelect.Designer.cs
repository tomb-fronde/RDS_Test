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
    partial class WCustlistSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Button cb_close;

        public URdsDw dw_custlist;

        public Button cb_all;

        public Button cb_select;

        public Button cb_labels;

        public Label help_1;

        public Label help_2;

        public Label help_3;

        public Label help_4;

        public Label st_1;

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
            this.cb_close = new System.Windows.Forms.Button();
            this.dw_custlist = new URdsDw();
            this.dw_custlist.DataObject = new DCustlistSelect();
            this.cb_all = new System.Windows.Forms.Button();
            this.cb_select = new System.Windows.Forms.Button();
            this.cb_labels = new System.Windows.Forms.Button();
            this.help_1 = new System.Windows.Forms.Label();
            this.help_2 = new System.Windows.Forms.Label();
            this.help_3 = new System.Windows.Forms.Label();
            this.help_4 = new System.Windows.Forms.Label();
            this.st_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(5, 433);
            this.st_label.Size = new System.Drawing.Size(96, 23);
            this.st_label.Text = "WCustlistSelect";
            // 
            // cb_close
            // 
            this.cb_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_close.Location = new System.Drawing.Point(454, 419);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 2;
            this.cb_close.Text = "Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_custlist
            // 
            this.dw_custlist.Location = new System.Drawing.Point(8, 125);
            this.dw_custlist.Name = "dw_custlist";
            this.dw_custlist.Size = new System.Drawing.Size(521, 288);
            this.dw_custlist.TabIndex = 1;
            this.dw_custlist.Click += new System.EventHandler(this.dw_custlist_clicked);

            //this.dw_custlist.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_custlist_constructor);

            // 
            // cb_all
            // 
            this.cb_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_all.Location = new System.Drawing.Point(364, 419);
            this.cb_all.Name = "cb_all";
            this.cb_all.Size = new System.Drawing.Size(75, 23);
            this.cb_all.TabIndex = 4;
            this.cb_all.Text = "Select All";
            this.cb_all.Click += new System.EventHandler(this.cb_all_clicked);
            // 
            // cb_select
            // 
            this.cb_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_select.Location = new System.Drawing.Point(274, 420);
            this.cb_select.Name = "cb_select";
            this.cb_select.Size = new System.Drawing.Size(75, 23);
            this.cb_select.TabIndex = 3;
            this.cb_select.Text = "Select";
            this.cb_select.Click += new System.EventHandler(this.cb_select_clicked);
            // 
            // cb_labels
            // 
            this.cb_labels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_labels.Location = new System.Drawing.Point(171, 420);
            this.cb_labels.Name = "cb_labels";
            this.cb_labels.Size = new System.Drawing.Size(88, 23);
            this.cb_labels.TabIndex = 5;
            this.cb_labels.Text = "Generate Labels";
            this.cb_labels.Click += new System.EventHandler(this.cb_labels_clicked);
            // 
            // help_1
            // 
            //?this.help_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(213)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.help_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.help_1.Location = new System.Drawing.Point(128, 58);
            this.help_1.Name = "help_1";
            this.help_1.Size = new System.Drawing.Size(264, 16);
            this.help_1.TabIndex = 6;
            this.help_1.Text = "If you only want to print a few customer address labels";
            // 
            // help_2
            // 
            //?this.help_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(213)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.help_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.help_2.Location = new System.Drawing.Point(128, 74);
            this.help_2.Name = "help_2";
            this.help_2.Size = new System.Drawing.Size(264, 16);
            this.help_2.TabIndex = 7;
            this.help_2.Text = "    - pick those customers you want to print ";
            // 
            // help_3
            // 
            //?this.help_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(213)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.help_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.help_3.Location = new System.Drawing.Point(128, 90);
            this.help_3.Name = "help_3";
            this.help_3.Size = new System.Drawing.Size(264, 16);
            this.help_3.TabIndex = 8;
            this.help_3.Text = "   - click the \'select\' button";
            // 
            // help_4
            // 
            //?this.help_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(213)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.help_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.help_4.Location = new System.Drawing.Point(128, 106);
            this.help_4.Name = "help_4";
            this.help_4.Size = new System.Drawing.Size(264, 16);
            this.help_4.TabIndex = 9;
            this.help_4.Text = "   - click the \'Generate Labels\' button";
            // 
            // st_1
            // 
            //this.st_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(213)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_1.Location = new System.Drawing.Point(128, 42);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(264, 16);
            this.st_1.TabIndex = 10;
            this.st_1.Text = "Click the \'Generate Labels\' button to print all labels";
            // 
            // WCustlistSelect
            // 
            this.ClientSize = new System.Drawing.Size(550, 455);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.dw_custlist);
            this.Controls.Add(this.cb_all);
            this.Controls.Add(this.help_1);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.cb_labels);
            this.Controls.Add(this.help_2);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.help_4);
            this.Controls.Add(this.help_3);
            this.Name = "w_custlist_select";
            this.Controls.SetChildIndex(this.help_3, 0);
            this.Controls.SetChildIndex(this.help_4, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.help_2, 0);
            this.Controls.SetChildIndex(this.cb_labels, 0);
            this.Controls.SetChildIndex(this.cb_select, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.help_1, 0);
            this.Controls.SetChildIndex(this.cb_all, 0);
            this.Controls.SetChildIndex(this.dw_custlist, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}