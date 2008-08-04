namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DNpadParameters
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  npad_directory;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  npad_enabled;
        private Metex.Windows.DataGridViewEntityComboColumn npad_userid;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.NpadParameters);

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
			this.grid.Location = new System.Drawing.Point(120, 20);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(700, 400);
			this.grid.TabIndex = 0;

			//
			// npad_userid
			//
			npad_userid = new Metex.Windows.DataGridViewEntityComboColumn();
			this.npad_userid.DataPropertyName = "NpadUserid";
			this.npad_userid.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
			this.npad_userid.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.npad_userid.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.npad_userid.HeaderText = "Userid";
            this.npad_userid.Name = "npad_userid";
            this.npad_userid.ValueMember = "UiUserid";
            this.npad_userid.DisplayMember = "UName";
			this.npad_userid.Width =200;
            this.npad_userid.ReadOnly = true;
            this.npad_userid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.npad_userid.DisplayStyleForCurrentCellOnly = true;
			this.grid.Columns.Add(npad_userid);


			//
			// npad_enabled
			//
			npad_enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.npad_enabled.DataPropertyName = "NpadEnabled";
			this.npad_enabled.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.npad_enabled.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;;
			this.npad_enabled.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.npad_enabled.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.npad_enabled.DefaultCellStyle.NullValue = false;
			this.npad_enabled.HeaderText = "Enabled";
			this.npad_enabled.Name = "npad_enabled";
			this.npad_enabled.TrueValue = "1";
			this.npad_enabled.FalseValue = "0";
			this.npad_enabled.Width = 89;
			this.grid.Columns.Add(npad_enabled);


			//
			// npad_directory
			//
			npad_directory= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.npad_directory.DataPropertyName = "NpadDirectory";
			this.npad_directory.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.npad_directory.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
			this.npad_directory.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.npad_directory.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.npad_directory.HeaderText = "Npad Directory";
			this.npad_directory.Name = "npad_directory";
			this.npad_directory.Width = 380;
			this.grid.Columns.Add(npad_directory);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(700, 300);
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(grid);
		}
		#endregion

	}
}
