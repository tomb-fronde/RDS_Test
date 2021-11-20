using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralsec
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_type", "_contract_type", "contract_type")]
    [MapInfo("ct_key", "_ct_key", "contract_type")]
    [MapInfo("ct_rd_ref_mandatory", "_ct_rd_ref_mandatory", "contract_type")]
    [System.Serializable()]

    public class DddwFilteredContractTypes : Entity<DddwFilteredContractTypes>
    {
        #region Business Methods
        [DBField()]
        private string _contract_type;

        [DBField()]
        private int? _ct_key;

        [DBField()]
        private string _ct_rd_ref_mandatory;

        public virtual string ContractType
        {
            get
            {
                CanReadProperty("ContractType", true);
                return _contract_type;
            }
            set
            {
                CanWriteProperty("ContractType", true);
                if (_contract_type != value)
                {
                    _contract_type = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CtKey
        {
            get
            {
                CanReadProperty("CtKey", true);
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

        public virtual string CtRdRefMandatory
        {
            get
            {
                CanReadProperty("CtRdRefMandatory", true);
                return _ct_rd_ref_mandatory;
            }
            set
            {
                CanWriteProperty("CtRdRefMandatory", true);
                if (_ct_rd_ref_mandatory != value)
                {
                    _ct_rd_ref_mandatory = value;
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
        public static DddwFilteredContractTypes NewDddwFilteredContractTypes(int? al_ui_id)
        {
            return Create(al_ui_id);
        }

        public static DddwFilteredContractTypes[] GetAllDddwFilteredContractTypes(int? al_ui_id)
        {
            return Fetch(al_ui_id).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT contract_type.contract_type, contract_type.ct_key, contract_type.ct_rd_ref_mandatory " +
                        "FROM rd.contract_type, rd.rds_user_contract_type " +
                        "WHERE ( rds_user_contract_type.ct_key = contract_type.ct_key) and ((rds_user_contract_type.ui_id = @al_ui_id)) ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_ui_id", al_ui_id);

                    List<DddwFilteredContractTypes> _list = new List<DddwFilteredContractTypes>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwFilteredContractTypes instance = new DddwFilteredContractTypes();
                            instance._contract_type = GetValueFromReader<string>(dr, 0);
                            instance._ct_key = GetValueFromReader<int?>(dr, 1);
                            instance._ct_rd_ref_mandatory = GetValueFromReader<string>(dr, 2);
                            //instance.StoreFieldValues(dr, "rd.rds_user_contract_type");
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
