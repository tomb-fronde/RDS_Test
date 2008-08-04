namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractorSearch
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
            this.Name = "DContractorSearch";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractorSearch);
            #region n_8925963 define
            this.n_8925963 = new System.Windows.Forms.Label();
            this.n_8925963.Name = "n_8925963";
            this.n_8925963.Location = new System.Drawing.Point(132, 2);
            this.n_8925963.Size = new System.Drawing.Size(113, 13);
            this.n_8925963.TabIndex = 0;
            this.n_8925963.Font = new System.Drawing.Font("MS Sans Serif",8,System.Drawing.FontStyle.Underline|System.Drawing.FontStyle.Bold);
            this.n_8925963.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_8925963.Text = "Search Criteria";
            #endregion
            this.Controls.Add(n_8925963);
            #region c_surname_company_t define
            this.c_surname_company_t = new System.Windows.Forms.Label();
            this.c_surname_company_t.Name = "c_surname_company_t";
            this.c_surname_company_t.Location = new System.Drawing.Point(20, 22);
            this.c_surname_company_t.Size = new System.Drawing.Size(110, 13);
            this.c_surname_company_t.TabIndex = 0;
            this.c_surname_company_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_surname_company_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_surname_company_t.Text = "Surname / Company";
            #endregion
            this.Controls.Add(c_surname_company_t);
            #region c_first_names_t define
            this.c_first_names_t = new System.Windows.Forms.Label();
            this.c_first_names_t.Name = "c_first_names_t";
            this.c_first_names_t.Location = new System.Drawing.Point(67, 43);
            this.c_first_names_t.Size = new System.Drawing.Size(65, 13);
            this.c_first_names_t.TabIndex = 0;
            this.c_first_names_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_first_names_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_first_names_t.Text = "First Names";
            #endregion
            this.Controls.Add(c_first_names_t);
            #region contractor_supplier_no_t define
            this.contractor_supplier_no_t = new System.Windows.Forms.Label();
            this.contractor_supplier_no_t.Name = "contractor_supplier_no_t";
            this.contractor_supplier_no_t.Location = new System.Drawing.Point(67, 63);
            this.contractor_supplier_no_t.Size = new System.Drawing.Size(62, 13);
            this.contractor_supplier_no_t.TabIndex = 0;
            this.contractor_supplier_no_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contractor_supplier_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contractor_supplier_no_t.Text = "Supplier No";
            #endregion
            this.Controls.Add(contractor_supplier_no_t);
            #region contract_no_t define
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Location = new System.Drawing.Point(65, 84);
            this.contract_no_t.Size = new System.Drawing.Size(65, 13);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contract_no_t.Text = "Contract No";
            #endregion
            this.Controls.Add(contract_no_t);
            #region n_13224809 define
            this.n_13224809 = new System.Windows.Forms.Label();
            this.n_13224809.Name = "n_13224809";
            this.n_13224809.Location = new System.Drawing.Point(68, 106);
            this.n_13224809.Size = new System.Drawing.Size(60, 13);
            this.n_13224809.TabIndex = 0;
            this.n_13224809.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_13224809.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_13224809.Text = "Phone Day";
            #endregion
            this.Controls.Add(n_13224809);
            #region n_51914417 define
            this.n_51914417 = new System.Windows.Forms.Label();
            this.n_51914417.Name = "n_51914417";
            this.n_51914417.Location = new System.Drawing.Point(53, 127);
            this.n_51914417.Size = new System.Drawing.Size(76, 13);
            this.n_51914417.TabIndex = 0;
            this.n_51914417.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_51914417.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_51914417.Text = "Contract Type";
            #endregion
            this.Controls.Add(n_51914417);
            #region n_64576574 define
            this.n_64576574 = new System.Windows.Forms.Label();
            this.n_64576574.Name = "n_64576574";
            this.n_64576574.Location = new System.Drawing.Point(88, 149);
            this.n_64576574.Size = new System.Drawing.Size(41, 13);
            this.n_64576574.TabIndex = 0;
            this.n_64576574.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_64576574.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_64576574.Text = "Region";
            #endregion
            this.Controls.Add(n_64576574);
            #region c_surname_company define
            this.c_surname_company = new System.Windows.Forms.TextBox();
            this.c_surname_company.Name = "c_surname_company";
            this.c_surname_company.Location = new System.Drawing.Point(137, 19);
            this.c_surname_company.Size = new System.Drawing.Size(228, 20);
            this.c_surname_company.TabIndex = 10;
            this.c_surname_company.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_surname_company.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_surname_company.MaxLength = 40;
            #endregion
            this.Controls.Add(c_surname_company);
            #region c_first_names define
            this.c_first_names = new System.Windows.Forms.TextBox();
            this.c_first_names.Name = "c_first_names";
            this.c_first_names.Location = new System.Drawing.Point(137, 40);
            this.c_first_names.Size = new System.Drawing.Size(228, 20);
            this.c_first_names.TabIndex = 20;
            this.c_first_names.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_first_names.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_first_names.MaxLength = 40;
            #endregion
            this.Controls.Add(c_first_names);
            #region contractor_supplier_no define
            this.contractor_supplier_no = new System.Windows.Forms.MaskedTextBox();
            this.contractor_supplier_no.Name = "contractor_supplier_no";
            this.contractor_supplier_no.Location = new System.Drawing.Point(137, 60);
            this.contractor_supplier_no.Size = new System.Drawing.Size(41, 20);
            this.contractor_supplier_no.TabIndex = 30;
            this.contractor_supplier_no.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contractor_supplier_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contractor_supplier_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorSupplierNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
           // this.contractor_supplier_no.Mask = "######";
            this.contractor_supplier_no.DataBindings[0].FormatString = "######";
            this.contractor_supplier_no.DataBindings[0].NullValue = "";
            this.contractor_supplier_no.DataBindings[0].DataSourceNullValue = null;
            #endregion
            this.Controls.Add(contractor_supplier_no);
            #region contract_no define
            this.contract_no = new System.Windows.Forms.MaskedTextBox();
            this.contract_no.Name = "contract_no";
            this.contract_no.Location = new System.Drawing.Point(137, 81);
            this.contract_no.Size = new System.Drawing.Size(41, 20);
            this.contract_no.TabIndex = 40;
            this.contract_no.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.contract_no.Mask = "######";
            this.contract_no.DataBindings[0].FormatString = "######";
            this.contract_no.DataBindings[0].NullValue = "";
            this.contract_no.DataBindings[0].DataSourceNullValue = null;

            #endregion
            this.Controls.Add(contract_no);
            #region c_phone_day define
            this.c_phone_day = new System.Windows.Forms.TextBox();
            this.c_phone_day.Name = "c_phone_day";
            this.c_phone_day.Location = new System.Drawing.Point(137, 103);
            this.c_phone_day.Size = new System.Drawing.Size(62, 20);
            this.c_phone_day.TabIndex = 50;
            this.c_phone_day.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.c_phone_day.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c_phone_day.MaxLength = 11;
            this.c_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(c_phone_day);
            #region ct_key define
            this.ct_key = new Metex.Windows.DataEntityCombo();
          //  this.ct_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList ;
            this.ct_key.Name = "ct_key";
            this.ct_key.Location = new System.Drawing.Point(137, 125);
            this.ct_key.Size = new System.Drawing.Size(176, 21);
            this.ct_key.TabIndex = 60;
            this.ct_key.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.ct_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.AutoRetrieve = true;
            //this.ct_key.DataBindings[0].NullValue = null;
            this.ct_key.DataBindings[0].DataSourceNullValue = null;

            #endregion
            this.Controls.Add(ct_key);
            #region region_id define
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.Name = "region_id";
            this.region_id.Location = new System.Drawing.Point(137, 146);
            this.region_id.Size = new System.Drawing.Size(176, 21);
            this.region_id.TabIndex = 70;
            this.region_id.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.region_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.ValueMember = "RegionId";
            this.region_id.AutoRetrieve = true;
            #endregion
            this.Controls.Add(region_id);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }



        #endregion

        private System.Windows.Forms.Label n_8925963;
        private System.Windows.Forms.Label c_surname_company_t;
        private System.Windows.Forms.Label c_first_names_t;
        private System.Windows.Forms.Label contractor_supplier_no_t;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.Label n_13224809;
        private System.Windows.Forms.Label n_51914417;
        private System.Windows.Forms.Label n_64576574;
        private System.Windows.Forms.TextBox c_surname_company;
        private System.Windows.Forms.TextBox c_first_names;
        private System.Windows.Forms.MaskedTextBox contractor_supplier_no;
        private System.Windows.Forms.MaskedTextBox contract_no;
        private System.Windows.Forms.TextBox c_phone_day;
        private Metex.Windows.DataEntityCombo ct_key;
        private Metex.Windows.DataEntityCombo region_id;
    }
}
