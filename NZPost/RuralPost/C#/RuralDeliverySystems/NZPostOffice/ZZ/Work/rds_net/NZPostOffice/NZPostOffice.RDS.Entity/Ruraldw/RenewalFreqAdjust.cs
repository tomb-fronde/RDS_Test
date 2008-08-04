using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "frequency_adjustments")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "frequency_adjustments")]
	[MapInfo("fd_unique_seq_number", "_fd_unique_seq_number", "frequency_adjustments")]
	[MapInfo("fd_adjustment_amount", "_fd_adjustment_amount", "frequency_adjustments")]
	[MapInfo("fd_paid_to_date", "_fd_paid_to_date", "frequency_adjustments")]
	[MapInfo("fd_bm_after_extn", "_fd_bm_after_extn", "frequency_adjustments")]
	[MapInfo("fd_confirmed", "_fd_confirmed", "frequency_adjustments")]
	[MapInfo("fd_amount_to_pay", "_fd_amount_to_pay_display_only", "frequency_adjustments")]
	[MapInfo("pct_id", "_pct_id", "frequency_adjustments")]
	[MapInfo("fd_effective_date", "_fd_effective_date", "frequency_adjustments")]
	[MapInfo("sf_key", "_sf_key", "frequency_adjustments")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "frequency_adjustments")]
	[System.Serializable()]

	public class RenewalFreqAdjust : Entity<RenewalFreqAdjust>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private int?  _fd_unique_seq_number;

		[DBField()]
		private decimal?  _fd_adjustment_amount;

		[DBField()]
		private DateTime?  _fd_paid_to_date;

		[DBField()]
		private decimal?  _fd_bm_after_extn;

		[DBField()]
		private string  _fd_confirmed="N";

		[DBField()]
		private decimal?  _fd_amount_to_pay_display_only;

		[DBField()]
		private int?  _pct_id;

		[DBField()]
		private DateTime?  _fd_effective_date;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_delivery_days;


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
                CanReadProperty("FdUniqueSeqNumber", true);
				return _fd_unique_seq_number;
			}
			set
			{
                CanWriteProperty("FdUniqueSeqNumber", true);
				if ( _fd_unique_seq_number != value )
				{
					_fd_unique_seq_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FdAdjustmentAmount
		{
			get
			{
                CanReadProperty("FdAdjustmentAmount", true);
				return _fd_adjustment_amount;
			}
			set
			{
                CanWriteProperty("FdAdjustmentAmount", true);
				if ( _fd_adjustment_amount != value )
				{
					_fd_adjustment_amount = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? FdPaidToDate
		{
			get
			{
                CanReadProperty("FdPaidToDate", true);
				return _fd_paid_to_date;
			}
			set
			{
                CanWriteProperty("FdPaidToDate", true);
				if ( _fd_paid_to_date != value )
				{
					_fd_paid_to_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FdBmAfterExtn
		{
			get
			{
                CanReadProperty("FdBmAfterExtn", true);
				return _fd_bm_after_extn;
			}
			set
			{
                CanWriteProperty("FdBmAfterExtn", true);
				if ( _fd_bm_after_extn != value )
				{
					_fd_bm_after_extn = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FdConfirmed
		{
			get
			{
                CanReadProperty("FdConfirmed", true);
				return _fd_confirmed;
			}
			set
			{
                CanWriteProperty("FdConfirmed", true);
				if ( _fd_confirmed != value )
				{
					_fd_confirmed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FdAmountToPayDisplayOnly
		{
			get
			{
                CanReadProperty("FdAmountToPayDisplayOnly", true);
				return _fd_amount_to_pay_display_only;
			}
			set
			{
                CanWriteProperty("FdAmountToPayDisplayOnly", true);
				if ( _fd_amount_to_pay_display_only != value )
				{
					_fd_amount_to_pay_display_only = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PctId
		{
			get
			{
                CanReadProperty("PctId", true);
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

		public virtual DateTime? FdEffectiveDate
		{
			get
			{
                CanReadProperty("FdEffectiveDate", true);
				return _fd_effective_date;
			}
			set
			{
                CanWriteProperty("FdEffectiveDate", true);
				if ( _fd_effective_date != value )
				{
					_fd_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SfKey
		{
			get
			{
                CanReadProperty("SfKey", true);
				return _sf_key;
			}
			set
			{
                CanWriteProperty("SfKey", true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfDeliveryDays
		{
			get
			{
                CanReadProperty("RfDeliveryDays", true);
				return _rf_delivery_days;
			}
			set
			{
                CanWriteProperty("RfDeliveryDays", true);
				if ( _rf_delivery_days != value )
				{
					_rf_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_1]
//?			string(contract_no) + '/' + string(contract_seq_number)
        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return (_contract_no.GetValueOrDefault().ToString()) + "/" + (_contract_seq_number.GetValueOrDefault().ToString());
            }
        }

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _contract_no,_contract_seq_number,_fd_unique_seq_number );
		}
		#endregion

		#region Factory Methods
		public static RenewalFreqAdjust NewRenewalFreqAdjust( int? contract_no, int? sequence )
		{
			return Create(contract_no, sequence);
		}

		public static RenewalFreqAdjust[] GetAllRenewalFreqAdjust( int? contract_no, int? sequence )
		{
			return Fetch(contract_no, sequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract_no, int? sequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT frequency_adjustments.contract_no,  frequency_adjustments.contract_seq_number,  frequency_adjustments.fd_unique_seq_number,  frequency_adjustments.fd_adjustment_amount,  frequency_adjustments.fd_paid_to_date,  frequency_adjustments.fd_bm_after_extn,  frequency_adjustments.fd_confirmed,  frequency_adjustments.fd_amount_to_pay,  frequency_adjustments.pct_id,  frequency_adjustments.fd_effective_date,  frequency_adjustments.sf_key,  frequency_adjustments.rf_delivery_days  FROM frequency_adjustments  WHERE frequency_adjustments.contract_no = @contract_no  AND frequency_adjustments.contract_seq_number = @sequence  ORDER BY frequency_adjustments.fd_unique_seq_number   ASC  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contract_no", contract_no);
					pList.Add(cm, "sequence", sequence);

					List<RenewalFreqAdjust> _list = new List<RenewalFreqAdjust>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RenewalFreqAdjust instance = new RenewalFreqAdjust();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,1);
                            instance._fd_unique_seq_number = GetValueFromReader<Int32?>(dr,2);
                            instance._fd_adjustment_amount = GetValueFromReader<Decimal?>(dr,3);
                            instance._fd_paid_to_date = GetValueFromReader<DateTime?>(dr,4);

                            instance._fd_bm_after_extn = GetValueFromReader<Decimal?>(dr,5);
                            instance._fd_confirmed = GetValueFromReader<String>(dr,6);
                            instance._fd_amount_to_pay_display_only = GetValueFromReader<Decimal?>(dr,7);
                            instance._pct_id = GetValueFromReader<Int32?>(dr,8);
                            instance._fd_effective_date = GetValueFromReader<DateTime?>(dr,9);

                            instance._sf_key = GetValueFromReader<Int32?>(dr,10);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr,11);

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
				if (GenerateUpdateCommandText(cm, "frequency_adjustments", ref pList))
				{
					cm.CommandText += " WHERE  frequency_adjustments.contract_no = @contract_no AND " + 
						"frequency_adjustments.contract_seq_number = @contract_seq_number AND " + 
						"frequency_adjustments.fd_unique_seq_number = @fd_unique_seq_number ";

					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
					pList.Add(cm, "fd_unique_seq_number", GetInitialValue("_fd_unique_seq_number"));
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
				if (GenerateInsertCommandText(cm, "frequency_adjustments", pList))
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
					pList.Add(cm,"contract_seq_number", GetInitialValue("_contract_seq_number"));
					pList.Add(cm,"fd_unique_seq_number", GetInitialValue("_fd_unique_seq_number"));
						cm.CommandText = "DELETE FROM frequency_adjustments WHERE " +
						"frequency_adjustments.contract_no = @contract_no AND " + 
						"frequency_adjustments.contract_seq_number = @contract_seq_number AND " + 
						"frequency_adjustments.fd_unique_seq_number = @fd_unique_seq_number ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract_no, int? contract_seq_number, int? fd_unique_seq_number )
		{
			_contract_no = contract_no;
			_contract_seq_number = contract_seq_number;
			_fd_unique_seq_number = fd_unique_seq_number;
		}
	}
}
