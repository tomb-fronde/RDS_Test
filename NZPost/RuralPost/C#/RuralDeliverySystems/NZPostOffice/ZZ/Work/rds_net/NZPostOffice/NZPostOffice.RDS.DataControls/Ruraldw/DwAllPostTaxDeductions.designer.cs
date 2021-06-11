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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.ded_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_start_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_end_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_contractor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AllPostTaxDeductions);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ded_id,
            this.ded_reference,
            this.ded_start_balance,
            this.ded_end_balance});
            this.grid.DataSource = this.bindingSource;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 15);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 25);
            this.grid.TabIndex = 0;
            // 
            // ded_id
            // 
            this.ded_id.DataPropertyName = "DedId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.ded_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.ded_id.HeaderText = "ID";
            this.ded_id.Name = "ded_id";
            this.ded_id.ReadOnly = true;
            this.ded_id.Width = 50;
            // 
            // ded_reference
            // 
            this.ded_reference.DataPropertyName = "DedReference";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ded_reference.DefaultCellStyle = dataGridViewCellStyle3;
            this.ded_reference.HeaderText = "Reference";
            this.ded_reference.Name = "ded_reference";
            this.ded_reference.ReadOnly = true;
            this.ded_reference.Width = 288;
            // 
            // ded_start_balance
            // 
            this.ded_start_balance.DataPropertyName = "DedStartBalance";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Format = "###,###.00";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ded_start_balance.DefaultCellStyle = dataGridViewCellStyle4;
            this.ded_start_balance.HeaderText = "Total Amount";
            this.ded_start_balance.Name = "ded_start_balance";
            this.ded_start_balance.ReadOnly = true;
            this.ded_start_balance.Width = 89;
            // 
            // ded_end_balance
            // 
            this.ded_end_balance.DataPropertyName = "DedEndBalance";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Format = "###,###.00";
            this.ded_end_balance.DefaultCellStyle = dataGridViewCellStyle5;
            this.ded_end_balance.HeaderText = "Ending Balance";
            this.ded_end_balance.Name = "ded_end_balance";
            this.ded_end_balance.ReadOnly = true;
            this.ded_end_balance.Width = 89;
            // 
            // st_contractor
            // 
            this.st_contractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_contractor.Location = new System.Drawing.Point(2, 0);
            this.st_contractor.Name = "st_contractor";
            this.st_contractor.Size = new System.Drawing.Size(537, 14);
            this.st_contractor.TabIndex = 1;
            this.st_contractor.Text = "Owner Driver:";
            // 
            // DwAllPostTaxDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.st_contractor);
            this.Name = "DwAllPostTaxDeductions";
            this.Size = new System.Drawing.Size(575, 250);
            this.SizeChanged += new System.EventHandler(this.DwAllPostTaxDeductions_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        void DwAllPostTaxDeductions_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left - 3;
            this.grid.Height = this.Height - this.grid.Top - 3;
        }
        #endregion

    }
}
