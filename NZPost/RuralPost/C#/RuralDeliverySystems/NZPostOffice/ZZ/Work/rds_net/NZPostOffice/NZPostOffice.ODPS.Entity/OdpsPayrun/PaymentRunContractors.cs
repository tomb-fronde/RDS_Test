//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsPayrun
{
    // TJB  RPCR_140  June-2019
    // Added rg_code and contract_no parameters to Fetch and
    // associated changes to OD_DWS_OwnerDriver_Search

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("contractor_no", "_contractor_no", "")]
    [MapInfo("c_first_names", "_c_first_names", "")]
    [MapInfo("edate", "_edate", "")]
    [System.Serializable()]

    public class PaymentRunContractors : Entity<PaymentRunContractors>
    {

        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contractor_no;

        [DBField()]
        private string _c_first_names;

        [DBField()]
        private DateTime? _edate;

        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                if (_contract_no == 0)
                {
                    return null;
                }
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

        public virtual DateTime? Edate
        {
            get
            {
                CanReadProperty("Edate", true);
                return _edate;
            }
            set
            {
                CanWriteProperty("Edate", true);
                if (_edate != value)
                {
                    _edate = value;
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
        public static PaymentRunContractors NewPaymentRunContractors(string inOwnerDriver, DateTime? sdate, DateTime? edate)
        {
            return Create(inOwnerDriver, sdate, edate);
        }

        // TJB  RPCR_140  June-2019
        // Added rg_code and contract_no parameters
        public static PaymentRunContractors[] GetAllPaymentRunContractors(
            string inOwnerDriver, DateTime? sdate, DateTime? edate 
            , int? rg_code, int? contract_no)
        {
            return Fetch(inOwnerDriver, sdate, edate, rg_code, contract_no).list;
        }
        #endregion

        #region Data Access
        // TJB  RPCR_140  June-2019
        // Added rg_code and contract_no parameters
        [ServerMethod]
        private void FetchEntity(
            string inOwnerDriver, DateTime? sdate, DateTime? edate, 
            int? rg_code, int? contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.OD_DWS_OwnerDriver_Search";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inOwnerDriver", inOwnerDriver);
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);
                    pList.Add(cm, "inRgCode", rg_code);
                    pList.Add(cm, "inContractNo", contract_no);

                    List<PaymentRunContractors> _list = new List<PaymentRunContractors>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PaymentRunContractors instance = new PaymentRunContractors();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._contractor_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
                            instance._edate = GetValueFromReader<DateTime?>(dr, 3);
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
