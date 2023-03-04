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
    [MapInfo("sf_key", "_sf_key", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("mc_sequence_no", "_mc_sequence_no", "")]
    [MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
    [MapInfo("mc_dispatch_carried", "_mc_dispatch_carried", "")]
    [MapInfo("mc_uplift_time", "_mc_uplift_time", "")]
    [MapInfo("mc_uplift_outlet", "_mc_uplift_outlet", "")]
    [MapInfo("mc_uplift_outlet_name", "_mc_uplift_outlet_name", "")]
    [MapInfo("mc_set_down_time", "_mc_set_down_time", "")]
    [MapInfo("mc_set_down_outlet", "_mc_set_down_outlet", "")]
    [MapInfo("mc_set_down_outlet_name", "_mc_set_down_outlet_name", "")]
    [MapInfo("mc_disbanded_date", "_mc_disbanded_date", "")]
    [MapInfo("uplift_picklist", "_uplift_picklist", "")]
    [MapInfo("setdown_picklist", "_setdown_picklist", "")]
    [System.Serializable()]

    public class MailCarried : Entity<MailCarried>
    {
        #region Business Methods
        [DBField()]
        private int? _sf_key;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _mc_sequence_no;

        [DBField()]
        private string _rf_delivery_days;

        [DBField()]
        private string _mc_dispatch_carried;

        [DBField()]
        private DateTime? _mc_uplift_time;

        [DBField()]
        private int? _mc_uplift_outlet;

        [DBField()]
        private string _mc_uplift_outlet_name;

        [DBField()]
        private DateTime? _mc_set_down_time;

        [DBField()]
        private int? _mc_set_down_outlet;

        [DBField()]
        private string _mc_set_down_outlet_name;

        [DBField()]
        private DateTime? _mc_disbanded_date;

        [DBField()]
        private int? _uplift_picklist;

        [DBField()]
        private int? _setdown_picklist;


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

        public virtual int? McSequenceNo
        {
            get
            {
                CanReadProperty("McSequenceNo", true);
                return _mc_sequence_no;
            }
            set
            {
                CanWriteProperty("McSequenceNo", true);
                if (_mc_sequence_no != value)
                {
                    _mc_sequence_no = value;
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

        public virtual string McDispatchCarried
        {
            get
            {
                CanReadProperty("McDispatchCarried", true);
                return _mc_dispatch_carried;
            }
            set
            {
                CanWriteProperty("McDispatchCarried", true);
                if (_mc_dispatch_carried != value)
                {
                    _mc_dispatch_carried = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? McUpliftTime
        {
            get
            {
                CanReadProperty("McUpliftTime", true);
                return _mc_uplift_time;
            }
            set
            {
                CanWriteProperty("McUpliftTime", true);
                if (_mc_uplift_time != value)
                {
                    _mc_uplift_time = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? McUpliftOutlet
        {
            get
            {
                CanReadProperty("McUpliftOutlet", true);
                return _mc_uplift_outlet;
            }
            set
            {
                CanWriteProperty("McUpliftOutlet", true);
                if (_mc_uplift_outlet != value)
                {
                    _mc_uplift_outlet = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string McUpliftOutletName
        {
            get
            {
                CanReadProperty("McUpliftOutletName", true);
                return _mc_uplift_outlet_name;
            }
            set
            {
                CanWriteProperty("McUpliftOutletName", true);
                if (_mc_uplift_outlet_name != value)
                {
                    _mc_uplift_outlet_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? McSetDownTime
        {
            get
            {
                CanReadProperty("McSetDownTime", true);
                return _mc_set_down_time;
            }
            set
            {
                CanWriteProperty("McSetDownTime", true);
                if (_mc_set_down_time != value)
                {
                    _mc_set_down_time = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? McSetDownOutlet
        {
            get
            {
                CanReadProperty("McSetDownOutlet", true);
                return _mc_set_down_outlet;
            }
            set
            {
                CanWriteProperty("McSetDownOutlet", true);
                if (_mc_set_down_outlet != value)
                {
                    _mc_set_down_outlet = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string McSetDownOutletName
        {
            get
            {
                CanReadProperty("McSetDownOutletName", true);
                return _mc_set_down_outlet_name;
            }
            set
            {
                CanWriteProperty("McSetDownOutletName", true);
                if (_mc_set_down_outlet_name != value)
                {
                    _mc_set_down_outlet_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? McDisbandedDate
        {
            get
            {
                CanReadProperty("McDisbandedDate", true);
                return _mc_disbanded_date;
            }
            set
            {
                CanWriteProperty("McDisbandedDate", true);
                if (_mc_disbanded_date != value)
                {
                    _mc_disbanded_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? UpliftPicklist
        {
            get
            {
                CanReadProperty("UpliftPicklist", true);
                return _uplift_picklist;
            }
            set
            {
                CanWriteProperty("UpliftPicklist", true);
                if (_uplift_picklist != value)
                {
                    _uplift_picklist = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? SetdownPicklist
        {
            get
            {
                CanReadProperty("SetdownPicklist", true);
                return _setdown_picklist;
            }
            set
            {
                CanWriteProperty("SetdownPicklist", true);
                if (_setdown_picklist != value)
                {
                    _setdown_picklist = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}/{3}", _sf_key, _contract_no, _mc_sequence_no, _rf_delivery_days);
        }
        #endregion

        #region Factory Methods
        public static MailCarried NewMailCarried(int? inContract, int? inSFKey, string inDeliveryDays)
        {
            return Create(inContract, inSFKey, inDeliveryDays);
        }

        public static MailCarried[] GetAllMailCarried(int? inContract, int? inSFKey, string inDeliveryDays)
        {
            return Fetch(inContract, inSFKey, inDeliveryDays).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inContract, int? inSFKey, string inDeliveryDays)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContract", inContract);
                    pList.Add(cm, "inSFKey", inSFKey);
                    pList.Add(cm, "inDeliveryDays", inDeliveryDays);
                    cm.CommandText = "sp_GetMailCarried";

                    List<MailCarried> _list = new List<MailCarried>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            MailCarried instance = new MailCarried();
                            instance._sf_key = GetValueFromReader<Int32?>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._mc_sequence_no = GetValueFromReader<Int32?>(dr, 2);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr, 3);
                            instance._mc_dispatch_carried = GetValueFromReader<String>(dr, 4);
                            instance._mc_uplift_time = GetValueFromReader<DateTime>(dr, 5);
                            instance._mc_uplift_outlet = GetValueFromReader<Int32?>(dr, 6);
                            instance._mc_uplift_outlet_name = GetValueFromReader<String>(dr, 7);
                            instance._mc_set_down_time = GetValueFromReader<DateTime>(dr, 8);
                            instance._mc_set_down_outlet = GetValueFromReader<Int32?>(dr, 9);
                            instance._mc_set_down_outlet_name = GetValueFromReader<String>(dr, 10);
                            instance._mc_disbanded_date = GetValueFromReader<DateTime?>(dr, 11);
                            instance._uplift_picklist = GetValueFromReader<Int32?>(dr, 12);
                            instance._setdown_picklist = GetValueFromReader<Int32?>(dr, 13);
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
        private void CreateEntity(int? sf_key, int? contract_no, int? mc_sequence_no, string rf_delivery_days)
        {
            _sf_key = sf_key;
            _contract_no = contract_no;
            _mc_sequence_no = mc_sequence_no;
            _rf_delivery_days = rf_delivery_days;
        }
    }
}
