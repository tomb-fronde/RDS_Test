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
    [MapInfo("tc_id", "_tc_id", "")]
    [MapInfo("region_id", "_region_id", "")]
    [MapInfo("tc_name", "_tc_name", "")]
    [MapInfo("sl_id", "_sl_id", "")]
    [MapInfo("sl_name", "_sl_name", "")]
    [System.Serializable()]

    public class TownSuburbMap : Entity<TownSuburbMap>
    {
        #region Business Methods
        [DBField()]
        private int? _tc_id;

        [DBField()]
        private int? _region_id;

        [DBField()]
        private string _tc_name;

        [DBField()]
        private int? _sl_id;

        [DBField()]
        private string _sl_name;


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

        public virtual int? RegionId
        {
            get
            {
                CanReadProperty("RegionId", true);
                return _region_id;
            }
            set
            {
                CanWriteProperty("RegionId", true);
                if (_region_id != value)
                {
                    _region_id = value;
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
                if (_tc_name != value)
                {
                    _tc_name = value;
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
            return string.Format("{0}/{1}", _tc_id, _sl_id);
        }
        #endregion

        #region Factory Methods
        public static TownSuburbMap NewTownSuburbMap()
        {
            return Create();
        }

        public static TownSuburbMap[] GetAllTownSuburbMap()
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
                    cm.CommandText = "rd.sp_gettownsuburbmap";

                    List<TownSuburbMap> _list = new List<TownSuburbMap>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            TownSuburbMap instance = new TownSuburbMap();
                            instance._tc_id = GetValueFromReader<Int32?>(dr,0);
                            instance._region_id = GetValueFromReader<Int32?>(dr,1);
                            instance._tc_name = GetValueFromReader<String>(dr,2);
                            instance._sl_id = GetValueFromReader<Int32?>(dr,3);
                            instance._sl_name = GetValueFromReader<String>(dr,4);
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
        private void CreateEntity(int? tc_id, int? sl_id)
        {
            _tc_id = tc_id;
            _sl_id = sl_id;
        }
    }
}
