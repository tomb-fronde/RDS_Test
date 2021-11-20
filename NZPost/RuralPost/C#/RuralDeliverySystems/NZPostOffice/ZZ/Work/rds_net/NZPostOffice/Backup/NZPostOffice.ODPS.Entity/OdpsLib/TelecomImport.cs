using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsLib
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("bill_month", "_bill_month", "")]
    [MapInfo("bill_cycle", "_bill_cycle", "")]
    [MapInfo("cust_no", "_cust_no", "")]
    [MapInfo("account_no", "_account_no", "")]
    [MapInfo("account_name", "_account_name", "")]
    [MapInfo("open_bal", "_open_bal", "")]
    [MapInfo("payments", "_payments", "")]
    [MapInfo("adj_tran", "_adj_tran", "")]
    [MapInfo("bal_bf", "_bal_bf", "")]
    [MapInfo("curr_chg", "_curr_chg", "")]
    [MapInfo("total_due", "_total_due", "")]
    [MapInfo("supplier_no", "_supplier_no", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [System.Serializable()]

    public class TelecomImport : Entity<TelecomImport>
    {
        #region Business Methods
        [DBField()]
        private string _bill_month;

        [DBField()]
        private int? _bill_cycle;

        [DBField()]
        private int? _cust_no;

        [DBField()]
        private int? _account_no;

        [DBField()]
        private string _account_name;

        [DBField()]
        private decimal? _open_bal;

        [DBField()]
        private decimal? _payments;

        [DBField()]
        private decimal? _adj_tran;

        [DBField()]
        private decimal? _bal_bf;

        [DBField()]
        private decimal? _curr_chg;

        [DBField()]
        private decimal? _total_due;

        [DBField()]
        private int? _supplier_no;

        [DBField()]
        private int? _contract_no;

        public virtual string BillMonth
        {
            get
            {
                CanReadProperty("BillMonth", true);
                return _bill_month;
            }
            set
            {
                CanWriteProperty("BillMonth", true);
                if (_bill_month != value)
                {
                    _bill_month = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? BillCycle
        {
            get
            {
                CanReadProperty("BillCycle", true);
                return _bill_cycle;
            }
            set
            {
                CanWriteProperty("BillCycle", true);
                if (_bill_cycle != value)
                {
                    _bill_cycle = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustNo
        {
            get
            {
                CanReadProperty("CustNo", true);
                return _cust_no;
            }
            set
            {
                CanWriteProperty("CustNo", true);
                if (_cust_no != value)
                {
                    _cust_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AccountNo
        {
            get
            {
                CanReadProperty("AccountNo", true);
                return _account_no;
            }
            set
            {
                CanWriteProperty("AccountNo", true);
                if (_account_no != value)
                {
                    _account_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AccountName
        {
            get
            {
                CanReadProperty("AccountName", true);
                return _account_name;
            }
            set
            {
                CanWriteProperty("AccountName", true);
                if (_account_name != value)
                {
                    _account_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? OpenBal
        {
            get
            {
                CanReadProperty("OpenBal", true);
                return _open_bal;
            }
            set
            {
                CanWriteProperty("OpenBal", true);
                if (_open_bal != value)
                {
                    _open_bal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Payments
        {
            get
            {
                CanReadProperty("Payments", true);
                return _payments;
            }
            set
            {
                CanWriteProperty("Payments", true);
                if (_payments != value)
                {
                    _payments = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? AdjTran
        {
            get
            {
                CanReadProperty("AdjTran", true);
                return _adj_tran;
            }
            set
            {
                CanWriteProperty("AdjTran", true);
                if (_adj_tran != value)
                {
                    _adj_tran = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? BalBf
        {
            get
            {
                CanReadProperty("BalBf", true);
                return _bal_bf;
            }
            set
            {
                CanWriteProperty("BalBf", true);
                if (_bal_bf != value)
                {
                    _bal_bf = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CurrChg
        {
            get
            {
                CanReadProperty("CurrChg", true);
                return _curr_chg;
            }
            set
            {
                CanWriteProperty("CurrChg", true);
                if (_curr_chg != value)
                {
                    _curr_chg = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? TotalDue
        {
            get
            {
                CanReadProperty("TotalDue", true);
                return _total_due;
            }
            set
            {
                CanWriteProperty("TotalDue", true);
                if (_total_due != value)
                {
                    _total_due = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? SupplierNo
        {
            get
            {
                CanReadProperty("SupplierNo", true);
                return _supplier_no;
            }
            set
            {
                CanWriteProperty("SupplierNo", true);
                if (_supplier_no != value)
                {
                    _supplier_no = value;
                    PropertyHasChanged();
                }
            }
        }

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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static TelecomImport NewTelecomImport()
        {
            return Create();
        }

        public static TelecomImport[] GetAllTelecomImport()
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
                    ParameterCollection pList = new ParameterCollection();

                    List<TelecomImport> _list = new List<TelecomImport>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            TelecomImport instance = new TelecomImport();
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
