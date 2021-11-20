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
    [MapInfo("cust_surname_company", "_rds_customer_cust_surname_company", "rds_customer")]
    [MapInfo("cust_initials", "_rds_customer_cust_initials", "rds_customer")]
    [MapInfo("cust_title", "_rds_cust_title", "rds_customer")]
    [MapInfo("master_cust_id", "_master_cust_id", "rds_customer")]
    [MapInfo("primary_ind", "_primary_ind", "")]
    [MapInfo("cust_id", "_cust_id", "customer_address_moves")]
    [MapInfo("move_in_date", "_move_in_date", "customer_address_moves")]
    [MapInfo("adr_id", "_adr_id", "customer_address_moves")]
    [MapInfo("move_out_date", "_move_out_date", "customer_address_moves")]
    [System.Serializable()]

    public class AddressOccupantsMovement : Entity<AddressOccupantsMovement>
    {
        #region Business Methods
        [DBField()]
        private string _rds_customer_cust_surname_company;

        [DBField()]
        private string _rds_customer_cust_initials;

        [DBField()]
        private string _rds_cust_title;

        [DBField()]
        private int? _master_cust_id;

        [DBField()]
        private int? _primary_ind;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private DateTime? _move_in_date;

        [DBField()]
        private int? _adr_id;

        [DBField()]
        private DateTime? _move_out_date;

        public virtual string RDSCustomerCustSurnameCompany
        {
            get
            {
                CanReadProperty("RDSCustomerCustSurnameCompany", true);
                return _rds_customer_cust_surname_company;
            }
            set
            {
                CanWriteProperty("RDSCustomerCustSurnameCompany", true);
                if (_rds_customer_cust_surname_company != value)
                {
                    _rds_customer_cust_surname_company = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RDSCustomerCustInitials
        {
            get
            {
                CanReadProperty("RDSCustomerCustInitials", true);
                return _rds_customer_cust_initials;
            }
            set
            {
                CanWriteProperty("RDSCustomerCustInitials", true);
                if (_rds_customer_cust_initials != value)
                {
                    _rds_customer_cust_initials = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RDSCustTitle
        {
            get
            {
                CanReadProperty("RDSCustTitle", true);
                return _rds_cust_title;
            }
            set
            {
                CanWriteProperty("RDSCustTitle", true);
                if (_rds_cust_title != value)
                {
                    _rds_cust_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? MasterCustId
        {
            get
            {
                CanReadProperty("MasterCustId", true);
                return _master_cust_id;
            }
            set
            {
                CanWriteProperty("MasterCustId", true);
                if (_master_cust_id != value)
                {
                    _master_cust_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrimaryInd
        {
            get
            {
                CanReadProperty("PrimaryInd", true);
                return _primary_ind;
            }
            set
            {
                CanWriteProperty("PrimaryInd", true);
                if (_primary_ind != value)
                {
                    _primary_ind = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustId
        {
            get
            {
                CanReadProperty("CustId", true);
                return _cust_id;
            }
            set
            {
                CanWriteProperty("CustId", true);
                if (_cust_id != value)
                {
                    _cust_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? MoveInDate
        {
            get
            {
                CanReadProperty("MoveInDate", true);
                return _move_in_date;
            }
            set
            {
                CanWriteProperty("MoveInDate", true);
                if (_move_in_date != value)
                {
                    _move_in_date = value;
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

        public virtual DateTime? MoveOutDate
        {
            get
            {
                CanReadProperty("MoveOutDate", true);
                return _move_out_date;
            }
            set
            {
                CanWriteProperty("MoveOutDate", true);
                if (_move_out_date != value)
                {
                    _move_out_date = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _cust_id, _adr_id);
        }
        #endregion

        #region Factory Methods
        public static AddressOccupantsMovement NewAddressOccupantsMovement(int? al_adr_id)
        {
            return Create(al_adr_id);
        }

        public static AddressOccupantsMovement[] GetAllAddressOccupantsMovement(int? al_adr_id)
        {
            return Fetch(al_adr_id).list;
        }

        public static AddressOccupantsMovement[] GetAllAddressOccupantsData(int? dpid, bool type)
        {
            return Fetch(dpid, true).list;
        }

        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_adr_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = @"SELECT rds_customer.cust_surname_company,
                                              rds_customer.cust_initials,
                                              rds_customer.master_cust_id,
                                              primary_ind =   case when rds_customer.master_cust_id is null then 1 else 0 end,
                                              rds_customer.cust_id,
                                              customer_address_moves.move_in_date,
                                              customer_address_moves.adr_id,
                                              customer_address_moves.move_out_date
                                         FROM customer_address_moves,  rds_customer
                                        WHERE ( rds_customer.cust_id = customer_address_moves.cust_id ) 
                                         AND  ( ( customer_address_moves.adr_id = @al_adr_id ) ) 
                                         AND  customer_address_moves.move_out_date is null";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_adr_id", al_adr_id);

                    List<AddressOccupantsMovement> _list = new List<AddressOccupantsMovement>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddressOccupantsMovement instance = new AddressOccupantsMovement();
                            instance._rds_customer_cust_surname_company = GetValueFromReader<String>(dr, 0);
                            instance._rds_customer_cust_initials = GetValueFromReader<String>(dr, 1);
                            instance._master_cust_id = GetValueFromReader<Int32?>(dr, 2);
                            instance._primary_ind = GetValueFromReader<Int32?>(dr, 3);
                            instance._cust_id = GetValueFromReader<Int32?>(dr, 4);

                            instance._move_in_date = GetValueFromReader<DateTime?>(dr, 5);
                            instance._adr_id = GetValueFromReader<Int32?>(dr, 6);
                            instance._move_out_date = GetValueFromReader<DateTime?>(dr, 7);

                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }                       
                        list = _list.ToArray();                       
                    }
                }
            }
        }

        [ServerMethod]
        private void FetchEntity(int? al_adr_id, bool type)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = @"select cust_surname_company,cust_initials,cust_title into @surname,
                                            @initials,
                                            @title from customer_address_moves as cam,rds_customer as c where
                                            cam.dp_id = @dpid and
                                            cam.move_out_date is null and
                                            c.cust_id = cam.cust_id;";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_adr_id", al_adr_id);

                    List<AddressOccupantsMovement> _list = new List<AddressOccupantsMovement>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddressOccupantsMovement instance = new AddressOccupantsMovement();
                            instance._rds_customer_cust_surname_company = GetValueFromReader<String>(dr, 0);
                            instance._rds_customer_cust_initials = GetValueFromReader<String>(dr, 1);
                            instance._rds_cust_title = GetValueFromReader<String>(dr, 2);                           

                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        if (_list.Count > 0)
                        {
                            list = _list.ToArray();
                        }
                        else
                        {
                            list = null;
                        }
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
                if (GenerateUpdateCommandText(cm, "customer_address_moves", ref pList))
                {
                    cm.CommandText += " WHERE  customer_address_moves.cust_id = @cust_id AND " +
                        "customer_address_moves.adr_id = @adr_id ";

                    pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
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
                cm.CommandText = cm.CommandText = "insert into customer_address_moves ( adr_id, cust_id, dp_id, move_in_date, move_out_date, move_out_source, move_out_user ) " +
                        "values ( @adr_id, @cust_id, NULL,@move_in_date, @move_out_date, NULL, NULL )";
                pList.Add(cm, "cust_id", _cust_id);
                pList.Add(cm, "adr_id",_adr_id);
                pList.Add(cm, "move_in_date", _move_in_date);
                pList.Add(cm, "move_out_date", _move_out_date);
                //if (GenerateInsertCommandText(cm, "customer_address_moves", pList))
                //{
                    DBHelper.ExecuteNonQuery(cm, pList);
                //}
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
                    pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
                    cm.CommandText = "DELETE FROM customer_address_moves WHERE " +
                    "customer_address_moves.cust_id = @cust_id AND " +
                    "customer_address_moves.adr_id = @adr_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? cust_id, int? adr_id)
        {
            _cust_id = cust_id;
            _adr_id = adr_id;
        }
    }
}
