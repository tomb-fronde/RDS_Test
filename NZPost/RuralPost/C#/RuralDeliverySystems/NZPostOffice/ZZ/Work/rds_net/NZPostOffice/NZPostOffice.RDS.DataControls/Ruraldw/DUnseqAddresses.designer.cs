namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DUnseqAddresses
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sequence;
		private System.Windows.Forms.DataGridViewTextBoxColumn  adr_num_alpha;
		private System.Windows.Forms.DataGridViewTextBoxColumn  customer;
		private System.Windows.Forms.DataGridViewTextBoxColumn  adr_no_numeric;
		private System.Windows.Forms.DataGridViewTextBoxColumn  road_name;

        private System.Windows.Forms.DataGridViewTextBoxColumn adr_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn address_adr_alpha;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivery_sequence;
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.UnseqAddresses);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;            
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			//this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.MultiSelect = true;
            //
            // sequence
            //
            sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequence.DataPropertyName = "Sequence";
            this.sequence.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sequence.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sequence.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.sequence.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sequence.HeaderText = "Seq";
            this.sequence.Name = "sequence";
            this.sequence.Width = 29;
            this.grid.Columns.Add(sequence);
            //
            // adr_num_alpha
            //
            adr_num_alpha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adr_num_alpha.DataPropertyName = "AdrNumAlpha";
            this.adr_num_alpha.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.adr_num_alpha.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.adr_num_alpha.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.adr_num_alpha.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_num_alpha.HeaderText = "Road Num";
            this.adr_num_alpha.Name = "adr_num_alpha";
            this.adr_num_alpha.ReadOnly = true;
            this.adr_num_alpha.Width = 64;
           
            this.grid.Columns.Add(adr_num_alpha);

			//
			// adr_no_numeric
			//
			adr_no_numeric= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adr_no_numeric.DataPropertyName = "AdrNoNumeric";
			this.adr_no_numeric.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.adr_no_numeric.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
            //this.adr_no_numeric.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.adr_no_numeric.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.adr_no_numeric.HeaderText = "Road Num";
			this.adr_no_numeric.Name = "adr_no_numeric";
			this.adr_no_numeric.Width = 63;
            this.adr_no_numeric.Visible = false;
			this.grid.Columns.Add(adr_no_numeric);


			//
			// road_name
			//
			road_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.road_name.DataPropertyName = "RoadName";
			this.road_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.road_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.road_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.road_name.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.road_name.HeaderText = "Road Name";
			this.road_name.Name = "road_name";
			this.road_name.ReadOnly = true;
			this.road_name.Width = 159;
			this.grid.Columns.Add(road_name);


			//
			// customer
			//
			customer= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.customer.DataPropertyName = "Customer";
			this.customer.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.customer.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.customer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.customer.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.customer.HeaderText = "Customer";
            this.customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.customer.Name = "customer";
			this.customer.ReadOnly = true;
			this.customer.Width = 224;
			this.grid.Columns.Add(customer);

			
            //
            // adr_no
            //
            adr_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adr_no.DataPropertyName = "AdrNo";
            this.adr_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.adr_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.adr_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.adr_no.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_no.HeaderText = "";
            this.adr_no.Name = "adr_no";
            this.adr_no.ReadOnly = true;
            this.adr_no.Width = 224;
            this.adr_no.Visible = false;
            this.grid.Columns.Add(adr_no);
            //
            // address_adr_alpha
            //
            address_adr_alpha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address_adr_alpha.DataPropertyName = "AddressAdrAlpha";
            this.address_adr_alpha.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.address_adr_alpha.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.address_adr_alpha.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.address_adr_alpha.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.address_adr_alpha.HeaderText = "";
            this.address_adr_alpha.Name = "address_adr_alpha";
            this.address_adr_alpha.ReadOnly = true;
            this.address_adr_alpha.Width = 224;
            this.address_adr_alpha.Visible = false;
            this.grid.Columns.Add(address_adr_alpha);
            //
            // delivery_sequence
            //
            delivery_sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delivery_sequence.DataPropertyName = "DeliverySequence";
            this.delivery_sequence.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.delivery_sequence.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.delivery_sequence.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.delivery_sequence.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.delivery_sequence.HeaderText = "";
            this.delivery_sequence.Name = "delivery_sequence";
            this.delivery_sequence.ReadOnly = true;
            this.delivery_sequence.Width = 224;
            this.delivery_sequence.Visible = false;
            this.grid.Columns.Add(delivery_sequence);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(grid);
		}
		#endregion

	}
}
