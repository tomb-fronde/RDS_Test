using System.Windows.Forms;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WPassword
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WPassword";

            this.SuspendLayout();
            this.sle_1 = new TextBox();
            this.sle_2 = new TextBox();
            this.cb_2 = new Button();
            this.cb_1 = new Button();
            Controls.Add(sle_1);
            Controls.Add(sle_2);
            Controls.Add(cb_2);
            Controls.Add(cb_1);
            this.Text = "Password Encryptor";
            this.ControlBox = true;
            this.Height = 94;
            this.Width = 297;
            this.Top = 329;
            this.Left = 318;
            // 
            // sle_1
            // 
            sle_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_1.ForeColor = System.Drawing.SystemColors.WindowText;
            // Metex Migrator Warning: property autohscroll was not converted
//?         sle_1.autohscroll = false;
            sle_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_1.TabIndex = 3;
            sle_1.Height = 23;
            sle_1.Width = 223;
            sle_1.Top = 6;
            sle_1.Left = 5;
            // 
            // sle_2
            // 
            sle_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_2.ForeColor = System.Drawing.SystemColors.WindowText;
            // Metex Migrator Warning: property autohscroll was not converted
//?         sle_2.autohscroll = false;
            sle_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_2.TabIndex = 1;
            sle_2.Height = 23;
            sle_2.Width = 222;
            sle_2.Top = 37;
            sle_2.Left = 5;
            // 
            // cb_2
            // 
            cb_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_2.Text = "Decrypt";
            cb_2.TabIndex = 2;
            cb_2.Height = 27;
            cb_2.Width = 54;
            cb_2.Top = 35;
            cb_2.Left = 232;
//?         cb_2.Click += new EventHandler(cb_2_clicked);
            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_1.Text = "Encrypt";
            cb_1.TabIndex = 3;
            cb_1.Height = 27;
            cb_1.Width = 54;
            cb_1.Top = 4;
            cb_1.Left = 232;
//?         cb_1.Click += new EventHandler(cb_1_clicked);
            this.ResumeLayout();
        }

        public TextBox sle_1;

        public TextBox sle_2;

        public Button cb_2;

        public Button cb_1;

        #endregion
    }
}