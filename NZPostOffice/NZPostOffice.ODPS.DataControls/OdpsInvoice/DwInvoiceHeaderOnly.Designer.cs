namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceHeaderOnly
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwInvoiceHeaderOnly";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceHeaderOnly);
            #region t_1 define
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Name = "t_1";
            this.t_1.Location = new System.Drawing.Point(256, 12);
            this.t_1.Size = new System.Drawing.Size(347, 16);
            this.t_1.TabIndex = 0;
            this.t_1.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_1.Text = "BUYER CREATED TAX INVOICE (IRD approved)";
            #endregion
            this.Controls.Add(t_1);
            #region p_1 define
            this.p_1 = new System.Windows.Forms.PictureBox();
            this.p_1.Name = "p_1";
            this.p_1.Location = new System.Drawing.Point(604, 7);
            this.p_1.Size = new System.Drawing.Size(51, 28);
            this.p_1.TabIndex = 0;
            //?this.p_1.Image = ((object)(resources.GetObject("p_1.Image")));
            #endregion
            this.Controls.Add(p_1);
            #region t_2 define
            this.t_2 = new System.Windows.Forms.Label();
            this.t_2.Name = "t_2";
            this.t_2.Location = new System.Drawing.Point(10, 49);
            this.t_2.Size = new System.Drawing.Size(96, 17);
            this.t_2.TabIndex = 0;
            this.t_2.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_2.Text = "Invoice from:";
            #endregion
            this.Controls.Add(t_2);
            #region t_3 define
            this.t_3 = new System.Windows.Forms.Label();
            this.t_3.Name = "t_3";
            this.t_3.Location = new System.Drawing.Point(430, 51);
            this.t_3.Size = new System.Drawing.Size(28, 17);
            this.t_3.TabIndex = 0;
            this.t_3.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_3.Text = "For:";
            #endregion
            this.Controls.Add(t_3);
            #region con_title define
            this.con_title = new System.Windows.Forms.TextBox();
            this.con_title.Name = "con_title";
            this.con_title.Location = new System.Drawing.Point(466, 51);
            this.con_title.Size = new System.Drawing.Size(382, 18);
            this.con_title.TabIndex = 0;
            this.con_title.Enabled = false;
            this.con_title.Font = new System.Drawing.Font("Times New Roman", 10);
            this.con_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.con_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(con_title);
            #region t_4 define
            this.t_4 = new System.Windows.Forms.Label();
            this.t_4.Name = "t_4";
            this.t_4.Location = new System.Drawing.Point(10, 79);
            this.t_4.Size = new System.Drawing.Size(94, 16);
            this.t_4.TabIndex = 0;
            this.t_4.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_4.Text = "Contract No. ";
            #endregion
            this.Controls.Add(t_4);
            #region contract_no define
            this.contract_no = new System.Windows.Forms.TextBox();
            this.contract_no.Name = "contract_no";
            this.contract_no.Location = new System.Drawing.Point(106, 79);
            this.contract_no.Size = new System.Drawing.Size(164, 17);
            this.contract_no.TabIndex = 0;
            this.contract_no.Enabled = false;
            this.contract_no.Font = new System.Drawing.Font("Times New Roman", 10);
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(contract_no);
            #region t_5 define
            this.t_5 = new System.Windows.Forms.Label();
            this.t_5.Name = "t_5";
            this.t_5.Location = new System.Drawing.Point(10, 105);
            this.t_5.Size = new System.Drawing.Size(65, 16);
            this.t_5.TabIndex = 0;
            this.t_5.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_5.Text = "GST No: ";
            #endregion
            this.Controls.Add(t_5);
            #region c_gst_number define
            this.c_gst_number = new System.Windows.Forms.TextBox();
            this.c_gst_number.Name = "c_gst_number";
            this.c_gst_number.Location = new System.Drawing.Point(106, 105);
            this.c_gst_number.Size = new System.Drawing.Size(164, 16);
            this.c_gst_number.TabIndex = 0;
            this.c_gst_number.Enabled = false;
            this.c_gst_number.Font = new System.Drawing.Font("Times New Roman", 10);
            this.c_gst_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_gst_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CGstNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_gst_number);
            #region t_6 define
            this.t_6 = new System.Windows.Forms.Label();
            this.t_6.Name = "t_6";
            this.t_6.Location = new System.Drawing.Point(463, 79);
            this.t_6.Size = new System.Drawing.Size(150, 16);
            this.t_6.TabIndex = 0;
            this.t_6.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_6.Text = "provided period ending";
            #endregion
            this.Controls.Add(t_6);
            #region compute_2 define
            this.compute_2 = new System.Windows.Forms.TextBox();
            this.compute_2.Name = "compute_2";
            this.compute_2.Location = new System.Drawing.Point(615, 79);
            this.compute_2.Size = new System.Drawing.Size(209, 16);
            this.compute_2.TabIndex = 0;
            this.compute_2.Font = new System.Drawing.Font("Times New Roman", 10);
            this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(compute_2);
            #region t_7 define
            this.t_7 = new System.Windows.Forms.Label();
            this.t_7.Name = "t_7";
            this.t_7.Location = new System.Drawing.Point(10, 132);
            this.t_7.Size = new System.Drawing.Size(91, 16);
            this.t_7.TabIndex = 0;
            this.t_7.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_7.Text = "Supplier No.";
            #endregion
            this.Controls.Add(t_7);
            #region ds_no define
            this.ds_no = new System.Windows.Forms.TextBox();
            this.ds_no.Name = "ds_no";
            this.ds_no.Location = new System.Drawing.Point(106, 132);
            this.ds_no.Size = new System.Drawing.Size(164, 16);
            this.ds_no.TabIndex = 0;
            this.ds_no.Enabled = false;
            this.ds_no.Font = new System.Drawing.Font("Times New Roman", 10);
            this.ds_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ds_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DsNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ds_no);
            #region t_10 define
            this.t_10 = new System.Windows.Forms.Label();
            this.t_10.Name = "t_10";
            this.t_10.Location = new System.Drawing.Point(464, 159);
            this.t_10.Size = new System.Drawing.Size(76, 17);
            this.t_10.TabIndex = 0;
            this.t_10.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_10.Text = "Invoice to:";
            #endregion
            this.Controls.Add(t_10);
            #region compute_4 define
            this.compute_4 = new System.Windows.Forms.TextBox();
            this.compute_4.Name = "compute_4";
            this.compute_4.Location = new System.Drawing.Point(10, 190);
            this.compute_4.Size = new System.Drawing.Size(454, 23);
            this.compute_4.TabIndex = 0;
            this.compute_4.Font = new System.Drawing.Font("Times New Roman", 10);
            this.compute_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(compute_4);
            #region c_address define
            this.c_address = new System.Windows.Forms.TextBox();
            this.c_address.Name = "c_address";
            this.c_address.Location = new System.Drawing.Point(10, 216);
            this.c_address.Size = new System.Drawing.Size(454, 23);
            this.c_address.TabIndex = 0;
            this.c_address.Enabled = false;
            this.c_address.Font = new System.Drawing.Font("Times New Roman", 10);
            this.c_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_address);
            #region t_9 define
            this.t_9 = new System.Windows.Forms.Label();
            this.t_9.Name = "t_9";
            this.t_9.Location = new System.Drawing.Point(464, 133);
            this.t_9.Size = new System.Drawing.Size(100, 17);
            this.t_9.TabIndex = 0;
            this.t_9.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_9.Text = "Tax invoice no. ";
            #endregion
            this.Controls.Add(t_9);
            #region cinvoice_no define
            this.cinvoice_no = new System.Windows.Forms.TextBox();
            this.cinvoice_no.Name = "cinvoice_no";
            this.cinvoice_no.Location = new System.Drawing.Point(566, 133);
            this.cinvoice_no.Size = new System.Drawing.Size(91, 23);
            this.cinvoice_no.TabIndex = 0;
            this.cinvoice_no.Enabled = false;
            this.cinvoice_no.Font = new System.Drawing.Font("Times New Roman", 10);
            this.cinvoice_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.cinvoice_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CinvoiceNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(cinvoice_no);
            #region t_8 define
            this.t_8 = new System.Windows.Forms.Label();
            this.t_8.Name = "t_8";
            this.t_8.Location = new System.Drawing.Point(463, 106);
            this.t_8.Size = new System.Drawing.Size(82, 17);
            this.t_8.TabIndex = 0;
            this.t_8.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_8.Text = "Issue date:";
            #endregion
            this.Controls.Add(t_8);
            #region compute_3 define
            this.compute_3 = new System.Windows.Forms.TextBox();
            this.compute_3.Name = "compute_3";
            this.compute_3.Location = new System.Drawing.Point(566, 106);
            this.compute_3.Size = new System.Drawing.Size(91, 23);
            this.compute_3.TabIndex = 0;
            this.compute_3.Font = new System.Drawing.Font("Times New Roman", 10);
            this.compute_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(compute_3);
            #region compute_1 define
            this.compute_1 = new System.Windows.Forms.TextBox();
            this.compute_1.Name = "compute_1";
            this.compute_1.Location = new System.Drawing.Point(13, 12);
            this.compute_1.Size = new System.Drawing.Size(75, 20);
            this.compute_1.TabIndex = 0;
            this.compute_1.Font = new System.Drawing.Font("Times New Roman", 10);
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(compute_1);
            this.Size = new System.Drawing.Size(891, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.PictureBox p_1;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.TextBox con_title;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label t_5;
        private System.Windows.Forms.TextBox c_gst_number;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.Label t_7;
        private System.Windows.Forms.TextBox ds_no;
        private System.Windows.Forms.Label t_10;
        private System.Windows.Forms.TextBox compute_4;
        private System.Windows.Forms.TextBox c_address;
        private System.Windows.Forms.Label t_9;
        private System.Windows.Forms.TextBox cinvoice_no;
        private System.Windows.Forms.Label t_8;
        private System.Windows.Forms.TextBox compute_3;
        private System.Windows.Forms.TextBox compute_1;
    }
}
