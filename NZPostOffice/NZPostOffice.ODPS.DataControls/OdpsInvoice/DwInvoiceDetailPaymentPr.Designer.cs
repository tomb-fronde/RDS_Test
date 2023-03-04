namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceDetailPaymentPr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prs_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn in_date;
        private System.Windows.Forms.Label rowcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn pvalue;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceDetailPaymentPr);

            //
            // rowcount
            //
            rowcount = new System.Windows.Forms.Label();
            this.rowcount.Location = new System.Drawing.Point(499, 35);
            this.rowcount.Size = new System.Drawing.Size(64, 15);
            this.rowcount.Visible = false;
            this.rowcount.Name = "rowcount";
            this.rowcount.Width = 56;
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
            this.RetrieveEnd += new System.EventHandler(DwInvoiceDetailPaymentPr_RetrieveEnd);

            //
            // in_date
            //
            in_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.in_date.DataPropertyName = "InDate";
            this.in_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.in_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.in_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.in_date.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.in_date.HeaderText = "Date";
            this.in_date.Name = "in_date";
            this.in_date.ReadOnly = true;
            this.in_date.Width = 80;
            this.in_date.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(in_date);


            //
            // prs_description
            //
            prs_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prs_description.DataPropertyName = "PrsDescription";
            this.prs_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prs_description.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.prs_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prs_description.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.prs_description.HeaderText = "Reason";
            this.prs_description.Name = "prs_description";
            this.prs_description.ReadOnly = true;
            this.prs_description.Width = 171;
            this.prs_description.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(prs_description);


            //
            // pvalue
            //
            pvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvalue.DataPropertyName = "Pvalue";
            this.pvalue.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pvalue.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pvalue.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pvalue.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.pvalue.HeaderText = "Value";
            this.pvalue.Name = "pvalue";
            this.pvalue.ReadOnly = true;
            this.pvalue.Width = 60;
            this.grid.Columns.Add(pvalue);

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
