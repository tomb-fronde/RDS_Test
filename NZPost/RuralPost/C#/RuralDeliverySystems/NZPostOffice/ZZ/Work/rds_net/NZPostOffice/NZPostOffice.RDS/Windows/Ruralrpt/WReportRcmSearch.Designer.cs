using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Controls;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WReportRcmSearch
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
            this.Size = new System.Drawing.Size(380, 185);
            // 
            // st_label
            // 
            st_label.Text = "RDRPTRCS";
            st_label.Height = 14;
            st_label.Location = new System.Drawing.Point(3, 139);
            // 
            // dw_criteria
            // 
            dw_criteria.DataObject = new DReportRcmCriteria();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_criteria.Size = new System.Drawing.Size(296, 127);
            dw_criteria.Location = new System.Drawing.Point(3, 5);
            
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            
            // 
            // dw_results
            // 
            dw_results.Height = 259;
            dw_results.Top = 79;
            dw_results.Visible = false;
           
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            pb_search.Top = 38;
            pb_search.Left = 300;
            pb_search.Visible = false;
           
            pb_search.Tag = "ComponentName=Disabled;";
            // 
            // pb_open
            // 
            pb_open.Top = 3;
            pb_open.Left = 305;
            this.ResumeLayout();
        }

        #endregion
    }
}