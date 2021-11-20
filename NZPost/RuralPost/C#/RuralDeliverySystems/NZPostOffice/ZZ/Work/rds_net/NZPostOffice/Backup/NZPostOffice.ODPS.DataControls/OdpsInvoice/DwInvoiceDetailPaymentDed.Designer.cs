namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceDetailPaymentDed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcd_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ded_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcd_amount;
        private System.Windows.Forms.Label rowcount;


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
            // rowcount
            //
            rowcount = new System.Windows.Forms.Label();
            this.rowcount.Location = new System.Drawing.Point(499,35);
            this.rowcount.Size = new System.Drawing.Size(64, 15);
            this.rowcount.Visible = false;
            this.rowcount.Name = "rowcount";
            this.rowcount.Width = 56;
            this.Controls.Add(rowcount);

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceDetailPaymentDed);
            //
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
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.TabIndex = 0;
            this.RetrieveEnd+=new System.EventHandler(DwInvoiceDetailPaymentDed_RetrieveEnd);

            //
            // pcd_date
            //
            pcd_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcd_date.DataPropertyName = "PcdDate";
            this.pcd_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pcd_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pcd_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pcd_date.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.pcd_date.HeaderText = "Date";
            this.pcd_date.Name = "pcd_date";
            this.pcd_date.ReadOnly = true;
            this.pcd_date.Width = 80;
            this.pcd_date.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(pcd_date);


            //
            // ded_description
            //
            ded_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_description.DataPropertyName = "DedDescription";
            this.ded_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ded_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ded_description.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.ded_description.HeaderText = "Reason";
            this.ded_description.Name = "ded_description";
            this.ded_description.ReadOnly = true;
            this.ded_description.Width = 171;
            this.ded_description.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(ded_description);


            //
            // pcd_amount
            //
            pcd_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcd_amount.DataPropertyName = "PcdAmount";
            this.pcd_amount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pcd_amount.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pcd_amount.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pcd_amount.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.pcd_amount.HeaderText = "Value";
            this.pcd_amount.Name = "pcd_amount";
            this.pcd_amount.ReadOnly = true;
            this.pcd_amount.Width = 60;
            this.grid.Columns.Add(pcd_amount);

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
