using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;


namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB Allowances 15-May-2021: New
    // Merged MaintainAllowances and MaintainVehAllowances to rationalise WMaintainAllowances code
    // [22-June-2021] Changed how function f_GetAllowanceAmount.sql determines net_amount
    //                for fixed-type calculations (no change to MaintainAllowancesV2)
    //
    // TJB Allowances 29-Mar-2021: New
    // Get details for the DMaintainDistanceAllowances tab
    // Derived from MaintainAllowances
    // [31-Mar-2021] Added retreival of vehicle_allowance_rates 
    // [April-2021] Changed total_amount to net_amount
    //              Changed all initial<items> derivations to use GetInitialValue()

    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("alt_key", "_alt_key", "contract_allowance")]
	[MapInfo("contract_no", "_contract_no", "contract_allowance")]
	[MapInfo("ca_effective_date", "_effective_date", "contract_allowance")]
	[MapInfo("ca_annual_amount", "_annual_amount", "contract_allowance")]
	[MapInfo("ca_notes", "_notes", "contract_allowance")]
	[MapInfo("ca_paid_to_date", "_paid_to_date", "contract_allowance")]
	[MapInfo("ca_approved", "_approved", "contract_allowance")]
    [MapInfo("ca_var1", "_ca_var1", "contract_allowance")]
    [MapInfo("ca_dist_day", "_ca_dist_day", "contract_allowance")]
    [MapInfo("ca_hrs_wk", "_ca_hrs_wk", "contract_allowance")]
    [MapInfo("ca_doc_description", "_ca_doc_description", "contract_allowance")]
    [MapInfo("ca_costs_covered", "_ca_costs_covered", "contract_allowance")]
    [MapInfo("ca_row_changed", "_ca_row_changed", "contract_allowance")]
    [MapInfo("var_id", "_var_id", "contract_allowance")]
    [MapInfo("con_title", "_contract_title", "")]
    [MapInfo("alt_description", "_alt_description", "")]
    [MapInfo("alt_rate", "_alt_rate", "")]
    [MapInfo("alt_wks_yr", "_alt_wks_yr", "")]
    [MapInfo("alt_acc", "_alt_acc", "")]
    [MapInfo("alct_id", "_alct_id", "")]
    [MapInfo("alct_description", "_alct_description", "")]
    [MapInfo("var_description", "_var_description", "")]
    [MapInfo("var_carrier_pa", "_var_carrier_pa", "")]
    [MapInfo("var_repairs_pk", "_var_repairs_pk", "")]
    [MapInfo("var_licence_pa", "_var_licence_pa", "")]
    [MapInfo("var_tyres_pk", "_var_tyres_pk", "")]
    [MapInfo("var_allowance_pk", "_var_allowance_pk", "")]
    [MapInfo("var_insurance_pa", "_var_insurance_pa", "")]
    [MapInfo("var_ror_pa", "_var_ror_pa", "")]
    [MapInfo("var_fuel_use_pk", "_var_fuel_use_pk", "")]
    [MapInfo("var_fuel_rate", "_var_fuel_rate", "")]
    [MapInfo("var_ruc_rate_pk", "_var_ruc_rate_pk", "")]
    [System.Serializable()]

	public class MaintainAllowanceV2 : Entity<MaintainAllowanceV2>
	{
        // TJB Allowances 15-May-2021
        
        private int _sqlcode;
        public int SQLCode
        {
            get
            {
                return _sqlcode;
            }
        }

        private string _sqlerrtext;
        public string SQLErrText
        {
            get
            {
                return _sqlerrtext;
            }
        }

        #region Business Methods
		[DBField()]
		private int?  _alt_key;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private DateTime?  _effective_date;

		[DBField()]
		private decimal?  _annual_amount;

		[DBField()]
		private string  _notes;

		[DBField()]
		private DateTime?  _paid_to_date;

		[DBField()]
		private string  _approved;

		[DBField()]
		private string  _contract_title;

        [DBField()]
        private decimal? _ca_var1;

        [DBField()]
        private decimal? _ca_dist_day;

        [DBField()]
        private decimal? _ca_hrs_wk;

        [DBField()]
        private string _alt_description;

        [DBField()]
        private decimal? _alt_rate;

        [DBField()]
        private decimal? _alt_wks_yr;

        [DBField()]
        private decimal? _alt_acc;

        [DBField()]
        private int? _alct_id;

        [DBField()]
        private string _alct_description;

        [DBField()]
        private string _ca_doc_description;

        [DBField()]
        private string _ca_costs_covered;

        [DBField()]
        private string _ca_row_changed;

        [DBField()]
        private int? _var_id;

        [DBField()]
        private string _var_description;

        [DBField()]
        private decimal? _var_carrier_pa;

        [DBField()]
        private decimal? _var_repairs_pk;

        [DBField()]
        private decimal? _var_licence_pa;

        [DBField()]
        private decimal? _var_tyres_pk;

        [DBField()]
        private decimal? _var_allowance_pk;

        [DBField()]
        private decimal? _var_insurance_pa;

        [DBField()]
        private decimal? _var_ror_pa;

        [DBField()]
        private decimal? _var_fuel_use_pk;

        [DBField()]
        private decimal? _var_fuel_rate;

        [DBField()]
        private decimal? _var_ruc_rate_pk;

        [DBField()]
        private decimal? _net_amount;
        private decimal? _calc_amount;

        /*************************************************************************/

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
				if ( _alt_key != value )
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
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? EffectiveDate
		{
			get
			{
			CanReadProperty("EffectiveDate", true);
				return _effective_date;
			}
			set
			{
				CanWriteProperty("EffectiveDate", true);
				if ( _effective_date != value )
				{
					_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? AnnualAmount
		{
			get
			{
				CanReadProperty("AnnualAmount", true);
				return _annual_amount;
			}
			set
			{
				CanWriteProperty("AnnualAmount", true);
				if ( _annual_amount != value )
				{
					_annual_amount = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Notes
		{
			get
			{
				CanReadProperty("Notes", true);
				return _notes;
			}
			set
			{
				CanWriteProperty("Notes", true);
				if ( _notes != value )
				{
					_notes = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? PaidToDate
		{
			get
			{
				CanReadProperty("PaidToDate", true);
				return _paid_to_date;
			}
			set
			{
				CanWriteProperty("PaidToDate", true);
				if ( _paid_to_date != value )
				{
					_paid_to_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Approved
		{
			get
			{
				CanReadProperty("Approved", true);
				return _approved;
			}
			set
			{
				CanWriteProperty("Approved", true);
				if ( _approved != value )
				{
					_approved = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractTitle
		{
			get
			{
				CanReadProperty("ContractTitle", true);
				return _contract_title;
			}
			set
			{
				CanWriteProperty("ContractTitle", true);
				if ( _contract_title != value )
				{
					_contract_title = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual Decimal? CaVar1
        {
            get
            {
                CanReadProperty("CaVar1", true);
                return _ca_var1;
            }
            set
            {
                CanWriteProperty("CaVar1", true);
                if (_ca_var1 != value)
                {
                    _ca_var1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? CaDistDay
        {
            get
            {
                CanReadProperty("CaDistDay", true);
                return _ca_dist_day;
            }
            set
            {
                CanWriteProperty("CaDistDay", true);
                if (_ca_dist_day != value)
                {
                    _ca_dist_day = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? CaHrsWk
        {
            get
            {
                CanReadProperty("CaHrsWk", true);
                return _ca_hrs_wk;
            }
            set
            {
                CanWriteProperty("CaHrsWk", true);
                if (_ca_hrs_wk != value)
                {
                    _ca_hrs_wk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AltDescription
        {
            get
            {
                CanReadProperty("AltDescription", true);
                return _alt_description;
            }
            set
            {
                CanWriteProperty("AltDescription", true);
                if (_alt_description != value)
                {
                    _alt_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? AltRate
        {
            get
            {
                CanReadProperty("AltRate", true);
                return _alt_rate;
            }
            set
            {
                CanWriteProperty("AltRate", true);
                if (_alt_rate != value)
                {
                    _alt_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? AltWksYr
        {
            get
            {
                CanReadProperty("AltWksYr", true);
                return _alt_wks_yr;
            }
            set
            {
                CanWriteProperty("AltWksYr", true);
                if (_alt_wks_yr != value)
                {
                    _alt_wks_yr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? AltAcc
        {
            get
            {
                CanReadProperty("AltAcc", true);
                return _alt_acc;
            }
            set
            {
                CanWriteProperty("AltAcc", true);
                if (_alt_acc != value)
                {
                    _alt_acc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AlctId
        {
            get
            {
                CanReadProperty("AlctId", true);
                return _alct_id;
            }
            set
            {
                CanWriteProperty("AlctId", true);
                if (_alct_id != value)
                {
                    _alct_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AlctDescription
        {
            get
            {
                CanReadProperty("AlctDescription", true);
                return _alct_description;
            }
            set
            {
                CanWriteProperty("AlctDescription", true);
                if (_alct_description != value)
                {
                    _alct_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DocDescription
        {
            get
            {
                CanReadProperty("DocDescription", true);
                return _ca_doc_description;
            }
            set
            {
                CanWriteProperty("DocDescription", true);
                if (_ca_doc_description != value)
                {
                    _ca_doc_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CaCostsCovered
        {
            get
            {
                CanReadProperty("CaCostsCovered", true);
                return _ca_costs_covered;
            }
            set
            {
                CanWriteProperty("CaCostsCovered", true);
                if (_ca_costs_covered != value)
                {
                    _ca_costs_covered = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RowChanged
        {
            get
            {
                CanReadProperty("RowChanged", true);
                return (_ca_row_changed ?? "X");
            }
            set
            {
                CanWriteProperty("RowChanged", true);
                if (_ca_row_changed != value)
                {
                    _ca_row_changed = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VarId
        {
            get
            {
                CanReadProperty("VarId", true);
                return _var_id;
            }
            set
            {
                CanWriteProperty("VarId", true);
                if (_var_id != value)
                {
                    _var_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VarDescription
        {
            get
            {
                CanReadProperty("VarDescription", true);
                return _var_description;
            }
            set
            {
                CanWriteProperty("VarDescription", true);
                if (_var_description != value)
                {
                    _var_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarCarrierPa
        {
            get
            {
                CanReadProperty("VarCarrierPa", true);
                return _var_carrier_pa;
            }
            set
            {
                CanWriteProperty("VarCarrierPa", true);
                if (_var_carrier_pa != value)
                {
                    _var_carrier_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarRepairsPk
        {
            get
            {
                CanReadProperty("VarRepairsPk", true);
                return _var_repairs_pk;
            }
            set
            {
                CanWriteProperty("VarRepairsPk", true);
                if (_var_repairs_pk != value)
                {
                    _var_repairs_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarLicencePa
        {
            get
            {
                CanReadProperty("VarLicencePa", true);
                return _var_licence_pa;
            }
            set
            {
                CanWriteProperty("VarLicencePa", true);
                if (_var_licence_pa != value)
                {
                    _var_licence_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarTyresPk
        {
            get
            {
                CanReadProperty("VarTyresPk", true);
                return _var_tyres_pk;
            }
            set
            {
                CanWriteProperty("VarTyresPk", true);
                if (_var_tyres_pk != value)
                {
                    _var_tyres_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarAllowancePk
        {
            get
            {
                CanReadProperty("VarAllowancePk", true);
                return _var_allowance_pk;
            }
            set
            {
                CanWriteProperty("VarAllowancePk", true);
                if (_var_allowance_pk != value)
                {
                    _var_allowance_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarInsurancePa
        {
            get
            {
                CanReadProperty("VarInsurancePa", true);
                return _var_insurance_pa;
            }
            set
            {
                CanWriteProperty("VarInsurancePa", true);
                if (_var_insurance_pa != value)
                {
                    _var_insurance_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarRorPa
        {
            get
            {
                CanReadProperty("VarRorPa", true);
                return _var_ror_pa;
            }
            set
            {
                CanWriteProperty("VarRorPa", true);
                if (_var_ror_pa != value)
                {
                    _var_ror_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarFuelUsePk
        {
            get
            {
                CanReadProperty("VarFuelUsePk", true);
                return _var_fuel_use_pk;
            }
            set
            {
                CanWriteProperty("VarFuelUsePk", true);
                if (_var_fuel_use_pk != value)
                {
                    _var_fuel_use_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarFuelRate
        {
            get
            {
                CanReadProperty("VarFuelRate", true);
                return _var_fuel_rate;
            }
            set
            {
                CanWriteProperty("VarFuelRate", true);
                if (_var_fuel_rate != value)
                {
                    _var_fuel_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? VarRucRatePk
        {
            get
            {
                CanReadProperty("VarRucRatePk", true);
                return _var_ruc_rate_pk;
            }
            set
            {
                CanWriteProperty("VarRucRatePk", true);
                if (_var_ruc_rate_pk != value)
                {
                    _var_ruc_rate_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NetAmount
        {
            get
            {
                CanReadProperty("NetAmount", true);
                return _net_amount;
            }
            set
            {
                CanWriteProperty("NetAmount", true);
                if (_net_amount != value)
                {
                    _net_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CalcAmount
        {
            get
            {
                CanReadProperty("CalcAmount", true);
                return _calc_amount;
            }
            set
            {
                CanWriteProperty("CalcAmount", true);
                if (_calc_amount != value)
                {
                    _calc_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        /*************************************************************************/
        // The Metex GetInitialValues function doesn't seem to work in WMaintainAllowance
        // but I can get the initial values this way.
        // See WMaintainAllowance.of_add_new_record().
        /*************************************************************************/

        public virtual int? InitialAltKey
        {
            get
            {
                return (int?)GetInitialValue("_alt_key");
            }
        }

        public virtual string InitialAltDescr
        {
            get
            {
                return (string)GetInitialValue("_alt_description");
            }
        }

        public virtual DateTime? InitialEffDate
        {
            get
            {
                return (DateTime?)GetInitialValue("_effective_date");
            }
        }

        public virtual decimal? InitialAmount
        {
            get
            {
                return (decimal?)GetInitialValue("_annual_amount");
            }
        }

        public virtual string InitialApproved
        {
            get
            {
                return (string)GetInitialValue("_approved");
            }
        }

        public virtual string InitialDocDescr
        {
            get
            {
                return (string)GetInitialValue("_ca_doc_description");
            }
        }

        public virtual string InitialNotes
        {
            get
            {
                return (string)GetInitialValue("_notes");
            }
        }

        public virtual string InitialCostsCovered
        {
            get
            {
                return (string)GetInitialValue("_ca_costs_covered");
            }
        }

        public virtual Decimal? InitialCaVar1
        {
            get
            {
                return (decimal?)GetInitialValue("_ca_var1");
            }
        }

        public virtual Decimal? InitialDistDay
        {
            get
            {
                return (decimal?)GetInitialValue("_ca_dist_day");
            }
        }

        public virtual Decimal? InitialHrsWk
        {
            get
            {
                return (decimal?)GetInitialValue("_ca_hrs_wk");
            }
        }

        public virtual int? InitialVarId
        {
            get
            {
                return (int?)GetInitialValue("_var_id");
            }
        }

        public virtual Decimal? InitialCarrierPa
        {
            get
            {
                return (decimal?)GetInitialValue("_var_carrier_pa");
            }
        }

        public virtual Decimal? InitialRepairsPk
        {
            get
            {
                return (decimal?)GetInitialValue("_var_repairs_pk");
            }
        }

        public virtual Decimal? InitialLicencePa
        {
            get
            {
                return (decimal?)GetInitialValue("_var_licence_pa");
            }
        }

        public virtual Decimal? InitialTyresPk
        {
            get
            {
                return (decimal?)GetInitialValue("_var_tyres_pk");
            }
        }

        public virtual Decimal? InitialAllowancePk
        {
            get
            {
                return (decimal?)GetInitialValue("_var_allowance_pk");
            }
        }

        public virtual Decimal? InitialInsurancePa
        {
            get
            {
                return (decimal?)GetInitialValue("_var_insurance_pa");
            }
        }

        public virtual Decimal? InitialRorPa
        {
            get
            {
                return (decimal?)GetInitialValue("_var_ror_pa");
            }
        }

        public virtual decimal? InitialNetAmount
        {
            get
            {
                return (decimal?)GetInitialValue("_net_amount");
            }
        }

        /*************************************************************************/
        
        protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _alt_key,_contract_no,_effective_date );
		}
		#endregion

        private bool isMarkedNew = false;
        public void MarkNewEntity()
        {
            isMarkedNew = true;
            base.MarkNew();
        }
        public void MarkDirtyEntity()
        {
            base.MarkDirty();
        }
        public void MarkCleanEntity()
        {
            isMarkedNew = false;
            base.MarkClean();
        }

        #region Factory Methods
		public static MaintainAllowanceV2 NewMaintainAllowanceV2( int? inContractNo )
		{
			return Create(inContractNo);
		}

        public static MaintainAllowanceV2[] GetAllMaintainAllowanceV2(int? inContractNo, int? inAlctId)
        {
            return Fetch(inContractNo, inAlctId).list;
        }
        #endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? inContractNo, int? inAlctId)
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    _sqlerrtext = "";
                    _sqlcode = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.Text;
					//GenerateSelectCommandText(cm, "contract_allowance");
					//GenerateSelectCommandText(cm, "contract");
                    cm.CommandText =
                            "SELECT ca.alt_key "
                                + ", ca.contract_no "
                                + ", ca.ca_effective_date "
                                + ", ca.ca_annual_amount "
                                + ", ca.ca_notes "
                                + ", ca.ca_paid_to_date "
                                + ", ca.ca_approved "
                                + ", c.con_title "
                                + ", ca.ca_var1 "
                                + ", ca.ca_dist_day "
                                + ", ca.ca_hrs_wk "
                                + ", alt.alt_description "
                                + ", alt.alt_rate "
                                + ", alt.alt_wks_yr "
                                + ", alt.alt_acc "
                                + ", alct.alct_id "
                                + ", alct.alct_description "
                                + ", ca.ca_doc_description "
                                + ", ca.ca_costs_covered "
                                + ", var.var_id "
                                + ", var.var_description "
                                + ", var.var_carrier_pa "
                                + ", var.var_repairs_pk "
                                + ", var.var_licence_pa "
                                + ", var.var_tyres_pk "
                                + ", var.var_allowance_pk "
                                + ", var.var_insurance_pa "
                                + ", var.var_ror_pa "
                                + ", var.var_fuel_use_pk "
                                + ", var.var_fuel_rate "
                                + ", var.var_ruc_rate_pk "
                                + ", ca.ca_row_changed "
                                + ", rd.f_GetAllowanceAmount(ca.contract_no, ca.alt_key, ca_effective_date) "
                            + " FROM rd.contract_allowance ca "
                                + ", rd.contract c "
                                + ", rd.allowance_type alt "
                                + ", rd.allowance_calc_type alct "
                                + ", rd.vehicle_allowance_rates var "
                           + " WHERE ca.contract_no = @inContractNo "
                           + "  AND c.contract_no = ca.contract_no "
                           + "  AND alt.alt_key = ca.alt_key "
                           + "  AND alt.alct_id =  @inAlctId "
                           + "  AND alct.alct_id = alt.alct_id "
                           + "  AND (var.var_id = ca.var_id " 
                           + "       or (ca.var_id is null and var.var_id = 0))"
                           + " ORDER BY alt.alt_description ASC "
                                   + ", ca.ca_effective_date DESC ";

                    pList.Add(cm, "inContractNo", inContractNo);
                    pList.Add(cm, "inAlctId", inAlctId);

					List<MaintainAllowanceV2> _list = new List<MaintainAllowanceV2>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                MaintainAllowanceV2 instance = new MaintainAllowanceV2();
                                instance._alt_key = GetValueFromReader<int?>(dr, 0);
                                instance._contract_no = GetValueFromReader<int?>(dr, 1);
                                instance._effective_date = GetValueFromReader<DateTime?>(dr, 2);
                                instance._annual_amount = GetValueFromReader<decimal?>(dr, 3);
                                instance._notes = dr.GetString(4);
                                instance._paid_to_date = GetValueFromReader<DateTime?>(dr, 5);
                                instance._approved = dr.GetString(6);
                                instance._contract_title = dr.GetString(7);
                                instance._ca_var1 = GetValueFromReader<Decimal?>(dr, 8);
                                instance._ca_dist_day = GetValueFromReader<Decimal?>(dr, 9);
                                instance._ca_hrs_wk = GetValueFromReader<Decimal?>(dr, 10);
                                instance._alt_description = dr.GetString(11);
                                instance._alt_rate = GetValueFromReader<Decimal?>(dr, 12);
                                instance._alt_wks_yr = GetValueFromReader<Decimal?>(dr, 13);
                                instance._alt_acc = GetValueFromReader<Decimal?>(dr, 14);
                                instance._alct_id = GetValueFromReader<int?>(dr, 15);
                                instance._alct_description = dr.GetString(16);
                                instance._ca_doc_description = dr.GetString(17);
                                instance._ca_costs_covered = dr.GetString(18);
                                instance._var_id = GetValueFromReader<int?>(dr, 19);
                                instance._var_description = dr.GetString(20);
                                instance._var_carrier_pa = GetValueFromReader<Decimal?>(dr, 21);
                                instance._var_repairs_pk = GetValueFromReader<Decimal?>(dr, 22);
                                instance._var_licence_pa = GetValueFromReader<Decimal?>(dr, 23);
                                instance._var_tyres_pk = GetValueFromReader<Decimal?>(dr, 24);
                                instance._var_allowance_pk = GetValueFromReader<Decimal?>(dr, 25);
                                instance._var_insurance_pa = GetValueFromReader<Decimal?>(dr, 26);
                                instance._var_ror_pa = GetValueFromReader<Decimal?>(dr, 27);
                                instance._var_fuel_use_pk = GetValueFromReader<Decimal?>(dr, 28);
                                instance._var_fuel_rate = GetValueFromReader<Decimal?>(dr, 29);
                                instance._var_ruc_rate_pk = GetValueFromReader<Decimal?>(dr, 30);
                                instance._ca_row_changed = dr.GetString(31);
                                instance._net_amount = GetValueFromReader<decimal?>(dr, 32);

                                instance._calc_amount = instance._annual_amount;

                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        sqlErrText = e.Message;
                    }
				}
			}
		}

		[ServerMethod()]
		private void UpdateEntity()
		{
            _sqlcode = 0;
            _sqlerrtext = "";

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
				ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "contract_allowance", ref pList))
				{
					cm.CommandText += 
						" WHERE contract_allowance.alt_key = @alt_key " 
						+ " AND contract_allowance.contract_no = @contract_no " 
						+ " AND contract_allowance.ca_effective_date = @ca_effective_date ";

					pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "ca_effective_date", GetInitialValue("_effective_date"));
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
            _sqlcode = 0;
            _sqlerrtext = "";

            using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
				ParameterCollection pList = new ParameterCollection();
                if (isMarkedNew)
                {
                    try
                    {
                        cm.CommandText =
                                "INSERT INTO rd.contract_allowance "
                                + " (alt_key, contract_no, ca_effective_date, ca_annual_amount, ca_notes"
                                + ", ca_paid_to_date, ca_approved, ca_doc_description, ca_costs_covered"
                                + ", ca_var1, ca_dist_day, ca_hrs_wk, var_id, ca_row_changed) "
                                + "VALUES "
                                + " (@alt_key, @contract_no, @effective_date, @annual_amount, @notes"
                                + ", @paid_to_date, @approved, @ca_doc_description, @ca_costs_covered"
                                + ", @ca_var1, @ca_dist_day, @ca_hrs_wk, @var_id, @ca_row_changed)";

                        pList.Add(cm, "alt_key", _alt_key);
                        pList.Add(cm, "contract_no", _contract_no);
                        pList.Add(cm, "effective_date", _effective_date);
                        pList.Add(cm, "annual_amount", _annual_amount);
                        pList.Add(cm, "notes", _notes);
                        pList.Add(cm, "paid_to_date", _paid_to_date);
                        pList.Add(cm, "approved", _approved);
                        pList.Add(cm, "ca_doc_description", _ca_doc_description);
                        pList.Add(cm, "ca_costs_covered", _ca_costs_covered);
                        pList.Add(cm, "var_id", _var_id);
                        pList.Add(cm, "ca_var1", _ca_var1);
                        pList.Add(cm, "ca_dist_day", _ca_dist_day);
                        pList.Add(cm, "ca_hrs_wk", _ca_hrs_wk);
                        pList.Add(cm, "ca_row_changed", _ca_row_changed);

                        DBHelper.ExecuteNonQuery(cm, pList);
                        isMarkedNew = false;

                        StoreInitialValues();
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -2;
                        _sqlerrtext = e.Message;
                    }
                }
                else
                {
                    try
                    {
                        if (GenerateInsertCommandText(cm, "contract_allowance", pList))
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        StoreInitialValues();
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -2;
                        _sqlerrtext = e.Message;
                    }
                }
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
			using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					cm.CommandText = 
						" DELETE FROM contract_allowance " 
						+ "WHERE contract_allowance.alt_key = @alt_key " 
						+ "  AND contract_allowance.contract_no = @contract_no " 
						+ "  AND contract_allowance.ca_effective_date = @ca_effective_date ";

					pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "ca_effective_date", GetInitialValue("_effective_date"));
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? alt_key, int? contract_no, DateTime? effective_date )
		{
			_alt_key = alt_key;
			_contract_no = contract_no;
			_effective_date = effective_date;
		}
	}
}
