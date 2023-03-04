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
    [MapInfo("ca_key", "_ca_key", "contract_adjustments")]
    [MapInfo("contract_no", "_contract_no", "contract_adjustments")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "contract_adjustments")]
    [MapInfo("ca_date_occured", "_ca_date_occured", "contract_adjustments")]
    [MapInfo("ca_reason", "_ca_reason", "contract_adjustments")]
    [MapInfo("ca_date_paid", "_ca_date_paid", "contract_adjustments")]
    [MapInfo("ca_amount", "_ca_amount", "contract_adjustments")]
    [MapInfo("ca_confirmed", "_ca_confirmed", "contract_adjustments")]
    [MapInfo("pct_id", "_pct_id", "contract_adjustments")]
    [System.Serializable()]

    public class RenewalAdjustments : Entity<RenewalAdjustments>
    {
        #region Business Methods
        [DBField()]
        private int? _ca_key;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private DateTime? _ca_date_occured;

        [DBField()]
        private string _ca_reason;

        [DBField()]
        private DateTime? _ca_date_paid;

        [DBField()]
        private decimal? _ca_amount;

        [DBField()]
        private string _ca_confirmed="N";

        [DBField()]
        private int? _pct_id;


        public virtual int? CaKey
        {
            get
            {
                CanReadProperty("CaKey", true);
                return _ca_key;
            }
            set
            {
                CanWriteProperty("CaKey", true);
                if (_ca_key != value)
                {
                    _ca_key = value;
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

        public virtual DateTime? CaDateOccured
        {
            get
            {
                CanReadProperty("CaDateOccured", true);
                return _ca_date_occured;
            }
            set
            {
                CanWriteProperty("CaDateOccured", true);
                if (_ca_date_occured != value)
                {
                    _ca_date_occured = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CaReason
        {
            get
            {
                CanReadProperty("CaReason", true);
                return _ca_reason;
            }
            set
            {
                CanWriteProperty("CaReason", true);
                if (_ca_reason != value)
                {
                    _ca_reason = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? CaDatePaid
        {
            get
            {
                CanReadProperty("CaDatePaid", true);
                return _ca_date_paid;
            }
            set
            {
                CanWriteProperty("CaDatePaid", true);
                if (_ca_date_paid != value)
                {
                    _ca_date_paid = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CaAmount
        {
            get
            {
                CanReadProperty("CaAmount", true);
                return _ca_amount;
            }
            set
            {
                CanWriteProperty("CaAmount", true);
                if (_ca_amount != value)
                {
                    _ca_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CaConfirmed
        {
            get
            {
                CanReadProperty("CaConfirmed", true);
                return _ca_confirmed;
            }
            set
            {
                CanWriteProperty("CaConfirmed", true);
                if (_ca_confirmed != value)
                {
                    _ca_confirmed = value;
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
            return string.Format("{0}/{1}/{2}", _ca_key, _contract_no, _contract_seq_number);
        }
        #endregion

        #region Factory Methods
        public static RenewalAdjustments NewRenewalAdjustments(int? in_Contract, int? in_Sequence)
        {
            return Create(in_Contract, in_Sequence);
        }

        public static RenewalAdjustments[] GetAllRenewalAdjustments(int? in_Contract, int? in_Sequence)
        {
            return Fetch(in_Contract, in_Sequence).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract, int? in_Sequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    pList.Add(cm, "in_Sequence", in_Sequence);
                    cm.CommandText = "sp_GetContAdjustments";
                    List<RenewalAdjustments> _list = new List<RenewalAdjustments>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RenewalAdjustments instance = new RenewalAdjustments();
                            instance._ca_key = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,1);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,2);
                            instance._ca_date_occured = GetValueFromReader<DateTime?>(dr,3);
                            instance._ca_reason = GetValueFromReader<String>(dr,4);
                            instance._ca_date_paid = GetValueFromReader<DateTime?>(dr,5);
                            instance._ca_amount = GetValueFromReader<Decimal?>(dr,6);
                            instance._ca_confirmed = GetValueFromReader<String>(dr,7);
                            instance._pct_id = GetValueFromReader<Int32?>(dr,8);
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
                if (GenerateUpdateCommandText(cm, "contract_adjustments", ref pList))
                {
                    cm.CommandText += " WHERE  contract_adjustments.contract_no = @contract_no AND " +
                        "contract_adjustments.contract_seq_number = @contract_seq_number AND " +
                        "contract_adjustments.ca_key = @ca_key ";

                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    pList.Add(cm, "ca_key", GetInitialValue("_ca_key"));
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
                if (GenerateInsertCommandText(cm, "contract_adjustments", pList))
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
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    pList.Add(cm, "ca_key", GetInitialValue("_ca_key"));
                    cm.CommandText = "DELETE FROM contract_adjustments WHERE " +
                    "contract_adjustments.contract_no = @contract_no AND " +
                    "contract_adjustments.contract_seq_number = @contract_seq_number AND " +
                    "contract_adjustments.ca_key = @ca_key";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity(int? ca_key, int? contract_no, int? contract_seq_number)
        {
            _ca_key = ca_key;
            _contract_no = contract_no;
            _contract_seq_number = contract_seq_number;
        }
    }
}
