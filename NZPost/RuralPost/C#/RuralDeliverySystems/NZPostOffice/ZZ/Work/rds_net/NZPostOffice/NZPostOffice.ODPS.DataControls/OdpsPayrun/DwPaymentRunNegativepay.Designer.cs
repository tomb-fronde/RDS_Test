namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwPaymentRunNegativepay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn net_pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_surname_company;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_first_names;
        private System.Windows.Forms.DataGridViewTextBoxColumn gst;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_tax_adjustments;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_pay;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.PaymentRunNegativepay);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            //this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            //this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            //this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
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
            this.grid.BackgroundColor = System.Drawing.Color.White;
       
            //
            // contract_no
            //
            contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_no.DataPropertyName = "ContractNo";
            this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.contract_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no.HeaderText = "Contract No";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Width = 60;
            this.grid.Columns.Add(contract_no);

            //
            // c_surname_company
            //
            c_surname_company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_surname_company.DataPropertyName = "CSurnameCompany";
            this.c_surname_company.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.c_surname_company.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.c_surname_company.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.c_surname_company.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.c_surname_company.HeaderText = "Surname/Company";
            this.c_surname_company.Name = "c_surname_company";
            this.c_surname_company.ReadOnly = true;
            this.c_surname_company.Width = 150;
            this.grid.Columns.Add(c_surname_company);

            //
            // c_first_names
            //
            c_first_names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_first_names.DataPropertyName = "CFirstNames";
            this.c_first_names.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.c_first_names.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.c_first_names.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.c_first_names.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.c_first_names.HeaderText = "First Names";
            this.c_first_names.Name = "c_first_names";
            this.c_first_names.ReadOnly = true;
            this.c_first_names.Width = 139;
            this.grid.Columns.Add(c_first_names);

            //
            // gross_pay
            //
            gross_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross_pay.DataPropertyName = "GrossPay";
            this.gross_pay.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gross_pay.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gross_pay.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gross_pay.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.gross_pay.HeaderText = "Gross Pay";
            this.gross_pay.Name = "gross_pay";
            this.gross_pay.ReadOnly = true;
            this.gross_pay.Width = 60;
            this.grid.Columns.Add(gross_pay);

            //
            // gst
            //
            gst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gst.DataPropertyName = "Gst";
            this.gst.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gst.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gst.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gst.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.gst.HeaderText = "GST";
            this.gst.Name = "gst";
            this.gst.ReadOnly = true;
            this.gst.Width = 60;
            this.grid.Columns.Add(gst);

            //
            // tax
            //
            tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax.DataPropertyName = "Tax";
            this.tax.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tax.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tax.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tax.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.tax.HeaderText = "Tax";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            this.tax.Width = 60;
            this.grid.Columns.Add(tax);

            //
            // post_tax_adjustments
            //
            post_tax_adjustments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_tax_adjustments.DataPropertyName = "PostTaxAdjustments";
            this.post_tax_adjustments.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.post_tax_adjustments.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.post_tax_adjustments.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.post_tax_adjustments.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.post_tax_adjustments.HeaderText = "Post Tax Adjustments";
            this.post_tax_adjustments.Name = "post_tax_adjustments";
            this.post_tax_adjustments.ReadOnly = true;
            this.post_tax_adjustments.Width = 105;
            this.grid.Columns.Add(post_tax_adjustments);

            //
            // net_pay
            //
            net_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_pay.DataPropertyName = "NetPay";
            this.net_pay.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.net_pay.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.net_pay.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.net_pay.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.net_pay.HeaderText = "Net Pay";
            this.net_pay.Name = "net_pay";
            this.net_pay.ReadOnly = true;
            this.net_pay.Width = 60;
            this.grid.Columns.Add(net_pay);

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
