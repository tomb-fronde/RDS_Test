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
    [MapInfo("region_id", "_region_id", "outlet")]
    [MapInfo("outlet_id", "_outlet_id", "outlet")]
    [MapInfo("o_name", "_o_name", "outlet")]
    [MapInfo("outlet_picklist", "_outlet_picklist", "outlet")]
    [MapInfo("ct_key", "_ct_key", "contract_type")]
    [MapInfo("rg_code", "_rg_code", "renewal_group")]
    [MapInfo("sf_key", "_sf_key", "standard_frequency")]
    [System.Serializable()]

    public class ReportRcmCriteria : Entity<ReportRcmCriteria>
    {
        #region Business Methods
        [DBField()]
        private int? _region_id;

        [DBField()]
        private int? _outlet_id;

        [DBField()]
        private string _o_name = "<All Outlets>";

        [DBField()]
        private int? _outlet_picklist;

        [DBField()]
        private int? _ct_key;

        [DBField()]
        private int? _rg_code;

        [DBField()]
        private int? _sf_key;


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

        public virtual int? OutletId
        {
            get
            {
                CanReadProperty("OutletId", true);
                return _outlet_id;
            }
            set
            {
                CanWriteProperty("OutletId", true);
                if (_outlet_id != value)
                {
                    _outlet_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OName
        {
            get
            {
                CanReadProperty("OName", true);
                return _o_name;
            }
            set
            {
                CanWriteProperty("OName", true);
                if (_o_name != value)
                {
                    _o_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? OutletPicklist
        {
            get
            {
                CanReadProperty("OutletPicklist", true);
                return _outlet_picklist;
            }
            set
            {
                CanWriteProperty("OutletPicklist", true);
                if (_outlet_picklist != value)
                {
                    _outlet_picklist = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CtKey
        {
            get
            {
                CanReadProperty("CtKey", true);
                return _ct_key;
            }
            set
            {
                CanWriteProperty("CtKey", true);
                if (_ct_key != value)
                {
                    _ct_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RgCode
        {
            get
            {
                CanReadProperty("RgCode", true);
                return _rg_code;
            }
            set
            {
                CanWriteProperty("RgCode", true);
                if (_rg_code != value)
                {
                    _rg_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? SfKey
        {
            get
            {
                CanReadProperty("SfKey", true);
                return _sf_key;
            }
            set
            {
                CanWriteProperty("SfKey", true);
                if (_sf_key != value)
                {
                    _sf_key = value;
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
        public static ReportRcmCriteria NewReportRcmCriteria()
        {
            return Create();
        }

        public static ReportRcmCriteria[] GetAllReportRcmCriteria()
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
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT  outlet.region_id ,"
                        + " outlet.outlet_id ,"
                        + " outlet.o_name ,"
                        + " 0 outlet_picklist,"
                        + " contract_type.ct_key ,"
                        + " renewal_group.rg_code ,"
                        + " standard_frequency.sf_key"
                        + " FROM outlet ,"
                        + " contract_type ,"
                        + " renewal_group ,"
                        + " standard_frequency";

                    ParameterCollection pList = new ParameterCollection();

                    List<ReportRcmCriteria> _list = new List<ReportRcmCriteria>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ReportRcmCriteria instance = new ReportRcmCriteria();
                            instance._region_id = GetValueFromReader<int?>(dr, 0);
                            instance._outlet_id = GetValueFromReader<int?>(dr, 1);
                            instance._o_name = GetValueFromReader<string>(dr, 2);
                            instance._outlet_picklist = GetValueFromReader<int?>(dr, 3);
                            instance._ct_key = GetValueFromReader<int?>(dr, 4);
                            instance._rg_code = GetValueFromReader<int?>(dr, 5);
                            instance._sf_key = GetValueFromReader<int?>(dr, 6);
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
        private void CreateEntity()
        {
        }
    }
}
