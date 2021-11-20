using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  RPCR_105  May-2016: New
    // Finds contract numbers from the post_code table where
    // a specific post_code has more than one contract; the
    // contract number passed to the fetch routine is excluded.

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("post_code", "_post_code", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [System.Serializable()]

    public class ReassignContract : Entity<ReassignContract>
    {
        #region Business Methods
        [DBField()]
        private string _post_code;

        [DBField()]
        private int? _contract_no;


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

        public virtual string PostCode
        {
            get
            {
                CanReadProperty("PostCode", true);
                return _post_code;
            }
            set
            {
                CanWriteProperty("PostCode", true);
                if (_post_code != value)
                {
                    _post_code = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _post_code, _contract_no);
        }
        #endregion

        #region Factory Methods
        public static ReassignContract NewReassignContract(string inPostCode, int? inContractNo)
        {
            return Create(inPostCode, inContractNo);
        }

        public static ReassignContract[] GetAllReassignContract(string inPostCode, int? inContractNo)
        {
            return Fetch(inPostCode, inContractNo).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string inPostCode, int? inContractNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inPostCode", inPostCode);
                    pList.Add(cm, "inContractNo", inContractNo);
                    cm.CommandText = "select contract_no from rd.post_code "
                                   + " where post_code = @inPostCode "
                                   + "   and contract_no != @inContractNo";

                    List<ReassignContract> _list = new List<ReassignContract>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ReassignContract instance = new ReassignContract();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
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
        private void CreateEntity(string in_post_code, int? in_contract_no)
        {
            _post_code = in_post_code;
            _contract_no = in_contract_no;
        }
        #endregion

    }
}
