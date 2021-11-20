namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RVehExpRegReport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rego;
		private System.Windows.Forms.DataGridViewTextBoxColumn  vfuel;
		private System.Windows.Forms.DataGridViewTextBoxColumn  expiry;
		private System.Windows.Forms.DataGridViewTextBoxColumn  vdesc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  con_num;
		private System.Windows.Forms.DataGridViewTextBoxColumn  vyear;
		private System.Windows.Forms.DataGridViewTextBoxColumn  vmake;
		private System.Windows.Forms.DataGridViewTextBoxColumn  vmodel;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.VehExpRegReport);

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
			// expiry
			//
			expiry= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.expiry.DataPropertyName = "Expiry";
			this.expiry.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.expiry.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.expiry.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.expiry.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.expiry.DefaultCellStyle.Format = "dd/mm/yyyy";
			this.expiry.HeaderText = "Rural Post";
			this.expiry.Name = "expiry";
			this.expiry.ReadOnly = true;
			this.expiry.Width = 99;
			this.grid.Columns.Add(expiry);


			//
			// con_num
			//
			con_num= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con_num.DataPropertyName = "ConNum";
			this.con_num.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.con_num.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.con_num.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.con_num.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.con_num.HeaderText = "Contract";
			this.con_num.Name = "con_num";
			this.con_num.ReadOnly = true;
			this.con_num.Width = 60;
			this.grid.Columns.Add(con_num);


			//
			// rego
			//
			rego= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rego.DataPropertyName = "Rego";
			this.rego.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rego.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rego.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rego.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rego.HeaderText = "Registration";
			this.rego.Name = "rego";
			this.rego.ReadOnly = true;
			this.rego.Width = 67;
			this.grid.Columns.Add(rego);


			//
			// vyear
			//
			vyear= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vyear.DataPropertyName = "Vyear";
			this.vyear.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.vyear.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.vyear.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.vyear.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.vyear.HeaderText = "Year";
			this.vyear.Name = "vyear";
			this.vyear.ReadOnly = true;
			this.vyear.Width = 53;
			this.grid.Columns.Add(vyear);


			//
			// vdesc
			//
			vdesc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vdesc.DataPropertyName = "Vdesc";
			this.vdesc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.vdesc.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.vdesc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.vdesc.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.vdesc.HeaderText = "Vehicle Class";
			this.vdesc.Name = "vdesc";
			this.vdesc.ReadOnly = true;
			this.vdesc.Width = 108;
			this.grid.Columns.Add(vdesc);


			//
			// vfuel
			//
			vfuel= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vfuel.DataPropertyName = "Vfuel";
			this.vfuel.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.vfuel.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.vfuel.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.vfuel.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.vfuel.HeaderText = "Fuel Type";
			this.vfuel.Name = "vfuel";
			this.vfuel.ReadOnly = true;
			this.vfuel.Width = 64;
			this.grid.Columns.Add(vfuel);


			//
			// vmake
			//
			vmake= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vmake.DataPropertyName = "Vmake";
			this.vmake.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.vmake.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.vmake.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.vmake.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.vmake.HeaderText = "Make";
			this.vmake.Name = "vmake";
			this.vmake.ReadOnly = true;
			this.vmake.Width = 89;
			this.grid.Columns.Add(vmake);


			//
			// vmodel
			//
			vmodel= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vmodel.DataPropertyName = "Vmodel";
			this.vmodel.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.vmodel.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.vmodel.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.vmodel.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.vmodel.HeaderText = "Model";
			this.vmodel.Name = "vmodel";
			this.vmodel.ReadOnly = true;
			this.vmodel.Width = 124;
			this.grid.Columns.Add(vmodel);

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
