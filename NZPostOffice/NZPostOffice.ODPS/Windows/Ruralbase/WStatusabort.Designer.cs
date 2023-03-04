using System.Windows.Forms;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WStatusabort
    {

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
            this.cb_1 = new Button();
            this.st_bar = new Label();
            this.st_limit = new Label();
            Controls.Add(cb_1);
            Controls.Add(st_bar);
            Controls.Add(st_limit);
//!            this.Icon = new System.Drawing.Icon("Information!");
            this.Text = "Printing your document ( s)...";
            this.Location = new System.Drawing.Point(128, 116);
            this.Size = new System.Drawing.Size(333, 96);

            // 
            // cb_1
            // 
            this.AcceptButton = cb_1;
            cb_1.Text = "&Abort";
            cb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 1;
            cb_1.Size = new System.Drawing.Size(54, 23);
            cb_1.Location = new System.Drawing.Point(130, 41);
            //cb_1.Click += new EventHandler(cb_1_clicked);

            // 
            // st_bar
            // 
            st_bar.TabStop = false;
            st_bar.BackColor = System.Drawing.Color.Teal;
            st_bar.ForeColor = System.Drawing.SystemColors.WindowText;
            st_bar.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_bar.Size = new System.Drawing.Size(270, 18);
            st_bar.Location = new System.Drawing.Point(14, 17);

            // 
            // st_limit
            // 
            st_limit.TabStop = false;
            st_limit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            st_limit.BorderStyle = BorderStyle.None;
            st_limit.BackColor = System.Drawing.Color.Silver;
            st_limit.ForeColor = System.Drawing.SystemColors.WindowText;
            st_limit.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_limit.Size = new System.Drawing.Size(299, 22);
            st_limit.Location = new System.Drawing.Point(12, 15);
            this.ResumeLayout();
        }


        #endregion
        private Button cb_1;

        private Label st_bar;

        private Label st_limit;

    }
}