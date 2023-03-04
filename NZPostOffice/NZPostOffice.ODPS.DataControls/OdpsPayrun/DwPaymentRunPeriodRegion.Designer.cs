using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwPaymentRunPeriodRegion
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
        private DateTimeMaskedTextBox end_date;// System.Windows.Forms.MaskedTextBox end_date;
        private DateTimeMaskedTextBox start_date;// System.Windows.Forms.MaskedTextBox start_date;
        private System.Windows.Forms.TextBox owner_driver;
        private System.Windows.Forms.Label owner_driver_t;
        private System.Windows.Forms.Label start_date_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.owner_driver = new System.Windows.Forms.TextBox();
            this.end_date = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.start_date = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.start_date_t = new System.Windows.Forms.Label();
            this.owner_driver_t = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.PaymentRunPeriodRegion);
           
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.BackColor = System.Drawing.Color.White;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id.DropDownWidth = 172;
            this.region_id.Font = new System.Drawing.Font("Arial", 8F);
            this.region_id.ForeColor = System.Drawing.Color.Black;
            this.region_id.Location = new System.Drawing.Point(97, 27);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(172, 22);
            this.region_id.TabIndex = 20;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
           
            // 
            // owner_driver
            // 
            this.owner_driver.BackColor = System.Drawing.Color.White;
            this.owner_driver.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OwnerDriver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.owner_driver.Font = new System.Drawing.Font("Arial", 8F);
            this.owner_driver.ForeColor = System.Drawing.Color.Black;
            this.owner_driver.Location = new System.Drawing.Point(97, 50);
            this.owner_driver.MaxLength = 40;
            this.owner_driver.Name = "owner_driver";
            this.owner_driver.Size = new System.Drawing.Size(172, 20);
            this.owner_driver.TabIndex = 30;
            
            // 
            // end_date
            // 
            this.end_date.BackColor = System.Drawing.Color.White;
            this.end_date.Mask = "00/00/0000";
            this.end_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.end_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.end_date.DataBindings[0].DataSourceNullValue = null;
            this.end_date.ForeColor = System.Drawing.Color.White;
            this.end_date.Location = new System.Drawing.Point(209, 4);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(60, 20);
            this.end_date.TabIndex = 10;
            
            // 
            // start_date
            // 
            this.start_date.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.start_date.Mask = "00/00/0000";
            this.start_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.start_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.start_date.DataBindings[0].DataSourceNullValue = null;
            this.start_date.ForeColor = System.Drawing.Color.Black;
            this.start_date.Location = new System.Drawing.Point(97, 4);
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Size = new System.Drawing.Size(60, 20);
            this.start_date.TabIndex = 31;
           
            // 
            // start_date_t
            // 
            this.start_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.start_date_t.Font = new System.Drawing.Font("Arial", 8F);
            this.start_date_t.ForeColor = System.Drawing.Color.Black;
            this.start_date_t.Location = new System.Drawing.Point(48, 4);
            this.start_date_t.Name = "start_date_t";
            this.start_date_t.Size = new System.Drawing.Size(40, 14);
            this.start_date_t.TabIndex = 32;
            this.start_date_t.Text = "From:";
            this.start_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            // 
            // owner_driver_t
            // 
            this.owner_driver_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.owner_driver_t.Font = new System.Drawing.Font("Arial", 8F);
            this.owner_driver_t.ForeColor = System.Drawing.Color.Black;
            this.owner_driver_t.Location = new System.Drawing.Point(3, 50);
            this.owner_driver_t.Name = "owner_driver_t";
            this.owner_driver_t.Size = new System.Drawing.Size(85, 14);
            this.owner_driver_t.TabIndex = 33;
            this.owner_driver_t.Text = "Owner Driver:";
            this.owner_driver_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(177, 7);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(26, 14);
            this.t_1.TabIndex = 34;
            this.t_1.Text = "to:";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           
            // 
            // t_2
            // 
            this.t_2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_2.Font = new System.Drawing.Font("Arial", 8F);
            this.t_2.ForeColor = System.Drawing.Color.Black;
            this.t_2.Location = new System.Drawing.Point(45, 27);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(43, 14);
            this.t_2.TabIndex = 34;
            this.t_2.Text = "Region:";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           
            // 
            // DwPaymentRunPeriodRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.owner_driver);
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.start_date_t);
            this.Controls.Add(this.owner_driver_t);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.t_2);
            this.Name = "DwPaymentRunPeriodRegion";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
