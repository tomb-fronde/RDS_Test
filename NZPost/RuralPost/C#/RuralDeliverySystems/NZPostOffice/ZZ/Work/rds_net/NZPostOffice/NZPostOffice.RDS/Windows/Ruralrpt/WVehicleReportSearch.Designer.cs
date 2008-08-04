using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Controls;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WVehicleReportSearch
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
            this.Text = "Vehicle Age Report";
            this.Name = "w_vehicle_report_search";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(380, 186);
            // 
            // st_label
            // 
            st_label.Location = new System.Drawing.Point(1, 142);
            // 
            // dw_criteria
            // 
            dw_criteria.DataObject = new DReportGenericOutletCriteriawithrgct();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_criteria.Location = new System.Drawing.Point(3, 3);
            dw_criteria.Size = new System.Drawing.Size(300, 130);
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);

            // 
            // dw_results
            // 
            //dw_results.DataObject = new DReportGenericResults();
            dw_results.Tag = "ComponentName=Disabled;";
            dw_results.Visible = false;
            dw_results.Height = 259;
            dw_results.Top = 79;
            // 
            // pb_search
            // 
            pb_search.Tag = "ComponentName=Disabled;";
            pb_search.Visible = false;
            pb_search.Location = new System.Drawing.Point(300, 93);
            // 
            // pb_open
            // 
            pb_open.Location = new System.Drawing.Point(306, 11);
            this.ResumeLayout();
        }

        #endregion
    }
}