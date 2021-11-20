using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("road_name", "_road_name", "road")]
	[MapInfo("rt_id", "_rt_id", "road_type")]
	[MapInfo("rt_name", "_rt_name", "road_type")]
	[MapInfo("rs_id", "_rs_id", "road_suffix")]
	[MapInfo("rs_name", "_rs_name", "road_suffix")]
	[MapInfo("sl_id", "_sl_id", "suburblocality")]
	[MapInfo("sl_name", "_sl_name", "suburblocality")]
	[MapInfo("tc_id", "_tc_id", "towncity")]
	[MapInfo("tc_name", "_tc_name", "towncity")]
	[System.Serializable()]

	public class RoadList : Entity<RoadList>
	{
		#region Business Methods
		[DBField()]
		private string  _road_name;

		[DBField()]
		private int?  _rt_id;

		[DBField()]
		private string  _rt_name;

		[DBField()]
		private int?  _rs_id;

		[DBField()]
		private string  _rs_name;

		[DBField()]
		private int?  _sl_id;

		[DBField()]
		private string  _sl_name;

		[DBField()]
		private int?  _tc_id;

		[DBField()]
		private string  _tc_name;

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

		public virtual int? RtId
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

		public virtual string RtName
		{
			get
			{
                CanReadProperty("RtName", true);
				return _rt_name;
			}
			set
			{
                CanWriteProperty("RtName", true);
				if ( _rt_name != value )
				{
					_rt_name = value;
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

		public virtual int? SlId
		{
			get
			{
                CanReadProperty("SlId", true);
				return _sl_id;
			}
			set
			{
                CanWriteProperty("SlId", true);
				if ( _sl_id != value )
				{
					_sl_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SlName
		{
			get
			{
                CanReadProperty("SlName", true);
				return _sl_name;
			}
			set
			{
                CanWriteProperty("SlName", true);
				if ( _sl_name != value )
				{
					_sl_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? TcId
		{
			get
			{
                CanReadProperty("TcId", true);
				return _tc_id;
			}
			set
			{
                CanWriteProperty("TcId", true);
				if ( _tc_id != value )
				{
					_tc_id = value;
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

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        List<RoadList> List = new List<RoadList>();

		public static RoadList NewRoadList(  )
		{
			return Create();
		}

		public static List<RoadList> GetAllRoadList(  )
		{
			return Fetch().List;
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
                    cm.CommandText = " SELECT DISTINCT"
                                   +        " road_name,"
                                   +        " road_type.rt_id,"
                                   +        " rt_name,"
                                   +        " road_suffix.rs_id,"
                                   +        " rs_name,"
                                   +        " suburblocality.sl_id,"
                                   +        " sl_name,"
                                   +        " towncity.tc_id,"
                                   +        " tc_name"
                                   +   " FROM road"
                                   +            " LEFT OUTER JOIN road_type " 
                                   +                  "ON (road.rt_id = road_type.rt_id)"
                                   +            " LEFT OUTER JOIN road_suffix " 
                                   +                  "ON (road.rs_id = road_suffix.rs_id)"
                                   +            " LEFT OUTER JOIN road_suburb " 
                                   +                  "ON (road.road_id = road_suburb.road_id)"
                                   +            " LEFT OUTER JOIN suburblocality " 
                                   +                  "ON (road_suburb.sl_id = suburblocality.sl_id)"
                                   +            " LEFT OUTER JOIN town_road " 
                                   +                  "ON (road.road_id = town_road.road_id)"
                                   +            " LEFT OUTER JOIN towncity " 
                                   +                  "ON (town_road.tc_id = towncity.tc_id)";
                    ParameterCollection pList = new ParameterCollection();

					List<RoadList> _list = new List<RoadList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RoadList instance = new RoadList();

                            instance._road_name = dr.GetString(0);//!GetValueFromReader<string>(dr,0);
                            instance._rt_id = dr.GetInt32(1);//!GetValueFromReader<int?>(dr,1);
                            instance._rt_name = dr.GetString(2);//!GetValueFromReader<string>(dr,2);
                            instance._rs_id = dr.GetInt32(3);//!GetValueFromReader<int?>(dr,3);
                            instance._rs_name = dr.GetString(4);//!GetValueFromReader<string>(dr,4);
                            instance._sl_id = dr.GetInt32(5);//!GetValueFromReader<int?>(dr,5);
                            instance._sl_name = dr.GetString(6);//!GetValueFromReader<string>(dr,6);
                            instance._tc_id = dr.GetInt32(7);//!GetValueFromReader<int?>(dr,7);
                            instance._tc_name = dr.GetString(8);//!GetValueFromReader<string>(dr,8);
 
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
                        foreach (RoadList item in _list)
                        {
                            List.Add(item);
                        }
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
