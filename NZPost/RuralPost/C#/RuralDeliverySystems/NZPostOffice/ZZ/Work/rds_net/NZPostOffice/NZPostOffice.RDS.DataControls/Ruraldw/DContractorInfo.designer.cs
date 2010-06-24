using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DContractorInfo
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

		private System.Windows.Forms.MaskedTextBox   contractor_c_mobile;
		private System.Windows.Forms.Label   contractor_contractor_supplier_no_t;
		private System.Windows.Forms.TextBox   contractor_contractor_supplier_no;
		private System.Windows.Forms.Label   t_1;
		private System.Windows.Forms.TextBox   contractor_c_surname_company;
		private System.Windows.Forms.MaskedTextBox   contractor_c_phone_day;
		private System.Windows.Forms.TextBox   contractor_c_first_names;
		private System.Windows.Forms.TextBox   contractor_c_salutation;
		private System.Windows.Forms.Label   contractor_c_mobile_t;
		private System.Windows.Forms.Label   contractor_c_phone_night_t;
		private System.Windows.Forms.Label   contractor_c_surname_company_t;
		private System.Windows.Forms.Label   contractor_c_phone_day_t;
		private System.Windows.Forms.MaskedTextBox   contractor_c_phone_night;
		private System.Windows.Forms.Label   contractor_c_first_names_t;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.contractor_contractor_supplier_no_t = new System.Windows.Forms.Label();
            this.contractor_contractor_supplier_no = new System.Windows.Forms.TextBox();
            this.contractor_c_surname_company_t = new System.Windows.Forms.Label();
            this.contractor_c_surname_company = new System.Windows.Forms.TextBox();
            this.contractor_c_first_names_t = new System.Windows.Forms.Label();
            this.contractor_c_first_names = new System.Windows.Forms.TextBox();
            this.contractor_c_salutation = new System.Windows.Forms.TextBox();
            this.contractor_c_phone_day_t = new System.Windows.Forms.Label();
            this.contractor_c_phone_day = new System.Windows.Forms.MaskedTextBox();
            this.contractor_c_phone_night_t = new System.Windows.Forms.Label();
            this.contractor_c_phone_night = new System.Windows.Forms.MaskedTextBox();
            this.contractor_c_mobile_t = new System.Windows.Forms.Label();
            this.contractor_c_mobile = new System.Windows.Forms.MaskedTextBox();
            this.t_1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractorInfo);
            // 
            // contractor_contractor_supplier_no_t
            // 
            this.contractor_contractor_supplier_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_contractor_supplier_no_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_contractor_supplier_no_t.ForeColor = System.Drawing.Color.Black;
            this.contractor_contractor_supplier_no_t.Location = new System.Drawing.Point(5, 5);
            this.contractor_contractor_supplier_no_t.Name = "contractor_contractor_supplier_no_t";
            this.contractor_contractor_supplier_no_t.Size = new System.Drawing.Size(76, 14);
            this.contractor_contractor_supplier_no_t.TabIndex = 0;
            this.contractor_contractor_supplier_no_t.Text = "Suppiler No";
            this.contractor_contractor_supplier_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contractor_contractor_supplier_no
            // 
            this.contractor_contractor_supplier_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorContractorSupplierNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_contractor_supplier_no.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_contractor_supplier_no.ForeColor = System.Drawing.Color.Black;
            this.contractor_contractor_supplier_no.Location = new System.Drawing.Point(106, 5);
            this.contractor_contractor_supplier_no.MaxLength = 0;
            this.contractor_contractor_supplier_no.Name = "contractor_contractor_supplier_no";
            this.contractor_contractor_supplier_no.ReadOnly = true;
            this.contractor_contractor_supplier_no.Size = new System.Drawing.Size(60, 20);
            this.contractor_contractor_supplier_no.TabIndex = 1;
            this.contractor_contractor_supplier_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // contractor_c_surname_company_t
            // 
            this.contractor_c_surname_company_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_c_surname_company_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_surname_company_t.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_surname_company_t.Location = new System.Drawing.Point(5, 24);
            this.contractor_c_surname_company_t.Name = "contractor_c_surname_company_t";
            this.contractor_c_surname_company_t.Size = new System.Drawing.Size(100, 14);
            this.contractor_c_surname_company_t.TabIndex = 2;
            this.contractor_c_surname_company_t.Text = "Surname/Company";
            this.contractor_c_surname_company_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contractor_c_surname_company
            // 
            this.contractor_c_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_surname_company.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_surname_company.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_surname_company.Location = new System.Drawing.Point(106, 24);
            this.contractor_c_surname_company.MaxLength = 40;
            this.contractor_c_surname_company.Name = "contractor_c_surname_company";
            this.contractor_c_surname_company.ReadOnly = true;
            this.contractor_c_surname_company.Size = new System.Drawing.Size(205, 20);
            this.contractor_c_surname_company.TabIndex = 3;
            // 
            // contractor_c_first_names_t
            // 
            this.contractor_c_first_names_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_c_first_names_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_first_names_t.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_first_names_t.Location = new System.Drawing.Point(5, 43);
            this.contractor_c_first_names_t.Name = "contractor_c_first_names_t";
            this.contractor_c_first_names_t.Size = new System.Drawing.Size(79, 14);
            this.contractor_c_first_names_t.TabIndex = 4;
            this.contractor_c_first_names_t.Text = "First Names";
            this.contractor_c_first_names_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contractor_c_first_names
            // 
            this.contractor_c_first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_first_names.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_first_names.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_first_names.Location = new System.Drawing.Point(106, 43);
            this.contractor_c_first_names.MaxLength = 40;
            this.contractor_c_first_names.Name = "contractor_c_first_names";
            this.contractor_c_first_names.ReadOnly = true;
            this.contractor_c_first_names.Size = new System.Drawing.Size(205, 20);
            this.contractor_c_first_names.TabIndex = 5;
            // 
            // contractor_c_salutation
            // 
            this.contractor_c_salutation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCSalutation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_salutation.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_salutation.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_salutation.Location = new System.Drawing.Point(106, 62);
            this.contractor_c_salutation.MaxLength = 0;
            this.contractor_c_salutation.Name = "contractor_c_salutation";
            this.contractor_c_salutation.ReadOnly = true;
            this.contractor_c_salutation.Size = new System.Drawing.Size(205, 20);
            this.contractor_c_salutation.TabIndex = 6;
            // 
            // contractor_c_phone_day_t
            // 
            this.contractor_c_phone_day_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_c_phone_day_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_phone_day_t.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_phone_day_t.Location = new System.Drawing.Point(5, 82);
            this.contractor_c_phone_day_t.Name = "contractor_c_phone_day_t";
            this.contractor_c_phone_day_t.Size = new System.Drawing.Size(71, 14);
            this.contractor_c_phone_day_t.TabIndex = 7;
            this.contractor_c_phone_day_t.Text = "Phone Day";
            this.contractor_c_phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contractor_c_phone_day
            // 
            this.contractor_c_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_phone_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_phone_day.Location = new System.Drawing.Point(106, 82);
            this.contractor_c_phone_day.Mask = "(##) ###-######";
            this.contractor_c_phone_day.Name = "contractor_c_phone_day";
            this.contractor_c_phone_day.ReadOnly = true;
            this.contractor_c_phone_day.Size = new System.Drawing.Size(97, 20);
            this.contractor_c_phone_day.TabIndex = 8;
            // 
            // contractor_c_phone_night_t
            // 
            this.contractor_c_phone_night_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_c_phone_night_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_phone_night_t.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_phone_night_t.Location = new System.Drawing.Point(38, 101);
            this.contractor_c_phone_night_t.Name = "contractor_c_phone_night_t";
            this.contractor_c_phone_night_t.Size = new System.Drawing.Size(33, 14);
            this.contractor_c_phone_night_t.TabIndex = 9;
            this.contractor_c_phone_night_t.Text = "Night";
            this.contractor_c_phone_night_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contractor_c_phone_night
            // 
            this.contractor_c_phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCPhoneNight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_phone_night.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_phone_night.Location = new System.Drawing.Point(106, 101);
            this.contractor_c_phone_night.Mask = "(##) ###-######";
            this.contractor_c_phone_night.Name = "contractor_c_phone_night";
            this.contractor_c_phone_night.ReadOnly = true;
            this.contractor_c_phone_night.Size = new System.Drawing.Size(97, 20);
            this.contractor_c_phone_night.TabIndex = 10;
            // 
            // contractor_c_mobile_t
            // 
            this.contractor_c_mobile_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_c_mobile_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contractor_c_mobile_t.ForeColor = System.Drawing.Color.Black;
            this.contractor_c_mobile_t.Location = new System.Drawing.Point(38, 120);
            this.contractor_c_mobile_t.Name = "contractor_c_mobile_t";
            this.contractor_c_mobile_t.Size = new System.Drawing.Size(44, 14);
            this.contractor_c_mobile_t.TabIndex = 11;
            this.contractor_c_mobile_t.Text = "Mobile";
            this.contractor_c_mobile_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contractor_c_mobile
            // 
            this.contractor_c_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_mobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_mobile.Location = new System.Drawing.Point(106, 120);
            this.contractor_c_mobile.Mask = "(###) ###-#####";
            this.contractor_c_mobile.Name = "contractor_c_mobile";
            this.contractor_c_mobile.ReadOnly = true;
            this.contractor_c_mobile.Size = new System.Drawing.Size(97, 20);
            this.contractor_c_mobile.TabIndex = 12;
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(5, 63);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(65, 14);
            this.t_1.TabIndex = 13;
            this.t_1.Text = "Salutation";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DContractorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contractor_contractor_supplier_no_t);
            this.Controls.Add(this.contractor_contractor_supplier_no);
            this.Controls.Add(this.contractor_c_surname_company_t);
            this.Controls.Add(this.contractor_c_surname_company);
            this.Controls.Add(this.contractor_c_first_names_t);
            this.Controls.Add(this.contractor_c_first_names);
            this.Controls.Add(this.contractor_c_salutation);
            this.Controls.Add(this.contractor_c_phone_day_t);
            this.Controls.Add(this.contractor_c_phone_day);
            this.Controls.Add(this.contractor_c_phone_night_t);
            this.Controls.Add(this.contractor_c_phone_night);
            this.Controls.Add(this.contractor_c_mobile_t);
            this.Controls.Add(this.contractor_c_mobile);
            this.Controls.Add(this.t_1);
            this.Name = "DContractorInfo";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
