using System.Windows.Forms;
namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DProcurement
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  proc_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  proc_id;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.Procurement);

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
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(grid_DataError);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);
			//
			// proc_id
			//
			proc_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.proc_id.DataPropertyName = "ProcId";
			this.proc_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.proc_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
			this.proc_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.proc_id.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.proc_id.HeaderText = "Procurements Id";
			this.proc_id.Name = "proc_id";
			this.proc_id.Width = 75;
			this.grid.Columns.Add(proc_id);

            //
            // proc_name
            //
            proc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proc_name.DataPropertyName = "ProcName";
            this.proc_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.proc_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.proc_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.proc_name.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.proc_name.HeaderText = "Name";
            this.proc_name.Name = "proc_name";
            this.proc_name.Width = 175;
            this.grid.Columns.Add(proc_name);


			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(grid);
		}

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            if (grid.Columns[e.ColumnIndex].Name == "proc_id")
            {
                string createValue = grid.Rows[e.RowIndex].Cells["proc_id"].EditedFormattedValue.ToString();
                try
                {
                    int.Parse(createValue);
                }
                catch
                {
                    MessageBox.Show("Item " +createValue + " doesn't pass validation test.","Validation Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.grid.IsCurrentCellDirty)
            {
                this.grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
		#endregion

	}
}
