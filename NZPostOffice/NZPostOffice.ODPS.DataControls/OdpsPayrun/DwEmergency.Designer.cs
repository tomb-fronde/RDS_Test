namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwEmergency
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_witholding_tax_rate_applied;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_invoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_invoice_date;
        private Metex.Windows.DataGridViewEntityComboColumn payment_component_pct_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_component_pc_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_component_comments;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.Emergency);

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
            this.grid.ColumnHeadersHeight = 38;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
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
            // payment_component_pc_amount
            //
            payment_component_pc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_component_pc_amount.DataPropertyName = "PaymentComponentPcAmount";
            this.payment_component_pc_amount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.payment_component_pc_amount.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.payment_component_pc_amount.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payment_component_pc_amount.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payment_component_pc_amount.HeaderText = "Tax Rate Applied";
            this.payment_component_pc_amount.Name = "payment_component_pc_amount";
            this.payment_component_pc_amount.Width = 82;
            this.grid.Columns.Add(payment_component_pc_amount);

            //
            // payment_component_comments
            //
            payment_component_comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_component_comments.DataPropertyName = "PaymentComponentComments";
            this.payment_component_comments.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.payment_component_comments.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.payment_component_comments.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payment_component_comments.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payment_component_comments.HeaderText = "Comments";
            this.payment_component_comments.Name = "payment_component_comments";
            this.payment_component_comments.ReadOnly = true;
            this.payment_component_comments.Width = 190;
            this.grid.Columns.Add(payment_component_comments);

            //
            // payment_invoice_no
            //
            payment_invoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_invoice_no.DataPropertyName = "PaymentInvoiceNo";
            this.payment_invoice_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.payment_invoice_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.payment_invoice_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payment_invoice_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payment_invoice_no.HeaderText = "Invoice Series No";
            this.payment_invoice_no.Name = "payment_invoice_no";
            this.payment_invoice_no.ReadOnly = true;
            this.payment_invoice_no.Width = 84;
            this.grid.Columns.Add(payment_invoice_no);

            //
            // payment_witholding_tax_rate_applied
            //
            payment_witholding_tax_rate_applied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_witholding_tax_rate_applied.DataPropertyName = "PaymentWitholdingTaxRateApplied";
            this.payment_witholding_tax_rate_applied.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.payment_witholding_tax_rate_applied.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.payment_witholding_tax_rate_applied.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payment_witholding_tax_rate_applied.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payment_witholding_tax_rate_applied.HeaderText = "Tax Rate Applied";
            this.payment_witholding_tax_rate_applied.Name = "payment_witholding_tax_rate_applied";
            this.payment_witholding_tax_rate_applied.ReadOnly = true;
            this.payment_witholding_tax_rate_applied.Width = 82;
            this.grid.Columns.Add(payment_witholding_tax_rate_applied);

            //
            // payment_invoice_date
            //
            payment_invoice_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_invoice_date.DataPropertyName = "PaymentInvoiceDate";
            this.payment_invoice_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.payment_invoice_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.payment_invoice_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payment_invoice_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payment_invoice_date.HeaderText = "Invoice Date";
            this.payment_invoice_date.Name = "payment_invoice_date";
            this.payment_invoice_date.ReadOnly = true;
            this.payment_invoice_date.Width = 60;
            this.grid.Columns.Add(payment_invoice_date);

            //
            // payment_component_pct_id
            //
            payment_component_pct_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.payment_component_pct_id.ValueMember = "PctId";
            this.payment_component_pct_id.DisplayMember = "PctDescription";
            this.payment_component_pct_id.DataPropertyName = "PaymentComponentPctId";
            this.payment_component_pct_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.payment_component_pct_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payment_component_pct_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payment_component_pct_id.HeaderText = "Payment Component Type";
            this.payment_component_pct_id.Name = "d_dddw_payment_components";
            this.payment_component_pct_id.Width = 155;
            this.grid.Columns.Add(payment_component_pct_id);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.Controls.Add(grid);
        }
        #endregion

    }
}
