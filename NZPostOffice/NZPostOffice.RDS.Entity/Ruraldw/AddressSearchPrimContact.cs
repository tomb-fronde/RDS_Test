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
    [MapInfo("cust_id", "_cust_id", "rds_customer")]
    [MapInfo("cust_title", "_cust_title", "rds_customer")]
    [MapInfo("cust_surname_company", "_cust_surname_company", "rds_customer")]
    [MapInfo("cust_initials", "_cust_initials", "rds_customer")]
    [System.Serializable()]

    public class AddressSearchPrimContact : Entity<AddressSearchPrimContact>
    {
        #region Business Methods
        [DBField()]
        private int? _cust_id;

        [DBField()]
        private string _cust_title;

        [DBField()]
        private string _cust_surname_company;

        [DBField()]
        private string _cust_initials;


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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static AddressSearchPrimContact NewAddressSearchPrimContact()
        {
            return Create();
        }

        public static AddressSearchPrimContact[] GetAllAddressSearchPrimContact()
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
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = @"  SELECT rds_customer.cust_id,   
                                                 rds_customer.cust_title,   
                                                 rds_customer.cust_surname_company,   
                                                 rds_customer.cust_initials  
                                            FROM rds_customer  
                                           WHERE rds_customer.cust_id = -1";
                    List<AddressSearchPrimContact> _list = new List<AddressSearchPrimContact>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddressSearchPrimContact instance = new AddressSearchPrimContact();
                            instance._cust_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._cust_title = GetValueFromReader<String>(dr, 1);
                            instance._cust_surname_company = GetValueFromReader<String>(dr, 2);
                            instance._cust_initials = GetValueFromReader<String>(dr, 3);

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
