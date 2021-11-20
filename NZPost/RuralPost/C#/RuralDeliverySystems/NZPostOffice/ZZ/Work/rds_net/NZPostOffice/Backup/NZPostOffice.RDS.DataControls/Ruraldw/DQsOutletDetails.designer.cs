namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DQsOutletDetails
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		private void InitializeComponent()
		{
            this.gb_details = new System.Windows.Forms.GroupBox();
            this.tb_outlet_name_type = new System.Windows.Forms.TextBox();
            this.tb_outlet_id = new System.Windows.Forms.TextBox();
            this.tb_telephone = new System.Windows.Forms.TextBox();
            this.tb_physical_address = new System.Windows.Forms.TextBox();
            this.tb_postal_address = new System.Windows.Forms.TextBox();
            this.physical_address_t = new System.Windows.Forms.Label();
            this.telephone_t = new System.Windows.Forms.Label();
            this.postal_address_t = new System.Windows.Forms.Label();
            this.details_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.gb_details.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.QsOutletDetails);
            // 
            // gb_details
            // 
            this.gb_details.Controls.Add(this.tb_outlet_name_type);
            this.gb_details.Controls.Add(this.tb_outlet_id);
            this.gb_details.Controls.Add(this.tb_telephone);
            this.gb_details.Controls.Add(this.tb_physical_address);
            this.gb_details.Controls.Add(this.tb_postal_address);
            this.gb_details.Controls.Add(this.physical_address_t);
            this.gb_details.Controls.Add(this.telephone_t);
            this.gb_details.Controls.Add(this.postal_address_t);
            this.gb_details.Controls.Add(this.details_t);
            this.gb_details.Location = new System.Drawing.Point(0, -5);
            this.gb_details.Name = "gb_details";
            this.gb_details.Size = new System.Drawing.Size(325, 229);
            this.gb_details.TabIndex = 0;
            this.gb_details.TabStop = false;
            // 
            // tb_outlet_name_type
            // 
            this.tb_outlet_name_type.BackColor = System.Drawing.SystemColors.Control;
            this.tb_outlet_name_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_outlet_name_type.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ONameType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_outlet_name_type.Location = new System.Drawing.Point(9, 34);
            this.tb_outlet_name_type.Name = "tb_outlet_name_type";
            this.tb_outlet_name_type.ReadOnly = true;
            this.tb_outlet_name_type.Size = new System.Drawing.Size(292, 20);
            this.tb_outlet_name_type.TabIndex = 8;
            // 
            // tb_outlet_id
            // 
            this.tb_outlet_id.BackColor = System.Drawing.SystemColors.Control;
            this.tb_outlet_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_outlet_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutletId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_outlet_id.Location = new System.Drawing.Point(104, 190);
            this.tb_outlet_id.Name = "tb_outlet_id";
            this.tb_outlet_id.ReadOnly = true;
            this.tb_outlet_id.Size = new System.Drawing.Size(100, 20);
            this.tb_outlet_id.TabIndex = 7;
            this.tb_outlet_id.Visible = false;
            // 
            // tb_telephone
            // 
            this.tb_telephone.BackColor = System.Drawing.SystemColors.Control;
            this.tb_telephone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_telephone.Location = new System.Drawing.Point(104, 152);
            this.tb_telephone.Name = "tb_telephone";
            this.tb_telephone.Size = new System.Drawing.Size(197, 20);
            this.tb_telephone.TabIndex = 6;
            // 
            // tb_physical_address
            // 
            this.tb_physical_address.BackColor = System.Drawing.SystemColors.Control;
            this.tb_physical_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_physical_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OPhyAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_physical_address.Location = new System.Drawing.Point(104, 106);
            this.tb_physical_address.Multiline = true;
            this.tb_physical_address.Name = "tb_physical_address";
            this.tb_physical_address.ReadOnly = true;
            this.tb_physical_address.Size = new System.Drawing.Size(197, 40);
            this.tb_physical_address.TabIndex = 5;
            // 
            // tb_postal_address
            // 
            this.tb_postal_address.BackColor = System.Drawing.SystemColors.Control;
            this.tb_postal_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_postal_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_postal_address.Location = new System.Drawing.Point(104, 60);
            this.tb_postal_address.Multiline = true;
            this.tb_postal_address.Name = "tb_postal_address";
            this.tb_postal_address.ReadOnly = true;
            this.tb_postal_address.Size = new System.Drawing.Size(197, 40);
            this.tb_postal_address.TabIndex = 4;
            // 
            // physical_address_t
            // 
            this.physical_address_t.AutoSize = true;
            this.physical_address_t.Location = new System.Drawing.Point(6, 105);
            this.physical_address_t.Name = "physical_address_t";
            this.physical_address_t.Size = new System.Drawing.Size(87, 13);
            this.physical_address_t.TabIndex = 3;
            this.physical_address_t.Text = "Physical Address";
            // 
            // telephone_t
            // 
            this.telephone_t.AutoSize = true;
            this.telephone_t.Location = new System.Drawing.Point(6, 155);
            this.telephone_t.Name = "telephone_t";
            this.telephone_t.Size = new System.Drawing.Size(58, 13);
            this.telephone_t.TabIndex = 2;
            this.telephone_t.Text = "Telephone";
            // 
            // postal_address_t
            // 
            this.postal_address_t.AutoSize = true;
            this.postal_address_t.Location = new System.Drawing.Point(6, 60);
            this.postal_address_t.Name = "postal_address_t";
            this.postal_address_t.Size = new System.Drawing.Size(77, 13);
            this.postal_address_t.TabIndex = 1;
            this.postal_address_t.Text = "Postal Address";
            // 
            // details_t
            // 
            this.details_t.AutoSize = true;
            this.details_t.Location = new System.Drawing.Point(3, 11);
            this.details_t.Name = "details_t";
            this.details_t.Size = new System.Drawing.Size(80, 13);
            this.details_t.TabIndex = 0;
            this.details_t.Text = "Address Details";
            // 
            // DQsOutletDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.gb_details);
            this.Name = "DQsOutletDetails";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.gb_details.ResumeLayout(false);
            this.gb_details.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.GroupBox gb_details;
        private System.Windows.Forms.Label details_t;
        private System.Windows.Forms.Label physical_address_t;
        private System.Windows.Forms.Label telephone_t;
        private System.Windows.Forms.Label postal_address_t;
        private System.Windows.Forms.TextBox tb_postal_address;
        private System.Windows.Forms.TextBox tb_telephone;
        private System.Windows.Forms.TextBox tb_physical_address;
        private System.Windows.Forms.TextBox tb_outlet_name_type;
        private System.Windows.Forms.TextBox tb_outlet_id;



    }
}
