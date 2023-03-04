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
    [MapInfo("tc_id", "_tc_id", "")]
    [System.Serializable()]

    public class RoadMapV2 : Entity<RoadMapV2>
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
            return string.Format("{0}", _road_id);
        }
        #endregion

        #region Factory Methods
        List<RoadMapV2> List = new List<RoadMapV2>();

        public static RoadMapV2 NewRoadMapV2()
        {
            return Create();
        }

        public static List<RoadMapV2> GetAllRoadMapV2()
        {
            return Fetch().List;
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
                    cm.CommandText = "rd.sp_getroadmap_v2";

                    List<RoadMapV2> _list = new List<RoadMapV2>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RoadMapV2 instance = new RoadMapV2();

                            instance._road_id = dr.GetInt32(0);//!GetValueFromReader<Int32?>(dr,0);
                            instance._rt_id = dr.GetInt32(1);//!GetValueFromReader<Int32?>(dr,1);
                            instance._road_name = dr.GetString(2);//!GetValueFromReader<String>(dr,2);
                            instance._rt_name = dr.GetString(3);//!GetValueFromReader<String>(dr,3);
                            instance._rs_id = dr.GetInt32(4);//!GetValueFromReader<Int32?>(dr,4);
                            instance._rs_name = dr.GetString(5);//!GetValueFromReader<String>(dr,5);
                            instance._tc_id = dr.GetInt32(6);//!GetValueFromReader<Int32?>(dr,6);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }

                        foreach (RoadMapV2 item in _list)
                        {
                            List.Add(item);
                        }
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
