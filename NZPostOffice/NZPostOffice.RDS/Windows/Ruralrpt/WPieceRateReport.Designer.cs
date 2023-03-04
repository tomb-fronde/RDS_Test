using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WPieceRateReport
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
            this.Text = "Piece Rate Report";
            this.ControlBox = true;
            // 
            // st_label
            // 
            // 
            // cb_getreport
            // 
            // 
            // dw_report
            // 
            //!dw_report.DataObject = new RPieceRateReport();
            dw_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(dw_report);
            this.ResumeLayout();
        }

        #endregion
    }
}