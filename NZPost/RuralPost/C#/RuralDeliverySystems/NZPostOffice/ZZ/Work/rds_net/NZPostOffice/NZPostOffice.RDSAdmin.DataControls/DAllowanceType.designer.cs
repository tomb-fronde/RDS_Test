namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DAllowanceType
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
        public Metex.Windows.DataEntityGrid Grid
        {
            get
            {
                return grid;
            }
        }
		#region Component Designer generated code
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.alt_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_wks_yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alct_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.alt_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.alt_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.AllowanceType);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 40;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alt_description,
            this.alt_rate,
            this.alt_wks_yr,
            this.alt_acc,
            this.alct_id,
            this.alt_effective_date,
            this.alt_notes});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(794, 425);
            this.grid.TabIndex = 0;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
            // 
            // alt_description
            // 
            this.alt_description.DataPropertyName = "AltDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.alt_description.DefaultCellStyle = dataGridViewCellStyle2;
            this.alt_description.HeaderText = "Allowance Types";
            this.alt_description.Name = "alt_description";
            this.alt_description.Width = 180;
            // 
            // alt_rate
            // 
            this.alt_rate.DataPropertyName = "AltRate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "null";
            this.alt_rate.DefaultCellStyle = dataGridViewCellStyle3;
            this.alt_rate.HeaderText = "Rate";
            this.alt_rate.Name = "alt_rate";
            this.alt_rate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_rate.Width = 50;
            // 
            // alt_wks_yr
            // 
            this.alt_wks_yr.DataPropertyName = "AltWksYr";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = "null";
            this.alt_wks_yr.DefaultCellStyle = dataGridViewCellStyle4;
            this.alt_wks_yr.HeaderText = "Weeks per Yr";
            this.alt_wks_yr.Name = "alt_wks_yr";
            this.alt_wks_yr.Width = 50;
            // 
            // alt_acc
            // 
            this.alt_acc.DataPropertyName = "AltAcc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = "null";
            this.alt_acc.DefaultCellStyle = dataGridViewCellStyle5;
            this.alt_acc.HeaderText = "Acc %";
            this.alt_acc.Name = "alt_acc";
            this.alt_acc.Width = 50;
            // 
            // alct_id
            // 
            this.alct_id.DataPropertyName = "AlctId";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = "null";
            this.alct_id.DefaultCellStyle = dataGridViewCellStyle6;
            this.alct_id.HeaderText = "Calc Type";
            this.alct_id.Name = "alct_id";
            this.alct_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alct_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.alct_id.Width = 140;
            // 
            // alt_effective_date
            // 
            this.alt_effective_date.DataPropertyName = "AltEffectiveDate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.alt_effective_date.DefaultCellStyle = dataGridViewCellStyle7;
            this.alt_effective_date.HeaderText = "Effective Date";
            this.alt_effective_date.IncludeLiterals = false;
            this.alt_effective_date.IncludePrompt = false;
            this.alt_effective_date.Mask = null;
            this.alt_effective_date.Name = "alt_effective_date";
            this.alt_effective_date.PromptChar = '\0';
            this.alt_effective_date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_effective_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.alt_effective_date.ValidatingType = null;
            this.alt_effective_date.Width = 70;
            // 
            // alt_notes
            // 
            this.alt_notes.DataPropertyName = "AltNotes";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.alt_notes.DefaultCellStyle = dataGridViewCellStyle8;
            this.alt_notes.HeaderText = "Notes";
            this.alt_notes.Name = "alt_notes";
            this.alt_notes.Width = 220;
            // 
            // DAllowanceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DAllowanceType";
            this.Size = new System.Drawing.Size(794, 425);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn alt_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt_wks_yr;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt_acc;
        private Metex.Windows.DataGridViewEntityComboColumn alct_id;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn alt_effective_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt_notes;




















    }
}
