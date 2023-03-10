using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    // TJB  RPCR_139 Bugfix July-2019
    // Changed contract_no to string (was numericmasked)
    //
    // TJB  RPCR_141  June-2019
    // Added contract_no and rg_code dropdown
    // Added this.contract_no.CausesValidation = false;

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
        private System.Windows.Forms.Label end_date_t;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label rg_code_t;
        private Metex.Windows.DataEntityCombo rg_code;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.start_date_t = new System.Windows.Forms.Label();
            this.start_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.end_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.owner_driver = new System.Windows.Forms.TextBox();
            this.owner_driver_t = new System.Windows.Forms.Label();
            this.end_date_t = new System.Windows.Forms.Label();
            this.contract_no_t = new System.Windows.Forms.Label();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.contract_no = new System.Windows.Forms.TextBox();
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
            this.start_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.start_date.EditMask = "";
            this.start_date.Location = new System.Drawing.Point(96, 9);
            this.start_date.Mask = "00/00/0000";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Size = new System.Drawing.Size(70, 20);
            this.start_date.TabIndex = 1;
            this.start_date.Text = "00000000";
            this.start_date.Value = null;
            // 
            // end_date
            // 
            this.end_date.BackColor = System.Drawing.Color.White;
            this.end_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.end_date.EditMask = "";
            this.end_date.Location = new System.Drawing.Point(199, 9);
            this.end_date.Mask = "00/00/0000";
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(70, 20);
            this.end_date.TabIndex = 10;
            this.end_date.Text = "00000000";
            this.end_date.ValidatingType = typeof(System.DateTime);
            this.end_date.Value = null;
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
            // end_date_t
            // 
            this.end_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.end_date_t.Font = new System.Drawing.Font("Arial", 8F);
            this.end_date_t.ForeColor = System.Drawing.Color.Black;
            this.end_date_t.Location = new System.Drawing.Point(172, 9);
            this.end_date_t.Name = "end_date_t";
            this.end_date_t.Size = new System.Drawing.Size(26, 14);
            this.end_date_t.TabIndex = 34;
            this.end_date_t.Text = "to:";
            this.end_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no_t
            // 
            this.contract_no_t.AutoSize = true;
            this.contract_no_t.Location = new System.Drawing.Point(10, 64);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(64, 13);
            this.contract_no_t.TabIndex = 35;
            this.contract_no_t.Text = "Contract No";
            // 
            // rg_code_t
            // 
            this.rg_code_t.AutoSize = true;
            this.rg_code_t.Location = new System.Drawing.Point(10, 90);
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Size = new System.Drawing.Size(81, 13);
            this.rg_code_t.TabIndex = 36;
            this.rg_code_t.Text = "Renewal Group";
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.BackColor = System.Drawing.Color.White;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.DropDownHeight = 150;
            this.rg_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.IntegralHeight = false;
            this.rg_code.Location = new System.Drawing.Point(96, 87);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(187, 21);
            this.rg_code.TabIndex = 40;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true));
            this.contract_no.Location = new System.Drawing.Point(96, 62);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(67, 20);
            this.contract_no.TabIndex = 41;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DwPaymentRunPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.start_date_t);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.owner_driver);
            this.Controls.Add(this.owner_driver_t);
            this.Controls.Add(this.end_date_t);
            this.Name = "DwPaymentRunPeriod";
            this.Size = new System.Drawing.Size(286, 144);
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
