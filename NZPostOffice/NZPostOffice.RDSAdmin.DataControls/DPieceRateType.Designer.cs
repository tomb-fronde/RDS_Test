namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DPieceRateType
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.prt_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prs_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.prt_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prt_print_on_schedule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prs_true_value = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.PieceRateType);
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
            this.grid.ColumnHeadersHeight = 32;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prt_description,
            this.prs_key,
            this.prt_code,
            this.prt_print_on_schedule,
            this.prs_true_value});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(555, 347);
            this.grid.TabIndex = 0;
            // 
            // prt_description
            // 
            this.prt_description.DataPropertyName = "PrtDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.prt_description.DefaultCellStyle = dataGridViewCellStyle2;
            this.prt_description.HeaderText = "Piece Rate Types";
            this.prt_description.Name = "prt_description";
            this.prt_description.Width = 195;
            // 
            // prs_key
            // 
            this.prs_key.DataPropertyName = "PrsKey";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.prs_key.DefaultCellStyle = dataGridViewCellStyle3;
            this.prs_key.HeaderText = "Supplier";
            this.prs_key.Name = "prs_key";
            this.prs_key.Width = 176;
            // 
            // prt_code
            // 
            this.prt_code.DataPropertyName = "PrtCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.prt_code.DefaultCellStyle = dataGridViewCellStyle4;
            this.prt_code.HeaderText = "Code";
            this.prt_code.Name = "prt_code";
            this.prt_code.Width = 40;
            // 
            // prt_print_on_schedule
            // 
            this.prt_print_on_schedule.DataPropertyName = "PrtPrintOnSchedule";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = false;
            this.prt_print_on_schedule.DefaultCellStyle = dataGridViewCellStyle5;
            this.prt_print_on_schedule.FalseValue = "N";
            this.prt_print_on_schedule.HeaderText = "Print On\nSchedule";
            this.prt_print_on_schedule.Name = "prt_print_on_schedule";
            this.prt_print_on_schedule.TrueValue = "Y";
            this.prt_print_on_schedule.Width = 53;
            // 
            // prs_true_value
            // 
            this.prs_true_value.DataPropertyName = "PrsTrueValue";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = false;
            this.prs_true_value.DefaultCellStyle = dataGridViewCellStyle6;
            this.prs_true_value.FalseValue = "N";
            this.prs_true_value.HeaderText = "True Value";
            this.prs_true_value.Name = "prs_true_value";
            this.prs_true_value.TrueValue = "Y";
            this.prs_true_value.Width = 66;
            // 
            // DPieceRateType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DPieceRateType";
            this.Size = new System.Drawing.Size(555, 347);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn prt_description;
        private Metex.Windows.DataGridViewEntityComboColumn prs_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn prt_code;
        private System.Windows.Forms.DataGridViewCheckBoxColumn prt_print_on_schedule;
        private System.Windows.Forms.DataGridViewCheckBoxColumn prs_true_value;




    }
}
