using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WGenericReportSearchWithDate
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
            this.Name = "w_generic_report_search_with_date";
            this.dw_criteria.DataObject = new DReportGenericCriteriaWithMonth();
            // 
            // st_label
            // 
            st_label.Width = 200;
            // 
            // dw_criteria
            // 
           
            dw_criteria.Height = 163;
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           // ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            // 
            // dw_results
            // 
            dw_results.Height = 167;
            dw_results.Top = 173;
            // 
            // pb_search
            // 
            // 
            // pb_open
            // 
            pb_open.Top = 170;
            this.ResumeLayout();
        }

        #endregion
    }
}