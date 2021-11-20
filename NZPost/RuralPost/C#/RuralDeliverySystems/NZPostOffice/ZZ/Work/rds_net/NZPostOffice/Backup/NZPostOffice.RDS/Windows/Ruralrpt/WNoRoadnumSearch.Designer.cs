using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using System;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WNoRoadnumSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Label st_header;

        public Label st_contract;

        public RadioButton rb_contract;

        public TextBox sle_contract_number;

        public Label st_town;

        public RadioButton rb_town;

        public URdsDw dw_select;

        public Button pb_open;

        /// <summary>
        /// 
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.SuspendLayout();
            this.st_header = new Label();
            this.st_contract = new Label();
            this.rb_contract = new RadioButton();
            this.sle_contract_number = new TextBox();
            this.st_town = new Label();
            this.rb_town = new RadioButton();
            this.dw_select = new URdsDw();
            this.pb_open = new Button();
            Controls.Add(dw_select);
            Controls.Add(st_header);
            Controls.Add(st_contract);
            Controls.Add(rb_contract);

            Controls.Add(st_town);
            Controls.Add(rb_town);

            Controls.Add(pb_open);
            Controls.Add(sle_contract_number);
            // w_no_roadnum_search.BackColor = 80269524;
            this.BackColor = System.Drawing.SystemColors.Control;//this.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Unnumbered Address Search";
            this.Height = 142;
            this.Width = 364;
            this.Top = 121;
            this.Left = 231;
            this.Tag = "Unnumbered Address Search";
            // 
            // st_label
            // 
            st_label.Text = "RDRPTRNN";
            st_label.Top = 94;
            st_label.Left = 7;
            // 
            // st_header
            // 
            st_header.TabStop = false;
            st_header.Text = "Search Criteria";
            // st_header.BackColor = 80269524;
            st_header.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_header.ForeColor = System.Drawing.SystemColors.WindowText;
            st_header.Font = new System.Drawing.Font("MS Sans Serif", 9, System.Drawing.FontStyle.Bold);
            st_header.Height = 15;
            st_header.Width = 105;
            st_header.Top = 10;
            st_header.Left = 15;
            // 
            // st_contract
            // 
            st_contract.TabStop = false;
            st_contract.Text = "Contract";
            // st_contract.BackColor = 80269524;
            st_contract.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_contract.ForeColor = System.Drawing.SystemColors.WindowText;
            st_contract.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_contract.Height = 19;
            st_contract.Width = 54;
            st_contract.Top = 59;
            st_contract.Left = 32;
            // 
            // rb_contract
            // 
            //?rb_contract.lefttext = true;
            rb_contract.BackColor = System.Drawing.SystemColors.Control;
            rb_contract.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_contract.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            rb_contract.Height = 19;
            rb_contract.Width = 15;
            rb_contract.Top = 57;
            rb_contract.Left = 15;

            rb_contract.Tag = "contract check";
            rb_contract.Click += new EventHandler(rb_contract_clicked);
            // 
            // sle_contract_number
            // 
            //? sle_contract_number.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //?sle_contract_number.autohscroll = false;
            sle_contract_number.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_contract_number.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_contract_number.TabIndex = 1;
            sle_contract_number.Height = 23;
            sle_contract_number.Width = 102;
            sle_contract_number.Top = 56;
            sle_contract_number.Left = 110;
            sle_contract_number.BringToFront();
            sle_contract_number.Tag = "for entry of contract number";
            // 
            // st_town
            // 
            st_town.TabStop = false;
            st_town.Text = "Town / City";
            st_town.BackColor = System.Drawing.SystemColors.Control;
            st_town.ForeColor = System.Drawing.SystemColors.WindowText;
            st_town.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_town.Height = 19;
            st_town.Width = 70;
            st_town.Top = 30;
            st_town.Left = 32;
            st_town.Tag = "town text";
            // 
            // rb_town
            // 
            //?rb_town.lefttext = true;
            rb_town.Checked = true;
            rb_town.BackColor = System.Drawing.SystemColors.Control;
            rb_town.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_town.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            rb_town.Height = 10;
            rb_town.Width = 15;
            rb_town.Top = 29;
            rb_town.Left = 15;
            rb_town.Tag = "town check";
            rb_town.Click += new EventHandler(rb_town_clicked);
            // 
            // dw_select
            // 
            //!dw_select.DataObject = new DTownSelect();
            //!dw_select.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //dw_select.VerticalScroll.Visible = false;
            //dw_select.HorizontalScroll.Visible = true;
            dw_select.TabIndex = 2;
            dw_select.Height = 85;
            dw_select.Width = 280;
            dw_select.Top = 5;
            dw_select.Left = 7;
            dw_select.SendToBack();
            dw_select.Click += new EventHandler(dw_select_clicked);
            //dw_select.Constructor += new UserEventDelegate(dw_select_constructor);
            // 
            // pb_open
            // 
            pb_open.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pb_open.Image = global::NZPostOffice.Shared.Properties.Resources.OPEN;
            this.AcceptButton = pb_open;
            pb_open.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_open.TabIndex = 1;
            pb_open.Height = 31;
            pb_open.Width = 59;
            pb_open.Top = 7;
            pb_open.Left = 290;
            pb_open.Click += new EventHandler(pb_open_clicked);
            this.ResumeLayout();
        }

        #endregion
    }
}
