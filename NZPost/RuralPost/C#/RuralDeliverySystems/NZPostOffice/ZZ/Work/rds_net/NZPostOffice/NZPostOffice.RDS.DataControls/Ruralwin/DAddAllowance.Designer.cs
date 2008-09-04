using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DAddAllowance
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

        private System.Windows.Forms.TextBox contract_title;
        private System.Windows.Forms.Label allowance_t;
        private System.Windows.Forms.Label effective_date_t;
        private System.Windows.Forms.Label paid_to_date_t;
        private System.Windows.Forms.Label annual_amount_t;
        private System.Windows.Forms.TextBox notes;
        private System.Windows.Forms.Label notes_t;
        private Metex.Windows.DataEntityCombo alt_key;
        private DateTimeMaskedTextBox effective_date;// System.Windows.Forms.MaskedTextBox effective_date;
        private DateTimeMaskedTextBox paid_to_date;// System.Windows.Forms.MaskedTextBox paid_to_date;
        private NumericalMaskedTextBox annual_amount;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DAddAllowance";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.AddAllowance);
            #region contract_title define
            this.contract_title = new System.Windows.Forms.TextBox();
            this.contract_title.Name = "contract_title";
            this.contract_title.Location = new System.Drawing.Point(3, 3);
            this.contract_title.Size = new System.Drawing.Size(300, 20);
            this.contract_title.TabIndex = 0;
            this.contract_title.BackColor = System.Drawing.SystemColors.Control;
            //this.contract_title.BorderStyle = BorderStyle.None;
            this.contract_title.Enabled = true;
            this.contract_title.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            this.contract_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.contract_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(contract_title);
            #region allowance_t define
            this.allowance_t = new System.Windows.Forms.Label();
            this.allowance_t.Name = "allowance_t";
            this.allowance_t.Location = new System.Drawing.Point(10, 39);
            this.allowance_t.Size = new System.Drawing.Size(106, 14);
            this.allowance_t.TabIndex = 0;
            this.allowance_t.Font = new System.Drawing.Font("Arial", 8);
            this.allowance_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.allowance_t.Text = "Allowance";
            #endregion
            this.Controls.Add(allowance_t);
            #region effective_date_t define
            this.effective_date_t = new System.Windows.Forms.Label();
            this.effective_date_t.Name = "effective_date_t";
            this.effective_date_t.Location = new System.Drawing.Point(197, 40);
            this.effective_date_t.Size = new System.Drawing.Size(68, 13);
            this.effective_date_t.TabIndex = 0;
            this.effective_date_t.Font = new System.Drawing.Font("Arial", 8);
            this.effective_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.effective_date_t.Text = "Effective";
            #endregion
            this.Controls.Add(effective_date_t);
            #region paid_to_date_t define
            this.paid_to_date_t = new System.Windows.Forms.Label();
            this.paid_to_date_t.Name = "paid_to_date_t";
            this.paid_to_date_t.Location = new System.Drawing.Point(281, 25);
            this.paid_to_date_t.Size = new System.Drawing.Size(68, 32);
            this.paid_to_date_t.TabIndex = 0;
            this.paid_to_date_t.Font = new System.Drawing.Font("Arial", 8);
            this.paid_to_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.paid_to_date_t.Text = "First Paid Date";
            #endregion
            this.Controls.Add(paid_to_date_t);
            #region annual_amount_t define
            this.annual_amount_t = new System.Windows.Forms.Label();
            this.annual_amount_t.Name = "annual_amount_t";
            this.annual_amount_t.Location = new System.Drawing.Point(363, 40);
            this.annual_amount_t.Size = new System.Drawing.Size(85, 14);
            this.annual_amount_t.TabIndex = 0;
            this.annual_amount_t.Font = new System.Drawing.Font("Arial", 8);
            this.annual_amount_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.annual_amount_t.Text = "Annual Amount";
            #endregion
            this.Controls.Add(annual_amount_t);
            #region notes define
            this.notes = new System.Windows.Forms.TextBox();
            this.notes.Name = "notes";
            this.notes.Location = new System.Drawing.Point(84, 83);
            this.notes.Size = new System.Drawing.Size(360, 65);
            this.notes.TabIndex = 50;
            this.notes.Enabled = true;
            this.notes.Font = new System.Drawing.Font("Arial", 8);
            this.notes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.notes.Multiline = true;
            this.notes.MaxLength = 200;
            this.notes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Notes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(notes);
            #region notes_t define
            this.notes_t = new System.Windows.Forms.Label();
            this.notes_t.Name = "notes_t";
            this.notes_t.Location = new System.Drawing.Point(40, 84);
            this.notes_t.Size = new System.Drawing.Size(38, 14);
            this.notes_t.TabIndex = 0;
            this.notes_t.Font = new System.Drawing.Font("Arial", 8);
            this.notes_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.notes_t.Text = "Notes";
            #endregion
            this.Controls.Add(notes_t);
            #region alt_key define
            this.alt_key = new Metex.Windows.DataEntityCombo();
            this.alt_key.Name = "alt_key";
            this.alt_key.Location = new System.Drawing.Point(10, 58);
            this.alt_key.Size = new System.Drawing.Size(176, 22);
            this.alt_key.TabIndex = 10;
            this.alt_key.Enabled = true;
            this.alt_key.Font = new System.Drawing.Font("Arial", 8);
            //this.alt_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.alt_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AltKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.alt_key.DisplayMember = "AltDescription";
            this.alt_key.ValueMember = "AltKey";
            this.alt_key.AutoRetrieve = true;
            this.alt_key.BackColor = System.Drawing.Color.Aqua;
            #endregion
            this.Controls.Add(alt_key);
            #region effective_date define
            this.effective_date = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.effective_date.Name = "effective_date";
            this.effective_date.Location = new System.Drawing.Point(197, 59);
            this.effective_date.Size = new System.Drawing.Size(68, 20);
            this.effective_date.TabIndex = 30;
            this.effective_date.Enabled = true;
            this.effective_date.Font = new System.Drawing.Font("Arial", 8);
            this.effective_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "EffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.effective_date.Mask = "00/00/0000";
            //this.effective_date.PromptChar = '0';
            this.effective_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.effective_date.BackColor = System.Drawing.Color.Aqua;
            this.effective_date.DataBindings[0].DataSourceNullValue = null;
            //this.effective_date.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.effective_date.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            #endregion
            this.Controls.Add(effective_date);
            #region paid_to_date define
            this.paid_to_date = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.paid_to_date.Name = "paid_to_date";
            this.paid_to_date.Location = new System.Drawing.Point(281, 59);
            this.paid_to_date.Size = new System.Drawing.Size(68, 20);
            this.paid_to_date.TabIndex = 60;
            this.paid_to_date.Mask = "00/00/0000";
            //this.paid_to_date.PromptChar = '0';
            this.paid_to_date.BackColor = System.Drawing.SystemColors.Control;
            //this.paid_to_date.BorderStyle = BorderStyle.None;
            //this.paid_to_date.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.paid_to_date.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            this.paid_to_date.Font = new System.Drawing.Font("Arial", 8);
            this.paid_to_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paid_to_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PaidToDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.paid_to_date.DataBindings[0].FormatString = "dd/MM/yyyy" ;
            #endregion
            this.Controls.Add(paid_to_date);
            #region annual_amount define
            this.annual_amount = new NumericalMaskedTextBox();
            this.annual_amount.Name = "annual_amount";
            this.annual_amount.Location = new System.Drawing.Point(364, 59);
            this.annual_amount.Size = new System.Drawing.Size(80, 20);
            this.annual_amount.TabIndex = 40;
            this.annual_amount.EditMask = "###,###.00";
            this.annual_amount.PromptChar = ' ';
            this.annual_amount.InsertKeyMode = InsertKeyMode.Overwrite;
            this.annual_amount.Enabled = true;
            this.annual_amount.Font = new System.Drawing.Font("Arial", 8);
            this.annual_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.annual_amount.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AnnualAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.annual_amount.DataBindings[0].FormatString = "###,###.00" ;// this.annual_amount.DataBindings["Text"].FormatString = "###,###.00" ;// this.annual_amount.Mask = "###,###.00";
            this.annual_amount.DataBindings[0].DataSourceNullValue = null;
            this.annual_amount.BackColor = System.Drawing.Color.Aqua;
            #endregion
            this.Controls.Add(annual_amount);
            this.Size = new System.Drawing.Size(547, 212);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion


    }
}
