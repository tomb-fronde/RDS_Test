using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB RPCR_151 May-2020
    // Added InPayRelated and related in_pay_relate and _in_pay_relate variables
    // InPayRelated is bound to by checkbox1 in datacontrol DContractorFull.

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "contractor")]
	[MapInfo("c_title", "_c_title", "contractor")]
	[MapInfo("c_surname_company", "_c_surname_company", "contractor")]
	[MapInfo("c_first_names", "_c_first_names", "contractor")]
	[MapInfo("c_initials", "_c_initials", "contractor")]
	[MapInfo("c_address", "_c_address", "contractor")]
	[MapInfo("c_phone_day", "_c_phone_day", "contractor")]
	[MapInfo("c_phone_night", "_c_phone_night", "contractor")]
	[MapInfo("c_mobile", "_c_mobile", "contractor")]
	[MapInfo("c_bank_account_no", "_c_bank_account_no", "contractor")]
	[MapInfo("c_ird_no", "_c_ird_no", "contractor")]
	[MapInfo("c_gst_number", "_c_gst_number", "contractor")]
	[MapInfo("c_tax_rate", "_c_tax_rate", "contractor")]
	[MapInfo("c_salutation", "_c_salutation", "contractor")]
	[MapInfo("nz_post_employee", "_nz_post_employee", "contractor")]
	[MapInfo("c_witholding_tax_certificate", "_c_witholding_tax_certificate", "contractor")]
	[MapInfo("c_tpid_number", "_c_tpid_number", "contractor")]
	[MapInfo("c_email_address", "_c_email_address", "contractor")]
	[MapInfo("c_mobile2", "_c_mobile2", "contractor")]
	[MapInfo("c_notes", "_c_notes", "contractor")]
	[MapInfo("c_prime_contact", "_c_prime_contact", "contractor")]
    [MapInfo("in_pay_related", "_in_pay_related", "")]
    [System.Serializable()]

	public class ContractorFull : Entity<ContractorFull>
	{
		#region Business Methods
		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private string  _c_title;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private string  _c_address;

		[DBField()]
		private string  _c_phone_day;

		[DBField()]
		private string  _c_phone_night;

		[DBField()]
		private string  _c_mobile;

		[DBField()]
		private string  _c_bank_account_no;

		[DBField()]
		private string  _c_ird_no;

		[DBField()]
		private string  _c_gst_number;

		[DBField()]
		private decimal?  _c_tax_rate;

		[DBField()]
		private string  _c_salutation;

		[DBField()]
		private string  _nz_post_employee;

		[DBField()]
		private string  _c_witholding_tax_certificate;

		[DBField()]
		private int?  _c_tpid_number;

		[DBField()]
		private string  _c_email_address;

		[DBField()]
		private string  _c_mobile2;

		[DBField()]
		private string  _c_notes;

		[DBField()]
		private int?  _c_prime_contact;

        [DBField()]
        private bool _in_pay_related;

        // TJB RPCR_151 May-2020: NEW
        public virtual bool InPayRelated
        {
            get
            {
                CanReadProperty("InPayRelated", true);
                return _in_pay_related;
            }
            set
            {
                CanWriteProperty("InPayRelated", true);
                if (_in_pay_related != value)
                {
                    _in_pay_related = value;
                    PropertyHasChanged();
                }
            }
        }

		public virtual int? ContractorSupplierNo
		{
			get
			{
                CanReadProperty("ContractorSupplierNo", true);
				return _contractor_supplier_no;
			}
			set
			{
                CanWriteProperty("ContractorSupplierNo", true);
				if ( _contractor_supplier_no != value )
				{
					_contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CTitle
		{
			get
			{
                CanReadProperty("CTitle", true);
				return _c_title;
			}
			set
			{
                CanWriteProperty("CTitle", true);
				if ( _c_title != value )
				{
					_c_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CSurnameCompany
		{
			get
			{
                CanReadProperty("CSurnameCompany", true);
				return _c_surname_company;
			}
			set
			{
                CanWriteProperty("CSurnameCompany", true);
				if ( _c_surname_company != value )
				{
					_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CFirstNames
		{
			get
			{
                CanReadProperty("CFirstNames", true);
				return _c_first_names;
			}
			set
			{
                CanWriteProperty("CFirstNames", true);
				if ( _c_first_names != value )
				{
					_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CInitials
		{
			get
			{
                CanReadProperty("CInitials", true);
				return _c_initials;
			}
			set
			{
                CanWriteProperty("CInitials", true);
				if ( _c_initials != value )
				{
					_c_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CAddress
		{
			get
			{
                CanReadProperty("CAddress", true);
				return _c_address;
			}
			set
			{
                CanWriteProperty("CAddress", true);
				if ( _c_address != value )
				{
					_c_address = value;
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

		public virtual string CBankAccountNo
		{
			get
			{
                CanReadProperty("CBankAccountNo", true);
				return _c_bank_account_no;
			}
			set
			{
                CanWriteProperty("CBankAccountNo", true);
				if ( _c_bank_account_no != value )
				{
					_c_bank_account_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CIrdNo
		{
			get
			{
                CanReadProperty("CIrdNo", true);
				return _c_ird_no;
			}
			set
			{
                CanWriteProperty("CIrdNo", true);
				if ( _c_ird_no != value )
				{
					_c_ird_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CGstNumber
		{
			get
			{
                CanReadProperty("CGstNumber", true);
				return _c_gst_number;
			}
			set
			{
                CanWriteProperty("CGstNumber", true);
				if ( _c_gst_number != value )
				{
					_c_gst_number = value;
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

		public virtual string CSalutation
		{
			get
			{
                CanReadProperty("CSalutation", true);
				return _c_salutation;
			}
			set
			{
                CanWriteProperty("CSalutation", true);
				if ( _c_salutation != value )
				{
					_c_salutation = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string NzPostEmployee
		{
			get
			{
                CanReadProperty("NzPostEmployee", true);
				return _nz_post_employee;
			}
			set
			{
                CanWriteProperty("NzPostEmployee", true);
				if ( _nz_post_employee != value )
				{
					_nz_post_employee = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual bool NzPostEmployeeChecked
        {
            get
            {
                CanReadProperty("NzPostEmployee", true);
                if (_nz_post_employee == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("NzPostEmployee", true);
                if (value &&  _nz_post_employee!= "Y")
                {
                    _nz_post_employee = "Y";
                    PropertyHasChanged();
                }
                if (!value && _nz_post_employee != "N")
                {
                    _nz_post_employee = "N";
                    PropertyHasChanged();
                }
            }
        }

		public virtual string CWitholdingTaxCertificate
		{
			get
			{
                CanReadProperty("CWitholdingTaxCertificate", true);
				return _c_witholding_tax_certificate;
			}
			set
			{
                CanWriteProperty("CWitholdingTaxCertificate", true);
				if ( _c_witholding_tax_certificate != value )
				{
					_c_witholding_tax_certificate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CTpidNumber
		{
			get
			{
                CanReadProperty("CTpidNumber", true);
				return _c_tpid_number;
			}
			set
			{
                CanWriteProperty("CTpidNumber", true);
				if ( _c_tpid_number != value )
				{
					_c_tpid_number = value;
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

		public virtual string CNotes
		{
			get
			{
                CanReadProperty("CNotes", true);
				return _c_notes;
			}
			set
			{
                CanWriteProperty("CNotes", true);
				if ( _c_notes != value )
				{
					_c_notes = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CPrimeContact
		{
			get
			{
                CanReadProperty("CPrimeContact", true);
				return _c_prime_contact;
			}
			set
			{
                CanWriteProperty("CPrimeContact", true);
				if ( _c_prime_contact != value )
				{
					_c_prime_contact = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual bool CPrimeContact1
        {
            get
            {
                CanReadProperty("CPrimeContact1", true);
                return _c_prime_contact == 1;
            }
            set
            {
                //CanWriteProperty("CPrimeContact1", true);
                //if (_c_prime_contact != (value ? 1:2))
                //{
                //    _c_prime_contact = (value ? 1:2);
                //    PropertyHasChanged();
                //}
            }
        }

        public virtual bool CPrimeContact2
        {
            get
            {
                CanReadProperty("CPrimeContact2", true);
                return _c_prime_contact == 2;
            }
            set
            {
                //CanWriteProperty("CPrimeContact2", true);
                //if (_c_prime_contact != (value ? 2 : 3))
                //{
                //    _c_prime_contact = (value ? 2 : 3);
                //    PropertyHasChanged();
                //}
            }
        }

        public virtual bool CPrimeContact3
        {
            get
            {
                CanReadProperty("CPrimeContact3", true);
                return _c_prime_contact == 3;
            }
            set
            {
                //CanWriteProperty("CPrimeContact3", true);
                //if (_c_prime_contact != (value ? 3 : 1))
                //{
                //    _c_prime_contact = (value ? 3 : 1);
                //    PropertyHasChanged();
                //}
            }
        }

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _contractor_supplier_no );
		}
		#endregion

		#region Factory Methods
		public static ContractorFull NewContractorFull( int? in_contractor )
		{
			return Create(in_contractor);
		}

		public static ContractorFull[] GetAllContractorFull( int? in_contractor )
		{
			return Fetch(in_contractor).list;
		}

        public void MarkNotModified()
        {
            this.MarkOld();
        }
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_contractor )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_contractor", in_contractor);

                    cm.CommandText = @"  SELECT contractor.contractor_supplier_no,   
                                                 contractor.c_title,   
                                                 contractor.c_surname_company,   
                                                 contractor.c_first_names,   
                                                 contractor.c_initials,   
                                                 contractor.c_address,   
                                                 contractor.c_phone_day,   
                                                 contractor.c_phone_night,   
                                                 contractor.c_mobile,   
                                                 contractor.c_bank_account_no,   
                                                 contractor.c_ird_no,   
                                                 contractor.c_gst_number,   
                                                 contractor.c_tax_rate,   
                                                 contractor.c_salutation,   
                                                 contractor.nz_post_employee,   
                                                 contractor.c_witholding_tax_certificate,   
                                                 contractor.c_tpid_number,   
                                                 contractor.c_email_address,   
                                                 contractor.c_mobile2,   
                                                 contractor.c_notes,   
                                                 contractor.c_prime_contact  
                                            FROM contractor  
                                           WHERE contractor.contractor_supplier_no = @in_contractor";
					List<ContractorFull> _list = new List<ContractorFull>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractorFull instance = new ContractorFull();
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr,0);
                            instance._c_title = GetValueFromReader<String>(dr,1);
                            instance._c_surname_company = GetValueFromReader<String>(dr,2);
                            instance._c_first_names = GetValueFromReader<String>(dr,3);
                            instance._c_initials = GetValueFromReader<String>(dr,4);

                            instance._c_address = GetValueFromReader<String>(dr,5);
                            instance._c_phone_day = GetValueFromReader<String>(dr,6);
                            instance._c_phone_night = GetValueFromReader<String>(dr,7);
                            instance._c_mobile = GetValueFromReader<String>(dr,8);
                            instance._c_bank_account_no = GetValueFromReader<String>(dr,9);

                            instance._c_ird_no = GetValueFromReader<String>(dr,10);
                            instance._c_gst_number = GetValueFromReader<String>(dr,11);
                            instance._c_tax_rate = GetValueFromReader<Decimal?>(dr,12);
                            instance._c_salutation = GetValueFromReader<String>(dr,13);
                            instance._nz_post_employee = GetValueFromReader<String>(dr,14);

                            instance._c_witholding_tax_certificate = GetValueFromReader<String>(dr,15);
                            instance._c_tpid_number = GetValueFromReader<Int32?>(dr,16);
                            instance._c_email_address = GetValueFromReader<String>(dr,17);
                            instance._c_mobile2 = GetValueFromReader<String>(dr,18);
                            instance._c_notes = GetValueFromReader<String>(dr,19);
                            instance._c_prime_contact = GetValueFromReader<Int32?>(dr,20);

                            instance._in_pay_related = false;

							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		[ServerMethod()]
		private void UpdateEntity()
		{
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "contractor", ref pList))
				{
					cm.CommandText += " WHERE  contractor.contractor_supplier_no = @contractor_supplier_no ";

					pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "contractor", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
			using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;
					cm.CommandType = CommandType.Text;
						ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
						cm.CommandText = "DELETE FROM contractor WHERE " +
						"contractor.contractor_supplier_no = @contractor_supplier_no ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contractor_supplier_no )
		{
			_contractor_supplier_no = contractor_supplier_no;
		}
	}
}
