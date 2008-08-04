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
	[MapInfo("rs_name", "_rs_name", "road_suffix")]
	[MapInfo("rs_id", "_rs_id", "road_suffix")]
	[MapInfo("rs_abbrev", "_rs_abbrev", "road_suffix")]
	[System.Serializable()]

	public class DddwRoadSuffix : Entity<DddwRoadSuffix>
	{
		#region Business Methods
		[DBField()]
		private string  _rs_name;

		[DBField()]
		private int?  _rs_id;

		[DBField()]
		private string  _rs_abbrev;


		public virtual string RsName
		{
			get
			{
                CanReadProperty("RsName", true);
				return _rs_name;
			}
			set
			{
                CanWriteProperty("RsName", true);
				if ( _rs_name != value )
				{
					_rs_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RsId
		{
			get
			{
                CanReadProperty("RsId", true);
				return _rs_id;
			}
			set
			{
                CanWriteProperty("RsId", true);
				if ( _rs_id != value )
				{
					_rs_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RsAbbrev
		{
			get
			{
                CanReadProperty("RsAbbrev", true);
				return _rs_abbrev;
			}
			set
			{
                CanWriteProperty("RsAbbrev", true);
				if ( _rs_abbrev != value )
				{
					_rs_abbrev = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rs_id );
		}
		#endregion

		#region Factory Methods
		public static DddwRoadSuffix NewDddwRoadSuffix(  )
		{
			return Create();
		}

		public static DddwRoadSuffix[] GetAllDddwRoadSuffix(  )
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
					cm.CommandText = "SELECT road_suffix.rs_name,  road_suffix.rs_id,  road_suffix.rs_abbrev  FROM road_suffix  UNION ALL  SELECT ''  as rs_name,  NULL as rs_id,  NULL as rs_abbrev  FROM DUMMY  ";
                    cm.CommandText += " order by road_suffix.rs_name ";//! added sorting
					ParameterCollection pList = new ParameterCollection();

					List<DddwRoadSuffix> _list = new List<DddwRoadSuffix>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwRoadSuffix instance = new DddwRoadSuffix();
                            instance._rs_name = dr.GetString(0);
                            instance._rs_id = dr.GetInt32(1);
                            instance._rs_abbrev = dr.GetString(2);

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
				if (GenerateUpdateCommandText(cm, "road_suffix", ref pList))
				{
					cm.CommandText += " WHERE  road_suffix.rs_id = @rs_id ";

					pList.Add(cm, "rs_id", GetInitialValue("_rs_id"));
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
				if (GenerateInsertCommandText(cm, "road_suffix", pList))
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
					pList.Add(cm,"rs_id", GetInitialValue("_rs_id"));
						cm.CommandText = "DELETE FROM road_suffix WHERE " +
						"road_suffix.rs_id = @rs_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rs_id )
		{
			_rs_id = rs_id;
		}
	}
}
