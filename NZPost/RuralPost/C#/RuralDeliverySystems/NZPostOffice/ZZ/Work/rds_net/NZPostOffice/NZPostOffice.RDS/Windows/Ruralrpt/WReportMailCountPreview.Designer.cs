using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WReportMailCountPreview
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

            this.SuspendLayout();
            this.Text = "Mail Count Report";
            this.Height = 396;
            this.Width = 565;
            // 
            // st_label
            // 
            st_label.Width = 70;
            st_label.Top = 328;
            st_label.Left = 5;
            st_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            // 
            // dw_parameters
            // 
            dw_parameters.Top = 137;
            dw_parameters.Left = 68;
            // 
            // cb_getreport
            // 
            cb_getreport.Top = 147;
            cb_getreport.Left = 363;
            // 
            // dw_report
            // 
            dw_report.DataObject = new RMailCount();
            dw_report.Top = 4;
            dw_report.Left = 3;
            dw_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(dw_report);
            this.ResumeLayout();
        }

        #endregion
    }
}