using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "contract_allowance")]
	[MapInfo("alt_key", "_alt_key", "contract_allowance")]
	[MapInfo("ca_effective_date", "_effective_date", "contract_allowance")]
	[MapInfo("ca_paid_to_date", "_paid_to_date", "contract_allowance")]
	[MapInfo("ca_annual_amount", "_annual_amount", "contract_allowance")]
	[MapInfo("ca_notes", "_notes", "contract_allowance")]
	[MapInfo("alt_description", "_alt_description", "allowance_type")]
	[System.Serializable()]

	public class AllowanceBreakdown : Entity<AllowanceBreakdown>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _alt_key;

		[DBField()]
		private DateTime?  _effective_date;

		[DBField()]
		private DateTime?  _paid_to_date;

		[DBField()]
		private decimal?  _annual_amount;

		[DBField()]
		private string  _notes;

		[DBField()]
		private string  _alt_description;


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
				if ( _alt_description != value )
				{
					_alt_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _contract_no,_alt_key,_effective_date );
		}
		#endregion

		#region Factory Methods
		public static AllowanceBreakdown NewAllowanceBreakdown( int? inContractNo, int? inAltKey )
		{
			return Create(inContractNo, inAltKey);
		}

		public static AllowanceBreakdown[] GetAllAllowanceBreakdown( int? inContractNo, int? inAltKey )
		{
			return Fetch(inContractNo, inAltKey).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContractNo, int? inAltKey )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContractNo", inContractNo);
					pList.Add(cm, "inAltKey", inAltKey);
                    //GenerateSelectCommandText(cm, "contract_allowance");
                    //GenerateSelectCommandText(cm, "allowance_type");
                    cm.CommandText="SELECT contract_allowance.contract_no,contract_allowance.alt_key,"+
                        "contract_allowance.ca_effective_date ,contract_allowance.ca_paid_to_date ,"+
                        "contract_allowance.ca_annual_amount ,contract_allowance.ca_notes ,"+
                        "allowance_type.alt_description "+
                        "FROM rd.contract_allowance ,rd.allowance_type "+     
                        "WHERE (allowance_type.alt_key = contract_allowance.alt_key) and "+
                        "((contract_allowance.contract_no = @inContractNo ) And  "+
                        "(contract_allowance.alt_key = @inAltKey)) "+
                        "ORDER BY contract_allowance.ca_effective_date DESC";

					List<AllowanceBreakdown> _list = new List<AllowanceBreakdown>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							AllowanceBreakdown instance = new AllowanceBreakdown();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._alt_key = GetValueFromReader<int?>(dr,1);
                            instance._effective_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._paid_to_date = GetValueFromReader<DateTime?>(dr,3);
                            instance._annual_amount = GetValueFromReader<decimal?>(dr,4);
                            instance._notes = GetValueFromReader<string>(dr,5);
                            instance._alt_description = GetValueFromReader<string>(dr,6);
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
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "contract_allowance", ref pList))
				{
					cm.CommandText += " WHERE  contract_allowance.contract_no = @contract_no AND " + 
						"contract_allowance.alt_key = @alt_key AND " + 
						"contract_allowance.ca_effective_date = @ca_effective_date ";

					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
					pList.Add(cm, "ca_effective_date", GetInitialValue("_effective_date"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "contract_allowance", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
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
					pList.Add(cm,"contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm,"alt_key", GetInitialValue("_alt_key"));
					pList.Add(cm,"ca_effective_date", GetInitialValue("_effective_date"));
						cm.CommandText = "DELETE FROM contract_allowance WHERE " +
						"contract_allowance.contract_no = @contract_no AND " + 
						"contract_allowance.alt_key = @alt_key AND " + 
						"contract_allowance.ca_effective_date = @ca_effective_date ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract_no, int? alt_key, DateTime? effective_date )
		{
			_contract_no = contract_no;
			_alt_key = alt_key;
			_effective_date = effective_date;
		}
	}
}
