namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DAllowanceBreakdown
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label compute_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid_to_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn effective_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn annual_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.Panel panel2;

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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.AllowanceBreakdown);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;

            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;//.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 220);
            this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;

            //
            // effective_date
            //
            effective_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effective_date.DataPropertyName = "EffectiveDate";
            this.effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.effective_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.effective_date.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.effective_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.effective_date.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.effective_date.HeaderText = "Effective Date";
            this.effective_date.Name = "effective_date";
            this.effective_date.ReadOnly = true;
            this.effective_date.Width = 82;
            this.grid.Columns.Add(effective_date);

            //
            // paid_to_date
            //
            paid_to_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid_to_date.DataPropertyName = "PaidToDate";
            this.paid_to_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.paid_to_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.paid_to_date.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.paid_to_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.paid_to_date.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.paid_to_date.HeaderText = "Date First Paid";
            this.paid_to_date.Name = "paid_to_date";
            this.paid_to_date.ReadOnly = true;
            this.paid_to_date.Width = 105;
            this.grid.Columns.Add(paid_to_date);

            //
            // annual_amount
            //
            annual_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.annual_amount.DataPropertyName = "AnnualAmount";
            this.annual_amount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.annual_amount.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.annual_amount.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.annual_amount.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.annual_amount.DefaultCellStyle.Format = "$#,##0.00;$-#,##0.00";
            this.annual_amount.HeaderText = "Annual Amount";
            this.annual_amount.Name = "annual_amount";
            this.annual_amount.ReadOnly = true;
            this.annual_amount.Width = 105;
            this.grid.Columns.Add(annual_amount);

            // 
            // panel2
            // 
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(187, 230);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 1);
            this.panel2.TabIndex = 6;

            //
            // notes
            //
            notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes.DataPropertyName = "Notes";
            this.notes.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.notes.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.notes.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.notes.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.notes.HeaderText = "Notes";
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            this.notes.Width = 769;
            this.grid.Columns.Add(notes);

            //
            // compute_1
            //
            this.compute_1 = new System.Windows.Forms.Label();
            //this.compute_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compute_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.compute_1.ForeColor = System.Drawing.Color.Black;
            this.compute_1.Location = new System.Drawing.Point(187, 230);
            this.compute_1.Name = "compute_1";
            this.compute_1.Size = new System.Drawing.Size(100, 20);
            this.compute_1.TabIndex = 1;
            this.compute_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.compute_1.DataBindings["Text"].FormatString = "$#,##0.00" ;// this.compute_1.Mask = "$#,##0.00";//.DataBindings[0].FormatString = "$#,##0.00";

            this.Controls.Add(grid);
            this.Controls.Add(panel2);
            this.Controls.Add(compute_1);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
        }

        #endregion
    }
}
