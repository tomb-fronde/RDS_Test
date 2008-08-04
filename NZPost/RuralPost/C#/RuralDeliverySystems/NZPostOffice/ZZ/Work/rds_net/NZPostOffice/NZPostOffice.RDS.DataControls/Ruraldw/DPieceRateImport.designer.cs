namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DPieceRateImport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn  totalcost;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract;
		private System.Windows.Forms.DataGridViewTextBoxColumn  prt_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn  prd_quantity;
		private System.Windows.Forms.DataGridViewTextBoxColumn  prd_date;
		private Metex.Windows.DataGridViewEntityComboColumn  prt_key;
		private System.Windows.Forms.DataGridViewTextBoxColumn  prd_cost;
		private System.Windows.Forms.DataGridViewTextBoxColumn  nextdup;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport);
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
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.grid.TabIndex = 0;
			//
			// contract
			//
			contract= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract.DataPropertyName = "Contract";
			this.contract.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.contract.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contract.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contract.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contract.HeaderText = "Contract";
			this.contract.Name = "contract";
			this.contract.ReadOnly = true;
			this.contract.Width = 50;
			this.grid.Columns.Add(contract);
			//
			// prd_date
			//
			prd_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.prd_date.DataPropertyName = "PrdDate";
			this.prd_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.prd_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.prd_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.prd_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prd_date.HeaderText = "Date";
			this.prd_date.Name = "prd_date";
			this.prd_date.ReadOnly = true;
			this.prd_date.Width = 68;
			this.grid.Columns.Add(prd_date);
            //
            // prt_code
            //
            prt_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prt_code.DataPropertyName = "PrtCode";
            this.prt_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prt_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prt_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prt_code.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prt_code.HeaderText = "Code";
            this.prt_code.Name = "prt_code";
            this.prt_code.ReadOnly = true;
            this.prt_code.Width = 42;
            this.grid.Columns.Add(prt_code);
            //
            // prd_quantity
            //
            prd_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_quantity.DataPropertyName = "PrdQuantity";
            this.prd_quantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.prd_quantity.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prd_quantity.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prd_quantity.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prd_quantity.HeaderText = "Quantity";
            this.prd_quantity.Name = "prd_quantity";
            this.prd_quantity.ReadOnly = true;
            this.prd_quantity.Width = 50;
            this.grid.Columns.Add(prd_quantity);
            //
            // prd_cost
            //
            prd_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_cost.DataPropertyName = "PrdCost";
            this.prd_cost.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.prd_cost.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prd_cost.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prd_cost.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prd_cost.DefaultCellStyle.Format = "#,##0.00";
            this.prd_cost.HeaderText = "Cost";
            this.prd_cost.Name = "prd_cost";
            this.prd_cost.ReadOnly = true;
            this.prd_cost.Width = 56;
            this.grid.Columns.Add(prd_cost);
            //
            // prt_key
            //
            prt_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.prt_key.DataPropertyName = "PrtKey";
            this.prt_key.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prt_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prt_key.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prt_key.HeaderText = "Piece Rate";
            this.prt_key.Name = "prt_key";
            this.prt_key.Width = 172;
            this.prt_key.DisplayMember = "PrtDescription";
            this.prt_key.ValueMember = "PrtKey";
            this.prt_key.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
           // this.prt_key.ReadOnly = true;
            this.grid.Columns.Add(prt_key);
            //
            // totalcost
            //
            totalcost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalcost.DataPropertyName = "Totalcost";
            this.totalcost.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.totalcost.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.totalcost.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.totalcost.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.totalcost.HeaderText = "";
            this.totalcost.Name = "totalcost";
            this.totalcost.Width = 39;
            this.totalcost.Visible = false;
            this.grid.Columns.Add(totalcost);
			//
			// nextdup
			//
			nextdup= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nextdup.DataPropertyName = "Nextdup";
			this.nextdup.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.nextdup.DefaultCellStyle.BackColor = System.Drawing.Color.White;
			this.nextdup.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.nextdup.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nextdup.HeaderText = "";
			this.nextdup.Name = "nextdup";
			this.nextdup.Width = 39;
            this.nextdup.Visible = false;
			this.grid.Columns.Add(nextdup);
			//
			// contract_no
			//
			contract_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract_no.DataPropertyName = "ContractNo";
			this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contract_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.contract_no.HeaderText = "";
			this.contract_no.Name = "contract_no";
			this.contract_no.ReadOnly = true;
            this.contract_no.Visible = false;
			this.contract_no.Width = 67;
			this.grid.Columns.Add(contract_no);
            
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
		}

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
                return;
            //if((contract_no = contract_no[1] and  prt_code =  prt_code [1] and  prd_date =  prd_date[1]),'Y','N')
            if (e.NewIndex < 0 || e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
                return;
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                return;
            }
            else
            {
                if (((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).ContractNo == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[0])).ContractNo == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).PrtCode == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[0])).PrtCode == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).PrdDate == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[0])).PrdDate == null)
                {
                    ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).Nextdup = null;
                }
                else
                {
                    if (((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).ContractNo == ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[0])).ContractNo
                        && ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).PrtCode == ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[0])).PrtCode
                        && ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).PrdDate == ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[0])).PrdDate)
                    {
                        ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).Nextdup = "Y";
                    }
                    else
                    {
                        ((NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport)(bindingSource.List[e.NewIndex])).Nextdup = "N";
                    }
                }
            }
        }
		#endregion

	}
}
