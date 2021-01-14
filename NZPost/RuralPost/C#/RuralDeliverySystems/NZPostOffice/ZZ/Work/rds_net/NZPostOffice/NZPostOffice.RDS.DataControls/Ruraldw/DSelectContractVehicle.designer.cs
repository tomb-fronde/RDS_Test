using System;
using System.Windows.Forms;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DSelectContractVehicle
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.Label st_protect_confirm;
	
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
            this.grid = new Metex.Windows.DataEntityGrid();
            this.st_title = new System.Windows.Forms.Label();
            this.st_protect_confirm = new System.Windows.Forms.Label();
            this.vehicle_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicle_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.SelectContractVehicle);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.vehicle_name,
            this.vehicle_number,
            this.VehicleStatus,
            this.DefaultVehicle});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(348, 209);
            this.grid.TabIndex = 0;
            // 
            // st_title
            // 
            this.st_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_title.Location = new System.Drawing.Point(0, 0);
            this.st_title.Name = "st_title";
            this.st_title.Size = new System.Drawing.Size(638, 14);
            this.st_title.TabIndex = 1;
            this.st_title.Text = "SelectVehicle:";
            // 
            // st_protect_confirm
            // 
            this.st_protect_confirm.Location = new System.Drawing.Point(0, 0);
            this.st_protect_confirm.Name = "st_protect_confirm";
            this.st_protect_confirm.Size = new System.Drawing.Size(10, 14);
            this.st_protect_confirm.TabIndex = 2;
            this.st_protect_confirm.Text = "N";
            this.st_protect_confirm.Visible = false;
            // 
            // vehicle_name
            // 
            this.vehicle_name.DataPropertyName = "VehicleName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Format = "##,###.00";
            dataGridViewCellStyle2.NullValue = ".00";
            this.vehicle_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.vehicle_name.HeaderText = "Vehicle Name";
            this.vehicle_name.Name = "vehicle_name";
            this.vehicle_name.Width = 240;
            // 
            // vehicle_number
            // 
            this.vehicle_number.DataPropertyName = "VehicleNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.vehicle_number.DefaultCellStyle = dataGridViewCellStyle3;
            this.vehicle_number.HeaderText = "Vehicle No";
            this.vehicle_number.Name = "vehicle_number";
            this.vehicle_number.Width = 65;
            // 
            // VehicleStatus
            // 
            this.VehicleStatus.DataPropertyName = "VehicleStatus";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.VehicleStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.VehicleStatus.HeaderText = "Status";
            this.VehicleStatus.Name = "VehicleStatus";
            this.VehicleStatus.ToolTipText = "\"A\" is active otherwise not active";
            this.VehicleStatus.Visible = false;
            this.VehicleStatus.Width = 50;
            // 
            // DefaultVehicle
            // 
            this.DefaultVehicle.DataPropertyName = "DefaultVehicle";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.DefaultVehicle.DefaultCellStyle = dataGridViewCellStyle5;
            this.DefaultVehicle.HeaderText = "Default";
            this.DefaultVehicle.Name = "DefaultVehicle";
            this.DefaultVehicle.ToolTipText = "1 means this is the  default vehicle";
            this.DefaultVehicle.Visible = false;
            this.DefaultVehicle.Width = 50;
            // 
            // DSelectContractVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.st_title);
            this.Controls.Add(this.st_protect_confirm);
            this.Name = "DSelectContractVehicle";
            this.Size = new System.Drawing.Size(348, 209);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}

        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("grid_Validating");
        }
/*  (moved to DSelectContractVehicle.cs)
        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int rows;
            rows = grid.RowCount;
            MessageBox.Show("grid_CurrentCellDirtyStateChanged \n"
                            + "grid.Rowcount = "+rows.ToString());
        }
*/
        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("grid_DataError");
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (grid.RowCount <= 0)
                return;
            for (int i = 0; i < grid.RowCount; i++)
            {
                grid.Rows[i].Cells["vehicle_name"].ReadOnly = false;
                grid.Rows[i].Cells["vehicle_number"].ReadOnly = false;
            }
        }
        #endregion

        private DataGridViewTextBoxColumn vehicle_name;
        private DataGridViewTextBoxColumn vehicle_number;
        private DataGridViewTextBoxColumn VehicleStatus;
        private DataGridViewTextBoxColumn DefaultVehicle;






    }
}
