using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("gp_code", "_gp_code", "user_groups")]
	[MapInfo("gp_title", "_gp_title", "user_groups")]
	[MapInfo("gp_cargo", "_gp_cargo", "user_groups")]
	[MapInfo("gp_created_date", "_gp_created_date", "user_groups")]
	[MapInfo("gp_created_by", "_gp_created_by", "user_groups")]
	[MapInfo("gp_modified_date", "_gp_modified_date", "user_groups")]
	[MapInfo("gp_modified_by", "_gp_modified_by", "user_groups")]
	[MapInfo("gp_level_1", "_gp_level_1", "user_groups")]
	[MapInfo("gp_level_2", "_gp_level_2", "user_groups")]
	[MapInfo("gp_level_3", "_gp_level_3", "user_groups")]
	[MapInfo("gp_level_4", "_gp_level_4", "user_groups")]
	[MapInfo("gp_level_5", "_gp_level_5", "user_groups")]
	[MapInfo("gp_level_6", "_gp_level_6", "user_groups")]
	[MapInfo("gp_level_7", "_gp_level_7", "user_groups")]
	[MapInfo("gp_level_8", "_gp_level_8", "user_groups")]
	[MapInfo("gp_level_9", "_gp_level_9", "user_groups")]
	[System.Serializable()]

	public class UserGroupTest : Entity<UserGroupTest>
	{
		#region Business Methods
		[DBField()]
		private int?  _gp_code;

		[DBField()]
		private string  _gp_title;

		[DBField()]
		private string  _gp_cargo;

		[DBField()]
		private DateTime?  _gp_created_date;

		[DBField()]
		private string  _gp_created_by;

		[DBField()]
		private DateTime?  _gp_modified_date;

		[DBField()]
		private string  _gp_modified_by;

		[DBField()]
		private int?  _gp_level_1 =-1;

		[DBField()]
		private int?  _gp_level_2=-1;

		[DBField()]
		private int?  _gp_level_3=-1;

		[DBField()]
		private int?  _gp_level_4=0;

		[DBField()]
		private int?  _gp_level_5=-1;

		[DBField()]
		private int?  _gp_level_6=-1;

		[DBField()]
		private int?  _gp_level_7=-1;

		[DBField()]
		private int?  _gp_level_8=-1;

		[DBField()]
		private int?  _gp_level_9=-1;


		public virtual int? GpCode
		{
			get
			{
                CanReadProperty("GpCode", true);
				return _gp_code;
			}
			set
			{
                CanWriteProperty("GpCode", true);
				if ( _gp_code != value )
				{
					_gp_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string GpTitle
		{
			get
			{
                CanReadProperty("GpTitle", true);
				return _gp_title;
			}
			set
			{
                CanWriteProperty("GpTitle", true);
				if ( _gp_title != value )
				{
					_gp_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string GpCargo
		{
			get
			{
                CanReadProperty("GpCargo", true);
				return _gp_cargo;
			}
			set
			{
                CanWriteProperty("GpCargo", true);
				if ( _gp_cargo != value )
				{
					_gp_cargo = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? GpCreatedDate
		{
			get
			{
                CanReadProperty("GpCreatedDate", true);
				return _gp_created_date;
			}
			set
			{
                CanWriteProperty("GpCreatedDate", true);
				if ( _gp_created_date != value )
				{
					_gp_created_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string GpCreatedBy
		{
			get
			{
                CanReadProperty("GpCreatedBy", true);
				return _gp_created_by;
			}
			set
			{
                CanWriteProperty("GpCreatedBy", true);
				if ( _gp_created_by != value )
				{
					_gp_created_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? GpModifiedDate
		{
			get
			{
                CanReadProperty("GpModifiedDate", true);
				return _gp_modified_date;
			}
			set
			{
                CanWriteProperty("GpModifiedDate", true);
				if ( _gp_modified_date != value )
				{
					_gp_modified_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string GpModifiedBy
		{
			get
			{
                CanReadProperty("GpModifiedBy", true);
				return _gp_modified_by;
			}
			set
			{
                CanWriteProperty("GpModifiedBy", true);
				if ( _gp_modified_by != value )
				{
					_gp_modified_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel1
		{
			get
			{
                CanReadProperty("GpLevel1", true);
				return _gp_level_1;
			}
			set
			{
                CanWriteProperty("GpLevel1", true);
				if ( _gp_level_1 != value )
				{
					_gp_level_1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel2
		{
			get
			{
                CanReadProperty("GpLevel2", true);
				return _gp_level_2;
			}
			set
			{
                CanWriteProperty("GpLevel2", true);
				if ( _gp_level_2 != value )
				{
					_gp_level_2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel3
		{
			get
			{
                CanReadProperty("GpLevel3", true);
				return _gp_level_3;
			}
			set
			{
                CanWriteProperty("GpLevel3", true);
				if ( _gp_level_3 != value )
				{
					_gp_level_3 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel4
		{
			get
			{
                CanReadProperty("GpLevel4", true);
				return _gp_level_4;
			}
			set
			{
                CanWriteProperty("GpLevel4", true);
				if ( _gp_level_4 != value )
				{
					_gp_level_4 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel5
		{
			get
			{
                CanReadProperty("GpLevel5", true);
				return _gp_level_5;
			}
			set
			{
                CanWriteProperty("GpLevel5", true);
				if ( _gp_level_5 != value )
				{
					_gp_level_5 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel6
		{
			get
			{
                CanReadProperty("GpLevel6", true);
				return _gp_level_6;
			}
			set
			{
                CanWriteProperty("GpLevel6", true);
				if ( _gp_level_6 != value )
				{
					_gp_level_6 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel7
		{
			get
			{
                CanReadProperty("GpLevel7", true);
				return _gp_level_7;
			}
			set
			{
                CanWriteProperty("GpLevel7", true);
				if ( _gp_level_7 != value )
				{
					_gp_level_7 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel8
		{
			get
			{
                CanReadProperty("GpLevel8", true);
				return _gp_level_8;
			}
			set
			{
                CanWriteProperty("GpLevel8", true);
				if ( _gp_level_8 != value )
				{
					_gp_level_8 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? GpLevel9
		{
			get
			{
                CanReadProperty("GpLevel9", true);
				return _gp_level_9;
			}
			set
			{
                CanWriteProperty("GpLevel9", true);
				if ( _gp_level_9 != value )
				{
					_gp_level_9 = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _gp_code );
		}
		#endregion

		#region Factory Methods
		public static UserGroupTest NewUserGroupTest(  )
		{
			return Create();
		}

		public static UserGroupTest[] GetAllUserGroupTest(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = @"SELECT user_groups.gp_code,   
                                             user_groups.gp_title,   
                                             user_groups.gp_cargo,   
                                             user_groups.gp_created_date,   
                                             user_groups.gp_created_by,   
                                             user_groups.gp_modified_date,   
                                             user_groups.gp_modified_by,   
                                             user_groups.gp_level_1,   
                                             user_groups.gp_level_2,   
                                             user_groups.gp_level_3,   
                                             user_groups.gp_level_4,   
                                             user_groups.gp_level_5,   
                                             user_groups.gp_level_6,   
                                             user_groups.gp_level_7,   
                                             user_groups.gp_level_8,   
                                             user_groups.gp_level_9  
                                        FROM user_groups  ";

					List<UserGroupTest> _list = new List<UserGroupTest>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserGroupTest instance = new UserGroupTest();
                            instance._gp_code = GetValueFromReader<Int32?>(dr,0);
                            instance._gp_title = GetValueFromReader<String>(dr,1);
                            instance._gp_cargo = GetValueFromReader<String>(dr,2);
                            instance._gp_created_date = GetValueFromReader<DateTime?>(dr,3);
                            instance._gp_created_by = GetValueFromReader<String>(dr,4);

                            instance._gp_modified_date = GetValueFromReader<DateTime?>(dr,5);
                            instance._gp_modified_by = GetValueFromReader<String>(dr,6);
                            instance._gp_level_1 = GetValueFromReader<Int32?>(dr,7);
                            instance._gp_level_2 = GetValueFromReader<Int32?>(dr,8);
                            instance._gp_level_3 = GetValueFromReader<Int32?>(dr,9);

                            instance._gp_level_4 = GetValueFromReader<Int32?>(dr,10);
                            instance._gp_level_5 = GetValueFromReader<Int32?>(dr,11);
                            instance._gp_level_6 = GetValueFromReader<Int32?>(dr,12);
                            instance._gp_level_7 = GetValueFromReader<Int32?>(dr,13);
                            instance._gp_level_8 = GetValueFromReader<Int32?>(dr,14);
                            instance._gp_level_9 = GetValueFromReader<Int32?>(dr,15);

							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
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
				if (GenerateUpdateCommandText(cm, "user_groups", ref pList))
				{
					cm.CommandText += " WHERE  user_groups.gp_code = @gp_code ";

					pList.Add(cm, "gp_code", GetInitialValue("_gp_code"));
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
				if (GenerateInsertCommandText(cm, "user_groups", pList))
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
					pList.Add(cm,"gp_code", GetInitialValue("_gp_code"));
						cm.CommandText = "DELETE FROM user_groups WHERE " +
						"user_groups.gp_code = @gp_code ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? gp_code )
		{
			_gp_code = gp_code;
		}
	}
}
