using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralmailmerge;

namespace NZPostOffice.RDS.DataControls.Ruralmailmerge
{
	partial class DMailmergeCustDownloadData
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

		private System.Windows.Forms.TextBox   contractor_c_mobile;
		private System.Windows.Forms.TextBox   address_adr_alpha;
		private System.Windows.Forms.TextBox   outlet_o_address;
		private System.Windows.Forms.TextBox   cust_mailing_address_no;
		private System.Windows.Forms.TextBox   contractor_c_title;
		private System.Windows.Forms.TextBox   primary_contact;
		private System.Windows.Forms.TextBox   rds_customer_cust_surname_company;
		private System.Windows.Forms.TextBox   c_mobile2;
		private System.Windows.Forms.TextBox   outlet_o_name;
		private System.Windows.Forms.TextBox   outlet_type_ot_outlet_type;
		private System.Windows.Forms.TextBox   address_adr_no;
		private System.Windows.Forms.TextBox   rds_customer_cust_dir_listing_text;
		private System.Windows.Forms.TextBox   contractor_c_initials;
		private System.Windows.Forms.TextBox   region_rgn_fax;
		private System.Windows.Forms.TextBox   cust_address_locality;
		private System.Windows.Forms.TextBox   rds_customer_cust_dir_listing_ind;
		private System.Windows.Forms.TextBox   cust_delivery_days;
		private System.Windows.Forms.TextBox   cust_deliverydays;
		private System.Windows.Forms.TextBox   region_rgn_telephone;
		private System.Windows.Forms.TextBox   cust_name;
		private System.Windows.Forms.TextBox   contractor_c_surname_company;
		private System.Windows.Forms.TextBox   rds_customer_cust_initials;
		private System.Windows.Forms.TextBox   cust_address_town;
		private System.Windows.Forms.TextBox   contractor_c_phone_day;
		private System.Windows.Forms.TextBox   rds_customer_cust_date_first_loaded;
		private System.Windows.Forms.TextBox   cust_address_road;
		private System.Windows.Forms.TextBox   outlet_o_manager;
		private System.Windows.Forms.TextBox   region_rgn_name;
		private System.Windows.Forms.TextBox   contractor_c_first_names;
		private System.Windows.Forms.TextBox   contractor_c_salutation;
		private System.Windows.Forms.TextBox   contractor_c_email_address;
		private System.Windows.Forms.TextBox   region_rgn_rcm_manager;
		private System.Windows.Forms.TextBox   address_dp_id;
		private System.Windows.Forms.TextBox   rds_customer_cust_title;
		private System.Windows.Forms.TextBox   cust_category;
		private System.Windows.Forms.TextBox   address_cust_rd_number;
		private System.Windows.Forms.TextBox   ownerdriver_name;
		private System.Windows.Forms.TextBox   outlet_o_telephone;
		private System.Windows.Forms.TextBox   adr_post_code;
		private System.Windows.Forms.TextBox   ccontract_no;
		private System.Windows.Forms.TextBox   region_rgn_address;
		private System.Windows.Forms.TextBox   contractor_c_phone_night;
		private System.Windows.Forms.TextBox   cust_date_left;
		private System.Windows.Forms.TextBox   outlet_o_fax;
		private System.Windows.Forms.TextBox   rds_customer_cust_id;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DMailmergeCustDownloadData";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralmailmerge.MailmergeCustDownloadData);
			//
			// cust_address_road
			//
			cust_address_road = new System.Windows.Forms.TextBox();
			this.cust_address_road.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_address_road.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_address_road.ForeColor = System.Drawing.Color.Black;
			this.cust_address_road.Location = new System.Drawing.Point(121, 33);
			this.cust_address_road.MaxLength = 45;
			this.cust_address_road.Name = "cust_address_road";
			this.cust_address_road.Size = new System.Drawing.Size(230, 16);
			this.cust_address_road.TextAlign = HorizontalAlignment.Left;
			this.cust_address_road.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_address_road.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustAddressRoad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_address_road.ReadOnly=true;
			this.Controls.Add(cust_address_road);

			//
			// cust_address_locality
			//
			cust_address_locality = new System.Windows.Forms.TextBox();
			this.cust_address_locality.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_address_locality.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_address_locality.ForeColor = System.Drawing.Color.Black;
			this.cust_address_locality.Location = new System.Drawing.Point(352, 33);
			this.cust_address_locality.MaxLength = 45;
			this.cust_address_locality.Name = "cust_address_locality";
			this.cust_address_locality.Size = new System.Drawing.Size(230, 16);
			this.cust_address_locality.TextAlign = HorizontalAlignment.Left;
			this.cust_address_locality.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_address_locality.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustAddressLocality", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_address_locality.ReadOnly=true;
			this.Controls.Add(cust_address_locality);

			//
			// cust_address_town
			//
			cust_address_town = new System.Windows.Forms.TextBox();
			this.cust_address_town.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_address_town.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_address_town.ForeColor = System.Drawing.Color.Black;
			this.cust_address_town.Location = new System.Drawing.Point(584, 33);
			this.cust_address_town.MaxLength = 45;
			this.cust_address_town.Name = "cust_address_town";
			this.cust_address_town.Size = new System.Drawing.Size(230, 16);
			this.cust_address_town.TextAlign = HorizontalAlignment.Left;
			this.cust_address_town.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_address_town.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustAddressTown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_address_town.ReadOnly=true;
			this.Controls.Add(cust_address_town);

			//
			// cust_deliverydays
			//
			cust_deliverydays = new System.Windows.Forms.TextBox();
			this.cust_deliverydays.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_deliverydays.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_deliverydays.ForeColor = System.Drawing.Color.Black;
			this.cust_deliverydays.Location = new System.Drawing.Point(468, 62);
			this.cust_deliverydays.MaxLength = 32000;
			this.cust_deliverydays.Name = "cust_deliverydays";
			this.cust_deliverydays.Size = new System.Drawing.Size(468, 16);
			this.cust_deliverydays.TextAlign = HorizontalAlignment.Left;
			this.cust_deliverydays.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_deliverydays.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustDeliverydays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_deliverydays.ReadOnly=true;
			this.Controls.Add(cust_deliverydays);

			//
			// ownerdriver_name
			//
			ownerdriver_name = new System.Windows.Forms.TextBox();
			this.ownerdriver_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ownerdriver_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ownerdriver_name.ForeColor = System.Drawing.Color.Black;
			this.ownerdriver_name.Location = new System.Drawing.Point(488, 88);
			this.ownerdriver_name.MaxLength = 92;
			this.ownerdriver_name.Name = "ownerdriver_name";
			this.ownerdriver_name.Size = new System.Drawing.Size(466, 16);
			this.ownerdriver_name.TextAlign = HorizontalAlignment.Left;
			this.ownerdriver_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ownerdriver_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OwnerdriverName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.ownerdriver_name.ReadOnly=true;
			this.Controls.Add(ownerdriver_name);

			//
			// ccontract_no
			//
			ccontract_no = new System.Windows.Forms.TextBox();
			this.ccontract_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ccontract_no.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ccontract_no.ForeColor = System.Drawing.Color.Black;
			this.ccontract_no.Location = new System.Drawing.Point(808, 175);
			this.ccontract_no.MaxLength = 23;
			this.ccontract_no.Name = "ccontract_no";
			this.ccontract_no.Size = new System.Drawing.Size(120, 16);
			this.ccontract_no.TextAlign = HorizontalAlignment.Left;
			this.ccontract_no.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ccontract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CcontractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.ccontract_no.ReadOnly=true;
			this.Controls.Add(ccontract_no);

			//
			// cust_name
			//
			cust_name = new System.Windows.Forms.TextBox();
			this.cust_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_name.ForeColor = System.Drawing.Color.Black;
			this.cust_name.Location = new System.Drawing.Point(733, 5);
			this.cust_name.MaxLength = 86;
			this.cust_name.Name = "cust_name";
			this.cust_name.Size = new System.Drawing.Size(213, 16);
			this.cust_name.TextAlign = HorizontalAlignment.Left;
			this.cust_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_name.ReadOnly=true;
			this.Controls.Add(cust_name);

			//
			// cust_mailing_address_no
			//
			cust_mailing_address_no = new System.Windows.Forms.TextBox();
			this.cust_mailing_address_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_mailing_address_no.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_mailing_address_no.ForeColor = System.Drawing.Color.Black;
			this.cust_mailing_address_no.Location = new System.Drawing.Point(49, 208);
			this.cust_mailing_address_no.MaxLength = 0;
			this.cust_mailing_address_no.Name = "cust_mailing_address_no";
			this.cust_mailing_address_no.Size = new System.Drawing.Size(91, 14);
			this.cust_mailing_address_no.TextAlign = HorizontalAlignment.Left;
			this.cust_mailing_address_no.BackColor = System.Drawing.Color.White;
			this.cust_mailing_address_no.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustMailingAddressNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_mailing_address_no.ReadOnly=true;
			this.Controls.Add(cust_mailing_address_no);

			//
			// cust_category
			//
			cust_category = new System.Windows.Forms.TextBox();
			this.cust_category.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_category.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_category.ForeColor = System.Drawing.Color.Black;
			this.cust_category.Location = new System.Drawing.Point(280, 62);
			this.cust_category.MaxLength = 7;
			this.cust_category.Name = "cust_category";
			this.cust_category.Size = new System.Drawing.Size(185, 16);
			this.cust_category.TextAlign = HorizontalAlignment.Left;
			this.cust_category.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.cust_category.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustCategory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_category.ReadOnly=true;
			this.Controls.Add(cust_category);

			//
			// cust_delivery_days
			//
			cust_delivery_days = new System.Windows.Forms.TextBox();
			this.cust_delivery_days.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_delivery_days.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_delivery_days.ForeColor = System.Drawing.Color.Black;
			this.cust_delivery_days.Location = new System.Drawing.Point(5630, 0);
			this.cust_delivery_days.MaxLength = 0;
			this.cust_delivery_days.Name = "cust_delivery_days";
			this.cust_delivery_days.Size = new System.Drawing.Size(35, 13);
			this.cust_delivery_days.TextAlign = HorizontalAlignment.Left;
			this.cust_delivery_days.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_delivery_days.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustDeliveryDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_delivery_days.ReadOnly=true;
			this.Controls.Add(cust_delivery_days);

			//
			// rds_customer_cust_id
			//
			rds_customer_cust_id = new System.Windows.Forms.TextBox();
			this.rds_customer_cust_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_customer_cust_id.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rds_customer_cust_id.ForeColor = System.Drawing.Color.Black;
			this.rds_customer_cust_id.Location = new System.Drawing.Point(5665, 0);
			this.rds_customer_cust_id.MaxLength = 0;
			this.rds_customer_cust_id.Name = "rds_customer_cust_id";
			this.rds_customer_cust_id.Size = new System.Drawing.Size(217, 13);
			this.rds_customer_cust_id.TextAlign = HorizontalAlignment.Left;
			this.rds_customer_cust_id.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_customer_cust_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsCustomerCustId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_customer_cust_id.ReadOnly=true;
			this.Controls.Add(rds_customer_cust_id);

			//
			// rds_customer_cust_surname_company
			//
			rds_customer_cust_surname_company = new System.Windows.Forms.TextBox();
			this.rds_customer_cust_surname_company.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_customer_cust_surname_company.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rds_customer_cust_surname_company.ForeColor = System.Drawing.Color.Black;
			this.rds_customer_cust_surname_company.Location = new System.Drawing.Point(5882, 0);
			this.rds_customer_cust_surname_company.MaxLength = 0;
			this.rds_customer_cust_surname_company.Name = "rds_customer_cust_surname_company";
			this.rds_customer_cust_surname_company.Size = new System.Drawing.Size(227, 13);
			this.rds_customer_cust_surname_company.TextAlign = HorizontalAlignment.Left;
			this.rds_customer_cust_surname_company.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_customer_cust_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsCustomerCustSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_customer_cust_surname_company.ReadOnly=true;
			this.Controls.Add(rds_customer_cust_surname_company);

			//
			// rds_customer_cust_initials
			//
			rds_customer_cust_initials = new System.Windows.Forms.TextBox();
			this.rds_customer_cust_initials.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_customer_cust_initials.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rds_customer_cust_initials.ForeColor = System.Drawing.Color.Black;
			this.rds_customer_cust_initials.Location = new System.Drawing.Point(6110, 0);
			this.rds_customer_cust_initials.MaxLength = 0;
			this.rds_customer_cust_initials.Name = "rds_customer_cust_initials";
			this.rds_customer_cust_initials.Size = new System.Drawing.Size(151, 13);
			this.rds_customer_cust_initials.TextAlign = HorizontalAlignment.Left;
			this.rds_customer_cust_initials.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_customer_cust_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsCustomerCustInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_customer_cust_initials.ReadOnly=true;
			this.Controls.Add(rds_customer_cust_initials);

			//
			// rds_customer_cust_date_first_loaded
			//
			rds_customer_cust_date_first_loaded = new System.Windows.Forms.TextBox();
			this.rds_customer_cust_date_first_loaded.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_customer_cust_date_first_loaded.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rds_customer_cust_date_first_loaded.ForeColor = System.Drawing.Color.Black;
			this.rds_customer_cust_date_first_loaded.Location = new System.Drawing.Point(6261, 0);
			this.rds_customer_cust_date_first_loaded.MaxLength = 0;
			this.rds_customer_cust_date_first_loaded.Name = "rds_customer_cust_date_first_loaded";
			this.rds_customer_cust_date_first_loaded.Size = new System.Drawing.Size(96, 13);
			this.rds_customer_cust_date_first_loaded.TextAlign = HorizontalAlignment.Left;
			this.rds_customer_cust_date_first_loaded.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_customer_cust_date_first_loaded.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsCustomerCustDateFirstLoaded", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_customer_cust_date_first_loaded.ReadOnly=true;
			this.Controls.Add(rds_customer_cust_date_first_loaded);

			//
			// cust_date_left
			//
			cust_date_left = new System.Windows.Forms.TextBox();
			this.cust_date_left.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cust_date_left.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_date_left.ForeColor = System.Drawing.Color.Black;
			this.cust_date_left.Location = new System.Drawing.Point(6357, 0);
			this.cust_date_left.MaxLength = 0;
			this.cust_date_left.Name = "cust_date_left";
			this.cust_date_left.Size = new System.Drawing.Size(217, 13);
			this.cust_date_left.TextAlign = HorizontalAlignment.Left;
			this.cust_date_left.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_date_left.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CustDateLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cust_date_left.ReadOnly=true;
			this.Controls.Add(cust_date_left);

			//
			// rds_customer_cust_dir_listing_ind
			//
			rds_customer_cust_dir_listing_ind = new System.Windows.Forms.TextBox();
			this.rds_customer_cust_dir_listing_ind.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_customer_cust_dir_listing_ind.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rds_customer_cust_dir_listing_ind.ForeColor = System.Drawing.Color.Black;
			this.rds_customer_cust_dir_listing_ind.Location = new System.Drawing.Point(6575, 0);
			this.rds_customer_cust_dir_listing_ind.MaxLength = 0;
			this.rds_customer_cust_dir_listing_ind.Name = "rds_customer_cust_dir_listing_ind";
			this.rds_customer_cust_dir_listing_ind.Size = new System.Drawing.Size(5, 13);
			this.rds_customer_cust_dir_listing_ind.TextAlign = HorizontalAlignment.Left;
			this.rds_customer_cust_dir_listing_ind.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_customer_cust_dir_listing_ind.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsCustomerCustDirListingInd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_customer_cust_dir_listing_ind.ReadOnly=true;
			this.Controls.Add(rds_customer_cust_dir_listing_ind);

			//
			// rds_customer_cust_dir_listing_text
			//
			rds_customer_cust_dir_listing_text = new System.Windows.Forms.TextBox();
			this.rds_customer_cust_dir_listing_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_customer_cust_dir_listing_text.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rds_customer_cust_dir_listing_text.ForeColor = System.Drawing.Color.Black;
			this.rds_customer_cust_dir_listing_text.Location = new System.Drawing.Point(6580, 0);
			this.rds_customer_cust_dir_listing_text.MaxLength = 0;
			this.rds_customer_cust_dir_listing_text.Name = "rds_customer_cust_dir_listing_text";
			this.rds_customer_cust_dir_listing_text.Size = new System.Drawing.Size(302, 13);
			this.rds_customer_cust_dir_listing_text.TextAlign = HorizontalAlignment.Left;
			this.rds_customer_cust_dir_listing_text.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_customer_cust_dir_listing_text.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsCustomerCustDirListingText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_customer_cust_dir_listing_text.ReadOnly=true;
			this.Controls.Add(rds_customer_cust_dir_listing_text);

			//
			// contractor_c_title
			//
			contractor_c_title = new System.Windows.Forms.TextBox();
			this.contractor_c_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_title.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_title.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_title.Location = new System.Drawing.Point(6883, 0);
			this.contractor_c_title.MaxLength = 0;
			this.contractor_c_title.Name = "contractor_c_title";
			this.contractor_c_title.Size = new System.Drawing.Size(51, 13);
			this.contractor_c_title.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_title.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_title.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_title.ReadOnly=true;
			this.Controls.Add(contractor_c_title);

			//
			// contractor_c_first_names
			//
			contractor_c_first_names = new System.Windows.Forms.TextBox();
			this.contractor_c_first_names.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_first_names.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_first_names.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_first_names.Location = new System.Drawing.Point(6934, 0);
			this.contractor_c_first_names.MaxLength = 0;
			this.contractor_c_first_names.Name = "contractor_c_first_names";
			this.contractor_c_first_names.Size = new System.Drawing.Size(201, 13);
			this.contractor_c_first_names.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_first_names.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_first_names.ReadOnly=true;
			this.Controls.Add(contractor_c_first_names);

			//
			// contractor_c_surname_company
			//
			contractor_c_surname_company = new System.Windows.Forms.TextBox();
			this.contractor_c_surname_company.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_surname_company.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_surname_company.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_surname_company.Location = new System.Drawing.Point(7135, 0);
			this.contractor_c_surname_company.MaxLength = 0;
			this.contractor_c_surname_company.Name = "contractor_c_surname_company";
			this.contractor_c_surname_company.Size = new System.Drawing.Size(202, 13);
			this.contractor_c_surname_company.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_surname_company.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_surname_company.ReadOnly=true;
			this.Controls.Add(contractor_c_surname_company);

			//
			// contractor_c_phone_day
			//
			contractor_c_phone_day = new System.Windows.Forms.TextBox();
			this.contractor_c_phone_day.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_phone_day.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_phone_day.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_phone_day.Location = new System.Drawing.Point(7338, 0);
			this.contractor_c_phone_day.MaxLength = 0;
			this.contractor_c_phone_day.Name = "contractor_c_phone_day";
			this.contractor_c_phone_day.Size = new System.Drawing.Size(76, 13);
			this.contractor_c_phone_day.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_phone_day.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_phone_day.ReadOnly=true;
			this.Controls.Add(contractor_c_phone_day);

			//
			// contractor_c_phone_night
			//
			contractor_c_phone_night = new System.Windows.Forms.TextBox();
			this.contractor_c_phone_night.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_phone_night.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_phone_night.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_phone_night.Location = new System.Drawing.Point(7414, 0);
			this.contractor_c_phone_night.MaxLength = 0;
			this.contractor_c_phone_night.Name = "contractor_c_phone_night";
			this.contractor_c_phone_night.Size = new System.Drawing.Size(76, 13);
			this.contractor_c_phone_night.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_phone_night.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCPhoneNight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_phone_night.ReadOnly=true;
			this.Controls.Add(contractor_c_phone_night);

			//
			// contractor_c_mobile
			//
			contractor_c_mobile = new System.Windows.Forms.TextBox();
			this.contractor_c_mobile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_mobile.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_mobile.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_mobile.Location = new System.Drawing.Point(7490, 0);
			this.contractor_c_mobile.MaxLength = 0;
			this.contractor_c_mobile.Name = "contractor_c_mobile";
			this.contractor_c_mobile.Size = new System.Drawing.Size(76, 13);
			this.contractor_c_mobile.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_mobile.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_mobile.ReadOnly=true;
			this.Controls.Add(contractor_c_mobile);

			//
			// contractor_c_salutation
			//
			contractor_c_salutation = new System.Windows.Forms.TextBox();
			this.contractor_c_salutation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_salutation.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_salutation.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_salutation.Location = new System.Drawing.Point(7566, 0);
			this.contractor_c_salutation.MaxLength = 0;
			this.contractor_c_salutation.Name = "contractor_c_salutation";
			this.contractor_c_salutation.Size = new System.Drawing.Size(201, 13);
			this.contractor_c_salutation.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_salutation.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_salutation.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCSalutation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_salutation.ReadOnly=true;
			this.Controls.Add(contractor_c_salutation);

			//
			// outlet_o_name
			//
			outlet_o_name = new System.Windows.Forms.TextBox();
			this.outlet_o_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.outlet_o_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.outlet_o_name.ForeColor = System.Drawing.Color.Black;
			this.outlet_o_name.Location = new System.Drawing.Point(7768, 0);
			this.outlet_o_name.MaxLength = 0;
			this.outlet_o_name.Name = "outlet_o_name";
			this.outlet_o_name.Size = new System.Drawing.Size(201, 13);
			this.outlet_o_name.TextAlign = HorizontalAlignment.Left;
			this.outlet_o_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.outlet_o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OutletOName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.outlet_o_name.ReadOnly=true;
			this.Controls.Add(outlet_o_name);

			//
			// outlet_o_address
			//
			outlet_o_address = new System.Windows.Forms.TextBox();
			this.outlet_o_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.outlet_o_address.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.outlet_o_address.ForeColor = System.Drawing.Color.Black;
			this.outlet_o_address.Location = new System.Drawing.Point(7969, 0);
			this.outlet_o_address.MaxLength = 0;
			this.outlet_o_address.Name = "outlet_o_address";
			this.outlet_o_address.Size = new System.Drawing.Size(769, 13);
			this.outlet_o_address.TextAlign = HorizontalAlignment.Left;
			this.outlet_o_address.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.outlet_o_address.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OutletOAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.outlet_o_address.ReadOnly=true;
			this.Controls.Add(outlet_o_address);

			//
			// outlet_o_telephone
			//
			outlet_o_telephone = new System.Windows.Forms.TextBox();
			this.outlet_o_telephone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.outlet_o_telephone.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.outlet_o_telephone.ForeColor = System.Drawing.Color.Black;
			this.outlet_o_telephone.Location = new System.Drawing.Point(8739, 0);
			this.outlet_o_telephone.MaxLength = 0;
			this.outlet_o_telephone.Name = "outlet_o_telephone";
			this.outlet_o_telephone.Size = new System.Drawing.Size(56, 13);
			this.outlet_o_telephone.TextAlign = HorizontalAlignment.Left;
			this.outlet_o_telephone.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.outlet_o_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OutletOTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.outlet_o_telephone.ReadOnly=true;
			this.Controls.Add(outlet_o_telephone);

			//
			// outlet_o_fax
			//
			outlet_o_fax = new System.Windows.Forms.TextBox();
			this.outlet_o_fax.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.outlet_o_fax.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.outlet_o_fax.ForeColor = System.Drawing.Color.Black;
			this.outlet_o_fax.Location = new System.Drawing.Point(8796, 0);
			this.outlet_o_fax.MaxLength = 0;
			this.outlet_o_fax.Name = "outlet_o_fax";
			this.outlet_o_fax.Size = new System.Drawing.Size(56, 13);
			this.outlet_o_fax.TextAlign = HorizontalAlignment.Left;
			this.outlet_o_fax.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.outlet_o_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OutletOFax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.outlet_o_fax.ReadOnly=true;
			this.Controls.Add(outlet_o_fax);

			//
			// outlet_o_manager
			//
			outlet_o_manager = new System.Windows.Forms.TextBox();
			this.outlet_o_manager.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.outlet_o_manager.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.outlet_o_manager.ForeColor = System.Drawing.Color.Black;
			this.outlet_o_manager.Location = new System.Drawing.Point(8852, 0);
			this.outlet_o_manager.MaxLength = 0;
			this.outlet_o_manager.Name = "outlet_o_manager";
			this.outlet_o_manager.Size = new System.Drawing.Size(202, 13);
			this.outlet_o_manager.TextAlign = HorizontalAlignment.Left;
			this.outlet_o_manager.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.outlet_o_manager.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OutletOManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.outlet_o_manager.ReadOnly=true;
			this.Controls.Add(outlet_o_manager);

			//
			// region_rgn_name
			//
			region_rgn_name = new System.Windows.Forms.TextBox();
			this.region_rgn_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.region_rgn_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.region_rgn_name.ForeColor = System.Drawing.Color.Black;
			this.region_rgn_name.Location = new System.Drawing.Point(9054, 0);
			this.region_rgn_name.MaxLength = 0;
			this.region_rgn_name.Name = "region_rgn_name";
			this.region_rgn_name.Size = new System.Drawing.Size(201, 13);
			this.region_rgn_name.TextAlign = HorizontalAlignment.Left;
			this.region_rgn_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_rgn_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RegionRgnName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.region_rgn_name.ReadOnly=true;
			this.Controls.Add(region_rgn_name);

			//
			// region_rgn_rcm_manager
			//
			region_rgn_rcm_manager = new System.Windows.Forms.TextBox();
			this.region_rgn_rcm_manager.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.region_rgn_rcm_manager.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.region_rgn_rcm_manager.ForeColor = System.Drawing.Color.Black;
			this.region_rgn_rcm_manager.Location = new System.Drawing.Point(9256, 0);
			this.region_rgn_rcm_manager.MaxLength = 0;
			this.region_rgn_rcm_manager.Name = "region_rgn_rcm_manager";
			this.region_rgn_rcm_manager.Size = new System.Drawing.Size(201, 13);
			this.region_rgn_rcm_manager.TextAlign = HorizontalAlignment.Left;
			this.region_rgn_rcm_manager.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_rgn_rcm_manager.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RegionRgnRcmManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.region_rgn_rcm_manager.ReadOnly=true;
			this.Controls.Add(region_rgn_rcm_manager);

			//
			// region_rgn_fax
			//
			region_rgn_fax = new System.Windows.Forms.TextBox();
			this.region_rgn_fax.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.region_rgn_fax.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.region_rgn_fax.ForeColor = System.Drawing.Color.Black;
			this.region_rgn_fax.Location = new System.Drawing.Point(9457, 0);
			this.region_rgn_fax.MaxLength = 0;
			this.region_rgn_fax.Name = "region_rgn_fax";
			this.region_rgn_fax.Size = new System.Drawing.Size(56, 13);
			this.region_rgn_fax.TextAlign = HorizontalAlignment.Left;
			this.region_rgn_fax.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_rgn_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RegionRgnFax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.region_rgn_fax.ReadOnly=true;
			this.Controls.Add(region_rgn_fax);

			//
			// region_rgn_telephone
			//
			region_rgn_telephone = new System.Windows.Forms.TextBox();
			this.region_rgn_telephone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.region_rgn_telephone.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.region_rgn_telephone.ForeColor = System.Drawing.Color.Black;
			this.region_rgn_telephone.Location = new System.Drawing.Point(9513, 0);
			this.region_rgn_telephone.MaxLength = 0;
			this.region_rgn_telephone.Name = "region_rgn_telephone";
			this.region_rgn_telephone.Size = new System.Drawing.Size(101, 13);
			this.region_rgn_telephone.TextAlign = HorizontalAlignment.Left;
			this.region_rgn_telephone.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_rgn_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RegionRgnTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.region_rgn_telephone.ReadOnly=true;
			this.Controls.Add(region_rgn_telephone);

			//
			// region_rgn_address
			//
			region_rgn_address = new System.Windows.Forms.TextBox();
			this.region_rgn_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.region_rgn_address.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.region_rgn_address.ForeColor = System.Drawing.Color.Black;
			this.region_rgn_address.Location = new System.Drawing.Point(9615, 0);
			this.region_rgn_address.MaxLength = 0;
			this.region_rgn_address.Name = "region_rgn_address";
			this.region_rgn_address.Size = new System.Drawing.Size(769, 13);
			this.region_rgn_address.TextAlign = HorizontalAlignment.Left;
			this.region_rgn_address.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_rgn_address.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RegionRgnAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.region_rgn_address.ReadOnly=true;
			this.Controls.Add(region_rgn_address);

			//
			// address_cust_rd_number
			//
			address_cust_rd_number = new System.Windows.Forms.TextBox();
			this.address_cust_rd_number.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.address_cust_rd_number.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.address_cust_rd_number.ForeColor = System.Drawing.Color.Black;
			this.address_cust_rd_number.Location = new System.Drawing.Point(10384, 0);
			this.address_cust_rd_number.MaxLength = 0;
			this.address_cust_rd_number.Name = "address_cust_rd_number";
			this.address_cust_rd_number.Size = new System.Drawing.Size(202, 13);
			this.address_cust_rd_number.TextAlign = HorizontalAlignment.Left;
			this.address_cust_rd_number.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.address_cust_rd_number.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "AddressCustRdNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.address_cust_rd_number.ReadOnly=true;
			this.Controls.Add(address_cust_rd_number);

			//
			// contractor_c_initials
			//
			contractor_c_initials = new System.Windows.Forms.TextBox();
			this.contractor_c_initials.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_initials.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_initials.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_initials.Location = new System.Drawing.Point(10587, 0);
			this.contractor_c_initials.MaxLength = 0;
			this.contractor_c_initials.Name = "contractor_c_initials";
			this.contractor_c_initials.Size = new System.Drawing.Size(50, 13);
			this.contractor_c_initials.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_initials.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_initials.ReadOnly=true;
			this.Controls.Add(contractor_c_initials);

			//
			// outlet_type_ot_outlet_type
			//
			outlet_type_ot_outlet_type = new System.Windows.Forms.TextBox();
			this.outlet_type_ot_outlet_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.outlet_type_ot_outlet_type.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.outlet_type_ot_outlet_type.ForeColor = System.Drawing.Color.Black;
			this.outlet_type_ot_outlet_type.Location = new System.Drawing.Point(10637, 0);
			this.outlet_type_ot_outlet_type.MaxLength = 0;
			this.outlet_type_ot_outlet_type.Name = "outlet_type_ot_outlet_type";
			this.outlet_type_ot_outlet_type.Size = new System.Drawing.Size(151, 13);
			this.outlet_type_ot_outlet_type.TextAlign = HorizontalAlignment.Left;
			this.outlet_type_ot_outlet_type.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.outlet_type_ot_outlet_type.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OutletTypeOtOutletType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.outlet_type_ot_outlet_type.ReadOnly=true;
			this.Controls.Add(outlet_type_ot_outlet_type);

			//
			// rds_customer_cust_title
			//
			rds_customer_cust_title = new System.Windows.Forms.TextBox();
			this.rds_customer_cust_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_customer_cust_title.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rds_customer_cust_title.ForeColor = System.Drawing.Color.Black;
			this.rds_customer_cust_title.Location = new System.Drawing.Point(10789, 0);
			this.rds_customer_cust_title.MaxLength = 0;
			this.rds_customer_cust_title.Name = "rds_customer_cust_title";
			this.rds_customer_cust_title.Size = new System.Drawing.Size(50, 13);
			this.rds_customer_cust_title.TextAlign = HorizontalAlignment.Left;
			this.rds_customer_cust_title.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_customer_cust_title.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsCustomerCustTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_customer_cust_title.ReadOnly=true;
			this.Controls.Add(rds_customer_cust_title);

			//
			// address_adr_no
			//
			address_adr_no = new System.Windows.Forms.TextBox();
			this.address_adr_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.address_adr_no.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.address_adr_no.ForeColor = System.Drawing.Color.Black;
			this.address_adr_no.Location = new System.Drawing.Point(10839, 0);
			this.address_adr_no.MaxLength = 0;
			this.address_adr_no.Name = "address_adr_no";
			this.address_adr_no.Size = new System.Drawing.Size(101, 13);
			this.address_adr_no.TextAlign = HorizontalAlignment.Left;
			this.address_adr_no.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.address_adr_no.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "AddressAdrNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.address_adr_no.ReadOnly=true;
			this.Controls.Add(address_adr_no);

			//
			// adr_post_code
			//
			adr_post_code = new System.Windows.Forms.TextBox();
			this.adr_post_code.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.adr_post_code.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.adr_post_code.ForeColor = System.Drawing.Color.Black;
			this.adr_post_code.Location = new System.Drawing.Point(10940, 0);
			this.adr_post_code.MaxLength = 0;
			this.adr_post_code.Name = "adr_post_code";
			this.adr_post_code.Size = new System.Drawing.Size(19, 13);
			this.adr_post_code.TextAlign = HorizontalAlignment.Left;
			this.adr_post_code.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.adr_post_code.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "AdrPostCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.adr_post_code.ReadOnly=true;
			this.Controls.Add(adr_post_code);

			//
			// address_adr_alpha
			//
			address_adr_alpha = new System.Windows.Forms.TextBox();
			this.address_adr_alpha.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.address_adr_alpha.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.address_adr_alpha.ForeColor = System.Drawing.Color.Black;
			this.address_adr_alpha.Location = new System.Drawing.Point(10960, 0);
			this.address_adr_alpha.MaxLength = 0;
			this.address_adr_alpha.Name = "address_adr_alpha";
			this.address_adr_alpha.Size = new System.Drawing.Size(101, 13);
			this.address_adr_alpha.TextAlign = HorizontalAlignment.Left;
			this.address_adr_alpha.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.address_adr_alpha.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "AddressAdrAlpha", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.address_adr_alpha.ReadOnly=true;
			this.Controls.Add(address_adr_alpha);

			//
			// c_mobile2
			//
			c_mobile2 = new System.Windows.Forms.TextBox();
			this.c_mobile2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.c_mobile2.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.c_mobile2.ForeColor = System.Drawing.Color.Black;
			this.c_mobile2.Location = new System.Drawing.Point(11061, 0);
			this.c_mobile2.MaxLength = 0;
			this.c_mobile2.Name = "c_mobile2";
			this.c_mobile2.Size = new System.Drawing.Size(61, 13);
			this.c_mobile2.TextAlign = HorizontalAlignment.Left;
			this.c_mobile2.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.c_mobile2.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "CMobile2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.c_mobile2.ReadOnly=true;
			this.Controls.Add(c_mobile2);

			//
			// primary_contact
			//
			primary_contact = new System.Windows.Forms.TextBox();
			this.primary_contact.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.primary_contact.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.primary_contact.ForeColor = System.Drawing.Color.Black;
			this.primary_contact.Location = new System.Drawing.Point(11122, 0);
			this.primary_contact.MaxLength = 0;
			this.primary_contact.Name = "primary_contact";
			this.primary_contact.Size = new System.Drawing.Size(61, 13);
			this.primary_contact.TextAlign = HorizontalAlignment.Left;
			this.primary_contact.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.primary_contact.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "PrimaryContact", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.primary_contact.ReadOnly=true;
			this.Controls.Add(primary_contact);

			//
			// contractor_c_email_address
			//
			contractor_c_email_address = new System.Windows.Forms.TextBox();
			this.contractor_c_email_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contractor_c_email_address.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_c_email_address.ForeColor = System.Drawing.Color.Black;
			this.contractor_c_email_address.Location = new System.Drawing.Point(11183, 0);
			this.contractor_c_email_address.MaxLength = 0;
			this.contractor_c_email_address.Name = "contractor_c_email_address";
			this.contractor_c_email_address.Size = new System.Drawing.Size(202, 13);
			this.contractor_c_email_address.TextAlign = HorizontalAlignment.Left;
			this.contractor_c_email_address.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_c_email_address.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractorCEmailAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contractor_c_email_address.ReadOnly=true;
			this.Controls.Add(contractor_c_email_address);

			//
			// address_dp_id
			//
			address_dp_id = new System.Windows.Forms.TextBox();
			this.address_dp_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.address_dp_id.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.address_dp_id.ForeColor = System.Drawing.Color.Black;
			this.address_dp_id.Location = new System.Drawing.Point(11386, 0);
			this.address_dp_id.MaxLength = 0;
			this.address_dp_id.Name = "address_dp_id";
			this.address_dp_id.Size = new System.Drawing.Size(217, 13);
			this.address_dp_id.TextAlign = HorizontalAlignment.Left;
			this.address_dp_id.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.address_dp_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "AddressDpId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.address_dp_id.ReadOnly=true;
			this.Controls.Add(address_dp_id);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
		}
		#endregion

	}
}
