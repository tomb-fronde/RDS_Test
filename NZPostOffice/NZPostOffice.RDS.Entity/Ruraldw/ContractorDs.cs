using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  AP export file format change  Dec-2013
    // Added supplier_no to retreived values
    //
    // TJB  AP export file format change  Jan-2014: Bug fix
    // Fixed bugs in update and delete functions.
    // Fixed fetch function via modified sp_GetContractorDS()
    // Added 2nd contractor_supplier_no to MapInfo for contractor_ds table
    // 

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "contractor")]
    [MapInfo("contractor_supplier_no", "_contractor_no", "contractor_ds")]
    [MapInfo("cd_old_ds_no", "_cd_old_ds_no", "contractor_ds")]
    [MapInfo("supplier_no", "_supplier_no", "contractor")]
    [System.Serializable()]

    public class ContractorDs : Entity<ContractorDs>
    {
        #region Business Methods
        [DBField()]
        private int? _contractor_supplier_no;

        [DBField()]
        private int? _contractor_no;

        [DBField()]
        private string _cd_old_ds_no;

        [DBField()]
        private string _supplier_no;

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
                    _contractor_no = value;
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

        public virtual string SupplierNo
        {
            get
            {
                CanReadProperty("SupplierNo", true);
                return _supplier_no;
            }
            set
            {
                CanWriteProperty("SupplierNo", true);
                if (_supplier_no != value)
                {
                    _supplier_no = value;
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
                            instance._contractor_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._cd_old_ds_no = GetValueFromReader<String>(dr, 1);
                            instance._supplier_no = GetValueFromReader<String>(dr, 2);
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

                string initial_cd_old_ds_no = (string)GetInitialValue("_cd_old_ds_no");
                string initial_supplier_no = (string)GetInitialValue("_supplier_no");

                try
                {
                    if (initial_supplier_no != _supplier_no)
                        if (GenerateUpdateCommandText(cm, "contractor", ref pList))
                        {
                            cm.CommandText += " WHERE contractor.contractor_supplier_no = @contractor_supplier_no " 
                           //                   + " AND contractor.supplier_no = @supplier_no"
                                              ;

                            pList.Add(cm, "contractor_supplier_no", _contractor_supplier_no);
                            //pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                            //pList.Add(cm, "supplier_no", GetInitialValue("_supplier_no"));
                            //pList.Add(cm, "supplier_no", _supplier_no);

                            DBHelper.ExecuteNonQuery(cm, pList);
                        }

                    if (initial_cd_old_ds_no == null)
                    {
                        if (_cd_old_ds_no != null)
                        {
                            if (GenerateInsertCommandText(cm, "contractor_ds", pList))
                            {
                                DBHelper.ExecuteNonQuery(cm, pList);
                            }
                        }
                    }
                    else if (initial_cd_old_ds_no != _cd_old_ds_no)
                    {
                        if (GenerateUpdateCommandText(cm, "contractor_ds", ref pList))
                        {
                            cm.CommandText += " WHERE contractor_ds.contractor_supplier_no = @contractor_supplier_no "
                                              + " AND contractor_ds.cd_old_ds_no = @cd_old_ds_no";

                            pList.Add(cm, "contractor_supplier_no", _contractor_supplier_no);
                            //pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                            pList.Add(cm, "cd_old_ds_no", GetInitialValue("_cd_old_ds_no"));

                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                    }
                    // reinitialize original key/value list
                    StoreInitialValues();
                }
                catch (Exception e)
                {
                    sqlCode = -1;
                    sqlErrText = e.Message;
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
                    cm.CommandText = "DELETE FROM contractor_ds " 
                                   + " WHERE contractor_ds.contractor_supplier_no = @contractor_supplier_no " 
                    //               + "   AND  contractor_ds.cd_old_ds_no = @cd_old_ds_no"
                                   ;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contractor_supplier_no", _contractor_supplier_no);
                    //pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                    //pList.Add(cm, "cd_old_ds_no", GetInitialValue("_cd_old_ds_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);

                    cm.CommandText = "UPDATE contractor "
                                   + "   SET supplier_no = NULL "
                                   + " WHERE contractor.contractor_supplier_no = @contractor_supplier_no "
                                   ;
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
