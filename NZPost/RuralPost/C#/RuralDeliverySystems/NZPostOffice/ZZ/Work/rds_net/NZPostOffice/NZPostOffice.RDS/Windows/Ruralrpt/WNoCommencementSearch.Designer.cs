using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WNoCommencementSearch
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
            this.st_1 = new Label();
            this.st_2 = new Label();
            this.em_1 = new MaskedTextBox();
            this.pb_1 = new Button();
            this.dw_1 = new URdsDw();
            //!this.dw_1.DataObject = new DExtRegion();
            Controls.Add(st_1);
            Controls.Add(st_2);
            Controls.Add(em_1);
            Controls.Add(pb_1);
            Controls.Add(dw_1);
            this.Text = "Customer Commencement Date Report";
            this.ControlBox = true;
            this.Height = 154;
            this.Width = 307;
            // 
            // st_label
            // 
            st_label.Text = "RDRPTCS";
            st_label.Width = 70;
            st_label.Top = 84;
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.TabStop = false;
            st_1.Text = "Customers without commencement dates";
            st_1.Height = 18;
            st_1.Width = 200;
            st_1.Top = 7;
            st_1.Left = 8;
            // 
            // st_2
            // 
            st_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_2.ForeColor = System.Drawing.SystemColors.WindowText;
            st_2.TabStop = false;
            st_2.Text = "days or more after date first loaded";
            st_2.Height = 19;
            st_2.Width = 164;
            st_2.Top = 33;
            st_2.Left = 48;
            // 
            // em_1
            // 
            em_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            em_1.ForeColor = System.Drawing.SystemColors.WindowText;
            em_1.Mask = "###";
            em_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            em_1.TabIndex = 1;
            em_1.Height = 22;
            em_1.Width = 33;
            em_1.Top = 30;
            em_1.Left = 8;
            // 
            // pb_1
            // 
            pb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = pb_1;
            pb_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //?pb_1.Image = new System.Drawing.Bitmap("..\\bitmaps\\open.bmp");
            pb_1.TabIndex = 3;
            pb_1.Height = 31;
            pb_1.Width = 59;
            pb_1.Top = 11;
            pb_1.Left = 222;
            // 
            // dw_1
            // 
            //!dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_1.TabIndex = 2;
            dw_1.Height = 22;
            dw_1.Width = 169;
            dw_1.Top = 57;
            dw_1.Left = 5;
            //dw_1.Constructor +=new UserEventDelegate(dw_1_constructor);
            this.ResumeLayout();
        }


        #endregion

        public Label st_1;

        public Label st_2;

        public MaskedTextBox em_1;

        public Button pb_1;

        public URdsDw dw_1;
    }
}