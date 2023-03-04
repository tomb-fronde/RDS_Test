using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.DataControls.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    // TJB  RPCR_113  July-2018
    // Numerous (most) lines changed by designer when window name added

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
            this.components = new System.ComponentModel.Container();
            this.tab_folder = new System.Windows.Forms.TabControl();
            this.tabpage_account_code = new System.Windows.Forms.TabPage();
            this.uo_1 = new NZPostOffice.ODPS.Windows.Odps.UoAccountCode(this.components);
            this.tabpage_pbu_code = new System.Windows.Forms.TabPage();
            this.uo_2 = new NZPostOffice.ODPS.Windows.Odps.UoPbuCode(this.components);
            this.tabpage_pct = new System.Windows.Forms.TabPage();
            this.tabpage_national = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tab_folder.SuspendLayout();
            this.tabpage_account_code.SuspendLayout();
            this.tabpage_pbu_code.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_folder
            // 
            this.tab_folder.Controls.Add(this.tabpage_account_code);
            this.tab_folder.Controls.Add(this.tabpage_pbu_code);
            this.tab_folder.Controls.Add(this.tabpage_pct);
            this.tab_folder.Controls.Add(this.tabpage_national);
            this.tab_folder.Font = new System.Drawing.Font("Arial", 8F);
            this.tab_folder.Location = new System.Drawing.Point(1, 2);
            this.tab_folder.Name = "tab_folder";
            this.tab_folder.SelectedIndex = 0;
            this.tab_folder.Size = new System.Drawing.Size(740, 340);
            this.tab_folder.TabIndex = 1;
            this.tab_folder.Tag = "resize=Scale;color=window;";
            this.tab_folder.SelectedIndexChanged += new System.EventHandler(this.tab_folder_selectionchanged);
            // 
            // tabpage_account_code
            // 
            this.tabpage_account_code.Controls.Add(this.uo_1);
            this.tabpage_account_code.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_account_code.Location = new System.Drawing.Point(4, 23);
            this.tabpage_account_code.Name = this.tabpage_account_code.Text;
            this.tabpage_account_code.Size = new System.Drawing.Size(732, 313);
            this.tabpage_account_code.TabIndex = 0;
            this.tabpage_account_code.Tag = "resize=scale;color=window;";
            this.tabpage_account_code.Text = "Account Code";
            // 
            // uo_1
            // 
            this.uo_1.Location = new System.Drawing.Point(0, 8);
            this.uo_1.Name = "uo_1";
            this.uo_1.Size = new System.Drawing.Size(733, 292);
            this.uo_1.TabIndex = 0;
            // 
            // tabpage_pbu_code
            // 
            this.tabpage_pbu_code.Controls.Add(this.uo_2);
            this.tabpage_pbu_code.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_pbu_code.Location = new System.Drawing.Point(4, 23);
            this.tabpage_pbu_code.Name = this.tabpage_pbu_code.Text;
            this.tabpage_pbu_code.Size = new System.Drawing.Size(732, 313);
            this.tabpage_pbu_code.TabIndex = 1;
            this.tabpage_pbu_code.Tag = "resize=scale; color=window;";
            this.tabpage_pbu_code.Text = "PBU Code";
            // 
            // uo_2
            // 
            this.uo_2.Location = new System.Drawing.Point(0, 8);
            this.uo_2.Name = "uo_2";
            this.uo_2.Size = new System.Drawing.Size(733, 292);
            this.uo_2.TabIndex = 0;
            // 
            // tabpage_pct
            // 
            this.tabpage_pct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_pct.Location = new System.Drawing.Point(4, 23);
            this.tabpage_pct.Name = this.tabpage_pct.Text;
            this.tabpage_pct.Size = new System.Drawing.Size(732, 313);
            this.tabpage_pct.TabIndex = 2;
            this.tabpage_pct.Tag = "resize=scale; color=window;";
            this.tabpage_pct.Text = "Payment Component Type";
            // 
            // tabpage_national
            // 
            this.tabpage_national.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_national.Location = new System.Drawing.Point(4, 23);
            this.tabpage_national.Name = this.tabpage_national.Text;
            this.tabpage_national.Size = new System.Drawing.Size(732, 313);
            this.tabpage_national.TabIndex = 3;
            this.tabpage_national.Tag = "resize=scale; color=window;";
            this.tabpage_national.Text = "National";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(7, 346);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 13);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "WCodeTableMaintenance";
            // 
            // WCodeTableMaintenance
            // 
            this.ClientSize = new System.Drawing.Size(740, 359);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tab_folder);
            this.Location = new System.Drawing.Point(217, 184);
            this.MaximizeBox = false;
            this.Name = "WCodeTableMaintenance";
            this.Tag = "color=window;";
            this.Text = "Code Maintenance";
            this.Controls.SetChildIndex(this.tab_folder, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.tab_folder.ResumeLayout(false);
            this.tabpage_account_code.ResumeLayout(false);
            this.tabpage_pbu_code.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private TextBox textBox1;
    }
}