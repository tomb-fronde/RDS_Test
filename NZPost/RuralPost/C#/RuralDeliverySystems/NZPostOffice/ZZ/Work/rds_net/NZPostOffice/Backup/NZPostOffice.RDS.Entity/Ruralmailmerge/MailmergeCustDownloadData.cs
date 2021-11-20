using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralmailmerge
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("cust_id", "_rds_customer_cust_id", "rds_customer")]
    [MapInfo("cust_surname_company", "_rds_customer_cust_surname_company", "rds_customer")]
    [MapInfo("cust_initials", "_rds_customer_cust_initials", "rds_customer")]
    [MapInfo("cust_name", "_cust_name", "contract")]
    [MapInfo("cust_mailing_address_road", "_cust_address_road", "contract")]
    [MapInfo("cust_mailing_address_locality", "_cust_address_locality", "suburblocality")]
    [MapInfo("cust_mail_town", "_cust_address_town", "towncity")]
    [MapInfo("cust_date_first_loaded", "_rds_customer_cust_date_first_loaded", "rds_customer")]
    [MapInfo("cust_date_left", "_cust_date_left", "contract")]
    [MapInfo("cust_dir_listing_ind", "_rds_customer_cust_dir_listing_ind", "rds_customer")]
    [MapInfo("cust_dir_listing_text", "_rds_customer_cust_dir_listing_text", "rds_customer")]
    [MapInfo("c_title", "_contractor_c_title", "contractor")]
    [MapInfo("c_first_names", "_contractor_c_first_names", "contractor")]
    [MapInfo("c_surname_company", "_contractor_c_surname_company", "contractor")]
    [MapInfo("ownerdriver_name", "_ownerdriver_name", "contract")]
    [MapInfo("c_phone_day", "_contractor_c_phone_day", "contract")]
    [MapInfo("c_phone_night", "_contractor_c_phone_night", "contract")]
    [MapInfo("c_mobile", "_contractor_c_mobile", "contract")]
    [MapInfo("c_mobile2", "_c_mobile2", "contract")]
    [MapInfo("primary_contact", "_primary_contact", "contract")]
    [MapInfo("c_email_address", "_contractor_c_email_address", "contractor")]
    [MapInfo("c_salutation", "_contractor_c_salutation", "contractor")]
    [MapInfo("o_name", "_outlet_o_name", "outlet")]
    [MapInfo("o_address", "_outlet_o_address", "outlet")]
    [MapInfo("o_telephone", "_outlet_o_telephone", "outlet")]
    [MapInfo("o_fax", "_outlet_o_fax", "outlet")]
    [MapInfo("o_manager", "_outlet_o_manager", "outlet")]
    [MapInfo("rgn_name", "_region_rgn_name", "region")]
    [MapInfo("rgn_rcm_manager", "_region_rgn_rcm_manager", "region")]
    [MapInfo("rgn_fax", "_region_rgn_fax", "region")]
    [MapInfo("rgn_telephone", "_region_rgn_telephone", "region")]
    [MapInfo("rgn_address", "_region_rgn_address", "region")]
    [MapInfo("contract_no", "_ccontract_no", "contract")]
    [MapInfo("cust_rd_number", "_address_cust_rd_number", "address")]
    [MapInfo("cust_delivery_days", "_cust_delivery_days", "contract")]
    [MapInfo("cust_deliverydays", "_cust_deliverydays1", "contract")]
    [MapInfo("cust_category", "_cust_category", "contract")]
    [MapInfo("c_initials", "_contractor_c_initials", "contractor")]
    [MapInfo("ot_outlet_type", "_outlet_type_ot_outlet_type", "outlet_type")]
    [MapInfo("cust_title", "_rds_customer_cust_title", "rds_customer")]
    [MapInfo("adr_no", "_address_adr_no", "contract")]
    [MapInfo("adr_post_code", "_adr_post_code", "post_code")]
    [MapInfo("adr_alpha", "_address_adr_alpha", "address")]
    [MapInfo("cust_mailing_address_no", "_cust_mailing_address_no", "contract")]
    [MapInfo("dp_id", "_address_dp_id", "contract")]
    [System.Serializable()]

    public class MailmergeCustDownloadData : Entity<MailmergeCustDownloadData>
    {
        #region Business Methods
        [DBField()]
        private int? _rds_customer_cust_id;

        [DBField()]
        private string _rds_customer_cust_surname_company;

        [DBField()]
        private string _rds_customer_cust_initials;

        [DBField()]
        private string _cust_name;

        [DBField()]
        private string _cust_address_road;

        [DBField()]
        private string _cust_address_locality;

        [DBField()]
        private string _cust_address_town;

        [DBField()]
        private DateTime? _rds_customer_cust_date_first_loaded;

        [DBField()]
        private int? _cust_date_left;

        [DBField()]
        private string _rds_customer_cust_dir_listing_ind;

        [DBField()]
        private string _rds_customer_cust_dir_listing_text;

        [DBField()]
        private string _contractor_c_title;

        [DBField()]
        private string _contractor_c_first_names;

        [DBField()]
        private string _contractor_c_surname_company;

        [DBField()]
        private string _ownerdriver_name;

        [DBField()]
        private string _contractor_c_phone_day;

        [DBField()]
        private string _contractor_c_phone_night;

        [DBField()]
        private string _contractor_c_mobile;

        [DBField()]
        private string _c_mobile2;

        [DBField()]
        private string _primary_contact;

        [DBField()]
        private string _contractor_c_email_address;

        [DBField()]
        private string _contractor_c_salutation;

        [DBField()]
        private string _outlet_o_name;

        [DBField()]
        private string _outlet_o_address;

        [DBField()]
        private string _outlet_o_telephone;

        [DBField()]
        private string _outlet_o_fax;

        [DBField()]
        private string _outlet_o_manager;

        [DBField()]
        private string _region_rgn_name;

        [DBField()]
        private string _region_rgn_rcm_manager;

        [DBField()]
        private string _region_rgn_fax;

        [DBField()]
        private string _region_rgn_telephone;

        [DBField()]
        private string _region_rgn_address;

        [DBField()]
        private string _ccontract_no;

        [DBField()]
        private string _address_cust_rd_number;

        [DBField()]
        private string _cust_delivery_days;

        [DBField()]
        private string _cust_deliverydays;

        [DBField()]
        private string _cust_category;

        [DBField()]
        private string _contractor_c_initials;

        [DBField()]
        private string _outlet_type_ot_outlet_type;

        [DBField()]
        private string _rds_customer_cust_title;

        [DBField()]
        private string _address_adr_no;

        [DBField()]
        private string _adr_post_code;

        [DBField()]
        private string _address_adr_alpha;

        [DBField()]
        private string _cust_mailing_address_no;

        [DBField()]
        private int? _address_dp_id;


        public virtual int? RDSCustomerCustId
        {
            get
            {
                CanReadProperty("RDSCustomerCustId", true);
                return _rds_customer_cust_id;
            }
            set
            {
                CanWriteProperty("RDSCustomerCustId", true);
                if (_rds_customer_cust_id != value)
                {
                    _rds_customer_cust_id = value;
                    PropertyHasChanged();
                }
            }
        }

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

        public virtual string CustName
        {
            get
            {
                CanReadProperty("CustName", true);
                return _cust_name;
            }
            set
            {
                CanWriteProperty("CustName", true);
                if (_cust_name != value)
                {
                    _cust_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustAddressRoad
        {
            get
            {
                CanReadProperty("CustAddressRoad", true);
                return _cust_address_road;
            }
            set
            {
                CanWriteProperty("CustAddressRoad", true);
                if (_cust_address_road != value)
                {
                    _cust_address_road = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustAddressLocality
        {
            get
            {
                CanReadProperty("CustAddressLocality", true);
                return _cust_address_locality;
            }
            set
            {
                CanWriteProperty("CustAddressLocality", true);
                if (_cust_address_locality != value)
                {
                    _cust_address_locality = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustAddressTown
        {
            get
            {
                CanReadProperty("CustAddressTown", true);
                return _cust_address_town;
            }
            set
            {
                CanWriteProperty("CustAddressTown", true);
                if (_cust_address_town != value)
                {
                    _cust_address_town = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RDSCustomerCustDateFirstLoaded
        {
            get
            {
                CanReadProperty("RDSCustomerCustDateFirstLoaded", true);
                return _rds_customer_cust_date_first_loaded;
            }
            set
            {
                CanWriteProperty("RDSCustomerCustDateFirstLoaded", true);
                if (_rds_customer_cust_date_first_loaded != value)
                {
                    _rds_customer_cust_date_first_loaded = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustDateLeft
        {
            get
            {
                CanReadProperty("CustDateLeft", true);
                return _cust_date_left;
            }
            set
            {
                CanWriteProperty("CustDateLeft", true);
                if (_cust_date_left != value)
                {
                    _cust_date_left = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RDSCustomerCustDirListingInd
        {
            get
            {
                CanReadProperty("RDSCustomerCustDirListingInd", true);
                return _rds_customer_cust_dir_listing_ind;
            }
            set
            {
                CanWriteProperty("RDSCustomerCustDirListingInd", true);
                if (_rds_customer_cust_dir_listing_ind != value)
                {
                    _rds_customer_cust_dir_listing_ind = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RDSCustomerCustDirListingText
        {
            get
            {
                CanReadProperty("RDSCustomerCustDirListingText", true);
                return _rds_customer_cust_dir_listing_text;
            }
            set
            {
                CanWriteProperty("RDSCustomerCustDirListingText", true);
                if (_rds_customer_cust_dir_listing_text != value)
                {
                    _rds_customer_cust_dir_listing_text = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCTitle
        {
            get
            {
                CanReadProperty("ContractorCTitle", true);
                return _contractor_c_title;
            }
            set
            {
                CanWriteProperty("ContractorCTitle", true);
                if (_contractor_c_title != value)
                {
                    _contractor_c_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCFirstNames
        {
            get
            {
                CanReadProperty("ContractorCFirstNames", true);
                return _contractor_c_first_names;
            }
            set
            {
                CanWriteProperty("ContractorCFirstNames", true);
                if (_contractor_c_first_names != value)
                {
                    _contractor_c_first_names = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCSurnameCompany
        {
            get
            {
                CanReadProperty("ContractorCSurnameCompany", true);
                return _contractor_c_surname_company;
            }
            set
            {
                CanWriteProperty("ContractorCSurnameCompany", true);
                if (_contractor_c_surname_company != value)
                {
                    _contractor_c_surname_company = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OwnerdriverName
        {
            get
            {
                CanReadProperty("OwnerdriverName", true);
                return _ownerdriver_name;
            }
            set
            {
                CanWriteProperty("OwnerdriverName", true);
                if (_ownerdriver_name != value)
                {
                    _ownerdriver_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCPhoneDay
        {
            get
            {
                CanReadProperty("ContractorCPhoneDay", true);
                return _contractor_c_phone_day;
            }
            set
            {
                CanWriteProperty("ContractorCPhoneDay", true);
                if (_contractor_c_phone_day != value)
                {
                    _contractor_c_phone_day = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCPhoneNight
        {
            get
            {
                CanReadProperty("ContractorCPhoneNight", true);
                return _contractor_c_phone_night;
            }
            set
            {
                CanWriteProperty("ContractorCPhoneNight", true);
                if (_contractor_c_phone_night != value)
                {
                    _contractor_c_phone_night = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCMobile
        {
            get
            {
                CanReadProperty("ContractorCMobile", true);
                return _contractor_c_mobile;
            }
            set
            {
                CanWriteProperty("ContractorCMobile", true);
                if (_contractor_c_mobile != value)
                {
                    _contractor_c_mobile = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CMobile2
        {
            get
            {
                CanReadProperty("CMobile2", true);
                return _c_mobile2;
            }
            set
            {
                CanWriteProperty("CMobile2", true);
                if (_c_mobile2 != value)
                {
                    _c_mobile2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrimaryContact
        {
            get
            {
                CanReadProperty("PrimaryContact", true);
                return _primary_contact;
            }
            set
            {
                CanWriteProperty("PrimaryContact", true);
                if (_primary_contact != value)
                {
                    _primary_contact = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCEmailAddress
        {
            get
            {
                CanReadProperty("ContractorCEmailAddress", true);
                return _contractor_c_email_address;
            }
            set
            {
                CanWriteProperty("ContractorCEmailAddress", true);
                if (_contractor_c_email_address != value)
                {
                    _contractor_c_email_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCSalutation
        {
            get
            {
                CanReadProperty("ContractorCSalutation", true);
                return _contractor_c_salutation;
            }
            set
            {
                CanWriteProperty("ContractorCSalutation", true);
                if (_contractor_c_salutation != value)
                {
                    _contractor_c_salutation = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OutletOName
        {
            get
            {
                CanReadProperty("OutletOName", true);
                return _outlet_o_name;
            }
            set
            {
                CanWriteProperty("OutletOName", true);
                if (_outlet_o_name != value)
                {
                    _outlet_o_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OutletOAddress
        {
            get
            {
                CanReadProperty("OutletOAddress", true);
                return _outlet_o_address;
            }
            set
            {
                CanWriteProperty("OutletOAddress", true);
                if (_outlet_o_address != value)
                {
                    _outlet_o_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OutletOTelephone
        {
            get
            {
                CanReadProperty("OutletOTelephone", true);
                return _outlet_o_telephone;
            }
            set
            {
                CanWriteProperty("OutletOTelephone", true);
                if (_outlet_o_telephone != value)
                {
                    _outlet_o_telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OutletOFax
        {
            get
            {
                CanReadProperty("OutletOFax", true);
                return _outlet_o_fax;
            }
            set
            {
                CanWriteProperty("OutletOFax", true);
                if (_outlet_o_fax != value)
                {
                    _outlet_o_fax = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OutletOManager
        {
            get
            {
                CanReadProperty("OutletOManager", true);
                return _outlet_o_manager;
            }
            set
            {
                CanWriteProperty("OutletOManager", true);
                if (_outlet_o_manager != value)
                {
                    _outlet_o_manager = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RegionRgnName
        {
            get
            {
                CanReadProperty("RegionRgnName", true);
                return _region_rgn_name;
            }
            set
            {
                CanWriteProperty("RegionRgnName", true);
                if (_region_rgn_name != value)
                {
                    _region_rgn_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RegionRgnRcmManager
        {
            get
            {
                CanReadProperty("RegionRgnRcmManager", true);
                return _region_rgn_rcm_manager;
            }
            set
            {
                CanWriteProperty("RegionRgnRcmManager", true);
                if (_region_rgn_rcm_manager != value)
                {
                    _region_rgn_rcm_manager = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RegionRgnFax
        {
            get
            {
                CanReadProperty("RegionRgnFax", true);
                return _region_rgn_fax;
            }
            set
            {
                CanWriteProperty("RegionRgnFax", true);
                if (_region_rgn_fax != value)
                {
                    _region_rgn_fax = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RegionRgnTelephone
        {
            get
            {
                CanReadProperty("RegionRgnTelephone", true);
                return _region_rgn_telephone;
            }
            set
            {
                CanWriteProperty("RegionRgnTelephone", true);
                if (_region_rgn_telephone != value)
                {
                    _region_rgn_telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RegionRgnAddress
        {
            get
            {
                CanReadProperty("RegionRgnAddress", true);
                return _region_rgn_address;
            }
            set
            {
                CanWriteProperty("RegionRgnAddress", true);
                if (_region_rgn_address != value)
                {
                    _region_rgn_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CcontractNo
        {
            get
            {
                CanReadProperty("CcontractNo", true);
                return _ccontract_no;
            }
            set
            {
                CanWriteProperty("CcontractNo", true);
                if (_ccontract_no != value)
                {
                    _ccontract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AddressCustRdNumber
        {
            get
            {
                CanReadProperty("AddressCustRdNumber", true);
                return _address_cust_rd_number;
            }
            set
            {
                CanWriteProperty("AddressCustRdNumber", true);
                if (_address_cust_rd_number != value)
                {
                    _address_cust_rd_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustDeliveryDays
        {
            get
            {
                CanReadProperty("CustDeliveryDays", true);
                return _cust_delivery_days;
            }
            set
            {
                CanWriteProperty("CustDeliveryDays", true);
                if (_cust_delivery_days != value)
                {
                    _cust_delivery_days = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustDeliverydays1
        {
            get
            {
                CanReadProperty("CustDeliverydays1", true);
                return _cust_deliverydays;
            }
            set
            {
                CanWriteProperty("CustDeliverydays1", true);
                if (_cust_deliverydays != value)
                {
                    _cust_deliverydays = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustCategory
        {
            get
            {
                CanReadProperty("CustCategory", true);
                return _cust_category;
            }
            set
            {
                CanWriteProperty("CustCategory", true);
                if (_cust_category != value)
                {
                    _cust_category = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractorCInitials
        {
            get
            {
                CanReadProperty("ContractorCInitials", true);
                return _contractor_c_initials;
            }
            set
            {
                CanWriteProperty("ContractorCInitials", true);
                if (_contractor_c_initials != value)
                {
                    _contractor_c_initials = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OutletTypeOtOutletType
        {
            get
            {
                CanReadProperty("OutletTypeOtOutletType", true);
                return _outlet_type_ot_outlet_type;
            }
            set
            {
                CanWriteProperty("OutletTypeOtOutletType", true);
                if (_outlet_type_ot_outlet_type != value)
                {
                    _outlet_type_ot_outlet_type = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RDSCustomerCustTitle
        {
            get
            {
                CanReadProperty("RDSCustomerCustTitle", true);
                return _rds_customer_cust_title;
            }
            set
            {
                CanWriteProperty("RDSCustomerCustTitle", true);
                if (_rds_customer_cust_title != value)
                {
                    _rds_customer_cust_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AddressAdrNo
        {
            get
            {
                CanReadProperty("AddressAdrNo", true);
                return _address_adr_no;
            }
            set
            {
                CanWriteProperty("AddressAdrNo", true);
                if (_address_adr_no != value)
                {
                    _address_adr_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrPostCode
        {
            get
            {
                CanReadProperty("AdrPostCode", true);
                return _adr_post_code;
            }
            set
            {
                CanWriteProperty("AdrPostCode", true);
                if (_adr_post_code != value)
                {
                    _adr_post_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AddressAdrAlpha
        {
            get
            {
                CanReadProperty("AddressAdrAlpha", true);
                return _address_adr_alpha;
            }
            set
            {
                CanWriteProperty("AddressAdrAlpha", true);
                if (_address_adr_alpha != value)
                {
                    _address_adr_alpha = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustMailingAddressNo
        {
            get
            {
                CanReadProperty("CustMailingAddressNo", true);
                return _cust_mailing_address_no;
            }
            set
            {
                CanWriteProperty("CustMailingAddressNo", true);
                if (_cust_mailing_address_no != value)
                {
                    _cust_mailing_address_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AddressDpId
        {
            get
            {
                CanReadProperty("AddressDpId", true);
                return _address_dp_id;
            }
            set
            {
                CanWriteProperty("AddressDpId", true);
                if (_address_dp_id != value)
                {
                    _address_dp_id = value;
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
        public static MailmergeCustDownloadData NewMailmergeCustDownloadData()
        {
            return Create();
        }

        public static MailmergeCustDownloadData[] GetAllMailmergeCustDownloadData(string sqlSyntax)
        {
            return Fetch(sqlSyntax).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string sqlSyntax)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = sqlSyntax;
                    cm.CommandTimeout = 0;

                    ParameterCollection pList = new ParameterCollection();

                    List<MailmergeCustDownloadData> _list = new List<MailmergeCustDownloadData>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (true)
                        //! while (dr.Read())
                        {
                            // ignore errors like PB does
                            try
                            {
                                if (!dr.Read())
                                    break;
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                            
                            MailmergeCustDownloadData instance = new MailmergeCustDownloadData();                               
                            instance._rds_customer_cust_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._rds_customer_cust_surname_company = GetValueFromReader<String>(dr, 1);
                            instance._rds_customer_cust_initials = GetValueFromReader<String>(dr, 2);
                            instance._cust_name = GetValueFromReader<String>(dr, 3);
                            instance._cust_address_road = GetValueFromReader<String>(dr, 4);

                            instance._cust_address_locality = GetValueFromReader<String>(dr, 5);
                            instance._cust_address_town = GetValueFromReader<String>(dr, 6);
                            instance._rds_customer_cust_date_first_loaded = GetValueFromReader<DateTime?>(dr, 7);
                            instance._cust_date_left = GetValueFromReader<Int32?>(dr, 8);
                            instance._rds_customer_cust_dir_listing_ind = GetValueFromReader<String>(dr, 9);

                            instance._rds_customer_cust_dir_listing_text = GetValueFromReader<String>(dr, 10);
                            instance._contractor_c_title = GetValueFromReader<String>(dr, 11);
                            instance._contractor_c_first_names = GetValueFromReader<String>(dr, 12);
                            instance._contractor_c_surname_company = GetValueFromReader<String>(dr, 13);
                            instance._ownerdriver_name = GetValueFromReader<String>(dr, 14);

                            instance._contractor_c_phone_day = GetValueFromReader<String>(dr, 15);
                            instance._contractor_c_phone_night = GetValueFromReader<String>(dr, 16);
                            instance._contractor_c_mobile = GetValueFromReader<String>(dr, 17);
                            instance._c_mobile2 = GetValueFromReader<String>(dr, 18);

                            //p! there are two columns with name "(No column name)"

                            instance._primary_contact = GetValueFromReader<String>(dr, 21);

                            instance._contractor_c_email_address = GetValueFromReader<String>(dr, 22);
                            instance._contractor_c_salutation = GetValueFromReader<String>(dr, 23);
                            instance._outlet_o_name = GetValueFromReader<String>(dr, 24);
                            instance._outlet_o_address = GetValueFromReader<String>(dr, 25);
                            instance._outlet_o_telephone = GetValueFromReader<String>(dr, 26);

                            instance._outlet_o_fax = GetValueFromReader<String>(dr, 27);
                            instance._outlet_o_manager = GetValueFromReader<String>(dr, 28);
                            instance._region_rgn_name = GetValueFromReader<String>(dr, 29);
                            instance._region_rgn_rcm_manager = GetValueFromReader<String>(dr, 30);
                            instance._region_rgn_fax = GetValueFromReader<String>(dr, 31);

                            instance._region_rgn_telephone = GetValueFromReader<String>(dr, 32);
                            instance._region_rgn_address = GetValueFromReader<String>(dr, 33);
                            instance._ccontract_no = GetValueFromReader<String>(dr, 34);
                            instance._address_cust_rd_number = GetValueFromReader<String>(dr, 35);
                            instance._cust_delivery_days = GetValueFromReader<String>(dr, 36);

                            instance._cust_deliverydays = GetValueFromReader<String>(dr, 37);
                            instance._cust_category = GetValueFromReader<String>(dr, 38);
                            instance._contractor_c_initials = GetValueFromReader<String>(dr, 39);
                            instance._outlet_type_ot_outlet_type = GetValueFromReader<String>(dr, 40);
                            instance._rds_customer_cust_title = GetValueFromReader<String>(dr, 41);

                            instance._address_adr_no = GetValueFromReader<String>(dr, 42);
                            instance._adr_post_code = GetValueFromReader<String>(dr, 43);
                            instance._address_adr_alpha = GetValueFromReader<String>(dr, 44);
                            instance._cust_mailing_address_no = GetValueFromReader<String>(dr, 45);
                            instance._address_dp_id = GetValueFromReader<Int32?>(dr, 46);                           

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
