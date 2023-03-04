using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WGenericReportSearchWithMthYr
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
            // 
            // dw_criteria
            // 
            this.dw_criteria.Size = new System.Drawing.Size(293, 163);
            // 
            // dw_results
            // 
            this.dw_results.Location = new System.Drawing.Point(3, 173);
            this.dw_results.Size = new System.Drawing.Size(293, 167);
            // 
            // pb_open
            // 
            this.pb_open.Location = new System.Drawing.Point(302, 170);
            // 
            // st_label
            // 
            this.st_label.Size = new System.Drawing.Size(200, 15);
            // 
            // WGenericReportSearchWithMthYr
            // 
            this.ClientSize = new System.Drawing.Size(372, 359);
            this.Name = "WGenericReportSearchWithMthYr";
            this.Controls.SetChildIndex(this.pb_open, 0);
            this.Controls.SetChildIndex(this.pb_search, 0);
            this.Controls.SetChildIndex(this.dw_results, 0);
            this.Controls.SetChildIndex(this.dw_criteria, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}