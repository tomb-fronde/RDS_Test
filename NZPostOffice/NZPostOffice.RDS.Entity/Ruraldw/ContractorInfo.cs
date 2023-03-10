using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_037 fixup Mar-2013
    // Added "top(1) ... order by..." to select most recent driver
    // where contract has changed hands
    //
    // TJB  RPCR_046  Dec-2012
    // Changed fetch query to use newly-created function GetSeqNo.
    //
    // TJB  RPCR_037  Dec-2012
    // Added c_mobile2, c_prime_contact, c_notes to values returned
    // and PrimeContactDay, PrimeContactNight, PrimeContactMobile
    
    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contractor_supplier_no", "_contractor_contractor_supplier_no", "contractor")]
	[MapInfo("c_surname_company", "_contractor_c_surname_company", "contractor")]
	[MapInfo("c_first_names", "_contractor_c_first_names", "contractor")]
	[MapInfo("c_salutation", "_contractor_c_salutation", "contractor")]
	[MapInfo("c_initials", "_contractor_c_initials", "contractor")]
	[MapInfo("c_phone_day", "_contractor_c_phone_day", "contractor")]
	[MapInfo("c_phone_night", "_contractor_c_phone_night", "contractor")]
    [MapInfo("c_mobile", "_contractor_c_mobile", "contractor")]
    [MapInfo("c_mobile", "_contractor_c_mobile2", "contractor")]
    [MapInfo("c_prime_contact", "_contractor_c_prime_contact", "contractor")]
    [MapInfo("c_notes", "_contractor_c_notes", "contractor")]
    [System.Serializable()]

	public class ContractorInfo : Entity<ContractorInfo>
	{
		#region Business Methods
		[DBField()]
		private int?  _contractor_contractor_supplier_no;

		[DBField()]
		private string  _contractor_c_surname_company;

		[DBField()]
		private string  _contractor_c_first_names;

		[DBField()]
		private string  _contractor_c_salutation;

		[DBField()]
		private string  _contractor_c_initials;

		[DBField()]
		private string  _contractor_c_phone_day;

		[DBField()]
		private string  _contractor_c_phone_night;

        [DBField()]
        private string _contractor_c_mobile;

        [DBField()]
        private string _contractor_c_mobile2;

        [DBField()]
        private int? _contractor_c_prime_contact;

        [DBField()]
        private string _contractor_c_notes;


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

		public virtual string ContractorCPhoneNight
		{
			get
			{
                CanReadProperty("ContractorCPhoneNight", true);
				return _contractor_c_phone_night;
			}
			set
			{
                CanWriteProperty("ContractorCPhoneNight", true);
				if ( _contractor_c_phone_night != value )
				{
					_contractor_c_phone_night = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string ContractorCMobile
        {
            get
            {
                CanReadProperty("ContractorCMobile", true);
                return _contractor_c_mobile;
            }
            set
            {
                CanWriteProperty("ContractorCMobile", true);
                if (_contractor_c_mobile != value)
                {
                    _contractor_c_mobile = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCMobile2
        {
            get
            {
                CanReadProperty("ContractorCMobile2", true);
                return _contractor_c_mobile2;
            }
            set
            {
                CanWriteProperty("ContractorCMobile2", true);
                if (_contractor_c_mobile2 != value)
                {
                    _contractor_c_mobile2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ContractorCPrimeContact
        {
            get
            {
                CanReadProperty("ContractorCPrimeContact", true);
                return _contractor_c_prime_contact;
            }
            set
            {
                CanWriteProperty("ContractorCPrimeContact", true);
                if (_contractor_c_prime_contact != value)
                {
                    _contractor_c_prime_contact = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrimeContactDay
        {
            get
            {
                CanReadProperty("PrimeContactDay", true);
                if (_contractor_c_prime_contact == 1)
                    return _contractor_c_prime_contact;
                else
                    return null;
            }
        }

        public virtual int? PrimeContactNight
        {
            get
            {
                CanReadProperty("PrimeContactNight", true);
                if (_contractor_c_prime_contact == 2)
                    return _contractor_c_prime_contact;
                else
                    return null;
            }
        }

        public virtual int? PrimeContactMobile
        {
            get
            {
                CanReadProperty("PrimeContactMobile", true);
                if (_contractor_c_prime_contact == 3)
                    return _contractor_c_prime_contact;
                else
                    return null;
            }
        }

        public virtual string ContractorCNotes
        {
            get
            {
                CanReadProperty("ContractorCNotes", true);
                return _contractor_c_notes;
            }
            set
            {
                CanWriteProperty("ContractorCNotes", true);
                if (_contractor_c_notes != value)
                {
                    _contractor_c_notes = value;
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
		public static ContractorInfo NewContractorInfo( int? al_contract_no )
		{
			return Create(al_contract_no);
		}

		public static ContractorInfo[] GetAllContractorInfo( int? al_contract_no )
		{
			return Fetch(al_contract_no).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_contract_no )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    // TJB  RPCR_037 fixup Mar-2013
                    // Added "top(1) ... order by..." to select most recent driver
                    // where contract has changed hands
                    //
                    // TJB  RPCR_046  Dec-2012
                    // Changed query.  Used newly-created function GetSeqNo to determine
                    // which contract the query related to (most-recent ignoring any pending renewals).
					cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT top(1) contractor.contractor_supplier_no"
                                         + ", contractor.c_surname_company"
                                         + ", contractor.c_first_names"
                                         + ", contractor.c_salutation"
                                         + ", contractor.c_initials,contractor.c_phone_day"
                                         + ", contractor.c_phone_night"
                                         + ", contractor.c_mobile"
                                         + ", contractor.c_mobile2"
                                         + ", contractor.c_prime_contact"
                                         + ", contractor.c_notes"
                                     + " FROM contractor"
                                         + ", contractor_renewals"
                                    + " WHERE contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no "
                                      + " AND contractor_renewals.contract_no = @al_contract_no "
                                      + " AND contractor_renewals.contract_seq_number = rd.GetConSeqNo(@al_contract_no) "
                                    + " ORDER BY contractor_renewals.cr_effective_date desc";
/*
					cm.CommandText = " SELECT contractor.contractor_supplier_no"
                                         + ", contractor.c_surname_company"
                                         + ", contractor.c_first_names"
                                         + ", contractor.c_salutation"
                                         + ", contractor.c_initials,contractor.c_phone_day"
                                         + ", contractor.c_phone_night"
                                         + ", contractor.c_mobile"
                                         + ", contractor.c_mobile2"
                                         + ", contractor.c_prime_contact"
                                         + ", contractor.c_notes"
                                     + " FROM contract"
                                         + ", contract_renewals"
                                         + ", contractor"
                                         + ", contractor_renewals"
                                    + " WHERE contract_renewals.contract_no = contract.contract_no "
                                      + " AND contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no "
                                      + " AND contractor_renewals.contract_no = contract_renewals.contract_no "
                                      + " AND contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number "
                                      + " AND contract.contract_no = @al_contract_no "
                                      + " AND contractor_renewals.contract_seq_number "
                                                 + " = (SELECT Max(cr2.contract_seq_number) "
                                                      + " FROM contractor_renewals cr2 "
                                                     + " WHERE cr2.contract_no = contract.contract_no) "
                                                       + " AND contractor_renewals.cr_effective_date "
                                                               + " = (SELECT Max(cr3.cr_effective_date) "
                                                                    + " FROM contractor_renewals cr3 "
                                                                   + " WHERE cr3.contract_no = contract.contract_no)";
*/
                    ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_contract_no", al_contract_no);

					List<ContractorInfo> _list = new List<ContractorInfo>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractorInfo instance = new ContractorInfo();
                            instance._contractor_contractor_supplier_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contractor_c_surname_company = GetValueFromReader<String>(dr,1);
                            instance._contractor_c_first_names = GetValueFromReader<String>(dr,2);
                            instance._contractor_c_salutation = GetValueFromReader<String>(dr,3);
                            instance._contractor_c_initials = GetValueFromReader<String>(dr,4);

                            instance._contractor_c_phone_day = GetValueFromReader<String>(dr,5);
                            instance._contractor_c_phone_night = GetValueFromReader<String>(dr,6);
                            instance._contractor_c_mobile = GetValueFromReader<String>(dr, 7);
                            instance._contractor_c_mobile2 = GetValueFromReader<String>(dr, 8);
                            instance._contractor_c_prime_contact = GetValueFromReader<Int32?>(dr, 9);
                            instance._contractor_c_notes = GetValueFromReader<String>(dr, 10);

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
