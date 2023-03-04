namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwAcceptRejectMainrunGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_0001;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_0002;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_0003;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_0004;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_0005;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.AcceptRejectMainrunGrid);
            this.RetrieveEnd += new System.EventHandler(DwAcceptRejectMainrunGrid_RetrieveEnd);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F,System.Drawing.FontStyle.Bold);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.grid.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Grid_CellPainting);            
            this.grid.BackgroundColor = System.Drawing.Color.White;

            //
            // contract_no
            //
            contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_no.DataPropertyName = "ContractNo";
            this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contract_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no.HeaderText = "Contract No";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Width = 98;
            this.grid.Columns.Add(contract_no);

            //
            // compute_0001
            //
            compute_0001 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_0001.DataPropertyName = "Compute0001";
            this.compute_0001.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.compute_0001.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.compute_0001.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_0001.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_0001.HeaderText = "Owner-Driver";
            this.compute_0001.Name = "compute_0001";
            this.compute_0001.ReadOnly = true;
            this.compute_0001.Width = 175;
            this.grid.Columns.Add(compute_0001);

            //
            // compute_0002
            //
            compute_0002 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_0002.DataPropertyName = "Compute0002";
            this.compute_0002.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.compute_0002.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.compute_0002.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_0002.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            //!this.compute_0002.DefaultCellStyle.Format = "#,##0.00;[RED](#,##0.00)";
            this.compute_0002.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
            this.compute_0002.HeaderText = "Gross Pay";
            this.compute_0002.Name = "compute_0002";
            this.compute_0002.ReadOnly = true;
            this.compute_0002.Width = 90;
            this.grid.Columns.Add(compute_0002);

            //
            // compute_0003
            //
            compute_0003 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_0003.DataPropertyName = "Compute0003";
            this.compute_0003.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.compute_0003.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.compute_0003.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_0003.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            //!this.compute_0003.DefaultCellStyle.Format = "#,##0.00;[RED](#,##0.00)";
            this.compute_0003.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
            this.compute_0003.HeaderText = "Tax";
            this.compute_0003.Name = "compute_0003";
            this.compute_0003.ReadOnly = true;
            this.compute_0003.Width = 70;
            this.grid.Columns.Add(compute_0003);

            //
            // compute_0004
            //
            compute_0004 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_0004.DataPropertyName = "Compute0004";
            this.compute_0004.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.compute_0004.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.compute_0004.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_0004.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            //!this.compute_0004.DefaultCellStyle.Format = "#,##0.00;[RED](#,##0.00)";
            this.compute_0004.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
            this.compute_0004.HeaderText = "GST";
            this.compute_0004.Name = "compute_0004";
            this.compute_0004.ReadOnly = true;
            this.compute_0004.Width = 70;
            this.grid.Columns.Add(compute_0004);

            //
            // compute_0005
            //
            compute_0005 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_0005.DataPropertyName = "Compute0005";
            this.compute_0005.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.compute_0005.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.compute_0005.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_0005.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            //!this.compute_0005.DefaultCellStyle.Format = "#,##0.00;[RED](#,##0.00)";
            this.compute_0005.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
            this.compute_0005.HeaderText = "Deductions";
            this.compute_0005.Name = "compute_0005";
            this.compute_0005.ReadOnly = true;
            this.compute_0005.Width = 71;
            this.grid.Columns.Add(compute_0005);

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
