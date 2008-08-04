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
    [MapInfo("prt_description", "_prt_description", "")]
    [MapInfo("prt_key", "_prt_key", "")]
    [MapInfo("pr_effective_date", "_pr_effective_date", "")]
    [MapInfo("rg_code", "_rg_code", "")]
    [MapInfo("pr_active_status", "_pr_active_status", "")]
    [MapInfo("pr_rate", "_pr_rate", "")]
    [System.Serializable()]

    public class PieceRates : Entity<PieceRates>
    {
        #region Business Methods
        [DBField()]
        private string _prt_description;

        [DBField()]
        private int? _prt_key;

        [DBField()]
        private DateTime? _pr_effective_date;

        [DBField()]
        private int? _rg_code;

        [DBField()]
        private string _pr_active_status;

        [DBField()]
        private decimal? _pr_rate;


        public virtual string PrtDescription
        {
            get
            {
                CanReadProperty("PrtDescription", true);
                return _prt_description;
            }
            set
            {
                CanWriteProperty("PrtDescription", true);
                if (_prt_description != value)
                {
                    _prt_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrtKey
        {
            get
            {
                CanReadProperty("PrtKey", true);
                return _prt_key;
            }
            set
            {
                CanWriteProperty("PrtKey", true);
                if (_prt_key != value)
                {
                    _prt_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? PrEffectiveDate
        {
            get
            {
                CanReadProperty("PrEffectiveDate", true);
                return _pr_effective_date;
            }
            set
            {
                CanWriteProperty("PrEffectiveDate", true);
                if (_pr_effective_date != value)
                {
                    _pr_effective_date = value;
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

        public virtual string PrActiveStatus
        {
            get
            {
                CanReadProperty("PrActiveStatus", true);
                return _pr_active_status;
            }
            set
            {
                CanWriteProperty("PrActiveStatus", true);
                if (_pr_active_status != value)
                {
                    _pr_active_status = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? PrRate
        {
            get
            {
                CanReadProperty("PrRate", true);
                return _pr_rate;
            }
            set
            {
                CanWriteProperty("PrRate", true);
                if (_pr_rate != value)
                {
                    _pr_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _prt_key, _pr_effective_date, _rg_code);
        }
        #endregion

        #region Factory Methods
        public static PieceRates NewPieceRates(DateTime? in_Date)
        {
            return Create(in_Date);
        }

        public static PieceRates[] GetAllPieceRates(DateTime? in_Date)
        {
            return Fetch(in_Date).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? in_Date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Date", in_Date);
                    cm.CommandText = "rd.sp_getpiecerates";

                    List<PieceRates> _list = new List<PieceRates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PieceRates instance = new PieceRates();
                            instance._prt_description = GetValueFromReader<String>(dr,0);
                            instance._prt_key = GetValueFromReader<Int32?>(dr,1);
                            instance._pr_effective_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._rg_code = GetValueFromReader<Int32?>(dr,3);
                            instance._pr_active_status = GetValueFromReader<String>(dr,4);
                            instance._pr_rate = GetValueFromReader<Decimal?>(dr,5);
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
        private void CreateEntity(int? prt_key, DateTime? pr_effective_date, int? rg_code)
        {
            _prt_key = prt_key;
            _pr_effective_date = pr_effective_date;
            _rg_code = rg_code;
        }
    }
}
