namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DPostCriteria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_info;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;

        public Metex.Windows.DataEntityGrid PostGrid
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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.PostCriteria);

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
            // post_info
            //
            post_info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_info.DataPropertyName = "PostInfo";
            this.post_info.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.post_info.DefaultCellStyle.BackColor = System.Drawing.Color.White; //System.Drawing.SystemColors.ButtonFace;
            this.post_info.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.post_info.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.post_info.HeaderText = "";
            this.post_info.Name = "post_info";
            this.post_info.ReadOnly = true;
            this.post_info.Width = 240;
            this.grid.Columns.Add(post_info);


            //
            // post_id
            //
            post_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_id.DataPropertyName = "PostId";
            this.post_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.post_id.DefaultCellStyle.BackColor = System.Drawing.Color.White; //System.Drawing.ColorTranslator.FromWin32(553648127);
            this.post_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.post_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.post_id.HeaderText = "";
            this.post_id.Name = "post_id";
            this.post_id.ReadOnly = true;
            this.post_id.Width = 60;
            this.grid.Columns.Add(post_id);

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
