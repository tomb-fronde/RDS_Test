namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_054  July-2013
    // Changed alignment of prt_key header (to MiddleLeft; was unspecified)

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
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextdup;

	
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.contract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prt_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prt_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.totalcost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextdup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRateImport);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
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
            this.contract,
            this.prd_date,
            this.prt_code,
            this.prd_quantity,
            this.prd_cost,
            this.prt_key,
            this.totalcost,
            this.nextdup,
            this.contract_no});
            this.grid.DataSource = this.bindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle11;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            // 
            // contract
            // 
            this.contract.DataPropertyName = "Contract";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.contract.DefaultCellStyle = dataGridViewCellStyle2;
            this.contract.HeaderText = "Contract";
            this.contract.Name = "contract";
            this.contract.ReadOnly = true;
            this.contract.Width = 50;
            // 
            // prd_date
            // 
            this.prd_date.DataPropertyName = "PrdDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.prd_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.prd_date.HeaderText = "Date";
            this.prd_date.Name = "prd_date";
            this.prd_date.ReadOnly = true;
            this.prd_date.Width = 68;
            // 
            // prt_code
            // 
            this.prt_code.DataPropertyName = "PrtCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.prt_code.DefaultCellStyle = dataGridViewCellStyle4;
            this.prt_code.HeaderText = "Code";
            this.prt_code.Name = "prt_code";
            this.prt_code.ReadOnly = true;
            this.prt_code.Width = 42;
            // 
            // prd_quantity
            // 
            this.prd_quantity.DataPropertyName = "PrdQuantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.prd_quantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.prd_quantity.HeaderText = "Quantity";
            this.prd_quantity.Name = "prd_quantity";
            this.prd_quantity.ReadOnly = true;
            this.prd_quantity.Width = 50;
            // 
            // prd_cost
            // 
            this.prd_cost.DataPropertyName = "PrdCost";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "#,##0.00";
            this.prd_cost.DefaultCellStyle = dataGridViewCellStyle6;
            this.prd_cost.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.prd_cost.HeaderText = "Cost";
            this.prd_cost.Name = "prd_cost";
            this.prd_cost.ReadOnly = true;
            this.prd_cost.Width = 56;
            // 
            // prt_key
            // 
            this.prt_key.DataPropertyName = "PrtKey";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.prt_key.DefaultCellStyle = dataGridViewCellStyle7;
            this.prt_key.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.prt_key.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prt_key.HeaderText = "Piece Rate";
            this.prt_key.Name = "prt_key";
            this.prt_key.Width = 172;
            // 
            // totalcost
            // 
            this.totalcost.DataPropertyName = "Totalcost";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.totalcost.DefaultCellStyle = dataGridViewCellStyle8;
            this.totalcost.HeaderText = "";
            this.totalcost.Name = "totalcost";
            this.totalcost.ReadOnly = true;
            this.totalcost.Visible = false;
            this.totalcost.Width = 39;
            // 
            // nextdup
            // 
            this.nextdup.DataPropertyName = "Nextdup";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.nextdup.DefaultCellStyle = dataGridViewCellStyle9;
            this.nextdup.HeaderText = "";
            this.nextdup.Name = "nextdup";
            this.nextdup.Visible = false;
            this.nextdup.Width = 39;
            // 
            // contract_no
            // 
            this.contract_no.DataPropertyName = "ContractNo";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle = dataGridViewCellStyle10;
            this.contract_no.HeaderText = "";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Visible = false;
            this.contract_no.Width = 67;
            // 
            // DPieceRateImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "DPieceRateImport";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

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
