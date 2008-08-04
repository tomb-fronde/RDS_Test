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
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
    [MapInfo("contractor_name", "_contractor_name", "")]
    [MapInfo("cr_effective_date", "_cr_effective_date", "")]
    [System.Serializable()]

    public class ContractorList : Entity<ContractorList>
    {
        #region Business Methods
        [DBField()]
        private int? _contractor_supplier_no;

        [DBField()]
        private string _contractor_name;

        [DBField()]
        private DateTime? _cr_effective_date;

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

        public virtual string ContractorName
        {
            get
            {
                CanReadProperty("ContractorName", true);
                return _contractor_name;
            }
            set
            {
                CanWriteProperty("ContractorName", true);
                if (_contractor_name != value)
                {
                    _contractor_name = value;
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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static ContractorList NewContractorList(int? in_ContractorSupplierNo, int? in_ContractNo, int? in_ct_key, int? in_region_id, string in_c_surname_company, string in_c_first_names, string in_c_phone_day)
        {
            return Create(in_ContractorSupplierNo, in_ContractNo, in_ct_key, in_region_id, in_c_surname_company, in_c_first_names, in_c_phone_day);
        }

        public static ContractorList[] GetAllContractorList(int? in_ContractorSupplierNo, int? in_ContractNo, int? in_ct_key, int? in_region_id, string in_c_surname_company, string in_c_first_names, string in_c_phone_day)
        {
            return Fetch(in_ContractorSupplierNo, in_ContractNo, in_ct_key, in_region_id, in_c_surname_company, in_c_first_names, in_c_phone_day).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_ContractorSupplierNo, int? in_ContractNo, int? in_ct_key, int? in_region_id, string in_c_surname_company, string in_c_first_names, string in_c_phone_day)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_ContractorSupplierNo", in_ContractorSupplierNo);
                    pList.Add(cm, "in_ContractNo", in_ContractNo);
                    pList.Add(cm, "in_ct_key", in_ct_key);
                    pList.Add(cm, "in_region_id", in_region_id);
                    pList.Add(cm, "in_c_surname_company", in_c_surname_company);
                    pList.Add(cm, "in_c_first_names", in_c_first_names);
                    pList.Add(cm, "in_c_phone_day", in_c_phone_day);
                    cm.CommandText = "sp_SearchForContractor";
                    List<ContractorList> _list = new List<ContractorList>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractorList instance = new ContractorList();
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._contractor_name = GetValueFromReader<String>(dr, 1);
                            instance._cr_effective_date = GetValueFromReader<DateTime?>(dr, 2);
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
