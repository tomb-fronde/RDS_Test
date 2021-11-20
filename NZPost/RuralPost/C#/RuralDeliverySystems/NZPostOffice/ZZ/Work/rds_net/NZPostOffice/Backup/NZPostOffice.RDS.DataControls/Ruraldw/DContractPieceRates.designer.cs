using System.Drawing;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractPieceRates
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid_to_date;
        private Metex.Windows.DataGridViewEntityComboColumn prs_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn piece_rate_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn piece_rate_cost;
        private System.Windows.Forms.Label t_1;

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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractPieceRates);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
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
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 15);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(grid);

            //
            // prd_date
            //
            prd_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_date.DataPropertyName = "PrdDate";
            this.prd_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prd_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prd_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prd_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prd_date.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.prd_date.HeaderText = "Date";
            this.prd_date.Name = "prd_date";
            this.prd_date.ReadOnly = true;
            this.prd_date.Width = 75;
            this.grid.Columns.Add(prd_date);

            //
            // prs_key
            //
            prs_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.prs_key.DataPropertyName = "PrsKey";
            this.prs_key.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prs_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prs_key.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prs_key.HeaderText = "Supplier";
            this.prs_key.Name = "d_dddw_piece_rate_suppliers";
            this.prs_key.Width = 136;
            this.prs_key.ValueMember = "PrsKey";
            this.prs_key.DisplayMember = "PrsDescription";
            this.prs_key.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.prs_key.DisplayStyleForCurrentCellOnly = true;
            this.prs_key.ReadOnly = true;
            this.grid.Columns.Add(prs_key);

            //
            // piece_rate_quantity
            //
            piece_rate_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piece_rate_quantity.DataPropertyName = "PieceRateQuantity";
            this.piece_rate_quantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.piece_rate_quantity.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.piece_rate_quantity.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.piece_rate_quantity.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.piece_rate_quantity.HeaderText = "Quantity";
            this.piece_rate_quantity.Name = "piece_rate_quantity";
            this.piece_rate_quantity.ReadOnly = true;
            this.piece_rate_quantity.Width = 48;
            this.grid.Columns.Add(piece_rate_quantity);

            //
            // piece_rate_cost
            //
            piece_rate_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piece_rate_cost.DataPropertyName = "PieceRateCost";
            this.piece_rate_cost.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;//.MiddleLeft;
            this.piece_rate_cost.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.piece_rate_cost.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.piece_rate_cost.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.piece_rate_cost.DefaultCellStyle.Format = "#,##0.00";
            this.piece_rate_cost.HeaderText = "Cost";
            this.piece_rate_cost.Name = "piece_rate_cost";
            this.piece_rate_cost.ReadOnly = true;
            this.piece_rate_cost.Width = 59;
            this.grid.Columns.Add(piece_rate_cost);

            //
            // paid_to_date
            //
            paid_to_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid_to_date.DataPropertyName = "PaidToDate";
            this.paid_to_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.paid_to_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.paid_to_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.paid_to_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.paid_to_date.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.paid_to_date.HeaderText = "Date paid";
            this.paid_to_date.Name = "paid_to_date";
            this.paid_to_date.ReadOnly = true;
            this.paid_to_date.Width = 70;
            this.grid.Columns.Add(paid_to_date);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(1, 1);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(600, 14);
            this.t_1.Text = "Contract:";
            this.t_1.TextAlign = ContentAlignment.MiddleLeft;
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_1);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            // this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SizeChanged += new System.EventHandler(DContractPieceRates_SizeChanged);
        }
        void DContractPieceRates_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left;
            this.grid.Height = this.Height - this.grid.Top;
        }
        #endregion

    }
}
