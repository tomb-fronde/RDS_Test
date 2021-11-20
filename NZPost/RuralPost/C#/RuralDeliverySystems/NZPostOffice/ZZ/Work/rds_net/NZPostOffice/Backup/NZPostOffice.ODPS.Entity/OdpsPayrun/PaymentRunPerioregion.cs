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
    [MapInfo("region_id", "_region_id", "rd.region")]
    [MapInfo("start_date", "_start_date", "rd.region")]
    [MapInfo("end_date", "_end_date", "rd.region")]
    [MapInfo("c_surname_company", "_owner_driver", "rd.contractor")]
    [System.Serializable()]

    public class PaymentRunPeriodRegion : Entity<PaymentRunPeriodRegion>
    {

        #region Business Methods
        [DBField()]
        private int? _region_id;

        [DBField()]
        private DateTime? _start_date;

        [DBField()]
        private DateTime? _end_date;

        [DBField()]
        private string _owner_driver;

        public virtual int? RegionId
        {
            get
            {
                CanReadProperty("RegionId", true);
                return _region_id;
            }
            set
            {
                CanWriteProperty("RegionId", true);
                if (_region_id != value)
                {
                    _region_id = value;
                    PropertyHasChanged();
                }
            }
        }

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
        public static PaymentRunPeriodRegion NewPaymentRunPeriodRegion()
        {
            return Create();
        }

        public static PaymentRunPeriodRegion[] GetAllPaymentRunPeriodRegion()
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
                    cm.CommandText = "  SELECT rd.region.region_id," +
                                     "CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME) start_date," +
                                     "CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME) end_date," +
                                     "rd.contractor.c_surname_company " +
                                     "FROM rd.region, " +
                                     "rd.contractor";
                    ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "rd.region");
                    //GenerateSelectCommandText(cm, "rd.contractor");

                    List<PaymentRunPeriodRegion> _list = new List<PaymentRunPeriodRegion>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PaymentRunPeriodRegion instance = new PaymentRunPeriodRegion();
                            //instance.StoreFieldValues(dr, "rd.region");
                            //instance.StoreFieldValues(dr, "rd.contractor");
                            instance._region_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._start_date = GetValueFromReader<DateTime?>(dr, 1);
                            instance._end_date = GetValueFromReader<DateTime?>(dr, 2);
                            instance._owner_driver = GetValueFromReader<string>(dr, 3);
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
