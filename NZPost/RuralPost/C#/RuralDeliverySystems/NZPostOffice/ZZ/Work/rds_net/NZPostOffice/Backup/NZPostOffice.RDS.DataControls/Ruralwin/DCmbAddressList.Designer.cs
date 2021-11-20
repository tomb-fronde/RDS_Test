namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DCmbAddressList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmb_box_no;
        private System.Windows.Forms.TextBox cmbs_found;
        private System.Windows.Forms.DataGridViewTextBoxColumn tc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn adr_rd_no;


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
            components = new System.ComponentModel.Container();
            grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.CmbAddressList);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 232);
            this.grid.TabIndex = 0;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;

            //
            // cmb_box_no
            //
            cmb_box_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_box_no.DataPropertyName = "CmbBoxNo";
            this.cmb_box_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cmb_box_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmb_box_no.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmb_box_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.cmb_box_no.HeaderText = "Box No";
            this.cmb_box_no.Name = "cmb_box_no";
            this.cmb_box_no.ReadOnly = true;
            this.cmb_box_no.Width = 60;
            this.grid.Columns.Add(cmb_box_no);

            //
            // adr_rd_no
            //
            adr_rd_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adr_rd_no.DataPropertyName = "AdrRdNo";
            this.adr_rd_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.adr_rd_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.adr_rd_no.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.adr_rd_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.adr_rd_no.HeaderText = "RD";
            this.adr_rd_no.Name = "adr_rd_no";
            this.adr_rd_no.ReadOnly = true;
            this.adr_rd_no.Width = 36;
            this.grid.Columns.Add(adr_rd_no);

            //
            // tc_name
            //
            tc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc_name.DataPropertyName = "TcName";
            this.tc_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.tc_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tc_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tc_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.tc_name.HeaderText = "Mailtown";
            this.tc_name.Name = "tc_name";
            this.tc_name.ReadOnly = true;
            this.tc_name.Width = 133;
            this.grid.Columns.Add(tc_name);

            //
            // post_code
            //
            post_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_code.DataPropertyName = "PostCode";
            this.post_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.post_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.post_code.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.post_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.post_code.HeaderText = "Postcode";
            this.post_code.Name = "post_code";
            this.post_code.ReadOnly = true;
            this.post_code.Width = 63;
            this.grid.Columns.Add(post_code);

            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_1.DataPropertyName = "Compute1";
            this.compute_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.compute_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_1.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_1.HeaderText = "CMB Customer";
            this.compute_1.Name = "compute_1";
            this.compute_1.Width = 238;
            this.compute_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid.Columns.Add(compute_1);

            //
            // cmbs_found
            //
            this.cmbs_found = new System.Windows.Forms.TextBox();
            this.cmbs_found.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbs_found.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.cmbs_found.ForeColor = System.Drawing.Color.Black;
            this.cmbs_found.Location = new System.Drawing.Point(107, 236);
            this.cmbs_found.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmbs_found.Name = "cmbs_found";
            this.cmbs_found.BackColor = System.Drawing.SystemColors.Control;
            this.cmbs_found.Size = new System.Drawing.Size(95, 20);
            this.cmbs_found.TabIndex = 1;
            this.cmbs_found.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(grid);
            this.Controls.Add(cmbs_found);
        }
        #endregion

    }
}
