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
    [MapInfo("rg_code", "_rg_code", "rate_days")]
    [MapInfo("rr_rates_effective_date", "_rr_rates_effective_date", "rate_days")]
    [MapInfo("sf_key", "_sf_key", "rate_days")]
    [MapInfo("rtd_days_per_annum", "_rtd_days_per_annum", "rate_days")]
    [MapInfo("sf_description", "_sf_description", "")]
    [MapInfo("sf_days_week", "_sf_days_week", "")]
    [System.Serializable()]

    public class RateDays2001 : Entity<RateDays2001>
    {
        #region Business Methods
        [DBField()]
        private int? _rg_code;

        [DBField()]
        private DateTime? _rr_rates_effective_date;

        [DBField()]
        private int? _sf_key;

        [DBField()]
        private int? _rtd_days_per_annum;

        [DBField()]
        private string _sf_description;

        [DBField()]
        private int? _sf_days_week;


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

        public virtual DateTime? RrRatesEffectiveDate
        {
            get
            {
                CanReadProperty("RrRatesEffectiveDate", true);
                return _rr_rates_effective_date;
            }
            set
            {
                CanWriteProperty("RrRatesEffectiveDate", true);
                if (_rr_rates_effective_date != value)
                {
                    _rr_rates_effective_date = value;
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

        public virtual int? RtdDaysPerAnnum
        {
            get
            {
                CanReadProperty("RtdDaysPerAnnum", true);
                return _rtd_days_per_annum;
            }
            set
            {
                CanWriteProperty("RtdDaysPerAnnum", true);
                if (_rtd_days_per_annum != value)
                {
                    _rtd_days_per_annum = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string SfDescription
        {
            get
            {
                CanReadProperty("SfDescription", true);
                return _sf_description;
            }
            set
            {
                CanWriteProperty("SfDescription", true);
                if (_sf_description != value)
                {
                    _sf_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? SfDaysWeek
        {
            get
            {
                CanReadProperty("SfDaysWeek", true);
                return _sf_days_week;
            }
            set
            {
                CanWriteProperty("SfDaysWeek", true);
                if (_sf_days_week != value)
                {
                    _sf_days_week = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool? Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return IsNew;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _rg_code, _rr_rates_effective_date, _sf_key);
        }
        #endregion

        public void MarkNewEntity()
        {
            base.MarkNew();
        }

        public void MarkNotModifiedEntity()
        {
            base.MarkClean();
        }

        #region Factory Methods
        public static RateDays2001 NewRateDays2001(int? inRgCode, DateTime? in_Date)
        {
            return Create(inRgCode, in_Date);
        }

        public static RateDays2001[] GetAllRateDays2001(int? inRgCode, DateTime? in_Date)
        {
            return Fetch(inRgCode, in_Date).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inRgCode, DateTime? in_Date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inRgCode", inRgCode);
                    pList.Add(cm, "in_Date", in_Date);
                    cm.CommandText = "rd.sp_getratedays2001";

                    List<RateDays2001> _list = new List<RateDays2001>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RateDays2001 instance = new RateDays2001();
                            instance._rg_code = GetValueFromReader<Int32?>(dr,0);
                            instance._rr_rates_effective_date = GetValueFromReader<DateTime?>(dr,1);
                            instance._sf_key = GetValueFromReader<Int32?>(dr,2);
                            instance._rtd_days_per_annum = GetValueFromReader<Int32?>(dr,3);
                            instance._sf_description = GetValueFromReader<String>(dr,4).Trim();
                            instance._sf_days_week = GetValueFromReader<Int32?>(dr,5);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
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
                if (GenerateUpdateCommandText(cm, "rate_days", ref pList))
                {
                    cm.CommandText += " WHERE  rate_days.rg_code = @rg_code and rate_days.rr_rates_effective_date = @rr_rates_effective_date and rate_days.sf_key = @sf_key";

                    pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
                    pList.Add(cm, "rr_rates_effective_date", GetInitialValue("_rr_rates_effective_date"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
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
                if (GenerateInsertCommandText(cm, "rate_days", pList))
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
                    pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
                    pList.Add(cm, "rr_rates_effective_date", GetInitialValue("_rr_rates_effective_date"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    cm.CommandText = "DELETE FROM rate_days WHERE  WHERE  rate_days.rg_code = @rg_code and rate_days.rr_rates_effective_date = @rr_rates_effective_date and rate_days.sf_key = @sf_key";

                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? rg_code, DateTime? rr_rates_effective_date, int? sf_key)
        {
            _rg_code = rg_code;
            _rr_rates_effective_date = rr_rates_effective_date;
            _sf_key = sf_key;
        }
    }
}
