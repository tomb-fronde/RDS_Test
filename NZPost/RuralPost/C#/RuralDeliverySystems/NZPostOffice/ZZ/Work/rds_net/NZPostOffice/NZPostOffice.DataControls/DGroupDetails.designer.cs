namespace NZPostOffice.DataControls
{
	partial class DGroupDetails
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  modified_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  created_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  description;
		private System.Windows.Forms.DataGridViewTextBoxColumn  group_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  created_by;
		private System.Windows.Forms.DataGridViewTextBoxColumn  privacy_override;
		private System.Windows.Forms.DataGridViewTextBoxColumn  modified_by;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.Entity.GroupDetails);

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
			this.group_id.HeaderText = "Ug Id";
			this.group_id.Name = "group_id";
			this.group_id.Width = 60;
			this.grid.Columns.Add(group_id);


			//
			// name
			//
			name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name.DataPropertyName = "Name";
			this.name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.name.HeaderText = "Ug Name";
			this.name.Name = "name";
			this.name.Width = 255;
			this.grid.Columns.Add(name);


			//
			// description
			//
			description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.description.DataPropertyName = "Description";
			this.description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.description.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.description.HeaderText = "Ug Description";
			this.description.Name = "description";
			this.description.Width = 59;
			this.grid.Columns.Add(description);


			//
			// created_date
			//
			created_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.created_date.DataPropertyName = "CreatedDate";
			this.created_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.created_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.created_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.created_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.created_date.HeaderText = "Ug Created Date";
			this.created_date.Name = "created_date";
			this.created_date.Width = 78;
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
			this.created_by.HeaderText = "Ug Created By";
			this.created_by.Name = "created_by";
			this.created_by.Width = 105;
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
			this.modified_date.HeaderText = "Ug Modified Date";
			this.modified_date.Name = "modified_date";
			this.modified_date.Width = 81;
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
			this.modified_by.HeaderText = "Ug Modified By";
			this.modified_by.Name = "modified_by";
			this.modified_by.Width = 105;
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
			this.privacy_override.HeaderText = "Ug Privacy Override";
			this.privacy_override.Name = "privacy_override";
			this.privacy_override.Width = 96;
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
