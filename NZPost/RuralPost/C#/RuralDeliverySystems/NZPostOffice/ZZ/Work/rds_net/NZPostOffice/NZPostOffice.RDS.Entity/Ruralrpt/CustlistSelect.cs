using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("cust_title", "_cust_title", "rds_customer")]
    [MapInfo("cust_surname_company", "_cust_name", "rds_customer")]
    [MapInfo("cust_initials", "_cust_initials", "rds_customer")]
    [MapInfo("road_name", "_road_name", "")]
    [MapInfo("suburb", "_suburb", "suburblocality")]
    [MapInfo("town", "_town", "towncity")]
    [MapInfo("adr_no", "_address_adr_no", "")]
    [MapInfo("adr_alpha", "_address_adr_alpha", "address")]
    [MapInfo("customer_id", "_cust_id", "report_temp")]
    [MapInfo("road_name", "_road_road_name", "road")]
    [System.Serializable()]

    public class CustlistSelect : Entity<CustlistSelect>
    {
        #region Business Methods
        [DBField()]
        private string _cust_title;

        [DBField()]
        private string _cust_name;

        [DBField()]
        private string _cust_initials;

        [DBField()]
        private string _road_name;

        [DBField()]
        private string _suburb;

        [DBField()]
        private string _town;

        [DBField()]
        private string _address_adr_no;

        [DBField()]
        private string _address_adr_alpha;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private string _road_road_name;


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

        public virtual string RoadName
        {
            get
            {
                CanReadProperty("RoadName", true);
                return _road_name;
            }
            set
            {
                CanWriteProperty("RoadName", true);
                if (_road_name != value)
                {
                    _road_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Suburb
        {
            get
            {
                CanReadProperty("Suburb", true);
                return _suburb;
            }
            set
            {
                CanWriteProperty("Suburb", true);
                if (_suburb != value)
                {
                    _suburb = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Town
        {
            get
            {
                CanReadProperty("Town", true);
                return _town;
            }
            set
            {
                CanWriteProperty("Town", true);
                if (_town != value)
                {
                    _town = value;
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

        public virtual string RoadRoadName
        {
            get
            {
                CanReadProperty("RoadRoadName", true);
                return _road_road_name;
            }
            set
            {
                CanWriteProperty("RoadRoadName", true);
                if (_road_road_name != value)
                {
                    _road_road_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute2
        {
            get
            {
                CanReadProperty(true);
                string st1 = _address_adr_no ==null ? "" :_address_adr_no.Trim();
                string st2 = _address_adr_alpha ==null ?"" :_address_adr_alpha+" ";
                string st3 = _road_name == null ?"" :_road_name;
                string st4 = _suburb == null ?"":( _road_name == null ?_suburb :", "+ _suburb);
                string st5 = _town == null ?"":", "+ _town;
                return st1 + st2 + st3 + st4 + st5;
            }
        }

        public virtual string Compute1
        {
            get
            {
                CanReadProperty(true);
                string st1 = _cust_name == null ? "" : _cust_name.Trim();
                string st2 = (_cust_title + _cust_initials) == null ? "" : ", ";
                string st3 = _cust_title == null ? "" : _cust_title + " ";
                string st4 = _cust_initials == null ? "" : _cust_initials;
                return st1 + st2 + st3 + st4;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static CustlistSelect NewCustlistSelect()
        {
            return Create();
        }

        public static CustlistSelect[] GetAllCustlistSelect()
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
                    cm.CommandText =  " SELECT rds_customer.cust_title,   "+
                            " rds_customer.cust_surname_company,  " +  
                            " rds_customer.cust_initials,    "+
                            " road.road_name+ "+
                            " upper(case isnull(road_type.rt_name,'') " +
		                    " when '' then '' "+
                            " else' '+road_type.rt_name end + "+
                            " case isnull(road_suffix.rs_name,'')"+
                            " when '' then '' "+
                            " else ' '+road_suffix.rs_name end) as road_name,"+
                            " suburblocality.sl_name  as suburb,  "+ 
                            " towncity.tc_name  as town,   "+
                            " upper(case isnull(address.adr_unit,'')  " +
                            " when '' then ''  "+
                            " else address.adr_unit+'/' end +address.adr_no) as adr_no,  "+ 
                            " address.adr_alpha,   "+
                            " report_temp.customer_id,   "+
                            " road.road_name  "+
                            " FROM address LEFT OUTER JOIN road ON address.road_id = road.road_id "+
                            " LEFT OUTER JOIN road_type ON road.rt_id = road_type.rt_id "+
                            " LEFT OUTER JOIN road_suffix ON road.rs_id = road_suffix.rs_id   "+
                            " LEFT OUTER JOIN suburblocality ON suburblocality.sl_id = address.sl_id "+
                            " LEFT OUTER JOIN towncity ON towncity.tc_id = address.tc_id, "+
                            " report_temp,   "+
                            " rds_customer,   "+
                            " customer_address_moves,   "+
                            " post_code  "+
                            " WHERE customer_address_moves.adr_id = address.adr_id and  "+
                            " customer_address_moves.cust_id = rds_customer.cust_id and "+ 
                            " post_code.post_code_id = address.post_code_id and  "+
                            " rds_customer.cust_id = report_temp.customer_id AND  "+
                            " rds_customer.master_cust_id is NULL AND  "+
                            " customer_address_moves.move_out_date is NULL   "+
                            " ORDER BY rds_customer.cust_surname_company ASC "; 

                    ParameterCollection pList = new ParameterCollection();

                    List<CustlistSelect> _list = new List<CustlistSelect>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            CustlistSelect instance = new CustlistSelect();
                            instance._cust_title = GetValueFromReader<string>(dr,0);
                            instance._cust_name = GetValueFromReader<string>(dr,1);
                            instance._cust_initials = GetValueFromReader<string>(dr,2);
                            instance._road_name = GetValueFromReader<string>(dr,3);
                            instance._suburb = GetValueFromReader<string>(dr,4);
                            instance._town = GetValueFromReader<string>(dr,5);
                            instance._address_adr_no = GetValueFromReader<string>(dr,6);
                            instance._address_adr_alpha = GetValueFromReader<string>(dr,7);
                            instance._cust_id = GetValueFromReader<int?>(dr,8);
                            instance._road_road_name = GetValueFromReader<string>(dr,9);
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
