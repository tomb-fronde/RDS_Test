using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DOutletForm
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

		private System.Windows.Forms.Label   o_address_t;
		private System.Windows.Forms.TextBox   o_name;
		private System.Windows.Forms.Label   o_manager_t;
		private System.Windows.Forms.TextBox   o_fax;
		private System.Windows.Forms.Label   o_telephone_t;
		private System.Windows.Forms.TextBox   o_telephone;
		private System.Windows.Forms.Label   ot_code_t;
		private System.Windows.Forms.TextBox   o_responsibility_code;
		private System.Windows.Forms.Label   t_1;
		private System.Windows.Forms.Label   o_fax_t;
		private System.Windows.Forms.Label   o_responsibility_code_t;
		private System.Windows.Forms.TextBox   o_manager;
		private Metex.Windows.DataEntityCombo   ot_code;
		private System.Windows.Forms.Label   o_name_t;
		private System.Windows.Forms.TextBox   o_phy_address;
		private System.Windows.Forms.TextBox   o_address;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.o_name_t = new System.Windows.Forms.Label();
            this.ot_code_t = new System.Windows.Forms.Label();
            this.o_manager_t = new System.Windows.Forms.Label();
            this.o_address_t = new System.Windows.Forms.Label();
            this.o_name = new System.Windows.Forms.TextBox();
            this.ot_code = new Metex.Windows.DataEntityCombo();
            this.o_manager = new System.Windows.Forms.TextBox();
            this.o_address = new System.Windows.Forms.TextBox();
            this.o_phy_address = new System.Windows.Forms.TextBox();
            this.t_1 = new System.Windows.Forms.Label();
            this.o_telephone_t = new System.Windows.Forms.Label();
            this.o_telephone = new System.Windows.Forms.TextBox();
            this.o_responsibility_code_t = new System.Windows.Forms.Label();
            this.o_responsibility_code = new System.Windows.Forms.TextBox();
            this.o_fax = new System.Windows.Forms.TextBox();
            this.o_fax_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.OutletForm);
            // 
            // o_name_t
            // 
            this.o_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.o_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name_t.ForeColor = System.Drawing.Color.Black;
            this.o_name_t.Location = new System.Drawing.Point(0, 3);
            this.o_name_t.Name = "o_name_t";
            this.o_name_t.Size = new System.Drawing.Size(71, 13);
            this.o_name_t.TabIndex = 0;
            this.o_name_t.Text = "Outlet Name";
            this.o_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ot_code_t
            // 
            this.ot_code_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ot_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ot_code_t.ForeColor = System.Drawing.Color.Black;
            this.ot_code_t.Location = new System.Drawing.Point(0, 23);
            this.ot_code_t.Name = "ot_code_t";
            this.ot_code_t.Size = new System.Drawing.Size(71, 13);
            this.ot_code_t.TabIndex = 1;
            this.ot_code_t.Text = "Outlet Type";
            this.ot_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_manager_t
            // 
            this.o_manager_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.o_manager_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_manager_t.ForeColor = System.Drawing.Color.Black;
            this.o_manager_t.Location = new System.Drawing.Point(0, 42);
            this.o_manager_t.Name = "o_manager_t";
            this.o_manager_t.Size = new System.Drawing.Size(55, 13);
            this.o_manager_t.TabIndex = 2;
            this.o_manager_t.Text = "Manager";
            this.o_manager_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_address_t
            // 
            this.o_address_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.o_address_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_address_t.ForeColor = System.Drawing.Color.Black;
            this.o_address_t.Location = new System.Drawing.Point(0, 61);
            this.o_address_t.Name = "o_address_t";
            this.o_address_t.Size = new System.Drawing.Size(59, 13);
            this.o_address_t.TabIndex = 3;
            this.o_address_t.Text = "Address";
            this.o_address_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_name
            // 
            this.o_name.BackColor = System.Drawing.Color.White;
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.ForeColor = System.Drawing.Color.Black;
            this.o_name.Location = new System.Drawing.Point(96, 2);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(205, 20);
            this.o_name.TabIndex = 10;
            // 
            // ot_code
            // 
            this.ot_code.AutoRetrieve = true;
            this.ot_code.BackColor = System.Drawing.Color.White;
            this.ot_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "OtCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ot_code.DisplayMember = "OtOutletType";
            this.ot_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ot_code.DropDownWidth = 205;
            this.ot_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ot_code.ForeColor = System.Drawing.Color.Black;
            this.ot_code.Location = new System.Drawing.Point(96, 21);
            this.ot_code.Name = "ot_code";
            this.ot_code.Size = new System.Drawing.Size(205, 21);
            this.ot_code.TabIndex = 20;
            this.ot_code.Value = null;
            this.ot_code.ValueMember = "OtCode";
            // 
            // o_manager
            // 
            this.o_manager.BackColor = System.Drawing.Color.White;
            this.o_manager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_manager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_manager.ForeColor = System.Drawing.Color.Black;
            this.o_manager.Location = new System.Drawing.Point(96, 41);
            this.o_manager.MaxLength = 40;
            this.o_manager.Name = "o_manager";
            this.o_manager.Size = new System.Drawing.Size(205, 20);
            this.o_manager.TabIndex = 30;
            // 
            // o_address
            // 
            this.o_address.BackColor = System.Drawing.Color.White;
            this.o_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_address.ForeColor = System.Drawing.Color.Black;
            this.o_address.Location = new System.Drawing.Point(96, 61);
            this.o_address.Name = "o_address";
            this.o_address.Multiline = true;
            this.o_address.Size = new System.Drawing.Size(205, 40);
            this.o_address.TabIndex = 40;
            // 
            // o_phy_address
            // 
            this.o_phy_address.BackColor = System.Drawing.Color.White;
            this.o_phy_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OPhyAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_phy_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_phy_address.ForeColor = System.Drawing.Color.Black;
            this.o_phy_address.Location = new System.Drawing.Point(96, 100);
            this.o_phy_address.Name = "o_phy_address";
            this.o_phy_address.Multiline = true;
            this.o_phy_address.Size = new System.Drawing.Size(205, 40);
            this.o_phy_address.TabIndex = 50;
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.Control;
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(0, 100);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(94, 13);
            this.t_1.TabIndex = 51;
            this.t_1.Text = "Physical Address";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_telephone_t
            // 
            this.o_telephone_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.o_telephone_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_telephone_t.ForeColor = System.Drawing.Color.Black;
            this.o_telephone_t.Location = new System.Drawing.Point(0, 146);
            this.o_telephone_t.Name = "o_telephone_t";
            this.o_telephone_t.Size = new System.Drawing.Size(71, 13);
            this.o_telephone_t.TabIndex = 52;
            this.o_telephone_t.Text = "Telephone";
            this.o_telephone_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_telephone
            // 
            this.o_telephone.BackColor = System.Drawing.Color.White;
            this.o_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_telephone.ForeColor = System.Drawing.Color.Black;
            this.o_telephone.Location = new System.Drawing.Point(96, 142);
            this.o_telephone.MaxLength = 11;
            this.o_telephone.Name = "o_telephone";
            this.o_telephone.Size = new System.Drawing.Size(104, 20);
            this.o_telephone.TabIndex = 60;
            // 
            // o_responsibility_code_t
            // 
            this.o_responsibility_code_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.o_responsibility_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_responsibility_code_t.ForeColor = System.Drawing.Color.Black;
            this.o_responsibility_code_t.Location = new System.Drawing.Point(0, 182);
            this.o_responsibility_code_t.Name = "o_responsibility_code_t";
            this.o_responsibility_code_t.Size = new System.Drawing.Size(92, 13);
            this.o_responsibility_code_t.TabIndex = 61;
            this.o_responsibility_code_t.Text = "Responsibility Code";
            this.o_responsibility_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_responsibility_code
            // 
            this.o_responsibility_code.BackColor = System.Drawing.Color.White;
            this.o_responsibility_code.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OResponsibilityCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_responsibility_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_responsibility_code.ForeColor = System.Drawing.Color.Black;
            this.o_responsibility_code.Location = new System.Drawing.Point(96, 184);
            this.o_responsibility_code.MaxLength = 10;
            this.o_responsibility_code.Name = "o_responsibility_code";
            this.o_responsibility_code.Size = new System.Drawing.Size(104, 20);
            this.o_responsibility_code.TabIndex = 80;
            // 
            // o_fax
            // 
            this.o_fax.BackColor = System.Drawing.Color.White;
            this.o_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OFax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_fax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_fax.ForeColor = System.Drawing.Color.Black;
            this.o_fax.Location = new System.Drawing.Point(96, 163);
            this.o_fax.MaxLength = 11;
            this.o_fax.Name = "o_fax";
            this.o_fax.Size = new System.Drawing.Size(104, 20);
            this.o_fax.TabIndex = 70;
            // 
            // o_fax_t
            // 
            this.o_fax_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.o_fax_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_fax_t.ForeColor = System.Drawing.Color.Black;
            this.o_fax_t.Location = new System.Drawing.Point(0, 163);
            this.o_fax_t.Name = "o_fax_t";
            this.o_fax_t.Size = new System.Drawing.Size(71, 13);
            this.o_fax_t.TabIndex = 81;
            this.o_fax_t.Text = "Fax";
            this.o_fax_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DOutletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.o_name_t);
            this.Controls.Add(this.ot_code_t);
            this.Controls.Add(this.o_manager_t);
            this.Controls.Add(this.o_address_t);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.ot_code);
            this.Controls.Add(this.o_manager);
            this.Controls.Add(this.o_address);
            this.Controls.Add(this.o_phy_address);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.o_telephone_t);
            this.Controls.Add(this.o_telephone);
            this.Controls.Add(this.o_responsibility_code_t);
            this.Controls.Add(this.o_responsibility_code);
            this.Controls.Add(this.o_fax);
            this.Controls.Add(this.o_fax_t);
            this.Name = "DOutletForm";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
