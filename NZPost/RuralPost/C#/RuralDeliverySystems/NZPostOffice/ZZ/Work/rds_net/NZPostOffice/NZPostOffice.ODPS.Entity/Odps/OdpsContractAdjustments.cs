using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("ca_key", "_ca_key", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("ca_date_occured", "_ca_date_occured", "")]
	[MapInfo("ca_reason", "_ca_reason", "")]
	[MapInfo("ca_date_paid", "_ca_date_paid", "")]
	[MapInfo("ca_amount", "_ca_amount", "")]
	[MapInfo("ca_confirmed", "_ca_confirmed", "")]
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
	[MapInfo("effective_date", "_effective_date", "")]
	[MapInfo("pct_id", "_pct_id", "")]
	[MapInfo("priority", "_priority", "")]
	[MapInfo("ever_paid", "_ever_paid", "")]
	[System.Serializable()]

	public class OdpsContractAdjustments : Entity<OdpsContractAdjustments>
	{
		#region Business Methods
		[DBField()]
		private int?  _ca_key;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private DateTime?  _ca_date_occured;

		[DBField()]
		private string  _ca_reason;

		[DBField()]
		private DateTime?  _ca_date_paid;

		[DBField()]
		private decimal?  _ca_amount;

		[DBField()]
		private string  _ca_confirmed;

		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private DateTime?  _effective_date;

		[DBField()]
		private int?  _pct_id;

		[DBField()]
		private int?  _priority;

		[DBField()]
		private string  _ever_paid;

		public virtual int? CaKey
		{
			get
			{
				CanReadProperty("CaKey",true);
				return _ca_key;
			}
			set
			{
				CanWriteProperty("CaKey",true);
				if ( _ca_key != value )
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
				CanReadProperty("ContractNo",true);
				return _contract_no;
			}
			set
			{
				CanWriteProperty("ContractNo",true);
				if ( _contract_no != value )
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
				CanReadProperty("ContractSeqNumber",true);
				return _contract_seq_number;
			}
			set
			{
				CanWriteProperty("ContractSeqNumber",true);
				if ( _contract_seq_number != value )
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
				CanReadProperty("CaDateOccured",true);
				return _ca_date_occured;
			}
			set
			{
				CanWriteProperty("CaDateOccured",true);
				if ( _ca_date_occured != value )
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
				CanReadProperty("CaReason",true);
				return _ca_reason;
			}
			set
			{
				CanWriteProperty("CaReason",true);
				if ( _ca_reason != value )
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
				CanReadProperty("CaDatePaid",true);
				return _ca_date_paid;
			}
			set
			{
				CanWriteProperty("CaDatePaid",true);
				if ( _ca_date_paid != value )
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
				CanReadProperty("CaAmount",true);
				return _ca_amount;
			}
			set
			{
				CanWriteProperty("CaAmount",true);
				if ( _ca_amount != value )
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
				CanReadProperty("CaConfirmed",true);
				return _ca_confirmed;
			}
			set
			{
				CanWriteProperty("CaConfirmed",true);
				if ( _ca_confirmed != value )
				{
					_ca_confirmed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractorSupplierNo
		{
			get
			{
				CanReadProperty("ContractorSupplierNo",true);
				return _contractor_supplier_no;
			}
			set
			{
				CanWriteProperty("ContractorSupplierNo",true);
				if ( _contractor_supplier_no != value )
				{
					_contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? EffectiveDate
		{
			get
			{
				CanReadProperty("EffectiveDate",true);
				return _effective_date;
			}
			set
			{
				CanWriteProperty("EffectiveDate",true);
				if ( _effective_date != value )
				{
					_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PctId
		{
			get
			{
				CanReadProperty("PctId",true);
				return _pct_id;
			}
			set
			{
				CanWriteProperty("PctId",true);
				if ( _pct_id != value )
				{
					_pct_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Priority
		{
			get
			{
				CanReadProperty("Priority",true);
				return _priority;
			}
			set
			{
				CanWriteProperty("Priority",true);
				if ( _priority != value )
				{
					_priority = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EverPaid
		{
			get
			{
				CanReadProperty("EverPaid",true);
				return _ever_paid;
			}
			set
			{
				CanWriteProperty("EverPaid",true);
				if ( _ever_paid != value )
				{
					_ever_paid = value;
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
		public static OdpsContractAdjustments NewOdpsContractAdjustments( int? in_Contract, int? in_Sequence, int? in_Contractor )
		{
			return Create(in_Contract, in_Sequence, in_Contractor);
		}

		public static OdpsContractAdjustments[] GetAllOdpsContractAdjustments( int? in_Contract, int? in_Sequence, int? in_Contractor )
		{
			return Fetch(in_Contract, in_Sequence, in_Contractor).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Contract, int? in_Sequence, int? in_Contractor )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.sp_odps_getcontractadjust";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Contract", in_Contract);
					pList.Add(cm, "in_Sequence", in_Sequence);
					pList.Add(cm, "in_Contractor", in_Contractor);

					List<OdpsContractAdjustments> _list = new List<OdpsContractAdjustments>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OdpsContractAdjustments instance = new OdpsContractAdjustments();
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
		private void CreateEntity(  )
		{
		}
	}
}
