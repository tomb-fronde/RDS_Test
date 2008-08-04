using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsPayrun
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("start_date", "_start_date", "")]
    [MapInfo("end_date", "_end_date", "")]
    [MapInfo("owner_driver", "_owner_driver", "")]
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
