using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwOdpsContractAdjustments
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

        private System.Windows.Forms.Label effective_date_t;
        private Metex.Windows.DataEntityCombo pct_id;
        private System.Windows.Forms.MaskedTextBox effective_date;
        private System.Windows.Forms.CheckBox ca_confirmed;
        private System.Windows.Forms.Label ca_amount_t;
        private System.Windows.Forms.MaskedTextBox ca_date_paid;
        private System.Windows.Forms.Label priority_t;
        private System.Windows.Forms.Label ca_confirmed_t;
        private System.Windows.Forms.CheckBox ever_paid;
        private System.Windows.Forms.Label pct_id_t;
        private System.Windows.Forms.TextBox ca_reason;
        private System.Windows.Forms.MaskedTextBox ca_date_occured;
        private System.Windows.Forms.Label ca_date_paid_t;
        private System.Windows.Forms.Label ca_date_occured_t;
        private System.Windows.Forms.MaskedTextBox ca_amount;
        private System.Windows.Forms.Label ever_paid_t;
        private System.Windows.Forms.Label ca_reason_t;
        private System.Windows.Forms.TextBox priority;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwOdpsContractAdjustments";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.OdpsContractAdjustments);
         
            //
            // ca_date_occured_t
            //
            this.ca_date_occured_t = new System.Windows.Forms.Label();
            this.ca_date_occured_t.Font = new System.Drawing.Font("Arial", 10F);
            this.ca_date_occured_t.ForeColor = System.Drawing.Color.Black;
            this.ca_date_occured_t.Location = new System.Drawing.Point(60, 5);
            this.ca_date_occured_t.Name = "ca_date_occured_t";
            this.ca_date_occured_t.Size = new System.Drawing.Size(100, 16);
            this.ca_date_occured_t.Text = "Date Occured:";
            this.ca_date_occured_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(ca_date_occured_t);

            //
            // ca_reason_t
            //
            this.ca_reason_t = new System.Windows.Forms.Label();
            this.ca_reason_t.Font = new System.Drawing.Font("Arial", 10F);
            this.ca_reason_t.ForeColor = System.Drawing.Color.Black;
            this.ca_reason_t.Location = new System.Drawing.Point(90, 29);
            this.ca_reason_t.Name = "ca_reason_t";
            this.ca_reason_t.Size = new System.Drawing.Size(70, 16);
            this.ca_reason_t.Text = "Reason:";
            this.ca_reason_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(ca_reason_t);

            //
            // ca_date_paid_t
            //
            this.ca_date_paid_t = new System.Windows.Forms.Label();
            this.ca_date_paid_t.Font = new System.Drawing.Font("Arial", 10F);
            this.ca_date_paid_t.ForeColor = System.Drawing.Color.Black;
            this.ca_date_paid_t.Location = new System.Drawing.Point(80, 53);
            this.ca_date_paid_t.Name = "ca_date_paid_t";
            this.ca_date_paid_t.Size = new System.Drawing.Size(80, 16);
            this.ca_date_paid_t.Text = "Date Paid:";
            this.ca_date_paid_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(ca_date_paid_t);

            //
            // ca_amount_t
            //
            this.ca_amount_t = new System.Windows.Forms.Label();
            this.ca_amount_t.Font = new System.Drawing.Font("Arial", 10F);
            this.ca_amount_t.ForeColor = System.Drawing.Color.Black;
            this.ca_amount_t.Location = new System.Drawing.Point(100, 77);
            this.ca_amount_t.Name = "ca_amount_t";
            this.ca_amount_t.Size = new System.Drawing.Size(60, 16);
            this.ca_amount_t.Text = "Amount:";
            this.ca_amount_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(ca_amount_t);

            //
            // ca_confirmed_t
            //
            this.ca_confirmed_t = new System.Windows.Forms.Label();
            this.ca_confirmed_t.Font = new System.Drawing.Font("Arial", 10F);
            this.ca_confirmed_t.ForeColor = System.Drawing.Color.Black;
            this.ca_confirmed_t.Location = new System.Drawing.Point(75, 101);
            this.ca_confirmed_t.Name = "ca_confirmed_t";
            this.ca_confirmed_t.Size = new System.Drawing.Size(80, 16);
            this.ca_confirmed_t.Text = "Confirmed:";
            this.ca_confirmed_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(ca_confirmed_t);

            //
            // effective_date_t
            //
            this.effective_date_t = new System.Windows.Forms.Label();
            this.effective_date_t.Font = new System.Drawing.Font("Arial", 10F);
            this.effective_date_t.ForeColor = System.Drawing.Color.Black;
            this.effective_date_t.Location = new System.Drawing.Point(24, 125);
            this.effective_date_t.Name = "effective_date_t";
            this.effective_date_t.Size = new System.Drawing.Size(135, 16);
            this.effective_date_t.Text = "Effective Date:";
            this.effective_date_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(effective_date_t);

            //
            // pct_id_t
            //
            this.pct_id_t = new System.Windows.Forms.Label();
            this.pct_id_t.Font = new System.Drawing.Font("Arial", 10F);
            this.pct_id_t.ForeColor = System.Drawing.Color.Black;
            this.pct_id_t.Location = new System.Drawing.Point(-20, 149);
            this.pct_id_t.Name = "pct_id_t";
            this.pct_id_t.Size = new System.Drawing.Size(180, 16);
            this.pct_id_t.Text = "Payment Component Type:";
            this.pct_id_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(pct_id_t);

            //
            // priority_t
            //
            this.priority_t = new System.Windows.Forms.Label();
            this.priority_t.Font = new System.Drawing.Font("Arial", 10F);
            this.priority_t.ForeColor = System.Drawing.Color.Black;
            this.priority_t.Location = new System.Drawing.Point(24, 173);
            this.priority_t.Name = "priority_t";
            this.priority_t.Size = new System.Drawing.Size(135, 16);
            this.priority_t.Text = "Priority:";
            this.priority_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(priority_t);

            //
            // ever_paid_t
            //
            this.ever_paid_t = new System.Windows.Forms.Label();
            this.ever_paid_t.Font = new System.Drawing.Font("Arial", 10F);
            this.ever_paid_t.ForeColor = System.Drawing.Color.Black;
            this.ever_paid_t.Location = new System.Drawing.Point(24, 197);
            this.ever_paid_t.Name = "ever_paid_t";
            this.ever_paid_t.Size = new System.Drawing.Size(135, 16);
            this.ever_paid_t.Text = "Ever Paid:";
            this.ever_paid_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(ever_paid_t);

            //
            // ca_date_occured
            //
            ca_date_occured = new System.Windows.Forms.MaskedTextBox();
            this.ca_date_occured.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ca_date_occured.Location = new System.Drawing.Point(165, 5);
            this.ca_date_occured.Name = "ca_date_occured";
            this.ca_date_occured.Size = new System.Drawing.Size(72, 19);
            this.ca_date_occured.Mask = "";
            this.ca_date_occured.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CaDateOccured", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ca_date_occured.ReadOnly = true;
            this.Controls.Add(ca_date_occured);
         
            //
            // ca_reason
            //
            ca_reason = new System.Windows.Forms.TextBox();
            this.ca_reason.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ca_reason.Font = new System.Drawing.Font("Arial", 10F);
            this.ca_reason.ForeColor = System.Drawing.Color.Black;
            this.ca_reason.Location = new System.Drawing.Point(165, 29);
            this.ca_reason.MaxLength = 40;
            this.ca_reason.Name = "ca_reason";
            this.ca_reason.Size = new System.Drawing.Size(246, 19);
            this.ca_reason.TextAlign = HorizontalAlignment.Left;
            this.ca_reason.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CaReason", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ca_reason.ReadOnly = true;
            this.Controls.Add(ca_reason);

            //
            // ca_date_paid
            //
            ca_date_paid = new System.Windows.Forms.MaskedTextBox();
            this.ca_date_paid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ca_date_paid.Location = new System.Drawing.Point(165, 53);
            this.ca_date_paid.Name = "ca_date_paid";
            this.ca_date_paid.Size = new System.Drawing.Size(72, 19);
            this.ca_date_paid.Mask = "";
            this.ca_date_paid.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CaDatePaid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ca_date_paid.ReadOnly = true;
            this.Controls.Add(ca_date_paid);

            //
            // ca_amount
            //
            ca_amount = new System.Windows.Forms.MaskedTextBox();
            this.ca_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ca_amount.Location = new System.Drawing.Point(165, 77);
            this.ca_amount.Name = "ca_amount";
            this.ca_amount.Size = new System.Drawing.Size(72, 19);
            this.ca_amount.Mask = "";
            this.ca_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CaAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ca_amount.ReadOnly = true;
            this.Controls.Add(ca_amount);

            //
            // effective_date
            //
            effective_date = new System.Windows.Forms.MaskedTextBox();
            this.effective_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.effective_date.Location = new System.Drawing.Point(165, 125);
            this.effective_date.Name = "effective_date";
            this.effective_date.Size = new System.Drawing.Size(72, 19);
            this.effective_date.Mask = "";
            this.effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "EffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.effective_date.TabIndex = 40;
            this.Controls.Add(effective_date);
         
            //
            // pct_id
            //
            pct_id = new Metex.Windows.DataEntityCombo();
            this.pct_id.AutoRetrieve = true;
            this.pct_id.DisplayMember = "PctDescription";
            this.pct_id.Font = new System.Drawing.Font("Arial", 10F);
            this.pct_id.ForeColor = System.Drawing.Color.Black;
            this.pct_id.Location = new System.Drawing.Point(165, 149);
            this.pct_id.Name = "pct_id";
            this.pct_id.Size = new System.Drawing.Size(245, 19);
            this.pct_id.TabIndex = 30;
            this.pct_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pct_id.Value = null;
            this.pct_id.ValueMember = "PctId";
            this.pct_id.DropDownWidth = 245;
            this.pct_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PctId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(pct_id);

            //
            // priority
            //
            priority = new System.Windows.Forms.TextBox();
            this.priority.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.priority.Font = new System.Drawing.Font("Arial", 10F);
            this.priority.ForeColor = System.Drawing.Color.Black;
            this.priority.Location = new System.Drawing.Point(165, 173);
            this.priority.MaxLength = 0;
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(60, 19);
            this.priority.TextAlign = HorizontalAlignment.Left;
            this.priority.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "Priority", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.priority.TabIndex = 10;
            this.Controls.Add(priority);

            //
            // ever_paid
            //
            ever_paid = new System.Windows.Forms.CheckBox();
            this.ever_paid.DataBindings.Add(new System.Windows.Forms.Binding("Checked",this.bindingSource, "EverPaid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ever_paid.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ever_paid.Font = new System.Drawing.Font("Arial", 10F);
            this.ever_paid.ForeColor = System.Drawing.Color.Black;
            this.ever_paid.Location = new System.Drawing.Point(165, 197);
            this.ever_paid.Name = "ever_paid";
            this.ever_paid.Text = "";
            this.ever_paid.Size = new System.Drawing.Size(12, 19);
            this.ever_paid.TabIndex = 20;
            this.Controls.Add(ever_paid);

            //
            // ca_confirmed
            //
            ca_confirmed = new System.Windows.Forms.CheckBox();
            this.ca_confirmed.DataBindings.Add(new System.Windows.Forms.Binding("Checked",this.bindingSource, "CaConfirmed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ca_confirmed.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ca_confirmed.Font = new System.Drawing.Font("Arial", 10F);
            this.ca_confirmed.ForeColor = System.Drawing.Color.Black;
            this.ca_confirmed.Location = new System.Drawing.Point(165, 101);
            this.ca_confirmed.Name = "ca_confirmed";
            this.ca_confirmed.Text = "";
            this.ca_confirmed.Size = new System.Drawing.Size(12, 19);
            this.ca_confirmed.TabIndex = 32766;
            this.Controls.Add(ca_confirmed);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
