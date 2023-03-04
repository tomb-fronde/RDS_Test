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
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "types_for_contractor")]
    [MapInfo("ct_key", "_ct_key", "types_for_contractor")]
    [System.Serializable()]

    public class TypesForContractor : Entity<TypesForContractor>
    {
        #region Business Methods
        [DBField()]
        private int? _contractor_supplier_no;

        [DBField()]
        private int? _ct_key;


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

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contractor_supplier_no, _ct_key);
        }
        #endregion

        #region Factory Methods
        public static TypesForContractor NewTypesForContractor(int? in_Contractor)
        {
            return Create(in_Contractor);
        }

        public static TypesForContractor[] GetAllTypesForContractor(int? in_Contractor)
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
                    cm.CommandText = "sp_GetTypesForContractor";
                    List<TypesForContractor> _list = new List<TypesForContractor>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            TypesForContractor instance = new TypesForContractor();
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr,0);
                            instance._ct_key = GetValueFromReader<Int32?>(dr,1);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        [ServerMethod]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();

                if (GenerateUpdateCommandText(cm, "types_for_contractor", ref pList))
                {
                    cm.CommandText += " WHERE  contractor_supplier_no= @_contractor_supplier_no AND " +
                        "ct_key= @_ct_key1 ";

                    pList.Add(cm, "_contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                    pList.Add(cm, "_ct_key1", GetInitialValue("_ct_key"));
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

                if (GenerateInsertCommandText(cm, "types_for_contractor", pList))
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
                    pList.Add(cm, "ct_key", GetInitialValue("_ct_key"));
                    cm.CommandText = "DELETE FROM types_for_contractor WHERE " +
                    "types_for_contractor.contractor_supplier_no = @contractor_supplier_no AND " +
                    "types_for_contractor.ct_key = @ct_key ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contractor_supplier_no, int? ct_key)
        {
            _contractor_supplier_no = contractor_supplier_no;
            _ct_key = ct_key;
        }
    }
}
