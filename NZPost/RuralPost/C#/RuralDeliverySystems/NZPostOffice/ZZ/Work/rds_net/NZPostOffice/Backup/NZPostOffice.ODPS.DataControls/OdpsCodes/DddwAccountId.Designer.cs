namespace NZPostOffice.ODPS.DataControls.OdpsCodes
{
    partial class DddwAccountId
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac_id;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsCodes.AccountId);

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
            this.grid.TabIndex = 0;

            //
            // ac_description
            //
            ac_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac_description.DataPropertyName = "AcDescription";
            this.ac_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ac_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ac_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ac_description.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ac_description.HeaderText = "";
            this.ac_description.Name = "ac_description";
            this.ac_description.ReadOnly = true;
            this.ac_description.Width = 240;
            this.grid.Columns.Add(ac_description);

            //
            // ac_id
            //
            ac_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac_id.DataPropertyName = "AcId";
            this.ac_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ac_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ac_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ac_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ac_id.HeaderText = "";
            this.ac_id.Name = "ac_id";
            this.ac_id.ReadOnly = true;
            this.ac_id.Visible = false;
            this.ac_id.Width = 240;
            this.grid.Columns.Add(ac_id);

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
