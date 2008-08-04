namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwIr68aIr68p
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpnontaxable;
        private System.Windows.Forms.DataGridViewTextBoxColumn paye;
        private System.Windows.Forms.DataGridViewTextBoxColumn gptaxable;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Ir68aIr68p);

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
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // gpnontaxable
            //
            gpnontaxable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpnontaxable.DataPropertyName = "Gpnontaxable";
            this.gpnontaxable.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gpnontaxable.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gpnontaxable.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gpnontaxable.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.gpnontaxable.DefaultCellStyle.Format = "##,###,###.00";
            this.gpnontaxable.HeaderText = "Paye";
            this.gpnontaxable.Name = "gpnontaxable";
            this.gpnontaxable.ReadOnly = true;
            this.gpnontaxable.Width = 105;
            this.grid.Columns.Add(gpnontaxable);


            //
            // paye
            //
            paye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paye.DataPropertyName = "Paye";
            this.paye.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.paye.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.paye.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.paye.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.paye.DefaultCellStyle.Format = "##,###,###.00";
            this.paye.HeaderText = "Paye";
            this.paye.Name = "paye";
            this.paye.ReadOnly = true;
            this.paye.Width = 105;
            this.grid.Columns.Add(paye);


            //
            // gptaxable
            //
            gptaxable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gptaxable.DataPropertyName = "Gptaxable";
            this.gptaxable.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gptaxable.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gptaxable.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gptaxable.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.gptaxable.DefaultCellStyle.Format = "##,###,###.00";
            this.gptaxable.HeaderText = "Paye";
            this.gptaxable.Name = "gptaxable";
            this.gptaxable.ReadOnly = true;
            this.gptaxable.Width = 105;
            this.grid.Columns.Add(gptaxable);


            //
            // acc
            //
            acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acc.DataPropertyName = "Acc";
            this.acc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.acc.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.acc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.acc.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.acc.DefaultCellStyle.Format = "##,###,###.00";
            this.acc.HeaderText = "Paye";
            this.acc.Name = "acc";
            this.acc.Width = 81;
            this.grid.Columns.Add(acc);

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
