using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DAddressSearchPrimContact
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

		private System.Windows.Forms.Label   cust_surname_company_t;
		private System.Windows.Forms.Label   cust_initials_t;
		private System.Windows.Forms.TextBox   cust_surname_company;
		private System.Windows.Forms.TextBox   cust_initials;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.cust_surname_company = new System.Windows.Forms.TextBox();
            this.cust_initials = new System.Windows.Forms.TextBox();
            this.cust_surname_company_t = new System.Windows.Forms.Label();
            this.cust_initials_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AddressSearchPrimContact);
            // 
            // cust_surname_company
            // 
            this.cust_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_surname_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_surname_company.ForeColor = System.Drawing.Color.Black;
            this.cust_surname_company.Location = new System.Drawing.Point(110, 4);
            this.cust_surname_company.MaxLength = 45;
            this.cust_surname_company.Name = "cust_surname_company";
            this.cust_surname_company.Size = new System.Drawing.Size(230, 20);
            this.cust_surname_company.TabIndex = 30;
            // 
            // cust_initials
            // 
            this.cust_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_initials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_initials.ForeColor = System.Drawing.Color.Black;
            this.cust_initials.Location = new System.Drawing.Point(110, 25);
            this.cust_initials.MaxLength = 30;
            this.cust_initials.Name = "cust_initials";
            this.cust_initials.Size = new System.Drawing.Size(230, 20);
            this.cust_initials.TabIndex = 40;
            // 
            // cust_surname_company_t
            // 
            this.cust_surname_company_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cust_surname_company_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_surname_company_t.ForeColor = System.Drawing.Color.Black;
            this.cust_surname_company_t.Location = new System.Drawing.Point(0, 3);
            this.cust_surname_company_t.Name = "cust_surname_company_t";
            this.cust_surname_company_t.Size = new System.Drawing.Size(108, 13);
            this.cust_surname_company_t.TabIndex = 41;
            this.cust_surname_company_t.Text = "Surname / Company";
            this.cust_surname_company_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_initials_t
            // 
            this.cust_initials_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cust_initials_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_initials_t.ForeColor = System.Drawing.Color.Black;
            this.cust_initials_t.Location = new System.Drawing.Point(3, 24);
            this.cust_initials_t.Name = "cust_initials_t";
            this.cust_initials_t.Size = new System.Drawing.Size(105, 13);
            this.cust_initials_t.TabIndex = 42;
            this.cust_initials_t.Text = "Initials / Firstnames";
            this.cust_initials_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DAddressSearchPrimContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cust_surname_company);
            this.Controls.Add(this.cust_initials);
            this.Controls.Add(this.cust_surname_company_t);
            this.Controls.Add(this.cust_initials_t);
            this.Name = "DAddressSearchPrimContact";
            this.Size = new System.Drawing.Size(601, 104);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
