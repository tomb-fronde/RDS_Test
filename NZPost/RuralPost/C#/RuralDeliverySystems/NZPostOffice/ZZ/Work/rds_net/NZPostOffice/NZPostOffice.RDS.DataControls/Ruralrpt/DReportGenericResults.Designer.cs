namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportGenericResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;
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
            this.t_1 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.compute_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
           
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportGenericResults);
           
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.Control;
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.t_1.Location = new System.Drawing.Point(20, 2);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(85, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Search Results";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           
            // 
            // t_2
            // 
            this.t_2.BackColor = System.Drawing.SystemColors.Control;
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(4, 18);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(85, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Contracts Found";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.ColumnHeadersVisible = false;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compute_1,
            this.con_title});
            this.grid.DataSource = this.bindingSource;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 34);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.MultiSelect = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 244);
            this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;

            // 
            // compute_1
            // 
            this.compute_1.DataPropertyName = "Compute1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.compute_1.DefaultCellStyle = dataGridViewCellStyle2;
            this.compute_1.HeaderText = "";
            this.compute_1.Name = "compute_1";
            this.compute_1.ReadOnly = true;
            this.compute_1.Width = 55;
           
            // 
            // con_title
            // 
            this.con_title.DataPropertyName = "ConTitle";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.con_title.DefaultCellStyle = dataGridViewCellStyle3;
            this.con_title.HeaderText = "";
            this.con_title.Name = "con_title";
            this.con_title.ReadOnly = true;
            this.con_title.Width = 213;
           
            // 
            // DReportGenericResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;

            this.Controls.Add(this.grid);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.t_2);

            this.Name = "DReportGenericResults";
            this.Size = new System.Drawing.Size(638, 252);
            this.SizeChanged += new System.EventHandler(this.DReportGenericResults_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        void DReportGenericResults_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left - 5;
            this.grid.Height = this.Height - this.grid.Top - 5;
        }
        #endregion
    }
}
