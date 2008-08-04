using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwPaymentRunPeriod
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

        private DateTimeMaskedTextBox end_date;
        private DateTimeMaskedTextBox start_date;
        private System.Windows.Forms.TextBox owner_driver;
        private System.Windows.Forms.Label owner_driver_t;
        private System.Windows.Forms.Label start_date_t;
        private System.Windows.Forms.Label t_1;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.start_date_t = new System.Windows.Forms.Label();
            this.start_date = new DateTimeMaskedTextBox();
            this.end_date = new DateTimeMaskedTextBox();
            this.owner_driver = new System.Windows.Forms.TextBox();
            this.owner_driver_t = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
           
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.PaymentRunPeriod);
           
            // 
            // start_date_t
            // 
            this.start_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.start_date_t.Font = new System.Drawing.Font("Arial", 8F);
            this.start_date_t.ForeColor = System.Drawing.Color.Black;
            this.start_date_t.Location = new System.Drawing.Point(42, 9);
            this.start_date_t.Name = "start_date_t";
            this.start_date_t.Size = new System.Drawing.Size(46, 14);
            this.start_date_t.TabIndex = 0;
            this.start_date_t.Text = "From:";
            this.start_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            // 
            // start_date
            // 
            this.start_date.BackColor = System.Drawing.SystemColors.ButtonFace; 
            this.start_date.Mask = "00/00/0000";
            this.start_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.start_date.Location = new System.Drawing.Point(96, 9);
            this.start_date.Name = "start_date";
            this.start_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.start_date.DataBindings[0].DataSourceNullValue = null;
            this.start_date.ReadOnly = true;
            this.start_date.Size = new System.Drawing.Size(70, 20);
            this.start_date.TabIndex = 1;
           
            // 
            // end_date
            // 
            this.end_date.BackColor = System.Drawing.Color.White;
            this.end_date.Mask = "00/00/0000";
            this.end_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.end_date.Location = new System.Drawing.Point(199, 9);
            this.end_date.Name = "end_date";
            this.end_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.end_date.DataBindings[0].DataSourceNullValue = null;
            this.end_date.Size = new System.Drawing.Size(70, 20);
            this.end_date.TabIndex = 10;
            this.end_date.ValidatingType = typeof(System.DateTime);

            // 
            // owner_driver
            // 
            this.owner_driver.BackColor = System.Drawing.Color.White;
            this.owner_driver.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OwnerDriver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.owner_driver.Font = new System.Drawing.Font("Arial", 8F);
            this.owner_driver.ForeColor = System.Drawing.Color.Black;
            this.owner_driver.Location = new System.Drawing.Point(96, 37);
            this.owner_driver.MaxLength = 0;
            this.owner_driver.Name = "owner_driver";
            this.owner_driver.Size = new System.Drawing.Size(173, 20);
            this.owner_driver.TabIndex = 20;
           
            // 
            // owner_driver_t
            // 
            this.owner_driver_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.owner_driver_t.Font = new System.Drawing.Font("Arial", 8F);
            this.owner_driver_t.ForeColor = System.Drawing.Color.Black;
            this.owner_driver_t.Location = new System.Drawing.Point(0, 37);
            this.owner_driver_t.Name = "owner_driver_t";
            this.owner_driver_t.Size = new System.Drawing.Size(86, 14);
            this.owner_driver_t.TabIndex = 21;
            this.owner_driver_t.Text = "Owner Driver:";
            this.owner_driver_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(172, 9);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(26, 14);
            this.t_1.TabIndex = 34;
            this.t_1.Text = "to:";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          
            // 
            // DwPaymentRunPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.start_date_t);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.owner_driver);
            this.Controls.Add(this.owner_driver_t);
            this.Controls.Add(this.t_1);
            this.Name = "DwPaymentRunPeriod";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void end_date_Validated(object sender, EventArgs e)
        {
            try
            {
                DateTime.Parse(end_date.Text);
            }
            catch
            {
                this.end_date.Text = "00000000";
                MessageBox.Show("Invalid date value:" + end_date.ToString(), "Error");
            }
            //DateTime val;
            //DateTime.TryParse(this.end_date.Value == null ? "" : end_date.Value.ToString(), out val);
            //TimeSpan t;
            ////if (((Binding)sender).Control.Equals(end_date))
            //{
            //    if (TimeSpan.TryParse(end_date.Text, out t))
            //    {

            //        end_date.Value = new DateTime(val.Year, val.Month, val.Day).Add(t);
            //    }
            //    else
            //    {
            //        end_date.Value = new DateTime(val.Year, val.Month, val.Day);
            //    }
            //}
        }
        #endregion

    }
}
