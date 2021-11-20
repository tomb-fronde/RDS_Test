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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("fd_unique_seq_number", "_fd_unique_seq_number", "")]
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
	[MapInfo("pct_id", "_pct_id", "")]
	[MapInfo("annualised_amount", "_annualised_amount", "")]
	[MapInfo("expiry_date", "_expiry_date", "")]
	[MapInfo("priority", "_priority", "")]
	[MapInfo("ever_paid", "_ever_paid", "")]
	[System.Serializable()]

	public class OdpsFrequencyAdjustments : Entity<OdpsFrequencyAdjustments>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private int?  _fd_unique_seq_number;

		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private int?  _pct_id;

		[DBField()]
		private decimal?  _annualised_amount;

		[DBField()]
		private DateTime?  _expiry_date;

		[DBField()]
		private int?  _priority;

		[DBField()]
		private string  _ever_paid;

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
                CanWriteProperty("ContractSeqNumber", true);
				if ( _contract_seq_number != value )
				{
					_contract_seq_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdUniqueSeqNumber
		{
			get
			{
				CanReadProperty("FdUniqueSeqNumber",true);
				return _fd_unique_seq_number;
			}
			set
			{
				CanWriteProperty("FdUniqueSeqNumber",true);
				if ( _fd_unique_seq_number != value )
				{
					_fd_unique_seq_number = value;
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

		public virtual int? PctId
		{
			get
			{
				CanReadProperty("PctId",true);
				return _pct_id;
			}
			set
			{
                CanWriteProperty("PctId", true);
				if ( _pct_id != value )
				{
					_pct_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? AnnualisedAmount
		{
			get
			{
				CanReadProperty("AnnualisedAmount",true);
				return _annualised_amount;
			}
			set
			{
                CanWriteProperty("AnnualisedAmount", true);
				if ( _annualised_amount != value )
				{
					_annualised_amount = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ExpiryDate
		{
			get
			{
				CanReadProperty("ExpiryDate",true);
				return _expiry_date;
			}
			set
			{
				CanWriteProperty("ExpiryDate",true);
				if ( _expiry_date != value )
				{
					_expiry_date = value;
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
		public static OdpsFrequencyAdjustments NewOdpsFrequencyAdjustments( int? in_Contract, int? in_Sequence, int? inContractorNo )
		{
			return Create(in_Contract, in_Sequence, inContractorNo);
		}

		public static OdpsFrequencyAdjustments[] GetAllOdpsFrequencyAdjustments( int? in_Contract, int? in_Sequence, int? inContractorNo )
		{
			return Fetch(in_Contract, in_Sequence, inContractorNo).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Contract, int? in_Sequence, int? inContractorNo )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.sp_odps_frequency_adjustments";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Contract", in_Contract);
					pList.Add(cm, "in_Sequence", in_Sequence);
					pList.Add(cm, "inContractorNo", inContractorNo);

					List<OdpsFrequencyAdjustments> _list = new List<OdpsFrequencyAdjustments>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OdpsFrequencyAdjustments instance = new OdpsFrequencyAdjustments();
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
