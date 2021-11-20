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
	[MapInfo("ug_id", "_group_id", "rds_user_id_group")]
	[MapInfo("ug_name", "_group_name", "rds_user_group")]
	[MapInfo("ug_description", "_group_description", "rds_user_group")]
	[MapInfo("ug_created_date", "_created_date", "rds_user_group")]
	[MapInfo("ug_created_by", "_created_by", "rds_user_group")]
	[MapInfo("ug_modified_date", "_modified_date", "rds_user_group")]
	[MapInfo("ug_modified_by", "_modified_by", "rds_user_group")]
	[MapInfo("ug_privacy_override", "_privacy_override", "rds_user_group")]
	[System.Serializable()]

	public class UserGroups : Entity<UserGroups>
	{
		#region Business Methods
		[DBField()]
		private int?  _group_id;

		[DBField()]
		private string  _group_name;

		[DBField()]
		private string  _group_description;

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

		public virtual string GroupName
		{
			get
			{
				CanReadProperty(true);
				return _group_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _group_name != value )
				{
					_group_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string GroupDescription
		{
			get
			{
				CanReadProperty(true);
				return _group_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _group_description != value )
				{
					_group_description = value;
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
		private UserGroups[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static UserGroups NewUserGroups( string as_userid )
		{
			return Create(as_userid);
		}

		public static UserGroups[] GetAllUserGroups( string as_userid )
		{
			return Fetch(as_userid).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( string as_userid )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_user_id_group.ug_id,  rds_user_group.ug_name,  rds_user_group.ug_description,  rds_user_group.ug_created_date,  rds_user_group.ug_created_by,  rds_user_group.ug_modified_date,  rds_user_group.ug_modified_by,  rds_user_group.ug_privacy_override  FROM rd.rds_user_id_group,  rd.rds_user_group,  rd.rds_user_id  WHERE ( rds_user_group.ug_id = rds_user_id_group.ug_id ) and  ( rds_user_id.ui_id = rds_user_id_group.ui_id ) and  ( ( rds_user_id.ui_userid = :as_userid ) )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "as_userid", as_userid);

					List<UserGroups> list = new List<UserGroups>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserGroups instance = new UserGroups();
							instance.StoreFieldValues(dr, "rd.rds_user_id_group");
							instance.StoreFieldValues(dr, "rd.rds_user_group");
							instance.StoreFieldValues(dr, "rd.rds_user_id");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new UserGroups[list.Count];
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
