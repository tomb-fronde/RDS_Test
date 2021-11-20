namespace NZPostOffice.ODPS.DataControls.OdpsLib
{
    partial class DTelecomImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_month;
        private System.Windows.Forms.DataGridViewTextBoxColumn account_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bal_bf;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn account_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn curr_chg;
        private System.Windows.Forms.DataGridViewTextBoxColumn adj_tran;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_due;
        private System.Windows.Forms.DataGridViewTextBoxColumn payments;
        private System.Windows.Forms.DataGridViewTextBoxColumn open_bal;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsLib.TelecomImport);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline)));
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
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.TabIndex = 0;

            //
            // bill_month
            //
            bill_month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_month.DataPropertyName = "BillMonth";
            this.bill_month.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bill_month.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.bill_month.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bill_month.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.bill_month.HeaderText = "Month";
            this.bill_month.Name = "bill_month";
            this.bill_month.ReadOnly = true;
            this.bill_month.Width = 60;
            this.grid.Columns.Add(bill_month);


            //
            // bill_cycle
            //
            bill_cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_cycle.DataPropertyName = "BillCycle";
            this.bill_cycle.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bill_cycle.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.bill_cycle.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bill_cycle.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.bill_cycle.HeaderText = "Code";
            this.bill_cycle.Name = "bill_cycle";
            this.bill_cycle.ReadOnly = true;
            this.bill_cycle.Width = 35;
            this.grid.Columns.Add(bill_cycle);


            //
            // cust_no
            //
            cust_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_no.DataPropertyName = "CustNo";
            this.cust_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cust_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.cust_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.cust_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_no.HeaderText = "Cust No";
            this.cust_no.Name = "cust_no";
            this.cust_no.ReadOnly = true;
            this.cust_no.Width = 62;
            this.grid.Columns.Add(cust_no);


            //
            // account_no
            //
            account_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account_no.DataPropertyName = "AccountNo";
            this.account_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.account_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.account_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.account_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.account_no.HeaderText = "Account No";
            this.account_no.Name = "account_no";
            this.account_no.ReadOnly = true;
            this.account_no.Width = 75;
            this.grid.Columns.Add(account_no);


            //
            // account_name
            //
            account_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account_name.DataPropertyName = "AccountName";
            this.account_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.account_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.account_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.account_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.account_name.HeaderText = "Name";
            this.account_name.Name = "account_name";
            this.account_name.ReadOnly = true;
            this.account_name.Width = 120;
            this.grid.Columns.Add(account_name);


            //
            // open_bal
            //
            open_bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open_bal.DataPropertyName = "OpenBal";
            this.open_bal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.open_bal.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.open_bal.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.open_bal.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.open_bal.HeaderText = "Open";
            this.open_bal.Name = "open_bal";
            this.open_bal.ReadOnly = true;
            this.open_bal.Width = 50;
            this.grid.Columns.Add(open_bal);


            //
            // payments
            //
            payments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payments.DataPropertyName = "Payments";
            this.payments.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.payments.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.payments.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payments.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payments.HeaderText = "Payments";
            this.payments.Name = "payments";
            this.payments.ReadOnly = true;
            this.payments.Width = 60;
            this.grid.Columns.Add(payments);

            //
            // adj_tran
            //
            adj_tran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adj_tran.DataPropertyName = "AdjTran";
            this.adj_tran.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.adj_tran.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.adj_tran.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.adj_tran.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.adj_tran.HeaderText = "Adj";
            this.adj_tran.Name = "adj_tran";
            this.adj_tran.ReadOnly = true;
            this.adj_tran.Width = 50;
            this.grid.Columns.Add(adj_tran);

            //
            // bal_bf
            //
            bal_bf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bal_bf.DataPropertyName = "BalBf";
            this.bal_bf.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bal_bf.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.bal_bf.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bal_bf.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.bal_bf.HeaderText = "Bal BF";
            this.bal_bf.Name = "bal_bf";
            this.bal_bf.ReadOnly = true;
            this.bal_bf.Width = 50;
            this.grid.Columns.Add(bal_bf);

            //
            // curr_chg
            //
            curr_chg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curr_chg.DataPropertyName = "CurrChg";
            this.curr_chg.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.curr_chg.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.curr_chg.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.curr_chg.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.curr_chg.HeaderText = "Current";
            this.curr_chg.Name = "curr_chg";
            this.curr_chg.ReadOnly = true;
            this.curr_chg.Width = 50;
            this.grid.Columns.Add(curr_chg);

            //
            // total_due
            //
            total_due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_due.DataPropertyName = "TotalDue";
            this.total_due.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.total_due.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.total_due.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_due.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.total_due.HeaderText = "Total";
            this.total_due.Name = "total_due";
            this.total_due.ReadOnly = true;
            this.total_due.Width = 50;
            this.total_due.DefaultCellStyle.Format = "###.00";
            this.grid.Columns.Add(total_due);

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
