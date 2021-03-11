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
	[MapInfo("con_title", "_contract_title", "contract")]
    [MapInfo("ca_var1", "_ca_var1", "contract_allowance")]
    [MapInfo("ca_var2", "_ca_var2", "contract_allowance")]
    [MapInfo("ca_var3", "_ca_var3", "contract_allowance")]
    [MapInfo("alt_description", "_alt_description", "allowance_type")]
    [MapInfo("alt_fixed1", "_alt_fixed1", "allowance_type")]
    [MapInfo("alt_fixed2", "_alt_fixed2", "allowance_type")]
    [MapInfo("alt_fixed3", "_alt_fixed3", "allowance_type")]
    [MapInfo("alt_fixed4", "_alt_fixed4", "allowance_type")]
    [MapInfo("alct_id", "_alct_id", "allowance_calc_type")]
    [MapInfo("alct_description", "_alct_description", "allowance_calc_type")]
    [System.Serializable()]

	public class MaintainAllowance : Entity<MaintainAllowance>
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
        private int? _ca_var1;

        [DBField()]
        private int? _ca_var2;

        [DBField()]
        private decimal? _ca_var3;

        [DBField()]
        private decimal? _ca_var4;

        [DBField()]
        private string _alt_description;

        [DBField()]
        private int? _alt_fixed1;

        [DBField()]
        private decimal? _alt_fixed2;

        [DBField()]
        private decimal? _alt_fixed3;

        [DBField()]
        private decimal? _alt_fixed4;

        [DBField()]
        private int? _alct_id;

        [DBField()]
        private string _alct_description;

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

        public virtual int? CaVar1
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

        public virtual int? CaVar2
        {
            get
            {
                CanReadProperty("CaVar2", true);
                return _ca_var2;
            }
            set
            {
                CanWriteProperty("CaVar2", true);
                if (_ca_var2 != value)
                {
                    _ca_var2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CaVar3
        {
            get
            {
                CanReadProperty("CaVar3", true);
                return _ca_var3;
            }
            set
            {
                CanWriteProperty("CaVar3", true);
                if (_ca_var3 != value)
                {
                    _ca_var3 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CaVar4
        {
            get
            {
                CanReadProperty("CaVar4", true);
                return _ca_var4;
            }
            set
            {
                CanWriteProperty("CaVar4", true);
                if (_ca_var4 != value)
                {
                    _ca_var4 = value;
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

        public virtual int? AltFixed1
        {
            get
            {
                CanReadProperty("AltFixed1", true);
                return _alt_fixed1;
            }
            set
            {
                CanWriteProperty("AltFixed1", true);
                if (_alt_fixed1 != value)
                {
                    _alt_fixed1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? AltFixed2
        {
            get
            {
                CanReadProperty("AltFixed2", true);
                return _alt_fixed2;
            }
            set
            {
                CanWriteProperty("AltFixed2", true);
                if (_alt_fixed2 != value)
                {
                    _alt_fixed2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? AltFixed3
        {
            get
            {
                CanReadProperty("AltFixed3", true);
                return _alt_fixed3;
            }
            set
            {
                CanWriteProperty("AltFixed3", true);
                if (_alt_fixed3 != value)
                {
                    _alt_fixed3 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? AltFixed4
        {
            get
            {
                CanReadProperty("AltFixed4", true);
                return _alt_fixed4;
            }
            set
            {
                CanWriteProperty("AltFixed4", true);
                if (_alt_fixed4 != value)
                {
                    _alt_fixed4 = value;
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

        /*************************************************************************/
        
        protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _alt_key,_contract_no,_effective_date );
		}
		#endregion

		#region Factory Methods
		public static MaintainAllowance NewMaintainAllowance( int? inContractNo )
		{
			return Create(inContractNo);
		}

        public static MaintainAllowance[] GetAllMaintainAllowance(int? inContractNo, DateTime? inEffDate, int? inAlctId)
        {
            return Fetch(inContractNo, inEffDate, inAlctId).list;
        }
/*
        public static MaintainAllowance[] GetMaintainAllowance(int? inContractNo, DateTime? inEffDate)
        {
            int? inAlctId;
            return Fetch(inContractNo, inEffDate, inAlctId).list;
        }
*/
        #endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? inContractNo, DateTime? inEffDate, int? inAlctId)
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.Text;
					//GenerateSelectCommandText(cm, "contract_allowance");
					//GenerateSelectCommandText(cm, "contract");
                    cm.CommandText =
                        " SELECT contract_allowance.alt_key"
                            + ", contract_allowance.contract_no "
                            + ", contract_allowance.ca_effective_date "
                            + ", contract_allowance.ca_annual_amount"
                            + ", contract_allowance.ca_notes "
                            + ", contract_allowance.ca_paid_to_date"
                            + ", contract_allowance.ca_approved "
                            + ", contract.con_title "
                            + ", contract_allowance.ca_var1"
                            + ", contract_allowance.ca_var2"
                            + ", contract_allowance.ca_var3"
                            + ", contract_allowance.ca_var4"
	                        + ", allowance_type.alt_description"
	                        + ", allowance_type.alt_fixed1"
	                        + ", allowance_type.alt_fixed2"
	                        + ", allowance_type.alt_fixed3"
	                        + ", allowance_type.alt_fixed4"
                            + ", allowance_calc_type.alct_id"
                            + ", allowance_calc_type.alct_description"
                        + " FROM rd.contract_allowance " 
                        + "    , rd.contract "
	                    + "    , rd.allowance_type "
                        + "    , rd.allowance_calc_type "
                        + "WHERE contract.contract_no = contract_allowance.contract_no "
                        + "  AND contract_allowance.contract_no = @inContractNo "
                        + "  AND contract_allowance.ca_effective_date >= @inEffDate "
                        + "  AND allowance_type.alct_id = @inAlctId "
                        + "  AND allowance_type.alt_key = contract_allowance.alt_key "
                        + "  AND allowance_calc_type.alct_id = allowance_type.alct_id "
                        + "ORDER BY contract_allowance.contract_no "
                        + "       , contract_allowance.alt_key"
                        + "       , contract_allowance.ca_effective_date DESC";
                    //cm.CommandText += "ORDER BY contract_allowance.ca_effective_date DESC ";

                    pList.Add(cm, "inContractNo", inContractNo);
                    pList.Add(cm, "inEffDate", inEffDate);
                    pList.Add(cm, "inAlctId", inAlctId);

					List<MaintainAllowance> _list = new List<MaintainAllowance>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MaintainAllowance instance = new MaintainAllowance();
							instance._alt_key = GetValueFromReader<int?>(dr,0);
							instance._contract_no = GetValueFromReader<int?>(dr,1);
							instance._effective_date = GetValueFromReader<DateTime?>(dr,2);
							instance._annual_amount = GetValueFromReader<decimal?>(dr,3);
							instance._notes = dr.GetString(4);
							instance._paid_to_date = GetValueFromReader<DateTime?>(dr,5);
							instance._approved = dr.GetString(6);
							instance._contract_title = dr.GetString(7);
                            instance._ca_var1 = GetValueFromReader<int?>(dr, 8);
                            instance._ca_var2 = GetValueFromReader<int?>(dr, 9);
                            instance._ca_var3 = GetValueFromReader<decimal?>(dr, 10);
                            instance._ca_var4 = GetValueFromReader<decimal?>(dr, 11);
                            instance._alt_description = dr.GetString(12);
                            instance._alt_fixed1 = GetValueFromReader<int?>(dr, 13);
                            instance._alt_fixed2 = GetValueFromReader<decimal?>(dr, 14);
                            instance._alt_fixed3 = GetValueFromReader<decimal?>(dr, 15);
                            instance._alt_fixed4 = GetValueFromReader<decimal?>(dr, 16);
                            instance._alct_id = GetValueFromReader<int?>(dr, 17);
                            instance._alct_description = dr.GetString(18);
                            
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
				if (GenerateInsertCommandText(cm, "contract_allowance", pList))
				{
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -2;
                        _sqlerrtext = e.Message;
                    }
				}
				StoreInitialValues();
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
