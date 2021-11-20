using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WRoadnameReport
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
            this.BackColor = System.Drawing.SystemColors.Control; 
            this.Text = "Road Name Report";
            this.Height = 543;
            this.Width = 739;
            // 
            // st_label
            // 
            st_label.Text = "RDRPTRN";
            st_label.Top = 477;
            st_label.Left = 7;
            // 
            // dw_parameters
            // 
            // 
            // cb_getreport
            // 
            // 
            // dw_report
            // 
            //!dw_report.DataObject = new RPsRoadnameTown();
            dw_report.Height = 461;
            dw_report.Width = 720;
            //dw_report.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_report_constructor);
            this.ResumeLayout();
        }

        #endregion
    }
}