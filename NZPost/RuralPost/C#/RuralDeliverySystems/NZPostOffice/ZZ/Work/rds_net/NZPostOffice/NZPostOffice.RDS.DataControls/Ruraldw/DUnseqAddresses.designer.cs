namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DUnseqAddresses
    {
        // TJB  Jan-2011  Sequencing Review

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn address_adr_alpha;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivery_sequence;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adr_num_alpha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.road_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.UnseqAddresses);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.sequence,
            this.adr_num_alpha,
            this.road_name,
            this.customer});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 16;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            // 
            // sequence
            // 
            this.sequence.DataPropertyName = "Sequence";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.sequence.DefaultCellStyle = dataGridViewCellStyle2;
            this.sequence.HeaderText = "Seq";
            this.sequence.Name = "sequence";
            this.sequence.Width = 28;
            // 
            // adr_num_alpha
            // 
            this.adr_num_alpha.DataPropertyName = "AdrNumAlpha";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.adr_num_alpha.DefaultCellStyle = dataGridViewCellStyle3;
            this.adr_num_alpha.HeaderText = "Road Num";
            this.adr_num_alpha.Name = "adr_num_alpha";
            this.adr_num_alpha.ReadOnly = true;
            this.adr_num_alpha.Width = 68;
            // 
            // road_name
            // 
            this.road_name.DataPropertyName = "RoadName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.road_name.DefaultCellStyle = dataGridViewCellStyle4;
            this.road_name.HeaderText = "Road Name";
            this.road_name.Name = "road_name";
            this.road_name.ReadOnly = true;
            this.road_name.Width = 161;
            // 
            // customer
            // 
            this.customer.DataPropertyName = "Customer";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.customer.DefaultCellStyle = dataGridViewCellStyle5;
            this.customer.HeaderText = "Customer";
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            this.customer.Width = 224;
            // 
            // DUnseqAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grid);
            this.Name = "DUnseqAddresses";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn sequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn adr_num_alpha;
        private System.Windows.Forms.DataGridViewTextBoxColumn road_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
    }
}
