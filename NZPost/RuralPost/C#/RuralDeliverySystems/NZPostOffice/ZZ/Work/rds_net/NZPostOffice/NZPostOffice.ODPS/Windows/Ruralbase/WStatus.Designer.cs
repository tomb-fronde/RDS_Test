using System.Windows.Forms;
using System;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WStatus
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WStatus";

            this.SuspendLayout();
            this.st_message = new Label();
            this.st_bar = new Label();
            this.st_limit = new Label();
            Controls.Add(st_message);
            Controls.Add(st_bar);
            Controls.Add(st_limit);
            // Please add the corespondent full path of the icon
            this.Icon = new System.Drawing.Icon("Information!");
            //? this.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            this.Text = "Please wait while I process your request....";
            this.ControlBox = true;
            this.Height = 96;
            this.Width = 333;
            this.Top = 116;
            this.Left = 128;
            this.Load += new EventHandler(open);
            // 
            // st_message
            // 
            st_message.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);

            //? st_message.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_message.ForeColor = System.Drawing.SystemColors.WindowText;
            st_message.TabStop = false;
            st_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_message.Text = " ";
            st_message.Height = 17;
            st_message.Width = 296;
            st_message.Top = 42;
            st_message.Left = 12;
            // 
            // st_bar
            // 
            st_bar.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_bar.BackColor = System.Drawing.Color.Teal;
            st_bar.ForeColor = System.Drawing.SystemColors.WindowText;
            st_bar.TabStop = false;
            st_bar.Height = 18;
            st_bar.Width = 270;
            st_bar.Top = 17;
            st_bar.Left = 14;
            // 
            // st_limit
            // 
            st_limit.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_limit.BackColor = System.Drawing.Color.Silver;
            st_limit.ForeColor = System.Drawing.SystemColors.WindowText;
            st_limit.TabStop = false;
            st_limit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //?            st_limit.border = true;
            st_limit.Height = 22;
            st_limit.Width = 299;
            st_limit.Top = 15;
            st_limit.Left = 12;
            this.ResumeLayout();
        }

        public Label st_message;

        public Label st_bar;

        public Label st_limit;
    }
}