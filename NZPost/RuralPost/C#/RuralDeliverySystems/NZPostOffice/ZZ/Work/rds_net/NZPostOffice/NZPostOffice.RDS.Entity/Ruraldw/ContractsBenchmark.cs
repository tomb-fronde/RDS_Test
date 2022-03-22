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
    // Add vehicle_number to retreived values (stored proc changed)
    //   -- primarily during testing to bypass using getdate() in the stored proc
    //
    // TJB RPCR_134 July-2019
    // Removed contract_type restriction to November Renewals
    // Reformatted Fetch query for readability

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
    [MapInfo("fuel_key", "_fuel_key", "vehicle")]
    [MapInfo("vor_fuel_rate", "_fuel_rate", "vehicle")]
    [MapInfo("fr_fuel_rate", "_original_fuel_rate", "vehicle")]
    [MapInfo("bench_mark", "_bench_mark", "")]
    [MapInfo("bench_mark_veh", "_bench_mark_veh", "")]
    [System.Serializable()]

    public class ContractsBenchmark : Entity<ContractsBenchmark>
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
        private int? _fuel_key;

        [DBField()]
        private decimal? _fuel_rate;

        [DBField()]
        private decimal? _original_fuel_rate;

        [DBField()]
        private int? _bench_mark;

        [DBField()]
        private int? _bench_mark_veh;

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

        public virtual int? FuelKey
        {
            get
            {
                CanReadProperty("FuelKey", true);
                return _fuel_key;
            }
            set
            {
                CanWriteProperty("FuelKey", true);
                if (_fuel_key != value)
                {
                    _fuel_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? FuelRate
        {
            get
            {
                CanReadProperty("FuelRate", true);
                return _fuel_rate;
            }
            set
            {
                CanWriteProperty("FuelRate", true);
                if (_fuel_rate != value)
                {
                    _fuel_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? OriginalFuelRate
        {
            get
            {
                CanReadProperty("OriginalFuelRate", true);
                return _original_fuel_rate;
            }
            set
            {
                CanWriteProperty("OriginalFuelRate", true);
                if (_original_fuel_rate != value)
                {
                    _original_fuel_rate = value;
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

        public virtual int? BenchMarkVeh
        {
            get
            {
                CanReadProperty("BenchMarkVeh", true);
                return _bench_mark_veh;
            }
            set
            {
                CanWriteProperty("BenchMarkVeh", true);
                if (_bench_mark_veh != value)
                {
                    _bench_mark_veh = value;
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
        public static ContractsBenchmark NewContractsBenchmark(int? al_rg_code)
        {
            return Create(al_rg_code);
        }

        public static ContractsBenchmark[] GetAllContractsBenchmark(int? al_rg_code, DateTime? ad_eff_date)
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
                    // TJB Frequencies & Vehicles  Mar-2022
                    // Changed fetch from using inline query to call to stored procedure 

                    //cm.CommandType = CommandType.Text;
                    //cm.CommandText = "SELECT cr.contract_no, "
                    //               + "       cr.contract_seq_number, "
                    //               + "       cr.con_start_date, "
                    //               + "       cr.con_rates_effective_date, "
                    //               + "       cr.con_expiry_date, "
                    //               + "       cr.con_rg_code_at_renewal, "
                    //               + "       (SELECT v.ft_key FROM	rd.vehicle v "
                    //               + "         WHERE v.vehicle_number = rd.f_GetLatestVehicle(cr.contract_no,cr.contract_seq_number)) as fuel_key, "
                    //               + "       (SELECT vor_fuel_rate FROM rd.vehicle_override_rate vor "
                    //               + "         WHERE vor.contract_no = cr.contract_no "
                    //               + "           AND vor.contract_seq_number = cr.contract_seq_number "
                    //               + "           AND vor.vor_effective_date = "
                    //               + "                  (SELECT max(vor2.vor_effective_date) "
                    //               + "                     FROM rd.vehicle_override_rate vor2 "
                    //               + "                    WHERE vor2.contract_no = vor.contract_no "
                    //               + "                      AND vor2.contract_seq_number = vor.contract_seq_number) "
                    //               + "           AND vor.vor_effective_date >= cr.con_rates_effective_date), "
                    //               + "       (SELECT fr_fuel_rate FROM rd.fuel_rates "
                    //               + "         WHERE ft_key = "
                    //               + "                 (SELECT v.ft_key FROM rd.vehicle v "
                    //               + "                   WHERE v.vehicle_number = rd.f_GetLatestVehicle(cr.contract_no,cr.contract_seq_number)) "
                    //               + "                     AND rg_code = cr.con_rg_code_at_renewal  "
                    //               + "                     AND rr_rates_effective_date = cr.con_rates_effective_date), "
                    //               + "       rd.BenchmarkCalc2005(cr.contract_no, cr.contract_seq_number) as bench_mark "
                    //               + "  FROM rd.contract_renewals cr, rd.contract c "
                    //               + " WHERE c.contract_no = cr.contract_no "
                    //               + "   AND (c.rg_code = @al_rg_code OR @al_rg_code = -1) "
                    ///* TJB RPCR_134 July-2019: disabled   + "   AND c.con_base_cont_type = 1 "  */
                    //                                   + "   AND cr.contract_seq_number = c.con_active_sequence "
                    //                                   + "   AND c.con_date_terminated is null " 
                    //                                   + "   AND cr.con_acceptance_flag = 'Y' "
                    //                                   + "   AND cr.con_expiry_date >= getdate() " 
                    //                                   + " ORDER BY cr.contract_no"; 
                    //
                    //ParameterCollection pList = new ParameterCollection();
                    //pList.Add(cm, "al_rg_code", al_rg_code);

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_ContractsBenchmark";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inRgCode", al_rg_code);
                    pList.Add(cm, "inEffDate", ad_eff_date);

                    List<ContractsBenchmark> _list = new List<ContractsBenchmark>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractsBenchmark instance = new ContractsBenchmark();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._sequence_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr, 2);
                            instance._rates_effective_date = GetValueFromReader<DateTime?>(dr, 3);
                            instance._con_expiry_date = GetValueFromReader<DateTime?>(dr, 4);

                            instance._rg_code = GetValueFromReader<Int32?>(dr, 5);
                            instance._vehicle_number = GetValueFromReader<Int32?>(dr, 6);
                            instance._fuel_key = GetValueFromReader<Int32?>(dr, 7);
                            instance._fuel_rate = GetValueFromReader<Decimal?>(dr, 8);
                            instance._original_fuel_rate = GetValueFromReader<Decimal?>(dr, 9);
                            instance._bench_mark = GetValueFromReader<Int32?>(dr, 10);
                            instance._bench_mark_veh = GetValueFromReader<Int32?>(dr, 11);

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
