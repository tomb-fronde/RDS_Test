namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwIr13InterfaceHeader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_of_organisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn gst;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_of_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn rural_post_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn rural_post_gst_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_of_printing;
        private System.Windows.Forms.DataGridViewTextBoxColumn trading_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_of_payer;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Ir13InterfaceHeader);

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
            // name_of_organisation
            //
            name_of_organisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_of_organisation.DataPropertyName = "NameOfOrganisation";
            this.name_of_organisation.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name_of_organisation.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.name_of_organisation.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.name_of_organisation.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.name_of_organisation.HeaderText = "Name Of Organisation";
            this.name_of_organisation.Name = "name_of_organisation";
            this.name_of_organisation.ReadOnly = true;
            this.name_of_organisation.Width = 128;
            this.grid.Columns.Add(name_of_organisation);


            //
            // trading_name
            //
            trading_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trading_name.DataPropertyName = "TradingName";
            this.trading_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.trading_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.trading_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.trading_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.trading_name.HeaderText = "Trading Name";
            this.trading_name.Name = "trading_name";
            this.trading_name.ReadOnly = true;
            this.trading_name.Width = 80;
            this.grid.Columns.Add(trading_name);


            //
            // type_of_service
            //
            type_of_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_of_service.DataPropertyName = "TypeOfService";
            this.type_of_service.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.type_of_service.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.type_of_service.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.type_of_service.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.type_of_service.HeaderText = "Type Of Service";
            this.type_of_service.Name = "type_of_service";
            this.type_of_service.ReadOnly = true;
            this.type_of_service.Width = 150;
            this.grid.Columns.Add(type_of_service);


            //
            // gst
            //
            gst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gst.DataPropertyName = "Gst";
            this.gst.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gst.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gst.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gst.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.gst.HeaderText = "Gst";
            this.gst.Name = "gst";
            this.gst.ReadOnly = true;
            this.gst.Width = 25;
            this.grid.Columns.Add(gst);


            //
            // rural_post_gst_number
            //
            rural_post_gst_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rural_post_gst_number.DataPropertyName = "RuralPostGstNumber";
            this.rural_post_gst_number.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rural_post_gst_number.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.rural_post_gst_number.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rural_post_gst_number.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.rural_post_gst_number.HeaderText = "Rural Post Gst Number";
            this.rural_post_gst_number.Name = "rural_post_gst_number";
            this.rural_post_gst_number.ReadOnly = true;
            this.rural_post_gst_number.Width = 135;
            this.grid.Columns.Add(rural_post_gst_number);


            //
            // rural_post_address
            //
            rural_post_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rural_post_address.DataPropertyName = "RuralPostAddress";
            this.rural_post_address.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rural_post_address.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.rural_post_address.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rural_post_address.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.rural_post_address.HeaderText = "Rural Post Address";
            this.rural_post_address.Name = "rural_post_address";
            this.rural_post_address.ReadOnly = true;
            this.rural_post_address.Width = 353;
            this.grid.Columns.Add(rural_post_address);


            //
            // name_of_payer
            //
            name_of_payer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_of_payer.DataPropertyName = "NameOfPayer";
            this.name_of_payer.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name_of_payer.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.name_of_payer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.name_of_payer.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.name_of_payer.HeaderText = "Name Of Payer";
            this.name_of_payer.Name = "name_of_payer";
            this.name_of_payer.ReadOnly = true;
            this.name_of_payer.Width = 228;
            this.grid.Columns.Add(name_of_payer);


            //
            // date_of_printing
            //
            date_of_printing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_of_printing.DataPropertyName = "DateOfPrinting";
            this.date_of_printing.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.date_of_printing.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.date_of_printing.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.date_of_printing.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.date_of_printing.HeaderText = "Date Of Printing";
            this.date_of_printing.Name = "date_of_printing";
            this.date_of_printing.ReadOnly = true;
            this.date_of_printing.Width = 100;
            this.date_of_printing.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.Columns.Add(date_of_printing);

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
