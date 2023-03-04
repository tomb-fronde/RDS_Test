namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwInvoiceHeaderBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn cinvoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_gst_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_0011;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_title;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.InvoiceHeaderBackup);

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
            this.grid.TabIndex = 0;

            //
            // c_gst_number
            //
            c_gst_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_gst_number.DataPropertyName = "CGstNumber";
            this.c_gst_number.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.c_gst_number.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.c_gst_number.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.c_gst_number.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.c_gst_number.HeaderText = "Date";
            this.c_gst_number.Name = "c_gst_number";
            this.c_gst_number.ReadOnly = true;
            this.c_gst_number.Width = 141;
            this.grid.Columns.Add(c_gst_number);


            //
            // contract_no
            //
            contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_no.DataPropertyName = "ContractNo";
            this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contract_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.contract_no.HeaderText = "Date";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Width = 144;
            this.grid.Columns.Add(contract_no);


            //
            // ds_no
            //
            ds_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds_no.DataPropertyName = "DsNo";
            this.ds_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ds_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ds_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ds_no.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.ds_no.HeaderText = "Date";
            this.ds_no.Name = "ds_no";
            this.ds_no.ReadOnly = true;
            this.ds_no.Width = 145;
            this.grid.Columns.Add(ds_no);


            //
            // con_title
            //
            con_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_title.DataPropertyName = "ConTitle";
            this.con_title.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.con_title.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.con_title.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.con_title.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.con_title.HeaderText = "For:";
            this.con_title.Name = "con_title";
            this.con_title.ReadOnly = true;
            this.con_title.Width = 302;
            this.grid.Columns.Add(con_title);


            //
            // cinvoice_no
            //
            cinvoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cinvoice_no.DataPropertyName = "CinvoiceNo";
            this.cinvoice_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cinvoice_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.cinvoice_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.cinvoice_no.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.cinvoice_no.HeaderText = "Value";
            this.cinvoice_no.Name = "cinvoice_no";
            this.cinvoice_no.ReadOnly = true;
            this.cinvoice_no.Width = 117;
            this.grid.Columns.Add(cinvoice_no);


            //
            // compute_0011
            //
            compute_0011 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_0011.DataPropertyName = "Compute0011";
            this.compute_0011.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.compute_0011.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.compute_0011.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_0011.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.compute_0011.HeaderText = "Contract No.";
            this.compute_0011.Name = "compute_0011";
            this.compute_0011.ReadOnly = true;
            this.compute_0011.Width = 655;
            this.grid.Columns.Add(compute_0011);


            //
            // c_address
            //
            c_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_address.DataPropertyName = "CAddress";
            this.c_address.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.c_address.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.c_address.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.c_address.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.c_address.HeaderText = "Contract No.";
            this.c_address.Name = "c_address";
            this.c_address.ReadOnly = true;
            this.c_address.Width = 396;
            this.grid.Columns.Add(c_address);

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
