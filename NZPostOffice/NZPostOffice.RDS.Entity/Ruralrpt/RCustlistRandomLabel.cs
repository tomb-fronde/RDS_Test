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
	[MapInfo("cust_title", "_cust_title", "")]
	[MapInfo("cust_surname_company", "_cust_surname_company", "")]
	[MapInfo("cust_initials", "_cust_initials", "")]
	[MapInfo("cust_mailing_address_no", "_cust_mailing_address_no", "")]
	[MapInfo("cust_mailing_address_road", "_cust_mailing_address_road", "")]
	[MapInfo("cust_mailing_address_locality", "_cust_mailing_address_locality", "")]
	[MapInfo("cust_mail_town", "_cust_mail_town", "")]
	[MapInfo("cust_rd_number", "_cust_rd_number", "")]
	[MapInfo("con_rd_ref_text", "_con_rd_ref_text", "")]
	[MapInfo("cust_post_code", "_cust_post_code", "")]
	[System.Serializable()]

	public class CustlistRandomLabel : Entity<CustlistRandomLabel>
	{
		#region Business Methods
		[DBField()]
		private string  _cust_title;

		[DBField()]
		private string  _cust_surname_company;

		[DBField()]
		private string  _cust_initials;

		[DBField()]
		private string  _cust_mailing_address_no;

		[DBField()]
		private string  _cust_mailing_address_road;

		[DBField()]
		private string  _cust_mailing_address_locality;

		[DBField()]
		private string  _cust_mail_town;

		[DBField()]
		private string  _cust_rd_number;

		[DBField()]
		private string  _con_rd_ref_text;

		[DBField()]
		private string  _cust_post_code;


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

		public virtual string CustMailingAddressNo
		{
			get
			{
                CanReadProperty("CustMailingAddressNo", true);
				return _cust_mailing_address_no;
			}
			set
			{
                CanWriteProperty("CustMailingAddressNo", true);
				if ( _cust_mailing_address_no != value )
				{
					_cust_mailing_address_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailingAddressRoad
		{
			get
			{
                CanReadProperty("CustMailingAddressRoad", true);
				return _cust_mailing_address_road;
			}
			set
			{
                CanWriteProperty("CustMailingAddressRoad", true);
				if ( _cust_mailing_address_road != value )
				{
					_cust_mailing_address_road = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailingAddressLocality
		{
			get
			{
                CanReadProperty("CustMailingAddressLocality", true);
				return _cust_mailing_address_locality;
			}
			set
			{
                CanWriteProperty("CustMailingAddressLocality", true);
				if ( _cust_mailing_address_locality != value )
				{
					_cust_mailing_address_locality = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailTown
		{
			get
			{
                CanReadProperty("CustMailTown", true);
				return _cust_mail_town;
			}
			set
			{
                CanWriteProperty("CustMailTown", true);
				if ( _cust_mail_town != value )
				{
					_cust_mail_town = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustRdNumber
		{
			get
			{
                CanReadProperty("CustRdNumber", true);
				return _cust_rd_number;
			}
			set
			{
                CanWriteProperty("CustRdNumber", true);
				if ( _cust_rd_number != value )
				{
					_cust_rd_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConRdRefText
		{
			get
			{
                CanReadProperty("ConRdRefText", true);
				return _con_rd_ref_text;
			}
			set
			{
                CanWriteProperty("ConRdRefText", true);
				if ( _con_rd_ref_text != value )
				{
					_con_rd_ref_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustPostCode
		{
			get
			{
                CanReadProperty("CustPostCode", true);
				return _cust_post_code;
			}
			set
			{
                CanWriteProperty("CustPostCode", true);
				if ( _cust_post_code != value )
				{
					_cust_post_code = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_1]
		//?	if(isnull(cust_title),'', cust_title + ' ') + if(isnull(cust_initials),'', cust_initials  + ' ') +cust_surname_company

			// needs to implement compute expression manually:
			// compute control name=[compute_2]
		//?	if(isnull(cust_mailing_address_road) or len(cust_mailing_address_road)=0,'',if(isnull(cust_mailing_address_no) or len(cust_mailing_address_no)=0,'',cust_mailing_address_no+' ')+cust_mailing_address_road + 'r')+ if(isnull(cust_mailing_address_locality) or len(cust_mailing_address_locality)=0,'',cust_mailing_address_locality+'r')+if(isnull(cust_rd_number) or len(cust_rd_number)=0,if(isnull(con_rd_ref_text) or len(con_rd_ref_text)=0,'','RD '+con_rd_ref_text+'r'),'RD '+cust_rd_number)


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static CustlistRandomLabel NewCustlistRandomLabel( int? xrequired )
		{
			return Create(xrequired);
		}

		public static CustlistRandomLabel[] GetAllCustlistRandomLabel( int? xrequired )
		{
			return Fetch(xrequired).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? xrequired )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "p_getrandcustomers";
                    cm.CommandTimeout = 500;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "xrequired", xrequired);

					List<CustlistRandomLabel> _list = new List<CustlistRandomLabel>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustlistRandomLabel instance = new CustlistRandomLabel();
                            instance._cust_title = GetValueFromReader<string>(dr,0);
                            instance._cust_surname_company = GetValueFromReader<string>(dr,1);
                            instance._cust_initials = GetValueFromReader<string>(dr,2);
                            instance._cust_mailing_address_no = GetValueFromReader<string>(dr,3);
                            instance._cust_mailing_address_road = GetValueFromReader<string>(dr,4);
                            instance._cust_mailing_address_locality = GetValueFromReader<string>(dr,5);
                            instance._cust_mail_town = GetValueFromReader<string>(dr,6);
                            instance._cust_rd_number = GetValueFromReader<string>(dr,7);
                            instance._con_rd_ref_text = GetValueFromReader<string>(dr,8);
                            instance._cust_post_code = GetValueFromReader<string>(dr,9);
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
