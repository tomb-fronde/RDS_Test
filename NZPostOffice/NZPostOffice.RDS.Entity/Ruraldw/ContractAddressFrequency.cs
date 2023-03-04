using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  Jan-2011  Sequencing review: New
    // Interface to sp_GetAddressFrequency stored procedure

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("sf_key", "_sf_key", "")]
    [MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
    [MapInfo("rf_selected", "_rf_selected", "")]
    [MapInfo("rf_monday", "_rf_monday", "")]
    [MapInfo("rf_tuesday", "_rf_tuesday", "")]
    [MapInfo("rf_wednesday", "_rf_wednesday", "")]
    [MapInfo("rf_thursday", "_rf_thursday", "")]
    [MapInfo("rf_friday", "_rf_friday", "")]
    [MapInfo("rf_saturday", "_rf_saturday", "")]
    [MapInfo("rf_sunday", "_rf_sunday", "")]
    [MapInfo("rf_distance", "_rf_distance", "")]
    [MapInfo("adr_id", "_adr_id", "address_frequency")]
    [System.Serializable()]

    public class ContractAddressFrequency : Entity<ContractAddressFrequency>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _sf_key;

        [DBField()]
        private int? _adr_id;

        [DBField()]
        private string _rf_delivery_days;

        [DBField()]
        private string _rf_selected="Y";

        [DBField()]
        private string _rf_monday="N";

        [DBField()]
        private string _rf_tuesday="N";

        [DBField()]
        private string _rf_wednesday = "N";

        [DBField()]
        private string _rf_thursday = "N";

        [DBField()]
        private string _rf_friday = "N";

        [DBField()]
        private string _rf_saturday = "N";

        [DBField()]
        private string _rf_sunday = "N";

        [DBField()]
        private decimal? _rf_distance;

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

        public virtual int? AdrId
        {
            get
            {
                CanReadProperty("AdrId", true);
                return _adr_id;
            }
            set
            {
                CanWriteProperty("AdrId", true);
                if (_adr_id != value)
                {
                    _adr_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? SfKey
        {
            get
            {
                CanReadProperty("SfKey", true);
                return _sf_key;
            }
            set
            {
                CanWriteProperty("SfKey", true);
                if (_sf_key != value)
                {
                    _sf_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfDeliveryDays
        {
            get
            {
                CanReadProperty("RfDeliveryDays", true);
                return _rf_delivery_days;
            }
            set
            {
                CanWriteProperty("RfDeliveryDays", true);
                if (_rf_delivery_days != value)
                {
                    _rf_delivery_days = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfSelected
        {
            get
            {
                CanReadProperty("RfSelected", true);
                return _rf_selected;
            }
            set
            {
                CanWriteProperty("RfSelected", true);
                if (_rf_selected != value)
                {
                    _rf_selected = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfMonday
        {
            get
            {
                CanReadProperty("RfMonday", true);
                return _rf_monday;
            }
            set
            {
                CanWriteProperty("RfMonday", true);
                if (_rf_monday != value)
                {
                    _rf_monday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfTuesday
        {
            get
            {
                CanReadProperty("RfTuesday", true);
                return _rf_tuesday;
            }
            set
            {
                CanWriteProperty("RfTuesday", true);
                if (_rf_tuesday != value)
                {
                    _rf_tuesday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfWednesday
        {
            get
            {
                CanReadProperty("RfWednesday", true);
                return _rf_wednesday;
            }
            set
            {
                CanWriteProperty("RfWednesday", true);
                if (_rf_wednesday != value)
                {
                    _rf_wednesday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfThursday
        {
            get
            {
                CanReadProperty("RfThursday", true);
                return _rf_thursday;
            }
            set
            {
                CanWriteProperty("RfThursday", true);
                if (_rf_thursday != value)
                {
                    _rf_thursday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfFriday
        {
            get
            {
                CanReadProperty("RfFriday", true);
                return _rf_friday;
            }
            set
            {
                CanWriteProperty("RfFriday", true);
                if (_rf_friday != value)
                {
                    _rf_friday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfSaturday
        {
            get
            {
                CanReadProperty("RfSaturday", true);
                return _rf_saturday;
            }
            set
            {
                CanWriteProperty("RfSaturday", true);
                if (_rf_saturday != value)
                {
                    _rf_saturday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfSunday
        {
            get
            {
                CanReadProperty("RfSunday", true);
                return _rf_sunday;
            }
            set
            {
                CanWriteProperty("RfSunday", true);
                if (_rf_sunday != value)
                {
                    _rf_sunday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RfDistance
        {
            get
            {
                CanReadProperty("RfDistance", true);
                return _rf_distance;
            }
            set
            {
                CanWriteProperty("RfDistance", true);
                if (_rf_distance != value)
                {
                    _rf_distance = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[calc_deldays]
        //?rf_monday + rf_tuesday + rf_wednesday + rf_thursday + rf_friday + rf_saturday + rf_sunday
        public virtual string CalcDeldays
        {
            get
            {
                CanReadProperty("CalcDeldays", true);
                return _rf_monday + _rf_tuesday + _rf_wednesday + _rf_thursday + _rf_friday + _rf_saturday + _rf_sunday;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _contract_no, _sf_key, _rf_delivery_days);
        }
        #endregion

        #region Factory Methods
        public static ContractAddressFrequency NewContractAddressFrequency(int? in_Contract, int? in_AdrId)
        {
            return Create(in_Contract, in_AdrId);
        }

        public static ContractAddressFrequency[] GetAllContractAddressFrequency(int? in_Contract, int? in_AdrId)
        {
            return Fetch(in_Contract, in_AdrId).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract, int? in_AdrId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_contractno", in_Contract);
                    pList.Add(cm, "in_adrid", in_AdrId);
                    cm.CommandText = "sp_GetAddressFrequency";
                    List<ContractAddressFrequency> _list = new List<ContractAddressFrequency>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractAddressFrequency instance = new ContractAddressFrequency();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._sf_key = GetValueFromReader<Int32?>(dr, 1);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr, 2);
                            instance._rf_selected = GetValueFromReader<String>(dr, 3);
                            instance._rf_monday = GetValueFromReader<String>(dr, 4);
                            instance._rf_tuesday = GetValueFromReader<String>(dr, 5);
                            instance._rf_wednesday = GetValueFromReader<String>(dr, 6);
                            instance._rf_thursday = GetValueFromReader<String>(dr, 7);
                            instance._rf_friday = GetValueFromReader<String>(dr, 8);
                            instance._rf_saturday = GetValueFromReader<String>(dr, 9);
                            instance._rf_sunday = GetValueFromReader<String>(dr, 10);
                            instance._rf_distance = GetValueFromReader<Decimal?>(dr, 11);
                            instance._adr_id = in_AdrId;
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
                int? initial_contract_no = GetInitialValue<int?>("_contract_no");
                int? initial_adr_id = GetInitialValue<int?>("_adr_id");
                int? initial_sf_key = GetInitialValue<int?>("_sf_key");
                string initial_rf_delivery_days = GetInitialValue<string>("_rf_delivery_days");
                string initial_rf_selected = GetInitialValue<string>("_rf_selected");

                int? t;
                t = initial_adr_id;
                t = initial_sf_key;
                t = initial_contract_no;
                string s;
                s = initial_rf_delivery_days;
                s = initial_rf_selected;

                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();

                if (initial_rf_selected == "N" && _rf_selected == "Y")
                {
                    cm.CommandText = " INSERT INTO address_frequency "
                                    + "    (adr_id, sf_key, rf_delivery_days, contract_no) "
                                    + "VALUES"
                                    + "    (@adr_id, @sf_key, @rf_delivery_days, @contract_no) "
                                    ;
                }
                else if (initial_rf_selected == "Y" && _rf_selected == "N")
                {
                    cm.CommandText = " DELETE FROM address_frequency "
                                    + " WHERE  address_frequency.contract_no = @contract_no "
                                    + "   AND address_frequency.adr_id = @adr_id"
                                    + "   AND address_frequency.sf_key = @sf_key"
                                    + "   AND address_frequency.rf_delivery_days = @rf_delivery_days"
                                    ;
//                    cm.CommandText = " UPDATE address_frequency "
//                                    + "   SET address_frequency.rf_selected = @rf_selected "
//                                    + " WHERE  address_frequency.contract_no = @contract_no "
//                                    + "   AND address_frequency.adr_id = @adr_id"
//                                    + "   AND address_frequency.sf_key = @sf_key"
//                                    + "   AND address_frequency.rf_delivery_days = @rf_delivery_days"
//                                    ;
                }

                pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
                pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));
                pList.Add(cm, "rf_selected", _rf_selected);

                try
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                    // reinitialize original key/value list
                    // StoreInitialValues();
                }
                catch (Exception e)
                {
                    string errmsg = e.Message;
                    string ss = errmsg;
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no, int? sf_key, string rf_delivery_days)
        {
            _contract_no = contract_no;
            _sf_key = sf_key;
            _rf_delivery_days = rf_delivery_days;
        }
    }
}
