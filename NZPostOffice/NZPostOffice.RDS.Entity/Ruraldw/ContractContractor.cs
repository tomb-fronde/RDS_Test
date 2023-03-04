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
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "contractor_renewals")]
    [MapInfo("contract_no", "_contract_no", "contractor_renewals")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "contractor_renewals")]
    [MapInfo("cr_effective_date", "_cr_effective_date", "contractor_renewals")]
    [MapInfo("contractor_name", "_ccontractor_name", "contractor_renewals", true)]
    [System.Serializable()]

    public class ContractContractor : Entity<ContractContractor>
    {
        #region Business Methods
        [DBField()]
        private int? _contractor_supplier_no;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private DateTime? _cr_effective_date;

        [DBField()]
        private string _ccontractor_name;

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

        public virtual int? ContractSeqNumber
        {
            get
            {
                CanReadProperty("ContractSeqNumber", true);
                return _contract_seq_number;
            }
            set
            {
                CanWriteProperty("ContractSeqNumber", true);
                if (_contract_seq_number != value)
                {
                    _contract_seq_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? CrEffectiveDate
        {
            get
            {
                CanReadProperty("CrEffectiveDate", true);
                return _cr_effective_date;
            }
            set
            {
                CanWriteProperty("CrEffectiveDate", true);
                if (_cr_effective_date != value)
                {
                    _cr_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CcontractorName
        {
            get
            {
                CanReadProperty("CcontractorName", true);
                return _ccontractor_name;
            }
            set
            {
                CanWriteProperty("CcontractorName", true);
                if (_ccontractor_name != value)
                {
                    _ccontractor_name = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _contractor_supplier_no, _contract_no, _contract_seq_number);
        }
        #endregion

        #region Factory Methods
        public static ContractContractor NewContractContractor(int? contract_no, int? contract_seq_number)
        {
            return Create(contract_no, contract_seq_number);
        }

        public static ContractContractor[] GetAllContractContractor(int? contract_no, int? contract_seq_number)
        {
            return Fetch(contract_no, contract_seq_number).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? contract_no, int? contract_seq_number)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", contract_no);
                    pList.Add(cm, "contract_seq_number", contract_seq_number);
                    cm.CommandText = "SELECT contractor_renewals.contractor_supplier_no, " +
                        "contractor_renewals.contract_no, " +
                        "contractor_renewals.contract_seq_number, " +
                        "contractor_renewals.cr_effective_date, " +
                        // "contractor.c_surname_company || ifnull(contractor.c_first_names,'',', ' || contractor.c_first_names) as contractor_name " +
                       "contractor_name = case when contractor.c_first_names is null then contractor.c_surname_company else contractor.c_surname_company+',' + contractor.c_first_names end  " +
                        "FROM contractor_renewals,contractor " +
                        "WHERE ( contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no ) and " +
                        "( ( contractor_renewals.contract_no = @contract_no ) AND " +
                        "( contractor_renewals.contract_seq_number = @contract_seq_number ) ) " +
                        "ORDER BY contractor_renewals.cr_effective_date DESC";


                    List<ContractContractor> _list = new List<ContractContractor>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractContractor instance = new ContractContractor();
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr, 2);
                            instance._cr_effective_date = GetValueFromReader<DateTime?>(dr, 3);
                            instance._ccontractor_name = GetValueFromReader<String>(dr, 4);

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
                if (GenerateUpdateCommandText(cm, "contractor_renewals", ref pList))
                {
                    cm.CommandText += " WHERE  contractor_renewals.contractor_supplier_no = @contractor_supplier_no AND " +
                        "contractor_renewals.contract_no = @contract_no AND " +
                        "contractor_renewals.contract_seq_number = @contract_seq_number ";

                    pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
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
                if (GenerateInsertCommandText(cm, "contractor_renewals", pList))
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
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    cm.CommandText = "DELETE FROM contractor_renewals WHERE " +
                    "contractor_renewals.contractor_supplier_no = @contractor_supplier_no AND " +
                    "contractor_renewals.contract_no = @contract_no AND " +
                    "contractor_renewals.contract_seq_number = @contract_seq_number ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contractor_supplier_no, int? contract_no, int? contract_seq_number)
        {
            _contractor_supplier_no = contractor_supplier_no;
            _contract_no = contract_no;
            _contract_seq_number = contract_seq_number;
        }
    }
}
