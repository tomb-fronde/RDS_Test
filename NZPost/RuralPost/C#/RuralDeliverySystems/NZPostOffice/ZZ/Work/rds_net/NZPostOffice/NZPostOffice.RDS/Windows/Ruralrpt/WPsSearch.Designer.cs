using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WPsSearch
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
            this.Height = 151;
            // 
            // st_label
            // 
            st_label.Text = "RDRPTRS";
            st_label.Top = 90;
            st_label.Left = 3;
            // 
            // dw_criteria
            // 
            dw_criteria.DataObject = new DPsReportCriteria();
            dw_criteria.Height = 78;
            dw_criteria.Top = 5;
            // 
            // dw_results
            // 
            dw_results.DataObject = new DReportGenericResults();
            dw_results.Visible = false;
            dw_results.Height = 259;
            dw_results.Top = 79;
            // 
            // pb_search
            // 
            pb_search.Visible = false;
            // 
            // pb_open
            // 
            pb_open.Top = 52;
            this.ResumeLayout();
        }

        #endregion
    }
}