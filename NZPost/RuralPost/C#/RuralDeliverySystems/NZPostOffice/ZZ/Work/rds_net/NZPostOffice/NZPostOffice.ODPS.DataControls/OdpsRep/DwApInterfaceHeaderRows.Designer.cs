using NZPostOffice.ODPS.Entity.OdpsRep;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwApInterfaceHeaderRows
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_9;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_40;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_41;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_42;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_43;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_44;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_45;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_46;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_47;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_48;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_49;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaction_id_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_10;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_11;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_12;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_13;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_14;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_15;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_16;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_17;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_18;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_50;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_19;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_51;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_52;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_53;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_54;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_55;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_56;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_57;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_58;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_20;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_21;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_22;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_23;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_24;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_25;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_26;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_27;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_location_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_28;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_date_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_29;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_30;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_31;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_32;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_33;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_34;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_35;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_36;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_37;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_38;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_39;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_number_6;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_7;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_8;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.ApInterfaceHeaderRows);

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
            this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.TabIndex = 0;

            //
            // transaction_id_1
            //
            transaction_id_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction_id_1.DataPropertyName = "TransactionId1";
            this.transaction_id_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.transaction_id_1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.transaction_id_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.transaction_id_1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.transaction_id_1.HeaderText = "Transaction Id 1";
            this.transaction_id_1.Name = "transaction_id_1";
            this.transaction_id_1.ReadOnly = true;
            this.transaction_id_1.Width = 100;
            this.grid.Columns.Add(transaction_id_1);


            //
            // vendor_2
            //
            vendor_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_2.DataPropertyName = "Vendor2";
            this.vendor_2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.vendor_2.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.vendor_2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.vendor_2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.vendor_2.HeaderText = "Vendor 2";
            this.vendor_2.Name = "vendor_2";
            this.vendor_2.ReadOnly = true;
            this.vendor_2.Width = 74;
            this.grid.Columns.Add(vendor_2);


            //
            // vendor_location_3
            //
            vendor_location_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_location_3.DataPropertyName = "VendorLocation3";
            this.vendor_location_3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.vendor_location_3.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.vendor_location_3.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.vendor_location_3.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.vendor_location_3.HeaderText = "Vendor Location 3";
            this.vendor_location_3.Name = "vendor_location_3";
            this.vendor_location_3.ReadOnly = true;
            this.vendor_location_3.Width = 100;
            this.grid.Columns.Add(vendor_location_3);


            //
            // invoice_no_4
            //
            invoice_no_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_no_4.DataPropertyName = "InvoiceNo4";
            this.invoice_no_4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.invoice_no_4.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.invoice_no_4.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.invoice_no_4.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.invoice_no_4.HeaderText = "Invoice No 4";
            this.invoice_no_4.Name = "invoice_no_4";
            this.invoice_no_4.ReadOnly = true;
            this.invoice_no_4.Width = 154;
            this.grid.Columns.Add(invoice_no_4);


            //
            // invoice_date_5
            //
            invoice_date_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_date_5.DataPropertyName = "InvoiceDate5";
            this.invoice_date_5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.invoice_date_5.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.invoice_date_5.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.invoice_date_5.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.invoice_date_5.HeaderText = "Invoice Date 5";
            this.invoice_date_5.Name = "invoice_date_5";
            this.invoice_date_5.ReadOnly = true;
            this.invoice_date_5.Width = 100;
            this.grid.Columns.Add(invoice_date_5);


            //
            // payment_number_6
            //
            payment_number_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_number_6.DataPropertyName = "PaymentNumber6";
            this.payment_number_6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.payment_number_6.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.payment_number_6.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.payment_number_6.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.payment_number_6.HeaderText = "Payment Number 6";
            this.payment_number_6.Name = "payment_number_6";
            this.payment_number_6.ReadOnly = true;
            this.payment_number_6.Width = 110;
            this.grid.Columns.Add(payment_number_6);


            //
            // column_7
            //
            column_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_7.DataPropertyName = "Column7";
            this.column_7.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_7.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_7.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_7.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_7.HeaderText = "Column 7";
            this.column_7.Name = "column_7";
            this.column_7.ReadOnly = true;
            this.column_7.Width = 59;
            this.grid.Columns.Add(column_7);


            //
            // column_8
            //
            column_8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_8.DataPropertyName = "Column8";
            this.column_8.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_8.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_8.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_8.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_8.HeaderText = "Column 8";
            this.column_8.Name = "column_8";
            this.column_8.ReadOnly = true;
            this.column_8.Width = 100;
            this.grid.Columns.Add(column_8);


            //
            // column_9
            //
            column_9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_9.DataPropertyName = "Column9";
            this.column_9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_9.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_9.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_9.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_9.HeaderText = "Column 9";
            this.column_9.Name = "column_9";
            this.column_9.ReadOnly = true;
            this.column_9.Width = 169;
            this.grid.Columns.Add(column_9);


            //
            // column_10
            //
            column_10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_10.DataPropertyName = "Column10";
            this.column_10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_10.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_10.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_10.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_10.HeaderText = "Column 10";
            this.column_10.Name = "column_10";
            this.column_10.ReadOnly = true;
            this.column_10.Width = 100;
            this.grid.Columns.Add(column_10);


            //
            // column_11
            //
            column_11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_11.DataPropertyName = "Column11";
            this.column_11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_11.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_11.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_11.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_11.HeaderText = "Column 11";
            this.column_11.Name = "column_11";
            this.column_11.ReadOnly = true;
            this.column_11.Width = 100;
            this.grid.Columns.Add(column_11);


            //
            // column_12
            //
            column_12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_12.DataPropertyName = "Column12";
            this.column_12.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_12.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_12.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_12.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_12.HeaderText = "Column 12";
            this.column_12.Name = "column_12";
            this.column_12.ReadOnly = true;
            this.column_12.Width = 100;
            this.grid.Columns.Add(column_12);


            //
            // column_13
            //
            column_13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_13.DataPropertyName = "Column13";
            this.column_13.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_13.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_13.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_13.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_13.HeaderText = "Column 13";
            this.column_13.Name = "column_13";
            this.column_13.ReadOnly = true;
            this.column_13.Width = 100;
            this.grid.Columns.Add(column_13);


            //
            // column_14
            //
            column_14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_14.DataPropertyName = "Column14";
            this.column_14.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_14.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_14.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_14.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_14.HeaderText = "Column 14";
            this.column_14.Name = "column_14";
            this.column_14.ReadOnly = true;
            this.column_14.Width = 100;
            this.grid.Columns.Add(column_14);


            //
            // column_15
            //
            column_15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_15.DataPropertyName = "Column15";
            this.column_15.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_15.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_15.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_15.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_15.HeaderText = "Column 15";
            this.column_15.Name = "column_15";
            this.column_15.ReadOnly = true;
            this.column_15.Width = 100;
            this.grid.Columns.Add(column_15);


            //
            // column_16
            //
            column_16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_16.DataPropertyName = "Column16";
            this.column_16.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_16.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_16.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_16.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_16.HeaderText = "Column 16";
            this.column_16.Name = "column_16";
            this.column_16.ReadOnly = true;
            this.column_16.Width = 100;
            this.grid.Columns.Add(column_16);


            //
            // column_17
            //
            column_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_17.DataPropertyName = "Column17";
            this.column_17.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_17.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_17.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_17.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_17.HeaderText = "Column 17";
            this.column_17.Name = "column_17";
            this.column_17.ReadOnly = true;
            this.column_17.Width = 100;
            this.grid.Columns.Add(column_17);

            //
            // column_18
            //
            column_18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_18.DataPropertyName = "Column18";
            this.column_18.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_18.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_18.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_18.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_18.HeaderText = "Column 18";
            this.column_18.Name = "column_18";
            this.column_18.ReadOnly = true;
            this.column_18.Width = 100;
            this.grid.Columns.Add(column_18);

            //
            // column_19
            //
            column_19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_19.DataPropertyName = "Column19";
            this.column_19.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_19.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_19.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_19.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_19.HeaderText = "Column 19";
            this.column_19.Name = "column_19";
            this.column_19.ReadOnly = true;
            this.column_19.Width = 100;
            this.grid.Columns.Add(column_19);


            //
            // column_20
            //
            column_20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_20.DataPropertyName = "Column20";
            this.column_20.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_20.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_20.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_20.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_20.HeaderText = "Column 20";
            this.column_20.Name = "column_20";
            this.column_20.ReadOnly = true;
            this.column_20.Width = 100;
            this.grid.Columns.Add(column_20);


            //
            // column_21
            //
            column_21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_21.DataPropertyName = "Column21";
            this.column_21.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_21.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_21.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_21.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_21.HeaderText = "Column 21";
            this.column_21.Name = "column_21";
            this.column_21.ReadOnly = true;
            this.column_21.Width = 100;
            this.grid.Columns.Add(column_21);


            //
            // column_22
            //
            column_22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_22.DataPropertyName = "Column22";
            this.column_22.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_22.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_22.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_22.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_22.HeaderText = "Column 22";
            this.column_22.Name = "column_22";
            this.column_22.ReadOnly = true;
            this.column_22.Width = 100;
            this.grid.Columns.Add(column_22);


            //
            // column_23
            //
            column_23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_23.DataPropertyName = "Column23";
            this.column_23.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_23.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_23.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_23.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_23.HeaderText = "Column 23";
            this.column_23.Name = "column_23";
            this.column_23.ReadOnly = true;
            this.column_23.Width = 100;
            this.grid.Columns.Add(column_23);


            //
            // column_24
            //
            column_24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_24.DataPropertyName = "Column24";
            this.column_24.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_24.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_24.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_24.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_24.HeaderText = "Column 24";
            this.column_24.Name = "column_24";
            this.column_24.ReadOnly = true;
            this.column_24.Width = 100;
            this.grid.Columns.Add(column_24);


            //
            // column_25
            //
            column_25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_25.DataPropertyName = "Column25";
            this.column_25.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_25.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_25.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_25.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_25.HeaderText = "Column 25";
            this.column_25.Name = "column_25";
            this.column_25.ReadOnly = true;
            this.column_25.Width = 100;
            this.grid.Columns.Add(column_25);


            //
            // column_26
            //
            column_26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_26.DataPropertyName = "Column26";
            this.column_26.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_26.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_26.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_26.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_26.HeaderText = "Column 26";
            this.column_26.Name = "column_26";
            this.column_26.ReadOnly = true;
            this.column_26.Width = 100;
            this.grid.Columns.Add(column_26);


            //
            // column_27
            //
            column_27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_27.DataPropertyName = "Column27";
            this.column_27.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_27.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_27.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_27.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_27.HeaderText = "Column 27";
            this.column_27.Name = "column_27";
            this.column_27.ReadOnly = true;
            this.column_27.Width = 100;
            this.grid.Columns.Add(column_27);


            //
            // column_28
            //
            column_28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_28.DataPropertyName = "Column28";
            this.column_28.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_28.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_28.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_28.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_28.HeaderText = "Column 28";
            this.column_28.Name = "column_28";
            this.column_28.ReadOnly = true;
            this.column_28.Width = 100;
            this.grid.Columns.Add(column_28);
            //
            // column_29
            //
            column_29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_29.DataPropertyName = "Column29";
            this.column_29.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_29.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_29.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_29.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_29.HeaderText = "Column 29";
            this.column_29.Name = "column_29";
            this.column_29.ReadOnly = true;
            this.column_29.Width = 100;
            this.grid.Columns.Add(column_29);


            //
            // column_30
            //
            column_30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_30.DataPropertyName = "Column30";
            this.column_30.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_30.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_30.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_30.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_30.HeaderText = "Column 30";
            this.column_30.Name = "column_30";
            this.column_30.ReadOnly = true;
            this.column_30.Width = 100;
            this.grid.Columns.Add(column_30);


            //
            // column_31
            //
            column_31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_31.DataPropertyName = "Column31";
            this.column_31.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_31.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_31.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_31.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_31.HeaderText = "Column 31";
            this.column_31.Name = "column_31";
            this.column_31.ReadOnly = true;
            this.column_31.Width = 100;
            this.grid.Columns.Add(column_31);


            //
            // column_32
            //
            column_32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_32.DataPropertyName = "Column32";
            this.column_32.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_32.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_32.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_32.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_32.HeaderText = "Column 32";
            this.column_32.Name = "column_32";
            this.column_32.ReadOnly = true;
            this.column_32.Width = 100;
            this.grid.Columns.Add(column_32);


            //
            // column_33
            //
            column_33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_33.DataPropertyName = "Column33";
            this.column_33.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_33.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_33.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_33.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_33.HeaderText = "Column 33";
            this.column_33.Name = "column_33";
            this.column_33.ReadOnly = true;
            this.column_33.Width = 100;
            this.grid.Columns.Add(column_33);


            //
            // column_34
            //
            column_34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_34.DataPropertyName = "Column34";
            this.column_34.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_34.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_34.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_34.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_34.HeaderText = "Column 34";
            this.column_34.Name = "column_34";
            this.column_34.ReadOnly = true;
            this.column_34.Width = 100;
            this.grid.Columns.Add(column_34);


            //
            // column_35
            //
            column_35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_35.DataPropertyName = "Column35";
            this.column_35.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_35.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_35.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_35.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_35.HeaderText = "Column 35";
            this.column_35.Name = "column_35";
            this.column_35.ReadOnly = true;
            this.column_35.Width = 100;
            this.grid.Columns.Add(column_35);


            //
            // column_36
            //
            column_36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_36.DataPropertyName = "Column36";
            this.column_36.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_36.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_36.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_36.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_36.HeaderText = "Column 36";
            this.column_36.Name = "column_36";
            this.column_36.ReadOnly = true;
            this.column_36.Width = 100;
            this.grid.Columns.Add(column_36);


            //
            // column_37
            //
            column_37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_37.DataPropertyName = "Column37";
            this.column_37.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_37.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_37.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_37.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_37.HeaderText = "Column 37";
            this.column_37.Name = "column_37";
            this.column_37.ReadOnly = true;
            this.column_37.Width = 100;
            this.grid.Columns.Add(column_37);


            //
            // column_38
            //
            column_38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_38.DataPropertyName = "Column38";
            this.column_38.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_38.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_38.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_38.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_38.HeaderText = "Column 38";
            this.column_38.Name = "column_38";
            this.column_38.ReadOnly = true;
            this.column_38.Width = 505;
            this.grid.Columns.Add(column_38);


            //
            // column_39
            //
            column_39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_39.DataPropertyName = "Column39";
            this.column_39.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_39.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_39.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_39.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_39.HeaderText = "Column 39";
            this.column_39.Name = "column_39";
            this.column_39.ReadOnly = true;
            this.column_39.Width = 100;
            this.grid.Columns.Add(column_39);


            //
            // column_40
            //
            column_40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_40.DataPropertyName = "Column40";
            this.column_40.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_40.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_40.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_40.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_40.HeaderText = "Column 40";
            this.column_40.Name = "column_40";
            this.column_40.ReadOnly = true;
            this.column_40.Width = 100;
            this.grid.Columns.Add(column_40);


            //
            // column_41
            //
            column_41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_41.DataPropertyName = "Column41";
            this.column_41.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_41.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_41.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_41.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_41.HeaderText = "Column 41";
            this.column_41.Name = "column_41";
            this.column_41.ReadOnly = true;
            this.column_41.Width = 100;
            this.grid.Columns.Add(column_41);


            //
            // column_42
            //
            column_42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_42.DataPropertyName = "Column42";
            this.column_42.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_42.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_42.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_42.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_42.HeaderText = "Column 42";
            this.column_42.Name = "column_42";
            this.column_42.ReadOnly = true;
            this.column_42.Width = 100;
            this.grid.Columns.Add(column_42);


            //
            // column_43
            //
            column_43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_43.DataPropertyName = "Column43";
            this.column_43.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_43.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_43.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_43.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_43.HeaderText = "Column 43";
            this.column_43.Name = "column_43";
            this.column_43.ReadOnly = true;
            this.column_43.Width = 100;
            this.grid.Columns.Add(column_43);


            //
            // column_44
            //
            column_44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_44.DataPropertyName = "Column44";
            this.column_44.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_44.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_44.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_44.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_44.HeaderText = "Column 44";
            this.column_44.Name = "column_44";
            this.column_44.ReadOnly = true;
            this.column_44.Width = 100;
            this.grid.Columns.Add(column_44);


            //
            // column_45
            //
            column_45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_45.DataPropertyName = "Column45";
            this.column_45.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_45.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_45.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_45.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_45.HeaderText = "Column 45";
            this.column_45.Name = "column_45";
            this.column_45.ReadOnly = true;
            this.column_45.Width = 100;
            this.grid.Columns.Add(column_45);


            //
            // column_46
            //
            column_46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_46.DataPropertyName = "Column46";
            this.column_46.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_46.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_46.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_46.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_46.HeaderText = "Column 46";
            this.column_46.Name = "column_46";
            this.column_46.ReadOnly = true;
            this.column_46.Width = 100;
            this.grid.Columns.Add(column_46);


            //
            // column_47
            //
            column_47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_47.DataPropertyName = "Column47";
            this.column_47.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_47.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_47.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_47.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_47.HeaderText = "Column 47";
            this.column_47.Name = "column_47";
            this.column_47.ReadOnly = true;
            this.column_47.Width = 100;
            this.grid.Columns.Add(column_47);


            //
            // column_48
            //
            column_48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_48.DataPropertyName = "Column48";
            this.column_48.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_48.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_48.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_48.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_48.HeaderText = "Column 48";
            this.column_48.Name = "column_48";
            this.column_48.ReadOnly = true;
            this.column_48.Width = 100;
            this.grid.Columns.Add(column_48);


            //
            // column_49
            //
            column_49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_49.DataPropertyName = "Column49";
            this.column_49.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_49.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_49.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_49.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_49.HeaderText = "Column 49";
            this.column_49.Name = "column_49";
            this.column_49.ReadOnly = true;
            this.column_49.Width = 100;
            this.grid.Columns.Add(column_49);


            //
            // column_50
            //
            column_50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_50.DataPropertyName = "Column50";
            this.column_50.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_50.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_50.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_50.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_50.HeaderText = "Column 50";
            this.column_50.Name = "column_50";
            this.column_50.ReadOnly = true;
            this.column_50.Width = 100;
            this.grid.Columns.Add(column_50);


            //
            // column_51
            //
            column_51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_51.DataPropertyName = "Column51";
            this.column_51.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_51.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_51.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_51.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_51.HeaderText = "Column 51";
            this.column_51.Name = "column_51";
            this.column_51.ReadOnly = true;
            this.column_51.Width = 100;
            this.grid.Columns.Add(column_51);


            //
            // column_52
            //
            column_52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_52.DataPropertyName = "Column52";
            this.column_52.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_52.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_52.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_52.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_52.HeaderText = "Column 52";
            this.column_52.Name = "column_52";
            this.column_52.ReadOnly = true;
            this.column_52.Width = 100;
            this.grid.Columns.Add(column_52);


            //
            // column_53
            //
            column_53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_53.DataPropertyName = "Column53";
            this.column_53.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_53.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_53.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_53.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_53.HeaderText = "Column 53";
            this.column_53.Name = "column_53";
            this.column_53.ReadOnly = true;
            this.column_53.Width = 100;
            this.grid.Columns.Add(column_53);


            //
            // column_54
            //
            column_54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_54.DataPropertyName = "Column54";
            this.column_54.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_54.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_54.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_54.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_54.HeaderText = "Column 54";
            this.column_54.Name = "column_54";
            this.column_54.ReadOnly = true;
            this.column_54.Width = 100;
            this.grid.Columns.Add(column_54);


            //
            // column_55
            //
            column_55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_55.DataPropertyName = "Column55";
            this.column_55.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_55.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_55.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_55.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_55.HeaderText = "Column 55";
            this.column_55.Name = "column_55";
            this.column_55.ReadOnly = true;
            this.column_55.Width = 100;
            this.grid.Columns.Add(column_55);


            //
            // column_56
            //
            column_56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_56.DataPropertyName = "Column56";
            this.column_56.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_56.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_56.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_56.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_56.HeaderText = "Column 56";
            this.column_56.Name = "column_56";
            this.column_56.ReadOnly = true;
            this.column_56.Width = 100;
            this.grid.Columns.Add(column_56);


            //
            // column_57
            //
            column_57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_57.DataPropertyName = "Column57";
            this.column_57.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_57.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_57.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_57.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_57.HeaderText = "Column 57";
            this.column_57.Name = "column_57";
            this.column_57.ReadOnly = true;
            this.column_57.Width = 100;
            this.grid.Columns.Add(column_57);


            //
            // column_58
            //
            column_58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_58.DataPropertyName = "Column58";
            this.column_58.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_58.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.column_58.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column_58.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column_58.HeaderText = "Column 58";
            this.column_58.Name = "column_58";
            this.column_58.ReadOnly = true;
            this.column_58.Width = 100;
            this.grid.Columns.Add(column_58);

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
