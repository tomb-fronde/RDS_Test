using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwOdpsFrequencyAdjustments
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

        private Metex.Windows.DataEntityCombo pct_id;
        private DateTimeMaskedTextBox expiry_date;
        private System.Windows.Forms.Label priority_t;
        private System.Windows.Forms.CheckBox ever_paid;
        private System.Windows.Forms.Label annualised_amount_t;
        private System.Windows.Forms.Label pct_id_t;
        private System.Windows.Forms.Label expiry_date_t;
        private System.Windows.Forms.Label ever_paid_t;
        private System.Windows.Forms.TextBox annualised_amount;
        private System.Windows.Forms.TextBox priority;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwOdpsFrequencyAdjustments";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.OdpsFrequencyAdjustments);
            //
            // priority_t
            //
            this.priority_t = new System.Windows.Forms.Label();
            this.priority_t.Font = new System.Drawing.Font("Arial", 10F);
            this.priority_t.ForeColor = System.Drawing.Color.Black;
            this.priority_t.Location = new System.Drawing.Point(35, 114);
            this.priority_t.Name = "priority_t";
            this.priority_t.Size = new System.Drawing.Size(139, 16);
            this.priority_t.Text = "Priority:";
            this.priority_t.TextAlign = ContentAlignment.MiddleRight;
            this.priority_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(priority_t);

            //
            // ever_paid_t
            //
            this.ever_paid_t = new System.Windows.Forms.Label();
            this.ever_paid_t.Font = new System.Drawing.Font("Arial", 10F);
            this.ever_paid_t.ForeColor = System.Drawing.Color.Black;
            this.ever_paid_t.Location = new System.Drawing.Point(35, 148);
            this.ever_paid_t.Name = "ever_paid_t";
            this.ever_paid_t.Size = new System.Drawing.Size(139, 16);
            this.ever_paid_t.Text = "Ever Paid:";
            this.ever_paid_t.TextAlign = ContentAlignment.MiddleRight;
            this.ever_paid_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(ever_paid_t);

            //
            // pct_id_t
            //
            this.pct_id_t = new System.Windows.Forms.Label();
            this.pct_id_t.Font = new System.Drawing.Font("Arial", 10F);
            this.pct_id_t.ForeColor = System.Drawing.Color.Black;
            this.pct_id_t.Location = new System.Drawing.Point(19, 10);
            this.pct_id_t.Name = "pct_id_t";
            this.pct_id_t.Size = new System.Drawing.Size(154, 16);
            this.pct_id_t.Text = "Payment Component Type";
            this.pct_id_t.TextAlign = ContentAlignment.MiddleRight;
            this.pct_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(pct_id_t);

            //
            // annualised_amount_t
            //
            this.annualised_amount_t = new System.Windows.Forms.Label();
            this.annualised_amount_t.Font = new System.Drawing.Font("Arial", 10F);
            this.annualised_amount_t.ForeColor = System.Drawing.Color.Black;
            this.annualised_amount_t.Location = new System.Drawing.Point(35, 45);
            this.annualised_amount_t.Name = "annualised_amount_t";
            this.annualised_amount_t.Size = new System.Drawing.Size(139, 16);
            this.annualised_amount_t.Text = "Annualised Amount:";
            this.annualised_amount_t.TextAlign = ContentAlignment.MiddleRight;
            this.annualised_amount_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(annualised_amount_t);

            //
            // expiry_date_t
            //
            this.expiry_date_t = new System.Windows.Forms.Label();
            this.expiry_date_t.Font = new System.Drawing.Font("Arial", 10F);
            this.expiry_date_t.ForeColor = System.Drawing.Color.Black;
            this.expiry_date_t.Location = new System.Drawing.Point(35, 79);
            this.expiry_date_t.Name = "expiry_date_t";
            this.expiry_date_t.Size = new System.Drawing.Size(139, 16);
            this.expiry_date_t.Text = "Expiry Date:";
            this.expiry_date_t.TextAlign = ContentAlignment.MiddleRight;
            this.expiry_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(expiry_date_t);


            //
            // ever_paid
            //
            ever_paid = new System.Windows.Forms.CheckBox();
            this.ever_paid.DataBindings.Add(new System.Windows.Forms.Binding("Checked",this.bindingSource, "EverPaid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ever_paid.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ever_paid.Font = new System.Drawing.Font("Arial", 10F);
            this.ever_paid.ForeColor = System.Drawing.Color.Black;
            this.ever_paid.Location = new System.Drawing.Point(184, 148);
            this.ever_paid.Name = "ever_paid";
            this.ever_paid.Text = "";
            this.ever_paid.Size = new System.Drawing.Size(15, 19);
            this.ever_paid.TabIndex = 32766;
            this.Controls.Add(ever_paid);

            //
            // pct_id
            //
            pct_id = new Metex.Windows.DataEntityCombo();
            this.pct_id.AutoRetrieve = true;
            this.pct_id.DisplayMember = "PctId";
            this.pct_id.Font = new System.Drawing.Font("Arial", 10F);
            this.pct_id.ForeColor = System.Drawing.Color.Black;
            this.pct_id.Location = new System.Drawing.Point(184, 8);
            this.pct_id.Name = "pct_id";
            this.pct_id.Size = new System.Drawing.Size(234, 19);
            this.pct_id.TabIndex = 32766;
            this.pct_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pct_id.Value = null;
            this.pct_id.ValueMember = "PctDescription";
            this.pct_id.DropDownWidth = 234;
            this.pct_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PctId", true,System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(pct_id);

            //
            // annualised_amount
            //
            annualised_amount = new System.Windows.Forms.TextBox();
            this.annualised_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.annualised_amount.Font = new System.Drawing.Font("Arial", 10F);
            this.annualised_amount.ForeColor = System.Drawing.Color.Black;
            this.annualised_amount.Location = new System.Drawing.Point(184, 43);
            this.annualised_amount.MaxLength = 0;
            this.annualised_amount.Name = "annualised_amount";
            this.annualised_amount.Size = new System.Drawing.Size(72, 19);
            this.annualised_amount.TextAlign = HorizontalAlignment.Right;
            this.annualised_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "AnnualisedAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.annualised_amount.ReadOnly = true;
            this.Controls.Add(annualised_amount);

            //
            // expiry_date
            //
            expiry_date = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.expiry_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.expiry_date.Location = new System.Drawing.Point(184, 77);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(72, 19);
            this.expiry_date.Mask = "00/00/0000";
            this.expiry_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExpiryDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.expiry_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.expiry_date.DataBindings[0].DataSourceNullValue = null;
            this.expiry_date.ReadOnly = true;
            this.Controls.Add(expiry_date);
            //
            // priority
            //
            priority = new System.Windows.Forms.TextBox();
            this.priority.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.priority.Font = new System.Drawing.Font("Arial", 10F);
            this.priority.ForeColor = System.Drawing.Color.Black;
            this.priority.Location = new System.Drawing.Point(184, 112);
            this.priority.MaxLength = 0;
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(72, 19);
            this.priority.TextAlign = HorizontalAlignment.Right;
            this.priority.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "Priority", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.priority.ReadOnly = true;
            this.Controls.Add(priority);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
