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
    [MapInfo("alt_key", "_alt_key", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("ca_effective_date", "_ca_effective_date", "")]
    [MapInfo("ca_annual_amount", "_ca_annual_amount", "")]
    [MapInfo("ca_notes", "_ca_notes", "")]
    [MapInfo("ca_paid_to_date", "_ca_paid_to_date", "")]
    [MapInfo("pct_id", "_pct_id", "")]
    [System.Serializable()]

    public class ContractAllowances : Entity<ContractAllowances>
    {
        #region Business Methods
        [DBField()]
        private int? _alt_key;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private DateTime? _ca_effective_date;

        [DBField()]
        private decimal? _ca_annual_amount;

        [DBField()]
        private string _ca_notes;

        [DBField()]
        private DateTime? _ca_paid_to_date;

        [DBField()]
        private int? _pct_id;


        public virtual int? AltKey
        {
            get
            {
                CanReadProperty("AltKey", true);
                return _alt_key;
            }
            set
            {
                CanWriteProperty("AltKey", true);
                if (_alt_key != value)
                {
                    _alt_key = value;
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

        public virtual DateTime? CaEffectiveDate
        {
            get
            {
                CanReadProperty("CaEffectiveDate", true);
                return _ca_effective_date;
            }
            set
            {
                CanWriteProperty("CaEffectiveDate", true);
                if (_ca_effective_date != value)
                {
                    _ca_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CaAnnualAmount
        {
            get
            {
                CanReadProperty("CaAnnualAmount", true);
                return _ca_annual_amount;
            }
            set
            {
                CanWriteProperty("CaAnnualAmount", true);
                if (_ca_annual_amount != value)
                {
                    _ca_annual_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CaNotes
        {
            get
            {
                CanReadProperty("CaNotes", true);
                return _ca_notes;
            }
            set
            {
                CanWriteProperty("CaNotes", true);
                if (_ca_notes != value)
                {
                    _ca_notes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? CaPaidToDate
        {
            get
            {
                CanReadProperty("CaPaidToDate", true);
                return _ca_paid_to_date;
            }
            set
            {
                CanWriteProperty("CaPaidToDate", true);
                if (_ca_paid_to_date != value)
                {
                    _ca_paid_to_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PctId
        {
            get
            {
                CanReadProperty("PctId", true);
                return _pct_id;
            }
            set
            {
                CanWriteProperty("PctId", true);
                if (_pct_id != value)
                {
                    _pct_id = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _alt_key, _contract_no, _ca_effective_date);
        }
        #endregion

        #region Factory Methods
        public static ContractAllowances NewContractAllowances(int? in_Contract)
        {
            return Create(in_Contract);
        }

        public static ContractAllowances[] GetAllContractAllowances(int? in_Contract)
        {
            return Fetch(in_Contract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    cm.CommandText = "sp_GetContractAllowance";


                    List<ContractAllowances> _list = new List<ContractAllowances>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractAllowances instance = new ContractAllowances();
                            instance._alt_key = GetValueFromReader<Int32?>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._ca_effective_date = GetValueFromReader<DateTime?>(dr, 2);
                            instance._ca_annual_amount = GetValueFromReader<Decimal?>(dr, 3);
                            instance._ca_notes = GetValueFromReader<String>(dr, 4);
                            instance._ca_paid_to_date = GetValueFromReader<DateTime?>(dr, 5);
                            instance._pct_id = GetValueFromReader<Int32?>(dr, 6);
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
        private void CreateEntity(int? alt_key, int? contract_no, DateTime? ca_effective_date)
        {
            _alt_key = alt_key;
            _contract_no = contract_no;
            _ca_effective_date = ca_effective_date;
        }
    }
}
