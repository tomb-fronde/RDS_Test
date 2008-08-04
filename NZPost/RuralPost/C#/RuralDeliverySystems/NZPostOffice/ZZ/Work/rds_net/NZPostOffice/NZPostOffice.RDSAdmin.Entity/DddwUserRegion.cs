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
	[MapInfo("rgn_name", "_rgn_name", "region")]
	[MapInfo("region_id", "_region_id", "region")]
	[System.Serializable()]

	public class DUserRegion : Entity<DUserRegion>
	{
		#region Business Methods
		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private int?  _region_id;


		public virtual string RgnName
		{
			get
			{
				CanReadProperty(true);
				return _rgn_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionId
		{
			get
			{
				CanReadProperty(true);
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
		private DUserRegion[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _region_id );
		}
		#endregion

		#region Factory Methods
		public static DUserRegion NewUserRegion(  )
		{
			return Create();
		}

		public static DUserRegion[] GetAllUserRegion(  )
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT region.rgn_name,  region.region_id  FROM   region";//  union  SELECT 'National' as dummy,  '-1' as dummy2  FROM dummy  ";
					ParameterCollection pList = new ParameterCollection();

					List<DUserRegion> list = new List<DUserRegion>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DUserRegion instance = new DUserRegion();
							instance.StoreFieldValues(dr, "region");
							instance.StoreFieldValues(dr, "as");
							instance.StoreFieldValues(dr, "as");
							instance.StoreFieldValues(dr, "FROM");
							instance.MarkOld();
							list.Add(instance);
						}
                        DUserRegion instance2 = new DUserRegion();
                        instance2.RegionId = -1;
                        instance2.RgnName = "National";
                        instance2.MarkOld();
                        list.Add(instance2);
						dataList = new DUserRegion[list.Count];
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
				if (GenerateUpdateCommandText(cm, "region", ref pList))
				{
					cm.CommandText += " WHERE  region.rgn_name = @rgn_name ";

					pList.Add(cm, "rgn_name", GetInitialValue("_rgn_name"));
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
				if (GenerateInsertCommandText(cm, "region", pList))
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
					pList.Add(cm,"region_id", GetInitialValue("_region_id"));
						cm.CommandText = "DELETE FROM region WHERE " +
						"region.region_id = @region_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? region_id )
		{
			_region_id = region_id;
		}
	}
}
