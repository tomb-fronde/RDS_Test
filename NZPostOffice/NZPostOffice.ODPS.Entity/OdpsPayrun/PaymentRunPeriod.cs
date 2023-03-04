using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsPayrun
{
    // TJB  RPCR_139 Bugfix July-2019
    // Changed contract_no et al to string
    //
    // TJB  RPCR_141  June-2019
    // Added ContractNo, RgCode and associated _contract_no and _rg_code variables

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("start_date", "_start_date", "")]
    [MapInfo("end_date", "_end_date", "")]
    [MapInfo("owner_driver", "_owner_driver", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("rg_code", "_rg_code", "")]

    [System.Serializable()]

    public class PaymentRunPeriod : Entity<PaymentRunPeriod>
    {

        #region Business Methods
        [DBField()]
        private DateTime? _start_date;

        [DBField()]
        private DateTime? _end_date;

        [DBField()]
        private string _owner_driver;

        [DBField()]
        private string _contract_no;

        [DBField()]
        private int? _rg_code;

        public virtual DateTime? StartDate
        {
            get
            {
                CanReadProperty("StartDate", true);
                return _start_date;
            }
            set
            {
                CanWriteProperty("StartDate", true);
                if (_start_date != value)
                {
                    _start_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? EndDate
        {
            get
            {
                CanReadProperty("EndDate", true);
                return _end_date;
            }
            set
            {
                CanWriteProperty("EndDate", true);
                if (_end_date != value)
                {
                    _end_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OwnerDriver
        {
            get
            {
                CanReadProperty("OwnerDriver", true);
                return _owner_driver;
            }
            set
            {
                CanWriteProperty("OwnerDriver", true);
                if (_owner_driver != value)
                {
                    _owner_driver = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractNo
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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static PaymentRunPeriod NewPaymentRunPeriod()
        {
            return Create();
        }

        public static PaymentRunPeriod[] GetAllPaymentRunPeriod()
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

                    List<PaymentRunPeriod> _list = new List<PaymentRunPeriod>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PaymentRunPeriod instance = new PaymentRunPeriod();
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
