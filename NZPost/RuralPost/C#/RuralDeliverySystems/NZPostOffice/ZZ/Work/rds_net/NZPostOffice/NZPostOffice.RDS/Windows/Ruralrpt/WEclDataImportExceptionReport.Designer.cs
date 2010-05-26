using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WEclDataImportExceptionReport
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
            this.Text = "ECL Data Import Exception Report";
            //!this.dw_report.DataObject = new RAllowanceReport();
            this.dw_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Height = 418;
           
            // 
            // st_label
            // 
            st_label.Top = 354;
            st_label.Visible = false;
            
            // 
            // dw_parameters
            // 
            dw_parameters.Enabled = false;
            
            // 
            // cb_getreport
            // 
            cb_getreport.Enabled = false;
            
            // 
            // dw_report
            // 
            dw_report.Size =new System.Drawing.Size(537,336);
            dw_report.Location=new System.Drawing.Point( 8,8);
            this.ResumeLayout();
        }

        #endregion
    }
}