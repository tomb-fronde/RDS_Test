using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("region", "_region", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("owner_driver", "_owner_driver", "")]
    [MapInfo("day_phone", "_day_phone", "")]
    [MapInfo("night_phone", "_night_phone", "")]
    [MapInfo("cell_phone", "_cell_phone", "")]
    [MapInfo("list_printed", "_list_printed", "")]
    [MapInfo("list_updated", "_list_updated", "")]
    [System.Serializable()]

    public class OutValList : Entity<OutValList>
    {
        #region Business Methods
        [DBField()]
        private string _region;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _owner_driver;

        [DBField()]
        private string _day_phone;

        [DBField()]
        private string _night_phone;

        [DBField()]
        private string _cell_phone;

        [DBField()]
        private DateTime? _list_printed;

        [DBField()]
        private DateTime? _list_updated;

        public virtual string Region
        {
            get
            {
                CanReadProperty("Region", true);
                return _region;
            }
            set
            {
                CanWriteProperty("Region", true);
                if (_region != value)
                {
                    _region = value;
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

        public virtual int? REContractNo
        {
            get
            {
                return _contract_no;
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

        public virtual string DayPhone
        {
            get
            {
                CanReadProperty("DayPhone", true);
                return _day_phone;
            }
            set
            {
                CanWriteProperty("DayPhone", true);
                if (_day_phone != value)
                {
                    _day_phone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NightPhone
        {
            get
            {
                CanReadProperty("NightPhone", true);
                return _night_phone;
            }
            set
            {
                CanWriteProperty("NightPhone", true);
                if (_night_phone != value)
                {
                    _night_phone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CellPhone
        {
            get
            {
                CanReadProperty("CellPhone", true);
                return _cell_phone;
            }
            set
            {
                CanWriteProperty("CellPhone", true);
                if (_cell_phone != value)
                {
                    _cell_phone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ListPrinted
        {
            get
            {
                CanReadProperty("ListPrinted", true);
                return _list_printed;
            }
            set
            {
                CanWriteProperty("ListPrinted", true);
                if (_list_printed != value)
                {
                    _list_printed = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? REListPrinted
        {
            get
            {
                return _list_printed;
            }
        }

        public virtual DateTime? ListUpdated
        {
            get
            {
                CanReadProperty("ListUpdated", true);
                return _list_updated;
            }
            set
            {
                CanWriteProperty("ListUpdated", true);
                if (_list_updated != value)
                {
                    _list_updated = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? REListUpdated
        {
            get
            {
                return _list_updated;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static OutValList NewOutValList()
        {
            return Create();
        }

        public static OutValList[] GetAllOutValList()
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
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_out_val_list";
                    ParameterCollection pList = new ParameterCollection();

                    List<OutValList> _list = new List<OutValList>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            OutValList instance = new OutValList();
                            instance._region = GetValueFromReader<string>(dr, 0);
                            instance._contract_no = GetValueFromReader<int?>(dr, 1);
                            instance._owner_driver = GetValueFromReader<string>(dr, 2);
                            instance._day_phone = GetValueFromReader<string>(dr, 3);
                            instance._night_phone = GetValueFromReader<string>(dr, 4);
                            instance._cell_phone = GetValueFromReader<string>(dr, 5);
                            instance._list_printed = GetValueFromReader<DateTime?>(dr, 6);
                            instance._list_updated = GetValueFromReader<DateTime?>(dr, 7);
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
