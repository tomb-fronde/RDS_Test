using NZPostOffice.RDS.Controls;
using System.Windows.Forms;
using System;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WPrintAbort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public WAncestorWindow iw_Parent;

        public Label st_1;

        public Button cb_1;

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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.SuspendLayout();
            this.st_1 = new Label();
            this.cb_1 = new Button();
            Controls.Add(st_1);
            Controls.Add(cb_1);
            // Please add the corespondent full path of the icon
            this.Icon = System.Drawing.SystemIcons.Question;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WPrintAbort";

            // w_print_abort.BackColor = 81056981;
            this.BackColor = System.Drawing.SystemColors.Control;//this.BackColor = System.Drawing.Color.FromArgb(213, 212, 212);
            this.ControlBox = false;
            this.Height = 137;
            this.Width = 175;
            this.Top = 120;
            this.Left = 235;
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 10, System.Drawing.FontStyle.Bold);
           
            // st_1.BackColor = 80269524;
            st_1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_1.ForeColor = System.Drawing.Color.Navy;
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_1.Text = "Cancels the retrieval of data for previewing";
            st_1.Height = 55;
            st_1.Width = 121;
            st_1.Top = 49;
            st_1.Left = 23;
            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 10, System.Drawing.FontStyle.Bold);
            cb_1.Text = "&Abort";
            cb_1.TabIndex = 0;
            cb_1.Height = 29;
            cb_1.Width = 119;
            cb_1.Top = 13;
            cb_1.Left = 26;
            cb_1.Click += new EventHandler(cb_1_clicked);
            this.ResumeLayout();
        }

        #endregion
    }
}