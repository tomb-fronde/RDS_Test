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
    [MapInfo("rgn_name", "_rgn_name", "")]
    [MapInfo("o_name", "_o_name", "")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("resident", "_resident", "")]
    [MapInfo("business", "_business", "")]
    [MapInfo("farmer", "_farmer", "")]
    [MapInfo("cmb", "_unclassified", "")]
    [MapInfo("unclassified", "_cmb", "")]
    [System.Serializable()]

    public class CustCount : Entity<CustCount>
    {
        #region Business Methods
        [DBField()]
        private string _rgn_name;

        [DBField()]
        private string _o_name;

        [DBField()]
        private string _con_title;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _resident;

        [DBField()]
        private int? _business;

        [DBField()]
        private int? _farmer;

        [DBField()]
        private int? _unclassified;

        [DBField()]
        private int? _cmb;

        public virtual string RgnName
        {
            get
            {
                CanReadProperty("RgnName", true);
                return _rgn_name;
            }
            set
            {
                CanWriteProperty("RgnName", true);
                if (_rgn_name != value)
                {
                    _rgn_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OName
        {
            get
            {
                CanReadProperty("OName", true);
                return _o_name;
            }
            set
            {
                CanWriteProperty("OName", true);
                if (_o_name != value)
                {
                    _o_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConTitle
        {
            get
            {
                CanReadProperty("ConTitle", true);
                return _con_title;
            }
            set
            {
                CanWriteProperty("ConTitle", true);
                if (_con_title != value)
                {
                    _con_title = value;
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

        public int? REContractNo
        {
            get
            {
                return _contract_no;
            }
        }

        public virtual int? Resident
        {
            get
            {
                CanReadProperty("Resident", true);
                return _resident;
            }
            set
            {
                CanWriteProperty("Resident", true);
                if (_resident != value)
                {
                    _resident = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REResident
        {
            get
            {
                return _resident;
            }
        }

        public virtual int? Business
        {
            get
            {
                CanReadProperty("Business", true);
                return _business;
            }
            set
            {
                CanWriteProperty("Business", true);
                if (_business != value)
                {
                    _business = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REBusiness
        {
            get
            {
                return _business;
            }
        }

        public virtual int? Farmer
        {
            get
            {
                CanReadProperty("Farmer", true);
                return _farmer;
            }
            set
            {
                CanWriteProperty("Farmer", true);
                if (_farmer != value)
                {
                    _farmer = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFarmer
        {
            get
            {
                return _farmer;
            }
        }

        public virtual int? Unclassified
        {
            get
            {
                CanReadProperty("Unclassified", true);
                return _unclassified;
            }
            set
            {
                CanWriteProperty("Unclassified", true);
                if (_unclassified != value)
                {
                    _unclassified = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REUnclassified
        {
            get
            {
                return _unclassified;
            }
        }

        public virtual int? Cmb
        {
            get
            {
                CanReadProperty("Cmb", true);
                return _cmb;
            }
            set
            {
                CanWriteProperty("Cmb", true);
                if (_cmb != value)
                {
                    _cmb = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REmb
        {
            get
            {
                return _cmb;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static CustCount NewCustCount(int? inRegion, int? inOutlet, int? inContractType, int? inRenewalGroup)
        {
            return Create(inRegion, inOutlet, inContractType, inRenewalGroup);
        }

        public static CustCount[] GetAllCustCount(int? inRegion, int? inOutlet, int? inContractType, int? inRenewalGroup)
        {
            return Fetch(inRegion, inOutlet, inContractType, inRenewalGroup).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inRegion, int? inOutlet, int? inContractType, int? inRenewalGroup)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_GetCustomerCount";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inRegion", inRegion);
                    pList.Add(cm, "inOutlet", inOutlet);
                    pList.Add(cm, "inContractType", inContractType);
                    pList.Add(cm, "inRenewalGroup", inRenewalGroup);

                    List<CustCount> _list = new List<CustCount>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            CustCount instance = new CustCount();
                            instance._rgn_name = GetValueFromReader<string>(dr, 0);
                            instance._o_name = GetValueFromReader<string>(dr, 1);
                            instance._con_title = GetValueFromReader<string>(dr, 2);
                            instance._contract_no = GetValueFromReader<int?>(dr, 3);
                            instance._resident = GetValueFromReader<int?>(dr, 4);
                            instance._business = GetValueFromReader<int?>(dr, 5);
                            instance._farmer = GetValueFromReader<int?>(dr, 6);
                            instance._unclassified = GetValueFromReader<int?>(dr, 7);
                            instance._cmb = GetValueFromReader<int?>(dr, 8);
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
