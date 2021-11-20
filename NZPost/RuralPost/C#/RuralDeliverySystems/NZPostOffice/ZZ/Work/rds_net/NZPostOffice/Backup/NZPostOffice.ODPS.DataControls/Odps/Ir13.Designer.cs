namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class Ir13
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn employer_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_earnings;
        private System.Windows.Forms.DataGridViewTextBoxColumn ird_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_paye_deduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn employer_ird_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_earner_premium;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowance_tax_free_amounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_loan_repayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn employer_full_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn earnings_liable_for_premium;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn period_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn occupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_signed;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractor_supplier_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn employer_trade_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowance_tax_free_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn extra_pays;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_of_payer;
        private System.Windows.Forms.DataGridViewTextBoxColumn period_end_date;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.Ir13);

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
            // contractor_supplier_no
            //
            contractor_supplier_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractor_supplier_no.DataPropertyName = "ContractorSupplierNo";
            this.contractor_supplier_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.contractor_supplier_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_supplier_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contractor_supplier_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_supplier_no.HeaderText = "Contractor Supplier No";
            this.contractor_supplier_no.Name = "contractor_supplier_no";
            this.contractor_supplier_no.ReadOnly = true;
            this.contractor_supplier_no.Width = 140;
            this.grid.Columns.Add(contractor_supplier_no);


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
            this.employee_full_name.Width = 305;
            this.grid.Columns.Add(employee_full_name);


            //
            // employee_address
            //
            employee_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee_address.DataPropertyName = "EmployeeAddress";
            this.employee_address.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.employee_address.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.employee_address.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.employee_address.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.employee_address.HeaderText = "Employee Address";
            this.employee_address.Name = "employee_address";
            this.employee_address.ReadOnly = true;
            this.employee_address.Width = 866;
            this.grid.Columns.Add(employee_address);


            //
            // occupation
            //
            occupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occupation.DataPropertyName = "Occupation";
            this.occupation.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.occupation.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.occupation.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.occupation.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.occupation.HeaderText = "Occupation";
            this.occupation.Name = "occupation";
            this.occupation.ReadOnly = true;
            this.occupation.Width = 85;
            this.grid.Columns.Add(occupation);


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
            this.allowance_tax_free_type.Width = 125;
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
            this.allowance_tax_free_amounts.HeaderText = "Allowance Tax Free Amounts";
            this.allowance_tax_free_amounts.Name = "allowance_tax_free_amounts";
            this.allowance_tax_free_amounts.ReadOnly = true;
            this.allowance_tax_free_amounts.Width = 144;
            this.grid.Columns.Add(allowance_tax_free_amounts);


            //
            // employer_full_name
            //
            employer_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employer_full_name.DataPropertyName = "EmployerFullName";
            this.employer_full_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.employer_full_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.employer_full_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.employer_full_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.employer_full_name.HeaderText = "Employer Full Name";
            this.employer_full_name.Name = "employer_full_name";
            this.employer_full_name.ReadOnly = true;
            this.employer_full_name.Width = 866;
            this.grid.Columns.Add(employer_full_name);


            //
            // employer_full_address
            //
            employer_full_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employer_full_address.DataPropertyName = "EmployerFullAddress";
            this.employer_full_address.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.employer_full_address.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.employer_full_address.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.employer_full_address.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.employer_full_address.HeaderText = "Employer Full Address";
            this.employer_full_address.Name = "employer_full_address";
            this.employer_full_address.ReadOnly = true;
            this.employer_full_address.Width = 866;
            this.grid.Columns.Add(employer_full_address);


            //
            // employer_trade_name
            //
            employer_trade_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employer_trade_name.DataPropertyName = "EmployerTradeName";
            this.employer_trade_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.employer_trade_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.employer_trade_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.employer_trade_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.employer_trade_name.HeaderText = "Employer Trade Name";
            this.employer_trade_name.Name = "employer_trade_name";
            this.employer_trade_name.ReadOnly = true;
            this.employer_trade_name.Width = 105;
            this.grid.Columns.Add(employer_trade_name);


            //
            // name_of_payer
            //
            name_of_payer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_of_payer.DataPropertyName = "NameOfPayer";
            this.name_of_payer.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name_of_payer.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.name_of_payer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.name_of_payer.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.name_of_payer.HeaderText = "Name Of Payer";
            this.name_of_payer.Name = "name_of_payer";
            this.name_of_payer.ReadOnly = true;
            this.name_of_payer.Width = 73;
            this.grid.Columns.Add(name_of_payer);


            //
            // date_signed
            //
            date_signed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_signed.DataPropertyName = "DateSigned";
            this.date_signed.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.date_signed.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.date_signed.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.date_signed.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.date_signed.HeaderText = "Date Signed";
            this.date_signed.Name = "date_signed";
            this.date_signed.ReadOnly = true;
            this.date_signed.Width = 65;
            this.grid.Columns.Add(date_signed);


            //
            // period_start_date
            //
            period_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period_start_date.DataPropertyName = "PeriodStartDate";
            this.period_start_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.period_start_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.period_start_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.period_start_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.period_start_date.HeaderText = "Period Start Date";
            this.period_start_date.Name = "period_start_date";
            this.period_start_date.ReadOnly = true;
            this.period_start_date.Width = 81;
            this.grid.Columns.Add(period_start_date);


            //
            // period_end_date
            //
            period_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period_end_date.DataPropertyName = "PeriodEndDate";
            this.period_end_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.period_end_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.period_end_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.period_end_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.period_end_date.HeaderText = "Period End Date";
            this.period_end_date.Name = "period_end_date";
            this.period_end_date.ReadOnly = true;
            this.period_end_date.Width = 76;
            this.grid.Columns.Add(period_end_date);


            //
            // ird_number
            //
            ird_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ird_number.DataPropertyName = "IrdNumber";
            this.ird_number.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ird_number.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ird_number.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ird_number.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ird_number.HeaderText = "Ird Number";
            this.ird_number.Name = "ird_number";
            this.ird_number.ReadOnly = true;
            this.ird_number.Width = 55;
            this.grid.Columns.Add(ird_number);


            //
            // tax_code
            //
            tax_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_code.DataPropertyName = "TaxCode";
            this.tax_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.tax_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tax_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tax_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.tax_code.HeaderText = "Tax Code";
            this.tax_code.Name = "tax_code";
            this.tax_code.ReadOnly = true;
            this.tax_code.Width = 46;
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
            this.extra_pays.Width = 52;
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
            this.total_paye_deduction.Width = 101;
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
            this.earnings_liable_for_premium.Width = 135;
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
            this.acc_earner_premium.Width = 98;
            this.grid.Columns.Add(acc_earner_premium);


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
            this.student_loan_repayment.HeaderText = "Student Loan Repayment";
            this.student_loan_repayment.Name = "student_loan_repayment";
            this.student_loan_repayment.ReadOnly = true;
            this.student_loan_repayment.Width = 121;
            this.grid.Columns.Add(student_loan_repayment);


            //
            // employer_ird_number
            //
            employer_ird_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employer_ird_number.DataPropertyName = "EmployerIrdNumber";
            this.employer_ird_number.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.employer_ird_number.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.employer_ird_number.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.employer_ird_number.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.employer_ird_number.HeaderText = "Employer Ird Number";
            this.employer_ird_number.Name = "employer_ird_number";
            this.employer_ird_number.ReadOnly = true;
            this.employer_ird_number.Width = 105;
            this.grid.Columns.Add(employer_ird_number);


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
            this.start_date.Width = 55;
            this.grid.Columns.Add(start_date);


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
            this.end_date.Width = 55;
            this.grid.Columns.Add(end_date);

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
