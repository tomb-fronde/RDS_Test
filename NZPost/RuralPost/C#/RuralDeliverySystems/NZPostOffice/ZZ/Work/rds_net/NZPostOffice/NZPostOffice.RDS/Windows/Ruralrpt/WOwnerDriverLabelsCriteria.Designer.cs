using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WOwnerDriverLabelsCriteria
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
            this.Size = new System.Drawing.Size(380,180);
            this.Name = "w_owner_driver_labels_criteria";
            // 
            // st_label
            // 
            st_label.Text = "RDRPTODL";
            st_label.Top = 137;
            // 
            // dw_criteria
            // 
            dw_criteria.DataObject = new DOwnerDriverReportCriteria();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_criteria.Height = 125;
            dw_criteria.Width = 300;
            dw_criteria.Top = 8;
            dw_criteria.Left = 8;
            // 
            // dw_results
            // 
            dw_results.DataObject = new DReportGenericResults();
            dw_results.Height = 259;
            dw_results.Top = 79;
            dw_results.Visible = false;
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            pb_search.Visible = false;
            pb_search.Tag = "ComponentName=Disabled;";
            // 
            // pb_open
            // 
            pb_open.Top = 95;
            pb_open.Left = 311;
            this.ResumeLayout();
        }

        #endregion
    }
}