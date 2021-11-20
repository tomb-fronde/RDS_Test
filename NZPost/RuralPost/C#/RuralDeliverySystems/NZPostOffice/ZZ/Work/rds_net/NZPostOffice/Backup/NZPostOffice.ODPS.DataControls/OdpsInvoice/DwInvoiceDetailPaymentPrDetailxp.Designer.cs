namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceDetailPaymentPrDetailxp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn prt_code;
        private System.Windows.Forms.Label rowcount;
        private System.Windows.Forms.Label t_1;

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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceDetailPaymentPrDetailxp);

            //
            //t_1
            //
            t_1 = new System.Windows.Forms.Label();
            this.t_1.Name = "t_1";
            this.t_1.Text = "SKYROAD";
            this.t_1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.t_1.BackColor = System.Drawing.SystemColors.Window;
            this.t_1.Location = new System.Drawing.Point(0, 0);
            this.t_1.Size = new System.Drawing.Size(400, 23);
            this.Controls.Add(t_1);
            //
            // rowcount
            //
            rowcount = new System.Windows.Forms.Label();
            this.rowcount.Name = "rowcount";
            this.rowcount.Location = new System.Drawing.Point(400, 55);
            this.rowcount.Size = new System.Drawing.Size(64, 15);
            this.rowcount.Visible = false;
            this.rowcount.Width = 92;
            this.Controls.Add(rowcount);

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
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 23);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.ColumnHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid.Size = new System.Drawing.Size(400, 252);
            this.grid.TabIndex = 0;
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(grid_CellPainting);

            //
            // prd_date
            //
            prd_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_date.DataPropertyName = "PrdDate";
            this.prd_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.prd_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prd_date.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.prd_date.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.prd_date.HeaderText = "SKYROAD";
            this.prd_date.Name = "prd_date";
            this.prd_date.ReadOnly = true;
            this.prd_date.Width = 74;
            this.grid.Columns.Add(prd_date);


            //
            // prt_code
            //
            prt_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prt_code.DataPropertyName = "PrtCode";
            this.prt_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.prt_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prt_code.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.prt_code.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.prt_code.HeaderText = "SKYROAD";
            this.prt_code.Name = "prt_code";
            this.prt_code.ReadOnly = true;
            this.prt_code.Width = 82;
            this.grid.Columns.Add(prt_code);


            //
            // prd_quantity
            //
            prd_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_quantity.DataPropertyName = "PrdQuantity";
            this.prd_quantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.prd_quantity.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prd_quantity.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.prd_quantity.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.prd_quantity.DefaultCellStyle.Format = "#,##0";
            this.prd_quantity.HeaderText = "SKYROAD";
            this.prd_quantity.Name = "prd_quantity";
            this.prd_quantity.ReadOnly = true;
            this.prd_quantity.Width = 76;
            this.grid.Columns.Add(prd_quantity);


            //
            // rate
            //
            rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate.DataPropertyName = "Rate";
            this.rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.rate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.rate.DefaultCellStyle.Format = "##0.000";
            this.rate.HeaderText = "SKYROAD";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Width = 76;
            this.grid.Columns.Add(rate);


            //
            // cost
            //
            cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost.DataPropertyName = "Cost";
            this.cost.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cost.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cost.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cost.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.cost.DefaultCellStyle.Format = "#,##0.00";
            this.cost.HeaderText = "SKYROAD";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Width = 88;
            this.grid.Columns.Add(cost);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RetrieveEnd += new System.EventHandler(DwInvoiceDetailPaymentPrDetailxp_RetrieveEnd);
            this.Controls.Add(grid);
        }
        #endregion

    }
}
