namespace NZPostOffice.DataControls
{
	partial class DUserGroups
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  modified_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  created_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  group_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  group_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  created_by;
		private System.Windows.Forms.DataGridViewTextBoxColumn  privacy_override;
		private System.Windows.Forms.DataGridViewTextBoxColumn  modified_by;
		private System.Windows.Forms.DataGridViewTextBoxColumn  group_description;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.Entity.UserGroups);

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
			// group_id
			//
			group_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.group_id.DataPropertyName = "GroupId";
			this.group_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.group_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.group_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.group_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.group_id.HeaderText = "Rds User Id GroupUg Id";
			this.group_id.Name = "group_id";
			this.group_id.ReadOnly = true;
			this.group_id.Width = 52;
			this.grid.Columns.Add(group_id);


			//
			// group_name
			//
			group_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.group_name.DataPropertyName = "GroupName";
			this.group_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.group_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.group_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.group_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.group_name.HeaderText = "Rds User GroupUg Name";
			this.group_name.Name = "group_name";
			this.group_name.ReadOnly = true;
			this.group_name.Width = 78;
			this.grid.Columns.Add(group_name);


			//
			// group_description
			//
			group_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.group_description.DataPropertyName = "GroupDescription";
			this.group_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.group_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.group_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.group_description.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.group_description.HeaderText = "Rds User GroupUg Description";
			this.group_description.Name = "group_description";
			this.group_description.ReadOnly = true;
			this.group_description.Width = 92;
			this.grid.Columns.Add(group_description);


			//
			// created_date
			//
			created_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.created_date.DataPropertyName = "CreatedDate";
			this.created_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.created_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.created_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.created_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.created_date.HeaderText = "Rds User GroupUg Created Date";
			this.created_date.Name = "created_date";
			this.created_date.ReadOnly = true;
			this.created_date.Width = 70;
			this.grid.Columns.Add(created_date);


			//
			// created_by
			//
			created_by= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.created_by.DataPropertyName = "CreatedBy";
			this.created_by.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.created_by.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.created_by.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.created_by.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.created_by.HeaderText = "Rds User GroupUg Created By";
			this.created_by.Name = "created_by";
			this.created_by.ReadOnly = true;
			this.created_by.Width = 64;
			this.grid.Columns.Add(created_by);


			//
			// modified_date
			//
			modified_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.modified_date.DataPropertyName = "ModifiedDate";
			this.modified_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.modified_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.modified_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.modified_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.modified_date.HeaderText = "Rds User GroupUg Modified Date";
			this.modified_date.Name = "modified_date";
			this.modified_date.ReadOnly = true;
			this.modified_date.Width = 73;
			this.grid.Columns.Add(modified_date);


			//
			// modified_by
			//
			modified_by= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.modified_by.DataPropertyName = "ModifiedBy";
			this.modified_by.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.modified_by.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.modified_by.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.modified_by.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.modified_by.HeaderText = "Rds User GroupUg Modified By";
			this.modified_by.Name = "modified_by";
			this.modified_by.ReadOnly = true;
			this.modified_by.Width = 68;
			this.grid.Columns.Add(modified_by);


			//
			// privacy_override
			//
			privacy_override= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.privacy_override.DataPropertyName = "PrivacyOverride";
			this.privacy_override.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.privacy_override.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.privacy_override.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.privacy_override.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.privacy_override.HeaderText = "Rds User GroupUg Privacy Override";
			this.privacy_override.Name = "privacy_override";
			this.privacy_override.ReadOnly = true;
			this.privacy_override.Width = 88;
			this.grid.Columns.Add(privacy_override);

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
