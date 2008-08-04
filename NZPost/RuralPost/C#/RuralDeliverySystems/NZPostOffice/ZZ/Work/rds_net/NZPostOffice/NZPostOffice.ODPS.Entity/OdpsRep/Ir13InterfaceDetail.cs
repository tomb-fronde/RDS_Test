using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("owner_driver_ird_number", "_owner_driver_ird_number", "")]
    [MapInfo("owner_driver_name", "_owner_driver_name", "")]
    [MapInfo("owner_driver_address", "_owner_driver_address", "")]

    [MapInfo("owner_driver_gst_number", "_owner_driver_gst_number", "")]
    [MapInfo("contract_id", "_contract_id", "")]
    [MapInfo("tax", "_tax", "")]

    [MapInfo("gross_pay", "_gross_pay", "")]
    [MapInfo("start_date", "_start_date", "")]
    [MapInfo("end_date", "_end_date", "")]
    [MapInfoIndex(new string[] { 
        "owner_driver_ird_number", "owner_driver_name", "owner_driver_address", 
        "owner_driver_gst_number", "contract_id", "tax",
        "gross_pay", "start_date", "end_date" })]
    [System.Serializable()]

    public class Ir13InterfaceDetail : Entity<Ir13InterfaceDetail>
    {
        #region Business Methods
        [DBField()]
        private string _owner_driver_ird_number;

        [DBField()]
        private string _owner_driver_name;

        [DBField()]
        private string _owner_driver_address;

        [DBField()]
        private string _owner_driver_gst_number;

        [DBField()]
        private int? _contract_id;

        [DBField()]
        private decimal? _tax;

        [DBField()]
        private decimal? _gross_pay;

        [DBField()]
        private DateTime? _start_date;

        [DBField()]
        private DateTime? _end_date;

        public virtual string OwnerDriverIrdNumber
        {
            get
            {
                CanReadProperty("OwnerDriverIrdNumber", true);
                return _owner_driver_ird_number;
            }
            set
            {
                CanWriteProperty("OwnerDriverIrdNumber", true);
                if (_owner_driver_ird_number != value)
                {
                    _owner_driver_ird_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OwnerDriverName
        {
            get
            {
                CanReadProperty("OwnerDriverName", true);
                return _owner_driver_name;
            }
            set
            {
                CanWriteProperty("OwnerDriverName", true);
                if (_owner_driver_name != value)
                {
                    _owner_driver_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OwnerDriverAddress
        {
            get
            {
                CanReadProperty("OwnerDriverAddress", true);
                return _owner_driver_address;
            }
            set
            {
                CanWriteProperty("OwnerDriverAddress", true);
                if (_owner_driver_address != value)
                {
                    _owner_driver_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OwnerDriverGstNumber
        {
            get
            {
                CanReadProperty("OwnerDriverGstNumber", true);
                return _owner_driver_gst_number;
            }
            set
            {
                CanWriteProperty("OwnerDriverGstNumber", true);
                if (_owner_driver_gst_number != value)
                {
                    _owner_driver_gst_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ContractId
        {
            get
            {
                CanReadProperty("ContractId", true);
                return _contract_id;
            }
            set
            {
                CanWriteProperty("ContractId", true);
                if (_contract_id != value)
                {
                    _contract_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Tax
        {
            get
            {
                CanReadProperty("Tax", true);
                return _tax;
            }
            set
            {
                CanWriteProperty("Tax", true);
                if (_tax != value)
                {
                    _tax = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? GrossPay
        {
            get
            {
                CanReadProperty("GrossPay", true);
                return _gross_pay;
            }
            set
            {
                CanWriteProperty("GrossPay", true);
                if (_gross_pay != value)
                {
                    _gross_pay = value;
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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static Ir13InterfaceDetail NewIr13InterfaceDetail(DateTime? StartDate, DateTime? EndDate)
        {
            return Create(StartDate, EndDate);
        }

        public static Ir13InterfaceDetail[] GetAllIr13InterfaceDetail(DateTime? StartDate, DateTime? EndDate)
        {
            return Fetch(StartDate, EndDate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? StartDate, DateTime? EndDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_ir13_interface_detail";
                    cm.CommandTimeout = 100;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "StartDate", StartDate);
                    pList.Add(cm, "EndDate", EndDate);

                    List<Ir13InterfaceDetail> _list = new List<Ir13InterfaceDetail>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Ir13InterfaceDetail instance = new Ir13InterfaceDetail();
                            instance.OwnerDriverIrdNumber = GetValueFromReader<string>(dr, 0);
                            instance.OwnerDriverName = GetValueFromReader<string>(dr, 1);
                            instance.OwnerDriverAddress = GetValueFromReader<string>(dr, 2);
                            instance.OwnerDriverGstNumber = GetValueFromReader<string>(dr, 3);
                            instance.ContractId = GetValueFromReader<Int32?>(dr, 4);
                            instance.Tax = GetValueFromReader<decimal?>(dr, 5);
                            instance.GrossPay = GetValueFromReader<decimal?>(dr, 6);
                            instance.StartDate = GetValueFromReader<DateTime?>(dr, 7);
                            instance.EndDate = GetValueFromReader<DateTime?>(dr, 8);
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
