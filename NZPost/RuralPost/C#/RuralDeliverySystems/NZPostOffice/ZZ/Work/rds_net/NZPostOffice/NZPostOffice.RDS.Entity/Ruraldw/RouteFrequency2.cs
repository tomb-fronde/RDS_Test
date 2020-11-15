using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB Frequencies Changes 15-Nov-2020
    // Checkin working version
    // with DRouteFrequency2 and DRouteFrequency2Rows
    //
    // TJB Frequencies Changes Nov-2020
    // Derived from RouteFrequency

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "route_frequency")]
    [MapInfo("sf_key", "_sf_key", "route_frequency")]
    [MapInfo("rf_delivery_days", "_rf_delivery_days", "route_frequency")]
    [MapInfo("rf_active", "_rf_active", "route_frequency")]
    [MapInfo("rf_monday", "_rf_monday", "")]
    [MapInfo("rf_tuesday", "_rf_tuesday", "")]
    [MapInfo("rf_wednesday", "_rf_wednesday", "")]
    [MapInfo("rf_thursday", "_rf_thursday", "")]
    [MapInfo("rf_friday", "_rf_friday", "")]
    [MapInfo("rf_saturday", "_rf_saturday", "")]
    [MapInfo("rf_sunday", "_rf_sunday", "")]
    [MapInfo("rf_distance", "_distance", "route_frequency")]
    [MapInfo("rf_nms", "_rf_nms", "route_frequency")]
    [MapInfo("rf_dpcount", "_rf_dpcount", "route_frequency")]
    [MapInfo("vehicle_number", "_vehicle_number", "route_frequency")]
    [System.Serializable()]

    public class RouteFrequency2 : Entity<RouteFrequency2>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _sf_key;

        [DBField()]
        private string _rf_delivery_days;

        [DBField()]
        private string _rf_active = "Y";

        [DBField()]
        private string _rf_monday = "N";

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
        private decimal? _distance=0;

        [DBField()]
        private string _inUse;

        [DBField()]
        private string _rf_nms;

        [DBField()]
        private int? _rf_dpcount = 0;

        [DBField()]
        private int? _vehicle_number = 0;

        [DBField()]
        private string _sf_description;

        /*----------------------------------------------------------------------*/

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

        public virtual string RfNms
        {
            get
            {
                CanReadProperty("RfNms", true);
                return _rf_nms;
            }
            set
            {
                CanWriteProperty("RfNms", true);
                if (_rf_nms != value)
                {
                    _rf_nms = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RfDpcount
        {
            get
            {
                CanReadProperty("RfDpcount", true);
                return _rf_dpcount;
            }
            set
            {
                CanWriteProperty("RfDpcount", true);
                if (_rf_dpcount != value)
                {
                    _rf_dpcount = value;
                    PropertyHasChanged();
                }
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

        /*---------------------------------- For checkboxes ------------------------------------*/
        public virtual bool RfActiveChecked
        {
            get
            {
                CanReadProperty("RfActive", true);
                if (_rf_active == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfActive", true);
                if (value && _rf_active != "Y")
                {
                    _rf_active = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_active != "N")
                {
                    _rf_active = "N";
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool RfMondayChecked
        {
            get
            {
                CanReadProperty("RfMonday", true);
                if (_rf_monday == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfMonday", true);
                if (value && _rf_monday != "Y")
                {
                    _rf_monday = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_monday != "N")
                {
                    _rf_monday = "N";
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool RfTuesdayChecked
        {
            get
            {
                CanReadProperty("RfTuesday", true);
                if (_rf_tuesday == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfTuesday", true);
                if (value && _rf_tuesday != "Y")
                {
                    _rf_tuesday = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_tuesday != "N")
                {
                    _rf_tuesday = "N";
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool RfWednesdayChecked
        {
            get
            {
                CanReadProperty("RfWednesday", true);
                if (_rf_wednesday == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfWednesday", true);
                if (value && _rf_wednesday != "Y")
                {
                    _rf_wednesday = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_wednesday != "N")
                {
                    _rf_wednesday = "N";
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool RfThursdayChecked
        {
            get
            {
                CanReadProperty("RfThursday", true);
                if (_rf_thursday == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfThursday", true);
                if (value && _rf_thursday != "Y")
                {
                    _rf_thursday = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_thursday != "N")
                {
                    _rf_thursday = "N";
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool RfFridayChecked
        {
            get
            {
                CanReadProperty("RfFriday", true);
                if (_rf_friday == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfFriday", true);
                if (value && _rf_friday != "Y")
                {
                    _rf_friday = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_friday != "N")
                {
                    _rf_friday = "N";
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool RfSaturdayChecked
        {
            get
            {
                CanReadProperty("RfSaturday", true);
                if (_rf_saturday == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfSaturday", true);
                if (value && _rf_saturday != "Y")
                {
                    _rf_saturday = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_saturday != "N")
                {
                    _rf_saturday = "N";
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool RfSundayChecked
        {
            get
            {
                CanReadProperty("RfSunday", true);
                if (_rf_sunday == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                CanWriteProperty("RfSunday", true);
                if (value && _rf_sunday != "Y")
                {
                    _rf_sunday = "Y";
                    PropertyHasChanged();
                }
                if (!value && _rf_sunday != "N")
                {
                    _rf_sunday = "N";
                    PropertyHasChanged();
                }
            }
        }

 /*------------------------------------ Derived values ----------------------------------*/

        public virtual string Compute2
        {
            get
            {
                CanReadProperty("Compute2", true);
                if (InUse == null)
                {
                    return NZPostOffice.RDS.DataService.RDSDataService.FFreqInuse(_contract_no, _sf_key, _rf_delivery_days);//TComputer2; 
                }
                else
                    return InUse;
            }
        }

        private string _t_computer;
        public virtual string TComputer
        {
            get
            {
                return _t_computer;
            }
        }

        public virtual string InUse
        {
            get
            {
                CanReadProperty("InUse", true);
                return _inUse;
            }
        }

        // needs to implement compute expression manually:
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
        /*--------------------------------------------------------------------------*/
        #endregion

        #region Factory Methods
        public static RouteFrequency2 NewRouteFrequency2(int? in_Contract)
        {
            return Create(in_Contract);
        }

        public static RouteFrequency2[] GetAllRouteFrequency2(int? in_Contract, int? in_showAll)
        {
                return Fetch(in_Contract, in_showAll).list;
        }

        #endregion

        /*----------------------------------------------------------------------*/

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract, int? in_showAll)
        {
            // TJB  RPCR_044  Jan-2013
            // Added in_showAll; == 1 select all frequencies; == 0 select only active frequencies
            //   
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    if (in_showAll == null) in_showAll = 1;
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    pList.Add(cm, "in_showAll", in_showAll);
                    cm.CommandText = "rd.sp_getroutefrequency2020";

                    sqlCode = 0;

                    // TJB  Change Frequencies  Dec-2013
                    // Added try-catch during debugging
                    try
                    {
                        List<RouteFrequency2> _list = new List<RouteFrequency2>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                RouteFrequency2 instance = new RouteFrequency2();
                                instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                                instance._sf_key = GetValueFromReader<Int32?>(dr, 1);
                                instance._rf_delivery_days = GetValueFromReader<String>(dr, 2);
                                instance._rf_active = GetValueFromReader<String>(dr, 3);
                                instance._rf_monday = GetValueFromReader<String>(dr, 4);
                                instance._rf_tuesday = GetValueFromReader<String>(dr, 5);
                                instance._rf_wednesday = GetValueFromReader<String>(dr, 6);
                                instance._rf_thursday = GetValueFromReader<String>(dr, 7);
                                instance._rf_friday = GetValueFromReader<String>(dr, 8);
                                instance._rf_saturday = GetValueFromReader<String>(dr, 9);
                                instance._rf_sunday = GetValueFromReader<String>(dr, 10);
                                instance._distance = GetValueFromReader<Decimal?>(dr, 11);
                                instance._t_computer = GetValueFromReader<string>(dr, 12);
                                instance._rf_nms = GetValueFromReader<string>(dr, 13);
                                instance._rf_dpcount = GetValueFromReader<Int32>(dr, 14);
                                instance._vehicle_number = GetValueFromReader<Int32>(dr, 15);
                                instance._sf_description = GetValueFromReader<string>(dr, 16);
                                _inUse = in_Contract.ToString();
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        sqlCode = -1;
                        sqlErrText = e.Message;
                    }
                }
            }
        }

        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "route_frequency", ref pList))
                {
                    cm.CommandText += " WHERE  route_frequency.contract_no = @contract_no " +
                        "and route_frequency.sf_key = @sf_key " + 
                        "and route_frequency.rf_delivery_days = @rf_delivery_days";
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "route_frequency", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));
                    cm.CommandText = "DELETE FROM route_frequency WHERE " +
                        " route_frequency.contract_no = @contract_no " +
                        "and route_frequency.sf_key = @sf_key " +
                        "and route_frequency.rf_delivery_days = @rf_delivery_days";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }

        [ServerMethod]
        private string _FFreqInuse(int? ai_contract, int? ai_sfkey, string as_deldays)
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
                            iCount = GetValueFromReader<Int32>(dr, 0);
                        }
                    }
                    if (iCount > 0)
                    {
                        _t_computer = "Yes";
                        return "Yes";
                    }
                    else
                    {
                        _t_computer = "No";
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
