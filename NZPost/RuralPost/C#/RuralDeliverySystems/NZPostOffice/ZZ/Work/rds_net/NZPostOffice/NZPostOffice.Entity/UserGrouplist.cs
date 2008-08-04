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
	[MapInfo("ug_id", "_id", "rds_user_id_group")]
	[MapInfo("ug_name", "_rds_user_group_ug_name", "rds_user_group")]
	[System.Serializable()]

	public class UserGrouplist : Entity<UserGrouplist>
	{
		#region Business Methods
		[DBField()]
		private int?  _id;

		[DBField()]
		private string  _rds_user_group_ug_name;


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

		public virtual string RdsUserGroupUgName
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_group_ug_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_group_ug_name != value )
				{
					_rds_user_group_ug_name = value;
					PropertyHasChanged();
				}
			}
		}
		private UserGrouplist[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static UserGrouplist NewUserGrouplist( string as_userid )
		{
			return Create(as_userid);
		}

		public static UserGrouplist[] GetAllUserGrouplist( string as_userid )
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
					cm.CommandText = "SELECT rds_user_id_group.ug_id,  rds_user_group.ug_name  FROM rd.rds_user_id_group,  rd.rds_user_id,  rd.rds_user_group  WHERE ( rds_user_id.ui_id = rds_user_id_group.ui_id ) and  ( rds_user_group.ug_id = rds_user_id_group.ug_id ) and  ( ( rds_user_id.ui_userid = :as_userid ) )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "as_userid", as_userid);

					List<UserGrouplist> list = new List<UserGrouplist>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserGrouplist instance = new UserGrouplist();
							instance.StoreFieldValues(dr, "rds_user_id_group");
							instance.StoreFieldValues(dr, "rds_user_id");
							instance.StoreFieldValues(dr, "rds_user_group");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new UserGrouplist[list.Count];
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
