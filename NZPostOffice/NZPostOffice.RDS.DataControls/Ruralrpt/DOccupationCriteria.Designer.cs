namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DOccupationCriteria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn occupation_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn occ_id;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;

        public Metex.Windows.DataEntityGrid OccupationGrid
        {
            get
            {
                return grid;
            }
        }

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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.OccupationCriteria);

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
            this.grid.ColumnHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.TabIndex = 0;

            //
            // occupation_desc
            //
            occupation_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occupation_desc.DataPropertyName = "OccupationDesc";
            this.occupation_desc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.occupation_desc.DefaultCellStyle.BackColor = System.Drawing.Color.White; //System.Drawing.SystemColors.ButtonFace;
            this.occupation_desc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.occupation_desc.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.occupation_desc.HeaderText = "";
            this.occupation_desc.Name = "occupation_desc";
            this.occupation_desc.ReadOnly = true;
            this.occupation_desc.Width = 506;
            this.grid.Columns.Add(occupation_desc);

            //
            // occ_id
            //
            occ_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occ_id.DataPropertyName = "OccId";
            this.occ_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.occ_id.DefaultCellStyle.BackColor = System.Drawing.Color.White; //System.Drawing.SystemColors.ButtonFace;
            this.occ_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.occ_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.occ_id.HeaderText = "";
            this.occ_id.Name = "occ_id";
            this.occ_id.ReadOnly = true;
            this.occ_id.Width = 60;
            this.grid.Columns.Add(occ_id);

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
