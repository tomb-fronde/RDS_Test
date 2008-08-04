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
	[MapInfo("cust_id", "_cust_id", "")]
	[MapInfo("cust_title", "_cust_title", "")]
	[MapInfo("cust_initials", "_cust_initials", "")]
	[MapInfo("cust_surname_company", "_cust_surname_company", "")]
	[MapInfo("cust_phone_day", "_cust_phone_day", "")]
	[MapInfo("cust_phone_night", "_cust_phone_night", "")]
	[MapInfo("cust_phone_mobile", "_cust_phone_mobile", "")]
	[MapInfo("compute_0008", "_cust_address", "")]
	[MapInfo("compute_0009", "_cust_mail_category", "")]
	[MapInfo("compute_0010", "_cust_recipients", "")]
	[MapInfo("compute_0011", "_cust_contract", "")]
	[System.Serializable()]

	public class CustDetailsExport : Entity<CustDetailsExport>
	{
		#region Business Methods
		[DBField()]
		private string  _cust_id;

		[DBField()]
		private string  _cust_title;

		[DBField()]
		private string  _cust_initials;

		[DBField()]
		private string  _cust_surname_company;

		[DBField()]
		private string  _cust_phone_day;

		[DBField()]
		private string  _cust_phone_night;

		[DBField()]
		private string  _cust_phone_mobile;

		[DBField()]
		private string  _cust_address;

		[DBField()]
		private string  _cust_mail_category;

		[DBField()]
		private string  _cust_recipients;

		[DBField()]
		private string  _cust_contract;


		public virtual string CustId
		{
			get
			{
                CanReadProperty("CustId", true);
				return _cust_id;
			}
			set
			{
                CanWriteProperty("CustId", true);
				if ( _cust_id != value )
				{
					_cust_id = value;
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

		public virtual string CustPhoneDay
		{
			get
			{
                CanReadProperty("CustPhoneDay", true);
				return _cust_phone_day;
			}
			set
			{
                CanWriteProperty("CustPhoneDay", true);
				if ( _cust_phone_day != value )
				{
					_cust_phone_day = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustPhoneNight
		{
			get
			{
                CanReadProperty("CustPhoneNight", true);
				return _cust_phone_night;
			}
			set
			{
                CanWriteProperty("CustPhoneNight", true);
				if ( _cust_phone_night != value )
				{
					_cust_phone_night = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustPhoneMobile
		{
			get
			{
                CanReadProperty("CustPhoneMobile", true);
				return _cust_phone_mobile;
			}
			set
			{
                CanWriteProperty("CustPhoneMobile", true);
				if ( _cust_phone_mobile != value )
				{
					_cust_phone_mobile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustAddress
		{
			get
			{
                CanReadProperty("CustAddress", true);
				return _cust_address;
			}
			set
			{
                CanWriteProperty("CustAddress", true);
				if ( _cust_address != value )
				{
					_cust_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailCategory
		{
			get
			{
                CanReadProperty("CustMailCategory", true);
				return _cust_mail_category;
			}
			set
			{
                CanWriteProperty("CustMailCategory", true);
				if ( _cust_mail_category != value )
				{
					_cust_mail_category = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustRecipients
		{
			get
			{
                CanReadProperty("CustRecipients", true);
				return _cust_recipients;
			}
			set
			{
                CanWriteProperty("CustRecipients", true);
				if ( _cust_recipients != value )
				{
					_cust_recipients = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustContract
		{
			get
			{
                CanReadProperty("CustContract", true);
				return _cust_contract;
			}
			set
			{
                CanWriteProperty("CustContract", true);
				if ( _cust_contract != value )
				{
					_cust_contract = value;
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
		public static CustDetailsExport NewCustDetailsExport(  )
		{
			return Create();
		}

		public static CustDetailsExport[] GetAllCustDetailsExport(  )
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
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_GetCustomerDetailsForExport";
                    cm.CommandTimeout = 0;
					ParameterCollection pList = new ParameterCollection();

					List<CustDetailsExport> _list = new List<CustDetailsExport>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustDetailsExport instance = new CustDetailsExport();
                            instance._cust_id = GetValueFromReader<string>(dr,0);
                              instance._cust_title = GetValueFromReader<string>(dr,1);
                              instance._cust_initials = GetValueFromReader<string>(dr,2);
                              instance._cust_surname_company = GetValueFromReader<string>(dr,3);
                              instance._cust_phone_day = GetValueFromReader<string>(dr,4);
                              instance._cust_phone_night = GetValueFromReader<string>(dr,5);
                              instance._cust_phone_mobile = GetValueFromReader<string>(dr,6);
                              instance._cust_address = GetValueFromReader<string>(dr,7);
                              instance._cust_mail_category = GetValueFromReader<string>(dr,8);
                              instance._cust_recipients = GetValueFromReader<string>(dr,9);
                              instance._cust_contract = GetValueFromReader<string>(dr,10);
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
