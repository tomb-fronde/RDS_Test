using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.DataControls.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class WCodeTableMaintenance
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

            this.tab_folder = new TabControl();
            Controls.Add(tab_folder);
            this.MaximizeBox = false;
            this.Tag = "color=window;";
            this.Text = "Code Maintenance";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(748, 370);
            this.Location = new System.Drawing.Point(217, 184);

            // 
            // tab_folder
            // 
            tabpage_account_code = new TabPage();
            tabpage_pbu_code = new TabPage();
            tabpage_pct = new TabPage();
            tabpage_national = new TabPage();
            tab_folder.Controls.Add(tabpage_account_code);
            tab_folder.Controls.Add(tabpage_pbu_code);
            tab_folder.Controls.Add(tabpage_pct);
            tab_folder.Controls.Add(tabpage_national);
            tab_folder.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            tab_folder.SelectedIndex = 0;
            tab_folder.Tag = "resize=Scale;color=window;";
            tab_folder.TabIndex = 1;
            tab_folder.Size = new System.Drawing.Size(740, 340);
            tab_folder.Location = new System.Drawing.Point(1, 2);
            tab_folder.SelectedIndexChanged += new EventHandler(tab_folder_selectionchanged);

            // 
            // tabpage_account_code
            // 
            uo_1 = new UoAccountCode();
            tabpage_account_code.Controls.Add(uo_1);
            tabpage_account_code.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_account_code.Text = "Account Code";
            tabpage_account_code.Name = tabpage_account_code.Text;
            tabpage_account_code.Tag = "resize=scale;color=window;";
            tabpage_account_code.Size = new System.Drawing.Size(733, 308);
            tabpage_account_code.Top = 28;
            tabpage_account_code.Left = 3;

            // 
            // uo_1
            // 
            uo_1.TabIndex = 0;
            uo_1.Location = new System.Drawing.Point(0, 8);
            uo_1.Size = new System.Drawing.Size(733, 292);

            // 
            // tabpage_pbu_code
            // 
            uo_2 = new UoPbuCode();
            tabpage_pbu_code.Controls.Add(uo_2);
            tabpage_pbu_code.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_pbu_code.Text = "PBU Code";
            tabpage_pbu_code.Name = tabpage_pbu_code.Text;

            tabpage_pbu_code.Tag = "resize=scale; color=window;";
            tabpage_pbu_code.Size = new System.Drawing.Size(733, 308);
            tabpage_pbu_code.Top = 28;
            tabpage_pbu_code.Left = 3;

            // 
            // uo_2
            // 
            uo_2.TabIndex = 0;
            uo_2.Location = new System.Drawing.Point(0, 8);
            uo_2.Size = new System.Drawing.Size(733, 292);

            // 
            // tabpage_pct
            // 
            uo_3 = new UoPaymentComponentType();
            tabpage_pct.Controls.Add(uo_3);
            tabpage_pct.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_pct.Text = "Payment Component Type";
            tabpage_pct.Name = tabpage_pct.Text;
            tabpage_pct.Tag = "resize=scale; color=window;";
            tabpage_pct.Size = new System.Drawing.Size(733, 308);
            tabpage_pct.Top = 28;
            tabpage_pct.Left = 3;

            // 
            // uo_3
            //
            uo_3.TabIndex = 0;
            uo_3.Location = new System.Drawing.Point(0, 8);
            uo_3.Size = new System.Drawing.Size(733, 292);

            // 
            // tabpage_national
            // 
            uo_4 = new UoNational();
            tabpage_national.Controls.Add(uo_4);
            tabpage_national.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_national.Text = "National";
            tabpage_national.Name = tabpage_national.Text;
            tabpage_national.Tag = "resize=scale; color=window;";
            tabpage_national.Size = new System.Drawing.Size(733, 308);
            tabpage_national.Top = 28;
            tabpage_national.Left = 3;

            // 
            // uo_4
            // 
            uo_4.TabIndex = 0;
            uo_4.Size = new System.Drawing.Size(733, 300);
            uo_4.Location = new System.Drawing.Point(0, 8);

            this.ResumeLayout();
        }

        #endregion

        public TabControl tab_folder;

        public TabPage tabpage_account_code;
        public UoAccountCode uo_1;

        public TabPage tabpage_pbu_code;
        public UoPbuCode uo_2;

        public TabPage tabpage_pct;
        public UoPaymentComponentType uo_3;

        public TabPage tabpage_national;
        public UoNational uo_4;
    }
}