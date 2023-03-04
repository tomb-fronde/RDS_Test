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
    [MapInfo("road_id", "_road_id", "")]
    [MapInfo("rt_id", "_rt_id", "")]
    [MapInfo("road_name", "_road_name", "")]
    [MapInfo("rt_name", "_rt_name", "")]
    [MapInfo("sl_id", "_sl_id", "")]
    [MapInfo("sl_name", "_sl_name", "")]
    [System.Serializable()]

    public class RoadSuburbMap : Entity<RoadSuburbMap>
    {
        #region Business Methods
        [DBField()]
        private int? _road_id;

        [DBField()]
        private int? _rt_id;

        [DBField()]
        private string _road_name;

        [DBField()]
        private string _rt_name;

        [DBField()]
        private int? _sl_id;

        [DBField()]
        private string _sl_name;


        public virtual int? RoadId
        {
            get
            {
                CanReadProperty("RoadId", true);
                return _road_id;
            }
            set
            {
                CanWriteProperty("RoadId", true);
                if (_road_id != value)
                {
                    _road_id = value;
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
                if (_rt_id != value)
                {
                    _rt_id = value;
                    PropertyHasChanged();
                }
            }
        }

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
                if (_road_name != value)
                {
                    _road_name = value;
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
                if (_rt_name != value)
                {
                    _rt_name = value;
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
                if (_sl_id != value)
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
                if (_sl_name != value)
                {
                    _sl_name = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _road_id, _sl_id);
        }
        #endregion

        #region Factory Methods
        public static RoadSuburbMap NewRoadSuburbMap()
        {
            return Create();
        }

        public static RoadSuburbMap[] GetAllRoadSuburbMap()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "rd.sp_getroadsuburbmap";

                    List<RoadSuburbMap> _list = new List<RoadSuburbMap>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RoadSuburbMap instance = new RoadSuburbMap();
                            instance._road_id = GetValueFromReader<Int32?>(dr,0);
                            instance._rt_id = GetValueFromReader<Int32?>(dr,1);
                            instance._road_name = GetValueFromReader<String>(dr,2);
                            instance._rt_name = GetValueFromReader<String>(dr,3);
                            instance._sl_id = GetValueFromReader<Int32?>(dr,4);
                            instance._sl_name = GetValueFromReader<String>(dr,5);
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
        private void CreateEntity(int? road_id, int? sl_id)
        {
            _road_id = road_id;
            _sl_id = sl_id;
        }
    }
}
