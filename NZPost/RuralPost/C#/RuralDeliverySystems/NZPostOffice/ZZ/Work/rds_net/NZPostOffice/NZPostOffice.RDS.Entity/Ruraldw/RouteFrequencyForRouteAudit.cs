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
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("sf_key", "_sf_key", "")]
    [MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
    [MapInfo("rf_active", "_rf_active", "")]
    [MapInfo("rf_monday", "_rf_monday", "")]
    [MapInfo("rf_tuesday", "_rf_tuesday", "")]
    [MapInfo("rf_wednesday", "_rf_wednesday", "")]
    [MapInfo("rf_thursday", "_rf_thursday", "")]
    [MapInfo("rf_friday", "_rf_friday", "")]
    [MapInfo("rf_saturday", "_rf_saturday", "")]
    [MapInfo("rf_sunday", "_rf_sunday", "")]
    [MapInfo("rf_distance", "_distance", "")]
    [System.Serializable()]

    public class RouteFrequencyForRouteAudit : Entity<RouteFrequencyForRouteAudit>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _sf_key;

        [DBField()]
        private string _rf_delivery_days;

        [DBField()]
        private string _rf_active="Y";

        [DBField()]
        private string _rf_monday="N";

        [DBField()]
        private string _rf_tuesday = "N";

        [DBField()]
        private string _rf_wednesday = "N";

        [DBField()]
        private string _rf_thursday = "N";

        [DBField()]
        private string _rf_friday = "N";

        [DBField()]
        private string _rf_saturday = "N";

        [DBField()]
        private string _rf_sunday = "N";

        [DBField()]
        private decimal? _distance = 0;

        [DBField()]
        private string _inUse;

        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty("ContractNo", true);
                if (_contract_no != value)
                {
                    _contract_no = value;
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

        public virtual string RfDeliveryDays
        {
            get
            {
                CanReadProperty("RfDeliveryDays", true);
                return _rf_delivery_days;
            }
            set
            {
                CanWriteProperty("RfDeliveryDays", true);
                if (_rf_delivery_days != value)
                {
                    _rf_delivery_days = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfActive
        {
            get
            {
                CanReadProperty("RfActive", true);
                return _rf_active;
            }
            set
            {
                CanWriteProperty("RfActive", true);
                if (_rf_active != value)
                {
                    _rf_active = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfMonday
        {
            get
            {
                CanReadProperty("RfMonday", true);
                return _rf_monday;
            }
            set
            {
                CanWriteProperty("RfMonday", true);
                if (_rf_monday != value)
                {
                    _rf_monday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfTuesday
        {
            get
            {
                CanReadProperty("RfTuesday", true);
                return _rf_tuesday;
            }
            set
            {
                CanWriteProperty("RfTuesday", true);
                if (_rf_tuesday != value)
                {
                    _rf_tuesday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfWednesday
        {
            get
            {
                CanReadProperty("RfWednesday", true);
                return _rf_wednesday;
            }
            set
            {
                CanWriteProperty("RfWednesday", true);
                if (_rf_wednesday != value)
                {
                    _rf_wednesday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfThursday
        {
            get
            {
                CanReadProperty("RfThursday", true);
                return _rf_thursday;
            }
            set
            {
                CanWriteProperty("RfThursday", true);
                if (_rf_thursday != value)
                {
                    _rf_thursday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfFriday
        {
            get
            {
                CanReadProperty("RfFriday", true);
                return _rf_friday;
            }
            set
            {
                CanWriteProperty("RfFriday", true);
                if (_rf_friday != value)
                {
                    _rf_friday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfSaturday
        {
            get
            {
                CanReadProperty("RfSaturday", true);
                return _rf_saturday;
            }
            set
            {
                CanWriteProperty("RfSaturday", true);
                if (_rf_saturday != value)
                {
                    _rf_saturday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfSunday
        {
            get
            {
                CanReadProperty("RfSunday", true);
                return _rf_sunday;
            }
            set
            {
                CanWriteProperty("RfSunday", true);
                if (_rf_sunday != value)
                {
                    _rf_sunday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute2
        {
            get
            {
                CanReadProperty("Compute2", true);
                if (InUse == null)
                {
                    return TCompute;//FFreqInuse(_contract_no, _sf_key, _rf_delivery_days);
                }
                else
                    return InUse;
            }
        }
        private string _t_compute;
        public string TCompute
        {
            get 
            {
                return _t_compute;
            }
        }

        public virtual decimal? Distance
        {
            get
            {
                CanReadProperty("Distance", true);
                return _distance;
            }
            set
            {
                CanWriteProperty("Distance", true);
                if (_distance != value)
                {
                    _distance = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string InUse
        {
            get
            {
                CanReadProperty("InUse", true);
                return _inUse;
            }
        }	// needs to implement compute expression manually:
        // compute control name=[calc_deldays]
        //rf_monday + rf_tuesday + rf_wednesday + rf_thursday + rf_friday + rf_saturday + rf_sunday
        public virtual string CalcDeldays
        {
            get
            {
                CanReadProperty("CalcDeldays", true);
                return _rf_monday + _rf_tuesday + _rf_wednesday + _rf_thursday + _rf_friday + _rf_saturday + _rf_sunday;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[calc_numdeldays]
        //if(rf_monday='Y',1,0) + if(rf_tuesday='Y',1,0) + if(rf_wednesday='Y',1,0) + if(rf_thursday='Y',1,0) + if(rf_friday='Y',1,0) + if(rf_saturday='Y',1,0) + if(rf_sunday='Y',1,0)
        public virtual int? CalcNumdeldays
        {
            get
            {
                CanReadProperty("CalcNumdeldays", true);
                return (_rf_monday == "Y" ? 1 : 0) + (_rf_tuesday == "Y" ? 1 : 0) + (_rf_wednesday == "Y" ? 1 : 0) + (_rf_thursday == "Y" ? 1 : 0) + (_rf_friday == "Y" ? 1 : 0) + (_rf_saturday == "Y" ? 1 : 0) + (_rf_sunday == "Y" ? 1 : 0);
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _contract_no, _sf_key, _rf_delivery_days);
        }
        #endregion

        #region Factory Methods
        public static RouteFrequencyForRouteAudit NewRouteFrequencyForRouteAudit(int? in_Contract)
        {
            return Create(in_Contract);
        }

        public static RouteFrequencyForRouteAudit[] GetAllRouteFrequencyForRouteAudit(int? in_Contract)
        {
            return Fetch(in_Contract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    cm.CommandText = "rd.sp_getroutefrequency2001";
                    List<RouteFrequencyForRouteAudit> _list = new List<RouteFrequencyForRouteAudit>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RouteFrequencyForRouteAudit instance = new RouteFrequencyForRouteAudit();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._sf_key = GetValueFromReader<Int32?>(dr,1);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr,2);
                            instance._rf_active = GetValueFromReader<String>(dr,3);
                            instance._rf_monday = GetValueFromReader<String>(dr,4);
                            instance._rf_tuesday = GetValueFromReader<String>(dr,5);
                            instance._rf_wednesday = GetValueFromReader<String>(dr,6);
                            instance._rf_thursday = GetValueFromReader<String>(dr,7);
                            instance._rf_friday = GetValueFromReader<String>(dr,8);
                            instance._rf_saturday = GetValueFromReader<String>(dr,9);
                            instance._rf_sunday = GetValueFromReader<String>(dr,10);
                            instance._distance = GetValueFromReader<Decimal?>(dr,11);
                            instance._t_compute = GetValueFromReader<String>(dr, 12);
                            _inUse = in_Contract.ToString(); instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        [ServerMethod]
        private string FFreqInuse(int? ai_contract, int? ai_sfkey, string as_deldays)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                int iCount = 0;
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ai_contract", ai_contract);
                    pList.Add(cm, "ai_sfkey", ai_sfkey);
                    pList.Add(cm, "as_deldays", as_deldays);
                    cm.CommandText = "SELECT count (*) FROM frequency_distances fd, contract	c, contract_renewals cr WHERE" +
                        " fd.contract_no				= :ai_contract			AND " +
                        " fd.sf_key					= :ai_sfkey				AND " +
                        " fd.rf_delivery_days		= :as_deldays			AND " +
                        " fd.contract_no				= c.contract_no		AND " +
                        " c.con_active_sequence	= cr.contract_seq_number;";
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            iCount = GetValueFromReader<Int32>(dr,0);
                        }
                    }
                    if (iCount > 0)
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no, int? sf_key, string rf_delivery_days)
        {
            _contract_no = contract_no;
            _sf_key = sf_key;
            _rf_delivery_days = rf_delivery_days;
        }
    }
}
