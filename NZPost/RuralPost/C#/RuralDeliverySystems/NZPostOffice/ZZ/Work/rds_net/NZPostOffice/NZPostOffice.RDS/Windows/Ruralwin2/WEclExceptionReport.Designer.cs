namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    partial class WEclExceptionReportTest
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
            this.cb_cancel = new System.Windows.Forms.Button();
            this.st_label = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rEclDataImportExeptionTest1 = new NZPostOffice.RDS.DataControls.Report.REclDataImportExeptionTest();
            this.SuspendLayout();
            // 
            // cb_cancel
            // 
            this.cb_cancel.Location = new System.Drawing.Point(741, 297);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 1;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.UseVisualStyleBackColor = true;
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_Click);
            // 
            // st_label
            // 
            this.st_label.AutoSize = true;
            this.st_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.st_label.Location = new System.Drawing.Point(12, 302);
            this.st_label.Name = "st_label";
            this.st_label.Size = new System.Drawing.Size(133, 13);
            this.st_label.TabIndex = 0;
            this.st_label.Text = "WEclExceptionReportTest";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(15, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(801, 279);
            this.crystalReportViewer1.TabIndex = 3;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // WEclExceptionReportTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 326);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.st_label);
            this.Controls.Add(this.cb_cancel);
            this.Name = "WEclExceptionReportTest";
            this.Text = "WEclExceptionReportTest";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cb_cancel;
        private System.Windows.Forms.Label st_label;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private NZPostOffice.RDS.DataControls.Report.REclDataImportExeptionTest rEclDataImportExeptionTest1;
    }
}