namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DPieceRateBreakdown
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox compute_1;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn piece_rate_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_rate;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRateBreakdown);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
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

            //
            // piece_rate_description
            //
            piece_rate_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piece_rate_description.DataPropertyName = "PieceRateDescription";
            this.piece_rate_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.piece_rate_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.piece_rate_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.piece_rate_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.piece_rate_description.HeaderText = "Description";
            this.piece_rate_description.Name = "piece_rate_description";
            this.piece_rate_description.ReadOnly = true;
            this.piece_rate_description.Width = 141;            
            this.grid.Columns.Add(piece_rate_description);

            //
            // prd_quantity
            //
            prd_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_quantity.DataPropertyName = "PrdQuantity";
            this.prd_quantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.prd_quantity.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.prd_quantity.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prd_quantity.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prd_quantity.DefaultCellStyle.Format = "#,##0";
            this.prd_quantity.HeaderText = "Quantity";
            this.prd_quantity.Name = "prd_quantity";
            this.prd_quantity.ReadOnly = true;
            this.prd_quantity.Width = 60;
            this.grid.Columns.Add(prd_quantity);

            //
            // pr_rate
            //
            pr_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_rate.DataPropertyName = "PrRate";
            this.pr_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pr_rate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.pr_rate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pr_rate.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.pr_rate.DefaultCellStyle.Format = "#,##0.00";
            this.pr_rate.HeaderText = "Cost";
            this.pr_rate.Name = "pr_rate";
            this.pr_rate.ReadOnly = true;
            this.pr_rate.Width = 60;
            this.grid.Columns.Add(pr_rate);

            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.TextBox();
            this.compute_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compute_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.compute_1.ForeColor = System.Drawing.Color.Black;
            //this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.compute_1.Name = "compute_1";
            //this.compute_1.Location = new System.Drawing.Point(145,0);
            this.compute_1.Left = 27;            
            this.compute_1.Size = new System.Drawing.Size(60, 20);                     
            this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_1.ReadOnly = true;
            this.compute_1.BackColor = System.Drawing.SystemColors.Control;
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // compute_2
            //
            compute_2 = new System.Windows.Forms.TextBox();
            this.compute_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compute_2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.compute_2.ForeColor = System.Drawing.Color.Black;
            //this.compute_2.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.compute_2.Name = "compute_2";
            this.compute_2.Location = new System.Drawing.Point(88,0);
            this.compute_2.Size = new System.Drawing.Size(60, 20);            
            this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_2.ReadOnly = true;
            this.compute_2.BackColor = System.Drawing.SystemColors.Control;
            this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            //this.Size = new System.Drawing.Size(638, 252);
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(82439147);            
            this.Controls.Add(compute_1);
            this.Controls.Add(compute_2);
            this.Controls.Add(grid);

        }
        #endregion

    }
}
