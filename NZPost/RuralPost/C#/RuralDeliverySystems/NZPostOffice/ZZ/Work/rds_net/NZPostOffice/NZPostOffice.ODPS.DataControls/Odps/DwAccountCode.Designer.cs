namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwAccountCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac_description;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.AccountCode);

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
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
           
            //
            // ac_code
            //
            ac_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac_code.DataPropertyName = "AcCode";
            this.ac_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ac_code.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ac_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ac_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ac_code.HeaderText = "Account Code";
            this.ac_code.Name = "ac_code";
            this.ac_code.Width = 129;
            this.ac_code.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(ac_code);

            //
            // ac_description
            //
            ac_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac_description.DataPropertyName = "AcDescription";
            this.ac_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ac_description.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ac_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ac_description.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ac_description.HeaderText = "Account Description";
            this.ac_description.Name = "ac_description";
            this.ac_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ac_description.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.Columns.Add(ac_description);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.Controls.Add(grid);
        }
        #endregion

    }
}
