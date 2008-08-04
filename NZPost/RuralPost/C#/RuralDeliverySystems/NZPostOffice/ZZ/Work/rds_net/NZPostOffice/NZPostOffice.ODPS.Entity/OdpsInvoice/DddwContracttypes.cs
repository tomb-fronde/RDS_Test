//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsInvoice
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("ct_key", "_ct_key", "")]
    [MapInfo("contract_type", "_contract_type", "")]
    [MapInfo("ct_rd_ref_mandatory", "_ct_rd_ref_mandatory", "")]
    [System.Serializable()]

    public class DddwContracttypes : Entity<DddwContracttypes>
    {
        #region Business Methods
        [DBField()]
        private int? _ct_key;

        [DBField()]
        private string _contract_type;

        [DBField()]
        private string _ct_rd_ref_mandatory;

        public virtual int? CtKey
        {
            get
            {
                CanReadProperty("CtKey",true);
                return _ct_key;
            }
            set
            {
                CanWriteProperty("CtKey", true);
                if (_ct_key != value)
                {
                    _ct_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractType
        {
            get
            {
                CanReadProperty("ContractType",true);
                return _contract_type;
            }
            set
            {
                CanWriteProperty("ContractType",true);
                if (_contract_type != value)
                {
                    _contract_type = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CtRdRefMandatory
        {
            get
            {
                CanReadProperty("CtRdRefMandatory",true);
                return _ct_rd_ref_mandatory;
            }
            set
            {
                CanWriteProperty("CtRdRefMandatory",true);
                if (_ct_rd_ref_mandatory != value)
                {
                    _ct_rd_ref_mandatory = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _ct_key +" ";
        }
        #endregion

        #region Factory Methods
        public static DddwContracttypes NewDddwContracttypes()
        {
            return Create();
        }

        public static DddwContracttypes[] GetAllDddwContracttypes()
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
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_dddw_contracttypes";
                    ParameterCollection pList = new ParameterCollection();

                    List<DddwContracttypes> _list = new List<DddwContracttypes>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwContracttypes instance = new DddwContracttypes();
                            instance._ct_key = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_type = GetValueFromReader<string>(dr,1);
                            instance._ct_rd_ref_mandatory = GetValueFromReader<string>(dr,2);
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
