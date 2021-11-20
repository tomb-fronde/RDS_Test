namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceHeaderPostaddress
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
            this.Name = "DwInvoiceHeaderPostaddress";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceHeaderPostaddress);
            #region st_post define
            this.st_post = new System.Windows.Forms.Label();
            this.st_post.Name = "st_post";
            this.st_post.Location = new System.Drawing.Point(5, 2);
            this.st_post.Size = new System.Drawing.Size(73, 16);
            this.st_post.TabIndex = 0;
            this.st_post.Font = new System.Drawing.Font("Times New Roman", 10);
            this.st_post.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_post.Text = "RuralPost";
            #endregion
            this.Controls.Add(st_post);
            #region n_58939966 define
            this.n_58939966 = new System.Windows.Forms.Label();
            this.n_58939966.Name = "n_58939966";
            this.n_58939966.Location = new System.Drawing.Point(5, 28);
            this.n_58939966.Size = new System.Drawing.Size(162, 16);
            this.n_58939966.TabIndex = 0;
            this.n_58939966.Font = new System.Drawing.Font("Times New Roman", 10);
            this.n_58939966.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_58939966.Text = "New Zealand Post Ltd";
            #endregion
            this.Controls.Add(n_58939966);
            #region nat_rural_post_address define
            this.nat_rural_post_address = new System.Windows.Forms.TextBox();
            this.nat_rural_post_address.Name = "nat_rural_post_address";
            this.nat_rural_post_address.Location = new System.Drawing.Point(5, 53);
            this.nat_rural_post_address.Size = new System.Drawing.Size(174, 16);
            this.nat_rural_post_address.TabIndex = 0;
            this.nat_rural_post_address.ReadOnly = true;
            this.nat_rural_post_address.Font = new System.Drawing.Font("Times New Roman", 10);
            this.nat_rural_post_address.BackColor = System.Drawing.Color.White;
            this.nat_rural_post_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.nat_rural_post_address.MaxLength = 200;
            this.nat_rural_post_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nat_rural_post_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatRuralPostAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nat_rural_post_address);
            #region n_29779754 define
            this.n_29779754 = new System.Windows.Forms.Label();
            this.n_29779754.Name = "n_29779754";
            this.n_29779754.Location = new System.Drawing.Point(6, 85);
            this.n_29779754.Size = new System.Drawing.Size(65, 16);
            this.n_29779754.TabIndex = 0;
            this.n_29779754.Font = new System.Drawing.Font("Times New Roman", 10);
            this.n_29779754.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_29779754.Text = "GST No: ";
            #endregion
            this.Controls.Add(n_29779754);
            #region nat_rural_post_gst_no define
            this.nat_rural_post_gst_no = new System.Windows.Forms.TextBox();
            this.nat_rural_post_gst_no.Name = "nat_rural_post_gst_no";
            this.nat_rural_post_gst_no.Location = new System.Drawing.Point(77, 85);
            this.nat_rural_post_gst_no.Size = new System.Drawing.Size(120, 16);
            this.nat_rural_post_gst_no.TabIndex = 0;
            this.nat_rural_post_gst_no.ReadOnly = true;
            this.nat_rural_post_gst_no.Font = new System.Drawing.Font("Times New Roman", 10);
            this.nat_rural_post_gst_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.nat_rural_post_gst_no.BackColor = System.Drawing.Color.White;
            this.nat_rural_post_gst_no.MaxLength = 20;
            this.nat_rural_post_gst_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nat_rural_post_gst_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatRuralPostGstNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nat_rural_post_gst_no);
            this.Size = new System.Drawing.Size(650, 300);
            this.BackColor = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label st_post;
        private System.Windows.Forms.Label n_58939966;
        private System.Windows.Forms.TextBox nat_rural_post_address;
        private System.Windows.Forms.Label n_29779754;
        private System.Windows.Forms.TextBox nat_rural_post_gst_no;
    }
}
