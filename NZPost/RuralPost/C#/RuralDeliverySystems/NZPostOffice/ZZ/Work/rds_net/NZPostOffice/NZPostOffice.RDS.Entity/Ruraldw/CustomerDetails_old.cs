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
    [MapInfo("cust_phone_day", "_cust_phone_day", "rds_customer")]
    [MapInfo("cust_phone_night", "_cust_phone_night", "rds_customer")]
    [MapInfo("cust_dir_listing_ind", "_cust_dir_listing_ind", "rds_customer")]
    [MapInfo("cust_dir_listing_text", "_cust_dir_listing_text", "rds_customer")]
    [MapInfo("cust_business", "_cust_business", "rds_customer")]
    [MapInfo("cust_rural_resident", "_cust_rural_resident", "rds_customer")]
    [MapInfo("cust_rural_farmer", "_cust_rural_farmer", "rds_customer")]
    [MapInfo("cust_date_commenced", "_cust_date_commenced", "rds_customer")]
    [MapInfo("cust_phone_mobile", "_cust_phone_mobile", "rds_customer")]
    [MapInfo("master_cust_id", "_master_cust_id", "rds_customer")]
    [MapInfo("cust_care_of", "_cust_care_of", "rds_customer")]
    [MapInfo("cust_adpost_quantity", "_cust_adpost_quantity", "rds_customer")]
    [MapInfo("cust_catagory", "_cust_catagory", "rds_customer")]
    [MapInfo("cust_last_amended_user", "_cust_last_amended_user", "rds_customer")]
    [MapInfo("cust_last_amended_date", "_cust_last_amended_date", "rds_customer")]
    [MapInfo("cust_dpid", "_cust_dpid", "rds_customer")]
    [System.Serializable()]

    public class CustomerDetails3 : Entity<CustomerDetails3>
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

        [DBField()]
        private string _cust_phone_day;

        [DBField()]
        private string _cust_phone_night;

        [DBField()]
        private string _cust_dir_listing_ind;

        [DBField()]
        private string _cust_dir_listing_text;

        [DBField()]
        private string _cust_business="N"; //added by jlwang

        [DBField()]
        private string _cust_rural_resident="Y";

        [DBField()]
        private string _cust_rural_farmer="N";

        [DBField()]
        private DateTime? _cust_date_commenced;

        [DBField()]
        private string _cust_phone_mobile;

        [DBField()]
        private int? _master_cust_id;

        [DBField()]
        private string _cust_care_of;

        [DBField()]
        private int? _cust_adpost_quantity= 1;

        [DBField()]
        private string _cust_catagory;

        [DBField()]
        private string _cust_last_amended_user;

        [DBField()]
        private DateTime? _cust_last_amended_date;

        [DBField()]
        private int? _cust_dpid;

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

        public virtual string CustPhoneDay
        {
            get
            {
                CanReadProperty("CustPhoneDay", true);
                return _cust_phone_day;
            }
            set
            {
                CanWriteProperty("CustPhoneDay", true);
                if (_cust_phone_day != value)
                {
                    _cust_phone_day = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustPhoneNight
        {
            get
            {
                CanReadProperty("CustPhoneNight", true);
                return _cust_phone_night;
            }
            set
            {
                CanWriteProperty("CustPhoneNight", true);
                if (_cust_phone_night != value)
                {
                    _cust_phone_night = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustDirListingInd
        {
            get
            {
                CanReadProperty("CustDirListingInd", true);
                return _cust_dir_listing_ind;
            }
            set
            {
                CanWriteProperty("CustDirListingInd", true);
                if (_cust_dir_listing_ind != value)
                {
                    _cust_dir_listing_ind = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustDirListingText
        {
            get
            {
                CanReadProperty("CustDirListingText", true);
                return _cust_dir_listing_text;
            }
            set
            {
                CanWriteProperty("CustDirListingText", true);
                if (_cust_dir_listing_text != value)
                {
                    _cust_dir_listing_text = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool CustBusiness
        {
            get
            {
                CanReadProperty("CustBusiness", true);
                return _cust_business == "Y";
            }
            set
            {
                CanWriteProperty("CustBusiness", true);
                if (_cust_business != (value ? "Y" : "N"))
                {
                    _cust_business = (value ? "Y" : "N");
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool CustRuralResident
        {
            get
            {
                CanReadProperty("CustRuralResident", true);
                return _cust_rural_resident == "Y";
            }
            set
            {
                CanWriteProperty("CustRuralResident", true);
                if (_cust_rural_resident != (value ? "Y" : "N"))
                {
                    _cust_rural_resident = (value ? "Y" : "N");
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool CustRuralFarmer
        {
            get
            {
                CanReadProperty("CustRuralFarmer", true);
                return _cust_rural_farmer == "Y";
            }
            set
            {
                CanWriteProperty("CustRuralFarmer", true);
                if (_cust_rural_farmer != (value ? "Y" : "N"))
                {
                    _cust_rural_farmer = (value ? "Y" : "N");
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? CustDateCommenced
        {
            get
            {
                CanReadProperty("CustDateCommenced", true);
                return _cust_date_commenced;
            }
            set
            {
                CanWriteProperty("CustDateCommenced", true);
                if (_cust_date_commenced != value)
                {
                    _cust_date_commenced = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustPhoneMobile
        {
            get
            {
                CanReadProperty("CustPhoneMobile", true);
                return _cust_phone_mobile;
            }
            set
            {
                CanWriteProperty("CustPhoneMobile", true);
                if (_cust_phone_mobile != value)
                {
                    _cust_phone_mobile = value;
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

        public virtual string CustCareOf
        {
            get
            {
                CanReadProperty("CustCareOf", true);
                return _cust_care_of;
            }
            set
            {
                CanWriteProperty("CustCareOf", true);
                if (_cust_care_of != value)
                {
                    _cust_care_of = value;
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

        public virtual string CustCatagory
        {
            get
            {
                CanReadProperty("CustCatagory", true);
                return _cust_catagory;
            }
            set
            {
                CanWriteProperty("CustCatagory", true);
                if (_cust_catagory != value)
                {
                    _cust_catagory = value;
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

        public virtual int? CustDpid
        {
            get
            {
                CanReadProperty("CustDpid", true);
                return _cust_dpid;
            }
            set
            {
                CanWriteProperty("CustDpid", true);
                if (_cust_dpid != value)
                {
                    _cust_dpid = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool CustDirListingInd1
        {
            get
            {
                CanReadProperty("CustDirListingInd1", true);
                return _cust_dir_listing_ind == "N";
            }
            set
            {
                CanWriteProperty("CustDirListingInd1", true);
                string new_value = value ? "N" : "Y";
                if (_cust_dir_listing_ind != new_value)
                {
                    _cust_dir_listing_ind = new_value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool CustDirListingInd2
        {
            get
            {
                CanReadProperty("CustDirListingInd2", true);
                return _cust_dir_listing_ind == "Y";
            }
            set
            {
                CanWriteProperty("CustDirListingInd2", true);
                string new_value = value ? "Y" : "N";
                if (_cust_dir_listing_ind != new_value)
                {
                    _cust_dir_listing_ind = new_value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _cust_id);
        }
        #endregion

        #region Factory Methods
        public static CustomerDetails3 NewCustomerDetails(int? al_cust_id)
        {
            return Create(al_cust_id);
        }

        public static CustomerDetails3[] GetAllCustomerDetails(int? al_cust_id)
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
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_cust_id", al_cust_id);
                    cm.CommandText = "  SELECT rds_customer.cust_id,   " +
                        "rds_customer.cust_title,   " +
                        "rds_customer.cust_surname_company,   " +
                        "rds_customer.cust_initials,   " +
                        "rds_customer.cust_phone_day,   " +
                        "rds_customer.cust_phone_night,   " +
                        "rds_customer.cust_dir_listing_ind,   " +
                        "rds_customer.cust_dir_listing_text,   " +
                        "rds_customer.cust_business,   " +
                        "rds_customer.cust_rural_resident,   " +
                        "rds_customer.cust_rural_farmer,   " +
                        "rds_customer.cust_date_commenced,   " +
                        "rds_customer.cust_phone_mobile,   " +
                        "rds_customer.master_cust_id,   " +
                        "rds_customer.cust_care_of,   " +
                        "rds_customer.cust_adpost_quantity,   " +
                        "(case when rds_customer.cust_business = 'Y' THEN 	'BS' ELSE 	case when rds_customer.cust_rural_resident = 'Y' THEN 		'RR' 	ELSE	 case when rds_customer.cust_rural_farmer = 'Y' THEN	'RF' 	END END END 	)as cust_catagory ,   " +
                        "rds_customer.cust_last_amended_user,   " +
                        "rds_customer.cust_last_amended_date,   " +
                        "0 as cust_dpid  " +
                        "FROM rds_customer  " +
                        "WHERE rds_customer.cust_id = @al_cust_id    ";
                    List<CustomerDetails3> _list = new List<CustomerDetails3>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            CustomerDetails3 instance = new CustomerDetails3();
                            instance._cust_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._cust_title = GetValueFromReader<String>(dr, 1);
                            instance._cust_surname_company = GetValueFromReader<String>(dr, 2);
                            instance._cust_initials = GetValueFromReader<String>(dr, 3);
                            instance._cust_phone_day = GetValueFromReader<String>(dr, 4);

                            instance._cust_phone_night = GetValueFromReader<String>(dr, 5);
                            instance._cust_dir_listing_ind = GetValueFromReader<String>(dr, 6);
                            instance._cust_dir_listing_text = GetValueFromReader<String>(dr, 7);
                            instance._cust_business = GetValueFromReader<String>(dr, 8);
                            instance._cust_rural_resident = GetValueFromReader<String>(dr, 9);

                            instance._cust_rural_farmer = GetValueFromReader<String>(dr, 10);
                            instance._cust_date_commenced = GetValueFromReader<DateTime?>(dr, 11);
                            instance._cust_phone_mobile = GetValueFromReader<String>(dr, 12);
                            instance._master_cust_id = GetValueFromReader<Int32?>(dr, 13);
                            instance._cust_care_of = GetValueFromReader<String>(dr, 14);

                            instance._cust_adpost_quantity = GetValueFromReader<Int32?>(dr, 15);
                            instance._cust_catagory = GetValueFromReader<String>(dr, 16);
                            instance._cust_last_amended_user = GetValueFromReader<String>(dr, 17);
                            instance._cust_last_amended_date = GetValueFromReader<DateTime?>(dr, 18);
                            instance._cust_dpid = GetValueFromReader<Int32?>(dr, 19);

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
