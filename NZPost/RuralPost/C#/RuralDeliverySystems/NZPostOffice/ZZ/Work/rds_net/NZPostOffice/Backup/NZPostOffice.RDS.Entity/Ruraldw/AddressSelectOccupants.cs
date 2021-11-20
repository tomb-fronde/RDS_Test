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
    [MapInfo("cust_title", "_cust_title", "rds_customer")]
    [MapInfo("cust_surname_company", "_cust_surname_company", "rds_customer")]
    [MapInfo("cust_initials", "_cust_initials", "rds_customer")]
    [MapInfo("master_cust_id", "_master_cust_id", "rds_customer")]
    [MapInfo("move_ind", "_move_ind", "rds_customer")]
    [MapInfo("adr_id", "_adr_id", "customer_address_moves")]
    [MapInfo("cust_id", "_cust_id", "customer_address_moves")]
    [MapInfo("move_in_date", "_move_in_date", "customer_address_moves")]
    [MapInfo("move_out_date", "_move_out_date", "customer_address_moves")]
    [MapInfo("move_out_source", "_move_out_source", "customer_address_moves")]
    [MapInfo("move_out_user", "_move_out_user", "customer_address_moves")]
    [MapInfo("dp_id", "_dp_id", "customer_address_moves")]
    [System.Serializable()]

    public class AddressSelectOccupants : Entity<AddressSelectOccupants>
    {
        #region Business Methods
        [DBField()]
        private string _cust_title;

        [DBField()]
        private string _cust_surname_company;

        [DBField()]
        private string _cust_initials;

        [DBField()]
        private int? _master_cust_id;

        [DBField()]
        private string _move_ind;

        [DBField()]
        private int? _adr_id;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private DateTime? _move_in_date;

        [DBField()]
        private DateTime? _move_out_date;

        [DBField()]
        private string _move_out_source;

        [DBField()]
        private string _move_out_user;

        [DBField()]
        private int? _dp_id;


        public virtual string CustTitle
        {
            get
            {
                CanReadProperty("CustTitle", true);
                return _cust_title;
            }
            set
            {
                CanWriteProperty("CustTitle", true);
                if (_cust_title != value)
                {
                    _cust_title = value;
                    PropertyHasChanged();
                }
            }
        }

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

        public virtual string MoveInd
        {
            get
            {
                CanReadProperty("MoveInd", true);
                return _move_ind;
            }
            set
            {
                CanWriteProperty("MoveInd", true);
                if (_move_ind != value)
                {
                    _move_ind = value;
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

        public virtual string MoveOutSource
        {
            get
            {
                CanReadProperty("MoveOutSource", true);
                return _move_out_source;
            }
            set
            {
                CanWriteProperty("MoveOutSource", true);
                if (_move_out_source != value)
                {
                    _move_out_source = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MoveOutUser
        {
            get
            {
                CanReadProperty("MoveOutUser", true);
                return _move_out_user;
            }
            set
            {
                CanWriteProperty("MoveOutUser", true);
                if (_move_out_user != value)
                {
                    _move_out_user = value;
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
        // compute control name=[name]
        //?if(isnull( cust_initials ) OR Len(Trim(cust_initials))<;=0,  cust_surname_company ,   cust_surname_company + ', ' + cust_initials )
        public virtual string Name
        {
            get
            {
                CanReadProperty("Name", true);
                return (_cust_initials == null || _cust_initials.Trim().Length <= 0 ? _cust_surname_company : _cust_surname_company + ", " + _cust_initials);
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _cust_id, _move_in_date);
        }
        #endregion

        #region Factory Methods
        public static AddressSelectOccupants NewAddressSelectOccupants(int? al_cust_id)
        {
            return Create(al_cust_id);
        }

        public static AddressSelectOccupants[] GetAllAddressSelectOccupants(int? al_cust_id)
        {
            return Fetch(al_cust_id).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_cust_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = @"SELECT rds_customer.cust_title,
                                              rds_customer.cust_surname_company,
                                              rds_customer.cust_initials,
                                              rds_customer.master_cust_id,
                                              'Y' as move_ind,
                                              customer_address_moves.adr_id,
                                              customer_address_moves.cust_id,
                                              customer_address_moves.move_in_date,
                                              customer_address_moves.move_out_date,
                                              customer_address_moves.move_out_source,
                                              customer_address_moves.move_out_user,
                                              customer_address_moves.dp_id
                                         FROM rds_customer,  customer_address_moves
                                        WHERE rds_customer.cust_id = @al_cust_id
                                              AND rds_customer.cust_id = customer_address_moves.cust_id
                                              AND customer_address_moves.move_out_date is null
                                UNION  SELECT rds_customer.cust_title,
                                              rds_customer.cust_surname_company,
                                              rds_customer.cust_initials,
                                              rds_customer.master_cust_id,
                                              'Y' as move_ind,
                                              customer_address_moves.adr_id,
                                              customer_address_moves.cust_id,
                                              customer_address_moves.move_in_date,
                                              customer_address_moves.move_out_date,
                                              customer_address_moves.move_out_source,
                                              customer_address_moves.move_out_user,
                                              customer_address_moves.dp_id
                                         FROM rds_customer,  customer_address_moves
                                        WHERE rds_customer.master_cust_id = @al_cust_id
                                              AND rds_customer.cust_id = customer_address_moves.cust_id
                                              AND customer_address_moves.move_out_date is null  ";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_cust_id", al_cust_id);

                    List<AddressSelectOccupants> _list = new List<AddressSelectOccupants>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddressSelectOccupants instance = new AddressSelectOccupants();
                            instance._cust_title = GetValueFromReader<String>(dr, 0);
                            instance._cust_surname_company = GetValueFromReader<String>(dr, 1);
                            instance._cust_initials = GetValueFromReader<String>(dr, 2);
                            instance._master_cust_id = GetValueFromReader<Int32?>(dr, 3);
                            instance._move_ind = GetValueFromReader<String>(dr, 4);

                            instance._adr_id = GetValueFromReader<Int32?>(dr, 5);
                            instance._cust_id = GetValueFromReader<Int32?>(dr, 6);
                            instance._move_in_date = GetValueFromReader<DateTime?>(dr, 7);
                            instance._move_out_date = GetValueFromReader<DateTime?>(dr, 8);
                            instance._move_out_source = GetValueFromReader<String>(dr, 9);

                            instance._move_out_user = GetValueFromReader<String>(dr, 10);
                            instance._dp_id = GetValueFromReader<Int32?>(dr, 11);

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
                if (GenerateUpdateCommandText(cm, "customer_address_moves", ref pList))
                {
                    cm.CommandText += " WHERE  customer_address_moves.cust_id = @cust_id AND " +
                        "customer_address_moves.move_in_date = @move_in_date ";

                    pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
                    pList.Add(cm, "move_in_date", GetInitialValue("_move_in_date"));
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
                if (GenerateInsertCommandText(cm, "customer_address_moves", pList))
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
                    pList.Add(cm, "move_in_date", GetInitialValue("_move_in_date"));
                    cm.CommandText = "DELETE FROM customer_address_moves WHERE " +
                    "customer_address_moves.cust_id = @cust_id AND " +
                    "customer_address_moves.move_in_date = @move_in_date ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? cust_id, DateTime? move_in_date)
        {
            _cust_id = cust_id;
            _move_in_date = move_in_date;
        }
    }
}
