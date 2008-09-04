using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WMailCountSearch
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
            this.pb_1 = new Button();
            this.st_1 = new Label();
          
            this.Height = 396;
            // 
            // st_label
            // 
            st_label.Text = "RDRPTMCS";
            st_label.Location = new System.Drawing.Point(3, 348);
            // 
            // dw_criteria
            // 
           
            dw_criteria.Size = new System.Drawing.Size(293, 169);
            dw_criteria.Location = new System.Drawing.Point(3, 5);
            
            
           
            // 
            // dw_results
            // 
            
            dw_results.TabIndex = 5;
            dw_results.Size = new System.Drawing.Size(293, 164);
            dw_results.Location = new System.Drawing.Point(3, 176);
           
            // 
            // pb_search
            // 
            pb_search.TabIndex = 3;
            pb_search.Top = 4;
            // 
            // pb_open
            // 
            pb_open.TabIndex = 4;
            pb_open.Top = 176;
            // 
            // pb_1
            // 
            pb_1.Image = global::NZPostOffice.Shared.Properties.Resources.SAVE;
            pb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_1.TabIndex = 2;
            pb_1.Location = new System.Drawing.Point(195, 82);
            pb_1.Size = new System.Drawing.Size(21, 21);
            pb_1.BringToFront();
            
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_1.Text = " ( If 0, print data)";
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Location = new System.Drawing.Point(215, 153);
            st_1.Size = new System.Drawing.Size(73, 18);


            Controls.Add(pb_1);
            Controls.Add(st_1);
            this.Name = "w_mail_count_search";
            this.ResumeLayout();
        }

        private Button pb_1;

        private Label st_1;

        #endregion
    }
}