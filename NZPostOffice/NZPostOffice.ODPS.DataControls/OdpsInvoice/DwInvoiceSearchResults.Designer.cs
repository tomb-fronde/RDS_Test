namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceSearchResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_first_names;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceSearchResults);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // contract_no
            //
            contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_no.DataPropertyName = "ContractNo";
            this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.contract_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no.HeaderText = "Contract";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Width = 60;
            this.grid.Columns.Add(contract_no);


            //
            // c_first_names
            //
            c_first_names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_first_names.DataPropertyName = "CFirstNames";
            this.c_first_names.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.c_first_names.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.c_first_names.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.c_first_names.HeaderText = "Owner Driver";
            this.c_first_names.Name = "c_first_names";
            this.c_first_names.ReadOnly = true;
            this.c_first_names.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_first_names.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.Columns.Add(c_first_names);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.Controls.Add(grid);
        }
        #endregion

    }
}
