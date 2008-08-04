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
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "contractor_ds")]
    [MapInfo("cd_old_ds_no", "_cd_old_ds_no", "contractor_ds")]
    [System.Serializable()]

    public class ContractorDs : Entity<ContractorDs>
    {
        #region Business Methods
        [DBField()]
        private int? _contractor_supplier_no;

        [DBField()]
        private string _cd_old_ds_no;

        public virtual int? ContractorSupplierNo
        {
            get
            {
                CanReadProperty("ContractorSupplierNo", true);
                return _contractor_supplier_no;
            }
            set
            {
                CanWriteProperty("ContractorSupplierNo", true);
                if (_contractor_supplier_no != value)
                {
                    _contractor_supplier_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CdOldDsNo
        {
            get
            {
                CanReadProperty("CdOldDsNo", true);
                return _cd_old_ds_no;
            }
            set
            {
                CanWriteProperty("CdOldDsNo", true);
                if (_cd_old_ds_no != value)
                {
                    _cd_old_ds_no = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contractor_supplier_no, _cd_old_ds_no);
        }
        #endregion

        #region Factory Methods
        public static ContractorDs NewContractorDs(int? in_Contractor)
        {
            return Create(in_Contractor);
        }

        public static ContractorDs[] GetAllContractorDs(int? in_Contractor)
        {
            return Fetch(in_Contractor).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contractor)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contractor", in_Contractor);
                    cm.CommandText = "sp_GetContractorDS";

                    List<ContractorDs> _list = new List<ContractorDs>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractorDs instance = new ContractorDs();
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._cd_old_ds_no = GetValueFromReader<String>(dr, 1);
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
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "contractor_ds", ref pList))
                {
                    cm.CommandText += " WHERE  contractor_ds.contractor_supplier_no = @contractor_supplier_no and contractor_ds.cd_old_ds_no = @cd_old_ds_no";

                    pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                    pList.Add(cm, "cd_old_ds_no", GetInitialValue("_cd_old_ds_no"));

                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
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
                if (GenerateInsertCommandText(cm, "contractor_ds", pList))
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
                    pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                    pList.Add(cm, "cd_old_ds_no", GetInitialValue("_cd_old_ds_no"));
                    cm.CommandText = "DELETE FROM contractor_ds WHERE " +
                    "contractor_ds.contractor_supplier_no = @contractor_supplier_no and  contractor_ds.cd_old_ds_no = @cd_old_ds_no";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contractor_supplier_no, string cd_old_ds_no)
        {
            _contractor_supplier_no = contractor_supplier_no;
            _cd_old_ds_no = cd_old_ds_no;
        }
    }
}
