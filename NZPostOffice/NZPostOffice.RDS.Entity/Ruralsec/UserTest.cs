using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralsec
{
    // TJB  RPCR_117  July-2018
    // Changed u_phone to u_email, and Phone to Email

    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("u_id", "_rds_user_u_id", "rds_user")]
	[MapInfo("u_name", "_rds_user_u_name", "rds_user")]
	[MapInfo("u_location", "_rds_user_u_location", "rds_user")]
    [MapInfo("u_email", "_rds_user_u_email", "rds_user")]     // u_phone, _rds_user_u_phone
	[MapInfo("u_mobile", "_rds_user_u_mobile", "rds_user")]
	[MapInfo("region_id", "_rds_user_region_id", "rds_user")]
	[MapInfo("rgn_name", "_region_rgn_name", "region")]
	[MapInfo("ui_userid", "_rds_user_id_ui_userid", "rds_user_id")]
	[MapInfo("ui_password", "_rds_user_id_ui_password", "rds_user_id")]
	[MapInfo("ui_last_login_date", "_rds_user_id_ui_last_login_date", "rds_user_id")]
	[MapInfo("ui_last_login_time", "_rds_user_id_ui_last_login_time", "rds_user_id")]
	[MapInfo("ui_created_date", "_rds_user_id_ui_created_date", "rds_user_id")]
	[MapInfo("ui_created_by", "_rds_user_id_ui_created_by", "rds_user_id")]
	[MapInfo("ui_modified_date", "_rds_user_id_ui_modified_date", "rds_user_id")]
	[MapInfo("ui_modified_by", "_rds_user_id_ui_modified_by", "rds_user_id")]
	[MapInfo("ui_password_expiry", "_rds_user_id_ui_password_expiry", "rds_user_id")]
	[MapInfo("ui_grace_logins", "_rds_user_id_ui_grace_logins", "rds_user_id")]
	[MapInfo("ui_locked_date", "_rds_user_id_ui_locked_date", "rds_user_id")]
	[MapInfo("ui_can_change_password", "_rds_user_id_ui_can_change_password", "rds_user_id")]
	[MapInfo("ui_id", "_rds_user_id_ui_id", "rds_user_id")]
	[System.Serializable()]

	public class UserTest : Entity<UserTest>
	{
		#region Business Methods
		[DBField()]
		private int?  _rds_user_u_id;

		[DBField()]
		private string  _rds_user_u_name;

		[DBField()]
		private string  _rds_user_u_location;

		[DBField()]
        private string _rds_user_u_email;   // _rds_user_u_phone;

		[DBField()]
		private string  _rds_user_u_mobile;

		[DBField()]
		private int?  _rds_user_region_id;

		[DBField()]
		private string  _region_rgn_name;

		[DBField()]
		private string  _rds_user_id_ui_userid;

		[DBField()]
		private string  _rds_user_id_ui_password;

		[DBField()]
		private DateTime?  _rds_user_id_ui_last_login_date;

		[DBField()]
		private  DateTime? _rds_user_id_ui_last_login_time;

		[DBField()]
		private DateTime?  _rds_user_id_ui_created_date;

		[DBField()]
		private string  _rds_user_id_ui_created_by;

		[DBField()]
		private DateTime?  _rds_user_id_ui_modified_date;

		[DBField()]
		private string  _rds_user_id_ui_modified_by;

		[DBField()]
		private DateTime?  _rds_user_id_ui_password_expiry;

		[DBField()]
		private int?  _rds_user_id_ui_grace_logins;

		[DBField()]
		private DateTime?  _rds_user_id_ui_locked_date;

		[DBField()]
		private string  _rds_user_id_ui_can_change_password;

		[DBField()]
		private int?  _rds_user_id_ui_id;


		public virtual int? RDSUserUId
		{
			get
			{
                CanReadProperty("RDSUserUId", true);
				return _rds_user_u_id;
			}
			set
			{
                CanWriteProperty("RDSUserUId", true);
				if ( _rds_user_u_id != value )
				{
					_rds_user_u_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSUserUName
		{
			get
			{
                CanReadProperty("RDSUserUName", true);
				return _rds_user_u_name;
			}
			set
			{
                CanWriteProperty("RDSUserUName", true);
				if ( _rds_user_u_name != value )
				{
					_rds_user_u_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSUserULocation
		{
			get
			{
                CanReadProperty("RDSUserULocation", true);
				return _rds_user_u_location;
			}
			set
			{
                CanWriteProperty("RDSUserULocation", true);
				if ( _rds_user_u_location != value )
				{
					_rds_user_u_location = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string RDSUserUEmail   // RDSUserUPhone
		{
			get
			{
                CanReadProperty("RDSUserUEmail", true);
				return _rds_user_u_email;
			}
			set
			{
                CanWriteProperty("RDSUserUEmail", true);
                if (_rds_user_u_email != value)
				{
                    _rds_user_u_email = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSUserUMobile
		{
			get
			{
                CanReadProperty("RDSUserUMobile", true);
				return _rds_user_u_mobile;
			}
			set
			{
                CanWriteProperty("RDSUserUMobile", true);
				if ( _rds_user_u_mobile != value )
				{
					_rds_user_u_mobile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RDSUserRegionId
		{
			get
			{
                CanReadProperty("RDSUserRegionId", true);
				return _rds_user_region_id;
			}
			set
			{
                CanWriteProperty("RDSUserRegionId", true);
				if ( _rds_user_region_id != value )
				{
					_rds_user_region_id = value;
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

		public virtual string RDSUserIdUiUserid
		{
			get
			{
                CanReadProperty("RDSUserIdUiUserid", true);
				return _rds_user_id_ui_userid;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiUserid", true);
				if ( _rds_user_id_ui_userid != value )
				{
					_rds_user_id_ui_userid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSUserIdUiPassword
		{
			get
			{
                CanReadProperty("RDSUserIdUiPassword", true);
				return _rds_user_id_ui_password;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiPassword", true);
				if ( _rds_user_id_ui_password != value )
				{
					_rds_user_id_ui_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RDSUserIdUiLastLoginDate
		{
			get
			{
                CanReadProperty("RDSUserIdUiLastLoginDate", true);
				return _rds_user_id_ui_last_login_date;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiLastLoginDate", true);
				if ( _rds_user_id_ui_last_login_date != value )
				{
					_rds_user_id_ui_last_login_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RDSUserIdUiLastLoginTime
		{
			get
			{
                CanReadProperty("RDSUserIdUiLastLoginTime", true);
				return _rds_user_id_ui_last_login_time;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiLastLoginTime", true);
				if ( _rds_user_id_ui_last_login_time != value )
				{
					_rds_user_id_ui_last_login_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RDSUserIdUiCreatedDate
		{
			get
			{
                CanReadProperty("RDSUserIdUiCreatedDate", true);
				return _rds_user_id_ui_created_date;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiCreatedDate", true);
				if ( _rds_user_id_ui_created_date != value )
				{
					_rds_user_id_ui_created_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSUserIdUiCreatedBy
		{
			get
			{
                CanReadProperty("RDSUserIdUiCreatedBy", true);
				return _rds_user_id_ui_created_by;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiCreatedBy", true);
				if ( _rds_user_id_ui_created_by != value )
				{
					_rds_user_id_ui_created_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RDSUserIdUiModifiedDate
		{
			get
			{
                CanReadProperty("RDSUserIdUiModifiedDate", true);
				return _rds_user_id_ui_modified_date;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiModifiedDate", true);
				if ( _rds_user_id_ui_modified_date != value )
				{
					_rds_user_id_ui_modified_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSUserIdUiModifiedBy
		{
			get
			{
                CanReadProperty("RDSUserIdUiModifiedBy", true);
				return _rds_user_id_ui_modified_by;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiModifiedBy", true);
				if ( _rds_user_id_ui_modified_by != value )
				{
					_rds_user_id_ui_modified_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RDSUserIdUiPasswordExpiry
		{
			get
			{
                CanReadProperty("RDSUserIdUiPasswordExpiry", true);
				return _rds_user_id_ui_password_expiry;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiPasswordExpiry", true);
				if ( _rds_user_id_ui_password_expiry != value )
				{
					_rds_user_id_ui_password_expiry = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RDSUserIdUiGraceLogins
		{
			get
			{
                CanReadProperty("RDSUserIdUiGraceLogins", true);
				return _rds_user_id_ui_grace_logins;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiGraceLogins", true);
				if ( _rds_user_id_ui_grace_logins != value )
				{
					_rds_user_id_ui_grace_logins = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RDSUserIdUiLockedDate
		{
			get
			{
                CanReadProperty("RDSUserIdUiLockedDate", true);
				return _rds_user_id_ui_locked_date;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiLockedDate", true);
				if ( _rds_user_id_ui_locked_date != value )
				{
					_rds_user_id_ui_locked_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSUserIdUiCanChangePassword
		{
			get
			{
                CanReadProperty("RDSUserIdUiCanChangePassword", true);
				return _rds_user_id_ui_can_change_password;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiCanChangePassword", true);
				if ( _rds_user_id_ui_can_change_password != value )
				{
					_rds_user_id_ui_can_change_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RDSUserIdUiId
		{
			get
			{
                CanReadProperty("RDSUserIdUiId", true);
				return _rds_user_id_ui_id;
			}
			set
			{
                CanWriteProperty("RDSUserIdUiId", true);
				if ( _rds_user_id_ui_id != value )
				{
					_rds_user_id_ui_id = value;
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
		public static UserTest NewUserTest( string as_username )
		{
			return Create(as_username);
		}

		public static UserTest[] GetAllUserTest( string as_username )
		{
			return Fetch(as_username).list;
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
					cm.CommandText = "SELECT rds_user.u_id, rds_user.u_name, rds_user.u_location, rds_user.u_email, "+
                        "rds_user.u_mobile, rds_user.region_id, region.rgn_name, rds_user_id.ui_userid, "+
                        "rds_user_id.ui_password, rds_user_id.ui_last_login_date, rds_user_id.ui_last_login_time, "+
                        "rds_user_id.ui_created_date, rds_user_id.ui_created_by, rds_user_id.ui_modified_date, "+
                        "rds_user_id.ui_modified_by, rds_user_id.ui_password_expiry, rds_user_id.ui_grace_logins,"+
                        "rds_user_id.ui_locked_date, rds_user_id.ui_can_change_password, rds_user_id.ui_id "+
                        "FROM {oj rd.rds_user  LEFT OUTER JOIN rd.region  ON rds_user.region_id = region.region_id},rd.rds_user_id  "+
                        "WHERE rds_user_id.u_id = rds_user.u_id and rds_user_id.ui_userid = @as_username";

					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "as_username", as_username);

					List<UserTest> _list = new List<UserTest>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserTest instance = new UserTest();
                            instance._rds_user_u_id = GetValueFromReader<int?>(dr,0);
                            instance._rds_user_u_name = GetValueFromReader<string>(dr,1);
                            instance._rds_user_u_location = GetValueFromReader<string>(dr,2);
                            instance._rds_user_u_email = GetValueFromReader<string>(dr,3);
                            instance._rds_user_u_mobile = GetValueFromReader<string>(dr,4);
                            instance._rds_user_region_id = GetValueFromReader<int?>(dr,5);
                            instance._region_rgn_name = GetValueFromReader<string>(dr,6);
                            instance._rds_user_id_ui_userid = GetValueFromReader<string>(dr,7);
                            instance._rds_user_id_ui_password = GetValueFromReader<string>(dr,8);
                            instance._rds_user_id_ui_last_login_date = GetValueFromReader<DateTime?>(dr,9);
                            instance._rds_user_id_ui_last_login_time = GetValueFromReader<DateTime?>(dr,10);
                            instance._rds_user_id_ui_created_date = GetValueFromReader<DateTime?>(dr,11);
                            instance._rds_user_id_ui_created_by = GetValueFromReader<string>(dr,12);
                            instance._rds_user_id_ui_modified_date = GetValueFromReader<DateTime?>(dr,13);
                            instance._rds_user_id_ui_modified_by = GetValueFromReader<string>(dr,14);
                            instance._rds_user_id_ui_password_expiry = GetValueFromReader<DateTime?>(dr,15);
                            instance._rds_user_id_ui_grace_logins = GetValueFromReader<int?>(dr,16);
                            instance._rds_user_id_ui_locked_date = GetValueFromReader<DateTime?>(dr,17);
                            instance._rds_user_id_ui_can_change_password = GetValueFromReader<string>(dr,18);
                            instance._rds_user_id_ui_id = GetValueFromReader<int?>(dr,19);
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
