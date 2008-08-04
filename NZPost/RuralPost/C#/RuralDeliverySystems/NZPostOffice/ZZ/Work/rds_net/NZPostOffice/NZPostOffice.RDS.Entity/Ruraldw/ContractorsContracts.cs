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
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("con_title", "_con_title", "")]
    [System.Serializable()]

    public class ContractorsContracts : Entity<ContractorsContracts>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _con_title;

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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static ContractorsContracts NewContractorsContracts(int? in_Contractor)
        {
            return Create(in_Contractor);
        }

        public static ContractorsContracts[] GetAllContractorsContracts(int? in_Contractor)
        {
            return Fetch(in_Contractor).list;
        }
        #endregion

        #region Data Access
        //Exterior Data
        [ServerMethod]
        private void FetchEntity(int? in_Contractor)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_GetContractorsContracts";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contractor", in_Contractor);

                    List<ContractorsContracts> _list = new List<ContractorsContracts>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractorsContracts instance = new ContractorsContracts();
                            //instance.StoreFieldValues(dr,"");
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._con_title = GetValueFromReader<String>(dr, 1);
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
