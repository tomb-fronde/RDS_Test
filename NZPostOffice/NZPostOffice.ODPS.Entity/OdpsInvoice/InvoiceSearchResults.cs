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
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("contractor_no", "_contractor_no", "")]
    [MapInfo("c_first_names", "_c_first_names", "")]
    [System.Serializable()]

    public class InvoiceSearchResults : Entity<InvoiceSearchResults>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contractor_no;

        [DBField()]
        private string _c_first_names;

        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                if (_contract_no == 0)
                    return null;
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

        public virtual int? ContractorNo
        {
            get
            {
                CanReadProperty("ContractorNo", true);
                return _contractor_no;
            }
            set
            {
                CanWriteProperty("ContractorNo", true);
                if (_contractor_no != value)
                {
                    _contractor_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CFirstNames
        {
            get
            {
                CanReadProperty("CFirstNames", true);
                return _c_first_names;
            }
            set
            {
                CanWriteProperty("CFirstNames", true);
                if (_c_first_names != value)
                {
                    _c_first_names = value;
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
        public static InvoiceSearchResults NewInvoiceSearchResults(string inOwnerDriver, int? inRegion, DateTime? sdate, DateTime? edate, int? inContractNo, int? inCtKey)
        {
            return Create(inOwnerDriver, inRegion, sdate, edate, inContractNo, inCtKey);
        }

        public static InvoiceSearchResults[] GetAllInvoiceSearchResults(string inOwnerDriver, int? inRegion, DateTime? sdate, DateTime? edate, int? inContractNo, int? inCtKey)
        {
            return Fetch(inOwnerDriver, inRegion, sdate, edate, inContractNo, inCtKey).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string inOwnerDriver, int? inRegion, DateTime? sdate, DateTime? edate, int? inContractNo, int? inCtKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.OD_DWS_OwnerDriver_Search_Region_v2";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inOwnerDriver", inOwnerDriver);
                    pList.Add(cm, "inRegion", inRegion);
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);
                    pList.Add(cm, "inContractNo", inContractNo);
                    pList.Add(cm, "inCtKey", inCtKey);

                    List<InvoiceSearchResults> _list = new List<InvoiceSearchResults>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceSearchResults instance = new InvoiceSearchResults();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._contractor_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
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
