using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Windows.Ruralwin2;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WExtentions2001
    {

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_search;

        public TabControl tab_1;

        public TabPage tabpage_1;

        public URdsDw dw_ext;

        public Label st_showcalcs;

        public TabPage tabpage_2;

        public URdsDw dw_bm;

        public Button cb_print;

        public URdsDw dw_contract;

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.tab_1.SuspendLayout();
            //this.tabpage_1.SuspendLayout();
            //this.dw_ext.SuspendLayout();
            //this.tabpage_2.SuspendLayout();

            this.SuspendLayout();
            // 
            // st_label
            // 

            this.st_label.Location = new System.Drawing.Point(5, 507);
            this.st_label.Size = new System.Drawing.Size(171, 15);
            this.st_label.Text = "WExtentions2001";
            this.st_label.Visible = false;
            // 
            // cb_search
            // 
            this.cb_search = new Button();
            this.cb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_search.Location = new System.Drawing.Point(393, 9);
            this.cb_search.Name = "cb_search";
            this.cb_search.Size = new System.Drawing.Size(63, 22);
            this.cb_search.TabIndex = 2;
            this.cb_search.Text = "&Search";
            this.cb_search.Click += new System.EventHandler(this.cb_search_clicked);
            // 
            // tab_1
            // 
            this.tab_1 = new TabControl();
            this.tabpage_1 = new TabPage();
            this.tabpage_2 = new TabPage();
            this.tab_1.Controls.Add(this.tabpage_1);
            this.tab_1.Controls.Add(this.tabpage_2);
            this.tab_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tab_1.Location = new System.Drawing.Point(8, 70);
            this.tab_1.Name = "tab_1";
            this.tab_1.SelectedIndex = 0;
            this.tab_1.Size = new System.Drawing.Size(638, 360);
            this.tab_1.SelectedIndexChanged += new EventHandler(tab_1_SelectedIndexChanged);
            this.tab_1.TabIndex = 0;
            // 
            // tabpage_1
            // 

            //?this.tabpage_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dw_ext = new URdsDw();
            this.tabpage_1.Controls.Add(this.dw_ext);
            this.tabpage_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_1.Location = new System.Drawing.Point(4, 22);
            this.tabpage_1.Name = "tabpage_1";
            this.tabpage_1.Size = new System.Drawing.Size(630, 403);
            this.tabpage_1.TabIndex = 0;
            this.tabpage_1.Text = "Extension Parameters";
            this.tabpage_1.ToolTipText = "Tabpage for entering extension parameters";
            this.tabpage_1.Width = 0;
            // 
            // dw_ext
            // 

            this.dw_ext.DataObject = new DExtension2005();
            this.dw_ext.Controls.Add(this.st_showcalcs);
            this.dw_ext.Location = new System.Drawing.Point(0, 0);
            this.dw_ext.Name = "dw_ext";
            this.dw_ext.Size = new System.Drawing.Size(627, 325);
            this.dw_ext.TabIndex = 5;
            this.dw_ext.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //this.dw_ext.GotFocus += new System.EventHandler(this.dw_ext_getfocus);
            //this.dw_ext.ItemChanged += new EventHandler(this.dw_ext_itemchanged);

            //this.dw_ext.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_ext_constructor);
            //this.dw_ext.PfcUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate1(this.dw_ext_pfc_update);
            //this.dw_ext.PfcPostUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_ext_pfc_postupdate);
            //this.dw_ext.UpdateStart += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_ext_updatestart);
            //((DExtension2005)this.dw_ext.DataObject).TextBoxLostFocus += new EventHandler(this.dw_ext_itemchanged);
            // 
            // st_showcalcs
            // 
            this.st_showcalcs = new Label();
            this.st_showcalcs.BackColor = System.Drawing.Color.SkyBlue;
            this.st_showcalcs.Font = new System.Drawing.Font("Arial", 8F);
            this.st_showcalcs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_showcalcs.Location = new System.Drawing.Point(3, 386);
            this.st_showcalcs.Name = "st_showcalcs";
            this.st_showcalcs.Size = new System.Drawing.Size(157, 17);
            this.st_showcalcs.TabIndex = 6;
            this.st_showcalcs.Text = "Use scrollbar to see formulas on the right";
            this.st_showcalcs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st_showcalcs.Visible = false;
            // 
            // tabpage_2
            // 

            //? this.tabpage_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dw_bm = new URdsDw();
            this.tabpage_2.Controls.Add(this.dw_bm);
            this.tabpage_2.Controls.Add(this.cb_print);
            this.tabpage_2.Enabled = false;
            this.tabpage_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_2.Location = new System.Drawing.Point(4, 22);
            this.tabpage_2.Name = "tabpage_2";
            this.tabpage_2.Size = new System.Drawing.Size(580, 403);
            this.tabpage_2.TabIndex = 1;
            this.tabpage_2.Text = "Benchmark Report";
            this.tabpage_2.ToolTipText = "Benchmark report - enabled only when extension is successful";
            // 
            // dw_bm
            // 

            this.dw_bm.DataObject = new NZPostOffice.RDS.DataControls.Ruralrpt.RBenchmarkReport2006();
            this.dw_bm.Location = new System.Drawing.Point(3, 7);
            this.dw_bm.Name = "dw_bm";
            this.dw_bm.Size = new System.Drawing.Size(572, 283);
            this.dw_bm.TabIndex = 3;
            //this.dw_bm.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_bm_constructor);
            // 
            // cb_print
            // 
            this.cb_print = new Button();
            this.cb_print.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_print.Location = new System.Drawing.Point(499, 296);
            this.cb_print.Name = "cb_print";
            this.cb_print.Size = new System.Drawing.Size(77, 23);
            this.cb_print.TabIndex = 5;
            this.cb_print.Text = "&Print";
            this.cb_print.Click += new System.EventHandler(this.cb_print_clicked);
            // 
            // dw_contract
            // 
            this.dw_contract = new URdsDw();
            this.dw_contract.DataObject = new DContractNoEntry2001();
            this.dw_contract.Location = new System.Drawing.Point(8, 4);
            this.dw_contract.Name = "dw_contract";
            this.dw_contract.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_contract.Size = new System.Drawing.Size(373, 62);
            this.dw_contract.TabIndex = 1;
            //this.dw_contract.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_contract_constructor);
            // 
            // WExtentions2001
            // 
            //this.AcceptButton = this.cb_search;
            this.ClientSize = new System.Drawing.Size(652, 435);
            this.Controls.Add(this.tab_1);
            this.Controls.Add(this.cb_search);
            this.Controls.Add(this.dw_contract);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WExtentions2001";
            this.Text = "Extension Process";
            this.DoubleClick += new System.EventHandler(this.doubleclicked);
            //this.Controls.SetChildIndex(this.dw_contract, 0);
            //this.Controls.SetChildIndex(this.tab_1, 0);
            //this.Controls.SetChildIndex(this.cb_search, 0);
            //this.Controls.SetChildIndex(this.st_label, 0);

            //this.tab_1.ResumeLayout(false);
            //this.tabpage_1.ResumeLayout(false);
            //this.dw_ext.ResumeLayout(false);
            //this.tabpage_2.ResumeLayout(false);
            //this.ResumeLayout(false);
            //this.PerformLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
