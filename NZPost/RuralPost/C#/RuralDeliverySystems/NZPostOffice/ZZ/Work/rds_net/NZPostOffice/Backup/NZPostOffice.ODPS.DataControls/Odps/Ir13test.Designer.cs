namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class Ir13test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_earnings;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_deductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_paye_deduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_earner_premium;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowance_tax_free_amounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_loan_repayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn earnings_liable_for_premium;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowance_tax_free_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn extra_pays;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.Ir13test);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
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
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // employee_full_name
            //
            employee_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee_full_name.DataPropertyName = "EmployeeFullName";
            this.employee_full_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.employee_full_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.employee_full_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.employee_full_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.employee_full_name.HeaderText = "Employee Full Name";
            this.employee_full_name.Name = "employee_full_name";
            this.employee_full_name.ReadOnly = true;
            this.employee_full_name.Width = 218;
            this.grid.Columns.Add(employee_full_name);


            //
            // allowance_tax_free_type
            //
            allowance_tax_free_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowance_tax_free_type.DataPropertyName = "AllowanceTaxFreeType";
            this.allowance_tax_free_type.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.allowance_tax_free_type.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.allowance_tax_free_type.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.allowance_tax_free_type.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.allowance_tax_free_type.HeaderText = "Allowance Tax Free Type";
            this.allowance_tax_free_type.Name = "allowance_tax_free_type";
            this.allowance_tax_free_type.ReadOnly = true;
            this.allowance_tax_free_type.Width = 2;
            this.grid.Columns.Add(allowance_tax_free_type);


            //
            // allowance_tax_free_amounts
            //
            allowance_tax_free_amounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowance_tax_free_amounts.DataPropertyName = "AllowanceTaxFreeAmounts";
            this.allowance_tax_free_amounts.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.allowance_tax_free_amounts.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.allowance_tax_free_amounts.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.allowance_tax_free_amounts.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.allowance_tax_free_amounts.HeaderText = "Allowance Tax Free Type";
            this.allowance_tax_free_amounts.Name = "allowance_tax_free_amounts";
            this.allowance_tax_free_amounts.ReadOnly = true;
            this.allowance_tax_free_amounts.Width = 3;
            this.grid.Columns.Add(allowance_tax_free_amounts);


            //
            // tax_code
            //
            tax_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_code.DataPropertyName = "TaxCode";
            this.tax_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.tax_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tax_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tax_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.tax_code.HeaderText = "Allowance Tax Free Type";
            this.tax_code.Name = "tax_code";
            this.tax_code.ReadOnly = true;
            this.tax_code.Width = 25;
            this.grid.Columns.Add(tax_code);


            //
            // extra_pays
            //
            extra_pays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extra_pays.DataPropertyName = "ExtraPays";
            this.extra_pays.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.extra_pays.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.extra_pays.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.extra_pays.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.extra_pays.HeaderText = "Extra Pays";
            this.extra_pays.Name = "extra_pays";
            this.extra_pays.ReadOnly = true;
            this.extra_pays.Width = 14;
            this.grid.Columns.Add(extra_pays);


            //
            // total_paye_deduction
            //
            total_paye_deduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_paye_deduction.DataPropertyName = "TotalPayeDeduction";
            this.total_paye_deduction.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.total_paye_deduction.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_paye_deduction.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_paye_deduction.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.total_paye_deduction.HeaderText = "Total Paye Deduction";
            this.total_paye_deduction.Name = "total_paye_deduction";
            this.total_paye_deduction.ReadOnly = true;
            this.total_paye_deduction.Width = 53;
            this.grid.Columns.Add(total_paye_deduction);


            //
            // earnings_liable_for_premium
            //
            earnings_liable_for_premium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.earnings_liable_for_premium.DataPropertyName = "EarningsLiableForPremium";
            this.earnings_liable_for_premium.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.earnings_liable_for_premium.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.earnings_liable_for_premium.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.earnings_liable_for_premium.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.earnings_liable_for_premium.HeaderText = "Earnings Liable For Premium";
            this.earnings_liable_for_premium.Name = "earnings_liable_for_premium";
            this.earnings_liable_for_premium.ReadOnly = true;
            this.earnings_liable_for_premium.Width = 52;
            this.grid.Columns.Add(earnings_liable_for_premium);


            //
            // acc_earner_premium
            //
            acc_earner_premium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acc_earner_premium.DataPropertyName = "AccEarnerPremium";
            this.acc_earner_premium.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.acc_earner_premium.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.acc_earner_premium.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.acc_earner_premium.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.acc_earner_premium.HeaderText = "Acc Earner Premium";
            this.acc_earner_premium.Name = "acc_earner_premium";
            this.acc_earner_premium.ReadOnly = true;
            this.acc_earner_premium.Width = 52;
            this.grid.Columns.Add(acc_earner_premium);


            //
            // tax_deductions
            //
            tax_deductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_deductions.DataPropertyName = "TaxDeductions";
            this.tax_deductions.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tax_deductions.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tax_deductions.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tax_deductions.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.tax_deductions.HeaderText = "Tax Deductions";
            this.tax_deductions.Name = "tax_deductions";
            this.tax_deductions.ReadOnly = true;
            this.tax_deductions.Width = 75;
            this.grid.Columns.Add(tax_deductions);


            //
            // gross_earnings
            //
            gross_earnings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross_earnings.DataPropertyName = "GrossEarnings";
            this.gross_earnings.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gross_earnings.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gross_earnings.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gross_earnings.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.gross_earnings.HeaderText = "Gross Earnings";
            this.gross_earnings.Name = "gross_earnings";
            this.gross_earnings.ReadOnly = true;
            this.gross_earnings.Width = 75;
            this.grid.Columns.Add(gross_earnings);


            //
            // student_loan_repayment
            //
            student_loan_repayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_loan_repayment.DataPropertyName = "StudentLoanRepayment";
            this.student_loan_repayment.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.student_loan_repayment.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.student_loan_repayment.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.student_loan_repayment.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.student_loan_repayment.HeaderText = "Start Date";
            this.student_loan_repayment.Name = "student_loan_repayment";
            this.student_loan_repayment.ReadOnly = true;
            this.student_loan_repayment.Width = 65;
            this.grid.Columns.Add(student_loan_repayment);


            //
            // end_date
            //
            end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date.DataPropertyName = "EndDate";
            this.end_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.end_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.end_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.end_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.end_date.HeaderText = "End Date";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            this.end_date.Width = 65;
            this.grid.Columns.Add(end_date);


            //
            // start_date
            //
            start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date.DataPropertyName = "StartDate";
            this.start_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.start_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.start_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.start_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.start_date.HeaderText = "Start Date";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Width = 65;
            this.grid.Columns.Add(start_date);

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
