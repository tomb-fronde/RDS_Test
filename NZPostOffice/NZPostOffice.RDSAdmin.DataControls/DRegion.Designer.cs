using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DRegion
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

		private System.Windows.Forms.TextBox   rgn_name;
		private System.Windows.Forms.TextBox   rgn_telephone;
		private System.Windows.Forms.TextBox   rgn_address;
		private System.Windows.Forms.Label   rgn_name_t;
		private System.Windows.Forms.Label   rgn_responsibility_centre_no_t;
		private System.Windows.Forms.TextBox   rgn_fax;
		private System.Windows.Forms.Label   rgn_expenditure_code_t;
		private System.Windows.Forms.Label   rgn_fax_t;
		private System.Windows.Forms.TextBox   rgn_responsibility_centre_no;
		private System.Windows.Forms.Label   rgn_telephone_t;
		private System.Windows.Forms.Label   rgn_rcm_manager_t;
		private System.Windows.Forms.TextBox   rgn_mobile;
		private System.Windows.Forms.TextBox   rgn_rcm_manager;
		private System.Windows.Forms.Label   rgn_address_t;
		private System.Windows.Forms.TextBox   rgn_expenditure_code;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.rgn_name_t = new System.Windows.Forms.Label();
            this.rgn_telephone_t = new System.Windows.Forms.Label();
            this.rgn_rcm_manager_t = new System.Windows.Forms.Label();
            this.rgn_address_t = new System.Windows.Forms.Label();
            this.rgn_fax_t = new System.Windows.Forms.Label();
            this.rgn_responsibility_centre_no_t = new System.Windows.Forms.Label();
            this.rgn_expenditure_code_t = new System.Windows.Forms.Label();
            this.rgn_address = new System.Windows.Forms.TextBox();
            this.rgn_rcm_manager = new System.Windows.Forms.TextBox();
            this.rgn_name = new System.Windows.Forms.TextBox();
            this.rgn_telephone = new System.Windows.Forms.TextBox();
            this.rgn_mobile = new System.Windows.Forms.TextBox();
            this.rgn_fax = new System.Windows.Forms.TextBox();
            this.rgn_responsibility_centre_no = new System.Windows.Forms.TextBox();
            this.rgn_expenditure_code = new System.Windows.Forms.TextBox();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.mobile_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.gb_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.Region);
            // 
            // rgn_name_t
            // 
            this.rgn_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rgn_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_name_t.ForeColor = System.Drawing.Color.Black;
            this.rgn_name_t.Location = new System.Drawing.Point(7, 21);
            this.rgn_name_t.Name = "rgn_name_t";
            this.rgn_name_t.Size = new System.Drawing.Size(57, 13);
            this.rgn_name_t.TabIndex = 0;
            this.rgn_name_t.Text = "Region";
            this.rgn_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgn_telephone_t
            // 
            this.rgn_telephone_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rgn_telephone_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_telephone_t.ForeColor = System.Drawing.Color.Black;
            this.rgn_telephone_t.Location = new System.Drawing.Point(284, 21);
            this.rgn_telephone_t.Name = "rgn_telephone_t";
            this.rgn_telephone_t.Size = new System.Drawing.Size(68, 13);
            this.rgn_telephone_t.TabIndex = 1;
            this.rgn_telephone_t.Text = "Telephone";
            this.rgn_telephone_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgn_rcm_manager_t
            // 
            this.rgn_rcm_manager_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rgn_rcm_manager_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_rcm_manager_t.ForeColor = System.Drawing.Color.Black;
            this.rgn_rcm_manager_t.Location = new System.Drawing.Point(7, 39);
            this.rgn_rcm_manager_t.Name = "rgn_rcm_manager_t";
            this.rgn_rcm_manager_t.Size = new System.Drawing.Size(57, 13);
            this.rgn_rcm_manager_t.TabIndex = 2;
            this.rgn_rcm_manager_t.Text = "RCM Manager";
            this.rgn_rcm_manager_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgn_address_t
            // 
            this.rgn_address_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rgn_address_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_address_t.ForeColor = System.Drawing.Color.Black;
            this.rgn_address_t.Location = new System.Drawing.Point(7, 57);
            this.rgn_address_t.Name = "rgn_address_t";
            this.rgn_address_t.Size = new System.Drawing.Size(57, 13);
            this.rgn_address_t.TabIndex = 3;
            this.rgn_address_t.Text = "Location";
            this.rgn_address_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgn_fax_t
            // 
            this.rgn_fax_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rgn_fax_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_fax_t.ForeColor = System.Drawing.Color.Black;
            this.rgn_fax_t.Location = new System.Drawing.Point(284, 57);
            this.rgn_fax_t.Name = "rgn_fax_t";
            this.rgn_fax_t.Size = new System.Drawing.Size(30, 13);
            this.rgn_fax_t.TabIndex = 4;
            this.rgn_fax_t.Text = "Fax";
            this.rgn_fax_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgn_responsibility_centre_no_t
            // 
            this.rgn_responsibility_centre_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rgn_responsibility_centre_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_responsibility_centre_no_t.ForeColor = System.Drawing.Color.Black;
            this.rgn_responsibility_centre_no_t.Location = new System.Drawing.Point(280, 76);
            this.rgn_responsibility_centre_no_t.Name = "rgn_responsibility_centre_no_t";
            this.rgn_responsibility_centre_no_t.Size = new System.Drawing.Size(127, 13);
            this.rgn_responsibility_centre_no_t.TabIndex = 5;
            this.rgn_responsibility_centre_no_t.Text = "Responsibility Centre No";
            this.rgn_responsibility_centre_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgn_expenditure_code_t
            // 
            this.rgn_expenditure_code_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rgn_expenditure_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_expenditure_code_t.ForeColor = System.Drawing.Color.Black;
            this.rgn_expenditure_code_t.Location = new System.Drawing.Point(284, 94);
            this.rgn_expenditure_code_t.Name = "rgn_expenditure_code_t";
            this.rgn_expenditure_code_t.Size = new System.Drawing.Size(93, 13);
            this.rgn_expenditure_code_t.TabIndex = 6;
            this.rgn_expenditure_code_t.Text = "Expenditure Code";
            this.rgn_expenditure_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgn_address
            // 
            this.rgn_address.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_address.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_address.Location = new System.Drawing.Point(69, 59);
            this.rgn_address.MaxLength = 200;
            this.rgn_address.Multiline = true;
            this.rgn_address.Name = "rgn_address";
            this.rgn_address.Size = new System.Drawing.Size(205, 50);
            this.rgn_address.TabIndex = 30;
            // 
            // rgn_rcm_manager
            // 
            this.rgn_rcm_manager.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_rcm_manager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnRcmManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_rcm_manager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_rcm_manager.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_rcm_manager.Location = new System.Drawing.Point(69, 39);
            this.rgn_rcm_manager.MaxLength = 40;
            this.rgn_rcm_manager.Name = "rgn_rcm_manager";
            this.rgn_rcm_manager.Size = new System.Drawing.Size(205, 20);
            this.rgn_rcm_manager.TabIndex = 20;
            // 
            // rgn_name
            // 
            this.rgn_name.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_name.Location = new System.Drawing.Point(69, 21);
            this.rgn_name.MaxLength = 40;
            this.rgn_name.Name = "rgn_name";
            this.rgn_name.Size = new System.Drawing.Size(205, 20);
            this.rgn_name.TabIndex = 10;
            // 
            // rgn_telephone
            // 
            this.rgn_telephone.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_telephone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_telephone.Location = new System.Drawing.Point(408, 21);
            this.rgn_telephone.MaxLength = 20;
            this.rgn_telephone.Name = "rgn_telephone";
            this.rgn_telephone.Size = new System.Drawing.Size(101, 20);
            this.rgn_telephone.TabIndex = 40;
            // 
            // rgn_mobile
            // 
            this.rgn_mobile.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_mobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_mobile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_mobile.Location = new System.Drawing.Point(408, 39);
            this.rgn_mobile.MaxLength = 0;
            this.rgn_mobile.Name = "rgn_mobile";
            this.rgn_mobile.Size = new System.Drawing.Size(101, 20);
            this.rgn_mobile.TabIndex = 50;
            // 
            // rgn_fax
            // 
            this.rgn_fax.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnFax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_fax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_fax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_fax.Location = new System.Drawing.Point(408, 57);
            this.rgn_fax.MaxLength = 11;
            this.rgn_fax.Name = "rgn_fax";
            this.rgn_fax.Size = new System.Drawing.Size(101, 20);
            this.rgn_fax.TabIndex = 60;
            // 
            // rgn_responsibility_centre_no
            // 
            this.rgn_responsibility_centre_no.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_responsibility_centre_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnResponsibilityCentreNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_responsibility_centre_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_responsibility_centre_no.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_responsibility_centre_no.Location = new System.Drawing.Point(408, 76);
            this.rgn_responsibility_centre_no.MaxLength = 10;
            this.rgn_responsibility_centre_no.Name = "rgn_responsibility_centre_no";
            this.rgn_responsibility_centre_no.Size = new System.Drawing.Size(55, 20);
            this.rgn_responsibility_centre_no.TabIndex = 70;
            // 
            // rgn_expenditure_code
            // 
            this.rgn_expenditure_code.BackColor = System.Drawing.SystemColors.Window;
            this.rgn_expenditure_code.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RgnExpenditureCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_expenditure_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rgn_expenditure_code.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_expenditure_code.Location = new System.Drawing.Point(408, 94);
            this.rgn_expenditure_code.MaxLength = 10;
            this.rgn_expenditure_code.Name = "rgn_expenditure_code";
            this.rgn_expenditure_code.Size = new System.Drawing.Size(55, 20);
            this.rgn_expenditure_code.TabIndex = 80;
            // 
            // gb_1
            // 
            this.gb_1.Controls.Add(this.mobile_t);
            this.gb_1.Controls.Add(this.rgn_rcm_manager);
            this.gb_1.Controls.Add(this.rgn_expenditure_code);
            this.gb_1.Controls.Add(this.rgn_name_t);
            this.gb_1.Controls.Add(this.rgn_responsibility_centre_no);
            this.gb_1.Controls.Add(this.rgn_telephone_t);
            this.gb_1.Controls.Add(this.rgn_fax);
            this.gb_1.Controls.Add(this.rgn_rcm_manager_t);
            this.gb_1.Controls.Add(this.rgn_mobile);
            this.gb_1.Controls.Add(this.rgn_address_t);
            this.gb_1.Controls.Add(this.rgn_telephone);
            this.gb_1.Controls.Add(this.rgn_fax_t);
            this.gb_1.Controls.Add(this.rgn_name);
            this.gb_1.Controls.Add(this.rgn_responsibility_centre_no_t);
            this.gb_1.Controls.Add(this.rgn_address);
            this.gb_1.Controls.Add(this.rgn_expenditure_code_t);
            this.gb_1.Location = new System.Drawing.Point(14, 6);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(516, 133);
            this.gb_1.TabIndex = 81;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "Region Information";
            // 
            // mobile_t
            // 
            this.mobile_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mobile_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mobile_t.ForeColor = System.Drawing.Color.Black;
            this.mobile_t.Location = new System.Drawing.Point(284, 39);
            this.mobile_t.Name = "mobile_t";
            this.mobile_t.Size = new System.Drawing.Size(93, 13);
            this.mobile_t.TabIndex = 82;
            this.mobile_t.Text = "Mobile";
            this.mobile_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.gb_1);
            this.Name = "DRegion";
            this.Size = new System.Drawing.Size(549, 157);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.gb_1.ResumeLayout(false);
            this.gb_1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private GroupBox gb_1;
        private Label mobile_t;

	}
}
