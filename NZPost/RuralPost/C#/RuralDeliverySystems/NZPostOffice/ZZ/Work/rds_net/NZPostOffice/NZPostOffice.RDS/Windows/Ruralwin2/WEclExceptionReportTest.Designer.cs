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
            this.label2 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rEclDataImportExeptionTest1 = new NZPostOffice.RDS.DataControls.Report.REclDataImportExeptionTest();
            this.SuspendLayout();
            // 
            // cb_cancel
            // 
            this.cb_cancel.Location = new System.Drawing.Point(541, 234);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 1;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.UseVisualStyleBackColor = true;
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "WEclExceptionReportTest";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(15, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.rEclDataImportExeptionTest1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(601, 216);
            this.crystalReportViewer1.TabIndex = 3;
            // 
            // rEclDataImportExeptionTest1
            // 
            this.rEclDataImportExeptionTest1.FileName = "rassdk://C:\\Documents and Settings\\brittont.SYNERGYINT\\Local Settings\\Temp\\temp_d" +
                "ac97ebd-ceb5-4c47-b247-b1b592a000a2.rpt";
            // 
            // WEclExceptionReportTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 266);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_cancel);
            this.Name = "WEclExceptionReportTest";
            this.Text = "WEclExceptionReportTest";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cb_cancel;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private NZPostOffice.RDS.DataControls.Report.REclDataImportExeptionTest rEclDataImportExeptionTest1;
    }
}