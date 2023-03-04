using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  Allowances  Mar-2021
    // Added columns
    //    ca_end_date
    //    ca_doc_description
    //    var_id
    //    ca_row_changed
    //    alct_id
    //
    // TJB RPCR_017 July-2010
    // Added GetCurrentAllowances to limit allowance list to current allowances
    // Added ca_approved column to table
    
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
    [MapInfo("ca_end_date", "_end_date", "contract_allowance")]
    [MapInfo("ca_doc_description", "_doc_description", "contract_allowance")]
    [MapInfo("var_id", "_var_id", "contract_allowance")]
    [MapInfo("ca_row_changed", "_ca_row_changed", "contract_allowance")]
    [MapInfo("alct_id", "_alct_id", "")]
    [System.Serializable()]

	public class AddAllowance : Entity<AddAllowance>
	{
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
        private DateTime? _end_date;

        [DBField()]
        private string _doc_description;

        [DBField()]
        private int? _alct_id;

        [DBField()]
        private int? _var_id;

        [DBField()]
        private string _ca_row_changed;

        /****************************************************************************/
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

        public virtual DateTime? EndDate
        {
            get
            {
                CanReadProperty("EndDate", true);
                return _end_date;
            }
            set
            {
                CanWriteProperty("EndDate", true);
                if (_end_date != value)
                {
                    _end_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DocDescription
        {
            get
            {
                CanReadProperty("DocDescription", true);
                return _doc_description;
            }
            set
            {
                CanWriteProperty("DocDescription", true);
                if (_doc_description != value)
                {
                    _doc_description = value;
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

        public virtual int? VarId
        {
            get
            {
                CanReadProperty("VarId", true);
                return _var_id;
            }
            set
            {
                CanWriteProperty("AlctId", true);
                if (_var_id != value)
                {
                    _var_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RowChanged
        {
            get
            {
                CanReadProperty("RowChanged", true);
                return _ca_row_changed;
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

        protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _alt_key,_contract_no,_effective_date );
		}
		#endregion
/****************************************************************************/

		#region Factory Methods
		public static AddAllowance NewAddAllowance( int? inContractNo )
		{
			return Create(inContractNo);
		}

        // TJB RPCR_017 July-2010
        // Added inEffDate to limit allowance list to current allowances
        public static AddAllowance[] GetAllAddAllowance(int? inContractNo, DateTime? inEffDate)
        {
            return Fetch(inContractNo, inEffDate).list;
        }
      /*
        // TJB RPCR_017 July-2010
        // Added to limit allowance list to current allowances
        public static AddAllowance[] GetCurrentAllowances(int? inContractNo, DateTime? inEffDate)
        {
            return Fetch(inContractNo, inEffDate).list;
        }
      */
        #endregion

/****************************************************************************/
		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? inContractNo, DateTime? inEffDate)
		{
            // TJB RPCR_017 July-2010: Added inEffDate parameter and modified query
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
                try
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        ParameterCollection pList = new ParameterCollection();
                        cm.CommandType = CommandType.Text;
                        //GenerateSelectCommandText(cm, "contract_allowance");
                        //GenerateSelectCommandText(cm, "contract");
                        cm.CommandText =
                            " SELECT contract_allowance.alt_key"
                            + "    , contract_allowance.contract_no"
                            + "    , contract_allowance.ca_effective_date"
                            + "    , contract_allowance.ca_annual_amount"
                            + "    , contract_allowance.ca_notes"
                            + "    , contract_allowance.ca_paid_to_date"
                            + "    , contract_allowance.ca_approved"
                            + "    , contract.con_title"
                            + "    , contract_allowance.ca_end_date"
                            + "    , contract_allowance.ca_doc_description"
                            + "    , contract_allowance.var_id"
                            + "    , contract_allowance.ca_row_changed"
                            + "    , allowance_type.alct_id"
                            + " FROM rd.contract_allowance, rd.contract, rd.allowance_type "
                            + "WHERE contract_allowance.contract_no = @inContractNo "
                            + "  AND allowance_type.alt_key = contract_allowance.alt_key "
                            + "  AND contract.contract_no = contract_allowance.contract_no ";

                        pList.Add(cm, "inContractNo", inContractNo);
                        if (inEffDate != null)
                        {
                            cm.CommandText += "  AND contract_allowance.ca_effective_date >= @inEffDate ";
                            pList.Add(cm, "inEffDate", inEffDate);
                        }
                        cm.CommandText += "ORDER BY contract_allowance.ca_effective_date DESC ";

                        List<AddAllowance> _list = new List<AddAllowance>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                AddAllowance instance = new AddAllowance();
                                instance._alt_key = GetValueFromReader<int?>(dr, 0);
                                instance._contract_no = GetValueFromReader<int?>(dr, 1);
                                instance._effective_date = GetValueFromReader<DateTime?>(dr, 2);
                                instance._annual_amount = GetValueFromReader<decimal?>(dr, 3);
                                instance._notes = dr.GetString(4);
                                instance._paid_to_date = GetValueFromReader<DateTime?>(dr, 5);
                                instance._approved = dr.GetString(6);
                                instance._contract_title = dr.GetString(7);
                                instance._end_date = GetValueFromReader<DateTime?>(dr, 8);
                                instance._doc_description = dr.GetString(9);
                                instance._var_id = GetValueFromReader<int?>(dr, 10);
                                instance._ca_row_changed = dr.GetString(11);
                                instance._alct_id = GetValueFromReader<int?>(dr, 12);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                }
                catch (Exception e)
                {
                    _sqlcode = -1;
                    _sqlerrtext = e.Message;
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
