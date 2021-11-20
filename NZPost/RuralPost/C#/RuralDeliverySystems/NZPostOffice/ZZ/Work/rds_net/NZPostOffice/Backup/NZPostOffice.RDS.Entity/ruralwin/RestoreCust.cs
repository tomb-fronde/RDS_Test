using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("adr_id", "_adr_id", "customer_address_moves")]
    [MapInfo("cust_id", "_cust_id", "rds_customer")]
    [MapInfo("move_out_date", "_move_out_date", "customer_address_moves")]
    [MapInfo("cust_title", "_cust_title", "rds_customer")]
    [MapInfo("cust_surname_company", "_cust_surname_company", "rds_customer")]
    [MapInfo("cust_initials", "_cust_initials", "rds_customer")]
    [MapInfo("master_cust_id", "_master_cust_id", "rds_customer")]
    [MapInfo("move_out_source", "_move_out_source", "customer_address_moves")]
    [MapInfo("move_out_user", "_move_out_user", "customer_address_moves")]
    [MapInfo("move_in_date", "_move_in_date", "customer_address_moves")]
    [System.Serializable()]

    public class RestoreCust : Entity<RestoreCust>
    {
        #region Business Methods
        [DBField()]
        private int? _adr_id;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private DateTime? _move_out_date;

        [DBField()]
        private string _cust_title;

        [DBField()]
        private string _cust_surname_company;

        [DBField()]
        private string _cust_initials;

        [DBField()]
        private int? _master_cust_id;

        [DBField()]
        private string _move_out_source;

        [DBField()]
        private string _move_out_user;

        [DBField()]
        private DateTime? _move_in_date;

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

        public virtual string Moveoutdate
        {
            get
            {
                CanReadProperty(true);
                try
                {
                    string date = _move_out_date.Value.Day.ToString();

                    switch (_move_out_date.Value.Month)
                    {
                        case 1:
                            date += "-" + "Jan";
                            break;
                        case 2:
                            date += "-" + "Feb";
                            break;
                        case 3:
                            date += "-" + "Mar";
                            break;
                        case 4:
                            date += "-" + "Apr";
                            break;
                        case 5:
                            date += "-" + "May";
                            break;
                        case 6:
                            date += "-" + "Jun";
                            break;
                        case 7:
                            date += "-" + "Jul";
                            break;
                        case 8:
                            date += "-" + "Aug";
                            break;
                        case 9:
                            date += "-" + "Sep";
                            break;
                        case 10:
                            date += "-" + "Oct";
                            break;
                        case 11:
                            date += "-" + "Nov";
                            break;
                        default:
                            date += "-" + "Dec";
                            break;

                    }
                    return date += "-" + _move_out_date.Value.Year.ToString();
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        public virtual string CustName
        {
            get
            {
                CanReadProperty(true);
                string st1 = _cust_title == null ? "" : _cust_title.Trim() + " ";
                string st2 = _cust_initials == null ? "" : _cust_initials.Trim() + " ";
                string st3 = _cust_surname_company == null ? "" : _cust_surname_company.Trim();
                return st1 + st2 + st3;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _adr_id, _cust_id);
        }
        #endregion

        #region Factory Methods
        public static RestoreCust NewRestoreCust(int? in_custID)
        {
            return Create(in_custID);
        }

        public static RestoreCust[] GetAllRestoreCust(int? in_custID)
        {
            return Fetch(in_custID).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_custID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT customer_address_moves.adr_id,rds_customer.cust_id," +
                        "customer_address_moves.move_out_date,rds_customer.cust_title," +
                        "rds_customer.cust_surname_company,rds_customer.cust_initials, " +
                        "rds_customer.master_cust_id,customer_address_moves.move_out_source," +
                        "customer_address_moves.move_out_user,customer_address_moves.move_in_date  " +
                        "FROM {oj rds_customer LEFT OUTER JOIN customer_address_moves " +
                        "ON rds_customer.cust_id = customer_address_moves.cust_id} " +
                        "WHERE (rds_customer.cust_id = @in_custID ) AND " +
                        "(( customer_address_moves.cust_id is null ) OR " +
                        "((customer_address_moves.move_out_date is not null ) AND  " +
                        "( 0 = ( select count(*) from customer_address_moves cam2 where cam2.cust_id = customer_address_moves.cust_id and cam2.move_out_date is null) ) ) )  ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_custID", in_custID);

                    List<RestoreCust> _list = new List<RestoreCust>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RestoreCust instance = new RestoreCust();
                            instance._adr_id = GetValueFromReader<int?>(dr,0);
                            instance._cust_id = GetValueFromReader<int?>(dr,1);
                            instance._move_out_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._cust_title = GetValueFromReader<string>(dr,3);
                            instance._cust_surname_company = GetValueFromReader<string>(dr,4);
                            instance._cust_initials = GetValueFromReader<string>(dr,5);
                            instance._master_cust_id = GetValueFromReader<int?>(dr,6);
                            instance._move_out_source = GetValueFromReader<string>(dr,7);
                            instance._move_out_user = GetValueFromReader<string>(dr,8);
                            instance._move_in_date = GetValueFromReader<DateTime?>(dr,9);
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
                    cm.CommandText += " WHERE  customer_address_moves.adr_id = @adr_id AND " +
                        "customer_address_moves.cust_id = @cust_id ";

                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
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
                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
                    pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
                    cm.CommandText = "DELETE FROM customer_address_moves WHERE " +
                    "customer_address_moves.adr_id = @adr_id AND " +
                    "customer_address_moves.cust_id = @cust_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? adr_id, int? cust_id)
        {
            _adr_id = adr_id;
            _cust_id = cust_id;
        }
    }
}
