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
	[MapInfo("label", "_label", "dummy")]
	[MapInfo("id", "_id", "dummy")]
	[MapInfo("parent_id1", "_parent_id1", "dummy")]
	[MapInfo("pictindex", "_pictindex", "dummy")]
	[MapInfo("selectedpictindex", "_selectedpictindex", "dummy")]
	[System.Serializable()]

    public class GroupsAndUsersLevel1 : Entity<GroupsAndUsersLevel1>
	{
		#region Business Methods
		[DBField()]
		private string  _label;

		[DBField()]
		private int?  _id;

		[DBField()]
		private int?  _parent_id1;

		[DBField()]
		private int?  _pictindex;

		[DBField()]
		private int?  _selectedpictindex;


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

		public virtual int? Selectedpictindex
		{
			get
			{
				CanReadProperty(true);
				return _selectedpictindex;
			}
			set
			{
				CanWriteProperty(true);
				if ( _selectedpictindex != value )
				{
					_selectedpictindex = value;
					PropertyHasChanged();
				}
			}
		}
        private GroupsAndUsersLevel1[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        public static GroupsAndUsersLevel1 NewGroupsAndUsersLevel1()
		{
			return Create();
		}

        public static GroupsAndUsersLevel1[] GetAllGroupsAndUsersLevel1()
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT 'Groups' as Label, 1 as ID ,0 as Parent_id1, 1 as Pictindex, 4 as SelectedPictindex  union  select 'Users' as Label, 2 as ID ,0 as Parent_id1, 1 as Pictindex, 4 as SelectedPictindex  union  select 'System Tables' as Label, 3 as ID ,0 as Parent_id1, 1 as Pictindex, 4 as SelectedPictindex";
					ParameterCollection pList = new ParameterCollection();

                    List<GroupsAndUsersLevel1> list = new List<GroupsAndUsersLevel1>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            GroupsAndUsersLevel1 instance = new GroupsAndUsersLevel1();
							instance.StoreFieldValues(dr, "dummy");
							instance.StoreFieldValues(dr, "as");
							instance.StoreFieldValues(dr, "2");
							instance.StoreFieldValues(dr, "ID");
							instance.StoreFieldValues(dr, "0");
							instance.StoreFieldValues(dr, "Parent_id1");
							instance.StoreFieldValues(dr, "1");
							instance.StoreFieldValues(dr, "Pictindex");
							instance.StoreFieldValues(dr, "4");
							instance.StoreFieldValues(dr, "SelectedPictindex");
							instance.StoreFieldValues(dr, "dummy");
							instance.StoreFieldValues(dr, "as");
							instance.StoreFieldValues(dr, "3");
							instance.StoreFieldValues(dr, "ID");
							instance.StoreFieldValues(dr, "0");
							instance.StoreFieldValues(dr, "Parent_id1");
							instance.StoreFieldValues(dr, "1");
							instance.StoreFieldValues(dr, "Pictindex");
							instance.StoreFieldValues(dr, "4");
							instance.StoreFieldValues(dr, "SelectedPictindex");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new GroupsAndUsersLevel1[list.Count];
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
