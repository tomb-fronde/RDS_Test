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
	[MapInfo("ug_id", "_group_id", "rds_user_group")]
	[MapInfo("ug_name", "_name", "rds_user_group")]
	[MapInfo("ug_description", "_description", "rds_user_group")]
	[MapInfo("ug_created_date", "_created_date", "rds_user_group")]
	[MapInfo("ug_created_by", "_created_by", "rds_user_group")]
	[MapInfo("ug_modified_date", "_modified_date", "rds_user_group")]
	[MapInfo("ug_modified_by", "_modified_by", "rds_user_group")]
	[MapInfo("ug_privacy_override", "_privacy_override", "rds_user_group")]
	[System.Serializable()]

	public class GroupDetails : Entity<GroupDetails>
	{
		#region Business Methods
		[DBField()]
		private int?  _group_id;

		[DBField()]
		private string  _name;

		[DBField()]
		private string  _description;

		[DBField()]
		private DateTime?  _created_date;

		[DBField()]
		private string  _created_by;

		[DBField()]
		private DateTime?  _modified_date;

		[DBField()]
		private string  _modified_by;

		[DBField()]
		private string  _privacy_override;


		public virtual int? GroupId
		{
			get
			{
				CanReadProperty(true);
				return _group_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _group_id != value )
				{
					_group_id = value;
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

		public virtual string Description
		{
			get
			{
				CanReadProperty(true);
				return _description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _description != value )
				{
					_description = value;
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

		public virtual string PrivacyOverride
		{
			get
			{
				CanReadProperty(true);
				return _privacy_override;
			}
			set
			{
				CanWriteProperty(true);
				if ( _privacy_override != value )
				{
					_privacy_override = value;
					PropertyHasChanged();
				}
			}
		}
		private GroupDetails[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _group_id );
		}
		#endregion

		#region Factory Methods
		public static GroupDetails NewGroupDetails( int? al_group_id )
		{
			return Create(al_group_id);
		}

		public static GroupDetails[] GetAllGroupDetails( int? al_group_id )
		{
			return Fetch(al_group_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_group_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_user_group.ug_id,  rds_user_group.ug_name,  rds_user_group.ug_description,  rds_user_group.ug_created_date,  rds_user_group.ug_created_by,  rds_user_group.ug_modified_date,  rds_user_group.ug_modified_by,  rds_user_group.ug_privacy_override  FROM rd.rds_user_group  WHERE rds_user_group.ug_id = :al_group_id  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_group_id", al_group_id);

					List<GroupDetails> list = new List<GroupDetails>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							GroupDetails instance = new GroupDetails();
							instance.StoreFieldValues(dr, "rds_user_group");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new GroupDetails[list.Count];
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
				if (GenerateUpdateCommandText(cm, "rds_user_group", ref pList))
				{
					cm.CommandText += " WHERE  rds_user_group.ug_id = @ug_id ";

					pList.Add(cm, "ug_id", GetInitialValue("_group_id"));
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
				if (GenerateInsertCommandText(cm, "rds_user_group", pList))
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
					pList.Add(cm,"ug_id", GetInitialValue("_group_id"));
						cm.CommandText = "DELETE FROM rds_user_group WHERE " +
						"rds_user_group.ug_id = @ug_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? group_id )
		{
			_group_id = group_id;
		}
	}
}
