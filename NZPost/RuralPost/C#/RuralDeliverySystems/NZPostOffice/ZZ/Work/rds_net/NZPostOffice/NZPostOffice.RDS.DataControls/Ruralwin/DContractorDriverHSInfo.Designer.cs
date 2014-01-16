namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DContractorDriverHSInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            this.driver_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hst_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsi_date_checked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsi_passfail_ind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_add = new System.Windows.Forms.Button();
            this.cb_remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.ContractorDriverHSInfo);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.driver_name,
            this.hst_name,
            this.hsi_date_checked,
            this.hsi_passfail_ind,
            this.driver_no});
            this.grid.DataSource = this.bindingSource;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 16;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 257);
            this.grid.TabIndex = 0;
            // 
            // driver_name
            // 
            this.driver_name.DataPropertyName = "DriverName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.driver_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.driver_name.HeaderText = "Driver";
            this.driver_name.Name = "driver_name";
            this.driver_name.ReadOnly = true;
            this.driver_name.Width = 160;
            // 
            // hst_name
            // 
            this.hst_name.DataPropertyName = "HstName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hst_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.hst_name.HeaderText = "H&S Type";
            this.hst_name.Name = "hst_name";
            this.hst_name.ReadOnly = true;
            this.hst_name.Width = 160;
            // 
            // hsi_date_checked
            // 
            this.hsi_date_checked.DataPropertyName = "HsiDateChecked";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hsi_date_checked.DefaultCellStyle = dataGridViewCellStyle4;
            this.hsi_date_checked.HeaderText = "Date Checked";
            this.hsi_date_checked.Name = "hsi_date_checked";
            this.hsi_date_checked.ReadOnly = true;
            this.hsi_date_checked.Width = 80;
            // 
            // hsi_passfail_ind
            // 
            this.hsi_passfail_ind.DataPropertyName = "HsiPassfailInd";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hsi_passfail_ind.DefaultCellStyle = dataGridViewCellStyle5;
            this.hsi_passfail_ind.HeaderText = "Pass/Fail";
            this.hsi_passfail_ind.Name = "hsi_passfail_ind";
            this.hsi_passfail_ind.ReadOnly = true;
            this.hsi_passfail_ind.Width = 63;
            // 
            // driver_no
            // 
            this.driver_no.DataPropertyName = "DriverNo";
            this.driver_no.HeaderText = "DriverNo";
            this.driver_no.Name = "driver_no";
            this.driver_no.Visible = false;
            // 
            // cb_add
            // 
            this.cb_add.Location = new System.Drawing.Point(473, 196);
            this.cb_add.Name = "cb_add";
            this.cb_add.Size = new System.Drawing.Size(75, 23);
            this.cb_add.TabIndex = 1;
            this.cb_add.Text = "Add";
            this.cb_add.UseVisualStyleBackColor = true;
            this.cb_add.Click += new System.EventHandler(this.cb_add_Click);
            // 
            // cb_remove
            // 
            this.cb_remove.Location = new System.Drawing.Point(473, 228);
            this.cb_remove.Name = "cb_remove";
            this.cb_remove.Size = new System.Drawing.Size(75, 23);
            this.cb_remove.TabIndex = 2;
            this.cb_remove.Text = "Remove";
            this.cb_remove.UseVisualStyleBackColor = true;
            this.cb_remove.Click += new System.EventHandler(this.cb_remove_Click);
            // 
            // DContractorDriverHSInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.cb_remove);
            this.Controls.Add(this.cb_add);
            this.Controls.Add(this.grid);
            this.Name = "DContractorDriverHSInfo";
            this.Size = new System.Drawing.Size(638, 260);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button cb_add;
        private System.Windows.Forms.Button cb_remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn hst_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsi_date_checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsi_passfail_ind;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_no;



    }
}
