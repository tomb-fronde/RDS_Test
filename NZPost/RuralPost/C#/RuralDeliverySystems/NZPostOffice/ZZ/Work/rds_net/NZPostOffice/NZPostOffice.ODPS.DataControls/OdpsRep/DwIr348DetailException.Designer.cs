namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwIr348DetailException
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn cs_deductioncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl_deductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_earnings;
        private System.Windows.Forms.DataGridViewTextBoxColumn family_assistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn cs_deductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtl;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ird_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_paye;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn lump_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn not_liable;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Ir348DetailException);

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
            this.grid.BackgroundColor = System.Drawing.Color.White;

            //
            // dtl
            //
            dtl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtl.DataPropertyName = "Dtl";
            this.dtl.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtl.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dtl.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dtl.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.dtl.HeaderText = "Dtl";
            this.dtl.Name = "dtl";
            this.dtl.ReadOnly = true;
            this.dtl.Width = 60;
            this.grid.Columns.Add(dtl);


            //
            // c_ird_no
            //
            c_ird_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ird_no.DataPropertyName = "CIrdNo";
            this.c_ird_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.c_ird_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.c_ird_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.c_ird_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.c_ird_no.HeaderText = "C Ird No";
            this.c_ird_no.Name = "c_ird_no";
            this.c_ird_no.ReadOnly = true;
            this.c_ird_no.Width = 55;
            this.grid.Columns.Add(c_ird_no);


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
            this.tax_code.Width = 60;
            this.grid.Columns.Add(tax_code);


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
            this.start_date.Width = 88;
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
            this.end_date.Width = 88;
            this.grid.Columns.Add(end_date);


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
            this.gross_earnings.Width = 88;
            this.grid.Columns.Add(gross_earnings);


            //
            // not_liable
            //
            not_liable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.not_liable.DataPropertyName = "NotLiable";
            this.not_liable.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.not_liable.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.not_liable.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.not_liable.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.not_liable.HeaderText = "Not Liable";
            this.not_liable.Name = "not_liable";
            this.not_liable.ReadOnly = true;
            this.not_liable.Width = 88;
            this.grid.Columns.Add(not_liable);


            //
            // lump_sum
            //
            lump_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lump_sum.DataPropertyName = "LumpSum";
            this.lump_sum.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.lump_sum.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lump_sum.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.lump_sum.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.lump_sum.HeaderText = "Lump Sum";
            this.lump_sum.Name = "lump_sum";
            this.lump_sum.ReadOnly = true;
            this.lump_sum.Width = 88;
            this.grid.Columns.Add(lump_sum);


            //
            // total_paye
            //
            total_paye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_paye.DataPropertyName = "TotalPaye";
            this.total_paye.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.total_paye.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_paye.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_paye.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.total_paye.HeaderText = "Total Paye";
            this.total_paye.Name = "total_paye";
            this.total_paye.ReadOnly = true;
            this.total_paye.Width = 88;
            this.grid.Columns.Add(total_paye);


            //
            // cs_deductions
            //
            cs_deductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cs_deductions.DataPropertyName = "CsDeductions";
            this.cs_deductions.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cs_deductions.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cs_deductions.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.cs_deductions.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.cs_deductions.HeaderText = "Cs Deductions";
            this.cs_deductions.Name = "cs_deductions";
            this.cs_deductions.ReadOnly = true;
            this.cs_deductions.Width = 88;
            this.grid.Columns.Add(cs_deductions);


            //
            // cs_deductioncode
            //
            cs_deductioncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cs_deductioncode.DataPropertyName = "CsDeductioncode";
            this.cs_deductioncode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cs_deductioncode.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cs_deductioncode.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.cs_deductioncode.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.cs_deductioncode.HeaderText = "Cs Deductioncode";
            this.cs_deductioncode.Name = "cs_deductioncode";
            this.cs_deductioncode.ReadOnly = true;
            this.cs_deductioncode.Width = 866;
            this.grid.Columns.Add(cs_deductioncode);


            //
            // sl_deductions
            //
            sl_deductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl_deductions.DataPropertyName = "SlDeductions";
            this.sl_deductions.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sl_deductions.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sl_deductions.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.sl_deductions.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.sl_deductions.HeaderText = "Sl Deductions";
            this.sl_deductions.Name = "sl_deductions";
            this.sl_deductions.ReadOnly = true;
            this.sl_deductions.Width = 88;
            this.grid.Columns.Add(sl_deductions);


            //
            // family_assistance
            //
            family_assistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.family_assistance.DataPropertyName = "FamilyAssistance";
            this.family_assistance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.family_assistance.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.family_assistance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.family_assistance.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.family_assistance.HeaderText = "Family Assistance";
            this.family_assistance.Name = "family_assistance";
            this.family_assistance.ReadOnly = true;
            this.family_assistance.Width = 88;
            this.grid.Columns.Add(family_assistance);

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
