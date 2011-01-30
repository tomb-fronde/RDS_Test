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

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WCustomer
    {
        #region Define
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public TabControl tab_1;

        public TabPage tabpage_1;

        public GroupBox gb_1;

        public URdsDw dw_generic;

        public TabPage tabpage_2;

        public URdsDw dw_recipients2;

        public GroupBox gb_recipients;

        public TabPage tabpage_4;

        public URdsDw dw_occupations;

        public GroupBox gb_occupations;

        public TabPage tabpage_5;

        public URdsDw dw_interests;

        public GroupBox gb_interests;

        public UCb cb_save;

        public UCb cb_close;

        #endregion

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_1 = new System.Windows.Forms.TabControl();
            this.tabpage_1 = new System.Windows.Forms.TabPage();
            this.dw_generic = new NZPostOffice.RDS.Controls.URdsDw();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.tabpage_2 = new System.Windows.Forms.TabPage();
            this.dw_recipients2 = new NZPostOffice.RDS.Controls.URdsDw();
            this.gb_recipients = new System.Windows.Forms.GroupBox();
            this.tabpage_4 = new System.Windows.Forms.TabPage();
            this.dw_occupations = new NZPostOffice.RDS.Controls.URdsDw();
            this.gb_occupations = new System.Windows.Forms.GroupBox();
            this.tabpage_5 = new System.Windows.Forms.TabPage();
            this.dw_interests = new NZPostOffice.RDS.Controls.URdsDw();
            this.gb_interests = new System.Windows.Forms.GroupBox();
            this.st_label = new NZPostOffice.Shared.VisualComponents.USt();
            this.cb_save = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_close = new NZPostOffice.Shared.VisualComponents.UCb();
            this.tab_1.SuspendLayout();
            this.tabpage_1.SuspendLayout();
            this.tabpage_2.SuspendLayout();
            this.tabpage_4.SuspendLayout();
            this.tabpage_5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_1
            // 
            this.tab_1.Controls.Add(this.tabpage_1);
            this.tab_1.Controls.Add(this.tabpage_2);
            this.tab_1.Controls.Add(this.tabpage_4);
            this.tab_1.Controls.Add(this.tabpage_5);
            this.tab_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tab_1.Location = new System.Drawing.Point(5, 3);
            this.tab_1.Name = "tab_1";
            this.tab_1.SelectedIndex = 0;
            this.tab_1.Size = new System.Drawing.Size(415, 349);
            this.tab_1.TabIndex = 1;
            this.tab_1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tab1_selectionchanging);
            this.tab_1.SelectedIndexChanged += new System.EventHandler(this.tab_1_SelectedIndexChanged);
            // 
            // tabpage_1
            // 
            this.tabpage_1.Controls.Add(this.dw_generic);
            this.tabpage_1.Controls.Add(this.gb_1);
            this.tabpage_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_1.Location = new System.Drawing.Point(4, 22);
            this.tabpage_1.Name = this.tabpage_1.Text;
            this.tabpage_1.Size = new System.Drawing.Size(407, 323);
            this.tabpage_1.TabIndex = 0;
            this.tabpage_1.Tag = "ComponentName=Customer;";
            this.tabpage_1.Text = "Customer";
            // 
            // dw_generic
            // 
            this.dw_generic.DataObject = null;
            this.dw_generic.FireConstructor = false;
            this.dw_generic.Location = new System.Drawing.Point(14, 28);
            this.dw_generic.Name = "dw_generic";
            this.dw_generic.Size = new System.Drawing.Size(368, 277);
            this.dw_generic.TabIndex = 0;
            // 
            // gb_1
            // 
            this.gb_1.BackColor = System.Drawing.SystemColors.Control;
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_1.Location = new System.Drawing.Point(8, 9);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(389, 302);
            this.gb_1.TabIndex = 2;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "Customer Details";
            // 
            // tabpage_2
            // 
            this.tabpage_2.Controls.Add(this.dw_recipients2);
            this.tabpage_2.Controls.Add(this.gb_recipients);
            this.tabpage_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_2.Location = new System.Drawing.Point(4, 22);
            this.tabpage_2.Name = this.tabpage_2.Text;
            this.tabpage_2.Size = new System.Drawing.Size(407, 323);
            this.tabpage_2.TabIndex = 1;
            this.tabpage_2.Tag = "ComponentName=Recipients;";
            this.tabpage_2.Text = "Recipients";
            // 
            // dw_recipients2
            // 
            this.dw_recipients2.DataObject = null;
            this.dw_recipients2.FireConstructor = false;
            this.dw_recipients2.Location = new System.Drawing.Point(10, 24);
            this.dw_recipients2.Name = "dw_recipients2";
            this.dw_recipients2.Size = new System.Drawing.Size(380, 280);
            this.dw_recipients2.TabIndex = 0;
            this.dw_recipients2.ItemChanged += new System.EventHandler(this.dw_recipients2_itemchanged);
            // 
            // gb_recipients
            // 
            this.gb_recipients.BackColor = System.Drawing.SystemColors.Control;
            this.gb_recipients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_recipients.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_recipients.Location = new System.Drawing.Point(3, 6);
            this.gb_recipients.Name = "gb_recipients";
            this.gb_recipients.Size = new System.Drawing.Size(394, 304);
            this.gb_recipients.TabIndex = 1;
            this.gb_recipients.TabStop = false;
            this.gb_recipients.Text = "Recipients";
            // 
            // tabpage_4
            // 
            this.tabpage_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.tabpage_4.Controls.Add(this.dw_occupations);
            this.tabpage_4.Controls.Add(this.gb_occupations);
            this.tabpage_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_4.Location = new System.Drawing.Point(4, 22);
            this.tabpage_4.Name = this.tabpage_4.Text;
            this.tabpage_4.Size = new System.Drawing.Size(407, 323);
            this.tabpage_4.TabIndex = 2;
            this.tabpage_4.Tag = "ComponentName=Occupations;";
            this.tabpage_4.Text = "Occupations";
            // 
            // dw_occupations
            // 
            this.dw_occupations.DataObject = null;
            this.dw_occupations.FireConstructor = false;
            this.dw_occupations.Location = new System.Drawing.Point(10, 24);
            this.dw_occupations.Name = "dw_occupations";
            this.dw_occupations.Size = new System.Drawing.Size(382, 280);
            this.dw_occupations.TabIndex = 0;
            // 
            // gb_occupations
            // 
            this.gb_occupations.BackColor = System.Drawing.SystemColors.Control;
            this.gb_occupations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_occupations.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_occupations.Location = new System.Drawing.Point(3, 6);
            this.gb_occupations.Name = "gb_occupations";
            this.gb_occupations.Size = new System.Drawing.Size(394, 304);
            this.gb_occupations.TabIndex = 1;
            this.gb_occupations.TabStop = false;
            this.gb_occupations.Text = "Occupations";
            // 
            // tabpage_5
            // 
            this.tabpage_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.tabpage_5.Controls.Add(this.dw_interests);
            this.tabpage_5.Controls.Add(this.gb_interests);
            this.tabpage_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_5.Location = new System.Drawing.Point(4, 22);
            this.tabpage_5.Name = this.tabpage_5.Text;
            this.tabpage_5.Size = new System.Drawing.Size(407, 323);
            this.tabpage_5.TabIndex = 3;
            this.tabpage_5.Tag = "ComponentName=Interests;";
            this.tabpage_5.Text = "Interests";
            // 
            // dw_interests
            // 
            this.dw_interests.DataObject = null;
            this.dw_interests.FireConstructor = false;
            this.dw_interests.Location = new System.Drawing.Point(10, 24);
            this.dw_interests.Name = "dw_interests";
            this.dw_interests.Size = new System.Drawing.Size(382, 281);
            this.dw_interests.TabIndex = 0;
            // 
            // gb_interests
            // 
            this.gb_interests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_interests.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_interests.Location = new System.Drawing.Point(3, 6);
            this.gb_interests.Name = "gb_interests";
            this.gb_interests.Size = new System.Drawing.Size(394, 305);
            this.gb_interests.TabIndex = 1;
            this.gb_interests.TabStop = false;
            this.gb_interests.Text = "Interests";
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(10, 364);
            this.st_label.Name = "st_label";
            this.st_label.Size = new System.Drawing.Size(84, 15);
            this.st_label.TabIndex = 4;
            this.st_label.Text = "w_customer";
            this.st_label.Visible = false;
            // 
            // cb_save
            // 
            this.cb_save.Location = new System.Drawing.Point(255, 358);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "&Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_close
            // 
            this.cb_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_close.Location = new System.Drawing.Point(342, 358);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 3;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // WCustomer
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_close;
            this.ClientSize = new System.Drawing.Size(423, 387);
            this.ControlBox = false;
            this.Controls.Add(this.tab_1);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.st_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WCustomer";
            this.Text = "Customer";
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.tab_1, 0);
            this.tab_1.ResumeLayout(false);
            this.tabpage_1.ResumeLayout(false);
            this.tabpage_2.ResumeLayout(false);
            this.tabpage_4.ResumeLayout(false);
            this.tabpage_5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
