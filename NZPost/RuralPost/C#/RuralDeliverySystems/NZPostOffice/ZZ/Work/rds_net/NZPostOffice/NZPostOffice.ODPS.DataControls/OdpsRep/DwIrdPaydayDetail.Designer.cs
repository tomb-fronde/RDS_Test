namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    // TJB  RPCR_128  June-2019: New
    // Derived from DwIr348Header.designer
    // Added new fields

    partial class DwIrdPaydayDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdr;

        // TJB  RPCR_128  June-2019: added
        private System.Windows.Forms.DataGridViewTextBoxColumn pay_start_date;

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
            this.grid = new Metex.Windows.DataEntityGrid();
            this.c_ird_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIrdNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payStartDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payEndDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payCycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoursPaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grossEarningsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorGrossAdjustmentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notLiableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lumpSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPayeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorPayeAdjustmentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csDeductionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csDeductioncodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slDeductionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slcirDeductionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slborDeductionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ksDeductionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ksEmpContribDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esctDeductionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxCreditsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familyAssistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShareScheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQLCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQLErrTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.IrdPaydayDetail);
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
            this.hdrDataGridViewTextBoxColumn,
            this.cIrdNoDataGridViewTextBoxColumn,
            this.employeeFullNameDataGridViewTextBoxColumn,
            this.taxCodeDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.payStartDateDataGridViewTextBoxColumn,
            this.payEndDateDataGridViewTextBoxColumn,
            this.payCycleDataGridViewTextBoxColumn,
            this.hoursPaidDataGridViewTextBoxColumn,
            this.grossEarningsDataGridViewTextBoxColumn,
            this.priorGrossAdjustmentsDataGridViewTextBoxColumn,
            this.notLiableDataGridViewTextBoxColumn,
            this.lumpSumDataGridViewTextBoxColumn,
            this.totalPayeDataGridViewTextBoxColumn,
            this.priorPayeAdjustmentsDataGridViewTextBoxColumn,
            this.csDeductionsDataGridViewTextBoxColumn,
            this.csDeductioncodeDataGridViewTextBoxColumn,
            this.slDeductionsDataGridViewTextBoxColumn,
            this.slcirDeductionsDataGridViewTextBoxColumn,
            this.slborDeductionsDataGridViewTextBoxColumn,
            this.ksDeductionsDataGridViewTextBoxColumn,
            this.ksEmpContribDataGridViewTextBoxColumn,
            this.esctDeductionsDataGridViewTextBoxColumn,
            this.taxCreditsDataGridViewTextBoxColumn,
            this.familyAssistanceDataGridViewTextBoxColumn,
            this.ShareScheme,
            this.sQLCodeDataGridViewTextBoxColumn,
            this.sQLErrTextDataGridViewTextBoxColumn});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(899, 252);
            this.grid.TabIndex = 0;
            // 
            // c_ird_no
            // 
            this.c_ird_no.DataPropertyName = "CIrdNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.c_ird_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_ird_no.HeaderText = "C Ird No";
            this.c_ird_no.Name = "c_ird_no";
            this.c_ird_no.ReadOnly = true;
            this.c_ird_no.Width = 70;
            // 
            // employee_full_name
            // 
            this.employee_full_name.DataPropertyName = "EmployeeFullName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.employee_full_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.employee_full_name.HeaderText = "Employee Full Name";
            this.employee_full_name.Name = "employee_full_name";
            this.employee_full_name.ReadOnly = true;
            this.employee_full_name.Width = 305;
            // 
            // tax_code
            // 
            this.tax_code.DataPropertyName = "TaxCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.tax_code.DefaultCellStyle = dataGridViewCellStyle4;
            this.tax_code.HeaderText = "Tax Code";
            this.tax_code.Name = "tax_code";
            this.tax_code.ReadOnly = true;
            this.tax_code.Width = 60;
            // 
            // start_date
            // 
            this.start_date.DataPropertyName = "StartDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.start_date.DefaultCellStyle = dataGridViewCellStyle5;
            this.start_date.HeaderText = "Start Date";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Width = 88;
            // 
            // end_date
            // 
            this.end_date.DataPropertyName = "EndDate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.end_date.DefaultCellStyle = dataGridViewCellStyle6;
            this.end_date.HeaderText = "End Date";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            this.end_date.Width = 88;
            // 
            // hdrDataGridViewTextBoxColumn
            // 
            this.hdrDataGridViewTextBoxColumn.DataPropertyName = "Hdr";
            this.hdrDataGridViewTextBoxColumn.HeaderText = "Hdr";
            this.hdrDataGridViewTextBoxColumn.Name = "hdrDataGridViewTextBoxColumn";
            // 
            // cIrdNoDataGridViewTextBoxColumn
            // 
            this.cIrdNoDataGridViewTextBoxColumn.DataPropertyName = "CIrdNo";
            this.cIrdNoDataGridViewTextBoxColumn.HeaderText = "CIrdNo";
            this.cIrdNoDataGridViewTextBoxColumn.Name = "cIrdNoDataGridViewTextBoxColumn";
            // 
            // employeeFullNameDataGridViewTextBoxColumn
            // 
            this.employeeFullNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeFullName";
            this.employeeFullNameDataGridViewTextBoxColumn.HeaderText = "EmployeeFullName";
            this.employeeFullNameDataGridViewTextBoxColumn.Name = "employeeFullNameDataGridViewTextBoxColumn";
            // 
            // taxCodeDataGridViewTextBoxColumn
            // 
            this.taxCodeDataGridViewTextBoxColumn.DataPropertyName = "TaxCode";
            this.taxCodeDataGridViewTextBoxColumn.HeaderText = "TaxCode";
            this.taxCodeDataGridViewTextBoxColumn.Name = "taxCodeDataGridViewTextBoxColumn";
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "EndDate";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            // 
            // payStartDateDataGridViewTextBoxColumn
            // 
            this.payStartDateDataGridViewTextBoxColumn.DataPropertyName = "PayStartDate";
            this.payStartDateDataGridViewTextBoxColumn.HeaderText = "PayStartDate";
            this.payStartDateDataGridViewTextBoxColumn.Name = "payStartDateDataGridViewTextBoxColumn";
            // 
            // payEndDateDataGridViewTextBoxColumn
            // 
            this.payEndDateDataGridViewTextBoxColumn.DataPropertyName = "PayEndDate";
            this.payEndDateDataGridViewTextBoxColumn.HeaderText = "PayEndDate";
            this.payEndDateDataGridViewTextBoxColumn.Name = "payEndDateDataGridViewTextBoxColumn";
            // 
            // payCycleDataGridViewTextBoxColumn
            // 
            this.payCycleDataGridViewTextBoxColumn.DataPropertyName = "PayCycle";
            this.payCycleDataGridViewTextBoxColumn.HeaderText = "PayCycle";
            this.payCycleDataGridViewTextBoxColumn.Name = "payCycleDataGridViewTextBoxColumn";
            // 
            // hoursPaidDataGridViewTextBoxColumn
            // 
            this.hoursPaidDataGridViewTextBoxColumn.DataPropertyName = "HoursPaid";
            this.hoursPaidDataGridViewTextBoxColumn.HeaderText = "HoursPaid";
            this.hoursPaidDataGridViewTextBoxColumn.Name = "hoursPaidDataGridViewTextBoxColumn";
            // 
            // grossEarningsDataGridViewTextBoxColumn
            // 
            this.grossEarningsDataGridViewTextBoxColumn.DataPropertyName = "GrossEarnings";
            this.grossEarningsDataGridViewTextBoxColumn.HeaderText = "GrossEarnings";
            this.grossEarningsDataGridViewTextBoxColumn.Name = "grossEarningsDataGridViewTextBoxColumn";
            // 
            // priorGrossAdjustmentsDataGridViewTextBoxColumn
            // 
            this.priorGrossAdjustmentsDataGridViewTextBoxColumn.DataPropertyName = "PriorGrossAdjustments";
            this.priorGrossAdjustmentsDataGridViewTextBoxColumn.HeaderText = "PriorGrossAdjustments";
            this.priorGrossAdjustmentsDataGridViewTextBoxColumn.Name = "priorGrossAdjustmentsDataGridViewTextBoxColumn";
            // 
            // notLiableDataGridViewTextBoxColumn
            // 
            this.notLiableDataGridViewTextBoxColumn.DataPropertyName = "NotLiable";
            this.notLiableDataGridViewTextBoxColumn.HeaderText = "NotLiable";
            this.notLiableDataGridViewTextBoxColumn.Name = "notLiableDataGridViewTextBoxColumn";
            // 
            // lumpSumDataGridViewTextBoxColumn
            // 
            this.lumpSumDataGridViewTextBoxColumn.DataPropertyName = "LumpSum";
            this.lumpSumDataGridViewTextBoxColumn.HeaderText = "LumpSum";
            this.lumpSumDataGridViewTextBoxColumn.Name = "lumpSumDataGridViewTextBoxColumn";
            // 
            // totalPayeDataGridViewTextBoxColumn
            // 
            this.totalPayeDataGridViewTextBoxColumn.DataPropertyName = "TotalPaye";
            this.totalPayeDataGridViewTextBoxColumn.HeaderText = "TotalPaye";
            this.totalPayeDataGridViewTextBoxColumn.Name = "totalPayeDataGridViewTextBoxColumn";
            // 
            // priorPayeAdjustmentsDataGridViewTextBoxColumn
            // 
            this.priorPayeAdjustmentsDataGridViewTextBoxColumn.DataPropertyName = "PriorPayeAdjustments";
            this.priorPayeAdjustmentsDataGridViewTextBoxColumn.HeaderText = "PriorPayeAdjustments";
            this.priorPayeAdjustmentsDataGridViewTextBoxColumn.Name = "priorPayeAdjustmentsDataGridViewTextBoxColumn";
            // 
            // csDeductionsDataGridViewTextBoxColumn
            // 
            this.csDeductionsDataGridViewTextBoxColumn.DataPropertyName = "CsDeductions";
            this.csDeductionsDataGridViewTextBoxColumn.HeaderText = "CsDeductions";
            this.csDeductionsDataGridViewTextBoxColumn.Name = "csDeductionsDataGridViewTextBoxColumn";
            // 
            // csDeductioncodeDataGridViewTextBoxColumn
            // 
            this.csDeductioncodeDataGridViewTextBoxColumn.DataPropertyName = "CsDeductioncode";
            this.csDeductioncodeDataGridViewTextBoxColumn.HeaderText = "CsDeductioncode";
            this.csDeductioncodeDataGridViewTextBoxColumn.Name = "csDeductioncodeDataGridViewTextBoxColumn";
            // 
            // slDeductionsDataGridViewTextBoxColumn
            // 
            this.slDeductionsDataGridViewTextBoxColumn.DataPropertyName = "SlDeductions";
            this.slDeductionsDataGridViewTextBoxColumn.HeaderText = "SlDeductions";
            this.slDeductionsDataGridViewTextBoxColumn.Name = "slDeductionsDataGridViewTextBoxColumn";
            // 
            // slcirDeductionsDataGridViewTextBoxColumn
            // 
            this.slcirDeductionsDataGridViewTextBoxColumn.DataPropertyName = "SlcirDeductions";
            this.slcirDeductionsDataGridViewTextBoxColumn.HeaderText = "SlcirDeductions";
            this.slcirDeductionsDataGridViewTextBoxColumn.Name = "slcirDeductionsDataGridViewTextBoxColumn";
            // 
            // slborDeductionsDataGridViewTextBoxColumn
            // 
            this.slborDeductionsDataGridViewTextBoxColumn.DataPropertyName = "SlborDeductions";
            this.slborDeductionsDataGridViewTextBoxColumn.HeaderText = "SlborDeductions";
            this.slborDeductionsDataGridViewTextBoxColumn.Name = "slborDeductionsDataGridViewTextBoxColumn";
            // 
            // ksDeductionsDataGridViewTextBoxColumn
            // 
            this.ksDeductionsDataGridViewTextBoxColumn.DataPropertyName = "KsDeductions";
            this.ksDeductionsDataGridViewTextBoxColumn.HeaderText = "KsDeductions";
            this.ksDeductionsDataGridViewTextBoxColumn.Name = "ksDeductionsDataGridViewTextBoxColumn";
            // 
            // ksEmpContribDataGridViewTextBoxColumn
            // 
            this.ksEmpContribDataGridViewTextBoxColumn.DataPropertyName = "KsEmpContrib";
            this.ksEmpContribDataGridViewTextBoxColumn.HeaderText = "KsEmpContrib";
            this.ksEmpContribDataGridViewTextBoxColumn.Name = "ksEmpContribDataGridViewTextBoxColumn";
            // 
            // esctDeductionsDataGridViewTextBoxColumn
            // 
            this.esctDeductionsDataGridViewTextBoxColumn.DataPropertyName = "EsctDeductions";
            this.esctDeductionsDataGridViewTextBoxColumn.HeaderText = "EsctDeductions";
            this.esctDeductionsDataGridViewTextBoxColumn.Name = "esctDeductionsDataGridViewTextBoxColumn";
            // 
            // taxCreditsDataGridViewTextBoxColumn
            // 
            this.taxCreditsDataGridViewTextBoxColumn.DataPropertyName = "TaxCredits";
            this.taxCreditsDataGridViewTextBoxColumn.HeaderText = "TaxCredits";
            this.taxCreditsDataGridViewTextBoxColumn.Name = "taxCreditsDataGridViewTextBoxColumn";
            // 
            // familyAssistanceDataGridViewTextBoxColumn
            // 
            this.familyAssistanceDataGridViewTextBoxColumn.DataPropertyName = "FamilyAssistance";
            this.familyAssistanceDataGridViewTextBoxColumn.HeaderText = "FamilyAssistance";
            this.familyAssistanceDataGridViewTextBoxColumn.Name = "familyAssistanceDataGridViewTextBoxColumn";
            // 
            // ShareScheme
            // 
            this.ShareScheme.DataPropertyName = "ShareScheme";
            this.ShareScheme.HeaderText = "ShareScheme";
            this.ShareScheme.Name = "ShareScheme";
            // 
            // sQLCodeDataGridViewTextBoxColumn
            // 
            this.sQLCodeDataGridViewTextBoxColumn.DataPropertyName = "SQLCode";
            this.sQLCodeDataGridViewTextBoxColumn.HeaderText = "SQLCode";
            this.sQLCodeDataGridViewTextBoxColumn.Name = "sQLCodeDataGridViewTextBoxColumn";
            this.sQLCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sQLErrTextDataGridViewTextBoxColumn
            // 
            this.sQLErrTextDataGridViewTextBoxColumn.DataPropertyName = "SQLErrText";
            this.sQLErrTextDataGridViewTextBoxColumn.HeaderText = "SQLErrText";
            this.sQLErrTextDataGridViewTextBoxColumn.Name = "sQLErrTextDataGridViewTextBoxColumn";
            this.sQLErrTextDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DwIrdPaydayDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Name = "DwIrdPaydayDetail";
            this.Size = new System.Drawing.Size(899, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn c_ird_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIrdNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn payStartDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn payEndDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn payCycleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoursPaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grossEarningsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorGrossAdjustmentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notLiableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lumpSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPayeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorPayeAdjustmentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn csDeductionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn csDeductioncodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slDeductionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slcirDeductionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slborDeductionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksDeductionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksEmpContribDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn esctDeductionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxCreditsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn familyAssistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShareScheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn sQLCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sQLErrTextDataGridViewTextBoxColumn;
    }
}
