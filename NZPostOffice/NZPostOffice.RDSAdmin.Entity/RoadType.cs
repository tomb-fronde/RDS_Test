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
	[MapInfo("rt_abbrev", "_rt_abbrev", "road_type")]
	[MapInfo("rt_name", "_rt_name", "road_type")]
	[MapInfo("rt_id", "_rt_id", "road_type",true)]
	[System.Serializable()]

	public class RoadType : Entity<RoadType>
	{
		#region Business Methods
		[DBField()]
		private string  _rt_abbrev;

		[DBField()]
		private string  _rt_name;

		[DBField()]
		private int?  _rt_id;


		public virtual string RtAbbrev
		{
			get
			{
				CanReadProperty(true);
				return _rt_abbrev;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rt_abbrev != value )
				{
					_rt_abbrev = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RtName
		{
			get
			{
				CanReadProperty(true);
				return _rt_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rt_name != value )
				{
					_rt_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RtId
		{
			get
			{
				CanReadProperty(true);
				return _rt_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rt_id != value )
				{
					_rt_id = value;
					PropertyHasChanged();
				}
			}
		}
		private RoadType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rt_id );
		}
		#endregion

		#region Factory Methods
        public static RoadType NewRoadType(int? rt_id)
		{
            return Create(rt_id);
		}

		public static RoadType[] GetAllRoadType(  )
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
					GenerateSelectCommandText(cm, "road_type");

					List<RoadType> list = new List<RoadType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RoadType instance = new RoadType();
							instance.StoreFieldValues(dr, "road_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new RoadType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "road_type", ref pList))
				{
					cm.CommandText += " WHERE  road_type.rt_id = @rt_id ";

					pList.Add(cm, "rt_id", GetInitialValue("_rt_id"));
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
				if (GenerateInsertCommandText(cm, "road_type", pList))
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
					pList.Add(cm,"rt_id", GetInitialValue("_rt_id"));
						cm.CommandText = "DELETE FROM road_type WHERE " +
						"road_type.rt_id = @rt_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rt_id )
		{
			_rt_id = rt_id;
		}
	}
}
