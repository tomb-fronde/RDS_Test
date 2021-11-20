namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DQsContractorList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractor_supplier_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractor_name;
        private System.Windows.Forms.Label contractor_supplier_no_t;
        private System.Windows.Forms.Label c_surname_company_t;

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
            this.contractor_supplier_no_t = new System.Windows.Forms.Label();
            this.c_surname_company_t = new System.Windows.Forms.Label();
            grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.QsContractorList);

            // 
            // contractor_supplier_no_t
            // 
            this.contractor_supplier_no_t.BackColor = System.Drawing.SystemColors.Control;
            this.contractor_supplier_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_supplier_no_t.Location = new System.Drawing.Point(3, 3);
            this.contractor_supplier_no_t.Name = "t_1";
            this.contractor_supplier_no_t.Size = new System.Drawing.Size(65, 17);
            this.contractor_supplier_no_t.TabIndex = 0;
            this.contractor_supplier_no_t.Text = "Supplier No";
            // 
            // c_surname_company_t
            // 
            this.c_surname_company_t.BackColor = System.Drawing.SystemColors.Control;
            this.c_surname_company_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_surname_company_t.Location = new System.Drawing.Point(70, 3);
            this.c_surname_company_t.Name = "t_2";
            this.c_surname_company_t.Size = new System.Drawing.Size(70, 17);
            this.c_surname_company_t.TabIndex = 0;
            this.c_surname_company_t.Text = "Owner Driver";

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.grid.Location = new System.Drawing.Point(0, 34);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // contractor_supplier_no
            //
            contractor_supplier_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractor_supplier_no.DataPropertyName = "ContractorSupplierNo";
            this.contractor_supplier_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.contractor_supplier_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_supplier_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contractor_supplier_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.contractor_supplier_no.HeaderText = "";
            this.contractor_supplier_no.Name = "contractor_supplier_no";
            this.contractor_supplier_no.ReadOnly = true;
            this.contractor_supplier_no.Width = 74;
            this.grid.Columns.Add(contractor_supplier_no);


            //
            // contractor_name
            //
            contractor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractor_name.DataPropertyName = "ContractorName";
            this.contractor_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contractor_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contractor_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.contractor_name.HeaderText = "";
            this.contractor_name.Name = "contractor_name";
            this.contractor_name.Width = 232;
            this.contractor_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid.Columns.Add(contractor_name);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
            this.Controls.Add(this.contractor_supplier_no_t);
            this.Controls.Add(this.c_surname_company_t);
            this.Controls.Add(grid);
        }
        #endregion

    }
}