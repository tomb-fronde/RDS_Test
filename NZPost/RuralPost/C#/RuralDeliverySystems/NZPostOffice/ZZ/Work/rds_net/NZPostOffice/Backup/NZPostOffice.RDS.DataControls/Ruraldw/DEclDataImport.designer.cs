namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DEclDataImport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_run_id;
        /*private Metex.Windows.DataGridViewEntityComboColumn  prt_key;*/
	
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.ecl_batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_customer_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_ticket_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_ticket_part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_driver_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_rate_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_rate_descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_pkg_descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_batch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_run_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_driver_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_date_entered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_ticket_payable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_rural_payable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_scan_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_sig_req_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_sig_captured = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_sig_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_pr_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecl_ro5_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.EclDataImport);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 40;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ecl_batch_no,
            this.ecl_customer_name,
            this.ecl_customer_code,
            this.ecl_ticket_no,
            this.ecl_ticket_part,
            this.ecl_seq,
            this.ecl_driver_id,
            this.ecl_rate_code,
            this.ecl_rate_descr,
            this.ecl_pkg_descr,
            this.ecl_batch_id,
            this.ecl_run_no,
            this.ecl_driver_date,
            this.ecl_date_entered,
            this.ecl_ticket_payable,
            this.ecl_rural_payable,
            this.ecl_scan_count,
            this.ecl_sig_req_flag,
            this.ecl_sig_captured,
            this.ecl_sig_name,
            this.ecl_pr_code,
            this.ecl_ro5_flag});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1071, 252);
            this.grid.TabIndex = 0;
            // 
            // ecl_batch_no
            // 
            this.ecl_batch_no.DataPropertyName = "EclBatchNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.ecl_batch_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.ecl_batch_no.HeaderText = "Batch No";
            this.ecl_batch_no.Name = "ecl_batch_no";
            this.ecl_batch_no.ReadOnly = true;
            this.ecl_batch_no.Width = 52;
            // 
            // ecl_customer_name
            // 
            this.ecl_customer_name.DataPropertyName = "EclCustomerName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.ecl_customer_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.ecl_customer_name.HeaderText = "Customer Name";
            this.ecl_customer_name.Name = "ecl_customer_name";
            this.ecl_customer_name.ReadOnly = true;
            this.ecl_customer_name.Width = 140;
            // 
            // ecl_customer_code
            // 
            this.ecl_customer_code.DataPropertyName = "EclCustomerCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.ecl_customer_code.DefaultCellStyle = dataGridViewCellStyle4;
            this.ecl_customer_code.HeaderText = "Customer Code";
            this.ecl_customer_code.Name = "ecl_customer_code";
            this.ecl_customer_code.ReadOnly = true;
            this.ecl_customer_code.Width = 72;
            // 
            // ecl_ticket_no
            // 
            this.ecl_ticket_no.DataPropertyName = "EclTicketNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.ecl_ticket_no.DefaultCellStyle = dataGridViewCellStyle5;
            this.ecl_ticket_no.HeaderText = "Ticket No";
            this.ecl_ticket_no.Name = "ecl_ticket_no";
            this.ecl_ticket_no.ReadOnly = true;
            this.ecl_ticket_no.Width = 120;
            // 
            // ecl_ticket_part
            // 
            this.ecl_ticket_part.DataPropertyName = "EclTicketPart";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.ecl_ticket_part.DefaultCellStyle = dataGridViewCellStyle6;
            this.ecl_ticket_part.HeaderText = "Ticket Part";
            this.ecl_ticket_part.Name = "ecl_ticket_part";
            this.ecl_ticket_part.ReadOnly = true;
            this.ecl_ticket_part.Width = 50;
            // 
            // ecl_seq
            // 
            this.ecl_seq.DataPropertyName = "EclSeq";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.ecl_seq.DefaultCellStyle = dataGridViewCellStyle7;
            this.ecl_seq.HeaderText = "Seq";
            this.ecl_seq.Name = "ecl_seq";
            this.ecl_seq.ReadOnly = true;
            this.ecl_seq.Width = 90;
            // 
            // ecl_driver_id
            // 
            this.ecl_driver_id.DataPropertyName = "EclDriverId";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.ecl_driver_id.DefaultCellStyle = dataGridViewCellStyle8;
            this.ecl_driver_id.HeaderText = "Driver Id";
            this.ecl_driver_id.Name = "ecl_driver_id";
            this.ecl_driver_id.ReadOnly = true;
            this.ecl_driver_id.Width = 52;
            // 
            // ecl_rate_code
            // 
            this.ecl_rate_code.DataPropertyName = "EclRateCode";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.ecl_rate_code.DefaultCellStyle = dataGridViewCellStyle9;
            this.ecl_rate_code.HeaderText = "Rate Code";
            this.ecl_rate_code.Name = "ecl_rate_code";
            this.ecl_rate_code.ReadOnly = true;
            this.ecl_rate_code.Width = 52;
            // 
            // ecl_rate_descr
            // 
            this.ecl_rate_descr.DataPropertyName = "EclRateDescr";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.ecl_rate_descr.DefaultCellStyle = dataGridViewCellStyle10;
            this.ecl_rate_descr.HeaderText = "Rate Descr";
            this.ecl_rate_descr.Name = "ecl_rate_descr";
            this.ecl_rate_descr.Width = 128;
            // 
            // ecl_pkg_descr
            // 
            this.ecl_pkg_descr.DataPropertyName = "EclPkgDescr";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.ecl_pkg_descr.DefaultCellStyle = dataGridViewCellStyle11;
            this.ecl_pkg_descr.HeaderText = "Pkg Descr";
            this.ecl_pkg_descr.Name = "ecl_pkg_descr";
            this.ecl_pkg_descr.Width = 108;
            // 
            // ecl_batch_id
            // 
            this.ecl_batch_id.DataPropertyName = "EclBatchId";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.ecl_batch_id.DefaultCellStyle = dataGridViewCellStyle12;
            this.ecl_batch_id.HeaderText = "Batch Id";
            this.ecl_batch_id.Name = "ecl_batch_id";
            this.ecl_batch_id.ReadOnly = true;
            this.ecl_batch_id.Width = 72;
            // 
            // ecl_run_no
            // 
            this.ecl_run_no.DataPropertyName = "EclRunNo";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.ecl_run_no.DefaultCellStyle = dataGridViewCellStyle13;
            this.ecl_run_no.HeaderText = "Run No";
            this.ecl_run_no.Name = "ecl_run_no";
            this.ecl_run_no.ReadOnly = true;
            this.ecl_run_no.Width = 67;
            // 
            // ecl_driver_date
            // 
            this.ecl_driver_date.DataPropertyName = "EclDriverDate";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.ecl_driver_date.DefaultCellStyle = dataGridViewCellStyle14;
            this.ecl_driver_date.HeaderText = "Driver Date";
            this.ecl_driver_date.Name = "ecl_driver_date";
            this.ecl_driver_date.ReadOnly = true;
            this.ecl_driver_date.Width = 120;
            // 
            // ecl_date_entered
            // 
            this.ecl_date_entered.DataPropertyName = "EclDateEntered";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.ecl_date_entered.DefaultCellStyle = dataGridViewCellStyle15;
            this.ecl_date_entered.HeaderText = "Date Entered";
            this.ecl_date_entered.Name = "ecl_date_entered";
            this.ecl_date_entered.ReadOnly = true;
            this.ecl_date_entered.Width = 120;
            // 
            // ecl_ticket_payable
            // 
            this.ecl_ticket_payable.DataPropertyName = "EclTicketPayable";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.ecl_ticket_payable.DefaultCellStyle = dataGridViewCellStyle16;
            this.ecl_ticket_payable.HeaderText = "Ticket Payable";
            this.ecl_ticket_payable.Name = "ecl_ticket_payable";
            this.ecl_ticket_payable.ReadOnly = true;
            this.ecl_ticket_payable.Width = 50;
            // 
            // ecl_rural_payable
            // 
            this.ecl_rural_payable.DataPropertyName = "EclRuralPayable";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            this.ecl_rural_payable.DefaultCellStyle = dataGridViewCellStyle17;
            this.ecl_rural_payable.HeaderText = "Rural Payable";
            this.ecl_rural_payable.Name = "ecl_rural_payable";
            this.ecl_rural_payable.ReadOnly = true;
            this.ecl_rural_payable.Width = 50;
            // 
            // ecl_scan_count
            // 
            this.ecl_scan_count.DataPropertyName = "EclScanCount";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.ecl_scan_count.DefaultCellStyle = dataGridViewCellStyle18;
            this.ecl_scan_count.HeaderText = "Scan Count";
            this.ecl_scan_count.Name = "ecl_scan_count";
            this.ecl_scan_count.ReadOnly = true;
            this.ecl_scan_count.Width = 50;
            // 
            // ecl_sig_req_flag
            // 
            this.ecl_sig_req_flag.DataPropertyName = "EclSigReqFlag";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            this.ecl_sig_req_flag.DefaultCellStyle = dataGridViewCellStyle19;
            this.ecl_sig_req_flag.HeaderText = "Sig Req Flag";
            this.ecl_sig_req_flag.Name = "ecl_sig_req_flag";
            this.ecl_sig_req_flag.ReadOnly = true;
            this.ecl_sig_req_flag.Width = 92;
            // 
            // ecl_sig_captured
            // 
            this.ecl_sig_captured.DataPropertyName = "EclSigCaptured";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            this.ecl_sig_captured.DefaultCellStyle = dataGridViewCellStyle20;
            this.ecl_sig_captured.HeaderText = "Sig Captured";
            this.ecl_sig_captured.Name = "ecl_sig_captured";
            this.ecl_sig_captured.ReadOnly = true;
            this.ecl_sig_captured.Width = 94;
            // 
            // ecl_sig_name
            // 
            this.ecl_sig_name.DataPropertyName = "EclSigName";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            this.ecl_sig_name.DefaultCellStyle = dataGridViewCellStyle21;
            this.ecl_sig_name.HeaderText = "Sig Name";
            this.ecl_sig_name.Name = "ecl_sig_name";
            this.ecl_sig_name.ReadOnly = true;
            this.ecl_sig_name.Width = 108;
            // 
            // ecl_pr_code
            // 
            this.ecl_pr_code.DataPropertyName = "EclPrCode";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            this.ecl_pr_code.DefaultCellStyle = dataGridViewCellStyle22;
            this.ecl_pr_code.HeaderText = "Pr Code";
            this.ecl_pr_code.Name = "ecl_pr_code";
            this.ecl_pr_code.ReadOnly = true;
            this.ecl_pr_code.Width = 64;
            // 
            // ecl_ro5_flag
            // 
            this.ecl_ro5_flag.DataPropertyName = "EclRo5Flag";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            this.ecl_ro5_flag.DefaultCellStyle = dataGridViewCellStyle22;
            this.ecl_ro5_flag.HeaderText = "RO5 Flag";
            this.ecl_ro5_flag.Name = "ecl_ro5_flag";
            this.ecl_ro5_flag.ReadOnly = true;
            this.ecl_ro5_flag.Width = 64;
            // 
            // DEclDataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "DEclDataImport";
            this.Size = new System.Drawing.Size(1071, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
                return;
            if (e.NewIndex < 0 || e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
                return;
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                return;
            }
/*
            else
            {
                if (((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).ContractNo == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[0])).ContractNo == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).PrtCode == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[0])).PrtCode == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).PrdDate == null ||
                    ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[0])).PrdDate == null)
                {
                    ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).Nextdup = null;
                }
                else
                {
                    if (((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).ContractNo == ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[0])).ContractNo
                        && ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).PrtCode == ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[0])).PrtCode
                        && ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).PrdDate == ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[0])).PrdDate)
                    {
                        ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).Nextdup = "Y";
                    }
                    else
                    {
                        ((NZPostOffice.RDS.Entity.Ruraldw.EclDataImport)(bindingSource.List[e.NewIndex])).Nextdup = "N";
                    }
                }
            }
 */
        }
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_customer_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_ticket_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_ticket_part;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_driver_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_rate_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_rate_descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_pkg_descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_batch_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_run_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_driver_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_date_entered;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_ticket_payable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_rural_payable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_scan_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_sig_req_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_sig_captured;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_sig_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_pr_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecl_ro5_flag;
    }
}
