using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin2
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "route_frequency")]
    [MapInfo("sf_key", "_sf_key", "route_frequency")]
    [MapInfo("rf_delivery_days", "_rf_delivery_days", "route_frequency")]
    [MapInfo("rf_active", "_rf_active", "route_frequency")]
    [MapInfo("rf_distance", "_rf_distance", "route_frequency")]
    [System.Serializable()]

    public class RouteFrequency : Entity<RouteFrequency>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _sf_key;

        [DBField()]
        private string _rf_delivery_days;

        [DBField()]
        private string _rf_active;

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

        public virtual string RfActive
        {
            get
            {
                CanReadProperty("RfActive", true);
                return _rf_active;
            }
            set
            {
                CanWriteProperty("RfActive", true);
                if (_rf_active != value)
                {
                    _rf_active = value;
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

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _contract_no, _sf_key, _rf_delivery_days);
        }
        #endregion

        #region Factory Methods
        public static RouteFrequency NewRouteFrequency(int? inContract)
        {
            return Create(inContract);
        }

        public static RouteFrequency[] GetAllRouteFrequency(int? inContract)
        {
            return Fetch(inContract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContract", inContract);
                    cm.CommandText = " SELECT route_frequency.contract_no," +
                        "route_frequency.sf_key, " +
                        "route_frequency.rf_delivery_days, " +
                        "route_frequency.rf_active, " +
                        "route_frequency.rf_distance " +
                        " FROM route_frequency  " +
                        " WHERE route_frequency.contract_no = @inContract ";

                    List<RouteFrequency> _list = new List<RouteFrequency>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RouteFrequency instance = new RouteFrequency();
                            instance._contract_no = GetValueFromReader<int?>(dr, 0);
                            instance._sf_key = GetValueFromReader<int?>(dr, 1);
                            instance._rf_delivery_days = GetValueFromReader<string>(dr, 2);
                            instance._rf_active = GetValueFromReader<string>(dr, 3);
                            instance._rf_distance = GetValueFromReader<decimal?>(dr, 4);
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
                if (GenerateUpdateCommandText(cm, "route_frequency", ref pList))
                {
                    cm.CommandText += " WHERE  route_frequency.contract_no = @contract_no AND " +
                        "route_frequency.sf_key = @sf_key AND " +
                        "route_frequency.rf_delivery_days = @rf_delivery_days ";

                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));
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
                if (GenerateInsertCommandText(cm, "route_frequency", pList))
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
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));
                    cm.CommandText = "DELETE FROM route_frequency WHERE " +
                    "route_frequency.contract_no = @contract_no AND " +
                    "route_frequency.sf_key = @sf_key AND " +
                    "route_frequency.rf_delivery_days = @rf_delivery_days ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
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
