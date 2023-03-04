using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("sync_no", "_sync_no", "")]
	[MapInfo("sync_name", "_sync_name", "")]
	[MapInfo("sync_value", "_sync_value", "")]
	[System.Serializable()]

	public class Sync : Entity<Sync>
	{
		#region Business Methods
		[DBField()]
		private int?  _sync_no;

		[DBField()]
		private string  _sync_name;

		[DBField()]
		private decimal?  _sync_value;

		public virtual int? SyncNo
		{
			get
			{
                CanReadProperty("SyncNo", true);
				return _sync_no;
			}
			set
			{
                CanWriteProperty("SyncNo", true);
				if ( _sync_no != value )
				{
					_sync_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SyncName
		{
			get
			{
				CanReadProperty("SyncName",true);
				return _sync_name;
			}
			set
			{
				CanWriteProperty("SyncName",true);
				if ( _sync_name != value )
				{
					_sync_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? SyncValue
		{
			get
			{
                CanReadProperty("SyncValue", true);
				return _sync_value;
			}
			set
			{
				CanWriteProperty("SyncValue",true);
				if ( _sync_value != value )
				{
					_sync_value = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static Sync NewSync( string a_sync_name )
		{
			return Create(a_sync_name);
		}

		public static Sync[] GetAllSync( string a_sync_name )
		{
			return Fetch(a_sync_name).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( string a_sync_name )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.sp_sync";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "a_sync_name", a_sync_name);

					List<Sync> _list = new List<Sync>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Sync instance = new Sync();
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
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
