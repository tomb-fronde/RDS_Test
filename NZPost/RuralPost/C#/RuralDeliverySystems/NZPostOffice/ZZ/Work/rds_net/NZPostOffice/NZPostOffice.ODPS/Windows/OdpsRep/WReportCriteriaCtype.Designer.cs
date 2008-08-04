using System.Windows.Forms;
using System;
namespace NZPostOffice.ODPS.Windows.OdpsRep
{
    partial class WReportCriteriaCtype
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
            this.Text = "WReportCriteriaCtype";

            this.SuspendLayout();
            this.r_2 = new GroupBox();
            this.cbx_ctype = new CheckBox();
            this.cbx_1 = new CheckBox();
            this.cbx_2 = new CheckBox();
            this.cbx_3 = new CheckBox();
            this.cbx_4 = new CheckBox();
            this.cbx_5 = new CheckBox();
            this.cbx_6 = new CheckBox();
            this.cbx_7 = new CheckBox();
            this.cbx_8 = new CheckBox();
            this.cbx_9 = new CheckBox();
            this.cbx_10 = new CheckBox();
            //this.st_2 = new Label();
            this.cbx_all = new CheckBox();
            //this.r_1 = new GroupBox();
            Controls.Add(r_2);
            Controls.Add(cbx_ctype);
            this.r_2.Controls.Add(cbx_1);
            this.r_2.Controls.Add(cbx_2);
            this.r_2.Controls.Add(cbx_3);
            this.r_2.Controls.Add(cbx_4);
            this.r_2.Controls.Add(cbx_5);
            this.r_2.Controls.Add(cbx_6);
            this.r_2.Controls.Add(cbx_7);
            this.r_2.Controls.Add(cbx_8);
            this.r_2.Controls.Add(cbx_9);
            this.r_2.Controls.Add(cbx_10);
            //Controls.Add(st_2);
            this.r_2.Controls.Add(cbx_all);
            //Controls.Add(r_1);
            //?         this.toolbaralignment = floating!;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(463, 270);
            // 
            // cb_ok
            // 
            cb_ok.Location = new System.Drawing.Point(7, 178);
            // 
            // cb_cancel
            // 
            cb_cancel.Location = new System.Drawing.Point(77, 178);
            // 
            // dw_1
            // 
            dw_1.Height = 125;
            dw_1.Top = 7;
            // 
            // r_2
            // 
            r_2.Location = new System.Drawing.Point(256, 0);
            r_2.Size = new System.Drawing.Size(192, 245);
            r_2.Text = "Contract Type";
            r_2.BackColor = System.Drawing.Color.Empty;

            // 
            // cbx_ctype
            // 
            cbx_ctype.Text = "Contract Postie only";
            cbx_ctype.BackColor = System.Drawing.SystemColors.Control;
            cbx_ctype.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_ctype.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            cbx_ctype.Location = new System.Drawing.Point(16, 134);
            cbx_ctype.Size = new System.Drawing.Size(140, 16);
            cbx_ctype.Visible = false;
            // 
            // cbx_1
            // 
            cbx_1.Text = "none";
            cbx_1.BackColor = System.Drawing.SystemColors.Control;
            cbx_1.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);

            cbx_1.Location = new System.Drawing.Point(20, 40);
            cbx_1.Size = new System.Drawing.Size(166, 20);
            cbx_1.Click += new EventHandler(cbx_1_clicked);
            // 
            // cbx_2
            // 
            cbx_2.Text = "none";
            cbx_2.BackColor = System.Drawing.SystemColors.Control;
            cbx_2.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_2.Location = new System.Drawing.Point(20, 60);
            cbx_2.Size = new System.Drawing.Size(166, 20);
            cbx_2.Click += new EventHandler(cbx_2_clicked);
            // 
            // cbx_3
            // 
            cbx_3.Text = "none";
            cbx_3.BackColor = System.Drawing.SystemColors.Control;
            cbx_3.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_3.Location = new System.Drawing.Point(20, 80);
            cbx_3.Size = new System.Drawing.Size(166, 20);
            cbx_3.Click += new EventHandler(cbx_3_clicked);
            // 
            // cbx_4
            // 
            cbx_4.Text = "none";
            cbx_4.BackColor = System.Drawing.SystemColors.Control;
            cbx_4.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_4.Location = new System.Drawing.Point(20, 100);
            cbx_4.Size = new System.Drawing.Size(166, 20);
            cbx_4.Click += new EventHandler(cbx_4_clicked);
            // 
            // cbx_5
            // 
            cbx_5.Text = "none";
            cbx_5.BackColor = System.Drawing.SystemColors.Control;
            cbx_5.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_5.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_5.Location = new System.Drawing.Point(20, 120);
            cbx_5.Size = new System.Drawing.Size(166, 20);
            cbx_5.Click += new EventHandler(cbx_5_clicked);
            // 
            // cbx_6
            // 
            cbx_6.Text = "none";
            cbx_6.BackColor = System.Drawing.SystemColors.Control;
            cbx_6.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_6.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_6.Location = new System.Drawing.Point(20, 140);
            cbx_6.Size = new System.Drawing.Size(166, 20);
            cbx_6.Click += new EventHandler(cbx_6_clicked);
            // 
            // cbx_7
            // 
            cbx_7.Text = "none";
            cbx_7.BackColor = System.Drawing.SystemColors.Control;
            cbx_7.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_7.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_7.Location = new System.Drawing.Point(20, 160);
            cbx_7.Size = new System.Drawing.Size(166, 20);
            cbx_7.Click += new EventHandler(cbx_7_clicked);
            // 
            // cbx_8
            // 
            cbx_8.Text = "none";
            cbx_8.BackColor = System.Drawing.SystemColors.Control;
            cbx_8.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_8.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_8.Location = new System.Drawing.Point(20, 180);
            cbx_8.Size = new System.Drawing.Size(166, 20);
            cbx_8.Click += new EventHandler(cbx_8_clicked);
            // 
            // cbx_9
            // 
            cbx_9.Text = "none";
            cbx_9.BackColor = System.Drawing.SystemColors.Control;
            cbx_9.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_9.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_9.Location = new System.Drawing.Point(20, 200);
            cbx_9.Size = new System.Drawing.Size(166, 20);
            cbx_9.Click += new EventHandler(cbx_9_clicked);
            // 
            // cbx_10
            // 
            cbx_10.Text = "none";
            cbx_10.BackColor = System.Drawing.SystemColors.Control;
            cbx_10.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_10.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_10.Location = new System.Drawing.Point(20, 220);
            cbx_10.Size = new System.Drawing.Size(166, 20);
            cbx_10.Click += new EventHandler(cbx_10_clicked);

            //// 
            //// st_2
            //// 
            //st_2.TabStop = false;
            //st_2.Text = " Contract Type";
            //st_2.BackColor = System.Drawing.SystemColors.Control;
            //st_2.ForeColor = System.Drawing.SystemColors.WindowText;
            //st_2.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            //st_2.Size = new System.Drawing.Size(90, 16);
            //st_2.Location = new System.Drawing.Point(272, 9);
            // 
            // cbx_all
            // 
            cbx_all.Text = "All";
            cbx_all.BackColor = System.Drawing.SystemColors.Control;
            cbx_all.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_all.Font = new System.Drawing.Font("MS Sans Serif", 10, System.Drawing.FontStyle.Regular);
            cbx_all.Location = new System.Drawing.Point(20, 20);
            cbx_all.Size = new System.Drawing.Size(166, 20);
            cbx_all.Click += new EventHandler(cbx_all_clicked);

            //// 
            //// r_1
            //// 
            //r_1.Location = new System.Drawing.Point(257, 17);
            //r_1.Size = new System.Drawing.Size(190, 198);

            this.ResumeLayout();
        }

        public CheckBox cbx_ctype;

        public CheckBox cbx_1;
        public CheckBox cbx_2;
        public CheckBox cbx_3;
        public CheckBox cbx_4;
        public CheckBox cbx_5;
        public CheckBox cbx_6;
        public CheckBox cbx_7;
        public CheckBox cbx_8;
        public CheckBox cbx_9;
        public CheckBox cbx_10;

        //public Label st_2;
        public CheckBox cbx_all;

        //public GroupBox r_1;
        public GroupBox r_2;

    }
}