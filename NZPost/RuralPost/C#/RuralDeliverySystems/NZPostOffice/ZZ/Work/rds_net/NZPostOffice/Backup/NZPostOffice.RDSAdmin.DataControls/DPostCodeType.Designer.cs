namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DPostCodeType
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.DataGridViewTextBoxColumn  post_code_id;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        // TJB  RD7_CR001  Nov-2009
        //      Added Contract_no
        //      [Dec-2009] Also added RdNo
		private Metex.Windows.DataEntityGrid grid;
		#region Component Designer generated code
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.post_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_mail_town = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_district = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RdNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.PostCodeType);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.post_code,
            this.post_mail_town,
            this.post_district,
            this.RdNo,
            this.ContractNo});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(681, 360);
            this.grid.TabIndex = 0;
            // 
            // post_code
            // 
            this.post_code.DataPropertyName = "PostCode";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.post_code.DefaultCellStyle = dataGridViewCellStyle2;
            this.post_code.HeaderText = "Post Code:";
            this.post_code.Name = "post_code";
            // 
            // post_mail_town
            // 
            this.post_mail_town.DataPropertyName = "PostMailTown";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.post_mail_town.DefaultCellStyle = dataGridViewCellStyle3;
            this.post_mail_town.HeaderText = "Post Mail Town:";
            this.post_mail_town.Name = "post_mail_town";
            this.post_mail_town.Width = 160;
            // 
            // post_district
            // 
            this.post_district.DataPropertyName = "PostDistrict";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.post_district.DefaultCellStyle = dataGridViewCellStyle4;
            this.post_district.HeaderText = "Post District:";
            this.post_district.Name = "post_district";
            this.post_district.Width = 201;
            // 
            // RdNo
            // 
            this.RdNo.DataPropertyName = "RdNo";
            this.RdNo.HeaderText = "Rd No";
            this.RdNo.Name = "RdNo";
            // 
            // ContractNo
            // 
            this.ContractNo.DataPropertyName = "ContractNo";
            this.ContractNo.HeaderText = "Contract No";
            this.ContractNo.Name = "ContractNo";
            // 
            // DPostCodeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DPostCodeType";
            this.Size = new System.Drawing.Size(681, 360);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn post_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_mail_town;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_district;
        private System.Windows.Forms.DataGridViewTextBoxColumn RdNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractNo;

	}
}
