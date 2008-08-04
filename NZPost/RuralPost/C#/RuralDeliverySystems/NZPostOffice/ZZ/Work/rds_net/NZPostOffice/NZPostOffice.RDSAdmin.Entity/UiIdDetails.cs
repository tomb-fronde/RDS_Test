using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("ui_id", "_ui_id", "rds_user_id")]
	[MapInfo("u_id", "_u_id", "rds_user_id")]
	[MapInfo("ui_userid", "_ui_userid", "rds_user_id")]
	[MapInfo("ui_password", "_ui_password", "rds_user_id")]
	[MapInfo("ui_last_login_date", "_ui_last_login_date", "rds_user_id")]
	[MapInfo("ui_last_login_time", "_ui_last_login_time", "rds_user_id")]
	[MapInfo("ui_created_date", "_ui_created_date", "rds_user_id")]
	[MapInfo("ui_created_by", "_ui_created_by", "rds_user_id")]
	[MapInfo("ui_modified_date", "_ui_modified_date", "rds_user_id")]
	[MapInfo("ui_modified_by", "_ui_modified_by", "rds_user_id")]
	[MapInfo("ui_password_expiry", "_ui_password_expiry", "rds_user_id")]
	[MapInfo("ui_grace_logins", "_ui_grace_logins", "rds_user_id")]
	[MapInfo("ui_locked_date", "_ui_locked_date", "rds_user_id")]
	[MapInfo("ui_can_change_password", "_ui_can_change_password", "rds_user_id")]
	[System.Serializable()]

	public class UiIdDetails : Entity<UiIdDetails>
	{
		#region Business Methods
		[DBField()]
		private int?  _ui_id;

		[DBField()]
		private int?  _u_id;

		[DBField()]
		private string  _ui_userid;

		[DBField()]
		private string  _ui_password;

		[DBField()]
		private DateTime?  _ui_last_login_date;

		[DBField()]
		private DateTime?  _ui_last_login_time;

		[DBField()]
		private DateTime?  _ui_created_date;

		[DBField()]
		private string  _ui_created_by;

		[DBField()]
		private DateTime?  _ui_modified_date;

		[DBField()]
		private string  _ui_modified_by;

		[DBField()]
		private DateTime?  _ui_password_expiry;

		[DBField()]
		private int?  _ui_grace_logins;

		[DBField()]
		private DateTime?  _ui_locked_date;

		[DBField()]
		private string  _ui_can_change_password;


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

		public virtual int? UId
		{
			get
			{
				CanReadProperty(true);
				return _u_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _u_id != value )
				{
					_u_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UiUserid
		{
			get
			{
				CanReadProperty(true);
				return _ui_userid;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_userid != value )
				{
					_ui_userid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UiPassword
		{
			get
			{
				CanReadProperty(true);
				return _ui_password;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_password != value )
				{
					_ui_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? UiLastLoginDate
		{
			get
			{
				CanReadProperty(true);
				return _ui_last_login_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_last_login_date != value )
				{
					_ui_last_login_date = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual DateTime? UiLastLoginTime
		{
			get
			{
				CanReadProperty(true);
				return _ui_last_login_time;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_last_login_time != value )
				{
					_ui_last_login_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? UiCreatedDate
		{
			get
			{
				CanReadProperty(true);
				return _ui_created_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_created_date != value )
				{
					_ui_created_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UiCreatedBy
		{
			get
			{
				CanReadProperty(true);
				return _ui_created_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_created_by != value )
				{
					_ui_created_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? UiModifiedDate
		{
			get
			{
				CanReadProperty(true);
				return _ui_modified_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_modified_date != value )
				{
					_ui_modified_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UiModifiedBy
		{
			get
			{
				CanReadProperty(true);
				return _ui_modified_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_modified_by != value )
				{
					_ui_modified_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? UiPasswordExpiry
		{
			get
			{
				CanReadProperty(true);
				return _ui_password_expiry;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_password_expiry != value )
				{
					_ui_password_expiry = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? UiGraceLogins
		{
			get
			{
				CanReadProperty(true);
				return _ui_grace_logins;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_grace_logins != value )
				{
					_ui_grace_logins = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? UiLockedDate
		{
			get
			{
				CanReadProperty(true);
				return _ui_locked_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_locked_date != value )
				{
					_ui_locked_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UiCanChangePassword
		{
			get
			{
				CanReadProperty(true);
				return _ui_can_change_password;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_can_change_password != value )
				{
					_ui_can_change_password = value;
					PropertyHasChanged();
				}
			}
		}
		private UiIdDetails[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ui_id );
		}
		#endregion

		#region Factory Methods
		public static UiIdDetails NewUiIdDetails( int? al_user_id )
		{
			return Create(al_user_id);
		}

		public static UiIdDetails[] GetAllUiIdDetails( int? al_user_id )
		{
			return Fetch(al_user_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_user_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_user_id", al_user_id);
					GenerateSelectCommandText(cm, "rds_user_id");
                    cm.CommandText += " where rds_user_id.ui_id = @al_user_id";

					List<UiIdDetails> list = new List<UiIdDetails>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UiIdDetails instance = new UiIdDetails();
							instance.StoreFieldValues(dr, "rds_user_id");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new UiIdDetails[list.Count];
						list.CopyTo(dataList);
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
				if (GenerateUpdateCommandText(cm, "rds_user_id", ref pList))
				{
					cm.CommandText += " WHERE  rds_user_id.ui_id = @ui_id ";

					pList.Add(cm, "ui_id", GetInitialValue("_ui_id"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "rds_user_id", pList))
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
					pList.Add(cm,"ui_id", GetInitialValue("_ui_id"));
						cm.CommandText = "DELETE FROM rds_user_id WHERE " +
						"rds_user_id.ui_id = @ui_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ui_id )
		{
			_ui_id = ui_id;
		}
	}
}
