using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwReportCriteriaFinancial
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

        private DateTimeMaskedTextBox fedate;// System.Windows.Forms.MaskedTextBox fedate;
        private DateTimeMaskedTextBox fsdate;// System.Windows.Forms.MaskedTextBox fsdate;
        private System.Windows.Forms.Label fedate_t;
        private System.Windows.Forms.Label fsdate_t;
        private System.Windows.Forms.GroupBox gb_1;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwReportCriteriaFinancial";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.ReportCriteriaFinancial);

            //
            // fedate
            //
            fedate = new DateTimeMaskedTextBox();
            this.fedate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fedate.Location = new System.Drawing.Point(159, 29);
            this.fedate.Name = "fedate";
            this.fedate.Size = new System.Drawing.Size(69, 16);
            this.fedate.Mask = "00/00/0000";
            this.fedate.DataBindings.Add(new System.Windows.Forms.Binding("Value",this.bindingSource, "Fedate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fedate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.fedate.DataBindings[0].DataSourceNullValue = null;
            this.fedate.TabIndex = 40;
            this.Controls.Add(fedate);

            //
            // fsdate
            //
            fsdate = new DateTimeMaskedTextBox();
            this.fsdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fsdate.Location = new System.Drawing.Point(60, 29);
            this.fsdate.Name = "fsdate";
            this.fsdate.Size = new System.Drawing.Size(69, 16);
            this.fsdate.Mask = "00/00/0000";
            this.fsdate.DataBindings.Add(new System.Windows.Forms.Binding("Value",this.bindingSource, "Fsdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fsdate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.fsdate.DataBindings[0].DataSourceNullValue = null;
            this.fsdate.TabIndex = 30;
            this.Controls.Add(fsdate);
            //
            // fedate_t
            //
            this.fedate_t = new System.Windows.Forms.Label();
            this.fedate_t.Font = new System.Drawing.Font("Arial", 10F);
            this.fedate_t.ForeColor = System.Drawing.Color.Black;
            this.fedate_t.Location = new System.Drawing.Point(130, 29);
            this.fedate_t.Name = "fedate_t";
            this.fedate_t.Size = new System.Drawing.Size(30, 16);
            this.fedate_t.Text = "To:";
            this.fedate_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(fedate_t);

            //
            // fsdate_t
            //
            this.fsdate_t = new System.Windows.Forms.Label();
            this.fsdate_t.Font = new System.Drawing.Font("Arial", 10F);
            this.fsdate_t.ForeColor = System.Drawing.Color.Black;
            this.fsdate_t.Location = new System.Drawing.Point(10, 29);
            this.fsdate_t.Name = "fsdate_t";
            this.fsdate_t.Size = new System.Drawing.Size(50, 16);
            this.fsdate_t.Text = "From:";
            this.fsdate_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(fsdate_t);

            //
            // gb_1
            //
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.gb_1.Location = new System.Drawing.Point(5, 0);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(240, 65);
            this.gb_1.TabIndex = 81;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "Financial year:";
            this.Controls.Add(gb_1);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
