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
			components = new System.ComponentModel.Container();
			this.Name = "DAddressSearchPrimContact";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AddressSearchPrimContact);
			//
			// cust_surname_company
			//
			cust_surname_company = new System.Windows.Forms.TextBox();
			this.cust_surname_company.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.cust_surname_company.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_surname_company.ForeColor = System.Drawing.Color.Black;
			this.cust_surname_company.Location = new System.Drawing.Point(110, 2);
			this.cust_surname_company.MaxLength = 45;
			this.cust_surname_company.Name = "cust_surname_company";
			this.cust_surname_company.Size = new System.Drawing.Size(230, 13);
			this.cust_surname_company.TextAlign = HorizontalAlignment.Left;
			this.cust_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_surname_company.TabIndex = 30;
			this.Controls.Add(cust_surname_company);

			//
			// cust_initials
			//
			cust_initials = new System.Windows.Forms.TextBox();
			this.cust_initials.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.cust_initials.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_initials.ForeColor = System.Drawing.Color.Black;
			this.cust_initials.Location = new System.Drawing.Point(110, 23);
			this.cust_initials.MaxLength = 30;
			this.cust_initials.Name = "cust_initials";
			this.cust_initials.Size = new System.Drawing.Size(230, 13);
			this.cust_initials.TextAlign = HorizontalAlignment.Left;
			this.cust_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_initials.TabIndex = 40;
			this.Controls.Add(cust_initials);

			//
			// cust_surname_company_t
			//
			this.cust_surname_company_t = new System.Windows.Forms.Label();
			this.cust_surname_company_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_surname_company_t.ForeColor = System.Drawing.Color.Black;
			this.cust_surname_company_t.Location = new System.Drawing.Point(0, 1);
			this.cust_surname_company_t.Name = "cust_surname_company_t";
			this.cust_surname_company_t.Size = new System.Drawing.Size(108, 13);
			this.cust_surname_company_t.Text = "Surname / Company";
			this.cust_surname_company_t.TextAlign = ContentAlignment.MiddleRight;
			this.cust_surname_company_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(cust_surname_company_t);

			//
			// cust_initials_t
			//
			this.cust_initials_t = new System.Windows.Forms.Label();
			this.cust_initials_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_initials_t.ForeColor = System.Drawing.Color.Black;
			this.cust_initials_t.Location = new System.Drawing.Point(3, 22);
			this.cust_initials_t.Name = "cust_initials_t";
			this.cust_initials_t.Size = new System.Drawing.Size(105, 13);
			this.cust_initials_t.Text = "Initials / Firstnames";
			this.cust_initials_t.TextAlign = ContentAlignment.MiddleRight;
			this.cust_initials_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(cust_initials_t);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		}
		#endregion

	}
}
