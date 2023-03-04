using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwReportCriteria
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
        private System.Windows.Forms.Label sdate_t;
        private DateTimeMaskedTextBox fedate;
        private DateTimeMaskedTextBox fsdate;
        private System.Windows.Forms.Label fedate_t;
        private System.Windows.Forms.Label edate_t;
        private DateTimeMaskedTextBox edate;
        private DateTimeMaskedTextBox sdate;
        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.GroupBox gb_3;
        private System.Windows.Forms.Label fsdate_t;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwReportCriteria";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.ReportCriteria);

            //
            // sdate
            //
            sdate = new DateTimeMaskedTextBox();
            this.sdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sdate.Location = new System.Drawing.Point(60, 25);
            this.sdate.Name = "sdate";
            this.sdate.Size = new System.Drawing.Size(69, 16);
            this.sdate.BackColor = System.Drawing.SystemColors.Control;
            this.sdate.Mask = "00/00/0000";
            this.sdate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Sdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sdate.ReadOnly = true;
            this.sdate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.sdate.DataBindings[0].DataSourceNullValue = null;
            this.Controls.Add(sdate);

            //
            // edate_t
            //
            this.edate_t = new System.Windows.Forms.Label();
            this.edate_t.Font = new System.Drawing.Font("Arial", 10F);
            this.edate_t.ForeColor = System.Drawing.Color.Black;
            this.edate_t.Location = new System.Drawing.Point(130, 25);
            this.edate_t.Name = "edate_t";
            this.edate_t.Size = new System.Drawing.Size(30, 16);
            this.edate_t.Text = "To:";
            this.edate_t.TextAlign = ContentAlignment.MiddleRight;
            this.edate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(edate_t);

            //
            // edate
            //
            edate = new DateTimeMaskedTextBox();
            this.edate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edate.Location = new System.Drawing.Point(159, 25);
            this.edate.Name = "edate";
            this.edate.Size = new System.Drawing.Size(69, 16);
            this.edate.BackColor = System.Drawing.Color.White;
            this.edate.Mask = "00/00/0000";
            this.edate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Edate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.edate.TabIndex = 10;
            this.edate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.edate.DataBindings[0].DataSourceNullValue = null;
            this.Controls.Add(edate);

            //
            // sdate_t
            //
            this.sdate_t = new System.Windows.Forms.Label();
            this.sdate_t.Font = new System.Drawing.Font("Arial", 10F);
            this.sdate_t.ForeColor = System.Drawing.Color.Black;
            this.sdate_t.Location = new System.Drawing.Point(10, 25);
            this.sdate_t.Name = "sdate_t";
            this.sdate_t.Size = new System.Drawing.Size(50, 16);
            this.sdate_t.Text = "From:";
            this.sdate_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(sdate_t);

            //
            // fedate
            //
            fedate = new DateTimeMaskedTextBox();
            this.fedate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fedate.Location = new System.Drawing.Point(161, 205);
            this.fedate.Name = "fedate";
            this.fedate.Size = new System.Drawing.Size(69, 16);
            this.fedate.BackColor = System.Drawing.Color.White;
            this.fedate.Mask = "00/00/0000";
            this.fedate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Fedate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fedate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.fedate.DataBindings[0].DataSourceNullValue = null;
            this.fedate.ReadOnly = true;
            this.Controls.Add(fedate);

            //
            // fedate_t
            //
            this.fedate_t = new System.Windows.Forms.Label();
            this.fedate_t.Font = new System.Drawing.Font("Arial", 10F);
            this.fedate_t.ForeColor = System.Drawing.Color.Black;
            this.fedate_t.Location = new System.Drawing.Point(130, 205);
            this.fedate_t.Name = "fedate_t";
            this.fedate_t.Size = new System.Drawing.Size(30, 16);
            this.fedate_t.Text = "To:";
            this.fedate_t.TextAlign = ContentAlignment.MiddleRight;
            this.fedate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(fedate_t);

            //
            // fsdate
            //
            fsdate = new DateTimeMaskedTextBox();
            this.fsdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D ;
            this.fsdate.Location = new System.Drawing.Point(62, 205);
            this.fsdate.Name = "fsdate";
            this.fsdate.Size = new System.Drawing.Size(69, 16);
            this.fsdate.BackColor = System.Drawing.Color.White;
            this.fsdate.Mask = "00/00/0000";
            this.fsdate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Fsdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fsdate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.fsdate.DataBindings[0].DataSourceNullValue = null;
            this.fsdate.ReadOnly = true;
            this.Controls.Add(fsdate);

            //
            // fsdate_t
            //
            this.fsdate_t = new System.Windows.Forms.Label();
            this.fsdate_t.Font = new System.Drawing.Font("Arial", 10F);
            this.fsdate_t.ForeColor = System.Drawing.Color.Black;
            this.fsdate_t.Location = new System.Drawing.Point(12, 205);
            this.fsdate_t.Name = "fsdate_t";
            this.fsdate_t.Size = new System.Drawing.Size(50, 16);
            this.fsdate_t.Text = "From:";
            this.fsdate_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(fsdate_t);

            //
            // gb_1
            //
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.gb_1.Location = new System.Drawing.Point(5, 180);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(240, 55);
            this.gb_1.TabIndex = 81;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "Financial year:";
            this.Controls.Add(gb_1);

            //
            // gb_3
            //
            this.gb_3 = new System.Windows.Forms.GroupBox();
            this.gb_3.Location = new System.Drawing.Point(5, 0);
            this.gb_3.Name = "gb_3";
            this.gb_3.Size = new System.Drawing.Size(240, 55);
            this.gb_3.TabIndex = 81;
            this.gb_3.TabStop = false;
            this.gb_3.Text = "Report date:";
            this.Controls.Add(gb_3);

            //
            // region_id
            //
            region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.AutoRetrieve = true;
            this.region_id.BackColor = System.Drawing.Color.White;
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Arial", 10F);
            this.region_id.ForeColor = System.Drawing.Color.Black;
            this.region_id.Location = new System.Drawing.Point(19, 90);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(209, 17);
            this.region_id.TabIndex = 32766;
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DropDownWidth = 209;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(region_id);

            //
            // gb_2
            //
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.gb_2.Location = new System.Drawing.Point(5, 70);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(240, 55);
            this.gb_2.TabIndex = 81;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "Region";
            this.Controls.Add(gb_2);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
