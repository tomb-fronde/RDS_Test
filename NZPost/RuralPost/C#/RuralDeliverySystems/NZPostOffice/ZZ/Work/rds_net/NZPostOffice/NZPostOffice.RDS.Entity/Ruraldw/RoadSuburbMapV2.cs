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
    [MapInfo("road_name", "_road_name", "")]
    [MapInfo("rt_id", "_rt_id", "")]
    [MapInfo("rt_name", "_rt_name", "")]
    [MapInfo("rs_id", "_rt_id2", "")]
    [MapInfo("rs_name", "_rt_name2", "")]
    [MapInfo("sl_id", "_sl_id", "")]
    [MapInfo("sl_name", "_sl_name", "")]
    [System.Serializable()]

    public class RoadSuburbMapV2 : Entity<RoadSuburbMapV2>
    {
        #region Business Methods
        [DBField()]
        private int? _road_id;

        [DBField()]
        private string _road_name;

        [DBField()]
        private int? _rt_id;

        [DBField()]
        private string _rt_name;

        [DBField()]
        private int? _rt_id2;

        [DBField()]
        private string _rt_name2;

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

        public virtual int? RtId2
        {
            get
            {
                CanReadProperty("RtId2", true);
                return _rt_id2;
            }
            set
            {
                CanWriteProperty("RtId2", true);
                if (_rt_id2 != value)
                {
                    _rt_id2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RtName2
        {
            get
            {
                CanReadProperty("RtName2", true);
                return _rt_name2;
            }
            set
            {
                CanWriteProperty("RtName2", true);
                if (_rt_name2 != value)
                {
                    _rt_name2 = value;
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
        public static RoadSuburbMapV2 NewRoadSuburbMapV2()
        {
            return Create();
        }

        public static RoadSuburbMapV2[] GetAllRoadSuburbMapV2()
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
                    cm.CommandText = "rd.sp_getroadsuburbmap_v2";

                    List<RoadSuburbMapV2> _list = new List<RoadSuburbMapV2>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RoadSuburbMapV2 instance = new RoadSuburbMapV2();
                            instance._road_id = GetValueFromReader<Int32?>(dr,0);
                            instance._road_name = GetValueFromReader<String>(dr,1);
                            instance._rt_id = GetValueFromReader<Int32?>(dr,2);
                            instance._rt_name = GetValueFromReader<String>(dr,3);
                            instance._rt_id2 = GetValueFromReader<Int32?>(dr,4);
                            instance._rt_name2 = GetValueFromReader<String>(dr,5);
                            instance._sl_id = GetValueFromReader<Int32?>(dr,6);
                            instance._sl_name = GetValueFromReader<String>(dr,7);
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
