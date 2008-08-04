namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractorProcurement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Metex.Windows.DataGridViewEntityComboColumn proc_id;
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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractorProcurement);



            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
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
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.Location = new System.Drawing.Point(0, 15);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.Size = new System.Drawing.Size(500, 245);
            this.grid.TabIndex = 0;
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.Controls.Add(grid);
            
            //
            // proc_id
            //
            proc_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.proc_id.DataPropertyName = "ProcId";
            this.proc_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.proc_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.proc_id.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.proc_id.HeaderText = "Procurement deals";
            this.proc_id.Name = "proc_id";
            this.proc_id.Width = 155;

            this.grid.Columns.Add(proc_id);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(1, 1);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(500, 14);
            this.t_1.Text = "Owner Driver:";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_1);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(500, 245);
            this.BackColor = System.Drawing.SystemColors.Control;
            
        }

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            this.grid.EndEdit();
        }

        #endregion
    }
}
