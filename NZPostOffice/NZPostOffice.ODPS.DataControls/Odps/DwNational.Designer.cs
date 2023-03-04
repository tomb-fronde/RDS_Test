namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwNational
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Metex.Windows.DataGridViewEntityComboColumn ac_id;
        //private System.Windows.Forms.DataGridViewComboBoxColumn ac_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nat_ird_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn nat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nat_effective_date;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.National);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Gray;
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
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
            //
            // nat_id
            //
            nat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nat_id.DataPropertyName = "NatId";
            this.nat_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nat_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.nat_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_id.HeaderText = "National Id";
            this.nat_id.Name = "nat_id";
            this.nat_id.ReadOnly = true;
            this.nat_id.Width = 87;
            this.nat_id.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(nat_id);

            //
            // ac_id
            //
            ac_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.ac_id.DataPropertyName = "AcId";
            this.ac_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ac_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ac_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ac_id.HeaderText = "Account";
            this.ac_id.Name = "dddw_account_id";
            this.ac_id.Width = 293;
            this.ac_id.ReadOnly = true;
            this.ac_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ac_id.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ac_id.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(ac_id);

            //
            // nat_effective_date
            //
            nat_effective_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nat_effective_date.DataPropertyName = "NatEffectiveDate";
            this.nat_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nat_effective_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.nat_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_effective_date.HeaderText = "Effective Date";
            this.nat_effective_date.Name = "nat_effective_date";
            this.nat_effective_date.ReadOnly = true;
            this.nat_effective_date.Width = 87;
            this.nat_effective_date.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(nat_effective_date);

            //
            // nat_ird_no
            //
            nat_ird_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nat_ird_no.DataPropertyName = "NatIrdNo";
            this.nat_ird_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nat_ird_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ird_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.nat_ird_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ird_no.HeaderText = "IRD No";
            this.nat_ird_no.Name = "nat_ird_no";
            this.nat_ird_no.ReadOnly = true;
            this.nat_ird_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nat_ird_no.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(nat_ird_no);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.Controls.Add(grid);
        }
        #endregion

    }
}

