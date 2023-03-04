namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwInvoiceInterfaceHeader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn procdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn nat_rural_post_gst_no;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.InvoiceInterfaceHeader);

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
            // procdate
            //
            procdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procdate.DataPropertyName = "Procdate";
            this.procdate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.procdate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.procdate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.procdate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.procdate.HeaderText = "Procdate";
            this.procdate.Name = "procdate";
            this.procdate.ReadOnly = true;
            this.procdate.Width = 72;
            this.grid.Columns.Add(procdate);


            //
            // nat_rural_post_gst_no
            //
            nat_rural_post_gst_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nat_rural_post_gst_no.DataPropertyName = "NatRuralPostGstNo";
            this.nat_rural_post_gst_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nat_rural_post_gst_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.nat_rural_post_gst_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.nat_rural_post_gst_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.nat_rural_post_gst_no.HeaderText = "Nat Rural Post Gst No";
            this.nat_rural_post_gst_no.Name = "nat_rural_post_gst_no";
            this.nat_rural_post_gst_no.ReadOnly = true;
            this.nat_rural_post_gst_no.Width = 130;
            this.grid.Columns.Add(nat_rural_post_gst_no);

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
