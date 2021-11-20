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
    [MapInfo("rg_code", "_rg_code", "misc_rate")]
    [MapInfo("mr_effective_date", "_mr_effective_date", "misc_rate")]
    [MapInfo("mr_name", "_mr_name", "misc_rate")]
    [MapInfo("mr_value", "_mr_value", "misc_rate")]
    [MapInfo("mr_km_flag", "_mr_km_flag", "misc_rate")]
    [MapInfo("mr_annual_flag", "_mr_annual_flag", "misc_rate")]
    [System.Serializable()]

    public class MiscRates2001 : Entity<MiscRates2001>
    {
        #region Business Methods
        [DBField()]
        private int? _rg_code;

        [DBField()]
        private DateTime? _mr_effective_date;

        [DBField()]
        private string _mr_name;

        [DBField()]
        private decimal? _mr_value;

        [DBField()]
        private string _mr_km_flag;

        [DBField()]
        private string _mr_annual_flag;


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

        public virtual DateTime? MrEffectiveDate
        {
            get
            {
                CanReadProperty("MrEffectiveDate", true);
                return _mr_effective_date;
            }
            set
            {
                CanWriteProperty("MrEffectiveDate", true);
                if (_mr_effective_date != value)
                {
                    _mr_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MrName
        {
            get
            {
                CanReadProperty("MrName", true);
                return _mr_name;
            }
            set
            {
                CanWriteProperty("MrName", true);
                if (_mr_name != value)
                {
                    _mr_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? MrValue
        {
            get
            {
                CanReadProperty("MrValue", true);
                return _mr_value;
            }
            set
            {
                CanWriteProperty("MrValue", true);
                if (_mr_value != value)
                {
                    _mr_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MrKmFlag
        {
            get
            {
                CanReadProperty("MrKmFlag", true);
                return _mr_km_flag;
            }
            set
            {
                CanWriteProperty("MrKmFlag", true);
                if (_mr_km_flag != value)
                {
                    _mr_km_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MrAnnualFlag
        {
            get
            {
                CanReadProperty("MrAnnualFlag", true);
                return _mr_annual_flag;
            }
            set
            {
                CanWriteProperty("MrAnnualFlag", true);
                if (_mr_annual_flag != value)
                {
                    _mr_annual_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _rg_code, _mr_effective_date);
        }
        #endregion

        public void MarkNewEntity()
        {
            base.MarkNew();
        }

        public void MarkDirtyEntity()
        {
            base.MarkDirty();
        }

        #region Factory Methods
        public static MiscRates2001 NewMiscRates2001(int? in_RgCode, DateTime? in_EffectDate)
        {
            return Create(in_RgCode, in_EffectDate);
        }

        public static MiscRates2001[] GetAllMiscRates2001(int? in_RgCode, DateTime? in_EffectDate)
        {
            return Fetch(in_RgCode, in_EffectDate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_RgCode, DateTime? in_EffectDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_RgCode", in_RgCode);
                    pList.Add(cm, "in_EffectDate", in_EffectDate);
                    cm.CommandText = "rd.sp_getmiscrate";
                    List<MiscRates2001> _list = new List<MiscRates2001>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            MiscRates2001 instance = new MiscRates2001();
                            instance._rg_code = GetValueFromReader<Int32?>(dr,0);
                            instance._mr_effective_date = GetValueFromReader<DateTime?>(dr,1);
                            instance._mr_name = GetValueFromReader<String>(dr,2);
                            instance._mr_value = GetValueFromReader<Decimal?>(dr,3);
                            instance._mr_km_flag = GetValueFromReader<String>(dr,4);
                            instance._mr_annual_flag = GetValueFromReader<String>(dr,5);
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
                if (GenerateUpdateCommandText(cm, "misc_rate", ref pList))
                {
                    cm.CommandText += " WHERE  misc_rate.rg_code = @rg_code and misc_rate.mr_effective_date = @mr_effective_date";

                    pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
                    pList.Add(cm, "mr_effective_date", GetInitialValue("_mr_effective_date"));
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
                if (GenerateInsertCommandText(cm, "misc_rate", pList))
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
                    pList.Add(cm, "mr_effective_date", GetInitialValue("_mr_effective_date"));
                    cm.CommandText = "DELETE FROM misc_rate  WHERE  misc_rate.rg_code = @rg_code and misc_rate.mr_effective_date = @mr_effective_date";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? rg_code, DateTime? mr_effective_date)
        {
            _rg_code = rg_code;
            _mr_effective_date = mr_effective_date;
        }
    }
}
