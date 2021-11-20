using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
namespace NZPostOffice.ODPS.Windows.OdpsRep
{
    partial class WReport
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(644, 449);
            dw_report = new URdsDw();
            Controls.Add(dw_report);

            // 
            // dw_report
            // 
            dw_report.Location = new System.Drawing.Point(5, 6);
            dw_report.Size = new System.Drawing.Size(627, 388);
            dw_report.Tag = "resize=scale";
            dw_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeLayout();
        }

        public URdsDw dw_report;
    }
}