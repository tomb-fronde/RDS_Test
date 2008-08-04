namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DwAllPostTaxDeductions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn ded_end_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ded_reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ded_start_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ded_id;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;
        private System.Windows.Forms.Label st_contractor;
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            this.st_contractor = new System.Windows.Forms.Label();
            st_contractor.Font = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            st_contractor.Text = "Owner Driver:";
            st_contractor.Location = new System.Drawing.Point(2, 0);
            st_contractor.Size = new System.Drawing.Size(537, 14);
            st_contractor.BorderStyle = System.Windows.Forms.BorderStyle.None;


            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AllPostTaxDeductions);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 15);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 25);
            this.grid.TabIndex = 0;

            //
            // ded_id
            //
            ded_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_id.DataPropertyName = "DedId";
            this.ded_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ded_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ded_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_id.HeaderText = "ID";
            this.ded_id.Name = "ded_id";
            this.ded_id.ReadOnly = true;
            this.ded_id.Width = 50;
            this.grid.Columns.Add(ded_id);


            //
            // ded_reference
            //
            ded_reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_reference.DataPropertyName = "DedReference";
            this.ded_reference.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ded_reference.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_reference.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ded_reference.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_reference.HeaderText = "Reference";
            this.ded_reference.Name = "ded_reference";
            this.ded_reference.ReadOnly = true;
            // this.ded_reference.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ded_reference.Width = 288;
            this.ded_reference.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.Columns.Add(ded_reference);


            //
            // ded_start_balance
            //
            ded_start_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_start_balance.DataPropertyName = "DedStartBalance";
            this.ded_start_balance.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ded_start_balance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ded_start_balance.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_start_balance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ded_start_balance.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_start_balance.DefaultCellStyle.Format = "###,###.00";
            this.ded_start_balance.HeaderText = "Total Amount";
            this.ded_start_balance.Name = "ded_start_balance";
            this.ded_start_balance.ReadOnly = true;
            this.ded_start_balance.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ded_start_balance.Width = 89;
            this.grid.Columns.Add(ded_start_balance);


            //
            // ded_end_balance
            //
            ded_end_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_end_balance.DataPropertyName = "DedEndBalance";
            this.ded_end_balance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ded_end_balance.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_end_balance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ded_end_balance.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_end_balance.DefaultCellStyle.Format = "###,###.00";
            this.ded_end_balance.HeaderText = "Ending Balance";
            this.ded_end_balance.Name = "ded_end_balance";
            this.ded_end_balance.ReadOnly = true;
            this.ded_end_balance.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ded_end_balance.Width = 89;
            this.grid.Columns.Add(ded_end_balance);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 250);
            // this.AutoScroll = true;
            this.Controls.Add(grid);
            this.Controls.Add(st_contractor);
            this.SizeChanged += new System.EventHandler(DwAllPostTaxDeductions_SizeChanged);
        }
        void DwAllPostTaxDeductions_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left - 3;
            this.grid.Height = this.Height - this.grid.Top - 3;
        }
        #endregion

    }
}
