using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwOdpsOwnerdrivercontract
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

        private System.Windows.Forms.Label odc_standard_tax_rate_t;
        private System.Windows.Forms.Label odc_tax_percentage_t;
        private System.Windows.Forms.CheckBox odc_standard_tax_rate;
        private System.Windows.Forms.TextBox odc_tax_percentage;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwOdpsOwnerdrivercontract";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.OdpsOwnerdrivercontract);

            //
            // odc_standard_tax_rate
            //
            odc_standard_tax_rate = new System.Windows.Forms.CheckBox();
            this.odc_standard_tax_rate.DataBindings.Add(new System.Windows.Forms.Binding("Checked",this.bindingSource, "OdcStandardTaxRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.odc_standard_tax_rate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.odc_standard_tax_rate.Font = new System.Drawing.Font("Arial", 10F);
            this.odc_standard_tax_rate.ForeColor = System.Drawing.Color.Black;
            this.odc_standard_tax_rate.Location = new System.Drawing.Point(129, 8);
            this.odc_standard_tax_rate.Name = "odc_standard_tax_rate";
            this.odc_standard_tax_rate.Text = "";
            this.odc_standard_tax_rate.Size = new System.Drawing.Size(15, 19);
            this.odc_standard_tax_rate.TabIndex = 32766;
            this.Controls.Add(odc_standard_tax_rate);

            //
            // odc_tax_percentage
            //
            odc_tax_percentage = new System.Windows.Forms.TextBox();
            this.odc_tax_percentage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.odc_tax_percentage.Font = new System.Drawing.Font("Arial", 10F);
            this.odc_tax_percentage.ForeColor = System.Drawing.Color.Black;
            this.odc_tax_percentage.Location = new System.Drawing.Point(129, 38);
            this.odc_tax_percentage.MaxLength = 0;
            this.odc_tax_percentage.Name = "odc_tax_percentage";
            this.odc_tax_percentage.Size = new System.Drawing.Size(72, 19);
            this.odc_tax_percentage.TextAlign = HorizontalAlignment.Right;
            this.odc_tax_percentage.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "OdcTaxPercentage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.odc_tax_percentage.ReadOnly = true;
            this.Controls.Add(odc_tax_percentage);

            //
            // odc_standard_tax_rate_t
            //
            this.odc_standard_tax_rate_t = new System.Windows.Forms.Label();
            this.odc_standard_tax_rate_t.Font = new System.Drawing.Font("Arial", 10F);
            this.odc_standard_tax_rate_t.ForeColor = System.Drawing.Color.Black;
            this.odc_standard_tax_rate_t.Location = new System.Drawing.Point(-20, 8);
            this.odc_standard_tax_rate_t.Name = "odc_standard_tax_rate_t";
            this.odc_standard_tax_rate_t.Size = new System.Drawing.Size(150, 16);
            this.odc_standard_tax_rate_t.Text = "Standard Tax Rate:";
            this.odc_standard_tax_rate_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(odc_standard_tax_rate_t);

            //
            // odc_tax_percentage_t
            //
            this.odc_tax_percentage_t = new System.Windows.Forms.Label();
            this.odc_tax_percentage_t.Font = new System.Drawing.Font("Arial", 10F);
            this.odc_tax_percentage_t.ForeColor = System.Drawing.Color.Black;
            this.odc_tax_percentage_t.Location = new System.Drawing.Point(10, 38);
            this.odc_tax_percentage_t.Name = "odc_tax_percentage_t";
            this.odc_tax_percentage_t.Size = new System.Drawing.Size(120, 16);
            this.odc_tax_percentage_t.Text = "Tax Percentage:";
            this.odc_tax_percentage_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(odc_tax_percentage_t);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
