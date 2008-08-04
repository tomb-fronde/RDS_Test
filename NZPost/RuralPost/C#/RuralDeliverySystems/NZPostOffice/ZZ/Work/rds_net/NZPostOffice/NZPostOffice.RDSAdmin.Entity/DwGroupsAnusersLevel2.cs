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
	[MapInfo("label", "_label", "rds_user_group")]
	[MapInfo("id", "_id", "rds_user_group")]
	[MapInfo("account", "_account", "rds_user_group")]
	[MapInfo("parent_id1", "_parent_id1", "rds_user_group")]
	[MapInfo("pictindex", "_pictindex", "rds_user_group")]
	[System.Serializable()]

    public class GroupsAndUsersLevel2 : Entity<GroupsAndUsersLevel2>
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
        private GroupsAndUsersLevel2[] dataList;

		protected override object GetIdValue()
		{
			return "" + _id.ToString() + "/" + _parent_id1.ToString();
		}
		#endregion

		#region Factory Methods
        public static GroupsAndUsersLevel2 NewGroupsAndUsersLevel2()
		{
			return Create();
		}

        public static GroupsAndUsersLevel2[] GetAllGroupsAndUsersLevel2(int al_parent_id1)
		{
            return Fetch(al_parent_id1).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int al_parent_id1)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT rds_user_group.ug_name as Label,  rds_user_group.ug_id as ID,  rds_user_group.ug_id as Account,  @al_parent_id1 as parent_id1,  2 as Pictindex  from rds_user_group  where @al_parent_id1=1  union   select rds_user.u_name as Label,  rds_user_id.ui_id as ID,  rds_user.u_id as Account,  @al_parent_id1 as parent_id1,  3 as Pictindex  from rds_user,  rds_user_id  where @al_parent_id1=2  and	rds_user.u_id = rds_user_id.u_id   Union   select rds_maintenance_table.mt_name as Label,  rds_maintenance_table.mt_id as ID,  0 as Account,  @al_parent_id1 as Parent_id1,  5 as Pictindex  from rds_maintenance_table  where @al_parent_id1=3  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_parent_id1", al_parent_id1);

                    List<GroupsAndUsersLevel2> list = new List<GroupsAndUsersLevel2>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            GroupsAndUsersLevel2 instance = new GroupsAndUsersLevel2();
							instance.StoreFieldValues(dr, "rds_user_group");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new GroupsAndUsersLevel2[list.Count];
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
