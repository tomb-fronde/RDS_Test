using System.Windows.Forms;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WZoomPrint
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
            this.st_2 = new System.Windows.Forms.Label();
            this.sle_custom = new System.Windows.Forms.TextBox();
            this.rb_custom = new System.Windows.Forms.RadioButton();
            this.cb_1 = new System.Windows.Forms.Button();
            this.cb_ok = new System.Windows.Forms.Button();
            this.rb_30 = new System.Windows.Forms.RadioButton();
            this.rb_65 = new System.Windows.Forms.RadioButton();
            this.rb_100 = new System.Windows.Forms.RadioButton();
            this.rb_200 = new System.Windows.Forms.RadioButton();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // st_2
            // 
            this.st_2.BackColor = System.Drawing.Color.Silver;
            this.st_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_2.Location = new System.Drawing.Point(124, 127);
            this.st_2.Name = "st_2";
            this.st_2.Size = new System.Drawing.Size(16, 18);
            this.st_2.TabIndex = 0;
            this.st_2.Text = "%";
            this.st_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sle_custom
            // 
            this.sle_custom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sle_custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sle_custom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_custom.Location = new System.Drawing.Point(89, 124);
            this.sle_custom.Name = "sle_custom";
            this.sle_custom.Size = new System.Drawing.Size(33, 13);
            this.sle_custom.TabIndex = 3;
            // 
            // rb_custom
            // 
            this.rb_custom.BackColor = System.Drawing.Color.Silver;
            this.rb_custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_custom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_custom.Location = new System.Drawing.Point(25, 123);
            this.rb_custom.Name = "rb_custom";
            this.rb_custom.Size = new System.Drawing.Size(60, 18);
            this.rb_custom.TabIndex = 4;
            this.rb_custom.Text = "Custom";
            this.rb_custom.UseVisualStyleBackColor = false;
            // 
            // cb_1
            // 
            this.cb_1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cb_1.Location = new System.Drawing.Point(150, 47);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(59, 22);
            this.cb_1.TabIndex = 2;
            this.cb_1.Text = "&Cancel";
            // 
            // cb_ok
            // 
            this.cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cb_ok.Location = new System.Drawing.Point(150, 19);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(59, 22);
            this.cb_ok.TabIndex = 1;
            this.cb_ok.Text = "&OK";
            // 
            // rb_30
            // 
            this.rb_30.BackColor = System.Drawing.Color.Silver;
            this.rb_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_30.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_30.Location = new System.Drawing.Point(25, 99);
            this.rb_30.Name = "rb_30";
            this.rb_30.Size = new System.Drawing.Size(54, 18);
            this.rb_30.TabIndex = 5;
            this.rb_30.Text = "30%";
            this.rb_30.UseVisualStyleBackColor = false;
            // 
            // rb_65
            // 
            this.rb_65.BackColor = System.Drawing.Color.Silver;
            this.rb_65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_65.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_65.Location = new System.Drawing.Point(25, 75);
            this.rb_65.Name = "rb_65";
            this.rb_65.Size = new System.Drawing.Size(54, 18);
            this.rb_65.TabIndex = 6;
            this.rb_65.Text = "65%";
            this.rb_65.UseVisualStyleBackColor = false;
            // 
            // rb_100
            // 
            this.rb_100.BackColor = System.Drawing.Color.Silver;
            this.rb_100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_100.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_100.Location = new System.Drawing.Point(25, 51);
            this.rb_100.Name = "rb_100";
            this.rb_100.Size = new System.Drawing.Size(54, 18);
            this.rb_100.TabIndex = 7;
            this.rb_100.Text = "100%";
            this.rb_100.UseVisualStyleBackColor = false;
            // 
            // rb_200
            // 
            this.rb_200.BackColor = System.Drawing.Color.Silver;
            this.rb_200.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_200.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_200.Location = new System.Drawing.Point(25, 27);
            this.rb_200.Name = "rb_200";
            this.rb_200.Size = new System.Drawing.Size(54, 18);
            this.rb_200.TabIndex = 8;
            this.rb_200.Text = "200%";
            this.rb_200.UseVisualStyleBackColor = false;
            // 
            // gb_1
            // 
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.gb_1.Location = new System.Drawing.Point(0, 0);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(209, 191);
            this.gb_1.TabIndex = 9;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "Magnification";
            // 
            // WZoomPrint
            // 
            this.AcceptButton = this.cb_ok;
            this.CancelButton = this.cb_1;
            this.ClientSize = new System.Drawing.Size(217, 273);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.sle_custom);
            this.Controls.Add(this.rb_custom);
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.rb_30);
            this.Controls.Add(this.rb_65);
            this.Controls.Add(this.rb_100);
            this.Controls.Add(this.rb_200);
            this.Controls.Add(this.gb_1);
            this.Name = "WZoomPrint";
            this.Text = "Zoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Label st_2;

        //private Label st_1;

        private TextBox sle_custom;

        private RadioButton rb_custom;

        private Button cb_1;

        private Button cb_ok;

        private RadioButton rb_30;

        private RadioButton rb_65;

        private RadioButton rb_100;

        private RadioButton rb_200;
        private GroupBox gb_1;

        //public Metex.PBLib.Components.Line ln_8;

        //public Metex.PBLib.Components.Line ln_1;

        //public Metex.PBLib.Components.Line ln_2;

        //public Metex.PBLib.Components.Line ln_3;

        //public Metex.PBLib.Components.Line ln_4;

        //public Metex.PBLib.Components.Line ln_5;

        //public Metex.PBLib.Components.Line ln_6;

        //public Metex.PBLib.Components.Line ln_7;
    }
}