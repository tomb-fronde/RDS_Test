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
	[MapInfo("rur_id", "_rur_id", "rds_user_rights")]
	[MapInfo("rur_create", "_rur_create", "rds_user_rights")]
	[MapInfo("ug_id", "_ug_id", "rds_user_rights")]
	[MapInfo("rc_id", "_rc_id", "rds_user_rights")]
	[MapInfo("rur_read", "_rur_read", "rds_user_rights")]
	[MapInfo("rur_modify", "_rur_modify", "rds_user_rights")]
	[MapInfo("rur_delete", "_rur_delete", "rds_user_rights")]
	[MapInfo("rc_name", "_name", "rds_component")]
	[MapInfo("region_id", "_region_id", "rds_user_rights")]
	[System.Serializable()]

	public class UserGroupRights : Entity<UserGroupRights>
	{
		#region Business Methods
		[DBField()]
		private int?  _rur_id;

		[DBField()]
		private string  _rur_create;

		[DBField()]
		private int?  _ug_id;

		[DBField()]
		private int?  _rc_id;

		[DBField()]
		private string  _rur_read;

		[DBField()]
		private string  _rur_modify;

		[DBField()]
		private string  _rur_delete;

		[DBField()]
		private string  _name;

		[DBField()]
		private int?  _region_id;


		public virtual int? RurId
		{
			get
			{
				CanReadProperty("RurId", true);
				return _rur_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rur_id != value )
				{
					_rur_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RurCreate
		{
			get
			{
				CanReadProperty("RurCreate", true);
				return _rur_create;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rur_create != value )
				{
					_rur_create = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? UgId
		{
			get
			{
				CanReadProperty("UgId", true);
				return _ug_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_id != value )
				{
					_ug_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RcId
		{
			get
			{
				//? CanReadProperty("RcId", true);
				return _rc_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_id != value )
				{
					_rc_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RurRead
		{
			get
			{
				CanReadProperty("RurRead", true);
				return _rur_read;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rur_read != value )
				{
					_rur_read = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RurModify
		{
			get
			{
				CanReadProperty("RurModify", true);
				return _rur_modify;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rur_modify != value )
				{
					_rur_modify = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RurDelete
		{
			get
			{
				CanReadProperty("RurDelete", true);
				return _rur_delete;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rur_delete != value )
				{
					_rur_delete = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Name
		{
			get
			{
                CanReadProperty("Name", true);
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

		public virtual int? RegionId
		{
			get
			{
				CanReadProperty("RegionId", true);
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
		private UserGroupRights[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rur_id );
		}
		#endregion

		#region Factory Methods
		public static UserGroupRights NewUserGroupRights( int? al_groupid )
		{
			return Create(al_groupid);
		}

		public static UserGroupRights[] GetAllUserGroupRights( int? al_groupid )
		{
			return Fetch(al_groupid).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_groupid )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_user_rights.rur_id,  rds_user_rights.rur_create,  rds_user_rights.ug_id,  rds_user_rights.rc_id,  rds_user_rights.rur_read,  rds_user_rights.rur_modify,  rds_user_rights.rur_delete,  rds_component.rc_name,  rds_user_rights.region_id  FROM rd.rds_user_rights,  rd.rds_component  WHERE ( rds_component.rc_id = rds_user_rights.rc_id ) and  ( ( rds_user_rights.ug_id = :al_groupid ) )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_groupid", al_groupid);

					List<UserGroupRights> list = new List<UserGroupRights>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserGroupRights instance = new UserGroupRights();
							instance.StoreFieldValues(dr, "rds_user_rights");
							instance.StoreFieldValues(dr, "rds_component");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new UserGroupRights[list.Count];
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
				if (GenerateUpdateCommandText(cm, "rds_user_rights", ref pList))
				{
					cm.CommandText += " WHERE  rds_user_rights.rur_id = @rur_id ";

					pList.Add(cm, "rur_id", GetInitialValue("_rur_id"));
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
				if (GenerateInsertCommandText(cm, "rds_user_rights", pList))
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
					pList.Add(cm,"rur_id", GetInitialValue("_rur_id"));
						cm.CommandText = "DELETE FROM rds_user_rights WHERE " +
						"rds_user_rights.rur_id = @rur_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rur_id )
		{
			_rur_id = rur_id;
		}
	}
}
