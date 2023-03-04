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
    [MapInfo("rs_id", "_rs_id", "")]
    [MapInfo("rs_name", "_rs_name", "")]
    [System.Serializable()]

    public class RoadMap : Entity<RoadMap>
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
        private int? _rs_id;

        [DBField()]
        private string _rs_name;


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
                if (_rs_id != value)
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
                if (_rs_name != value)
                {
                    _rs_name = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _road_id);
        }
        #endregion

        #region Factory Methods
        public static RoadMap NewRoadMap()
        {
            return Create();
        }

        public static RoadMap[] GetAllRoadMap()
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
                    cm.CommandText = "rd.sp_getroadmap";

                    List<RoadMap> _list = new List<RoadMap>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RoadMap instance = new RoadMap();
                            instance._road_id = GetValueFromReader<Int32?>(dr,0);
                            instance._rt_id = GetValueFromReader<Int32?>(dr,1);
                            instance._road_name = GetValueFromReader<String>(dr,2);
                            instance._rt_name = GetValueFromReader<String>(dr,3);
                            instance._rs_id = GetValueFromReader<Int32?>(dr,4);
                            instance._rs_name = GetValueFromReader<String>(dr,5);
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
        private void CreateEntity(int? road_id)
        {
            _road_id = road_id;
        }
    }
}
