namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DWhatifFreqs
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_friday;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_active;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_thursday;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_saturday;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_monday;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_sunday;
		private Metex.Windows.DataGridViewEntityComboColumn  sf_key;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_wednesday;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn rf_distance;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calc_deldays;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  rf_tuesday;

	
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
			components = new System.ComponentModel.Container();
			grid = new Metex.Windows.DataEntityGrid();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.WhatifFreqs);

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
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;

			//
			// sf_key
			//
			sf_key = new Metex.Windows.DataGridViewEntityComboColumn();
			this.sf_key.DataPropertyName = "SfKey";
			this.sf_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.sf_key.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.sf_key.HeaderText = "Route Frequencies";
            this.sf_key.Name = "sf_key";
			this.sf_key.Width = 130;
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.ValueMember = "SfKey";
			this.grid.Columns.Add(sf_key);

            //
            // rf_active
            //
            rf_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_active.DataPropertyName = "RfActive";
            this.rf_active.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_active.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_active.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_active.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rf_active.DefaultCellStyle.NullValue = false;
            this.rf_active.HeaderText = "Active";
            this.rf_active.Name = "rf_active";
            this.rf_active.TrueValue = "Y";
            this.rf_active.FalseValue = "N";
            this.rf_active.Width = 40;
            this.grid.Columns.Add(rf_active);

            //
            // rf_monday
            //
            rf_monday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_monday.DataPropertyName = "RfMonday";
            this.rf_monday.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_monday.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_monday.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_monday.DefaultCellStyle.NullValue = false;
            this.rf_monday.HeaderText = "M";
            this.rf_monday.Name = "rf_monday";
            this.rf_monday.TrueValue = "Y";
            this.rf_monday.FalseValue = "N";
            this.rf_monday.Width = 20;
            this.grid.Columns.Add(rf_monday);

            //
            // rf_tuesday
            //
            rf_tuesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_tuesday.DataPropertyName = "RfTuesday";
            this.rf_tuesday.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_tuesday.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_tuesday.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_tuesday.DefaultCellStyle.NullValue = false;
            this.rf_tuesday.HeaderText = "T";
            this.rf_tuesday.Name = "rf_tuesday";
            this.rf_tuesday.TrueValue = "Y";
            this.rf_tuesday.FalseValue = "N";
            this.rf_tuesday.Width = 20;
            this.grid.Columns.Add(rf_tuesday);

            //
            // rf_wednesday
            //
            rf_wednesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_wednesday.DataPropertyName = "RfWednesday";
            this.rf_wednesday.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_wednesday.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_wednesday.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_wednesday.DefaultCellStyle.NullValue = false;
            this.rf_wednesday.HeaderText = "W";
            this.rf_wednesday.Name = "rf_wednesday";
            this.rf_wednesday.TrueValue = "Y";
            this.rf_wednesday.FalseValue = "N";
            this.rf_wednesday.Width = 20;
            this.grid.Columns.Add(rf_wednesday);

            //
            // rf_thursday
            //
            rf_thursday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_thursday.DataPropertyName = "RfThursday";
            this.rf_thursday.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_thursday.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_thursday.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_thursday.DefaultCellStyle.NullValue = false;
            this.rf_thursday.HeaderText = "T";
            this.rf_thursday.Name = "rf_thursday";
            this.rf_thursday.TrueValue = "Y";
            this.rf_thursday.FalseValue = "N";
            this.rf_thursday.Width = 20;
            this.grid.Columns.Add(rf_thursday);


            //
            // rf_friday
            //
            rf_friday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_friday.DataPropertyName = "RfFriday";
            this.rf_friday.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_friday.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_friday.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_friday.DefaultCellStyle.NullValue = false;
            this.rf_friday.HeaderText = "F";
            this.rf_friday.Name = "rf_friday";
            this.rf_friday.TrueValue = "Y";
            this.rf_friday.FalseValue = "N";
            this.rf_friday.Width = 20;
            this.grid.Columns.Add(rf_friday);

            //
            // rf_saturday
            //
            rf_saturday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_saturday.DataPropertyName = "RfSaturday";
            this.rf_saturday.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_saturday.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_saturday.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_saturday.DefaultCellStyle.NullValue = false;
            this.rf_saturday.HeaderText = "S";
            this.rf_saturday.Name = "rf_saturday";
            this.rf_saturday.TrueValue = "Y";
            this.rf_saturday.FalseValue = "N";
            this.rf_saturday.Width = 20;
            this.grid.Columns.Add(rf_saturday);

            //
            // rf_sunday
            //
            rf_sunday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rf_sunday.DataPropertyName = "RfSunday";
            this.rf_sunday.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rf_sunday.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_sunday.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_sunday.DefaultCellStyle.NullValue = false;
            this.rf_sunday.HeaderText = "S";
            this.rf_sunday.Name = "rf_sunday";
            this.rf_sunday.TrueValue = "Y";
            this.rf_sunday.FalseValue = "N";
            this.rf_sunday.Width = 20;
            this.grid.Columns.Add(rf_sunday);

			//
			// rf_distance
			//
            rf_distance = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
			this.rf_distance.DataPropertyName = "RfDistance";
			this.rf_distance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rf_distance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rf_distance.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rf_distance.HeaderText = "Distance";
			this.rf_distance.Name = "rf_distance";
			this.rf_distance.Width = 50;
            this.rf_distance.Mask = "###.00";
			this.grid.Columns.Add(rf_distance);
		
			//
			// calc_deldays
			//
			calc_deldays= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calc_deldays.DataPropertyName = "CalcDeldays";
			this.calc_deldays.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.calc_deldays.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calc_deldays.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.calc_deldays.HeaderText = "";
			this.calc_deldays.Name = "calc_deldays";
			this.calc_deldays.Width = 39;
            this.calc_deldays.Visible = false;
			this.grid.Columns.Add(calc_deldays);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
