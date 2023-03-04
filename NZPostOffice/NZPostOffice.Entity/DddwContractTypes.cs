using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Metex.Core.Security;
using Metex.Core;
using System.Data;

namespace NZPostOffice.Entity
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_type", "_contract_type", "contract_type")]
    [MapInfo("ct_key", "_ct_key", "contract_type")]
    [MapInfo("ct_rd_ref_mandatory", "_ct_rd_ref_mandatory", "contract_type")]
    [System.Serializable()]

    public class DddwContractTypes : Entity<DddwContractTypes>
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
            return _ct_key + " ";// string.Format("{0}", _ct_key);
        }
        #endregion

        #region Factory Methods
        public static DddwContractTypes NewDddwContractTypes()
        {
            return Create();
        }

        public static DddwContractTypes[] GetAllDddwContractTypes()
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
                    cm.CommandText = "SELECT contract_type.contract_type,  contract_type.ct_key,  contract_type.ct_rd_ref_mandatory  FROM rd.contract_type";
                    cm.CommandText += " order by contract_type.contract_type";
                    ParameterCollection pList = new ParameterCollection();

                    List<DddwContractTypes> _list = new List<DddwContractTypes>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwContractTypes instance = new DddwContractTypes();
                            instance._contract_type = GetValueFromReader<String>(dr, 0);
                            instance._ct_key = GetValueFromReader<Int32?>(dr, 1);
                            instance._ct_rd_ref_mandatory = GetValueFromReader<String>(dr, 2);
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
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "contract_type", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ct_key", GetInitialValue("_ct_key"));
                    cm.CommandText = "DELETE FROM contract_type WHERE " +
                    "contract_type.ct_key = @ct_key ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? ct_key)
        {
            _ct_key = ct_key;
        }
    }
}
