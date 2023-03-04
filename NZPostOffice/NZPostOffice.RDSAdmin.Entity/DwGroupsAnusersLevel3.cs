using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("label", "_label", "rds_user")]
	[MapInfo("id", "_id", "rds_user_id")]
	[MapInfo("account", "_account", "rds_user")]
	[MapInfo("parent_id1", "_parent_id1", "rds_user")]
	[MapInfo("parent_id2", "_parent_id2", "rds_user")]
	[MapInfo("pictindex", "_pictindex", "rds_user")]
	[System.Serializable()]

    public class GroupsAndUsersLevel3 : Entity<GroupsAndUsersLevel3>
	{
		#region Business Methods
		[DBField()]
		private string  _label;

		[DBField()]
		private int?  _id;

		[DBField()]
		private int?  _account;

		[DBField()]
		private int?  _parent_id1;

		[DBField()]
		private int?  _parent_id2;

		[DBField()]
		private int?  _pictindex;


		public virtual string Label
		{
			get
			{
				CanReadProperty(true);
				return _label;
			}
			set
			{
				CanWriteProperty(true);
				if ( _label != value )
				{
					_label = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual int? Account
		{
			get
			{
				CanReadProperty(true);
				return _account;
			}
			set
			{
				CanWriteProperty(true);
				if ( _account != value )
				{
					_account = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ParentId1
		{
			get
			{
				CanReadProperty(true);
				return _parent_id1;
			}
			set
			{
				CanWriteProperty(true);
				if ( _parent_id1 != value )
				{
					_parent_id1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ParentId2
		{
			get
			{
				CanReadProperty(true);
				return _parent_id2;
			}
			set
			{
				CanWriteProperty(true);
				if ( _parent_id2 != value )
				{
					_parent_id2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Pictindex
		{
			get
			{
				CanReadProperty(true);
				return _pictindex;
			}
			set
			{
				CanWriteProperty(true);
				if ( _pictindex != value )
				{
					_pictindex = value;
					PropertyHasChanged();
				}
			}
		}
        private GroupsAndUsersLevel3[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        public static GroupsAndUsersLevel3 NewGroupsAndUsersLevel3()
		{
			return Create();
		}

        public static GroupsAndUsersLevel3[] GetAllGroupsAndUsersLevel3(int al_parent_id1, int al_parent_id2)
		{
			return Fetch(al_parent_id1, al_parent_id2).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int al_parent_id1, int al_parent_id2)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_user.u_name as Label,  rds_user_id.ui_id as ID,  rds_user.u_id as Account,  :al_parent_id1 as parent_id1,  :al_parent_id2 as parent_id2, 3 as Pictindex  FROM rds_user,  rds_user_group,  rds_user_id,  rds_user_id_group  WHERE ( rds_user_id.u_id = rds_user.u_id ) and  ( rds_user_id_group.ui_id = rds_user_id.ui_id ) and  ( rds_user_id_group.ug_id = rds_user_group.ug_id ) and  ( ( rds_user_group.ug_id = :al_parent_id1 ) AND  ( :al_parent_id2 = 1 ) )  UNION  SELECT rds_user_group.ug_name,  rds_user_group.ug_id,  0,  :al_parent_id1,  :al_parent_id2, 2 as Pictindex  FROM rds_user,  rds_user_group,  rds_user_id,  rds_user_id_group  WHERE ( rds_user_id.u_id = rds_user.u_id ) and  ( rds_user_id_group.ui_id = rds_user_id.ui_id ) and  ( rds_user_id_group.ug_id = rds_user_group.ug_id ) and  ( ( rds_user_id_group.ui_id = :al_parent_id1 ) AND  ( :al_parent_id2 = 2 ) )   UNION  SELECT region.rgn_name,  region.region_id,  0,  :al_parent_id1,  :al_parent_id2, 2 as Pictindex  FROM region  WHERE :al_parent_id2 = 3  and :al_parent_id1 = 1 ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_parent_id1", al_parent_id1);
					pList.Add(cm, "al_parent_id2", al_parent_id2);

                    List<GroupsAndUsersLevel3> list = new List<GroupsAndUsersLevel3>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            GroupsAndUsersLevel3 instance = new GroupsAndUsersLevel3();
							instance.StoreFieldValues(dr, "rds_user");
							instance.StoreFieldValues(dr, "rds_user_group");
							instance.StoreFieldValues(dr, "rds_user_id");
							instance.StoreFieldValues(dr, "rds_user_id_group");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new GroupsAndUsersLevel3[list.Count];
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
