namespace NZPostOffice.ODPS.DataControls.Odps
{
    // TJB  RPCR_113  July-2018
    // Added 3 columns for email addresses to form
    // (many lines rearranged by designer)

    partial class DwPbuCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn pbu_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn pbu_description;


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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.pbu_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbu_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbuEmail1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbuEmail2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbuEmail3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.PbuCode);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pbu_code,
            this.pbu_description,
            this.PbuEmail1,
            this.PbuEmail2,
            this.PbuEmail3});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            // 
            // pbu_code
            // 
            this.pbu_code.DataPropertyName = "Pbucode";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.pbu_code.DefaultCellStyle = dataGridViewCellStyle2;
            this.pbu_code.HeaderText = "PBU Code";
            this.pbu_code.MaxInputLength = 10;
            this.pbu_code.Name = "pbu_code";
            // 
            // pbu_description
            // 
            this.pbu_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pbu_description.DataPropertyName = "PbuDescription";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.pbu_description.DefaultCellStyle = dataGridViewCellStyle3;
            this.pbu_description.HeaderText = "PBU Description";
            this.pbu_description.MaxInputLength = 100;
            this.pbu_description.Name = "pbu_description";
            // 
            // PbuEmail1
            // 
            this.PbuEmail1.DataPropertyName = "PbuEmail1";
            this.PbuEmail1.HeaderText = "Pbu Email 1";
            this.PbuEmail1.Name = "PbuEmail1";
            // 
            // PbuEmail2
            // 
            this.PbuEmail2.DataPropertyName = "PbuEmail2";
            this.PbuEmail2.HeaderText = "Pbu Emai l2";
            this.PbuEmail2.Name = "PbuEmail2";
            // 
            // PbuEmail3
            // 
            this.PbuEmail3.DataPropertyName = "PbuEmail3";
            this.PbuEmail3.HeaderText = "Pbu Email 3";
            this.PbuEmail3.Name = "PbuEmail3";
            // 
            // DwPbuCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "DwPbuCode";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn PbuEmail1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PbuEmail2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PbuEmail3;

    }
}
