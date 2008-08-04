using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DPsReportCriteria
    {

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
            components = new System.ComponentModel.Container();
            this.Name = "DPsReportCriteria";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.PsReportCriteria);
            //
            // outlet_region_id_t
            //
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_region_id_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.outlet_region_id_t.ForeColor = System.Drawing.Color.Black;
            this.outlet_region_id_t.Location = new System.Drawing.Point(23, 1);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(76, 13);
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = ContentAlignment.MiddleRight;
            this.outlet_region_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(outlet_region_id_t);

            //
            // region_id_ro
            //
            region_id_ro = new Metex.Windows.DataEntityCombo();
            this.region_id_ro.AutoRetrieve = true;
            this.region_id_ro.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.region_id_ro.ForeColor = System.Drawing.Color.Black;
            this.region_id_ro.Location = new System.Drawing.Point(104, 1);
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Size = new System.Drawing.Size(182, 14);
            this.region_id_ro.TabIndex = 32766;
            this.region_id_ro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id_ro.Value = null;
            this.region_id_ro.ValueMember = "RegionId";
            this.region_id_ro.DropDownWidth = 182;
            this.region_id_ro.DataBindings.Add(
                new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true,
                System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(region_id_ro);

            //
            // region_id
            //
            region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.AutoRetrieve = true;
            this.region_id.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.region_id.ForeColor = System.Drawing.Color.Black;
            this.region_id.Location = new System.Drawing.Point(104, 1);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(182, 14);
            this.region_id.TabIndex = 20;
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DropDownWidth = 182;
            this.region_id.DataBindings.Add(
                new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true,
                System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(region_id);

            //
            // t_2
            //
            this.t_2 = new System.Windows.Forms.Label();
            this.t_2.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.t_2.ForeColor = System.Drawing.Color.Black;
            this.t_2.Location = new System.Drawing.Point(23, 21);
            this.t_2.Name = "outlet_region_id_t";
            this.t_2.Size = new System.Drawing.Size(76, 13);
            this.t_2.Text = "Reporting Month";
            this.t_2.TextAlign = ContentAlignment.MiddleRight;
            this.t_2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_2);

            //
            // report_date
            //
            report_date = new System.Windows.Forms.MaskedTextBox();
            this.report_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.report_date.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //?	this.report_date.ForeColor = System.Drawing.ColorTranslator.FromWin32(MS Sans Serif);
            this.report_date.Location = new System.Drawing.Point(104, 21);
            this.report_date.Name = "report_date";
            this.report_date.Size = new System.Drawing.Size(41, 14);
            this.report_date.TextAlign = HorizontalAlignment.Center;
            this.report_date.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.report_date.Mask = "";
            this.report_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ReportDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.report_date.TabIndex = 10;
            this.Controls.Add(report_date);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
        }
        #endregion

    }
}
