using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Controls;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WAllowanceSearch
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
            this.Text = "Contract Allowance Summary Report";
            this.Location = new System.Drawing.Point(46, 55);
            this.Size = new System.Drawing.Size(380, 230);
            //!this.dw_criteria.DataObject = new DReportAllowanceCriteria();
            // 
            // st_label
            // 
            st_label.Text = "w_allowance_search";
            st_label.Location = new System.Drawing.Point(3, 178);
            // 
            // dw_criteria
            // 
            //!dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_criteria.Location = new System.Drawing.Point(3, 10);
            dw_criteria.Size = new System.Drawing.Size(280, 160);
            // 
            // dw_results
            // 
            dw_results.Location = new System.Drawing.Point(3, 170);
            dw_results.Size = new System.Drawing.Size(310, 165);
            dw_results.Visible = false;
            dw_results.Tag = "ComponentName=Disabled;";
            // 
            // pb_search
            // 
            this.AcceptButton = pb_search;
            pb_search.Location = new System.Drawing.Point(307, 128);
            pb_search.Visible = false;
            pb_search.Tag = "ComponentName=Disabled;";
            // 
            // pb_open
            // 
            pb_open.Location = new System.Drawing.Point(307, 5);
            this.AcceptButton = pb_open;
            this.Name = "w_allowance_search";
            this.ResumeLayout();
        }
        #endregion
    }
}