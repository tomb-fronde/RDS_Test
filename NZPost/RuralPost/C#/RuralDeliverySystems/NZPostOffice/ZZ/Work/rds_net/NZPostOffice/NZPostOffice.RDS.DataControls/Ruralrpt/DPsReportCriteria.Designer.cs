using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DPsReportCriteria
    {
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityCombo region_id;
        private Metex.Windows.DataEntityCombo region_id_ro;
        private System.Windows.Forms.MaskedTextBox report_date;
        private System.Windows.Forms.Label outlet_region_id_t;
        private System.Windows.Forms.Label t_2;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.region_id_ro = new Metex.Windows.DataEntityCombo();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.t_2 = new System.Windows.Forms.Label();
            this.report_date = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.PsReportCriteria);
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.ForeColor = System.Drawing.Color.Black;
            this.outlet_region_id_t.Location = new System.Drawing.Point(23, 1);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(76, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id_ro
            // 
            this.region_id_ro.AutoRetrieve = true;
            this.region_id_ro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.region_id_ro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.DropDownHeight = 150;
            this.region_id_ro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id_ro.DropDownWidth = 182;
            this.region_id_ro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_ro.ForeColor = System.Drawing.Color.Black;
            this.region_id_ro.Location = new System.Drawing.Point(104, 1);
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Size = new System.Drawing.Size(182, 21);
            this.region_id_ro.TabIndex = 32766;
            this.region_id_ro.Value = null;
            this.region_id_ro.ValueMember = "RegionId";
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id.DropDownWidth = 182;
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.ForeColor = System.Drawing.Color.Black;
            this.region_id.Location = new System.Drawing.Point(104, 1);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(182, 21);
            this.region_id.TabIndex = 20;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // t_2
            // 
            this.t_2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.ForeColor = System.Drawing.Color.Black;
            this.t_2.Location = new System.Drawing.Point(23, 21);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(76, 13);
            this.t_2.TabIndex = 32767;
            this.t_2.Text = "Reporting Month";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // report_date
            // 
            this.report_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.report_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ReportDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.report_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.report_date.Location = new System.Drawing.Point(104, 21);
            this.report_date.Name = "report_date";
            this.report_date.Size = new System.Drawing.Size(41, 20);
            this.report_date.TabIndex = 10;
            this.report_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DPsReportCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.region_id_ro);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.report_date);
            this.Name = "DPsReportCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

    }
}
