namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractor
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
            this.Name = "DContractor";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.Contractor);
            #region t_1 define
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Name = "t_1";
            this.t_1.Location = new System.Drawing.Point(141, 2);
            this.t_1.Size = new System.Drawing.Size(98, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_1.Text = "Owner Driver";
            #endregion
            this.Controls.Add(t_1);
            #region contractor_supplier_no define
            this.contractor_supplier_no = new System.Windows.Forms.MaskedTextBox();
            this.contractor_supplier_no.Name = "contractor_supplier_no";
            this.contractor_supplier_no.Location = new System.Drawing.Point(141, 19);
            this.contractor_supplier_no.Size = new System.Drawing.Size(68, 20);
            this.contractor_supplier_no.TabIndex = 0;
            this.contractor_supplier_no.Enabled = false;
            this.contractor_supplier_no.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contractor_supplier_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contractor_supplier_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorSupplierNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.contractor_supplier_no.Mask = "######";
            #endregion
            this.Controls.Add(contractor_supplier_no);
            #region c_surname_company define
            this.c_surname_company = new System.Windows.Forms.TextBox();
            this.c_surname_company.Name = "c_surname_company";
            this.c_surname_company.Location = new System.Drawing.Point(141, 67);
            this.c_surname_company.Size = new System.Drawing.Size(234, 20);
            this.c_surname_company.TabIndex = 20;
            this.c_surname_company.BackColor = System.Drawing.Color.Aqua;
            this.c_surname_company.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_surname_company.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_surname_company.MaxLength = 40;
            this.c_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_surname_company);
            #region c_phone_day_t define
            this.c_phone_day_t = new System.Windows.Forms.Label();
            this.c_phone_day_t.Name = "c_phone_day_t";
            this.c_phone_day_t.Location = new System.Drawing.Point(74, 200);
            this.c_phone_day_t.Size = new System.Drawing.Size(60, 13);
            this.c_phone_day_t.TabIndex = 0;
            this.c_phone_day_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_phone_day_t.Text = "Phone Day";
            #endregion
            this.Controls.Add(c_phone_day_t);
            #region contractor_supplier_no_t define
            this.contractor_supplier_no_t = new System.Windows.Forms.Label();
            this.contractor_supplier_no_t.Name = "contractor_supplier_no_t";
            this.contractor_supplier_no_t.Location = new System.Drawing.Point(70, 22);
            this.contractor_supplier_no_t.Size = new System.Drawing.Size(62, 13);
            this.contractor_supplier_no_t.TabIndex = 0;
            this.contractor_supplier_no_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contractor_supplier_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contractor_supplier_no_t.Text = "Supplier No";
            #endregion
            this.Controls.Add(contractor_supplier_no_t);
            #region c_title_t define
            this.c_title_t = new System.Windows.Forms.Label();
            this.c_title_t.Name = "c_title_t";
            this.c_title_t.Location = new System.Drawing.Point(105, 45);
            this.c_title_t.Size = new System.Drawing.Size(27, 13);
            this.c_title_t.TabIndex = 0;
            this.c_title_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_title_t.Text = "Title";
            #endregion
            this.Controls.Add(c_title_t);
            #region c_surname_company_t define
            this.c_surname_company_t = new System.Windows.Forms.Label();
            this.c_surname_company_t.Name = "c_surname_company_t";
            this.c_surname_company_t.Location = new System.Drawing.Point(28, 68);
            this.c_surname_company_t.Size = new System.Drawing.Size(105, 13);
            this.c_surname_company_t.TabIndex = 0;
            this.c_surname_company_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_surname_company_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_surname_company_t.Text = "Surname/Company";
            #endregion
            this.Controls.Add(c_surname_company_t);
            #region c_first_names_t define
            this.c_first_names_t = new System.Windows.Forms.Label();
            this.c_first_names_t.Name = "c_first_names_t";
            this.c_first_names_t.Location = new System.Drawing.Point(71, 92);
            this.c_first_names_t.Size = new System.Drawing.Size(62, 13);
            this.c_first_names_t.TabIndex = 0;
            this.c_first_names_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_first_names_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_first_names_t.Text = "First Names";
            #endregion
            this.Controls.Add(c_first_names_t);
            #region c_initials_t define
            this.c_initials_t = new System.Windows.Forms.Label();
            this.c_initials_t.Name = "c_initials_t";
            this.c_initials_t.Location = new System.Drawing.Point(99, 118);
            this.c_initials_t.Size = new System.Drawing.Size(33, 13);
            this.c_initials_t.TabIndex = 0;
            this.c_initials_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_initials_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_initials_t.Text = "Initials";
            #endregion
            this.Controls.Add(c_initials_t);
            #region c_address_t define
            this.c_address_t = new System.Windows.Forms.Label();
            this.c_address_t.Name = "c_address_t";
            this.c_address_t.Location = new System.Drawing.Point(90, 140);
            this.c_address_t.Size = new System.Drawing.Size(43, 13);
            this.c_address_t.TabIndex = 0;
            this.c_address_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_address_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_address_t.Text = "Address";
            #endregion
            this.Controls.Add(c_address_t);
            #region t_2 define
            this.t_2 = new System.Windows.Forms.Label();
            this.t_2.Name = "t_2";
            this.t_2.Location = new System.Drawing.Point(97, 224);
            this.t_2.Size = new System.Drawing.Size(40, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.t_2.Text = "Mobile";
            #endregion
            this.Controls.Add(t_2);
            #region c_title define
            this.c_title = new System.Windows.Forms.TextBox();
            this.c_title.Name = "c_title";
            this.c_title.Location = new System.Drawing.Point(141, 43);
            this.c_title.Size = new System.Drawing.Size(62, 20);
            this.c_title.TabIndex = 10;
            this.c_title.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_title.MaxLength = 10;
            this.c_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_title);
            #region c_first_names define
            this.c_first_names = new System.Windows.Forms.TextBox();
            this.c_first_names.Name = "c_first_names";
            this.c_first_names.Location = new System.Drawing.Point(141, 91);
            this.c_first_names.Size = new System.Drawing.Size(234, 20);
            this.c_first_names.TabIndex = 30;
            this.c_first_names.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_first_names.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_first_names.MaxLength = 40;
            this.c_first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_first_names);
            #region c_initials define
            this.c_initials = new System.Windows.Forms.TextBox();
            this.c_initials.Name = "c_initials";
            this.c_initials.Location = new System.Drawing.Point(141, 115);
            this.c_initials.Size = new System.Drawing.Size(73, 20);
            this.c_initials.TabIndex = 40;
            this.c_initials.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_initials.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_initials.MaxLength = 10;
            this.c_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_initials);
            #region c_phone_night_t define
            this.c_phone_night_t = new System.Windows.Forms.Label();
            this.c_phone_night_t.Name = "c_phone_night_t";
            this.c_phone_night_t.Location = new System.Drawing.Point(244, 200);
            this.c_phone_night_t.Size = new System.Drawing.Size(34, 13);
            this.c_phone_night_t.TabIndex = 0;
            this.c_phone_night_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_phone_night_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_phone_night_t.Text = "Night";
            #endregion
            this.Controls.Add(c_phone_night_t);
            #region c_phone_day define
            this.c_phone_day = new System.Windows.Forms.MaskedTextBox();
            this.c_phone_day.Name = "c_phone_day";
            this.c_phone_day.Location = new System.Drawing.Point(141, 196);
            this.c_phone_day.Size = new System.Drawing.Size(97, 20);
            this.c_phone_day.TabIndex = 60;
            this.c_phone_day.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_phone_day.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_phone_day.Mask = "(##) ###-######";
            #endregion
            this.Controls.Add(c_phone_day);
            #region c_mobile define
            this.c_mobile = new System.Windows.Forms.MaskedTextBox();
            this.c_mobile.Name = "c_mobile";
            this.c_mobile.Location = new System.Drawing.Point(141, 220);
            this.c_mobile.Size = new System.Drawing.Size(97, 20);
            this.c_mobile.TabIndex = 80;
            this.c_mobile.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_mobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_mobile.Mask = "(###) ###-#####";
            #endregion
            this.Controls.Add(c_mobile);
            #region c_address define
            this.c_address = new System.Windows.Forms.TextBox();
            this.c_address.Name = "c_address";
            this.c_address.Location = new System.Drawing.Point(141, 139);
            this.c_address.Size = new System.Drawing.Size(234, 53);
            this.c_address.TabIndex = 50;
            this.c_address.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_address.MaxLength = 200;
            this.c_address.Multiline = true;
            this.c_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_address);
            #region c_phone_night define
            this.c_phone_night = new System.Windows.Forms.MaskedTextBox();
            this.c_phone_night.Name = "c_phone_night";
            this.c_phone_night.Location = new System.Drawing.Point(279, 197);
            this.c_phone_night.Size = new System.Drawing.Size(97, 20);
            this.c_phone_night.TabIndex = 70;
            this.c_phone_night.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_phone_night.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CPhoneNight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_phone_night.Mask = "(##) ###-######";
            #endregion
            this.Controls.Add(c_phone_night);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.MaskedTextBox contractor_supplier_no;
        private System.Windows.Forms.TextBox c_surname_company;
        private System.Windows.Forms.Label c_phone_day_t;
        private System.Windows.Forms.Label contractor_supplier_no_t;
        private System.Windows.Forms.Label c_title_t;
        private System.Windows.Forms.Label c_surname_company_t;
        private System.Windows.Forms.Label c_first_names_t;
        private System.Windows.Forms.Label c_initials_t;
        private System.Windows.Forms.Label c_address_t;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.TextBox c_title;
        private System.Windows.Forms.TextBox c_first_names;
        private System.Windows.Forms.TextBox c_initials;
        private System.Windows.Forms.Label c_phone_night_t;
        private System.Windows.Forms.MaskedTextBox c_phone_day;
        private System.Windows.Forms.MaskedTextBox c_mobile;
        private System.Windows.Forms.TextBox c_address;
        private System.Windows.Forms.MaskedTextBox c_phone_night;
    }
}
