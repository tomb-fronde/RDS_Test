namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwComponentList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.rc_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_allowcreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_allowread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_allowmodify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_allowdelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.ComponentList);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
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
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rc_description,
            this.rc_allowcreate,
            this.rc_allowread,
            this.rc_allowmodify,
            this.rc_allowdelete});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            // 
            // rc_description
            // 
            this.rc_description.DataPropertyName = "RcDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.rc_description.DefaultCellStyle = dataGridViewCellStyle2;
            this.rc_description.HeaderText = "Components";
            this.rc_description.Name = "rc_description";
            this.rc_description.ReadOnly = true;
            this.rc_description.Width = 347;
            // 
            // rc_allowcreate
            // 
            this.rc_allowcreate.DataPropertyName = "RcAllowcreate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.rc_allowcreate.DefaultCellStyle = dataGridViewCellStyle3;
            this.rc_allowcreate.HeaderText = "";
            this.rc_allowcreate.Name = "rc_allowcreate";
            this.rc_allowcreate.ReadOnly = true;
            this.rc_allowcreate.Visible = false;
            this.rc_allowcreate.Width = 81;
            // 
            // rc_allowread
            // 
            this.rc_allowread.DataPropertyName = "RcAllowread";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.rc_allowread.DefaultCellStyle = dataGridViewCellStyle4;
            this.rc_allowread.HeaderText = "";
            this.rc_allowread.Name = "rc_allowread";
            this.rc_allowread.ReadOnly = true;
            this.rc_allowread.Visible = false;
            this.rc_allowread.Width = 81;
            // 
            // rc_allowmodify
            // 
            this.rc_allowmodify.DataPropertyName = "RcAllowmodify";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.rc_allowmodify.DefaultCellStyle = dataGridViewCellStyle5;
            this.rc_allowmodify.HeaderText = "";
            this.rc_allowmodify.Name = "rc_allowmodify";
            this.rc_allowmodify.ReadOnly = true;
            this.rc_allowmodify.Visible = false;
            this.rc_allowmodify.Width = 81;
            // 
            // rc_allowdelete
            // 
            this.rc_allowdelete.DataPropertyName = "RcAllowdelete";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.rc_allowdelete.DefaultCellStyle = dataGridViewCellStyle6;
            this.rc_allowdelete.HeaderText = "";
            this.rc_allowdelete.Name = "rc_allowdelete";
            this.rc_allowdelete.ReadOnly = true;
            this.rc_allowdelete.Visible = false;
            this.rc_allowdelete.Width = 81;
            // 
            // DwComponentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DwComponentList";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn rc_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_allowcreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_allowread;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_allowmodify;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_allowdelete;


    }
}
