namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwIr13InterfaceDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_driver_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_driver_ird_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_driver_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner_driver_gst_number;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Ir13InterfaceDetail);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
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
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // owner_driver_ird_number
            //
            owner_driver_ird_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_driver_ird_number.DataPropertyName = "OwnerDriverIrdNumber";
            this.owner_driver_ird_number.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.owner_driver_ird_number.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.owner_driver_ird_number.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.owner_driver_ird_number.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.owner_driver_ird_number.HeaderText = "Owner Driver Ird Number";
            this.owner_driver_ird_number.Name = "owner_driver_ird_number";
            this.owner_driver_ird_number.ReadOnly = true;
            this.owner_driver_ird_number.Width = 140;
            this.grid.Columns.Add(owner_driver_ird_number);


            //
            // owner_driver_name
            //
            owner_driver_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_driver_name.DataPropertyName = "OwnerDriverName";
            this.owner_driver_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.owner_driver_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.owner_driver_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.owner_driver_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.owner_driver_name.HeaderText = "Owner Driver Name";
            this.owner_driver_name.Name = "owner_driver_name";
            this.owner_driver_name.ReadOnly = true;
            this.owner_driver_name.Width = 314;
            this.grid.Columns.Add(owner_driver_name);


            //
            // owner_driver_address
            //
            owner_driver_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_driver_address.DataPropertyName = "OwnerDriverAddress";
            this.owner_driver_address.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.owner_driver_address.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.owner_driver_address.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.owner_driver_address.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.owner_driver_address.HeaderText = "Owner Driver Address";
            this.owner_driver_address.Name = "owner_driver_address";
            this.owner_driver_address.ReadOnly = true;
            this.owner_driver_address.Width = 367;
            this.grid.Columns.Add(owner_driver_address);


            //
            // owner_driver_gst_number
            //
            owner_driver_gst_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner_driver_gst_number.DataPropertyName = "OwnerDriverGstNumber";
            this.owner_driver_gst_number.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.owner_driver_gst_number.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.owner_driver_gst_number.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.owner_driver_gst_number.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.owner_driver_gst_number.HeaderText = "Owner Driver Gst Number";
            this.owner_driver_gst_number.Name = "owner_driver_gst_number";
            this.owner_driver_gst_number.ReadOnly = true;
            this.owner_driver_gst_number.Width = 147;
            this.grid.Columns.Add(owner_driver_gst_number);


            //
            // contract_id
            //
            contract_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_id.DataPropertyName = "ContractId";
            this.contract_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.contract_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.contract_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contract_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.contract_id.HeaderText = "Contract Id";
            this.contract_id.Name = "contract_id";
            this.contract_id.ReadOnly = true;
            this.contract_id.Width = 72;
            this.grid.Columns.Add(contract_id);


            //
            // tax
            //
            tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax.DataPropertyName = "Tax";
            this.tax.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tax.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.tax.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tax.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.tax.HeaderText = "Tax";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            this.tax.Width = 72;
            this.grid.Columns.Add(tax);


            //
            // gross_pay
            //
            gross_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross_pay.DataPropertyName = "GrossPay";
            this.gross_pay.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gross_pay.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gross_pay.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gross_pay.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.gross_pay.HeaderText = "Gross Pay";
            this.gross_pay.Name = "gross_pay";
            this.gross_pay.ReadOnly = true;
            this.gross_pay.Width = 72;
            this.grid.Columns.Add(gross_pay);


            //
            // start_date
            //
            start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date.DataPropertyName = "StartDate";
            this.start_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.start_date.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.start_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.start_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.start_date.HeaderText = "Start Date";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Width = 100;
            this.grid.Columns.Add(start_date);


            //
            // end_date
            //
            end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date.DataPropertyName = "EndDate";
            this.end_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.end_date.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.end_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.end_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.end_date.HeaderText = "End Date";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            this.end_date.Width = 100;
            this.grid.Columns.Add(end_date);

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
