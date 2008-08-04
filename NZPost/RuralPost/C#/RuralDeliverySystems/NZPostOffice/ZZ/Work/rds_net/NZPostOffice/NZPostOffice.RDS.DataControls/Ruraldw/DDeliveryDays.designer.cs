namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDeliveryDays
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  fri;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  thu;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  tue;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  sat;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  wed;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  mon;
		private System.Windows.Forms.DataGridViewTextBoxColumn  deliverystring;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  sun;
        private System.Windows.Forms.Label t_1;
	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DeliveryDays);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(1, 1);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(120, 28);
            this.t_1.Text = "Select the days the customer receives mail";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_1);

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
			//this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 29);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;

			//
			// mon
			//
			mon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.mon.DataPropertyName = "Mon";
			this.mon.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.mon.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.mon.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.mon.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.mon.DefaultCellStyle.NullValue = false;
            this.mon.HeaderText = "Mon";
			this.mon.Name = "mon";
			this.mon.TrueValue = "Y";
			this.mon.FalseValue = "N";
			this.mon.Width = 29;
			this.grid.Columns.Add(mon);


			//
			// tue
			//
			tue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.tue.DataPropertyName = "Tue";
			this.tue.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tue.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.tue.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.tue.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tue.DefaultCellStyle.NullValue = false;
            this.tue.HeaderText = "Tue";
			this.tue.Name = "tue";
			this.tue.TrueValue = "Y";
			this.tue.FalseValue = "N";
            this.tue.Width = 25;
			this.grid.Columns.Add(tue);


			//
			// wed
			//
			wed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.wed.DataPropertyName = "Wed";
			this.wed.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.wed.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.wed.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.wed.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.wed.DefaultCellStyle.NullValue = false;
            this.wed.HeaderText = "Wed";
			this.wed.Name = "wed";
			this.wed.TrueValue = "Y";
			this.wed.FalseValue = "N";
            this.wed.Width = 29;
			this.grid.Columns.Add(wed);


			//
			// thu
			//
			thu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.thu.DataPropertyName = "Thu";
			this.thu.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.thu.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.thu.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.thu.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.thu.DefaultCellStyle.NullValue = false;
            this.thu.HeaderText = "Thu";
			this.thu.Name = "thu";
			this.thu.TrueValue = "Y";
			this.thu.FalseValue = "N";
            this.thu.Width = 25;
			this.grid.Columns.Add(thu);


			//
			// fri
			//
			fri = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.fri.DataPropertyName = "Fri";
			this.fri.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.fri.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.fri.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fri.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fri.DefaultCellStyle.NullValue = false;
            this.fri.HeaderText = "Fri";
			this.fri.Name = "fri";
			this.fri.TrueValue = "Y";
			this.fri.FalseValue = "N";
            this.fri.Width = 25;
			this.grid.Columns.Add(fri);


			//
			// sat
			//
			sat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.sat.DataPropertyName = "Sat";
			this.sat.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.sat.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.sat.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.sat.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.sat.DefaultCellStyle.NullValue = false;
            this.sat.HeaderText = "Sat";
			this.sat.Name = "sat";
			this.sat.TrueValue = "Y";
			this.sat.FalseValue = "N";
            this.sat.Width = 25;
			this.grid.Columns.Add(sat);


			//
			// sun
			//
			sun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.sun.DataPropertyName = "Sun";
			this.sun.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.sun.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.sun.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.sun.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.sun.DefaultCellStyle.NullValue = false;
            this.sun.HeaderText = "Sun";
			this.sun.Name = "sun";
			this.sun.TrueValue = "Y";
			this.sun.FalseValue = "N";
            this.sun.Width = 25;
			this.grid.Columns.Add(sun);


			//
			// deliverystring
			//
			deliverystring= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.deliverystring.DataPropertyName = "Deliverystring";
			this.deliverystring.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.deliverystring.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.deliverystring.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.deliverystring.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.deliverystring.HeaderText = "";
			this.deliverystring.Name = "deliverystring";
			this.deliverystring.Width = 134;
			this.grid.Columns.Add(deliverystring);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
