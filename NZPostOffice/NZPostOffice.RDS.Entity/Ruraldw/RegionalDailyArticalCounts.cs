using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_093  Feb-2015: New
    // Fetch, save data to/from artical_count_daily table 
    //    for daily artical count entry.
    // Also saves weekly totals in artical_count table
    //
    // TJB  RPCR_093  Mar-2015
    // Added update/insert test to InsertEntity and UpdateEntity
    // Added acd_update to retrieved data

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "artical_count_daily")]
    [MapInfo("ac_start_week_period", "_ac_start_week_period", "artical_count_daily")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "artical_count_daily")]
    [MapInfo("acd_week_no", "_acd_week_no", "artical_count_daily")]
    [MapInfo("act_key", "_acct_key", "artical_count_daily")]
    [MapInfo("acd_mon_count", "_acd_mon_count", "artical_count_daily")]
    [MapInfo("acd_tue_count", "_acd_tue_count", "artical_count_daily")]
    [MapInfo("acd_wed_count", "_acd_wed_count", "artical_count_daily")]
    [MapInfo("acd_thu_count", "_acd_thu_count", "artical_count_daily")]
    [MapInfo("acd_fri_count", "_acd_fri_count", "artical_count_daily")]
    [MapInfo("acd_sat_count", "_acd_sat_count", "artical_count_daily")]
    [MapInfo("acd_update", "_acd_update", "")]
    [MapInfo("act_description", "_act_description", "")]
    [System.Serializable()]

    public class RegionalDailyArticalCounts : Entity<RegionalDailyArticalCounts>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private DateTime? _ac_start_week_period;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private int? _acd_week_no;

        [DBField()]
        private int? _act_key;

        [DBField()]
        private int? _acd_mon_count;

        [DBField()]
        private int? _acd_tue_count;

        [DBField()]
        private int? _acd_wed_count;

        [DBField()]
        private int? _acd_thu_count;

        [DBField()]
        private int? _acd_fri_count;

        [DBField()]
        private int? _acd_sat_count;

        [DBField()]
        private string _act_description;

        [DBField()]
        private string _acd_update;


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

        public virtual DateTime? AcStartWeekPeriod
        {
            get
            {
                CanReadProperty("AcStartWeekPeriod", true);
                return _ac_start_week_period;
            }
            set
            {
                CanWriteProperty("AcStartWeekPeriod", true);
                if (_ac_start_week_period != value)
                {
                    _ac_start_week_period = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ContractSeqNumber
        {
            get
            {
                CanReadProperty("ContractSeqNumber", true);
                return _contract_seq_number;
            }
            set
            {
                CanWriteProperty("ContractSeqNumber", true);
                if (_contract_seq_number != value)
                {
                    _contract_seq_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcdWeekNo
        {
            get
            {
                CanReadProperty("AcdWeekNo", true);
                return _acd_week_no;
            }
            set
            {
                CanWriteProperty("AcdWeekNo", true);
                if (_acd_week_no != value)
                {
                    _acd_week_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ActKey
        {
            get
            {
                CanReadProperty("ActKey", true);
                return _act_key;
            }
            set
            {
                CanWriteProperty("ActKey", true);
                if (_act_key != value)
                {
                    _act_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcdMonCount
        {
            get
            {
                CanReadProperty("AcdMonCount", true);
                return _acd_mon_count;
            }
            set
            {
                CanWriteProperty("AcdMonCount", true);
                if (_acd_mon_count != value)
                {
                    _acd_mon_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcdTueCount
        {
            get
            {
                CanReadProperty("AcdTueCount", true);
                return _acd_tue_count;
            }
            set
            {
                CanWriteProperty("AcdTueCount", true);
                if (_acd_tue_count != value)
                {
                    _acd_tue_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcdWedCount
        {
            get
            {
                CanReadProperty("AcdWedCount", true);
                return _acd_wed_count;
            }
            set
            {
                CanWriteProperty("AcdWedCount", true);
                if (_acd_wed_count != value)
                {
                    _acd_wed_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcdThuCount
        {
            get
            {
                CanReadProperty("AcdThuCount", true);
                return _acd_thu_count;
            }
            set
            {
                CanWriteProperty("AcdThuCount", true);
                if (_acd_thu_count != value)
                {
                    _acd_thu_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcdFriCount
        {
            get
            {
                CanReadProperty("AcdFriCount", true);
                return _acd_fri_count;
            }
            set
            {
                CanWriteProperty("AcdFriCount", true);
                if (_acd_fri_count != value)
                {
                    _acd_fri_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcdSatCount
        {
            get
            {
                CanReadProperty("AcdSatCount", true);
                return _acd_sat_count;
            }
            set
            {
                CanWriteProperty("AcdSatCount", true);
                if (_acd_sat_count != value)
                {
                    _acd_sat_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ActDescription
        {
            get
            {
                CanReadProperty("ActDescription", true);
                return _act_description;
            }
            set
            {
                CanWriteProperty("ActDescription", true);
                if (_act_description != value)
                {
                    _act_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AcdUpdate
        {
            get
            {
                CanReadProperty("AcdUpdate", true);
                return _acd_update;
            }
            set
            {
                CanWriteProperty("AcdUpdate", true);
                if (_acd_update != value)
                {
                    _acd_update = value;
                    PropertyHasChanged();
                }
            }
        }

        // Compute field for week total
        public virtual int? WeekTotal
        {
            get
            {
                CanReadProperty("WeekTotal", true);
                return (_acd_mon_count == null ? 0 : _acd_mon_count)
                       + (_acd_tue_count == null ? 0 : _acd_tue_count)
                       + (_acd_wed_count == null ? 0 : _acd_wed_count)
                       + (_acd_thu_count == null ? 0 : _acd_thu_count)
                       + (_acd_fri_count == null ? 0 : _acd_fri_count)
                       + (_acd_sat_count == null ? 0 : _acd_sat_count);
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _ac_start_week_period);
        }
        #endregion

        #region Factory Methods
        public static RegionalDailyArticalCounts NewRegionalDailyArticalCounts(int? in_Region, int? in_Renewal, DateTime? in_Period, int? in_WeekNo, int? in_ActKey)
        {
            return Create(in_Region, in_Renewal, in_Period, in_WeekNo, in_ActKey);
        }

        public static RegionalDailyArticalCounts[] GetAllRegionalDailyArticalCounts(int? in_Contract, int? in_Region, int? in_Renewal, DateTime? in_Period)
        {
            return Fetch(in_Contract, in_Region, in_Renewal, in_Period).list;
        }

        public void MarkAsNewAndModified()
        {
            base.MarkNew();
            //base.MarkDirty();
            base.MarkClean();
        }

        #endregion

        #region Data Access
        [ServerMethod()]
        private void FetchEntity(int? in_Contract, int? in_Region, int? in_Renewal, DateTime? in_Period)
        {
            // TJB  RPCR_093  Mar-2015
            // Added acd_update to retrieved data
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();

                    if (in_Contract == null || in_Contract == 0)
                    {
                        pList.Add(cm, "in_Region", in_Region);
                        pList.Add(cm, "in_RenewalGroup", in_Renewal);
                        pList.Add(cm, "in_Period", in_Period);
                        cm.CommandText = "sp_GetRegionDailyArticalCounts";
                    }
                    else
                    {
                        pList.Add(cm, "in_Contract", in_Contract);
                        pList.Add(cm, "in_Period", in_Period);
                        cm.CommandText = "sp_GetContractDailyArticalCounts";
                    }

                    List<RegionalDailyArticalCounts> _list = new List<RegionalDailyArticalCounts>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                RegionalDailyArticalCounts instance = new RegionalDailyArticalCounts();
                                instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                                instance._ac_start_week_period = GetValueFromReader<DateTime?>(dr, 1);
                                instance._acd_week_no = GetValueFromReader<Int32?>(dr, 2);
                                instance._act_key = GetValueFromReader<Int32?>(dr, 3);
                                instance._act_description = GetValueFromReader<string>(dr, 4);
                                instance._acd_mon_count = GetValueFromReader<Int32?>(dr, 5);
                                instance._acd_tue_count = GetValueFromReader<Int32?>(dr, 6);
                                instance._acd_wed_count = GetValueFromReader<Int32?>(dr, 7);
                                instance._acd_thu_count = GetValueFromReader<Int32?>(dr, 8);
                                instance._acd_fri_count = GetValueFromReader<Int32?>(dr, 9);
                                instance._acd_sat_count = GetValueFromReader<Int32?>(dr, 10);
                                instance._acd_update = GetValueFromReader<string>(dr, 11);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        string s1, s2;
                        s1 = e.Message;
                        s2 = s1;
                    }
                }
            }
        }

        [ServerMethod()]
        private void InsertEntity()
        {
            // TJB  RPCR_093  Mar-2015
            // Added update/insert test
            if (_acd_update == "U")
            {
                UpdateEntity();
            }
            else
            {
                using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into artical_count_daily"
                        + "( contract_no"
                        + ", ac_start_week_period"
                        + ", contract_seq_number"
                        + ", acd_week_no"
                        + ", act_key"
                        + ", acd_mon_count"
                        + ", acd_tue_count"
                        + ", acd_wed_count"
                        + ", acd_thu_count"
                        + ", acd_fri_count"
                        + ", acd_sat_count)"
                    + " values"
                        + "( @contract_no"
                        + ", @ac_start_week_period"
                        + ", @contract_seq_number"
                        + ", @acd_week_no"
                        + ", @act_key"
                        + ", @acd_mon_count"
                        + ", @acd_tue_count"
                        + ", @acd_wed_count"
                        + ", @acd_thu_count"
                        + ", @acd_fri_count"
                        + ", @acd_sat_count)"
                    ;
                    // If we're creating a new record, onvert and null's to 0
                    if (_acd_mon_count == null) AcdMonCount = 0;
                    if (_acd_tue_count == null) AcdTueCount = 0;
                    if (_acd_wed_count == null) AcdWedCount = 0;
                    if (_acd_thu_count == null) AcdThuCount = 0;
                    if (_acd_fri_count == null) AcdFriCount = 0;
                    if (_acd_sat_count == null) AcdSatCount = 0;

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", _contract_no);
                    pList.Add(cm, "ac_start_week_period", _ac_start_week_period);
                    pList.Add(cm, "contract_seq_number", _contract_seq_number);
                    pList.Add(cm, "acd_week_no", _acd_week_no);
                    pList.Add(cm, "act_key", _act_key);
                    pList.Add(cm, "acd_mon_count", _acd_mon_count);
                    pList.Add(cm, "acd_tue_count", _acd_tue_count);
                    pList.Add(cm, "acd_wed_count", _acd_wed_count);
                    pList.Add(cm, "acd_thu_count", _acd_thu_count);
                    pList.Add(cm, "acd_fri_count", _acd_fri_count);
                    pList.Add(cm, "acd_sat_count", _acd_sat_count);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        // reinitialize original key/value list
                        StoreInitialValues();
                    }
                    catch (Exception e)
                    {
                        string s1, s2;
                        s1 = e.Message;
                        s2 = s1;
                    }

                    update_artical_count();
                }
            }
        }
        [ServerMethod()]
        private void UpdateEntity()
        {
            // TJB  RPCR_093  Mar-2015
            // Added update/insert test
            if (_acd_update == "A")
            {
                InsertEntity();
                _acd_update = "U";
            }
            else
            {
                using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();

                    if (GenerateUpdateCommandText(cm, "artical_count_daily", ref pList))
                    {
                        pList.Add(cm, "contract_no", _contract_no);
                        pList.Add(cm, "ac_start_week_period", _ac_start_week_period);
                        pList.Add(cm, "contract_seq_number", _contract_seq_number);
                        pList.Add(cm, "acd_week_no", _acd_week_no);
                        pList.Add(cm, "act_key", _act_key);

                        cm.CommandText += " where "
                            + "    contract_no=@contract_no "
                            + "and ac_start_week_period=@ac_start_week_period "
                            + "and acd_week_no=@acd_week_no "
                            + "and act_key=@act_key ";

                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                            // reinitialize original key/value list
                            StoreInitialValues();
                        }
                        catch (Exception e)
                        {
                            string s1, s2;
                            s1 = e.Message;
                            s2 = s1;
                        }

                        update_artical_count();
                    }
                }
            }
        }

        [ServerMethod()]
        private void update_artical_count()
        {
            string artical_count_field = "";
            int    artical_count_value = 0;

            /******************************************************
             * Need to determine which field to populate, and     *
             * its value                                          *
             ******************************************************/
            if (_acd_week_no == 1)
            {
                if (_act_description == "Medium Letters")
                {
                    artical_count_field = "ac_w1_medium_letters";
                }
                else if (_act_description == "Other Envelopes")
                {
                    artical_count_field = "ac_w1_other_envelopes";
                }
                else if (_act_description == "Small Parcels")
                {
                    artical_count_field = "ac_w1_small_parcels";
                }
                else if (_act_description == "Inward Mail")
                {
                    artical_count_field = "ac_w1_inward_mail";
                }
            }
            else if (_acd_week_no == 2)
            {
                if (_act_description == "Medium Letters")
                {
                    artical_count_field = "ac_w2_medium_letters";
                }
                else if (_act_description == "Other Envelopes")
                {
                    artical_count_field = "ac_w2_other_envelopes";
                }
                else if (_act_description == "Small Parcels")
                {
                    artical_count_field = "ac_w2_small_parcels";
                }
                else if (_act_description == "Inward Mail")
                {
                    artical_count_field = "ac_w2_inward_mail";
                }
            }
            else
                return;

            artical_count_value = (WeekTotal == null) ? 0 : (int)WeekTotal;

            // If no record exists in the artical_count table for
            // contract_no/ac_start_week_period, sp_AddArticalCountValue 
            // will first create one with 0's for the counts, then 
            // update the appropriate column with the computed value.
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();

                    pList.Add(cm, "inContractNo", _contract_no);
                    pList.Add(cm, "inStartWeekPeriod", _ac_start_week_period);
                    pList.Add(cm, "inColumnName", artical_count_field);
                    pList.Add(cm, "inValue", artical_count_value);
                    cm.CommandText = "rd.sp_AddArticalCountValue";
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        // reinitialize original key/value list
                        StoreInitialValues();
                    }
                    catch (Exception e)
                    {
                        string s1, s2;
                        s1 = e.Message;
                        s2 = s1;
                    }
                }
            }
        }

        [ServerMethod()]
        private void CreateEntity(int? in_Contract
                                 , DateTime? in_StartWeekPeriod
                                 , int? in_WeekNo
                                 , int? in_ActKey)
        {
            _contract_no = in_Contract;
            _ac_start_week_period = in_StartWeekPeriod;
            _acd_week_no = in_WeekNo;
            _act_key = in_ActKey;
        }
        #endregion
    }
}
