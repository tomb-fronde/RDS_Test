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
    [MapInfo("cust_surname_company", "_cust_surname_company", "rds_customer")]
    [MapInfo("cust_initials", "_cust_initials", "rds_customer")]
    [MapInfo("master_cust_id", "_master_cust_id", "rds_customer")]
    [MapInfo("primary_ind", "_primary_ind", "customer_address_moves")]
    [MapInfo("cust_id", "_cust_id", "rds_customer")]
    [MapInfo("move_in_date", "_move_in_date", "customer_address_moves")]
    [MapInfo("adr_id", "_adr_id", "customer_address_moves")]
    [MapInfo("move_out_date", "_move_out_date", "customer_address_moves")]
    [MapInfo("cust_last_amended_date", "_cust_last_amended_date", "rds_customer")]
    [MapInfo("cust_last_amended_user", "_cust_last_amended_user", "rds_customer")]
    [MapInfo("cust_business", "_cust_business", "rds_customer")]
    [MapInfo("cust_rural_resident", "_cust_rural_resident", "rds_customer")]
    [MapInfo("cust_rural_farmer", "_cust_rural_farmer", "rds_customer")]
    [MapInfo("cust_adpost_quantity", "_cust_adpost_quantity", "rds_customer")]
    [MapInfo("dp_id", "_dp_id", "customer_address_moves")]
    [System.Serializable()]

    public class AddressOccupants : Entity<AddressOccupants>
    {
        #region Business Methods
        [DBField()]
        private string _cust_surname_company;

        [DBField()]
        private string _cust_initials;

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

        [DBField()]
        private DateTime? _cust_last_amended_date;

        [DBField()]
        private string _cust_last_amended_user;

        [DBField()]
        private string _cust_business;

        [DBField()]
        private string _cust_rural_resident;

        [DBField()]
        private string _cust_rural_farmer;

        [DBField()]
        private int? _cust_adpost_quantity;

        [DBField()]
        private int? _dp_id;


        public virtual string CustSurnameCompany
        {
            get
            {
                CanReadProperty("CustSurnameCompany", true);
                return _cust_surname_company;
            }
            set
            {
                CanWriteProperty("CustSurnameCompany", true);
                if (_cust_surname_company != value)
                {
                    _cust_surname_company = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustInitials
        {
            get
            {
                CanReadProperty("CustInitials", true);
                return _cust_initials;
            }
            set
            {
                CanWriteProperty("CustInitials", true);
                if (_cust_initials != value)
                {
                    _cust_initials = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? MasterCustId
        {
            get
            {
                CanReadProperty("MasterCustId", true);
                //! return _master_cust_id == null ? 0 : _master_cust_id;
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

        public virtual DateTime? CustLastAmendedDate
        {
            get
            {
                CanReadProperty("CustLastAmendedDate", true);
                return _cust_last_amended_date;
            }
            set
            {
                CanWriteProperty("CustLastAmendedDate", true);
                if (_cust_last_amended_date != value)
                {
                    _cust_last_amended_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustLastAmendedUser
        {
            get
            {
                CanReadProperty("CustLastAmendedUser", true);
                return _cust_last_amended_user;
            }
            set
            {
                CanWriteProperty("CustLastAmendedUser", true);
                if (_cust_last_amended_user != value)
                {
                    _cust_last_amended_user = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustBusiness
        {
            get
            {
                CanReadProperty("CustBusiness", true);
                return _cust_business;
            }
            set
            {
                CanWriteProperty("CustBusiness", true);
                if (_cust_business != value)
                {
                    _cust_business = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustRuralResident
        {
            get
            {
                CanReadProperty("CustRuralResident", true);
                return _cust_rural_resident;
            }
            set
            {
                CanWriteProperty("CustRuralResident", true);
                if (_cust_rural_resident != value)
                {
                    _cust_rural_resident = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustRuralFarmer
        {
            get
            {
                CanReadProperty("CustRuralFarmer", true);
                return _cust_rural_farmer;
            }
            set
            {
                CanWriteProperty("CustRuralFarmer", true);
                if (_cust_rural_farmer != value)
                {
                    _cust_rural_farmer = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustAdpostQuantity
        {
            get
            {
                CanReadProperty("CustAdpostQuantity", true);
                return _cust_adpost_quantity;
            }
            set
            {
                CanWriteProperty("CustAdpostQuantity", true);
                if (_cust_adpost_quantity != value)
                {
                    _cust_adpost_quantity = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? DpId
        {
            get
            {
                CanReadProperty("DpId", true);
                return _dp_id;
            }
            set
            {
                CanWriteProperty("DpId", true);
                if (_dp_id != value)
                {
                    _dp_id = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[contact]
        //if(isnull( cust_initials ) OR Len(Trim(cust_initials))<;=0,  cust_surname_company ,  cust_surname_company + ', ' + cust_initials)
        public virtual string Contact
        {
            get
            {
                CanReadProperty("Contact", true);
                return (string.IsNullOrEmpty(_cust_initials) ? _cust_surname_company : _cust_surname_company +
                    ", " + _cust_initials);
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _cust_id);
        }
        #endregion

        #region Factory Methods
        public static AddressOccupants NewAddressOccupants(int? al_adr_id)
        {
            return Create(al_adr_id);
        }

        public static AddressOccupants[] GetAllAddressOccupants(int? al_adr_id)
        {
            return Fetch(al_adr_id).list;
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
                                              primary_ind =	  case	     when	          case		      when   rds_customer.master_cust_id>0 then 0		  end  is null then 1	     else 0	  end ,
                                              rds_customer.cust_id,
                                              customer_address_moves.move_in_date,
                                              customer_address_moves.adr_id,
                                              customer_address_moves.move_out_date,
                                              rds_customer.cust_last_amended_date  AS cust_last_amended_date,
                                              rds_customer.cust_last_amended_user  AS cust_last_amended_user,
                                              rds_customer.cust_business,
                                              rds_customer.cust_rural_resident,
                                              rds_customer.cust_rural_farmer,
                                              rds_customer.cust_adpost_quantity,
                                              customer_address_moves.dp_id
                                         FROM customer_address_moves,  rds_customer
                                        WHERE rds_customer.cust_id = customer_address_moves.cust_id
                                              AND customer_address_moves.adr_id = @al_adr_id
                                              AND customer_address_moves.move_out_date is null";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_adr_id", al_adr_id);

                    List<AddressOccupants> _list = new List<AddressOccupants>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddressOccupants instance = new AddressOccupants();
                            instance._cust_surname_company = GetValueFromReader<String>(dr, 0);
                            instance._cust_initials = GetValueFromReader<String>(dr, 1);
                            instance._master_cust_id = GetValueFromReader<Int32?>(dr, 2);
                            instance._primary_ind = GetValueFromReader<Int32?>(dr, 3);
                            instance._cust_id = GetValueFromReader<Int32?>(dr, 4);

                            instance._move_in_date = GetValueFromReader<DateTime?>(dr, 5);
                            instance._adr_id = GetValueFromReader<Int32?>(dr, 6);
                            instance._move_out_date = GetValueFromReader<DateTime?>(dr, 7);
                            instance._cust_last_amended_date = GetValueFromReader<DateTime?>(dr, 8);
                            instance._cust_last_amended_user = GetValueFromReader<String>(dr, 9);

                            instance._cust_business = GetValueFromReader<String>(dr, 10);
                            instance._cust_rural_resident = GetValueFromReader<String>(dr, 11);
                            instance._cust_rural_farmer = GetValueFromReader<String>(dr, 12);
                            instance._cust_adpost_quantity = GetValueFromReader<Int32?>(dr, 13);
                            instance._dp_id = GetValueFromReader<Int32?>(dr, 14);

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
                if (GenerateUpdateCommandText(cm, "rds_customer", ref pList))
                {
                    cm.CommandText += " WHERE  rds_customer.cust_id = @cust_id ";

                    pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
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
                if (GenerateInsertCommandText(cm, "rds_customer", pList))
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
                    pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
                    cm.CommandText = "DELETE FROM rds_customer WHERE " +
                    "rds_customer.cust_id = @cust_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? cust_id)
        {
            _cust_id = cust_id;
        }
    }
}
