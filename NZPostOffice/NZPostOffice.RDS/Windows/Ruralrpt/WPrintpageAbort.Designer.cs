using System.Windows.Forms;
using System;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WPrintpageAbort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //?public WSheet iw_Parent;

        public PictureBox p_1;

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
            this.p_1 = new PictureBox();
            this.cb_1 = new Button();
            Controls.Add(p_1);
            Controls.Add(cb_1);
            // Please add the corespondent full path of the icon
            this.Icon = System.Drawing.SystemIcons.Application;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
           
            // w_printpage_abort.BackColor = 81056981;
            this.BackColor = System.Drawing.SystemColors.Control;//this.BackColor = System.Drawing.Color.FromArgb(213, 212, 212);
            this.ControlBox = false;
            this.Height = 85;
            this.Width = 173;
            this.Top = 120;
            this.Left = 235;
            // 
            // p_1
            // 
            p_1.TabStop = false;
            //?p_1.Image = new System.Drawing.Bitmap("..\\bitmaps\\abortprv.bmp");
            p_1.Height = 21;
            p_1.Width = 26;
            p_1.Top = 18;
            p_1.Left = 32;
            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 10, System.Drawing.FontStyle.Bold);
            cb_1.Text = "&Abort";
            cb_1.TabIndex = 0;
            cb_1.Height = 29;
            cb_1.Width = 119;
            cb_1.Top = 14;
            cb_1.Left = 26;
            cb_1.Click += new EventHandler(cb_1_clicked);
            this.ResumeLayout();
        }

        #endregion
    }
}