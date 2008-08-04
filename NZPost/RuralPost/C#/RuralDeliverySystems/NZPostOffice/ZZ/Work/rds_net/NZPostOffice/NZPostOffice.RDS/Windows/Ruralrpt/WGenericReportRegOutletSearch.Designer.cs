using NZPostOffice.RDS.DataControls.Ruraldw;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WGenericReportRegOutletSearch
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
            this.Height = 195;
            this.Name = "w_generic_report_reg_outlet_search";
            this.dw_criteria.DataObject = new DReportGenericOutletCriteriawithrg();
           
            // 
            // st_label
            // 
            st_label.Top = 147;
            st_label.Width = 200;
          
            // 
            // dw_criteria
            // 
            dw_criteria.Size = new System.Drawing.Size(295, 140);
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            // ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
         
            // 
            // dw_results
            // 
            dw_results.Tag = "ComponentName=Disabled;";
            dw_results.Visible = false;
            dw_results.Height = 259;
            dw_results.Top = 79;
            
            // 
            // pb_search
            // 
            pb_search.Tag = "ComponentName=Disabled;";
            pb_search.Visible = false;
            pb_search.Top = 86;
           
            // 
            // pb_open
            // 
            pb_open.Top = 6;
            pb_open.Left = 306;
            this.ResumeLayout();
        }

        #endregion
    }
}