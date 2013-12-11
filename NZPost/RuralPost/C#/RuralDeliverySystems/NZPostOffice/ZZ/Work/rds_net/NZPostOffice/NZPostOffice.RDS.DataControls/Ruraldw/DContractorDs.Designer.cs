namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractorDs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn cd_old_ds_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_no;
        private System.Windows.Forms.Label t_1;

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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractorDs);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 15);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(500,245);
            this.grid.TabIndex = 0;
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);//added by ylwang
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Controls.Add(grid);

            //
            // cd_old_ds_no
            //
            cd_old_ds_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cd_old_ds_no.DataPropertyName = "CdOldDsNo";
            //this.cd_old_ds_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cd_old_ds_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.cd_old_ds_no.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.cd_old_ds_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cd_old_ds_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.cd_old_ds_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.cd_old_ds_no.HeaderText = "Owner Driver's DS Numbers";
            this.cd_old_ds_no.HeaderText = "Old DS Number";
            this.cd_old_ds_no.Name = "cd_old_ds_no";
            this.cd_old_ds_no.Width = 180;
            this.cd_old_ds_no.DefaultCellStyle.Format = "??????????";
            this.cd_old_ds_no.MaxInputLength = 10;
            this.cd_old_ds_no.ReadOnly = false;
            this.grid.Columns.Add(cd_old_ds_no);

            //
            // supplier_no
            //
            supplier_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier_no.DataPropertyName = "SupplierNo";
            //this.supplier_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.supplier_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.supplier_no.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.supplier_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.supplier_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.supplier_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.supplier_no.HeaderText = "Supplier Number";
            this.supplier_no.MinimumWidth = 5;
            this.supplier_no.Name = "supplier_no";
            this.supplier_no.Width = 180;
            this.supplier_no.DefaultCellStyle.Format = "????????";
            this.supplier_no.MaxInputLength = 8;
            this.supplier_no.ReadOnly = false;
            this.grid.Columns.Add(supplier_no);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(1, 1);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(500, 14);
            this.t_1.Text = "";
            this.t_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_1);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(500, 245);
            this.BackColor = System.Drawing.SystemColors.Control;
            
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(DContractorDs_EditChanged);
        }

        void DContractorDs_EditChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (this.RowCount < 0)
                return;
            
            ((System.Windows.Forms.TextBox)grid.EditingControl).CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            
        }
        #endregion

    }
}
