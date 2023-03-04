namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    // TJB  RPCR_094  Mar-2015 - NEW

    partial class DwPayrunNegativepay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Metex.Windows.DataEntityGrid grid;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.grid = new Metex.Windows.DataEntityGrid();
            this.contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_surname_company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_first_names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_tax_adjustments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.PayrunNegativepay);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contract_no,
            this.c_surname_company,
            this.c_first_names,
            this.gross_pay,
            this.gst,
            this.tax,
            this.post_tax_adjustments,
            this.net_pay,
            this.contract_pay});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(859, 252);
            this.grid.TabIndex = 0;
            // 
            // contract_no
            // 
            this.contract_no.DataPropertyName = "ContractNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.contract_no.HeaderText = "Contract No";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Width = 60;
            // 
            // c_surname_company
            // 
            this.c_surname_company.DataPropertyName = "CSurnameCompany";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.c_surname_company.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_surname_company.HeaderText = "Surname/Company";
            this.c_surname_company.Name = "c_surname_company";
            this.c_surname_company.ReadOnly = true;
            this.c_surname_company.Width = 150;
            // 
            // c_first_names
            // 
            this.c_first_names.DataPropertyName = "CFirstNames";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.c_first_names.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_first_names.HeaderText = "First Names";
            this.c_first_names.Name = "c_first_names";
            this.c_first_names.ReadOnly = true;
            this.c_first_names.Width = 139;
            // 
            // gross_pay
            // 
            this.gross_pay.DataPropertyName = "GrossPay";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.gross_pay.DefaultCellStyle = dataGridViewCellStyle5;
            this.gross_pay.HeaderText = "Gross Pay";
            this.gross_pay.Name = "gross_pay";
            this.gross_pay.ReadOnly = true;
            this.gross_pay.Width = 60;
            // 
            // gst
            // 
            this.gst.DataPropertyName = "Gst";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.gst.DefaultCellStyle = dataGridViewCellStyle6;
            this.gst.HeaderText = "GST";
            this.gst.Name = "gst";
            this.gst.ReadOnly = true;
            this.gst.Width = 60;
            // 
            // tax
            // 
            this.tax.DataPropertyName = "Tax";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.tax.DefaultCellStyle = dataGridViewCellStyle7;
            this.tax.HeaderText = "Tax";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            this.tax.Width = 60;
            // 
            // post_tax_adjustments
            // 
            this.post_tax_adjustments.DataPropertyName = "PostTaxAdjustments";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.post_tax_adjustments.DefaultCellStyle = dataGridViewCellStyle8;
            this.post_tax_adjustments.HeaderText = "Post Tax Adjustments";
            this.post_tax_adjustments.Name = "post_tax_adjustments";
            this.post_tax_adjustments.ReadOnly = true;
            this.post_tax_adjustments.Width = 105;
            // 
            // net_pay
            // 
            this.net_pay.DataPropertyName = "NetPay";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.net_pay.DefaultCellStyle = dataGridViewCellStyle9;
            this.net_pay.HeaderText = "Net Pay";
            this.net_pay.Name = "net_pay";
            this.net_pay.ReadOnly = true;
            // 
            // contract_pay
            // 
            this.contract_pay.DataPropertyName = "ContractPay";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.contract_pay.DefaultCellStyle = dataGridViewCellStyle10;
            this.contract_pay.HeaderText = "Contract Pay";
            this.contract_pay.Name = "contract_pay";
            this.contract_pay.ReadOnly = true;
            // 
            // DwPayrunNegativepay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Name = "DwPayrunNegativepay";
            this.Size = new System.Drawing.Size(859, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn contract_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_surname_company;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_first_names;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn gst;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_tax_adjustments;
        private System.Windows.Forms.DataGridViewTextBoxColumn net_pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_pay;

    }
}
