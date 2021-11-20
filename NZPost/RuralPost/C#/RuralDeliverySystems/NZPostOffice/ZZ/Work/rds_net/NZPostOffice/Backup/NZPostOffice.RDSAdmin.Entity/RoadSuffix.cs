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
	[MapInfo("rs_abbrev", "_rs_abbrev", "road_suffix")]
	[MapInfo("rs_name", "_rs_name", "road_suffix")]
	[MapInfo("rs_id", "_rs_id", "road_suffix")]
	[System.Serializable()]

	public class RoadSuffix : Entity<RoadSuffix>
	{
		#region Business Methods
		[DBField()]
		private string  _rs_abbrev;

		[DBField()]
		private string  _rs_name;

		[DBField()]
		private int?  _rs_id;


		public virtual string RsAbbrev
		{
			get
			{
				CanReadProperty(true);
				return _rs_abbrev;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rs_abbrev != value )
				{
					_rs_abbrev = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RsName
		{
			get
			{
				CanReadProperty(true);
				return _rs_name;
			}
			set
			{
				CanWriteProperty(true);
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
				CanReadProperty(true);
				return _rs_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rs_id != value )
				{
					_rs_id = value;
					PropertyHasChanged();
				}
			}
		}
		private RoadSuffix[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rs_id );
		}
		#endregion

		#region Factory Methods
        public static RoadSuffix NewRoadSuffix(int? rs_id)
		{
            return Create(rs_id);
		}

		public static RoadSuffix[] GetAllRoadSuffix(  )
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
					ParameterCollection pList = new ParameterCollection();
					GenerateSelectCommandText(cm, "road_suffix");

					List<RoadSuffix> list = new List<RoadSuffix>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RoadSuffix instance = new RoadSuffix();
							instance.StoreFieldValues(dr, "road_suffix");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new RoadSuffix[list.Count];
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
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
				ParameterCollection pList = new ParameterCollection();
                cm.CommandText = "select max(rs_id) from road_suffix";                
                using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                {
                    while (dr.Read())
                    {
                        _rs_id = dr.GetInt32(0) + 1;
                    }
                }                
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
