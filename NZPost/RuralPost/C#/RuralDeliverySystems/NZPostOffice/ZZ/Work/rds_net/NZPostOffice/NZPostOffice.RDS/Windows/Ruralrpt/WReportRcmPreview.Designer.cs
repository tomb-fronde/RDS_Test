using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WReportRcmPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Label st_ret;

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
            this.st_ret = new Label();
            Controls.Add(st_ret);

            // 
            // st_label
            // 
            st_label.Text = "RDRPTRCP";

            //
            //dw_report
            //?dw_report.Width = 500;
            this.dw_report.DataObject = new RRcmStatNestedReport();
            this.dw_report.Dock = DockStyle.Fill;

            // 
            // st_ret
            // 
            st_ret.TabStop = false;
            st_ret.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_ret.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_ret.Size = new System.Drawing.Size(260, 15);

            this.ResumeLayout();
        }

        #endregion
    }
}