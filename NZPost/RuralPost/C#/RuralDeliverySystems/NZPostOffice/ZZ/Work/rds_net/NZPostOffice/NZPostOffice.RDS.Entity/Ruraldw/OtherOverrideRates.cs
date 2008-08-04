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
    [MapInfo("contract_seq_number", "_contract_seq_number", "")]
    [MapInfo("mor_name", "_mor_name", "")]
    [MapInfo("mor_value", "_mor_value", "")]
    [MapInfo("mor_km_flag", "_mor_km_flag", "")]
    [MapInfo("mor_annual_flag", "_mor_annual_flag", "")]
    [System.Serializable()]

    public class OtherOverrideRates : Entity<OtherOverrideRates>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private string _mor_name;

        [DBField()]
        private decimal? _mor_value;

        [DBField()]
        private string _mor_km_flag;

        [DBField()]
        private string _mor_annual_flag;


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

        public virtual string MorName
        {
            get
            {
                CanReadProperty("MorName", true);
                return _mor_name;
            }
            set
            {
                CanWriteProperty("MorName", true);
                if (_mor_name != value)
                {
                    _mor_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? MorValue
        {
            get
            {
                CanReadProperty("MorValue", true);
                return _mor_value;
            }
            set
            {
                CanWriteProperty("MorValue", true);
                if (_mor_value != value)
                {
                    _mor_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MorKmFlag
        {
            get
            {
                CanReadProperty("MorKmFlag", true);
                return _mor_km_flag;
            }
            set
            {
                CanWriteProperty("MorKmFlag", true);
                if (_mor_km_flag != value)
                {
                    _mor_km_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MorAnnualFlag
        {
            get
            {
                CanReadProperty("MorAnnualFlag", true);
                return _mor_annual_flag;
            }
            set
            {
                CanWriteProperty("MorAnnualFlag", true);
                if (_mor_annual_flag != value)
                {
                    _mor_annual_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _contract_seq_number);
        }
        #endregion

        #region Factory Methods
        public static OtherOverrideRates NewOtherOverrideRates(int? incontract_no, int? incontract_seq_no)
        {
            return Create(incontract_no, incontract_seq_no);
        }

        public static OtherOverrideRates[] GetAllOtherOverrideRates(int? incontract_no, int? incontract_seq_no)
        {
            return Fetch(incontract_no, incontract_seq_no).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? incontract_no, int? incontract_seq_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "incontract_no", incontract_no);
                    pList.Add(cm, "incontract_seq_no", incontract_seq_no);
                    cm.CommandText = "rd.sp_get_other_override_rates";

                    List<OtherOverrideRates> _list = new List<OtherOverrideRates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            OtherOverrideRates instance = new OtherOverrideRates();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,1);
                            instance._mor_name = GetValueFromReader<String>(dr,2);
                            instance._mor_value = GetValueFromReader<Decimal?>(dr,3);
                            instance._mor_km_flag = GetValueFromReader<String>(dr,4);
                            instance._mor_annual_flag = GetValueFromReader<String>(dr,5);
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
        private void CreateEntity(int? contract_no, int? contract_seq_number)
        {
            _contract_no = contract_no;
            _contract_seq_number = contract_seq_number;
        }
    }
}
