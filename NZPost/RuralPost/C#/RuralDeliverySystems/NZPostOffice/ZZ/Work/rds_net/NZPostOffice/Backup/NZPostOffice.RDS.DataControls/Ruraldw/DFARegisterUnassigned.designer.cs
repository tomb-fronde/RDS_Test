using System.Drawing;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_026  July-2011: New
    // Grid control to display unassigned fixed assets for WAddFixedAssets

    partial class DFARegisterUnassigned
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Metex.Windows.DataGridViewEntityComboColumn fat_id;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.fa_fixed_asset_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_dddw_fixed_asset_type = new Metex.Windows.DataGridViewEntityComboColumn();
            this.fa_owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa_purchase_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa_purchase_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.FARegisterUnassigned);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
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
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fa_fixed_asset_no,
            this.d_dddw_fixed_asset_type,
            this.fa_owner,
            this.fa_purchase_date,
            this.fa_purchase_price});
            this.grid.DataSource = this.bindingSource;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 18);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 231);
            this.grid.TabIndex = 0;
            // 
            // fa_fixed_asset_no
            // 
            this.fa_fixed_asset_no.DataPropertyName = "FaFixedAssetNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = null;
            this.fa_fixed_asset_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.fa_fixed_asset_no.HeaderText = "Asset";
            this.fa_fixed_asset_no.Name = "fa_fixed_asset_no";
            this.fa_fixed_asset_no.ReadOnly = true;
            this.fa_fixed_asset_no.Width = 80;
            // 
            // d_dddw_fixed_asset_type
            // 
            this.d_dddw_fixed_asset_type.DataPropertyName = "FatId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.d_dddw_fixed_asset_type.DefaultCellStyle = dataGridViewCellStyle3;
            this.d_dddw_fixed_asset_type.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.d_dddw_fixed_asset_type.HeaderText = "Asset Type";
            this.d_dddw_fixed_asset_type.Name = "d_dddw_fixed_asset_type";
            this.d_dddw_fixed_asset_type.ReadOnly = true;
            this.d_dddw_fixed_asset_type.Width = 200;
            // 
            // fa_owner
            // 
            this.fa_owner.DataPropertyName = "FaOwner";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.fa_owner.DefaultCellStyle = dataGridViewCellStyle4;
            this.fa_owner.HeaderText = "Owner";
            this.fa_owner.Name = "fa_owner";
            this.fa_owner.ReadOnly = true;
            this.fa_owner.Width = 120;
            // 
            // fa_purchase_date
            // 
            this.fa_purchase_date.DataPropertyName = "FaPurchaseDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.fa_purchase_date.DefaultCellStyle = dataGridViewCellStyle5;
            this.fa_purchase_date.HeaderText = "Date";
            this.fa_purchase_date.Name = "fa_purchase_date";
            this.fa_purchase_date.ReadOnly = true;
            this.fa_purchase_date.Width = 75;
            // 
            // fa_purchase_price
            // 
            this.fa_purchase_price.DataPropertyName = "FaPurchasePrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "#,##0.00";
            this.fa_purchase_price.DefaultCellStyle = dataGridViewCellStyle6;
            this.fa_purchase_price.HeaderText = "Price";
            this.fa_purchase_price.Name = "fa_purchase_price";
            this.fa_purchase_price.ReadOnly = true;
            this.fa_purchase_price.Width = 59;
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(1, 1);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(600, 14);
            this.t_1.TabIndex = 1;
            this.t_1.Text = "Unassigned Fixed Assets";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DFARegisterUnassigned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.t_1);
            this.Name = "DFARegisterUnassigned";
            this.Size = new System.Drawing.Size(580, 477);
            this.SizeChanged += new System.EventHandler(this.DContractPieceRates_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        void DContractPieceRates_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left;
            this.grid.Height = this.Height - this.grid.Top;
        }
        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn fa_fixed_asset_no;
        private Metex.Windows.DataGridViewEntityComboColumn d_dddw_fixed_asset_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa_owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa_purchase_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa_purchase_price;


    }
}
