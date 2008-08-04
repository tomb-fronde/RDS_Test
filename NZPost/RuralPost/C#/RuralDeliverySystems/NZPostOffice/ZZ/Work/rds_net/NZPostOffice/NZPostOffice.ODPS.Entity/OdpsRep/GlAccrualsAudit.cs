using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("pbu_code", "_pbu_code", "")]
    [MapInfo("account_code", "_account_code", "")]
    [MapInfo("transaction_amount", "_transaction_amount", "")]
    [MapInfo("description", "_description", "")]
    [MapInfo("drcr", "_drcr", "")]
    [MapInfo("trans1", "_trans1", "")]
    [MapInfo("trans2", "_trans2", "")]
    [System.Serializable()]

    public class GlAccrualsAudit : Entity<GlAccrualsAudit>
    {
        #region Business Methods
        [DBField()]
        private string _pbu_code;

        [DBField()]
        private string _account_code;

        [DBField()]
        private decimal? _transaction_amount;

        [DBField()]
        private string _description;

        [DBField()]
        private string _drcr;

        [DBField()]
        private int? _trans1;

        [DBField()]
        private int? _trans2;

        public virtual string PbuCode
        {
            get
            {
                CanReadProperty("PbuCode", true);
                return _pbu_code;
            }
            set
            {
                CanWriteProperty("PbuCode", true);
                if (_pbu_code != value)
                {
                    _pbu_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AccountCode
        {
            get
            {
                CanReadProperty("AccountCode", true);
                return _account_code;
            }
            set
            {
                CanWriteProperty("AccountCode", true);
                if (_account_code != value)
                {
                    _account_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? TransactionAmount
        {
            get
            {
                CanReadProperty("TransactionAmount", true);
                return _transaction_amount;
            }
            set
            {
                CanWriteProperty("TransactionAmount", true);
                if (_transaction_amount != value)
                {
                    _transaction_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RETransactionAmount
        {
            get
            {
                return System.Convert.ToInt32( _transaction_amount);
            }
        }

        public virtual string Description
        {
            get
            {
                CanReadProperty("Description", true);
                return _description;
            }
            set
            {
                CanWriteProperty("Description", true);
                if (_description != value)
                {
                    _description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Drcr
        {
            get
            {
                CanReadProperty("Drcr", true);
                return _drcr;
            }
            set
            {
                CanWriteProperty("Drcr", true);
                if (_drcr != value)
                {
                    _drcr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Trans1
        {
            get
            {
                CanReadProperty("Trans1", true);
                return _trans1;
            }
            set
            {
                CanWriteProperty("Trans1", true);
                if (_trans1 != value)
                {
                    _trans1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RETrans1
        {
            get
            {
                return (int)_trans1;
            }
        }

        public virtual int? Trans2
        {
            get
            {
                CanReadProperty("Trans2", true);
                return _trans2;
            }
            set
            {
                CanWriteProperty("Trans2", true);
                if (_trans2 != value)
                {
                    _trans2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RETrans2
        {
            get
            {
                return (int)_trans2;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static GlAccrualsAudit NewGlAccrualsAudit(DateTime? ProcDate)
        {
            return Create(ProcDate);
        }

        public static GlAccrualsAudit[] GetAllGlAccrualsAudit(DateTime? ProcDate)
        {
            return Fetch(ProcDate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? ProcDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_gl_interface_for_accrualssummary";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ProcDate", ProcDate);

                    List<GlAccrualsAudit> _list = new List<GlAccrualsAudit>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            GlAccrualsAudit instance = new GlAccrualsAudit();
                            instance._pbu_code = GetValueFromReader<string>(dr, 0);
                            instance._account_code = GetValueFromReader<string>(dr, 1);
                            instance._transaction_amount = GetValueFromReader<decimal?>(dr, 2);
                            instance._description = GetValueFromReader<string>(dr, 3);
                            instance._drcr = GetValueFromReader<string>(dr, 4);
                            instance._trans1 = GetValueFromReader<int?>(dr, 5);
                            instance._trans2 = GetValueFromReader<int?>(dr, 6);
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
