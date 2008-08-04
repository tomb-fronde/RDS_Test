using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
	[MapInfo("c_title", "_c_title", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("c_initials", "_c_initials", "")]
	[MapInfo("c_address", "_c_address", "")]
	[MapInfo("c_phone_day", "_c_phone_day", "")]
	[MapInfo("c_phone_night", "_c_phone_night", "")]
	[MapInfo("c_mobile", "_c_mobile", "")]
	[System.Serializable()]

	public class Contractor : Entity<Contractor>
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

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _contractor_supplier_no );
		}

		#endregion

		#region Factory Methods
		public static Contractor NewContractor( int? in_Contractor )
		{
			return Create(in_Contractor);
		}

		public static Contractor[] GetAllContractor( int? in_Contractor )
		{
			return Fetch(in_Contractor).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Contractor )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Contractor", in_Contractor);
                    cm.CommandText = "sp_GetContractor";

					List<Contractor> _list = new List<Contractor>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Contractor instance = new Contractor();
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr,0);
                            instance._c_title = GetValueFromReader<String>(dr,1);
                            instance._c_surname_company = GetValueFromReader<String>(dr,2);
                            instance._c_first_names = GetValueFromReader<String>(dr,3);
                            instance._c_initials = GetValueFromReader<String>(dr,4);
                            instance._c_address = GetValueFromReader<String>(dr,5);
                            instance._c_phone_day = GetValueFromReader<String>(dr,6);
                            instance._c_phone_night = GetValueFromReader<String>(dr,7);
                            instance._c_mobile = GetValueFromReader<String>(dr,8);
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
		private void CreateEntity( int? contractor_supplier_no )
		{
			_contractor_supplier_no = contractor_supplier_no;
		}
	}
}
