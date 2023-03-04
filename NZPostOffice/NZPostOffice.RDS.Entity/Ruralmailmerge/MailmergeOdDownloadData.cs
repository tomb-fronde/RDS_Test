using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralmailmerge
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contractor_supplier_no", "_contractor_contractor_supplier_no", "contractor")]
	[MapInfo("c_title", "_contractor_c_title", "contractor")]
	[MapInfo("c_initials", "_contractor_c_initials", "contractor")]
	[MapInfo("c_first_names", "_contractor_c_first_names", "contractor")]
	[MapInfo("c_surname_company", "_contractor_c_surname_company", "contractor")]
	[MapInfo("driver_name", "_driver_name", "contract")]
	[MapInfo("c_address", "_contractor_c_address", "contractor")]
	[MapInfo("c_phone_day", "_c_phone_day", "contract")]
	[MapInfo("c_phone_night", "_c_phone_night", "contract")]
	[MapInfo("c_mobile", "_c_mobile", "contract")]
	[MapInfo("c_mobile2", "_c_mobile2", "contract")]
	[MapInfo("primary_contact", "_primary_contact", "contract")]
	[MapInfo("c_email_address", "_c_email_address", "contractor")]
	[MapInfo("c_bank_account_no", "_contractor_c_tax_rate", "contractor")]
	[MapInfo("c_gst_number", "_contractor_c_ird_no", "contractor")]
	[MapInfo("c_tax_rate", "_c_tax_rate", "contractor")]
	[MapInfo("c_ird_no", "_contractor_c_ird_no", "contractor")]
	[MapInfo("con_title", "_contract_con_title", "contract")]
	[MapInfo("cr_effective_date", "_contractor_renewals_cr_effective_date", "contractor_renewals")]
	[MapInfo("con_start_date", "_contract_renewals_con_start_date", "contract_renewals")]
	[MapInfo("con_expiry_date", "_contract_renewals_con_expiry_date", "contract_renewals")]
	[MapInfo("o_name", "_outlet_o_name", "outlet")]
	[MapInfo("o_address", "_outlet_o_address", "outlet")]
	[MapInfo("o_telephone", "_outlet_o_telephone", "outlet")]
	[MapInfo("o_fax", "_outlet_o_fax", "outlet")]
	[MapInfo("o_manager", "_outlet_o_manager", "outlet")]
	[MapInfo("rgn_name", "_region_rgn_name", "region")]
	[MapInfo("rgn_rcm_manager", "_region_rgn_rcm_manager", "region")]
	[MapInfo("rgn_fax", "_region_rgn_fax", "region")]
	[MapInfo("rgn_telephone", "_region_rgn_telephone", "region")]
	[MapInfo("rgn_address", "_region_rgn_address", "region")]
	[MapInfo("c_salutation", "_contractor_c_salutation", "contractor")]
	[MapInfo("c_salutation", "_cc_salutation", "contract")]
	[MapInfo("contract_no", "_contract_contract_no", "contract")]
	[System.Serializable()]

	public class MailmergeOdDownloadData : Entity<MailmergeOdDownloadData>
	{
		#region Business Methods
		[DBField()]
		private int?  _contractor_contractor_supplier_no;

		[DBField()]
		private string  _contractor_c_title;

		[DBField()]
		private string  _contractor_c_initials;

		[DBField()]
		private string  _contractor_c_first_names;

		[DBField()]
		private string  _contractor_c_surname_company;

		[DBField()]
		private string  _driver_name;

		[DBField()]
		private string  _contractor_c_address;

		[DBField()]
		private string  _c_phone_day;

		[DBField()]
		private string  _c_phone_night;

		[DBField()]
		private string  _c_mobile;

		[DBField()]
		private string  _c_mobile2;

		[DBField()]
		private string  _primary_contact;

		[DBField()]
		private string  _c_email_address;

		[DBField()]
		private string  _contractor_c_tax_rate;

		[DBField()]
		private string  _contractor_c_ird_no;

		[DBField()]
		private decimal?  _c_tax_rate;

		[DBField()]
		private string  _contractor_c_ird_no1;

		[DBField()]
		private string  _contract_con_title;

		[DBField()]
		private DateTime?  _contractor_renewals_cr_effective_date;

		[DBField()]
		private DateTime?  _contract_renewals_con_start_date;

		[DBField()]
		private DateTime?  _contract_renewals_con_expiry_date;

		[DBField()]
		private string  _outlet_o_name;

		[DBField()]
		private string  _outlet_o_address;

		[DBField()]
		private string  _outlet_o_telephone;

		[DBField()]
		private string  _outlet_o_fax;

		[DBField()]
		private string  _outlet_o_manager;

		[DBField()]
		private string  _region_rgn_name;

		[DBField()]
		private string  _region_rgn_rcm_manager;

		[DBField()]
		private string  _region_rgn_fax;

		[DBField()]
		private string  _region_rgn_telephone;

		[DBField()]
		private string  _region_rgn_address;

		[DBField()]
		private string  _contractor_c_salutation;

		[DBField()]
		private string  _cc_salutation;

		[DBField()]
		private int?  _contract_contract_no;


		public virtual int? ContractorContractorSupplierNo
		{
			get
			{
                CanReadProperty("ContractorContractorSupplierNo", true);
				return _contractor_contractor_supplier_no;
			}
			set
			{
                CanWriteProperty("ContractorContractorSupplierNo", true);
				if ( _contractor_contractor_supplier_no != value )
				{
					_contractor_contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCTitle
		{
			get
			{
                CanReadProperty("ContractorCTitle", true);
				return _contractor_c_title;
			}
			set
			{
                CanWriteProperty("ContractorCTitle", true);
				if ( _contractor_c_title != value )
				{
					_contractor_c_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCInitials
		{
			get
			{
                CanReadProperty("ContractorCInitials", true);
				return _contractor_c_initials;
			}
			set
			{
                CanWriteProperty("ContractorCInitials", true);
				if ( _contractor_c_initials != value )
				{
					_contractor_c_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCFirstNames
		{
			get
			{
                CanReadProperty("ContractorCFirstNames", true);
				return _contractor_c_first_names;
			}
			set
			{
                CanWriteProperty("ContractorCFirstNames", true);
				if ( _contractor_c_first_names != value )
				{
					_contractor_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCSurnameCompany
		{
			get
			{
                CanReadProperty("ContractorCSurnameCompany", true);
				return _contractor_c_surname_company;
			}
			set
			{
                CanWriteProperty("ContractorCSurnameCompany", true);
				if ( _contractor_c_surname_company != value )
				{
					_contractor_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DriverName
		{
			get
			{
                CanReadProperty("DriverName", true);
				return _driver_name;
			}
			set
			{
                CanWriteProperty("DriverName", true);
				if ( _driver_name != value )
				{
					_driver_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCAddress
		{
			get
			{
                CanReadProperty("ContractorCAddress", true);
				return _contractor_c_address;
			}
			set
			{
                CanWriteProperty("ContractorCAddress", true);
				if ( _contractor_c_address != value )
				{
					_contractor_c_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CPhoneDay
		{
			get
			{
                CanReadProperty("CPhoneDay", true);
				return _c_phone_day;
			}
			set
			{
                CanWriteProperty("CPhoneDay", true);
				if ( _c_phone_day != value )
				{
					_c_phone_day = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CPhoneNight
		{
			get
			{
                CanReadProperty("CPhoneNight", true);
				return _c_phone_night;
			}
			set
			{
                CanWriteProperty("CPhoneNight", true);
				if ( _c_phone_night != value )
				{
					_c_phone_night = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CMobile
		{
			get
			{
                CanReadProperty("CMobile", true);
				return _c_mobile;
			}
			set
			{
                CanWriteProperty("CMobile", true);
				if ( _c_mobile != value )
				{
					_c_mobile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CMobile2
		{
			get
			{
                CanReadProperty("CMobile2", true);
				return _c_mobile2;
			}
			set
			{
                CanWriteProperty("CMobile2", true);
				if ( _c_mobile2 != value )
				{
					_c_mobile2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrimaryContact
		{
			get
			{
                CanReadProperty("PrimaryContact", true);
				return _primary_contact;
			}
			set
			{
                CanWriteProperty("PrimaryContact", true);
				if ( _primary_contact != value )
				{
					_primary_contact = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CEmailAddress
		{
			get
			{
                CanReadProperty("CEmailAddress", true);
				return _c_email_address;
			}
			set
			{
                CanWriteProperty("CEmailAddress", true);
				if ( _c_email_address != value )
				{
					_c_email_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCTaxRate
		{
			get
			{
                CanReadProperty("ContractorCTaxRate", true);
				return _contractor_c_tax_rate;
			}
			set
			{
                CanWriteProperty("ContractorCTaxRate", true);
				if ( _contractor_c_tax_rate != value )
				{
					_contractor_c_tax_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCIrdNo
		{
			get
			{
                CanReadProperty("ContractorCIrdNo", true);
				return _contractor_c_ird_no;
			}
			set
			{
                CanWriteProperty("ContractorCIrdNo", true);
				if ( _contractor_c_ird_no != value )
				{
					_contractor_c_ird_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? CTaxRate
		{
			get
			{
                CanReadProperty("CTaxRate", true);
				return _c_tax_rate;
			}
			set
			{
                CanWriteProperty("CTaxRate", true);
				if ( _c_tax_rate != value )
				{
					_c_tax_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCIrdNo1
		{
			get
			{
                CanReadProperty("ContractorCIrdNo1", true);
				return _contractor_c_ird_no1;
			}
			set
			{
                CanWriteProperty("ContractorCIrdNo1", true);
				if ( _contractor_c_ird_no1 != value )
				{
					_contractor_c_ird_no1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractConTitle
		{
			get
			{
                CanReadProperty("ContractConTitle", true);
				return _contract_con_title;
			}
			set
			{
                CanWriteProperty("ContractConTitle", true);
				if ( _contract_con_title != value )
				{
					_contract_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ContractorRenewalsCrEffectiveDate
		{
			get
			{
                CanReadProperty("ContractorRenewalsCrEffectiveDate", true);
				return _contractor_renewals_cr_effective_date;
			}
			set
			{
                CanWriteProperty("ContractorRenewalsCrEffectiveDate", true);
				if ( _contractor_renewals_cr_effective_date != value )
				{
					_contractor_renewals_cr_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ContractRenewalsConStartDate
		{
			get
			{
                CanReadProperty("ContractRenewalsConStartDate", true);
				return _contract_renewals_con_start_date;
			}
			set
			{
                CanWriteProperty("ContractRenewalsConStartDate", true);
				if ( _contract_renewals_con_start_date != value )
				{
					_contract_renewals_con_start_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ContractRenewalsConExpiryDate
		{
			get
			{
                CanReadProperty("ContractRenewalsConExpiryDate", true);
				return _contract_renewals_con_expiry_date;
			}
			set
			{
                CanWriteProperty("ContractRenewalsConExpiryDate", true);
				if ( _contract_renewals_con_expiry_date != value )
				{
					_contract_renewals_con_expiry_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOName
		{
			get
			{
                CanReadProperty("OutletOName", true);
				return _outlet_o_name;
			}
			set
			{
                CanWriteProperty("OutletOName", true);
				if ( _outlet_o_name != value )
				{
					_outlet_o_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOAddress
		{
			get
			{
                CanReadProperty("OutletOAddress", true);
				return _outlet_o_address;
			}
			set
			{
                CanWriteProperty("OutletOAddress", true);
				if ( _outlet_o_address != value )
				{
					_outlet_o_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOTelephone
		{
			get
			{
                CanReadProperty("OutletOTelephone", true);
				return _outlet_o_telephone;
			}
			set
			{
                CanWriteProperty("OutletOTelephone", true);
				if ( _outlet_o_telephone != value )
				{
					_outlet_o_telephone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOFax
		{
			get
			{
                CanReadProperty("OutletOFax", true);
				return _outlet_o_fax;
			}
			set
			{
                CanWriteProperty("OutletOFax", true);
				if ( _outlet_o_fax != value )
				{
					_outlet_o_fax = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOManager
		{
			get
			{
                CanReadProperty("OutletOManager", true);
				return _outlet_o_manager;
			}
			set
			{
                CanWriteProperty("OutletOManager", true);
				if ( _outlet_o_manager != value )
				{
					_outlet_o_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionRgnName
		{
			get
			{
                CanReadProperty("RegionRgnName", true);
				return _region_rgn_name;
			}
			set
			{
                CanWriteProperty("RegionRgnName", true);
				if ( _region_rgn_name != value )
				{
					_region_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionRgnRcmManager
		{
			get
			{
                CanReadProperty("RegionRgnRcmManager", true);
				return _region_rgn_rcm_manager;
			}
			set
			{
                CanWriteProperty("RegionRgnRcmManager", true);
				if ( _region_rgn_rcm_manager != value )
				{
					_region_rgn_rcm_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionRgnFax
		{
			get
			{
                CanReadProperty("RegionRgnFax", true);
				return _region_rgn_fax;
			}
			set
			{
                CanWriteProperty("RegionRgnFax", true);
				if ( _region_rgn_fax != value )
				{
					_region_rgn_fax = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionRgnTelephone
		{
			get
			{
                CanReadProperty("RegionRgnTelephone", true);
				return _region_rgn_telephone;
			}
			set
			{
                CanWriteProperty("RegionRgnTelephone", true);
				if ( _region_rgn_telephone != value )
				{
					_region_rgn_telephone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionRgnAddress
		{
			get
			{
                CanReadProperty("RegionRgnAddress", true);
				return _region_rgn_address;
			}
			set
			{
                CanWriteProperty("RegionRgnAddress", true);
				if ( _region_rgn_address != value )
				{
					_region_rgn_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCSalutation
		{
			get
			{
                CanReadProperty("ContractorCSalutation", true);
				return _contractor_c_salutation;
			}
			set
			{
                CanWriteProperty("ContractorCSalutation", true);
				if ( _contractor_c_salutation != value )
				{
					_contractor_c_salutation = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CcSalutation
		{
			get
			{
                CanReadProperty("CcSalutation", true);
				return _cc_salutation;
			}
			set
			{
                CanWriteProperty("CcSalutation", true);
				if ( _cc_salutation != value )
				{
					_cc_salutation = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractContractNo
		{
			get
			{
                CanReadProperty("ContractContractNo", true);
				return _contract_contract_no;
			}
			set
			{
                CanWriteProperty("ContractContractNo", true);
				if ( _contract_contract_no != value )
				{
					_contract_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static MailmergeOdDownloadData NewMailmergeOdDownloadData(  )
		{
			return Create();
		}

		public static MailmergeOdDownloadData[] GetAllMailmergeOdDownloadData(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText =" SELECT contractor.contractor_supplier_no, "+
                                    " contractor.c_title,   " +
                                    " contractor.c_initials,   "+
                                    " contractor.c_first_names,   "+
                                    " contractor.c_surname_company,   "+
                                    " isnull(contractor.c_title+' ','') "+
                                  " + isnull(contractor.c_first_names+' ','') "+
                                  " + isnull(contractor.c_surname_company,'')     as driver_name,  "+
                                   "  contractor.c_address,    "+
                                   "  case isnull(contractor.c_phone_day,'') "+
	                               "  when '' then ''  "+
	                               "  else "+
                                   "  case left(contractor.c_phone_day,2)when '02' then  "+
				                    "            substring(contractor.c_phone_day,1,3)+'-' "+
                                     "          +substring(contractor.c_phone_day,4,3)+'-' "+
                                      "         +substring(contractor.c_phone_day,7,len(contractor.c_phone_day) - 7) "+ 
                                       "    else "+
                                        "        substring(contractor.c_phone_day,1,2)+'-' "+
                                         "      +substring(contractor.c_phone_day,3,3)+'-' "+
                                          "     +substring(contractor.c_phone_day,6,len(contractor.c_phone_day) - 6)  "+
                                          " end "+
                                        " end  as c_phone_day, "+
                                   "  case isnull(contractor.c_phone_night,'') "+
                                    " when '' then '' "+
	                                " else "+
                                    " case left(contractor.c_phone_night,2)when '02' then "+
                                        "        substring(contractor.c_phone_night,1,3)+'-' "+
                                         "      +substring(contractor.c_phone_night,4,3)+'-' "+
                                        "       +substring(contractor.c_phone_night,7,len(contractor.c_phone_night) -7) "+ 
                                        "   else "+
                                         "       substring(contractor.c_phone_night,1,2)+'-' "+
                                         "      +substring(contractor.c_phone_night,3,3)+'-' "+
                                         "      +substring(contractor.c_phone_night,6,len(contractor.c_phone_night)-6) "+ 
                                        "   end "+
                                       "  end   as c_phone_night, "+
                                   "  case isnull(contractor.c_mobile,'') "+
	                              "   when '' then '' "+
	                               "  else "+
                                   "         substring(contractor.c_mobile,1,3)+'-' "+
                                   "        +substring(contractor.c_mobile,4,3)+'-' "+
                                   "        +substring(contractor.c_mobile,7,len(contractor.c_mobile)-7)  "+
                                  "   end   as c_mobile, "+
                                  "   case isnull(contractor.c_mobile2,'') "+
	                               "  when '' then '' "+
	                              "   else "+
                                   "        substring(contractor.c_mobile2,1,3)+'-' "+
                                  "         +substring(contractor.c_mobile2,4,3)+'-' "+
                                  "         +substring(contractor.c_mobile2,7,len(contractor.c_mobile2)-7) "+
                                  "   end   as c_mobile2, "+
                                  "   case contractor.c_prime_contact when 1      then c_phone_day "+
                                  "   end, "+
                                  "   case contractor.c_prime_contact when 2 then c_phone_night "+
	                              "   end, "+
                                 "    case contractor.c_prime_contact when 3 then c_mobile "+
                                 "    end as primary_contact,"+
                                 "    contractor.c_email_address,  "+ 
                                 "    contractor.c_bank_account_no,  "+ 
                                 "    contractor.c_gst_number,   "+
                                 "    contractor.c_tax_rate,   "+
                                 "    contractor.c_ird_no,   "+
                                 "    contract.con_title,   "+
                                 "    contractor_renewals.cr_effective_date, "+  
                                   "   contract_renewals.con_start_date, "+  
                                   "   contract_renewals.con_expiry_date,   "+
                                   "   outlet.o_name,   "+
                                   "   outlet.o_address,   "+
                                   "   outlet.o_telephone,   "+
                                   "   outlet.o_fax,   "+
                                   "   outlet.o_manager,   "+
                                   "   region.rgn_name,   "+
                                   "   region.rgn_rcm_manager,   "+
                                    "  region.rgn_fax,   "+
                                    "  region.rgn_telephone,   "+
                                    "  region.rgn_address,   "+
                                    "  contractor.c_salutation,   "+
                                    "  case isnull(contractor.c_salutation,'')"+
                                    "  when '' then isnull(contractor.c_title+' ','') "+
                                    "                 + isnull(contractor.c_first_names+' ','') "+
                                    "                 + isnull(contractor.c_surname_company,'') "+
                                    "  else contractor.c_salutation end    as c_salutation,   "+
                                     " contract.contract_no  "+
                                     " FROM contract,    "+
                                     " contractor_renewals,   "+ 
                                     " outlet,    "+
                                     " region,    "+
                                     " contract_renewals,    "+
                                     " contractor,    "+
                                     " types_for_contract   "+
                                     " WHERE region.region_id = outlet.region_id and   "+
                                     " outlet.outlet_id = contract.con_base_office and   "+
                                     " contract_renewals.contract_no = contractor_renewals.contract_no and   "+
                                     " contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and   "+
                                     " contract.contract_no = contract_renewals.contract_no and   "+
                                     " contract.con_active_sequence = contract_renewals.contract_seq_number and   "+
                                     " contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no and   "+
                                     " contract.contract_no = types_for_contract.contract_no and   "+
                                     " contractor_renewals.cr_effective_date =  "+
                                     " (select max(cr.cr_effective_date)  "+
                                     " from contractor_renewals cr     "+
                                     " where cr.contract_no = contract_renewals.contract_no  "+
                                    "  and cr.contract_seq_number = contract_renewals.contract_seq_number )"; 

					ParameterCollection pList = new ParameterCollection();

					List<MailmergeOdDownloadData> _list = new List<MailmergeOdDownloadData>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MailmergeOdDownloadData instance = new MailmergeOdDownloadData();
                            instance._contractor_contractor_supplier_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contractor_c_title = GetValueFromReader<String>(dr,1);
                            instance._contractor_c_initials = GetValueFromReader<String>(dr,2);
                            instance._contractor_c_first_names = GetValueFromReader<String>(dr,3);
                            instance._contractor_c_surname_company = GetValueFromReader<String>(dr,4);

                            instance._driver_name = GetValueFromReader<String>(dr,5);
                            instance._contractor_c_address = GetValueFromReader<String>(dr,6);
                            instance._c_phone_day = GetValueFromReader<String>(dr,7);
                            instance._c_phone_night = GetValueFromReader<String>(dr,8);
                            instance._c_mobile = GetValueFromReader<String>(dr,9);

                            instance._c_mobile2 = GetValueFromReader<String>(dr,10);
                            instance._primary_contact = GetValueFromReader<String>(dr,11);
                            instance._c_email_address = GetValueFromReader<String>(dr,12);
                            instance._contractor_c_tax_rate = GetValueFromReader<String>(dr,13);
                            instance._contractor_c_ird_no = GetValueFromReader<String>(dr,14);

                            instance._c_tax_rate = GetValueFromReader<Decimal?>(dr,15);
                            instance._contractor_c_ird_no = GetValueFromReader<String>(dr,16);
                            instance._contract_con_title = GetValueFromReader<String>(dr,17);
                            instance._contractor_renewals_cr_effective_date = GetValueFromReader<DateTime?>(dr,18);
                            instance._contract_renewals_con_start_date = GetValueFromReader<DateTime?>(dr,19);

                            instance._contract_renewals_con_expiry_date = GetValueFromReader<DateTime?>(dr,20);
                            instance._outlet_o_name = GetValueFromReader<String>(dr,21);
                            instance._outlet_o_address = GetValueFromReader<String>(dr,22);
                            instance._outlet_o_telephone = GetValueFromReader<String>(dr,23);
                            instance._outlet_o_fax = GetValueFromReader<String>(dr,24);

                            instance._outlet_o_manager = GetValueFromReader<String>(dr,25);
                            instance._region_rgn_name = GetValueFromReader<String>(dr,26);
                            instance._region_rgn_rcm_manager = GetValueFromReader<String>(dr,27);
                            instance._region_rgn_fax = GetValueFromReader<String>(dr,28);
                            instance._region_rgn_telephone = GetValueFromReader<String>(dr,29);

                            instance._region_rgn_address = GetValueFromReader<String>(dr,30);
                            instance._contractor_c_salutation = GetValueFromReader<String>(dr,31);
                            instance._cc_salutation = GetValueFromReader<String>(dr,32);
                            instance._contract_contract_no = GetValueFromReader<Int32?>(dr,33);

							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
