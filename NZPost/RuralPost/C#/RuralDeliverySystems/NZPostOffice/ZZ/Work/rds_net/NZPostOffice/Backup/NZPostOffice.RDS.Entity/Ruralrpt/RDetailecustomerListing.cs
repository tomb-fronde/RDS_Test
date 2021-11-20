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
	[MapInfo("cust_dir_listing_ind", "_cust_dir_listing_ind", "")]
	[MapInfo("cust_dir_listing_text", "_cust_dir_listing_text", "")]
	[MapInfo("cust_date_commenced", "_cust_date_commenced", "")]
	[MapInfo("cust_adpost_quantity", "_cust_adpost_quantity", "")]
	[MapInfo("compute_0012", "_compute_0012", "")]
	[MapInfo("compute_0013", "_compute_0013", "")]
	[MapInfo("compute_0014", "_compute_0014", "")]
	[MapInfo("compute_0015", "_compute_0015", "")]
	[MapInfo("compute_0016", "_compute_0016", "")]
	[System.Serializable()]

	public class DetailedCustomerListing : Entity<DetailedCustomerListing>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;

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
		private string  _cust_dir_listing_ind;

		[DBField()]
		private string  _cust_dir_listing_text;

		[DBField()]
		private DateTime?  _cust_date_commenced;

		[DBField()]
		private string  _cust_adpost_quantity;

		[DBField()]
		private string  _compute_0012;

		[DBField()]
		private string  _compute_0013;

		[DBField()]
		private string  _compute_0014;

		[DBField()]
		private string  _compute_0015;

		[DBField()]
		private string  _compute_0016;


		public virtual int? CustId
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

		public virtual string CustDirListingInd
		{
			get
			{
                CanReadProperty("CustDirListingInd", true);
				return _cust_dir_listing_ind;
			}
			set
			{
                CanWriteProperty("CustDirListingInd", true);
				if ( _cust_dir_listing_ind != value )
				{
					_cust_dir_listing_ind = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustDirListingText
		{
			get
			{
                CanReadProperty("CustDirListingText", true);
				return _cust_dir_listing_text;
			}
			set
			{
                CanWriteProperty("CustDirListingText", true);
				if ( _cust_dir_listing_text != value )
				{
					_cust_dir_listing_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CustDateCommenced
		{
			get
			{
                CanReadProperty("CustDateCommenced", true);
				return _cust_date_commenced;
			}
			set
			{
                CanWriteProperty("CustDateCommenced", true);
				if ( _cust_date_commenced != value )
				{
					_cust_date_commenced = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustAdpostQuantity
		{
			get
			{
                CanReadProperty("CustAdpostQuantity", true);
				return _cust_adpost_quantity;
			}
			set
			{
                CanWriteProperty("CustAdpostQuantity", true);
				if ( _cust_adpost_quantity != value )
				{
					_cust_adpost_quantity = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Compute0012
		{
			get
			{
                CanReadProperty("Compute0012", true);
				return _compute_0012;
			}
			set
			{
                CanWriteProperty("Compute0012", true);
				if ( _compute_0012 != value )
				{
					_compute_0012 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Compute0013
		{
			get
			{
                CanReadProperty("Compute0013", true);
				return _compute_0013;
			}
			set
			{
                CanWriteProperty("Compute0013", true);
				if ( _compute_0013 != value )
				{
					_compute_0013 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Compute0014
		{
			get
			{
                CanReadProperty("Compute0014", true);
				return _compute_0014;
			}
			set
			{
                CanWriteProperty("Compute0014", true);
				if ( _compute_0014 != value )
				{
					_compute_0014 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Compute0015
		{
			get
			{
                CanReadProperty("Compute0015", true);
				return _compute_0015;
			}
			set
			{
                CanWriteProperty("Compute0015", true);
				if ( _compute_0015 != value )
				{
					_compute_0015 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Compute0016
		{
			get
			{
                CanReadProperty("Compute0016", true);
				return _compute_0016;
			}
			set
			{
                CanWriteProperty("Compute0016", true);
				if ( _compute_0016 != value )
				{
					_compute_0016 = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[delivery_days]
		//?	if(mid( compute_0014 ,1,1)='Y','Mon ', '') + if(mid(compute_0014,2,1)='Y','Tue ','') + if(mid(compute_0014,3,1)='Y','Wed ','') + if(mid(compute_0014,4,1)='Y','Thu ','') + if(mid(compute_0014,5,1)='Y','Fri ','') + if(mid(compute_0014,6,1)='Y','Sat ','') + if(mid(compute_0014,7,1)='Y','Sun ','')

			// needs to implement compute expression manually:
			// compute control name=[cust_name]
		//?	Trim(if(isnull( cust_title ),'', cust_title )+' '+if(isnull(  cust_initials ),'',  cust_initials )+' '+if(isnull(  cust_surname_company ),'',  cust_surname_company ))


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static DetailedCustomerListing NewDetailedCustomerListing(  )
		{
			return Create();
		}

		public static DetailedCustomerListing[] GetAllDetailedCustomerListing(  )
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
                    cm.CommandText = "rd.sp_getcustomerdetails";
					ParameterCollection pList = new ParameterCollection();

					List<DetailedCustomerListing> _list = new List<DetailedCustomerListing>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DetailedCustomerListing instance = new DetailedCustomerListing();
                            instance._cust_id = GetValueFromReader<int?>(dr,0);
                            instance._cust_title = GetValueFromReader<string>(dr,1);
                            instance._cust_initials = GetValueFromReader<string>(dr,2);
                            instance._cust_surname_company = GetValueFromReader<string>(dr,3);
                            instance._cust_phone_day = GetValueFromReader<string>(dr,4);
                            instance._cust_phone_night = GetValueFromReader<string>(dr,5);
                            instance._cust_phone_mobile = GetValueFromReader<string>(dr,6);
                            instance._cust_dir_listing_ind = GetValueFromReader<string>(dr,7);
                            instance._cust_dir_listing_text = GetValueFromReader<string>(dr,8);
                            instance._cust_date_commenced = GetValueFromReader<DateTime?>(dr,9);
                            instance._cust_adpost_quantity = GetValueFromReader<string>(dr,10);
                            instance._compute_0012 = GetValueFromReader<string>(dr,11);
                            instance._compute_0013 = GetValueFromReader<string>(dr,12);
                            instance._compute_0014 = GetValueFromReader<string>(dr,13);
                            instance._compute_0015 = GetValueFromReader<string>(dr,14);
                            instance._compute_0016 = GetValueFromReader<string>(dr,15);
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
