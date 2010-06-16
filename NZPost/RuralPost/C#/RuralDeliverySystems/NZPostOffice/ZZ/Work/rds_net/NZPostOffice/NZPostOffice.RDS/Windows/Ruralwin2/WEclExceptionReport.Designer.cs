namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    partial class WEclExceptionReport
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
            this.rEclDataImportExeption1 = new NZPostOffice.RDS.DataControls.Report.REclDataImportExeption();
            this.SuspendLayout();
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cancel.Location = new System.Drawing.Point(726, 306);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 1;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.UseVisualStyleBackColor = true;
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_Click);
            // 
            // st_label
            // 
            this.st_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.st_label.AutoSize = true;
            this.st_label.CausesValidation = false;
            this.st_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.st_label.Location = new System.Drawing.Point(12, 311);
            this.st_label.Name = "st_label";
            this.st_label.Size = new System.Drawing.Size(112, 13);
            this.st_label.TabIndex = 0;
            this.st_label.Text = "WEclExceptionReport";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(15, 11);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(786, 289);
            this.crystalReportViewer1.TabIndex = 3;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // WEclExceptionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 336);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.st_label);
            this.Controls.Add(this.cb_cancel);
            this.Name = "WEclExceptionReport";
            this.Text = "WEclExceptionReport";
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
        private NZPostOffice.RDS.DataControls.Report.REclDataImportExeption rEclDataImportExeption1;
    }
}