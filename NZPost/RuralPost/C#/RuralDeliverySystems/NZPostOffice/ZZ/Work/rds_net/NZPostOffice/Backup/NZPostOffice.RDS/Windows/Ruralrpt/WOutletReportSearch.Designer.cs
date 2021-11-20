using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WOutletReportSearch
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
            this.Height = 170;
            this.Width = 349;
            this.Name = "w_outlet_report_search";
            // 
            // st_label
            // 
            st_label.Text = "w_outlet_report_search";
            st_label.Top = 126;
            // 
            // dw_criteria
            // 

            //!dw_criteria.DataObject = new DOutletReportCriteria();
            //!dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_criteria.Height = 96;
            dw_criteria.Width = 328;
            dw_criteria.Left = 8;
            // 
            // dw_results
            // 

            //!dw_results.DataObject = new DReportGenericResults();
            dw_results.Height = 165;
            dw_results.Width = 295;
            dw_results.Top = 170;
            dw_results.Visible = false;
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            this.AcceptButton = pb_search;
            pb_search.Top = 112;
            pb_search.Left = 208;
            pb_search.Visible = false;
            pb_search.Tag = "ComponentName=Disabled;";
            // 
            // pb_open
            // 
            //?pb_open.originalsize = false;
            this.AcceptButton = pb_open;
            pb_open.Top = 105;
            pb_open.Left = 277;
            this.ResumeLayout();
        }

        #endregion
    }
}