namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwInvoiceInterfaceDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_15;
        private System.Windows.Forms.DataGridViewTextBoxColumn gst_number_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerdriver_name_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn courier_post_vol_9;
        private System.Windows.Forms.DataGridViewTextBoxColumn pre_tax_adj_8;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_post_tax_value_17;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowance_7;
        private System.Windows.Forms.DataGridViewTextBoxColumn courier_post_value_10;
        private System.Windows.Forms.DataGridViewTextBoxColumn message_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_pay13;
        private System.Windows.Forms.DataGridViewTextBoxColumn adpost_value_12;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_tax_description_16;
        private System.Windows.Forms.DataGridViewTextBoxColumn basic_pay_6;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn address_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn gst_14;
        private System.Windows.Forms.DataGridViewTextBoxColumn adpost_vol_11;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.InvoiceInterfaceDetail);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
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
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // invoice_no_1
            //
            invoice_no_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_no_1.DataPropertyName = "InvoiceNo1";
            this.invoice_no_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.invoice_no_1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.invoice_no_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.invoice_no_1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.invoice_no_1.HeaderText = "Invoice No 1";
            this.invoice_no_1.Name = "invoice_no_1";
            this.invoice_no_1.ReadOnly = true;
            this.invoice_no_1.Width = 141;
            this.grid.Columns.Add(invoice_no_1);


            //
            // ownerdriver_name_2
            //
            ownerdriver_name_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerdriver_name_2.DataPropertyName = "OwnerdriverName2";
            this.ownerdriver_name_2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ownerdriver_name_2.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ownerdriver_name_2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ownerdriver_name_2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.ownerdriver_name_2.HeaderText = "Ownerdriver Name 2";
            this.ownerdriver_name_2.Name = "ownerdriver_name_2";
            this.ownerdriver_name_2.ReadOnly = true;
            this.ownerdriver_name_2.Width = 204;
            this.grid.Columns.Add(ownerdriver_name_2);


            //
            // address_3
            //
            address_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address_3.DataPropertyName = "Address3";
            this.address_3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.address_3.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.address_3.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.address_3.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.address_3.HeaderText = "Address 3";
            this.address_3.Name = "address_3";
            this.address_3.ReadOnly = true;
            this.address_3.Width = 91;
            this.grid.Columns.Add(address_3);


            //
            // gst_number_4
            //
            gst_number_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gst_number_4.DataPropertyName = "GstNumber4";
            this.gst_number_4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gst_number_4.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gst_number_4.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gst_number_4.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.gst_number_4.HeaderText = "Gst Number 4";
            this.gst_number_4.Name = "gst_number_4";
            this.gst_number_4.ReadOnly = true;
            this.gst_number_4.Width = 81;
            this.grid.Columns.Add(gst_number_4);


            //
            // message_5
            //
            message_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message_5.DataPropertyName = "Message5";
            this.message_5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.message_5.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.message_5.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.message_5.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.message_5.HeaderText = "Message 5";
            this.message_5.Name = "message_5";
            this.message_5.ReadOnly = true;
            this.message_5.Width = 159;
            this.grid.Columns.Add(message_5);


            //
            // basic_pay_6
            //
            basic_pay_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basic_pay_6.DataPropertyName = "BasicPay6";
            this.basic_pay_6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.basic_pay_6.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.basic_pay_6.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.basic_pay_6.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.basic_pay_6.HeaderText = "Basic Pay 6";
            this.basic_pay_6.Name = "basic_pay_6";
            this.basic_pay_6.ReadOnly = true;
            this.basic_pay_6.Width = 72;
            this.grid.Columns.Add(basic_pay_6);


            //
            // allowance_7
            //
            allowance_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowance_7.DataPropertyName = "Allowance7";
            this.allowance_7.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.allowance_7.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.allowance_7.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.allowance_7.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.allowance_7.HeaderText = "Allowance 7";
            this.allowance_7.Name = "allowance_7";
            this.allowance_7.ReadOnly = true;
            this.allowance_7.Width = 72;
            this.grid.Columns.Add(allowance_7);


            //
            // pre_tax_adj_8
            //
            pre_tax_adj_8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pre_tax_adj_8.DataPropertyName = "PreTaxAdj8";
            this.pre_tax_adj_8.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pre_tax_adj_8.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.pre_tax_adj_8.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pre_tax_adj_8.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.pre_tax_adj_8.HeaderText = "Pre Tax Adj 8";
            this.pre_tax_adj_8.Name = "pre_tax_adj_8";
            this.pre_tax_adj_8.ReadOnly = true;
            this.pre_tax_adj_8.Width = 79;
            this.grid.Columns.Add(pre_tax_adj_8);


            //
            // courier_post_vol_9
            //
            courier_post_vol_9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courier_post_vol_9.DataPropertyName = "CourierPostVol9";
            this.courier_post_vol_9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.courier_post_vol_9.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.courier_post_vol_9.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.courier_post_vol_9.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.courier_post_vol_9.HeaderText = "Courier Post Vol 9";
            this.courier_post_vol_9.Name = "courier_post_vol_9";
            this.courier_post_vol_9.ReadOnly = true;
            this.courier_post_vol_9.Width = 106;
            this.grid.Columns.Add(courier_post_vol_9);


            //
            // courier_post_value_10
            //
            courier_post_value_10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courier_post_value_10.DataPropertyName = "CourierPostValue10";
            this.courier_post_value_10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.courier_post_value_10.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.courier_post_value_10.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.courier_post_value_10.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.courier_post_value_10.HeaderText = "Courier Post Value 10";
            this.courier_post_value_10.Name = "courier_post_value_10";
            this.courier_post_value_10.ReadOnly = true;
            this.courier_post_value_10.Width = 127;
            this.grid.Columns.Add(courier_post_value_10);


            //
            // adpost_vol_11
            //
            adpost_vol_11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adpost_vol_11.DataPropertyName = "AdpostVol11";
            this.adpost_vol_11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.adpost_vol_11.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.adpost_vol_11.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.adpost_vol_11.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.adpost_vol_11.HeaderText = "Adpost Vol 11";
            this.adpost_vol_11.Name = "adpost_vol_11";
            this.adpost_vol_11.ReadOnly = true;
            this.adpost_vol_11.Width = 82;
            this.grid.Columns.Add(adpost_vol_11);


            //
            // adpost_value_12
            //
            adpost_value_12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adpost_value_12.DataPropertyName = "AdpostValue12";
            this.adpost_value_12.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.adpost_value_12.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.adpost_value_12.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.adpost_value_12.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.adpost_value_12.HeaderText = "Adpost Value 12";
            this.adpost_value_12.Name = "adpost_value_12";
            this.adpost_value_12.ReadOnly = true;
            this.adpost_value_12.Width = 96;
            this.grid.Columns.Add(adpost_value_12);


            //
            // gross_pay13
            //
            gross_pay13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross_pay13.DataPropertyName = "GrossPay13";
            this.gross_pay13.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gross_pay13.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gross_pay13.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gross_pay13.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.gross_pay13.HeaderText = "Gross Pay13";
            this.gross_pay13.Name = "gross_pay13";
            this.gross_pay13.ReadOnly = true;
            this.gross_pay13.Width = 76;
            this.grid.Columns.Add(gross_pay13);


            //
            // gst_14
            //
            gst_14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gst_14.DataPropertyName = "Gst14";
            this.gst_14.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gst_14.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gst_14.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gst_14.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.gst_14.HeaderText = "Gst 14";
            this.gst_14.Name = "gst_14";
            this.gst_14.ReadOnly = true;
            this.gst_14.Width = 72;
            this.grid.Columns.Add(gst_14);


            //
            // tax_15
            //
            tax_15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_15.DataPropertyName = "Tax15";
            this.tax_15.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tax_15.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.tax_15.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tax_15.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.tax_15.HeaderText = "Tax 15";
            this.tax_15.Name = "tax_15";
            this.tax_15.ReadOnly = true;
            this.tax_15.Width = 72;
            this.grid.Columns.Add(tax_15);


            //
            // post_tax_description_16
            //
            post_tax_description_16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_tax_description_16.DataPropertyName = "PostTaxDescription16";
            this.post_tax_description_16.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.post_tax_description_16.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.post_tax_description_16.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.post_tax_description_16.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.post_tax_description_16.HeaderText = "Post Tax Description 16";
            this.post_tax_description_16.Name = "post_tax_description_16";
            this.post_tax_description_16.ReadOnly = true;
            this.post_tax_description_16.Width = 139;
            this.grid.Columns.Add(post_tax_description_16);


            //
            // total_post_tax_value_17
            //
            total_post_tax_value_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_post_tax_value_17.DataPropertyName = "TotalPostTaxValue17";
            this.total_post_tax_value_17.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.total_post_tax_value_17.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.total_post_tax_value_17.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.total_post_tax_value_17.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.total_post_tax_value_17.HeaderText = "Total Post Tax Value 17";
            this.total_post_tax_value_17.Name = "total_post_tax_value_17";
            this.total_post_tax_value_17.ReadOnly = true;
            this.total_post_tax_value_17.Width = 139;
            this.grid.Columns.Add(total_post_tax_value_17);

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
