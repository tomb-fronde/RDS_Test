using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_047  Jan-2013:  New
    // Gets outlet address details for display on the contract outlet search screen (WQsOutlet)

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("outlet_id", "_outlet_id", "")]
    [MapInfo("o_name", "_o_name", "")]
    [MapInfo("ot_outlet_type", "_ot_outlet_type", "")]
    [MapInfo("o_address", "_o_address", "")]
    [MapInfo("o_phy_address", "_o_phy_address", "")]
    [MapInfo("o_telephone", "_o_telephone", "")]
    [MapInfo("o_fax", "_o_fax", "")]
    [MapInfo("o_manager", "_o_manager", "")]
    [MapInfo("o_fax", "_o_fax", "")]
    [System.Serializable()]

    public class QsOutletDetails : Entity<QsOutletDetails>
    {
        #region Business Methods
        [DBField()]
        private int? _outlet_id;

        [DBField()]
        private string _o_name;

        [DBField()]
        private string _ot_outlet_type;

        [DBField()]
        private string _o_address;

        [DBField()]
        private string _o_phy_address;

        [DBField()]
        private string _o_telephone;

        [DBField()]
        private string _o_fax;

        [DBField()]
        private string _o_manager;


        public virtual int? OutletId
        {
            get
            {
                CanReadProperty("OutletId", true);
                return _outlet_id;
            }
            set
            {
                CanWriteProperty("OutletId", true);
                if (_outlet_id != value)
                {
                    _outlet_id = value;
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

        public virtual string OtOutletType
        {
            get
            {
                CanReadProperty("OtOutletType", true);
                return _ot_outlet_type;
            }
            set
            {
                CanWriteProperty("OtOutletType", true);
                if (_ot_outlet_type != value)
                {
                    _ot_outlet_type = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OAddress
        {
            get
            {
                CanReadProperty("OAddress", true);
                return _o_address;
            }
            set
            {
                CanWriteProperty("OAddress", true);
                if (_o_address != value)
                {
                    _o_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OPhyAddress
        {
            get
            {
                CanReadProperty("OPhyAddress", true);
                return _o_phy_address;
            }
            set
            {
                CanWriteProperty("OPhyAddress", true);
                if (_o_phy_address != value)
                {
                    _o_phy_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OTelephone
        {
            get
            {
                CanReadProperty("OTelephone", true);
                return _o_telephone;
            }
            set
            {
                CanWriteProperty("OTelephone", true);
                if (_o_telephone != value)
                {
                    _o_telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OFax
        {
            get
            {
                CanReadProperty("OFax", true);
                return _o_fax;
            }
            set
            {
                CanWriteProperty("OFax", true);
                if (_o_fax != value)
                {
                    _o_fax = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OManager
        {
            get
            {
                CanReadProperty("OManager", true);
                return _o_manager;
            }
            set
            {
                CanWriteProperty("OManager", true);
                if (_o_manager != value)
                {
                    _o_manager = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ONameType
        {
            get
            {
                CanReadProperty("ONameType", true);
                return _o_name + " " + _ot_outlet_type;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static QsOutletDetails NewQsOutletDetails(int? in_outlet_id)
        {
            return Create(in_outlet_id);
        }

        public static QsOutletDetails[] GetAllQsOutletDetails(int? in_outlet_id)
        {
            return Fetch(in_outlet_id).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_outlet_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_outlet_id", in_outlet_id);
                    cm.CommandText = "select o.outlet_id, o.o_name, ot.ot_outlet_type, "
                                         + " o.o_address, o.o_phy_address, "
                                         + " o.o_telephone, o.o_fax, o.o_manager "
                                    + " from outlet o, outlet_type ot "
                                   + " where o.outlet_id = @in_outlet_id "
                                    + "  and ot.ot_code = o.ot_code ";

                    List<QsOutletDetails> _list = new List<QsOutletDetails>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            QsOutletDetails instance = new QsOutletDetails();
                            instance._outlet_id = GetValueFromReader<Int32?>(dr,0);
                            instance._o_name = GetValueFromReader<String>(dr, 1);
                            instance._ot_outlet_type = GetValueFromReader<String>(dr, 2);
                            instance._o_address = GetValueFromReader<String>(dr, 3);
                            instance._o_phy_address = GetValueFromReader<String>(dr, 4);
                            instance._o_telephone = GetValueFromReader<String>(dr, 5);
                            instance._o_fax = GetValueFromReader<String>(dr, 6);
                            instance._o_manager = GetValueFromReader<String>(dr, 7);
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
        private void CreateEntity(int? in_outlet_id)
        {
            _outlet_id = in_outlet_id;
        }
    }
}
