namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractAllowances
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DContractAllowances";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractAllowances);
            #region st_contract define
            this.st_contract = new System.Windows.Forms.Label();
            this.st_contract.Name = "st_contract";
            this.st_contract.Location = new System.Drawing.Point(12, 4);
            this.st_contract.Size = new System.Drawing.Size(528, 13);
            this.st_contract.TabIndex = 0;
            this.st_contract.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_contract.Text = "text";
            #endregion
            this.Controls.Add(st_contract);
            #region st_access define
            this.st_access = new System.Windows.Forms.Label();
            this.st_access.Name = "st_access";
            this.st_access.Location = new System.Drawing.Point(544, 9);
            this.st_access.Size = new System.Drawing.Size(9, 14);
            this.st_access.TabIndex = 0;
            this.st_access.Font = new System.Drawing.Font("Arial", 8);
            this.st_access.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_access.Text = "Y";
            this.st_access.Visible = false;
            #endregion
            this.Controls.Add(st_access);
            #region alt_key_t define
            this.alt_key_t = new System.Windows.Forms.Label();
            this.alt_key_t.Name = "alt_key_t";
            this.alt_key_t.Location = new System.Drawing.Point(19, 32);
            this.alt_key_t.Size = new System.Drawing.Size(56, 13);
            this.alt_key_t.TabIndex = 0;
            this.alt_key_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.alt_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alt_key_t.Text = "Allowance";
            #endregion
            this.Controls.Add(alt_key_t);
            #region ca_effective_date_t define
            this.ca_effective_date_t = new System.Windows.Forms.Label();
            this.ca_effective_date_t.Name = "ca_effective_date_t";
            this.ca_effective_date_t.Location = new System.Drawing.Point(249, 31);
            this.ca_effective_date_t.Size = new System.Drawing.Size(50, 13);
            this.ca_effective_date_t.TabIndex = 0;
            this.ca_effective_date_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_effective_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ca_effective_date_t.Text = "Effective";
            #endregion
            this.Controls.Add(ca_effective_date_t);
            #region ca_paid_to_date_t define
            this.ca_paid_to_date_t = new System.Windows.Forms.Label();
            this.ca_paid_to_date_t.Name = "ca_paid_to_date_t";
            this.ca_paid_to_date_t.Location = new System.Drawing.Point(321, 18);
            this.ca_paid_to_date_t.Size = new System.Drawing.Size(58, 26);
            this.ca_paid_to_date_t.TabIndex = 0;
            this.ca_paid_to_date_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_paid_to_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ca_paid_to_date_t.Text = "First Paid\r\n Date";
            #endregion
            this.Controls.Add(ca_paid_to_date_t);
            #region ca_annual_amount_t define
            this.ca_annual_amount_t = new System.Windows.Forms.Label();
            this.ca_annual_amount_t.Name = "ca_annual_amount_t";
            this.ca_annual_amount_t.Location = new System.Drawing.Point(411, 32);
            this.ca_annual_amount_t.Size = new System.Drawing.Size(61, 13);
            this.ca_annual_amount_t.TabIndex = 0;
            this.ca_annual_amount_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_annual_amount_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ca_annual_amount_t.Text = "Annual Amt";
            #endregion
            this.Controls.Add(ca_annual_amount_t);
            #region alt_key define
            this.alt_key = new Metex.Windows.DataEntityCombo();
            this.alt_key.Name = "alt_key";
            this.alt_key.Location = new System.Drawing.Point(19, 48);
            this.alt_key.Size = new System.Drawing.Size(204, 21);
            this.alt_key.TabIndex = 10;
            this.alt_key.Enabled = false;
            this.alt_key.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.alt_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.alt_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AltKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.alt_key.DisplayMember = "AltDescription";
            this.alt_key.ValueMember = "AltKey";
            this.alt_key.AutoRetrieve = true;
            #endregion
            this.Controls.Add(alt_key);
            #region ca_effective_date define
            this.ca_effective_date = new System.Windows.Forms.MaskedTextBox();
            this.ca_effective_date.Name = "ca_effective_date";
            this.ca_effective_date.Location = new System.Drawing.Point(240, 48);
            this.ca_effective_date.Size = new System.Drawing.Size(68, 20);
            this.ca_effective_date.TabIndex = 20;
            this.ca_effective_date.Enabled = false;
            this.ca_effective_date.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_effective_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ca_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CaEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ca_effective_date.Mask = "00/00/0000";
            this.ca_effective_date.ValidatingType = typeof(System.DateTime);
            this.ca_effective_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            #endregion
            this.Controls.Add(ca_effective_date);
            #region ca_paid_to_date define
            this.ca_paid_to_date = new System.Windows.Forms.MaskedTextBox();
            this.ca_paid_to_date.Name = "ca_paid_to_date";
            this.ca_paid_to_date.Location = new System.Drawing.Point(321, 48);
            this.ca_paid_to_date.Size = new System.Drawing.Size(74, 20);
            this.ca_paid_to_date.TabIndex = 0;
            this.ca_paid_to_date.Enabled = false;
            this.ca_paid_to_date.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_paid_to_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ca_paid_to_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CaPaidToDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ca_paid_to_date.Mask = "00/00/0000";
            this.ca_paid_to_date.ValidatingType = typeof(System.DateTime);
            this.ca_paid_to_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            #endregion
            this.Controls.Add(ca_paid_to_date);
            #region ca_annual_amount define
            this.ca_annual_amount = new System.Windows.Forms.MaskedTextBox();
            this.ca_annual_amount.Name = "ca_annual_amount";
            this.ca_annual_amount.Location = new System.Drawing.Point(404, 48);
            this.ca_annual_amount.Size = new System.Drawing.Size(68, 20);
            this.ca_annual_amount.TabIndex = 30;
            this.ca_annual_amount.Enabled = false;
            this.ca_annual_amount.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_annual_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ca_annual_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CaAnnualAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));            
            #endregion
            this.Controls.Add(ca_annual_amount);
            #region ca_notes_t define
            this.ca_notes_t = new System.Windows.Forms.Label();
            this.ca_notes_t.Name = "ca_notes_t";
            this.ca_notes_t.Location = new System.Drawing.Point(16, 74);
            this.ca_notes_t.Size = new System.Drawing.Size(116, 13);
            this.ca_notes_t.TabIndex = 0;
            this.ca_notes_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_notes_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ca_notes_t.Text = "Notes";
            #endregion
            this.Controls.Add(ca_notes_t);
            #region t_1 define
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Name = "t_1";
            this.t_1.Location = new System.Drawing.Point(4, 138);
            this.t_1.Size = new System.Drawing.Size(129, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_1.Text = "Pay Component Type";
            #endregion
            this.Controls.Add(t_1);
            #region ca_notes define
            this.ca_notes = new System.Windows.Forms.TextBox();
            this.ca_notes.Name = "ca_notes";
            this.ca_notes.Location = new System.Drawing.Point(140, 73);
            this.ca_notes.Size = new System.Drawing.Size(333, 58);
            this.ca_notes.TabIndex = 40;
            this.ca_notes.Enabled = false;
            this.ca_notes.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ca_notes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ca_notes.MaxLength = 200;
            this.ca_notes.Multiline = true;
            this.ca_notes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CaNotes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ca_notes);
            #region pct_id define
            this.pct_id = new Metex.Windows.DataEntityCombo();
            this.pct_id.Name = "pct_id";
            this.pct_id.Location = new System.Drawing.Point(141, 137);
            this.pct_id.Size = new System.Drawing.Size(260, 21);
            this.pct_id.TabIndex = 50;
            this.pct_id.Enabled = false;
            this.pct_id.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.pct_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pct_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PctId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pct_id.DisplayMember = "PctDescription";
            this.pct_id.ValueMember = "PctId";
            this.pct_id.AutoRetrieve = true;
            #endregion
            this.Controls.Add(pct_id);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label st_contract;
        private System.Windows.Forms.Label st_access;
        private System.Windows.Forms.Label alt_key_t;
        private System.Windows.Forms.Label ca_effective_date_t;
        private System.Windows.Forms.Label ca_paid_to_date_t;
        private System.Windows.Forms.Label ca_annual_amount_t;
        private Metex.Windows.DataEntityCombo alt_key;
        private System.Windows.Forms.MaskedTextBox ca_effective_date;
        private System.Windows.Forms.MaskedTextBox ca_paid_to_date;
        private System.Windows.Forms.MaskedTextBox ca_annual_amount;
        private System.Windows.Forms.Label ca_notes_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.TextBox ca_notes;
        private Metex.Windows.DataEntityCombo pct_id;
    }
}
