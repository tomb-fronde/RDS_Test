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
	[MapInfo("road_name", "_road_name", "")]
	[MapInfo("rt_id", "_rt_id", "")]
	[MapInfo("tc_name", "_tc_name", "")]
	[MapInfo("del_points", "_del_points", "")]
	[System.Serializable()]

	public class PsRoadnameTown : Entity<PsRoadnameTown>
	{
		#region Business Methods
		[DBField()]
		private string  _road_name;

		[DBField()]
		private string  _rt_id;

		[DBField()]
		private string  _tc_name;

		[DBField()]
		private int?  _del_points;


		public virtual string RoadName
		{
			get
			{
                CanReadProperty("RoadName", true);
				return _road_name;
			}
			set
			{
                CanWriteProperty("RoadName", true);
				if ( _road_name != value )
				{
					_road_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RtId
		{
			get
			{
                CanReadProperty("RtId", true);
				return _rt_id;
			}
			set
			{
                CanWriteProperty("RtId", true);
				if ( _rt_id != value )
				{
					_rt_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string TcName
		{
			get
			{
                CanReadProperty("TcName", true);
				return _tc_name;
			}
			set
			{
                CanWriteProperty("TcName", true);
				if ( _tc_name != value )
				{
					_tc_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? DelPoints
		{
			get
			{
                CanReadProperty("DelPoints", true);
				return _del_points;
			}
			set
			{
                CanWriteProperty("DelPoints", true);
				if ( _del_points != value )
				{
					_del_points = value;
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
		public static PsRoadnameTown NewPsRoadnameTown( int? town_id )
		{
			return Create(town_id);
		}

		public static PsRoadnameTown[] GetAllPsRoadnameTown( int? town_id )
		{
			return Fetch(town_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? town_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_getroads_town";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "town_id", town_id);

					List<PsRoadnameTown> _list = new List<PsRoadnameTown>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PsRoadnameTown instance = new PsRoadnameTown();
                            instance._road_name = GetValueFromReader<string>(dr,0);
                            instance._rt_id = GetValueFromReader<string>(dr,1);
                            instance._tc_name = GetValueFromReader<string>(dr,2);
                            instance._del_points = GetValueFromReader<int?>(dr,3);
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
