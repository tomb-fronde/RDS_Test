using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;


namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB Allowances 9-Mar-2021: New
    // Get details for the DMaintainAllowances tabs
    // [29Mar2021] Updated alt_fixed* names and added alt_ruc_pk
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
    [MapInfo("ca_end_date", "_end_date", "contract_allowance")]
    [MapInfo("ca_doc_description", "_ca_doc_description", "contract_allowance")]
    [MapInfo("ca_costs_covered", "_ca_costs_covered", "contract_allowance")]
    [MapInfo("var_id", "_var_id", "contract_allowance")]
    [MapInfo("ca_row_changed", "_ca_row_changed", "contract_allowance")]
    [MapInfo("con_title", "_contract_title", "")]
    [MapInfo("alt_description", "_alt_description", "")]
    [MapInfo("alt_rate", "_alt_rate", "")]
    [MapInfo("alt_wks_yr", "_alt_wks_yr", "")]
    [MapInfo("alt_acc", "_alt_acc", "")]
    [MapInfo("alt_fuel_pk", "_alt_fuel_pk", "")]
    [MapInfo("alt_ruc_pk", "_alt_ruc_pk", "")]
    [MapInfo("alct_id", "_alct_id", "")]
    [MapInfo("alct_description", "_alct_description", "")]
    [System.Serializable()]

	public class MaintainAllowanceV1 : Entity<MaintainAllowanceV1>
	{
        // TJB RPCR_017 July-2010
        // Added GetCurrentAllowances to limit allowance list to current allowances
        // Added ca_approved column to table

        private int _sqlcode = 0;
        public int SQLCode
        {
            get
            {
                return _sqlcode;
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
        private int? _var_id;

        [DBField()]
        private string _alt_description;

        [DBField()]
        private decimal? _alt_rate;

        [DBField()]
        private decimal? _alt_wks_yr;

        [DBField()]
        private decimal? _alt_acc;

        [DBField()]
        private decimal? _alt_fuel_pk;

        [DBField()]
        private decimal? _alt_ruc_pk;

        [DBField()]
        private int? _alct_id;

        [DBField()]
        private string _alct_description;

        [DBField()]
        private string _ca_doc_description;

        [DBField()]
        private DateTime? _ca_end_date;

        [DBField()]
        private string _ca_costs_covered;

        [DBField()]
        private decimal? _net_amount;
        private decimal? _calc_amount;

        // Used to mark changed rows.  New reords added via WAddAllowance
        // are marked New ("N") and updated in WModifyAllowance. Existing 
        // records that have the amount changed are marked "M" and re-inserted.
        [DBField()]
        private string _ca_row_changed = "X";
        
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

        public virtual Decimal? AltFuelPk
        {
            get
            {
                CanReadProperty("AltFuelPk", true);
                return _alt_fuel_pk;
            }
            set
            {
                CanWriteProperty("AltFuelPk", true);
                if (_alt_fuel_pk != value)
                {
                    _alt_fuel_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? AltRucPk
        {
            get
            {
                CanReadProperty("AltrucPk", true);
                return _alt_ruc_pk;
            }
            set
            {
                CanWriteProperty("AltRucPk", true);
                if (_alt_ruc_pk != value)
                {
                    _alt_ruc_pk = value;
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

        public virtual DateTime? EndDate
        {
            get
            {
                CanReadProperty("EndDate", true);
                return _ca_end_date;
            }
            set
            {
                CanWriteProperty("EndDate", true);
                if (_ca_end_date != value)
                {
                    _ca_end_date = value;
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
		public static MaintainAllowanceV1 NewMaintainAllowanceV1( int? inContractNo )
		{
			return Create(inContractNo);
		}

        public static MaintainAllowanceV1[] GetAllMaintainAllowanceV1(int? inContractNo, int? inAlctId)
        {
            return Fetch(inContractNo, inAlctId).list;
        }
        #endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? inContractNo, int? inAlctId)
		{
            _sqlcode = 0;
            _sqlerrtext = "";
            
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    try
                    {
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
                                    + ", ca.var_id "
                                    + ", alt.alt_description "
                                    + ", alt.alt_rate "
                                    + ", alt.alt_wks_yr "
                                    + ", alt.alt_acc "
                                    + ", alt.alt_fuel_pk "
                                    + ", alt.alt_ruc_pk "
                                    + ", alct.alct_id "
                                    + ", alct.alct_description "
                                    + ", ca.ca_end_date "
                                    + ", ca.ca_doc_description "
                                    + ", ca.ca_costs_covered "
                                    + ", ca.ca_row_changed "
                                    + ", rd.f_GetAllowanceAmount(ca.contract_no, ca.alt_key, ca_effective_date) "
                                 + "FROM rd.contract_allowance ca "
                                    + ", rd.contract c "
                                    + ", rd.allowance_type alt "
                                    + ", rd.allowance_calc_type alct "
                                + "WHERE ca.contract_no = @inContractNo "
                                + "  AND c.contract_no = ca.contract_no "
                                + "  AND alt.alt_key = ca.alt_key "
                                + "  AND alt.alct_id =  @inAlctId "
                                + "  AND alct.alct_id = alt.alct_id "
                                + "ORDER BY alt.alt_description ASC "
                                       + ", ca.ca_effective_date DESC ";

                        pList.Add(cm, "inContractNo", inContractNo);
                        pList.Add(cm, "inAlctId", inAlctId);

					    List<MaintainAllowanceV1> _list = new List<MaintainAllowanceV1>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                MaintainAllowanceV1 instance = new MaintainAllowanceV1();
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
                                instance._var_id = GetValueFromReader<int?>(dr, 11);
                                instance._alt_description = dr.GetString(12);
                                instance._alt_rate = GetValueFromReader<Decimal?>(dr, 13);
                                instance._alt_wks_yr = GetValueFromReader<Decimal?>(dr, 14);
                                instance._alt_acc = GetValueFromReader<Decimal?>(dr, 15);
                                instance._alt_fuel_pk = GetValueFromReader<Decimal?>(dr, 16);
                                instance._alt_ruc_pk = GetValueFromReader<Decimal?>(dr, 17);
                                instance._alct_id = GetValueFromReader<int?>(dr, 18);
                                instance._alct_description = dr.GetString(19);
                                instance._ca_end_date = GetValueFromReader<DateTime?>(dr, 20);
                                instance._ca_doc_description = dr.GetString(21);
                                instance._ca_costs_covered = dr.GetString(22);
                                instance._ca_row_changed = dr.GetString(23);
                                instance._net_amount = GetValueFromReader<decimal?>(dr, 24);

                                // CalcAmt may be needed to calculate previous NetAmt
                                // For FIXED type calculations, the "calculated" amount is the annual amount that was entered;
                                // for the other types, it is the net amount that was calculated
                                if (inAlctId == 1) // 1 == FIXED; CalcAmt may be needed to calculate previous NetAmt
                                    instance._calc_amount = instance._annual_amount;
                                else
                                    instance._calc_amount = instance._net_amount;

                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                        }
                        list = _list.ToArray();
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
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
						+ " AND contract_allowance.ca_effective_date = @effective_date ";

					pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "effective_date", GetInitialValue("_effective_date"));
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
                                + " (@inAltKey, @inContract, @inEffectiveDate, @inAnnualAmount, @inNotes"
                                + ", @inPaidToDate, @inApproved, @inDocDescription, @inCostsCovered"
                                + ", @inVar1, @inDistDay, @inHrsWk, @inVarId, @inRowChanged) ";

                        pList.Add(cm, "inAltKey", _alt_key);
                        pList.Add(cm, "inContract", _contract_no);
                        pList.Add(cm, "inEffectiveDate", _effective_date);
                        pList.Add(cm, "inAnnualAmount", _annual_amount);
                        pList.Add(cm, "inNotes", _notes);
                        pList.Add(cm, "inPaidToDate", _paid_to_date);
                        pList.Add(cm, "inApproved", _approved);
                        pList.Add(cm, "inDocDescription", _ca_doc_description);
                        pList.Add(cm, "inCostsCovered", _ca_costs_covered);
                        pList.Add(cm, "inVarId", _var_id);
                        pList.Add(cm, "inVar1", _ca_var1);
                        pList.Add(cm, "inDistDay", _ca_dist_day);
                        pList.Add(cm, "inHrsWk", _ca_hrs_wk);
                        pList.Add(cm, "inRowChanged", _ca_row_changed);
                        
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
