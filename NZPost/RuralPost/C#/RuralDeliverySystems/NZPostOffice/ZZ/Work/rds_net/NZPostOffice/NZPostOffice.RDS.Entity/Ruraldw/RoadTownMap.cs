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
    [MapInfo("tc_id", "_tc_id", "")]
    [System.Serializable()]

    public class RoadTownMap : Entity<RoadTownMap>
    {
        #region Business Methods
        [DBField()]
        private int? _road_id;

        [DBField()]
        private int? _rt_id;

        [DBField()]
        private int? _tc_id;


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
                if (_tc_id != value)
                {
                    _tc_id = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _road_id, _tc_id);
        }
        #endregion

        #region Factory Methods
        public static RoadTownMap NewRoadTownMap()
        {
            return Create();
        }

        public static RoadTownMap[] GetAllRoadTownMap()
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
                    cm.CommandText = "rd.sp_getroadtownmap_v2";

                    List<RoadTownMap> _list = new List<RoadTownMap>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RoadTownMap instance = new RoadTownMap();
                            instance._road_id = GetValueFromReader<Int32?>(dr,0);
                            instance._rt_id = GetValueFromReader<Int32?>(dr,1);
                            instance._tc_id = GetValueFromReader<Int32?>(dr,2);
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
        private void CreateEntity(int? road_id, int? tc_id)
        {
            _road_id = road_id;
            _tc_id = tc_id;
        }
    }
}
