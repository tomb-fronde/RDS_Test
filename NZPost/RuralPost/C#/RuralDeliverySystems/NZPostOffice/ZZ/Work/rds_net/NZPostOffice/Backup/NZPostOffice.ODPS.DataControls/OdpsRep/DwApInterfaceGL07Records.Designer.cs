using NZPostOffice.ODPS.Entity.OdpsRep;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwApInterfaceGL07Records
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn interface_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn voucher_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn trans_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn client;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn dim_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dim_6;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn cur_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn pay_transfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn apar_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank_acc_type;

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
            this.grid = new Metex.Windows.DataEntityGrid();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interface_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trans_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dim_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dim_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cur_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pay_transfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apar_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank_acc_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.ApInterfaceGL07Records);
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
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batch_no,
            this.interface_code,
            this.trans_type,
            this.client,
            this.ac_code,
            this.dim_4,
            this.dim_6,
            this.tax_code,
            this.currency,
            this.cur_amount,
            this.invoice_date,
            this.invoice_no,
            this.pay_transfer,
            this.status,
            this.apar_type,
            this.supplier_no,
            this.bank_acc_type});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(759, 252);
            this.grid.TabIndex = 0;
            // 
            // batch_no
            // 
            this.batch_no.DataPropertyName = "BatchNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.batch_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.batch_no.HeaderText = "Batch No";
            this.batch_no.Name = "batch_no";
            this.batch_no.ReadOnly = true;
            // 
            // interface_code
            // 
            this.interface_code.DataPropertyName = "InterfaceCode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.interface_code.DefaultCellStyle = dataGridViewCellStyle3;
            this.interface_code.HeaderText = "Interface";
            this.interface_code.Name = "interface_code";
            this.interface_code.ReadOnly = true;
            this.interface_code.Width = 74;
            // 
            // trans_type
            // 
            this.trans_type.DataPropertyName = "TransType";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.trans_type.DefaultCellStyle = dataGridViewCellStyle4;
            this.trans_type.HeaderText = "Trans Type";
            this.trans_type.Name = "trans_type";
            this.trans_type.ReadOnly = true;
            this.trans_type.Width = 154;
            // 
            // client
            // 
            this.client.DataPropertyName = "Client";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.client.DefaultCellStyle = dataGridViewCellStyle5;
            this.client.HeaderText = "Client";
            this.client.Name = "client";
            this.client.ReadOnly = true;
            // 
            // ac_code
            // 
            this.ac_code.DataPropertyName = "AcCode";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.ac_code.DefaultCellStyle = dataGridViewCellStyle6;
            this.ac_code.HeaderText = "Account";
            this.ac_code.Name = "ac_code";
            this.ac_code.ReadOnly = true;
            this.ac_code.Width = 110;
            // 
            // dim_4
            // 
            this.dim_4.DataPropertyName = "Dim4";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dim_4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dim_4.HeaderText = "Dim 4";
            this.dim_4.Name = "dim_4";
            this.dim_4.ReadOnly = true;
            this.dim_4.Width = 59;
            // 
            // dim_6
            // 
            this.dim_6.DataPropertyName = "Dim6";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dim_6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dim_6.HeaderText = "Dim 6";
            this.dim_6.Name = "dim_6";
            this.dim_6.ReadOnly = true;
            this.dim_6.Width = 59;
            // 
            // tax_code
            // 
            this.tax_code.DataPropertyName = "TaxCode";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.tax_code.DefaultCellStyle = dataGridViewCellStyle9;
            this.tax_code.HeaderText = "Tax Code";
            this.tax_code.Name = "tax_code";
            this.tax_code.ReadOnly = true;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "Currency";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.currency.DefaultCellStyle = dataGridViewCellStyle10;
            this.currency.HeaderText = "Currency";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            this.currency.Width = 169;
            // 
            // cur_amount
            // 
            this.cur_amount.DataPropertyName = "CurAmount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.cur_amount.DefaultCellStyle = dataGridViewCellStyle11;
            this.cur_amount.HeaderText = "Amount";
            this.cur_amount.Name = "cur_amount";
            this.cur_amount.ReadOnly = true;
            // 
            // invoice_date
            // 
            this.invoice_date.DataPropertyName = "InvoiceDate";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.invoice_date.DefaultCellStyle = dataGridViewCellStyle12;
            this.invoice_date.HeaderText = "Invoice Date";
            this.invoice_date.Name = "invoice_date";
            this.invoice_date.ReadOnly = true;
            // 
            // invoice_no
            // 
            this.invoice_no.DataPropertyName = "InvoiceNo";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.invoice_no.DefaultCellStyle = dataGridViewCellStyle13;
            this.invoice_no.HeaderText = "Invoice No";
            this.invoice_no.Name = "invoice_no";
            this.invoice_no.ReadOnly = true;
            // 
            // pay_transfer
            // 
            this.pay_transfer.DataPropertyName = "PayTransfer";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.pay_transfer.DefaultCellStyle = dataGridViewCellStyle14;
            this.pay_transfer.HeaderText = "Pay Transfer";
            this.pay_transfer.Name = "pay_transfer";
            this.pay_transfer.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.status.DefaultCellStyle = dataGridViewCellStyle15;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // apar_type
            // 
            this.apar_type.DataPropertyName = "AparType";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.apar_type.DefaultCellStyle = dataGridViewCellStyle16;
            this.apar_type.HeaderText = "Apar Type";
            this.apar_type.Name = "apar_type";
            this.apar_type.ReadOnly = true;
            // 
            // supplier_no
            // 
            this.supplier_no.DataPropertyName = "SupplierNo";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            this.supplier_no.DefaultCellStyle = dataGridViewCellStyle17;
            this.supplier_no.HeaderText = "Supplier No";
            this.supplier_no.Name = "supplier_no";
            this.supplier_no.ReadOnly = true;
            // 
            // bank_acc_type
            // 
            this.bank_acc_type.DataPropertyName = "BankAccType";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.bank_acc_type.DefaultCellStyle = dataGridViewCellStyle18;
            this.bank_acc_type.HeaderText = "Bank Acc Type";
            this.bank_acc_type.Name = "bank_acc_type";
            this.bank_acc_type.ReadOnly = true;
            // 
            // DwApInterfaceGL07Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Name = "DwApInterfaceGL07Rows";
            this.Size = new System.Drawing.Size(759, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

    }
}
