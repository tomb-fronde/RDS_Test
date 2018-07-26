using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core.Security;using Metex.Core;

namespace NZPostOffice.Entity
{
    // TJB RPCR_117  July-2018
    // Changed u_phone to u_email in Database.  Changes to reflect this:
    // _phone -> _u_email, Phone -> UEmail

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("u_id", "_id", "rds_user")]
	[MapInfo("u_name", "_name", "rds_user")]
	[MapInfo("u_location", "_location", "rds_user")]
    [MapInfo("u_email", "_u_email", "rds_user")]
	[MapInfo("u_mobile", "_mobile", "rds_user")]
	[MapInfo("region_id", "_region_id", "rds_user")]
    [MapInfo("rgn_name", "_region_name", "region")]
	[MapInfo("ui_userid", "_user_id", "rds_user_id")]
	[MapInfo("ui_password", "_password", "rds_user_id")]
	[MapInfo("ui_last_login_date", "_last_login_date", "rds_user_id")]
	[MapInfo("ui_last_login_time", "_last_login_time", "rds_user_id")]
	[MapInfo("ui_created_date", "_created_date", "rds_user_id")]
	[MapInfo("ui_created_by", "_created_by", "rds_user_id")]
	[MapInfo("ui_modified_date", "_modified_date", "rds_user_id")]
	[MapInfo("ui_modified_by", "_modified_by", "rds_user_id")]
	[MapInfo("ui_password_expiry", "_password_expiry", "rds_user_id")]
	[MapInfo("ui_grace_logins", "_grace_logins", "rds_user_id")]
	[MapInfo("ui_locked_date", "_locked_date", "rds_user_id")]
	[MapInfo("ui_can_change_password", "_can_change_password", "rds_user_id")]
	[MapInfo("ui_id", "_ui_id", "rds_user_id")]
	[System.Serializable()]

	public class UserDetails : Entity<UserDetails>
	{
		#region Business Methods
		[DBField()]
		private int?  _id;

		[DBField()]
		private string  _name;

		[DBField()]
		private string  _location;

		[DBField()]
		private string  _u_email;  //_phone;

		[DBField()]
		private string  _mobile;

		[DBField()]
		private int?  _region_id;

		[DBField()]
		private string  _region_name;

		[DBField()]
		private string  _user_id;

		[DBField()]
		private string  _password;

		[DBField()]
		private DateTime?  _last_login_date;

		[DBField()]
		private DateTime?  _last_login_time;

		[DBField()]
		private DateTime?  _created_date;

		[DBField()]
		private string  _created_by;

		[DBField()]
		private DateTime?  _modified_date;

		[DBField()]
		private string  _modified_by;

		[DBField()]
		private DateTime?  _password_expiry;

		[DBField()]
		private int?  _grace_logins;

		[DBField()]
		private DateTime?  _locked_date;

		[DBField()]
		private string  _can_change_password;

		[DBField()]
		private int?  _ui_id;


		public virtual int? Id
		{
			get
			{
				CanReadProperty(true);
				return _id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _id != value )
				{
					_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Name
		{
			get
			{
				CanReadProperty(true);
				return _name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _name != value )
				{
					_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Location
		{
			get
			{
				CanReadProperty(true);
				return _location;
			}
			set
			{
				CanWriteProperty(true);
				if ( _location != value )
				{
					_location = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UEmail  // Phone
		{
			get
			{
				CanReadProperty(true);
				return _u_email;      // _phone
			}
			set
			{
				CanWriteProperty(true);
                if (_u_email != value)
				{
                    _u_email = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Mobile
		{
			get
			{
				CanReadProperty(true);
				return _mobile;
			}
			set
			{
				CanWriteProperty(true);
				if ( _mobile != value )
				{
					_mobile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionId
		{
			get
			{
				CanReadProperty(true);
				return _region_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_id != value )
				{
					_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionName
		{
			get
			{
				CanReadProperty(true);
				return _region_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_name != value )
				{
					_region_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UserId
		{
			get
			{
				CanReadProperty(true);
				return _user_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _user_id != value )
				{
					_user_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Password
		{
			get
			{
				CanReadProperty(true);
				return _password;
			}
			set
			{
				CanWriteProperty(true);
				if ( _password != value )
				{
					_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? LastLoginDate
		{
			get
			{
				CanReadProperty(true);
				return _last_login_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _last_login_date != value )
				{
					_last_login_date = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual DateTime? LastLoginTime
		{
			get
			{
				CanReadProperty(true);
				return _last_login_time;
			}
			set
			{
				CanWriteProperty(true);
				if ( _last_login_time != value )
				{
					_last_login_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CreatedDate
		{
			get
			{
				CanReadProperty(true);
				return _created_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _created_date != value )
				{
					_created_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CreatedBy
		{
			get
			{
				CanReadProperty(true);
				return _created_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _created_by != value )
				{
					_created_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ModifiedDate
		{
			get
			{
				CanReadProperty(true);
				return _modified_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _modified_date != value )
				{
					_modified_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ModifiedBy
		{
			get
			{
				CanReadProperty(true);
				return _modified_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _modified_by != value )
				{
					_modified_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? PasswordExpiry
		{
			get
			{
				CanReadProperty(true);
				return _password_expiry;
			}
			set
			{
				CanWriteProperty(true);
				if ( _password_expiry != value )
				{
					_password_expiry = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GraceLogins
		{
			get
			{
				CanReadProperty(true);
				return _grace_logins;
			}
			set
			{
				CanWriteProperty(true);
				if ( _grace_logins != value )
				{
					_grace_logins = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? LockedDate
		{
			get
			{
				CanReadProperty(true);
				return _locked_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _locked_date != value )
				{
					_locked_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CanChangePassword
		{
			get
			{
				CanReadProperty(true);
				return _can_change_password;
			}
			set
			{
				CanWriteProperty(true);
				if ( _can_change_password != value )
				{
					_can_change_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? UiId
		{
			get
			{
				CanReadProperty(true);
				return _ui_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_id != value )
				{
					_ui_id = value;
					PropertyHasChanged();
				}
			}
		}
        private UserDetails[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        public static UserDetails NewUserDetails(string as_username)
		{
			return Create(as_username);
		}

        public static UserDetails[] GetAllUserDetails(string as_username)
		{
			return Fetch(as_username).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( string as_username )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_user.u_id"
                                    + "    , rds_user.u_name"
                                    + "    , rds_user.u_location"
                                    + "    , rds_user.u_email"
                                    + "    , rds_user.u_mobile"
                                    + "    , rds_user.region_id"
                                    + "    , isNull(region.rgn_name,'National User') as rgn_name"
                                    + "    , rds_user_id.ui_userid"
                                    + "    , rds_user_id.ui_password"
                                    + "    , rds_user_id.ui_last_login_date"
                                    + "    , rds_user_id.ui_last_login_time"
                                    + "    , rds_user_id.ui_created_date"
                                    + "    , rds_user_id.ui_created_by"
                                    + "    , rds_user_id.ui_modified_date"
                                    + "    , rds_user_id.ui_modified_by"
                                    + "    , rds_user_id.ui_password_expiry"
                                    + "    , rds_user_id.ui_grace_logins"
                                    + "    , rds_user_id.ui_locked_date"
                                    + "    , rds_user_id.ui_can_change_password"
                                    + "    , rds_user_id.ui_id "
                                    + " FROM {oj rd.rds_user  LEFT OUTER JOIN rd.region" 
                                    + "                       ON rds_user.region_id = region.region_id}" 
                                    + "                        , rd.rds_user_id " 
                                    + "WHERE rds_user_id.u_id = rds_user.u_id" 
                                    + "  and rds_user_id.ui_userid = :as_username ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "as_username", as_username);

                    List<UserDetails> list = new List<UserDetails>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            UserDetails instance = new UserDetails();
                            instance.StoreFieldValues(dr, "region");
                            instance.StoreFieldValues(dr, "rds_user");
							instance.StoreFieldValues(dr, "rds_user_id");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new UserDetails[list.Count];
						list.CopyTo(dataList);
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
