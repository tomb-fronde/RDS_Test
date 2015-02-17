using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_093:  New

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
    [MapInfo("act_description", "_act_description", "")]
    [System.Serializable()]

    public class DailyArticalCounts : Entity<DailyArticalCounts>
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

        // Compute weekday dates 
        private DateTime? GetDayNo(double day_no)
        {
            if (_ac_start_week_period == null)
            {
                return null;
            }
            else
            {
                DateTime temp_date = (DateTime)_ac_start_week_period;
                double temp_week_no = (double)_acd_week_no;
                return (DateTime?)temp_date.AddDays(day_no + ((temp_week_no - 1) * 7) );
            }
        }

        public virtual DateTime? AcdMonDate
        {
            get
            {
                return GetDayNo(0);
                //return _ac_start_week_period.AddDays(0 + ((_acd_week_no - 1) * 7));
            }
        }

        public virtual DateTime? AcdTueDate
        {
            get
            {
                return GetDayNo(1);
                //return _ac_start_week_period.AddDays(1 + ((_acd_week_no - 1) * 7));
            }
        }

        public virtual DateTime? AcdWedDate
        {
            get
            {
                return GetDayNo(2);
                //return _ac_start_week_period.AddDays(2 + ((_acd_week_no - 1) * 7));
            }
        }

        public virtual DateTime? AcdThuDate
        {
            get
            {
                return GetDayNo(3);
                //return _ac_start_week_period.AddDays(3 + ((_acd_week_no - 1) * 7));
            }
        }

        public virtual DateTime? AcdFriDate
        {
            get
            {
                return GetDayNo(4);
                //return _ac_start_week_period.AddDays(4 + ((_acd_week_no - 1) * 7));
            }
        }

        public virtual DateTime? AcdSatDate
        {
            get
            {
                return GetDayNo(5);
                //return _ac_start_week_period.AddDays(5 + ((_acd_week_no - 1) * 7));
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
        public static DailyArticalCounts NewDailyArticalCounts(int? in_contract, DateTime? in_period, int? in_week_no)
        {
            return Create(in_contract, in_period, in_week_no);
        }

        public static DailyArticalCounts[] GetAllDailyArticalCounts(int? in_contract, DateTime? in_period, int? in_week_no)
        {
            return Fetch(in_contract, in_period, in_week_no).list;
        }

        public void MarkAsNew()
        {
            base.MarkNew();
            base.MarkClean();
        }

        public void MarkAsNewAndModified()
        {
            base.MarkNew();
            base.MarkDirty();
            base.MarkClean();
        }

        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_contract, DateTime? in_period, int? in_week_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_contract", in_contract);
                    pList.Add(cm, "in_period", in_period);
                    pList.Add(cm, "in_week_no", in_week_no);
                    cm.CommandText = "select acd.contract_no"
                                    + ", acd.ac_start_week_period"
                                    + ", acd.contract_seq_number"
                                    + ", acd.acd_week_no"
                                    + ", acd.act_key"
                                    + ", act.act_description "
                                    + ", acd.acd_mon_count"
                                    + ", acd.acd_tue_count"
                                    + ", acd.acd_wed_count"
                                    + ", acd.acd_thu_count"
                                    + ", acd.acd_fri_count"
                                    + ", acd.acd_sat_count"
                                    + " from artical_count_daily acd " 
                                    + "          left outer join artical_count_type act"
                                    + "               on act.act_key = acd.act_key"
                                    + " where acd.contract_no = @in_contract "
                                    + "   and acd.ac_start_week_period = @in_period "
                                    + "   and acd.acd_week_no = @in_week_no "
                                    + " order by acd.act_key"
                                    ;

                    List<DailyArticalCounts> _list = new List<DailyArticalCounts>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                DailyArticalCounts instance = new DailyArticalCounts();
                                instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                                instance._ac_start_week_period = GetValueFromReader<DateTime?>(dr, 1);
                                instance._contract_seq_number = GetValueFromReader<Int32?>(dr, 2);
                                instance._acd_week_no = GetValueFromReader<Int32?>(dr, 3);
                                instance._act_key = GetValueFromReader<Int32?>(dr, 4);
                                instance._act_description = GetValueFromReader<string>(dr, 5);
                                instance._acd_mon_count = GetValueFromReader<Int32?>(dr, 6);
                                instance._acd_tue_count = GetValueFromReader<Int32?>(dr, 7);
                                instance._acd_wed_count = GetValueFromReader<Int32?>(dr, 8);
                                instance._acd_thu_count = GetValueFromReader<Int32?>(dr, 9);
                                instance._acd_fri_count = GetValueFromReader<Int32?>(dr, 10);
                                instance._acd_sat_count = GetValueFromReader<Int32?>(dr, 11);
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
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "insert into artical_count" 
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

                DBHelper.ExecuteNonQuery(cm, pList);
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "update artical_count"
                 + "set" 
                    + ", contract_seq_no = @contract_seq_no" 
                    + ", acd_mon_count = @acd_mon_count" 
                    + ", acd_tue_count = @acd_tue_count" 
                    + ", acd_wed_count = @acd_wed_count" 
                    + ", acd_thu_count = @acd_thu_count" 
                    + ", acd_fri_count = @acd_fri_count" 
                    + ", acd_sat_count = @acd_sat_count" 
                 + " where " 
                    + "    contract_no=@contract_no " 
                    + "and ac_start_week_period=@ac_start_week_period"
                    + "and acd_week_no=@acd_week_no"
                    + "and act_key=@act_key"
                 ;

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

                DBHelper.ExecuteNonQuery(cm, pList);
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity( int? in_contract_no, DateTime? in_start_week_period
                                 , int? in_week_no, int? in_act_key)
        {
            _contract_no = in_contract_no;
            _ac_start_week_period = in_start_week_period;
            _acd_week_no = in_week_no;
            _act_key = in_act_key;
        }

    }
}
