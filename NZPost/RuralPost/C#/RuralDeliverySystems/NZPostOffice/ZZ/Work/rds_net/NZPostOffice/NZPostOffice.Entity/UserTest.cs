using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core.Security;using Metex.Core;

namespace NZPostOffice.Entity
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("u_id", "_rds_user_u_id", "rds_user")]
	[MapInfo("u_name", "_rds_user_u_name", "rds_user")]
	[MapInfo("u_location", "_rds_user_u_location", "rds_user")]
	[MapInfo("u_phone", "_rds_user_u_phone", "rds_user")]
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
		private string  _rds_user_u_phone;

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
        private DateTime? _rds_user_id_ui_last_login_time;

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


		public virtual int? RdsUserUId
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_id != value )
				{
					_rds_user_u_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserUName
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_name != value )
				{
					_rds_user_u_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserULocation
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_location;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_location != value )
				{
					_rds_user_u_location = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserUPhone
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_phone;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_phone != value )
				{
					_rds_user_u_phone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserUMobile
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_mobile;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_mobile != value )
				{
					_rds_user_u_mobile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RdsUserRegionId
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_region_id;
			}
			set
			{
				CanWriteProperty(true);
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
				CanReadProperty(true);
				return _region_rgn_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_rgn_name != value )
				{
					_region_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserIdUiUserid
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_userid;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_userid != value )
				{
					_rds_user_id_ui_userid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserIdUiPassword
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_password;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_password != value )
				{
					_rds_user_id_ui_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RdsUserIdUiLastLoginDate
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_last_login_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_last_login_date != value )
				{
					_rds_user_id_ui_last_login_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RdsUserIdUiLastLoginTime
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_last_login_time;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_last_login_time != value )
				{
					_rds_user_id_ui_last_login_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RdsUserIdUiCreatedDate
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_created_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_created_date != value )
				{
					_rds_user_id_ui_created_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserIdUiCreatedBy
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_created_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_created_by != value )
				{
					_rds_user_id_ui_created_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RdsUserIdUiModifiedDate
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_modified_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_modified_date != value )
				{
					_rds_user_id_ui_modified_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserIdUiModifiedBy
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_modified_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_modified_by != value )
				{
					_rds_user_id_ui_modified_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RdsUserIdUiPasswordExpiry
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_password_expiry;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_password_expiry != value )
				{
					_rds_user_id_ui_password_expiry = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RdsUserIdUiGraceLogins
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_grace_logins;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_grace_logins != value )
				{
					_rds_user_id_ui_grace_logins = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RdsUserIdUiLockedDate
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_locked_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_locked_date != value )
				{
					_rds_user_id_ui_locked_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserIdUiCanChangePassword
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_can_change_password;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_can_change_password != value )
				{
					_rds_user_id_ui_can_change_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RdsUserIdUiId
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_id != value )
				{
					_rds_user_id_ui_id = value;
					PropertyHasChanged();
				}
			}
		}
		private UserTest[] dataList;

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
					cm.CommandText = "SELECT rds_user.u_id,  rds_user.u_name,  rds_user.u_location,  rds_user.u_phone,  rds_user.u_mobile,  rds_user.region_id,  region.rgn_name,  rds_user_id.ui_userid,  rds_user_id.ui_password,  rds_user_id.ui_last_login_date,  rds_user_id.ui_last_login_time,  rds_user_id.ui_created_date,  rds_user_id.ui_created_by,  rds_user_id.ui_modified_date,  rds_user_id.ui_modified_by,  rds_user_id.ui_password_expiry,  rds_user_id.ui_grace_logins,  rds_user_id.ui_locked_date,  rds_user_id.ui_can_change_password,  rds_user_id.ui_id  FROM {oj rd.rds_user  LEFT OUTER JOIN rd.region  ON rds_user.region_id = region.region_id},  rd.rds_user_id  WHERE ( rds_user_id.u_id = rds_user.u_id ) and  ( ( rds_user_id.ui_userid = :as_username ) )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "as_username", as_username);

					List<UserTest> list = new List<UserTest>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserTest instance = new UserTest();
							instance.StoreFieldValues(dr, "oj");
							instance.StoreFieldValues(dr, "LEFT");
							instance.StoreFieldValues(dr, "JOIN");
							instance.StoreFieldValues(dr, "ON");
							instance.StoreFieldValues(dr, "rd.rds_user_id");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new UserTest[list.Count];
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
