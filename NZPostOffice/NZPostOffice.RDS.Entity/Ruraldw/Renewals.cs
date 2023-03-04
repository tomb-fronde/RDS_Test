using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB RPCR_152 June-2020
    // Added column renewal_type
    //
    // TJB  RPCR_093  Feb-2015
    // Added note about _st_active_sequence

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "")]
    [MapInfo("con_start_date", "_con_start_date", "")]
    [MapInfo("con_expiry_date", "_con_expiry_date", "")]
    [MapInfo("con_acceptance_flag", "_con_acceptance_flag", "")]
    [MapInfo("contractor", "_contractor", "")]
    [MapInfo("renewal_type", "_renewal_type", "")]
    [System.Serializable()]

    public class Renewals : Entity<Renewals>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private DateTime? _con_start_date;

        [DBField()]
        private DateTime? _con_expiry_date;

        [DBField()]
        private string _con_acceptance_flag;

        [DBField()]
        private string _contractor;

        [DBField()]
        private string _renewal_type;


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

        public virtual DateTime? ConStartDate
        {
            get
            {
                CanReadProperty("ConStartDate", true);
                return _con_start_date;
            }
            set
            {
                CanWriteProperty("ConStartDate", true);
                if (_con_start_date != value)
                {
                    _con_start_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConExpiryDate
        {
            get
            {
                CanReadProperty("ConExpiryDate", true);
                return _con_expiry_date;
            }
            set
            {
                CanWriteProperty("ConExpiryDate", true);
                if (_con_expiry_date != value)
                {
                    _con_expiry_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConAcceptanceFlag
        {
            get
            {
                CanReadProperty("ConAcceptanceFlag", true);
                return _con_acceptance_flag;
            }
            set
            {
                CanWriteProperty("ConAcceptanceFlag", true);
                if (_con_acceptance_flag != value)
                {
                    _con_acceptance_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Contractor
        {
            get
            {
                CanReadProperty("Contractor", true);
                return _contractor;
            }
            set
            {
                CanWriteProperty("Contractor", true);
                if (_contractor != value)
                {
                    _contractor = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RenewalType
        {
            get
            {
                CanReadProperty("RenewalType", true);
                return _renewal_type;
            }
            set
            {
                CanWriteProperty("RenewalType", true);
                if (_renewal_type != value)
                {
                    _renewal_type = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[status]
        //?IF( contract_seq_number >;0,if(long(describe('st_active.text'))=contract_seq_number, 'Active', if(long(describe('st_active.text'))<;contract_seq_number, if(isnull(con_acceptance_flag) or con_acceptance_flag <;>; 'Y', 'Pending', 'Accepted'), 'Expired')),'')
        private string _st_active_text;
        public virtual string Status
        {
            get
            {
                // NOTE:  _st_active_sequence is the contract.con_active_sequence value for the contract.
                //        It will usually be set to 0 if con_active_sequence is null (but don't count on it)
                CanReadProperty("Compute1", true);
                //IF( contract_seq_number >0,if(long(describe("st_active.text"))=contract_seq_number, "Active", if(long(describe("st_active.text"))<contract_seq_number, if(isnull(con_acceptance_flag) or con_acceptance_flag <> 'Y', "Pending", "Accepted"), "Expired")),'')
                if (_contract_seq_number != null && _contract_seq_number > 0)
                {
                    if (_st_active_text != null && System.Convert.ToInt32(_st_active_text) == _contract_seq_number)
                    {
                        return "Active";
                    }
                    else
                    {
                        if (_st_active_text != null && System.Convert.ToInt32(_st_active_text) < _contract_seq_number)
                        {
                            if (_con_acceptance_flag == null || _con_acceptance_flag != "Y")
                            {
                                return "Pending";
                            }
                            else
                            {
                                return "Accepted";
                            }
                        }
                        else
                        {
                            return "Expired";
                        }
                    }
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (_st_active_text != value)
                {
                    _st_active_text = value;
                }
            }
        }

        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return (_contract_no.GetValueOrDefault().ToString()) + "/" + (_contract_seq_number.GetValueOrDefault().ToString());
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static Renewals NewRenewals(int? in_Contract)
        {
            return Create(in_Contract);
        }

        public static Renewals[] GetAllRenewals(int? in_Contract)
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
                    cm.CommandText = "sp_GetRenewals";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);

                    List<Renewals> _list = new List<Renewals>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Renewals instance = new Renewals();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,1);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._con_expiry_date = GetValueFromReader<DateTime?>(dr,3);
                            instance._con_acceptance_flag = GetValueFromReader<String>(dr,4);
                            instance._contractor = GetValueFromReader<String>(dr,5);
                            instance._renewal_type = GetValueFromReader<String>(dr, 6);
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
