using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("region_id", "_regionid", "region")]
	[MapInfo("rgn_name", "_rgn_name", "region")]
	[System.Serializable()]

	public class OutletReportCriteria : Entity<OutletReportCriteria>
	{
		#region Business Methods
		[DBField()]
		private int?  _regionid;

		[DBField()]
		private string  _rgn_name;


		public virtual int? Regionid
		{
			get
			{
                CanReadProperty("Regionid", true);
				return _regionid;
			}
			set
			{
                CanWriteProperty("Regionid", true);
				if ( _regionid != value )
				{
					_regionid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnName
		{
			get
			{
                CanReadProperty("RgnName", true);
				return _rgn_name;
			}
			set
			{
                CanWriteProperty("RgnName", true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _regionid );
		}
		#endregion

		#region Factory Methods
		public static OutletReportCriteria NewOutletReportCriteria(  )
		{
			return Create();
		}

		public static OutletReportCriteria[] GetAllOutletReportCriteria(  )
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
                    cm.CommandText = " SELECT region.region_id,"
                                   + " region.rgn_name"
                                   + " FROM region"
                                   + " ORDER BY region.region_id ASC ";
					List<OutletReportCriteria> _list = new List<OutletReportCriteria>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OutletReportCriteria instance = new OutletReportCriteria();
                            instance._regionid = GetValueFromReader<int?>(dr,0);
                            instance._rgn_name = GetValueFromReader<string>(dr,1);
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
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
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
					pList.Add(cm,"region_id", GetInitialValue("_regionid"));
						cm.CommandText = "DELETE FROM region WHERE " +
						"region.region_id = @region_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? regionid )
		{
			_regionid = regionid;
		}
	}
}
