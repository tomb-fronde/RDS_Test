namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwPaymentComponentType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Metex.Windows.DataGridViewEntityComboColumn pcg_id;
        private Metex.Windows.DataGridViewEntityComboColumn ac_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pct_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn pct_witholding_tax_status;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType);

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
            //?this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
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
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;

            //
            // ac_id
            //
            ac_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.ac_id.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ac_id.DataPropertyName = "AcId";
            this.ac_id.ValueMember = "AcId";
            this.ac_id.DisplayMember = "AcDescription";
            this.ac_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ac_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ac_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ac_id.HeaderText = "Account";
            this.ac_id.Name = "dddw_account_id";
            this.ac_id.Width = 171;
            this.ac_id.DropDownWidth = 256;
            this.ac_id.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.Columns.Add(ac_id);


            //
            // pct_description
            //
            pct_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pct_description.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pct_description.DataPropertyName = "PctDescription";
            this.pct_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pct_description.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.pct_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pct_description.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.pct_description.HeaderText = "Description";
            this.pct_description.Name = "pct_description";
            this.pct_description.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pct_description.Width = 240;
            this.grid.Columns.Add(pct_description);


            ////
            //// pct_witholding_tax_status
            ////
            //pct_witholding_tax_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.pct_witholding_tax_status.DataPropertyName = "PctWitholdingTaxStatus";
            //this.pct_witholding_tax_status.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.pct_witholding_tax_status.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            //this.pct_witholding_tax_status.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //this.pct_witholding_tax_status.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            //this.pct_witholding_tax_status.HeaderText = "Tax Status";
            //this.pct_witholding_tax_status.Name = "pct_witholding_tax_status";
            //this.pct_witholding_tax_status.ReadOnly = true;
            //this.pct_witholding_tax_status.Width = 65;
            //this.grid.Columns.Add(pct_witholding_tax_status);


            //
            // pcg_id
            //
            pcg_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.pcg_id.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pcg_id.DataPropertyName = "PcgId";
            this.pcg_id.ValueMember = "PcgId";
            this.pcg_id.DisplayMember = "PcgDescription";
            this.pcg_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.pcg_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pcg_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.pcg_id.HeaderText = "Group";
            this.pcg_id.Name = "dw_payment_component_group";
            this.pcg_id.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pcg_id.Width = 143;
            this.grid.Columns.Add(pcg_id);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.ColorTranslator.FromWin32(82439147);
            this.Controls.Add(grid);
        }
        #endregion

    }
}
