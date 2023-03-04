using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_054  June-2013
    // Added OldPrDate (_old_pr_date) to "remember" the starting value when making changes in WShowRates2001

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("prt_description", "_prt_description", "")]
    [MapInfo("prt_key", "_prt_key", "piece_rate")]
    [MapInfo("pr_effective_date", "_pr_effective_date", "piece_rate")]
    [MapInfo("rg_code", "_rg_code", "piece_rate")]
    [MapInfo("pr_active_status", "_pr_active_status", "piece_rate")]
    [MapInfo("pr_rate", "_pr_rate", "piece_rate")]
    [MapInfo("old_pr_date", "_old_pr_date","")]
    [System.Serializable()]

    public class PieceRates2001 : Entity<PieceRates2001>
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

        [DBField()]
        private DateTime? _old_pr_date;

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

        public virtual DateTime? OldPrDate
        {
            get
            {
                CanReadProperty("OldPrDate", true);
                return _old_pr_date;
            }
            set
            {
                CanWriteProperty("OldPrDate", true);
                if (_old_pr_date != value)
                {
                    _old_pr_date = value;
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
        // needs to implement compute expression manually:
        // compute control name=[grp]
        //left( prt_description ,2 )
        public virtual string Grp
        {
            get
            {
                CanReadProperty("Grp", true);
                return (_prt_description.Substring(0,2));
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _prt_key, _pr_effective_date, _rg_code);
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
        public static PieceRates2001 NewPieceRates2001(int? inRgCode, DateTime? in_Date)
        {
            return Create(inRgCode, in_Date);
        }

        public static PieceRates2001[] GetAllPieceRates2001(int? inRgCode, DateTime? in_Date)
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
                    cm.CommandText = "rd.sp_getpiecerates2001";

                    List<PieceRates2001> _list = new List<PieceRates2001>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PieceRates2001 instance = new PieceRates2001();
                            instance._prt_description = GetValueFromReader<String>(dr,0);
                            instance._prt_key = GetValueFromReader<Int32?>(dr,1);
                            instance._pr_effective_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._rg_code = GetValueFromReader<Int32?>(dr,3);
                            instance._pr_active_status = GetValueFromReader<String>(dr,4);
                            instance._pr_rate = GetValueFromReader<Decimal?>(dr,5);
                            instance._old_pr_date = GetValueFromReader<DateTime?>(dr,2);
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
                if (GenerateUpdateCommandText(cm, "piece_rate", ref pList))
                {
                    cm.CommandText += " WHERE  piece_rate.prt_key = @prt_key and piece_rate.pr_effective_date = @pr_effective_date and piece_rate.rg_code = @rg_code";

                    pList.Add(cm, "prt_key", GetInitialValue("_prt_key"));
                    pList.Add(cm, "pr_effective_date", GetInitialValue("_pr_effective_date"));
                    pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
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
                if (GenerateInsertCommandText(cm, "piece_rate", pList))
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
                    pList.Add(cm, "prt_key", GetInitialValue("_prt_key"));
                    pList.Add(cm, "pr_effective_date", GetInitialValue("_pr_effective_date"));
                    pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
                    cm.CommandText = "DELETE FROM piece_rate WHERE  piece_rate.prt_key = @prt_key and piece_rate.pr_effective_date = @pr_effective_date and piece_rate.rg_code = @rg_code";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
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
