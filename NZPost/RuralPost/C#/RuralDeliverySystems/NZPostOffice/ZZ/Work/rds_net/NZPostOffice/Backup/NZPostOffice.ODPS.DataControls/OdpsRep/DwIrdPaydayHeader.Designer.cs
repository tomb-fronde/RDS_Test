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
        private System.Windows.Forms.DataGridViewTextBoxColumn total_paye;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_support;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_loan;
        private System.Windows.Forms.DataGridViewTextBoxColumn kiwi_deducted;
        private System.Windows.Forms.DataGridViewTextBoxColumn kiwi_emp_contrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn esct_deducted;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_deducted;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn family_assistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn not_liable;
        private System.Windows.Forms.DataGridViewTextBoxColumn package;
        private System.Windows.Forms.DataGridViewTextBoxColumn form_version;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.IrdPaydayHeader);

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
            this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = System.Drawing.Color.White;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
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
            // hdr
            //
            hdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdr.DataPropertyName = "Hdr";
            this.hdr.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.hdr.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.hdr.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.hdr.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.hdr.HeaderText = "Hdr";
            this.hdr.Name = "hdr";
            this.hdr.ReadOnly = true;
            this.hdr.Width = 40;
            this.grid.Columns.Add(hdr);


            //
            // ird_no
            //
            ird_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ird_no.DataPropertyName = "IrdNo";
            this.ird_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ird_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ird_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ird_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ird_no.HeaderText = "Ird No";
            this.ird_no.Name = "ird_no";
            this.ird_no.ReadOnly = true;
            this.ird_no.Width = 105;
            this.grid.Columns.Add(ird_no);


            //
            // pay_date
            //
            pay_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pay_date.DataPropertyName = "PayDate";
            this.pay_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pay_date.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.pay_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pay_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.pay_date.HeaderText = "Pay Date";
            this.pay_date.Name = "pay_date";
            this.pay_date.ReadOnly = true;
            this.pay_date.Width = 105;
            this.grid.Columns.Add(pay_date);


            //
            // final_return
            //
            final_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.final_return.DataPropertyName = "FinalReturn";
            this.final_return.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.final_return.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.final_return.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.final_return.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.final_return.HeaderText = "Final Return";
            this.final_return.Name = "final_return";
            this.final_return.ReadOnly = true;
            this.final_return.Width = 40;
            this.grid.Columns.Add(final_return);


            //
            // nil_return
            //
            nil_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nil_return.DataPropertyName = "NilReturn";
            this.nil_return.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nil_return.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.nil_return.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.nil_return.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.nil_return.HeaderText = "Nil Return";
            this.nil_return.Name = "nil_return";
            this.nil_return.ReadOnly = true;
            this.nil_return.Width = 40;
            this.grid.Columns.Add(nil_return);


            //
            // paye_intermediary
            //
            paye_intermediary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paye_intermediary.DataPropertyName = "PayeIntermediary";
            this.paye_intermediary.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.paye_intermediary.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.paye_intermediary.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.paye_intermediary.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.paye_intermediary.HeaderText = "PAYE Intermediary";
            this.paye_intermediary.Name = "paye_intermediary";
            this.paye_intermediary.ReadOnly = true;
            this.paye_intermediary.Width = 105;
            this.grid.Columns.Add(paye_intermediary);


            //
            // contact_person
            //
            contact_person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact_person.DataPropertyName = "ContactPerson";
            this.contact_person.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contact_person.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.contact_person.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contact_person.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.contact_person.HeaderText = "Contact Person";
            this.contact_person.Name = "contact_person";
            this.contact_person.ReadOnly = true;
            this.contact_person.Width = 155;
            this.grid.Columns.Add(contact_person);


            //
            // contact_phone
            //
            contact_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact_phone.DataPropertyName = "ContactPhone";
            this.contact_phone.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contact_phone.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.contact_phone.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contact_phone.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.contact_phone.HeaderText = "Contact Phone";
            this.contact_phone.Name = "contact_phone";
            this.contact_phone.ReadOnly = true;
            this.contact_phone.Width = 155;
            this.grid.Columns.Add(contact_phone);


            //
            // contact_email
            //
            contact_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact_email.DataPropertyName = "ContactEmail";
            this.contact_email.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contact_email.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.contact_email.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contact_email.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.contact_email.HeaderText = "Contact Email";
            this.contact_email.Name = "contact_email";
            this.contact_email.ReadOnly = true;
            this.contact_email.Width = 105;
            this.grid.Columns.Add(contact_email);


            //
            // total_lines
            //
            total_lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_lines.DataPropertyName = "TotalLines";
            this.total_lines.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.total_lines.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.total_lines.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_lines.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.total_lines.HeaderText = "Total Lines";
            this.total_lines.Name = "total_lines";
            this.total_lines.ReadOnly = true;
            this.total_lines.Width = 105;
            this.grid.Columns.Add(total_lines);


            //
            // total_paye
            //
            total_paye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_paye.DataPropertyName = "TotalPaye";
            this.total_paye.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.total_paye.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.total_paye.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_paye.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.total_paye.HeaderText = "Total Paye";
            this.total_paye.Name = "total_paye";
            this.total_paye.ReadOnly = true;
            this.total_paye.Width = 105;
            this.grid.Columns.Add(total_paye);


            //
            // child_support
            //
            child_support = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.child_support.DataPropertyName = "ChildSupport";
            this.child_support.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.child_support.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.child_support.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.child_support.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.child_support.HeaderText = "Child Support";
            this.child_support.Name = "child_support";
            this.child_support.ReadOnly = true;
            this.child_support.Width = 105;
            this.grid.Columns.Add(child_support);


            //
            // student_loan
            //
            student_loan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_loan.DataPropertyName = "StudentLoan";
            this.student_loan.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.student_loan.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.student_loan.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.student_loan.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.student_loan.HeaderText = "Student Loan";
            this.student_loan.Name = "student_loan";
            this.student_loan.ReadOnly = true;
            this.student_loan.Width = 105;
            this.grid.Columns.Add(student_loan);


            //
            // kiwi_deducted
            //
            kiwi_deducted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kiwi_deducted.DataPropertyName = "KiwiDeducted";
            this.kiwi_deducted.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.kiwi_deducted.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.kiwi_deducted.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.kiwi_deducted.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.kiwi_deducted.HeaderText = "Kiwi Deducted";
            this.kiwi_deducted.Name = "kiwi_deducted";
            this.kiwi_deducted.ReadOnly = true;
            this.kiwi_deducted.Width = 105;
            this.grid.Columns.Add(kiwi_deducted);


            //
            // kiwi_emp_contrib
            //
            kiwi_emp_contrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kiwi_emp_contrib.DataPropertyName = "KiwiEmpContrib";
            this.kiwi_emp_contrib.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.kiwi_emp_contrib.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.kiwi_emp_contrib.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.kiwi_emp_contrib.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.kiwi_emp_contrib.HeaderText = "Kiwi Emp Contrib";
            this.kiwi_emp_contrib.Name = "kiwi_emp_contrib";
            this.kiwi_emp_contrib.ReadOnly = true;
            this.kiwi_emp_contrib.Width = 105;
            this.grid.Columns.Add(kiwi_emp_contrib);


            //
            // esct_deducted
            //
            esct_deducted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esct_deducted.DataPropertyName = "EsctDeducted";
            this.esct_deducted.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.esct_deducted.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.esct_deducted.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.esct_deducted.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.esct_deducted.HeaderText = "ESCT Deducted";
            this.esct_deducted.Name = "esct_deducted";
            this.esct_deducted.ReadOnly = true;
            this.esct_deducted.Width = 105;
            this.grid.Columns.Add(esct_deducted);


            //
            // total_deducted
            //
            total_deducted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_deducted.DataPropertyName = "TotalDeducted";
            this.total_deducted.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.total_deducted.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.total_deducted.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_deducted.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.total_deducted.HeaderText = "Total Deducted";
            this.total_deducted.Name = "total_deducted";
            this.total_deducted.ReadOnly = true;
            this.total_deducted.Width = 105;
            this.grid.Columns.Add(total_deducted);


            //
            // total_credits
            //
            total_credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_credits.DataPropertyName = "TotalCredits";
            this.total_credits.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.total_credits.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.total_credits.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_credits.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.total_credits.HeaderText = "Total Credits";
            this.total_credits.Name = "total_credits";
            this.total_credits.ReadOnly = true;
            this.total_credits.Width = 105;
            this.grid.Columns.Add(total_credits);


            //
            // family_assistance
            //
            family_assistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.family_assistance.DataPropertyName = "FamilyAssistance";
            this.family_assistance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.family_assistance.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.family_assistance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.family_assistance.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.family_assistance.HeaderText = "Family Assistance";
            this.family_assistance.Name = "family_assistance";
            this.family_assistance.ReadOnly = true;
            this.family_assistance.Width = 115;
            this.grid.Columns.Add(family_assistance);


            //
            // gross
            //
            gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross.DataPropertyName = "Gross";
            this.gross.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gross.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gross.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gross.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.gross.HeaderText = "Gross";
            this.gross.Name = "gross";
            this.gross.ReadOnly = true;
            this.gross.Width = 105;
            this.grid.Columns.Add(gross);


            //
            // not_liable
            //
            not_liable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.not_liable.DataPropertyName = "NotLiable";
            this.not_liable.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.not_liable.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.not_liable.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.not_liable.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.not_liable.HeaderText = "Not Liable";
            this.not_liable.Name = "not_liable";
            this.not_liable.ReadOnly = true;
            this.not_liable.Width = 105;
            this.grid.Columns.Add(not_liable);


            //
            // package
            //
            package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package.DataPropertyName = "Package";
            this.package.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.package.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.package.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.package.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.package.HeaderText = "Package";
            this.package.Name = "package";
            this.package.ReadOnly = true;
            this.package.Width = 105;
            this.grid.Columns.Add(package);


            //
            // form_version
            //
            form_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.form_version.DataPropertyName = "FormVersion";
            this.form_version.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.form_version.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.form_version.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.form_version.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.form_version.HeaderText = "Form Version";
            this.form_version.Name = "form_version";
            this.form_version.ReadOnly = true;
            this.form_version.Width = 115;
            this.grid.Columns.Add(form_version);

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
