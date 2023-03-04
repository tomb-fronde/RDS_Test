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
    [MapInfo("proc_id", "_proc_id", "contractor_procurement")]
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "contractor_procurement")]
    [System.Serializable()]

    public class ContractorProcurement : Entity<ContractorProcurement>
    {
        #region Business Methods
        [DBField()]
        private int? _proc_id;

        [DBField()]
        private int? _contractor_supplier_no;

        public virtual int? ProcId
        {
            get
            {
                CanReadProperty("ProcId", true);
                return _proc_id;
            }
            set
            {
                CanWriteProperty("ProcId", true);
                if (_proc_id != value)
                {
                    _proc_id = value;
                    PropertyHasChanged();
                }
            }
        }

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

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _proc_id, _contractor_supplier_no);
        }
        #endregion

        #region Factory Methods
        public static ContractorProcurement NewContractorProcurement(int? in_contractor)
        {
            return Create(in_contractor);
        }

        public static ContractorProcurement[] GetAllContractorProcurement(int? in_contractor)
        {
            return Fetch(in_contractor).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_contractor)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_contractor", in_contractor);
                    cm.CommandText = @"SELECT contractor_procurement.proc_id,   
                                             contractor_procurement.contractor_supplier_no  
                                        FROM contractor_procurement  
                                       WHERE contractor_procurement.contractor_supplier_no = @in_contractor   
                                    ORDER BY contractor_procurement.proc_id ASC";

                    List<ContractorProcurement> _list = new List<ContractorProcurement>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractorProcurement instance = new ContractorProcurement();
                            instance._proc_id = GetValueFromReader<Int32?>(dr, "proc_id");
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr, "contractor_supplier_no");

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
                //DbCommand cm = cn.CreateCommand();
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    //if (GenerateUpdateCommandText(cm, "contractor_procurement", ref pList))

                        //cm.CommandText += " WHERE  contractor_procurement.proc_id = @proc_id AND " +
                        //    "contractor_procurement.contractor_supplier_no = @contractor_supplier_no ";
                        cm.CommandText = "begin tran "                                          //altered by ygu
                                       + "DELETE FROM contractor_procurement WHERE contractor_procurement.proc_id = @proc_id1 AND contractor_procurement.contractor_supplier_no = @contractor_supplier_no "
                                       + "if @@Error<>0 "
                                       + "rollback tran "
                                       + "else "
                                       + "INSERT INTO contractor_procurement(proc_id, contractor_supplier_no) VALUES(@proc_id2, @contractor_supplier_no) "
                                       + "commit tran ";
                        pList.Add(cm, "proc_id1", GetInitialValue("_proc_id"));
                        pList.Add(cm, "proc_id2", ProcId);
                        pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        catch
                        { }
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
                if (GenerateInsertCommandText(cm, "contractor_procurement", pList))
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
                    pList.Add(cm, "proc_id", GetInitialValue("_proc_id"));
                    pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                    cm.CommandText = "DELETE FROM contractor_procurement WHERE " +
                    "contractor_procurement.proc_id = @proc_id AND " +
                    "contractor_procurement.contractor_supplier_no = @contractor_supplier_no ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? proc_id, int? contractor_supplier_no)
        {
            _proc_id = proc_id;
            _contractor_supplier_no = contractor_supplier_no;
        }
    }
}
