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

        public Label st_1;

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
            this.SuspendLayout();
            this.tab_1 = new TabControl();
            this.st_1 = new Label();
            this.st_label = new USt();
            this.cb_save = new UCb();
            this.cb_close = new UCb();
            Controls.Add(tab_1);
            Controls.Add(st_1);
            Controls.Add(cb_save);
            Controls.Add(cb_close);
            Controls.Add(st_label);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Customer";
            this.Size = new System.Drawing.Size(433, 380);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //!            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //!            this.FormClosing -= new FormClosingEventHandler(FormBase_FormClosing);
            //!            this.FormClosed -= new FormClosedEventHandler(this.FormBase_FormClosed);
         
            // 
            // tab_1
            // 
            // Gegerated from create event for tab_1
            this.tabpage_1 = new TabPage();
            this.tabpage_2 = new TabPage();
            this.tabpage_4 = new TabPage();
            this.tabpage_5 = new TabPage();
            tab_1.Controls.Add(tabpage_1);
            tab_1.Controls.Add(tabpage_2);
            tab_1.Controls.Add(tabpage_4);
            tab_1.Controls.Add(tabpage_5);
            tab_1.SelectedIndex = 0;
            tab_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_1.TabIndex = 1;
            tab_1.Height = 318;
            tab_1.Width = 415;
            tab_1.Top = 3;
            tab_1.Left = 5;
            tab_1.Selecting += new TabControlCancelEventHandler(tab1_selectionchanging);
            tab_1.SelectedIndexChanged += new EventHandler(tab_1_SelectedIndexChanged);
            // 
            // tabpage_1
            // 
            // Gegerated from create event for tabpage_1
            this.gb_1 = new GroupBox();
            dw_generic = new URdsDw();
            //!            dw_generic.DataObject = new DCustomerDetails2();
            tabpage_1.Controls.Add(dw_generic);
            tabpage_1.Controls.Add(gb_1);
            tabpage_1.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_1.Text = "Customer";
            tabpage_1.Height = 289;
            tabpage_1.Width = 407;
            tabpage_1.Top = 25;
            tabpage_1.Left = 3;
            tabpage_1.Name = tabpage_1.Text;//
            tabpage_1.Tag = "ComponentName=Customer;";
          
            // 
            // gb_1
            // 
            gb_1.Text = "Customer Details";
            gb_1.BackColor = System.Drawing.SystemColors.Control;
            gb_1.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_1.TabIndex = 2;
            gb_1.Location = new System.Drawing.Point(8, 9);
            gb_1.Size = new System.Drawing.Size(389, 270);
            // 
            // dw_generic
            // 
            //!            dw_generic.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_generic.VerticalScroll.Visible = false;

            dw_generic.TabIndex = 0;
            dw_generic.Size = new System.Drawing.Size(368, 240);
            dw_generic.Location = new System.Drawing.Point(14, 28);
            //!            dw_generic.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_generic_constructor);
            dw_generic.ItemChanged += new EventHandler(dw_generic_itemchanged);
            //!            dw_generic.PfcPreDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_generic_pfc_predeleterow);
            //!            dw_generic.PfcPreInsertRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_generic_pfc_preinsertrow);
            //!            dw_generic.PfcValidation += new UserEventDelegate1(dw_generic_pfc_validation);
            //!            dw_generic.PfcPostUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_generic_pfc_postupdate);
            //!            dw_generic.PfcPreUpdate += new UserEventDelegate1(dw_generic_pfc_preupdate);
            // 
            // tabpage_2
            // 
            // Gegerated from create event for tabpage_2
            this.dw_recipients2 = new URdsDw();
            //!            this.dw_recipients2.DataObject = new DRecipient();
            this.gb_recipients = new GroupBox();
            tabpage_2.Controls.Add(dw_recipients2);
            tabpage_2.Controls.Add(gb_recipients);
            tabpage_2.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_2.Text = "Recipients";
            tabpage_2.Size = new System.Drawing.Size(407, 289);
            tabpage_2.Top = 25;
            tabpage_2.Left = 3;
            tabpage_2.Name = tabpage_2.Text;//
            tabpage_2.Tag = "ComponentName=Recipients;";
            // 
            // dw_recipients2
            // 
            //!            dw_recipients2.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_recipients2.TabIndex = 0;
            dw_recipients2.Location = new System.Drawing.Point(10, 24);
            dw_recipients2.Size = new System.Drawing.Size(380, 243);
            //!            dw_recipients2.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_recipients2_constructor);
            dw_recipients2.ItemChanged += new EventHandler(dw_recipients2_itemchanged);
            //!            dw_recipients2.PfcPreDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_recipients2_pfc_predeleterow);
            //!            dw_recipients2.PfcPreUpdate += new UserEventDelegate1(dw_recipients2_pfc_preupdate);
            //!            dw_recipients2.PfcValidation += new UserEventDelegate1(dw_recipients2_pfc_validation);
            // 
            // gb_recipients
            // 
            gb_recipients.Text = "Recipients";
            gb_recipients.BackColor = System.Drawing.SystemColors.Control;
            gb_recipients.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_recipients.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_recipients.TabIndex = 1;
            gb_recipients.Location = new System.Drawing.Point(3, 6);
            gb_recipients.Size = new System.Drawing.Size(394, 268);
            // 
            // tabpage_4
            // 
            // Gegerated from create event for tabpage_4
            dw_occupations = new URdsDw();
            //!            dw_occupations.DataObject = new DCustomerOccupation();
            gb_occupations = new GroupBox();
            tabpage_4.Controls.Add(dw_occupations);
            tabpage_4.Controls.Add(gb_occupations);
            tabpage_4.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_4.Text = "Occupations";
            tabpage_4.BackColor = System.Drawing.Color.FromArgb(4, 235, 235, 233);
            tabpage_4.Size = new System.Drawing.Size(407, 289);
            tabpage_4.Top = 25;
            tabpage_4.Left = 3;
            tabpage_4.Name = tabpage_4.Text;//
            tabpage_4.Tag = "ComponentName=Occupations;";

            // 
            // dw_occupations
            // 
            //!            dw_occupations.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_occupations.TabIndex = 0;
            dw_occupations.Location = new System.Drawing.Point(10, 24);
            dw_occupations.Size = new System.Drawing.Size(382, 246);
            //!            dw_occupations.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_occupations_constructor);
            //!            dw_occupations.PfcPreUpdate += new UserEventDelegate1(dw_occupations_pfc_preupdate);
            //!            dw_occupations.PfcValidation += new UserEventDelegate1(dw_occupations_pfc_validation);

            // 
            // gb_occupations
            // 
            gb_occupations.Text = "Occupations";
            gb_occupations.BackColor = System.Drawing.SystemColors.Control;
            gb_occupations.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_occupations.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_occupations.TabIndex = 1;
            gb_occupations.Location = new System.Drawing.Point(3, 6);
            gb_occupations.Size = new System.Drawing.Size(394, 268);

            // 
            // tabpage_5
            // 
            // Gegerated from create event for tabpage_5
            dw_interests = new URdsDw();
            //!            dw_interests.DataObject = new DCustomerInterest();
            gb_interests = new GroupBox();
            tabpage_5.Controls.Add(dw_interests);
            tabpage_5.Controls.Add(gb_interests);
            tabpage_5.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_5.Text = "Interests";
            tabpage_5.BackColor = System.Drawing.Color.FromArgb(4, 235, 235, 233);
            tabpage_5.Size = new System.Drawing.Size(407, 289);
            tabpage_5.Top = 25;
            tabpage_5.Left = 3;
            tabpage_5.Name = tabpage_5.Text;//
            tabpage_5.Tag = "ComponentName=Interests;";

            // 
            // dw_interests
            // 
            //!            dw_interests.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_interests.TabIndex = 0;
            dw_interests.Location = new System.Drawing.Point(10, 24);
            dw_interests.Size = new System.Drawing.Size(382, 245);
            //!            dw_interests.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_interests_constructor);
            //!            dw_interests.PfcPreUpdate += new UserEventDelegate1(dw_interests_pfc_preupdate);
            //!            dw_interests.PfcValidation += new UserEventDelegate1(dw_interests_pfc_validation);
            // 
            // gb_interests
            // 
            gb_interests.Text = "Interests";
            gb_interests.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_interests.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_interests.TabIndex = 1;
            gb_interests.Location = new System.Drawing.Point(3, 6);
            gb_interests.Size = new System.Drawing.Size(394, 268);
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.Text = "w_customer";
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.Color.Gray;
            st_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_1.Location = new System.Drawing.Point(8, 337);
            st_1.Size = new System.Drawing.Size(67, 19);
            // 
            // cb_save
            // 
            this.AcceptButton = cb_save;
            cb_save.Text = "&Save";
            cb_save.TabIndex = 2;
            cb_save.Location = new System.Drawing.Point(256, 330);
            cb_save.Click += new EventHandler(cb_save_clicked);
            // 
            // cb_close
            // 
            this.CancelButton = cb_close;
            cb_close.Text = "&Close";
            cb_close.TabIndex = 3;
            cb_close.Location = new System.Drawing.Point(343, 330);
            cb_close.Click += new EventHandler(cb_close_clicked);
            // 
            // st_label
            // 
            st_label.Text = "w_customer";
            st_label.Visible = false;
            st_label.Location = new System.Drawing.Point(10, 334);
            st_label.Size = new System.Drawing.Size(70, 15);
            this.ResumeLayout();
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
