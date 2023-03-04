namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwIr348Header
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_support;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact_person;
        private System.Windows.Forms.DataGridViewTextBoxColumn family_assistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_paye;
        private System.Windows.Forms.DataGridViewTextBoxColumn not_liable;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_loan;
        private System.Windows.Forms.DataGridViewTextBoxColumn return_period;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn form_version_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ird_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdr;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Ir348Header);

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
            // return_period
            //
            return_period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.return_period.DataPropertyName = "ReturnPeriod";
            this.return_period.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.return_period.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.return_period.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.return_period.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.return_period.HeaderText = "Return Period";
            this.return_period.Name = "return_period";
            this.return_period.ReadOnly = true;
            this.return_period.Width = 105;
            this.grid.Columns.Add(return_period);


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
            // form_version_no
            //
            form_version_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.form_version_no.DataPropertyName = "FormVersionNo";
            this.form_version_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.form_version_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.form_version_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.form_version_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.form_version_no.HeaderText = "Form Version No";
            this.form_version_no.Name = "form_version_no";
            this.form_version_no.ReadOnly = true;
            this.form_version_no.Width = 115;
            this.grid.Columns.Add(form_version_no);

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
