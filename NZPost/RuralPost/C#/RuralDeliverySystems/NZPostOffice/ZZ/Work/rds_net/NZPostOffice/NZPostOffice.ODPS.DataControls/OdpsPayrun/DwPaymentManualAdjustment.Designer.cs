namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwPaymentManualAdjustment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn ded_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;

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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.PaymentManualAdjustment);

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
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            dataGridViewCellStyle.BackColor = System.Drawing.Color.White;
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
            // cname
            //
            cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname.DataPropertyName = "Cname";
            this.cname.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cname.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cname.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.cname.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.cname.HeaderText = "Contractor";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            this.cname.Width = 74;
            this.grid.Columns.Add(cname);
       
            //
            // ded_id
            //
            ded_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ded_id.DataPropertyName = "DedId";
            this.ded_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ded_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ded_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_id.HeaderText = "Deduction ID";
            this.ded_id.Name = "ded_id";
            this.ded_id.ReadOnly = true;
            this.ded_id.Width = 74;
            this.grid.Columns.Add(ded_id);


            //
            // comments
            //
            comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments.DataPropertyName = "Comments";
            this.comments.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.comments.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.comments.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.comments.HeaderText = "Comments";
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            this.comments.Width = 451;
            this.grid.Columns.Add(comments);

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
