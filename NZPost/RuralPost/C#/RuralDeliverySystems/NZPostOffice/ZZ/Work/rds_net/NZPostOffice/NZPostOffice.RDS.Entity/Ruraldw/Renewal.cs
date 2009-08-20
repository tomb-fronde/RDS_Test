using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "contract_renewals")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "contract_renewals")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("con_start_date", "_con_start_date", "contract_renewals")]
    [MapInfo("con_rates_effective_date", "_con_rates_effective_date", "contract_renewals")]
    [MapInfo("con_rg_code_at_renewal", "_con_rg_code_at_renewal", "contract_renewals")]
    [MapInfo("con_expiry_date", "_con_expiry_date", "contract_renewals")]
    [MapInfo("con_start_pay_date", "_con_start_pay_date", "contract_renewals")]
    [MapInfo("con_last_paid_date", "_con_last_paid_date", "contract_renewals")]
    [MapInfo("con_processing_hours_per_week", "_con_processing_hours_per_week", "contract_renewals")]
    [MapInfo("con_renewal_benchmark_price", "_con_renewal_benchmark_price", "contract_renewals")]
    [MapInfo("con_renewal_payment_value", "_con_renewal_payment_value", "contract_renewals")]
    [MapInfo("con_relief_driver_name", "_con_relief_driver_name", "contract_renewals")]
    [MapInfo("con_relief_driver_address", "_con_relief_driver_address", "contract_renewals")]
    [MapInfo("con_relief_driver_home_phone", "_con_relief_driver_home_phone", "contract_renewals")]
    [MapInfo("con_date_last_assigned", "_con_date_last_assigned", "")]
    [MapInfo("con_acceptance_flag", "_con_acceptance_flag", "contract_renewals")]
    [MapInfo("con_volume_at_renewal", "_con_volume_at_renewal", "contract_renewals")]
    [MapInfo("con_del_hrs_week_at_renewal", "_con_del_hrs_week_at_renewal", "contract_renewals")]
    [MapInfo("con_distance_at_renewal", "_con_distance_at_renewal", "contract_renewals")]
    [MapInfo("con_no_customers_at_renewal", "_con_no_customers_at_renewal", "")]
    [MapInfo("con_no_rural_private_bags_at_renewal", "_con_no_rural_private_bags_at_", "contract_renewals")]
    [MapInfo("con_no_other_bags_at_renewal", "_con_no_other_bags_at_renewal", "contract_renewals")]
    [MapInfo("con_no_private_bags_at_renewal", "_con_no_private_bags_at_renewa", "contract_renewals")]
    [MapInfo("con_no_post_offices_at_renewal", "_con_no_post_offices_at_renewa", "contract_renewals")]
    [MapInfo("con_no_cmbs_at_renewal", "_con_no_cmbs_at_renewal", "contract_renewals")]
    [MapInfo("con_no_cmb_custs_at_renewal", "_con_no_cmb_custs_at_renewal", "contract_renewals")]
    [System.Serializable()]

    public class Renewal : Entity<Renewal>
    {
        #region Business Methods

        // TJB  RD7_0040  Aug2009
        // Added SQL variables for RequestNextAvaliableSessionDbConnection
        private int _sqlcode = -1;
        public int SQLCode
        {
            get
            {
                return _sqlcode;
            }
        }

        private int _sqldbcode = -1;
        public int SQLDBCode
        {
            get
            {
                return _sqldbcode;
            }
        }

        private string _sqlerrtext = "";
        public string SQLErrText
        {
            get
            {
                return _sqlerrtext;
            }
        }

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private string _con_title;

        [DBField()]
        private DateTime? _con_start_date;

        [DBField()]
        private DateTime? _con_rates_effective_date;

        [DBField()]
        private int? _con_rg_code_at_renewal;

        [DBField()]
        private DateTime? _con_expiry_date;

        [DBField()]
        private DateTime? _con_start_pay_date;

        [DBField()]
        private DateTime? _con_last_paid_date;

        [DBField()]
        private decimal? _con_processing_hours_per_week;

        [DBField()]
        private decimal? _con_renewal_benchmark_price;

        [DBField()]
        private decimal? _con_renewal_payment_value;

        [DBField()]
        private string _con_relief_driver_name;

        [DBField()]
        private string _con_relief_driver_address;

        [DBField()]
        private string _con_relief_driver_home_phone;

        [DBField()]
        private DateTime? _con_date_last_assigned;

        [DBField()]
        private string _con_acceptance_flag;

        [DBField()]
        private int? _con_volume_at_renewal;

        [DBField()]
        private decimal? _con_del_hrs_week_at_renewal;

        [DBField()]
        private decimal? _con_distance_at_renewal;

        [DBField()]
        private int? _con_no_customers_at_renewal;

        [DBField()]
        private int? _con_no_rural_private_bags_at_;

        [DBField()]
        private int? _con_no_other_bags_at_renewal;

        [DBField()]
        private int? _con_no_private_bags_at_renewa;

        [DBField()]
        private int? _con_no_post_offices_at_renewa;

        [DBField()]
        private int? _con_no_cmbs_at_renewal;

        [DBField()]
        private int? _con_no_cmb_custs_at_renewal;

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

        public virtual string ConTitle
        {
            get
            {
                CanReadProperty("ConTitle", true);
                return _con_title;
            }
            set
            {
                CanWriteProperty("ConTitle", true);
                if (_con_title != value)
                {
                    _con_title = value;
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

        public virtual DateTime? ConRatesEffectiveDate
        {
            get
            {
                CanReadProperty("ConRatesEffectiveDate", true);
                return _con_rates_effective_date;
            }
            set
            {
                CanWriteProperty("ConRatesEffectiveDate", true);
                if (_con_rates_effective_date != value)
                {
                    _con_rates_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConRgCodeAtRenewal
        {
            get
            {
                CanReadProperty("ConRgCodeAtRenewal", true);
                return _con_rg_code_at_renewal;
            }
            set
            {
                CanWriteProperty("ConRgCodeAtRenewal", true);
                if (_con_rg_code_at_renewal != value)
                {
                    _con_rg_code_at_renewal = value;
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

        public virtual DateTime? ConStartPayDate
        {
            get
            {
                CanReadProperty("ConStartPayDate", true);
                return _con_start_pay_date;
            }
            set
            {
                CanWriteProperty("ConStartPayDate", true);
                if (_con_start_pay_date != value)
                {
                    _con_start_pay_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastPaidDate
        {
            get
            {
                CanReadProperty("ConLastPaidDate", true);
                return _con_last_paid_date;
            }
            set
            {
                CanWriteProperty("ConLastPaidDate", true);
                if (_con_last_paid_date != value)
                {
                    _con_last_paid_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ConProcessingHoursPerWeek
        {
            get
            {
                CanReadProperty("ConProcessingHoursPerWeek", true);
                return _con_processing_hours_per_week;
            }
            set
            {
                CanWriteProperty("ConProcessingHoursPerWeek", true);
                if (_con_processing_hours_per_week != value)
                {
                    _con_processing_hours_per_week = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ConRenewalBenchmarkPrice
        {
            get
            {
                CanReadProperty("ConRenewalBenchmarkPrice", true);
                return _con_renewal_benchmark_price;
            }
            set
            {
                CanWriteProperty("ConRenewalBenchmarkPrice", true);
                if (_con_renewal_benchmark_price != value)
                {
                    _con_renewal_benchmark_price = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ConRenewalPaymentValue
        {
            get
            {
                CanReadProperty("ConRenewalPaymentValue", true);
                return _con_renewal_payment_value;
            }
            set
            {
                CanWriteProperty("ConRenewalPaymentValue", true);
                if (_con_renewal_payment_value != value)
                {
                    _con_renewal_payment_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConReliefDriverName
        {
            get
            {
                CanReadProperty("ConReliefDriverName", true);
                return _con_relief_driver_name;
            }
            set
            {
                CanWriteProperty("ConReliefDriverName", true);
                if (_con_relief_driver_name != value)
                {
                    _con_relief_driver_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConReliefDriverAddress
        {
            get
            {
                CanReadProperty("ConReliefDriverAddress", true);
                return _con_relief_driver_address;
            }
            set
            {
                CanWriteProperty("ConReliefDriverAddress", true);
                if (_con_relief_driver_address != value)
                {
                    _con_relief_driver_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConReliefDriverHomePhone
        {
            get
            {
                CanReadProperty("ConReliefDriverHomePhone", true);
                return _con_relief_driver_home_phone;
            }
            set
            {
                CanWriteProperty("ConReliefDriverHomePhone", true);
                if (_con_relief_driver_home_phone != value)
                {
                    _con_relief_driver_home_phone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConDateLastAssigned
        {
            get
            {
                CanReadProperty("ConDateLastAssigned", true);
                return _con_date_last_assigned;
            }
            set
            {
                CanWriteProperty("ConDateLastAssigned", true);
                if (_con_date_last_assigned != value)
                {
                    _con_date_last_assigned = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool ConAcceptanceFlag
        {
            get
            {
                CanReadProperty("ConAcceptanceFlag", true);
                return _con_acceptance_flag == "Y";
            }
            set
            {
                CanWriteProperty("ConAcceptanceFlag", true);
                string new_value = value ? "Y" : "N";
                if (_con_acceptance_flag != new_value)
                {
                    _con_acceptance_flag = new_value;
                    PropertyHasChanged("_con_acceptance_flag");
                }
            }
        }

        public virtual int? ConVolumeAtRenewal
        {
            get
            {
                CanReadProperty("ConVolumeAtRenewal", true);
                return _con_volume_at_renewal;
            }
            set
            {
                CanWriteProperty("ConVolumeAtRenewal", true);
                if (_con_volume_at_renewal != value)
                {
                    _con_volume_at_renewal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ConDelHrsWeekAtRenewal
        {
            get
            {
                CanReadProperty("ConDelHrsWeekAtRenewal", true);
                return _con_del_hrs_week_at_renewal;
            }
            set
            {
                CanWriteProperty("ConDelHrsWeekAtRenewal", true);
                if (_con_del_hrs_week_at_renewal != value)
                {
                    _con_del_hrs_week_at_renewal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ConDistanceAtRenewal
        {
            get
            {
                CanReadProperty("ConDistanceAtRenewal", true);
                return _con_distance_at_renewal;
            }
            set
            {
                CanWriteProperty("ConDistanceAtRenewal", true);
                if (_con_distance_at_renewal != value)
                {
                    _con_distance_at_renewal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConNoCustomersAtRenewal
        {
            get
            {
                CanReadProperty("ConNoCustomersAtRenewal", true);
                return _con_no_customers_at_renewal;
            }
            set
            {
                CanWriteProperty("ConNoCustomersAtRenewal", true);
                if (_con_no_customers_at_renewal != value)
                {
                    _con_no_customers_at_renewal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConNoRuralPrivateBagsAt
        {
            get
            {
                CanReadProperty("ConNoRuralPrivateBagsAt", true);
                return _con_no_rural_private_bags_at_;
            }
            set
            {
                CanWriteProperty("ConNoRuralPrivateBagsAt", true);
                if (_con_no_rural_private_bags_at_ != value)
                {
                    _con_no_rural_private_bags_at_ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConNoOtherBagsAtRenewal
        {
            get
            {
                CanReadProperty("ConNoOtherBagsAtRenewal", true);
                return _con_no_other_bags_at_renewal;
            }
            set
            {
                CanWriteProperty("ConNoOtherBagsAtRenewal", true);
                if (_con_no_other_bags_at_renewal != value)
                {
                    _con_no_other_bags_at_renewal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConNoPrivateBagsAtRenewa
        {
            get
            {
                CanReadProperty("ConNoPrivateBagsAtRenewa", true);
                return _con_no_private_bags_at_renewa;
            }
            set
            {
                CanWriteProperty("ConNoPrivateBagsAtRenewa", true);
                if (_con_no_private_bags_at_renewa != value)
                {
                    _con_no_private_bags_at_renewa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConNoPostOfficesAtRenewa
        {
            get
            {
                CanReadProperty("ConNoPostOfficesAtRenewa", true);
                return _con_no_post_offices_at_renewa;
            }
            set
            {
                CanWriteProperty("ConNoPostOfficesAtRenewa", true);
                if (_con_no_post_offices_at_renewa != value)
                {
                    _con_no_post_offices_at_renewa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConNoCmbsAtRenewal
        {
            get
            {
                CanReadProperty("ConNoCmbsAtRenewal", true);
                return _con_no_cmbs_at_renewal;
            }
            set
            {
                CanWriteProperty("ConNoCmbsAtRenewal", true);
                if (_con_no_cmbs_at_renewal != value)
                {
                    _con_no_cmbs_at_renewal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConNoCmbCustsAtRenewal
        {
            get
            {
                CanReadProperty("ConNoCmbCustsAtRenewal", true);
                return _con_no_cmb_custs_at_renewal;
            }
            set
            {
                CanWriteProperty("ConNoCmbCustsAtRenewal", true);
                if (_con_no_cmb_custs_at_renewal != value)
                {
                    _con_no_cmb_custs_at_renewal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Contracttitle
        {
            get
            {
                CanReadProperty("Contracttitle", true);
                return ( _contract_no.GetValueOrDefault().ToString()) + "/" + ( _contract_seq_number.GetValueOrDefault().ToString()) + " " + (_con_title);
            }
        }
        
        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _contract_seq_number);
        }
        #endregion

        #region Factory Methods
        public static Renewal NewRenewal(int? in_ContractNo, int? in_ContractSeq)
        {
            return Create(in_ContractNo, in_ContractSeq);
        }

        public static Renewal[] GetAllRenewal(int? in_ContractNo, int? in_ContractSeq)
        {
            return Fetch(in_ContractNo, in_ContractSeq).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_ContractNo, int? in_ContractSeq)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_ContractNo", in_ContractNo);
                    pList.Add(cm, "in_ContractSeq", in_ContractSeq);
                    cm.CommandText = "sp_GetRenewalInfo";

                    List<Renewal> _list = new List<Renewal>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Renewal instance = new Renewal();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,1);
                            instance._con_title = GetValueFromReader<String>(dr,2);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr,3);
                            instance._con_rates_effective_date = GetValueFromReader<DateTime?>(dr,4);
                            instance._con_rg_code_at_renewal = GetValueFromReader<Int32?>(dr,5);
                            instance._con_expiry_date = GetValueFromReader<DateTime?>(dr,6);
                            instance._con_start_pay_date = GetValueFromReader<DateTime?>(dr,7);
                            instance._con_last_paid_date = GetValueFromReader<DateTime?>(dr,8);
                            instance._con_processing_hours_per_week = GetValueFromReader<Decimal?>(dr,9);
                            instance._con_renewal_benchmark_price = GetValueFromReader<Decimal?>(dr,10);
                            instance._con_renewal_payment_value = GetValueFromReader<Decimal?>(dr,11);
                            instance._con_relief_driver_name = GetValueFromReader<String>(dr,12);
                            instance._con_relief_driver_address = GetValueFromReader<String>(dr,13);
                            instance._con_relief_driver_home_phone = GetValueFromReader<String>(dr,14);
                            instance._con_date_last_assigned = GetValueFromReader<DateTime?>(dr,15);
                            instance._con_acceptance_flag = GetValueFromReader<String>(dr,16);
                            instance._con_volume_at_renewal = GetValueFromReader<Int32?>(dr,17);
                            instance._con_del_hrs_week_at_renewal = GetValueFromReader<Decimal?>(dr,18);
                            instance._con_distance_at_renewal = GetValueFromReader<Decimal?>(dr,19);
                            instance._con_no_customers_at_renewal = GetValueFromReader<Int32?>(dr,20);
                            instance._con_no_rural_private_bags_at_ = GetValueFromReader<Int32?>(dr,21);
                            instance._con_no_other_bags_at_renewal = GetValueFromReader<Int32?>(dr,22);
                            instance._con_no_private_bags_at_renewa = GetValueFromReader<Int32?>(dr,23);
                            instance._con_no_post_offices_at_renewa = GetValueFromReader<Int32?>(dr,24);
                            instance._con_no_cmbs_at_renewal = GetValueFromReader<Int32?>(dr,25);
                            instance._con_no_cmb_custs_at_renewal = GetValueFromReader<Int32?>(dr,26);
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
                // TJB  RD7_0040  Aug2009
                // Replaced generated update statement (it didn't generate anything)
                
                // if (GenerateUpdateCommandText(cm, "contract_renewals", ref pList))
                // {
                //     cm.CommandText += " WHERE  contract_renewals.contract_no = @contract_no and contract_renewals.contract_seq_number = @contract_seq_number";
                // 
                //     pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                //     pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                //     DBHelper.ExecuteNonQuery(cm, pList);
                // }
                cm.CommandText = "update contract_renewals set"
                                    + " con_start_date = @con_start_date,"
                                    + " con_expiry_date = @con_expiry_date,"
                                    + " con_acceptance_flag = @con_acceptance_flag,"
                                    + " con_relief_driver_name = @con_relief_driver_name,"
                                    + " con_relief_driver_address = @con_relief_driver_address,"
                                    + " con_relief_driver_home_phone = @con_relief_driver_home_phone,"
                                    + " con_renewal_payment_value = @con_renewal_payment_value,"
                                    + " con_rg_code_at_renewal = @con_rg_code_at_renewal,"
                                    + " con_volume_at_renewal = @con_volume_at_renewal,"
                                    + " con_del_hrs_week_at_renewal = @con_del_hrs_week_at_renewal,"
                                    + " con_no_customers_at_renewal = @con_no_customers_at_renewal,"
                                    + " con_no_rural_private_bags_at_renewal = @con_no_rural_private_bags_at_,"
                                    + " con_no_other_bags_at_renewal = @con_no_other_bags_at_renewal,"
                                    + " con_no_private_bags_at_renewal = @con_no_private_bags_at_renewa,"
                                    + " con_no_post_offices_at_renewal = @con_no_post_offices_at_renewa,"
                                    + " con_no_cmbs_at_renewal = @con_no_cmbs_at_renewal,"
                                    + " con_no_cmb_custs_at_renewal = @con_no_cmb_custs_at_renewal,"
                                    + " con_processing_hours_per_week = @con_processing_hours_per_week,"
                ;
                int l = cm.CommandText.Length - 1;
                cm.CommandText  = cm.CommandText.Substring(0,l);
                cm.CommandText += " WHERE contract_renewals.contract_no = @contract_no " 
                                   + "and contract_renewals.contract_seq_number = @contract_seq_number";

                pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                pList.Add(cm, "con_start_date", _con_start_date);
                pList.Add(cm, "con_expiry_date", _con_expiry_date);
                pList.Add(cm, "con_acceptance_flag", _con_acceptance_flag);
                pList.Add(cm, "con_relief_driver_name", _con_relief_driver_name);
                pList.Add(cm, "con_relief_driver_address", _con_relief_driver_address);
                pList.Add(cm, "con_relief_driver_home_phone", _con_relief_driver_home_phone);
                pList.Add(cm, "con_renewal_payment_value", _con_renewal_payment_value);
                pList.Add(cm, "con_rg_code_at_renewal", _con_rg_code_at_renewal);
                pList.Add(cm, "con_volume_at_renewal", _con_volume_at_renewal);
                pList.Add(cm, "con_del_hrs_week_at_renewal", _con_del_hrs_week_at_renewal);
                pList.Add(cm, "con_no_customers_at_renewal", _con_no_customers_at_renewal);
                pList.Add(cm, "con_no_rural_private_bags_at_", _con_no_rural_private_bags_at_);
                pList.Add(cm, "con_no_other_bags_at_renewal", _con_no_other_bags_at_renewal);
                pList.Add(cm, "con_no_private_bags_at_renewa", _con_no_private_bags_at_renewa);
                pList.Add(cm, "con_no_post_offices_at_renewa", _con_no_post_offices_at_renewa);
                pList.Add(cm, "con_no_cmbs_at_renewal", _con_no_cmbs_at_renewal);
                pList.Add(cm, "con_no_cmb_custs_at_renewal", _con_no_cmb_custs_at_renewal);
                pList.Add(cm, "con_processing_hours_per_week", _con_processing_hours_per_week);

                try
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                    _sqlcode = 0;
                }
                catch (Exception e)
                {
                    _sqlerrtext = e.Message;
                    _sqlcode = -1;
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
                if (GenerateInsertCommandText(cm, "contract_renewals", pList))
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
                    cm.CommandText += "DELETE FROM contract_renewals WHERE contract_renewals.contract_no = @contract_no and contract_renewals.contract_seq_number = @contract_seq_number";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
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
