namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DInterestCriteria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn interest_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn int_id;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;

        public Metex.Windows.DataEntityGrid InterestGrid
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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.InterestCriteria);

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
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.TabIndex = 10;

            //
            // interest_desc
            //
            interest_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interest_desc.DataPropertyName = "InterestDesc";
            this.interest_desc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.interest_desc.DefaultCellStyle.BackColor = System.Drawing.Color.White; //System.Drawing.SystemColors.ButtonFace;
            this.interest_desc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.interest_desc.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.interest_desc.HeaderText = "";
            this.interest_desc.Name = "interest_desc";
            this.interest_desc.ReadOnly = true;
            this.interest_desc.Width = 506;
            this.grid.Columns.Add(interest_desc);


            //
            // int_id
            //
            int_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int_id.DataPropertyName = "IntId";
            this.int_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.int_id.DefaultCellStyle.BackColor = System.Drawing.Color.White; //System.Drawing.SystemColors.ButtonFace;
            this.int_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.int_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.int_id.HeaderText = "";
            this.int_id.Name = "int_id";
            this.int_id.ReadOnly = true;
            this.int_id.Width = 60;
            this.grid.Columns.Add(int_id);

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
