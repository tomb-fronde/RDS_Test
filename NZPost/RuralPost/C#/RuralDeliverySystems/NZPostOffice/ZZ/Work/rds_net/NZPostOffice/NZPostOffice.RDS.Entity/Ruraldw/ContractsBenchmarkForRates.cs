using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB Frequencies & Allowances  March-2022
    // Changes to handle multiple vehicles per contract
    // Changed from inline query to stored proc
    // Add effective_date to call parameters
    // Add vehicle_number to retreived values
    //   -- primarily during testing to bypass using getdate() in the stored proc
    //
    // TJB RPCR_134 July-2019
    // Removed contract_type restriction to November Renewals
    // Reformatted Fetch query for readability
    //
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "contract_renewals")]
    [MapInfo("contract_seq_number", "_sequence_no", "contract_renewals")]
    [MapInfo("con_start_date", "_con_start_date", "contract_renewals")]
    [MapInfo("con_rates_effective_date", "_rates_effective_date", "contract_renewals")]
    [MapInfo("con_expiry_date", "_con_expiry_date", "contract_renewals")]
    [MapInfo("con_rg_code_at_renewal", "_rg_code", "contract_renewals")]
    [MapInfo("vehicle_number", "_vehicle_number", "")]
    [MapInfo("override_ruc_rate", "_override_ruc_rate", "vehicle_override_rate")]
    [MapInfo("original_ruc_rate", "_original_ruc_rate", "vehicle_override_rate")]
    [MapInfo("bench_mark", "_bench_mark", "vehicle_override_rate")]
    [System.Serializable()]

    public class ContractsBenchmarkForRates : Entity<ContractsBenchmarkForRates>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _sequence_no;

        [DBField()]
        private DateTime? _con_start_date;

        [DBField()]
        private DateTime? _rates_effective_date;

        [DBField()]
        private DateTime? _con_expiry_date;

        [DBField()]
        private int? _rg_code;

        [DBField()]
        private int? _vehicle_number;

        [DBField()]
        private decimal? _override_ruc_rate;

        [DBField()]
        private decimal? _original_ruc_rate;

        [DBField()]
        private int? _bench_mark;

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

        public virtual int? SequenceNo
        {
            get
            {
                CanReadProperty("SequenceNo", true);
                return _sequence_no;
            }
            set
            {
                CanWriteProperty("SequenceNo", true);
                if (_sequence_no != value)
                {
                    _sequence_no = value;
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

        public virtual DateTime? RatesEffectiveDate
        {
            get
            {
                CanReadProperty("RatesEffectiveDate", true);
                return _rates_effective_date;
            }
            set
            {
                CanWriteProperty("RatesEffectiveDate", true);
                if (_rates_effective_date != value)
                {
                    _rates_effective_date = value;
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

        public virtual int? RgCode
        {
            get
            {
                CanReadProperty("RgCode", true);
                return _rg_code;
            }
            set
            {
                CanWriteProperty("RgCode", true);
                if (_rg_code != value)
                {
                    _rg_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleNumber
        {
            get
            {
                CanReadProperty("VehicleNumber", true);
                return _vehicle_number;
            }
            set
            {
                CanWriteProperty("VehicleNumber", true);
                if (_vehicle_number != value)
                {
                    _vehicle_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? OverrideRucRate
        {
            get
            {
                CanReadProperty("OverrideRucRate", true);
                return _override_ruc_rate;
            }
            set
            {
                CanWriteProperty("OverrideRucRate", true);
                if (_override_ruc_rate != value)
                {
                    _override_ruc_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? OriginalRucRate
        {
            get
            {
                CanReadProperty("OriginalRucRate", true);
                return _original_ruc_rate;
            }
            set
            {
                CanWriteProperty("OriginalRucRate", true);
                if (_original_ruc_rate != value)
                {
                    _original_ruc_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? BenchMark
        {
            get
            {
                CanReadProperty("BenchMark", true);
                return _bench_mark;
            }
            set
            {
                CanWriteProperty("BenchMark", true);
                if (_bench_mark != value)
                {
                    _bench_mark = value;
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
        public static ContractsBenchmarkForRates NewContractsBenchmarkForRates(int? al_rg_code)
        {
            return Create(al_rg_code);
        }

        public static ContractsBenchmarkForRates[] GetAllContractsBenchmarkForRates(int? al_rg_code, DateTime? ad_eff_date)
        {
            return Fetch(al_rg_code, ad_eff_date).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_rg_code, DateTime? ad_eff_date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
//                    cm.CommandType = CommandType.Text;
//                    cm.CommandText = "SELECT cr.contract_no, " 
//                                   + "       cr.contract_seq_number, "
//                                   + "       cr.con_start_date, "
//                                   + "       cr.con_rates_effective_date, "
//                                   + "       cr.con_expiry_date, "
//                                   + "       cr.con_rg_code_at_renewal, "
//                                   + "       (SELECT vor_ruc FROM vehicle_override_rate vor "
//                                   + "         WHERE vor.contract_no = cr.contract_no "
//                                   + "           AND vor.contract_seq_number = cr.contract_seq_number "
//                                   + "           AND vor.vor_effective_date " 
//                                   + "                  = (SELECT max(vor2.vor_effective_date) " 
//                                   + "                       FROM vehicle_override_rate vor2 " 
//                                   + "                      WHERE vor2.contract_no = vor.contract_no " 
//                                   + "                        AND vor2.contract_seq_number = vor.contract_seq_number) " 
//                                   + "                        AND vor.vor_effective_date >= cr.con_rates_effective_date) as override_ruc_rate, "
//                                   + "       (SELECT vr_ruc FROM vehicle_rate vr "
//                                   + "         WHERE vr.vt_key = v.vt_key "
//                                   + "           AND vr.vr_rates_effective_date = cr.con_rates_effective_date) as original_ruc_rate, "
//                                   + "       rd.BenchmarkCalc2005(cr.contract_no, " 
//                                   + "       cr.contract_seq_number) as bench_mark " 
//                                   + "  FROM contract_renewals cr, contract c, contract_vehical cv,  vehicle v,  fuel_type ft "
//                                   + " WHERE c.contract_no = cr.contract_no "
//                                   + "   AND cr.contract_no = cv.contract_no " 
//                                   + "   AND cr.contract_seq_number = cv.contract_seq_number "
//                                   + "   AND v.vehicle_number = cv.vehicle_number " 
//                                   + "   AND v.vehicle_number = rd.f_GetLatestVehicle(cr.contract_no,cr.contract_seq_number) "
//                                   + "   AND ft.ft_key = v.ft_key "
//                                   + "   AND ft.ft_description like '%diesel%' " 
//                                   + "   AND (c.rg_code = @al_rg_code OR @al_rg_code = -1) "
///* TJB RPCR_134 July-2019: disabled  + "   AND c.con_base_cont_type = 1 "  */
//                                   + "   AND cr.contract_seq_number = c.con_active_sequence " 
//                                   + "   AND c.con_date_terminated is null  "
//                                   + "   AND cr.con_acceptance_flag = 'Y' "
//                                   + "   AND cr.con_expiry_date >= getdate() " 
//                                   + " ORDER BY cr.contract_no";
//
//                    ParameterCollection pList = new ParameterCollection();
//                    pList.Add(cm, "al_rg_code", al_rg_code);

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_ContractsBenchmarkForRates";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inRgCode", al_rg_code);
                    pList.Add(cm, "inEffDate", ad_eff_date);

                    List<ContractsBenchmarkForRates> _list = new List<ContractsBenchmarkForRates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractsBenchmarkForRates instance = new ContractsBenchmarkForRates();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._sequence_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr, 2);
                            instance._rates_effective_date = GetValueFromReader<DateTime?>(dr, 3);
                            instance._con_expiry_date = GetValueFromReader<DateTime?>(dr, 4);
                            instance._rg_code = GetValueFromReader<Int32?>(dr, 5);
                            instance._vehicle_number = GetValueFromReader<Int32?>(dr, 6);
                            instance._override_ruc_rate = GetValueFromReader<Int32?>(dr, 7);
                            instance._original_ruc_rate = GetValueFromReader<Decimal?>(dr, 8);
                            instance._bench_mark = GetValueFromReader<Int32?>(dr, 9);

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
