namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    // TJB  RPCR_128  June-2019: New
    // Derived from DwIr348Header.designer
    // Unchanged except changed name 'form_version_no' to 'form_version'

    partial class DwIrdPaydayHeader
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

        private Metex.Windows.DataEntityGrid grid;
        #region Component Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.hdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ird_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pay_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.final_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nil_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paye_intermediary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact_person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriorGrossAdjustments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.not_liable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_paye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriorPayeAdjustments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.child_support = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_loan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlcirDeductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlborDeductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kiwi_deducted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kiwi_emp_contrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esct_deducted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_deducted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.family_assistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShareScheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.form_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.IrdPaydayHeader);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hdr,
            this.ird_no,
            this.pay_date,
            this.final_return,
            this.nil_return,
            this.paye_intermediary,
            this.contact_person,
            this.contact_phone,
            this.contact_email,
            this.total_lines,
            this.gross,
            this.PriorGrossAdjustments,
            this.not_liable,
            this.total_paye,
            this.PriorPayeAdjustments,
            this.child_support,
            this.student_loan,
            this.SlcirDeductions,
            this.SlborDeductions,
            this.kiwi_deducted,
            this.kiwi_emp_contrib,
            this.esct_deducted,
            this.total_deducted,
            this.total_credits,
            this.family_assistance,
            this.ShareScheme,
            this.package,
            this.form_version});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(753, 252);
            this.grid.TabIndex = 0;
            // 
            // hdr
            // 
            this.hdr.DataPropertyName = "Hdr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.hdr.DefaultCellStyle = dataGridViewCellStyle2;
            this.hdr.HeaderText = "Hdr";
            this.hdr.Name = "hdr";
            this.hdr.ReadOnly = true;
            this.hdr.Width = 40;
            // 
            // ird_no
            // 
            this.ird_no.DataPropertyName = "IrdNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.ird_no.DefaultCellStyle = dataGridViewCellStyle3;
            this.ird_no.HeaderText = "Ird No";
            this.ird_no.Name = "ird_no";
            this.ird_no.ReadOnly = true;
            this.ird_no.Width = 105;
            // 
            // pay_date
            // 
            this.pay_date.DataPropertyName = "PayDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.pay_date.DefaultCellStyle = dataGridViewCellStyle4;
            this.pay_date.HeaderText = "Pay Date";
            this.pay_date.Name = "pay_date";
            this.pay_date.ReadOnly = true;
            this.pay_date.Width = 105;
            // 
            // final_return
            // 
            this.final_return.DataPropertyName = "FinalReturn";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.final_return.DefaultCellStyle = dataGridViewCellStyle5;
            this.final_return.HeaderText = "Final Return";
            this.final_return.Name = "final_return";
            this.final_return.ReadOnly = true;
            this.final_return.Width = 40;
            // 
            // nil_return
            // 
            this.nil_return.DataPropertyName = "NilReturn";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.nil_return.DefaultCellStyle = dataGridViewCellStyle6;
            this.nil_return.HeaderText = "Nil Return";
            this.nil_return.Name = "nil_return";
            this.nil_return.ReadOnly = true;
            this.nil_return.Width = 40;
            // 
            // paye_intermediary
            // 
            this.paye_intermediary.DataPropertyName = "PayeIntermediary";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.paye_intermediary.DefaultCellStyle = dataGridViewCellStyle7;
            this.paye_intermediary.HeaderText = "PAYE Intermediary";
            this.paye_intermediary.Name = "paye_intermediary";
            this.paye_intermediary.ReadOnly = true;
            this.paye_intermediary.Width = 105;
            // 
            // contact_person
            // 
            this.contact_person.DataPropertyName = "ContactPerson";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.contact_person.DefaultCellStyle = dataGridViewCellStyle8;
            this.contact_person.HeaderText = "Contact Person";
            this.contact_person.Name = "contact_person";
            this.contact_person.ReadOnly = true;
            this.contact_person.Width = 155;
            // 
            // contact_phone
            // 
            this.contact_phone.DataPropertyName = "ContactPhone";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.contact_phone.DefaultCellStyle = dataGridViewCellStyle9;
            this.contact_phone.HeaderText = "Contact Phone";
            this.contact_phone.Name = "contact_phone";
            this.contact_phone.ReadOnly = true;
            this.contact_phone.Width = 155;
            // 
            // contact_email
            // 
            this.contact_email.DataPropertyName = "ContactEmail";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.contact_email.DefaultCellStyle = dataGridViewCellStyle10;
            this.contact_email.HeaderText = "Contact Email";
            this.contact_email.Name = "contact_email";
            this.contact_email.ReadOnly = true;
            this.contact_email.Width = 105;
            // 
            // total_lines
            // 
            this.total_lines.DataPropertyName = "TotalLines";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.total_lines.DefaultCellStyle = dataGridViewCellStyle11;
            this.total_lines.HeaderText = "Total Lines";
            this.total_lines.Name = "total_lines";
            this.total_lines.ReadOnly = true;
            this.total_lines.Width = 105;
            // 
            // gross
            // 
            this.gross.DataPropertyName = "Gross";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.gross.DefaultCellStyle = dataGridViewCellStyle12;
            this.gross.HeaderText = "Gross";
            this.gross.Name = "gross";
            this.gross.ReadOnly = true;
            this.gross.Width = 105;
            // 
            // PriorGrossAdjustments
            // 
            this.PriorGrossAdjustments.DataPropertyName = "PriorGrossAdjustments";
            this.PriorGrossAdjustments.HeaderText = "PriorGrossAdjustments";
            this.PriorGrossAdjustments.Name = "PriorGrossAdjustments";
            // 
            // not_liable
            // 
            this.not_liable.DataPropertyName = "NotLiable";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.not_liable.DefaultCellStyle = dataGridViewCellStyle13;
            this.not_liable.HeaderText = "Not Liable";
            this.not_liable.Name = "not_liable";
            this.not_liable.ReadOnly = true;
            this.not_liable.Width = 105;
            // 
            // total_paye
            // 
            this.total_paye.DataPropertyName = "TotalPaye";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.total_paye.DefaultCellStyle = dataGridViewCellStyle14;
            this.total_paye.HeaderText = "Total Paye";
            this.total_paye.Name = "total_paye";
            this.total_paye.ReadOnly = true;
            this.total_paye.Width = 105;
            // 
            // PriorPayeAdjustments
            // 
            this.PriorPayeAdjustments.DataPropertyName = "PriorPayeAdjustments";
            this.PriorPayeAdjustments.HeaderText = "PriorPayeAdjustments";
            this.PriorPayeAdjustments.Name = "PriorPayeAdjustments";
            // 
            // child_support
            // 
            this.child_support.DataPropertyName = "ChildSupport";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.child_support.DefaultCellStyle = dataGridViewCellStyle15;
            this.child_support.HeaderText = "Child Support";
            this.child_support.Name = "child_support";
            this.child_support.ReadOnly = true;
            this.child_support.Width = 105;
            // 
            // student_loan
            // 
            this.student_loan.DataPropertyName = "StudentLoan";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.student_loan.DefaultCellStyle = dataGridViewCellStyle16;
            this.student_loan.HeaderText = "Student Loan";
            this.student_loan.Name = "student_loan";
            this.student_loan.ReadOnly = true;
            this.student_loan.Width = 105;
            // 
            // SlcirDeductions
            // 
            this.SlcirDeductions.DataPropertyName = "SlcirDeductions";
            this.SlcirDeductions.HeaderText = "SlcirDeductions";
            this.SlcirDeductions.Name = "SlcirDeductions";
            // 
            // SlborDeductions
            // 
            this.SlborDeductions.DataPropertyName = "SlborDeductions";
            this.SlborDeductions.HeaderText = "SlborDeductions";
            this.SlborDeductions.Name = "SlborDeductions";
            // 
            // kiwi_deducted
            // 
            this.kiwi_deducted.DataPropertyName = "KiwiDeducted";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            this.kiwi_deducted.DefaultCellStyle = dataGridViewCellStyle17;
            this.kiwi_deducted.HeaderText = "Kiwi Deducted";
            this.kiwi_deducted.Name = "kiwi_deducted";
            this.kiwi_deducted.ReadOnly = true;
            this.kiwi_deducted.Width = 105;
            // 
            // kiwi_emp_contrib
            // 
            this.kiwi_emp_contrib.DataPropertyName = "KiwiEmpContrib";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.kiwi_emp_contrib.DefaultCellStyle = dataGridViewCellStyle18;
            this.kiwi_emp_contrib.HeaderText = "Kiwi Emp Contrib";
            this.kiwi_emp_contrib.Name = "kiwi_emp_contrib";
            this.kiwi_emp_contrib.ReadOnly = true;
            this.kiwi_emp_contrib.Width = 105;
            // 
            // esct_deducted
            // 
            this.esct_deducted.DataPropertyName = "EsctDeducted";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            this.esct_deducted.DefaultCellStyle = dataGridViewCellStyle19;
            this.esct_deducted.HeaderText = "ESCT Deducted";
            this.esct_deducted.Name = "esct_deducted";
            this.esct_deducted.ReadOnly = true;
            this.esct_deducted.Width = 105;
            // 
            // total_deducted
            // 
            this.total_deducted.DataPropertyName = "TotalDeducted";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            this.total_deducted.DefaultCellStyle = dataGridViewCellStyle20;
            this.total_deducted.HeaderText = "Total Deducted";
            this.total_deducted.Name = "total_deducted";
            this.total_deducted.ReadOnly = true;
            this.total_deducted.Width = 105;
            // 
            // total_credits
            // 
            this.total_credits.DataPropertyName = "TotalCredits";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            this.total_credits.DefaultCellStyle = dataGridViewCellStyle21;
            this.total_credits.HeaderText = "Total Credits";
            this.total_credits.Name = "total_credits";
            this.total_credits.ReadOnly = true;
            this.total_credits.Width = 105;
            // 
            // family_assistance
            // 
            this.family_assistance.DataPropertyName = "FamilyAssistance";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            this.family_assistance.DefaultCellStyle = dataGridViewCellStyle22;
            this.family_assistance.HeaderText = "Family Assistance";
            this.family_assistance.Name = "family_assistance";
            this.family_assistance.ReadOnly = true;
            this.family_assistance.Width = 115;
            // 
            // ShareScheme
            // 
            this.ShareScheme.DataPropertyName = "ShareScheme";
            this.ShareScheme.HeaderText = "ShareScheme";
            this.ShareScheme.Name = "ShareScheme";
            // 
            // package
            // 
            this.package.DataPropertyName = "Package";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            this.package.DefaultCellStyle = dataGridViewCellStyle23;
            this.package.HeaderText = "Package";
            this.package.Name = "package";
            this.package.ReadOnly = true;
            this.package.Width = 105;
            // 
            // form_version
            // 
            this.form_version.DataPropertyName = "FormVersion";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            this.form_version.DefaultCellStyle = dataGridViewCellStyle24;
            this.form_version.HeaderText = "Form Version";
            this.form_version.Name = "form_version";
            this.form_version.ReadOnly = true;
            this.form_version.Width = 115;
            // 
            // DwIrdPaydayHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Name = "DwIrdPaydayHeader";
            this.Size = new System.Drawing.Size(753, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn hdr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ird_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn pay_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn final_return;
        private System.Windows.Forms.DataGridViewTextBoxColumn nil_return;
        private System.Windows.Forms.DataGridViewTextBoxColumn paye_intermediary;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact_person;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_lines;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriorGrossAdjustments;
        private System.Windows.Forms.DataGridViewTextBoxColumn not_liable;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_paye;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriorPayeAdjustments;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_support;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_loan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlcirDeductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlborDeductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn kiwi_deducted;
        private System.Windows.Forms.DataGridViewTextBoxColumn kiwi_emp_contrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn esct_deducted;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_deducted;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn family_assistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShareScheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn package;
        private System.Windows.Forms.DataGridViewTextBoxColumn form_version;
    }
}
