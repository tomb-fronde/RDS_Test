using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WOutletReport
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
            this.Text = "Base Office Outlet Report";
            this.Height = 418;
            // 
            // st_label
            // 
            st_label.Top = 354;
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
            //?dw_report.border = false;
            //!dw_report.DataObject = new ROutletBaseOfficeReport();
            dw_report.Height = 336;
            dw_report.Width = 537;
            dw_report.Top = 8;
            dw_report.Left = 8;
            this.ResumeLayout();
        }

        #endregion
    }
}