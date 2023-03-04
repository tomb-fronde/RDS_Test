using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "customer")]
	[MapInfo("cust_title", "_cust_title", "customer")]
	[MapInfo("cust_surname_company", "_cust_surname_company", "customer")]
	[MapInfo("cust_initials", "_cust_initials", "customer")]
	[MapInfo("cust_date_first_loaded", "_cust_date_first_loaded", "customer")]
	[MapInfo("c_surname_company", "_contractor_c_surname_company", "contractor")]
	[MapInfo("c_initials", "_contractor_c_initials", "contractor")]
	[MapInfo("c_phone_day", "_contractor_c_phone_day", "contractor")]
	[System.Serializable()]

	public class NoCommencement : Entity<NoCommencement>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _cust_title;

		[DBField()]
		private string  _cust_surname_company;

		[DBField()]
		private string  _cust_initials;

		[DBField()]
		private DateTime?  _cust_date_first_loaded;

		[DBField()]
		private string  _contractor_c_surname_company;

		[DBField()]
		private string  _contractor_c_initials;

		[DBField()]
		private string  _contractor_c_phone_day;


		public virtual int? ContractNo
		{
			get
			{
                CanReadProperty("ContractNo", true);
				return _contract_no;
			}
			set
			{
                CanWriteProperty("ContractNo", true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustTitle
		{
			get
			{
                CanReadProperty("CustTitle", true);
				return _cust_title;
			}
			set
			{
                CanWriteProperty("CustTitle", true);
				if ( _cust_title != value )
				{
					_cust_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustSurnameCompany
		{
			get
			{
                CanReadProperty("CustSurnameCompany", true);
				return _cust_surname_company;
			}
			set
			{
                CanWriteProperty("CustSurnameCompany", true);
				if ( _cust_surname_company != value )
				{
					_cust_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustInitials
		{
			get
			{
                CanReadProperty("CustInitials", true);
				return _cust_initials;
			}
			set
			{
                CanWriteProperty("CustInitials", true);
				if ( _cust_initials != value )
				{
					_cust_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CustDateFirstLoaded
		{
			get
			{
                CanReadProperty("CustDateFirstLoaded", true);
				return _cust_date_first_loaded;
			}
			set
			{
                CanWriteProperty("CustDateFirstLoaded", true);
				if ( _cust_date_first_loaded != value )
				{
					_cust_date_first_loaded = value;
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

		public virtual string ContractorCPhoneDay
		{
			get
			{
                CanReadProperty("ContractorCPhoneDay", true);
				return _contractor_c_phone_day;
			}
			set
			{
                CanWriteProperty("ContractorCPhoneDay", true);
				if ( _contractor_c_phone_day != value )
				{
					_contractor_c_phone_day = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_3]
		//?	if (not isnull(cust_initials ), cust_surname_company +', '+ cust_initials , cust_surname_company )


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static NoCommencement NewNoCommencement( int? ldays, int? lregion, string as_privacy_override )
		{
			return Create(ldays, lregion, as_privacy_override);
		}

		public static NoCommencement[] GetAllNoCommencement( int? ldays, int? lregion, string as_privacy_override )
		{
			return Fetch(ldays, lregion, as_privacy_override).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? ldays, int? lregion, string as_privacy_override )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT customer.contract_no,  customer.cust_title,  customer.cust_surname_company,  customer.cust_initials,  customer.cust_date_first_loaded ,  contractor.c_surname_company,  contractor.c_initials,  contractor.c_phone_day  FROM  customer,  contract_renewals,  contractor,  contractor_renewals,  contract,  outlet  WHERE 		( contract.con_base_office 				= outlet.outlet_id)  and 			(( outlet.region_id = :lregion and :lregion is not null)  or (:lregion is null))  and 			( customer.contract_no 						= contract_renewals.contract_no )  and 			( contract.contract_no 						= contract_renewals.contract_no )  and 			( contract.con_active_sequence 			= contract_renewals.contract_seq_number)  and 			( contract_renewals.contract_seq_number= contractor_renewals.contract_seq_number )  and 			( contractor.contractor_supplier_no 	= contractor_renewals.contractor_supplier_no )  and 			( contract_renewals.contract_no 			= contractor_renewals.contract_no )  and 			( contract_renewals.contract_seq_number= contractor_renewals.contract_seq_number )  and 			( contract.contract_no 						= contract_renewals.contract_no )  and 			( contract.contract_no 						= customer.contract_no )  and 			( contractor_renewaLs.cr_effective_date= (  select 	max(cr_effective_date)  from 	contractor_renewals cr  where 	cr.contract_no = contract.contract_no  and		cr.contract_seq_number = contract_renewals.contract_seq_number))  AND 		((customer.cust_date_commenced is null  AND days(customer.cust_date_first_loaded,today(*)) >;= :ldays )	)  and 			( :as_privacy_override = 'Y' OR customer.cust_dir_listing_ind = 'Y' )   ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "ldays", ldays);
					pList.Add(cm, "lregion", lregion);
					pList.Add(cm, "as_privacy_override", as_privacy_override);

					List<NoCommencement> _list = new List<NoCommencement>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							NoCommencement instance = new NoCommencement();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._cust_title = GetValueFromReader<string>(dr,1);
                            instance._cust_surname_company = GetValueFromReader<string>(dr,2);
                            instance._cust_initials = GetValueFromReader<string>(dr,3);
                            instance._cust_date_first_loaded = GetValueFromReader<DateTime?>(dr,4);
                            instance._contractor_c_surname_company = GetValueFromReader<string>(dr,5);
                            instance._contractor_c_initials = GetValueFromReader<string>(dr,6);
                            instance._contractor_c_phone_day = GetValueFromReader<string>(dr,7);
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
