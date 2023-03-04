namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwGroupsAndUsersLevel3
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  parent_id1;
		private System.Windows.Forms.DataGridViewTextBoxColumn  parent_id2;
		private System.Windows.Forms.DataGridViewTextBoxColumn  account;
		private System.Windows.Forms.DataGridViewTextBoxColumn  label;
		private System.Windows.Forms.DataGridViewTextBoxColumn  pictindex;
		private System.Windows.Forms.DataGridViewTextBoxColumn  id;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.GroupsAndUsersLevel3);

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
			// parent_id1
			//
			parent_id1= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.parent_id1.DataPropertyName = "ParentId1";
			this.parent_id1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.parent_id1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.parent_id1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.parent_id1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.parent_id1.HeaderText = "Rds UserParent Id1";
			this.parent_id1.Name = "parent_id1";
			this.parent_id1.ReadOnly = true;
			this.parent_id1.Width = 71;
			this.grid.Columns.Add(parent_id1);


			//
			// parent_id2
			//
			parent_id2= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.parent_id2.DataPropertyName = "ParentId2";
			this.parent_id2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.parent_id2.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.parent_id2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.parent_id2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.parent_id2.HeaderText = "Rds UserParent Id2";
			this.parent_id2.Name = "parent_id2";
			this.parent_id2.ReadOnly = true;
			this.parent_id2.Width = 71;
			this.grid.Columns.Add(parent_id2);


			//
			// label
			//
			label= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label.DataPropertyName = "Label";
			this.label.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.label.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.label.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.label.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.label.HeaderText = "Rds User Label";
			this.label.Name = "label";
			this.label.ReadOnly = true;
			this.label.Width = 293;
			this.grid.Columns.Add(label);


			//
			// pictindex
			//
			pictindex= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pictindex.DataPropertyName = "Pictindex";
			this.pictindex.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.pictindex.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.pictindex.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.pictindex.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.pictindex.HeaderText = "Rds User Pictindex";
			this.pictindex.Name = "pictindex";
			this.pictindex.ReadOnly = true;
			this.pictindex.Width = 252;
			this.grid.Columns.Add(pictindex);


			//
			// id
			//
			id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.id.DataPropertyName = "Id";
			this.id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.id.HeaderText = "Rds User Id Id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Width = 252;
			this.grid.Columns.Add(id);


			//
			// account
			//
			account= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.account.DataPropertyName = "Account";
			this.account.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.account.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.account.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.account.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.account.HeaderText = "Rds User Account";
			this.account.Name = "account";
			this.account.ReadOnly = true;
			this.account.Width = 252;
			this.grid.Columns.Add(account);

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
