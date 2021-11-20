namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwUpdatedContractors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname_company;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank_account_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn initials;
        private System.Windows.Forms.DataGridViewTextBoxColumn address1;
        private System.Windows.Forms.DataGridViewTextBoxColumn changetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.UpdatedContractors);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // ds_no
            //
            ds_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds_no.DataPropertyName = "DsNo";
            this.ds_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ds_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ds_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ds_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ds_no.HeaderText = "Ds No";
            this.ds_no.Name = "ds_no";
            this.ds_no.ReadOnly = true;
            this.ds_no.Width = 54;
            this.grid.Columns.Add(ds_no);


            //
            // title
            //
            title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title.DataPropertyName = "Title";
            this.title.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.title.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.title.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.title.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Width = 54;
            this.grid.Columns.Add(title);


            //
            // initials
            //
            initials = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initials.DataPropertyName = "Initials";
            this.initials.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.initials.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.initials.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.initials.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.initials.HeaderText = "Initials";
            this.initials.Name = "initials";
            this.initials.ReadOnly = true;
            this.initials.Width = 54;
            this.grid.Columns.Add(initials);


            //
            // surname_company
            //
            surname_company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname_company.DataPropertyName = "SurnameCompany";
            this.surname_company.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.surname_company.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.surname_company.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.surname_company.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.surname_company.HeaderText = "Surname Company";
            this.surname_company.Name = "surname_company";
            this.surname_company.ReadOnly = true;
            this.surname_company.Width = 205;
            this.grid.Columns.Add(surname_company);


            //
            // address1
            //
            address1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address1.DataPropertyName = "Address1";
            this.address1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.address1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.address1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.address1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.address1.HeaderText = "Address1";
            this.address1.Name = "address1";
            this.address1.ReadOnly = true;
            this.address1.Width = 610;
            this.address1.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.Columns.Add(address1);


            //
            // bank_account_no
            //
            bank_account_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank_account_no.DataPropertyName = "BankAccountNo";
            this.bank_account_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.bank_account_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.bank_account_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bank_account_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.bank_account_no.HeaderText = "Bank Account No";
            this.bank_account_no.Name = "bank_account_no";
            this.bank_account_no.ReadOnly = true;
            this.bank_account_no.Width = 205;
            this.grid.Columns.Add(bank_account_no);


            //
            // bank
            //
            bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank.DataPropertyName = "Bank";
            this.bank.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.bank.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.bank.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bank.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.bank.HeaderText = "Bank";
            this.bank.Name = "bank";
            this.bank.ReadOnly = true;
            this.bank.Width = 205;
            this.grid.Columns.Add(bank);


            //
            // branch
            //
            branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch.DataPropertyName = "Branch";
            this.branch.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.branch.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.branch.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.branch.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.branch.HeaderText = "Branch";
            this.branch.Name = "branch";
            this.branch.ReadOnly = true;
            this.branch.Width = 205;
            this.grid.Columns.Add(branch);


            //
            // changetype
            //
            changetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changetype.DataPropertyName = "Changetype";
            this.changetype.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.changetype.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.changetype.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.changetype.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.changetype.HeaderText = "Changetype";
            this.changetype.Name = "changetype";
            this.changetype.ReadOnly = true;
            this.changetype.Width = 100;
            this.changetype.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.Columns.Add(changetype);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(grid);
        }
        #endregion

    }
}
