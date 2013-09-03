using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // TJB  Release 7.1.10.3 fixups
    // Added retrieval of pr_effective_date and prs_key
    // related to changes in sp_schedule_b
    
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("con_renewal_payment_value", "_con_renewal_payment_value", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("gst_number", "_gst_number", "")]
	[MapInfo("piece_rate_pr_rate", "_piece_rate_pr_rate", "")]
	[MapInfo("piece_rate_type_prt_description", "_piece_rate_type_prt_description", "")]
	[MapInfo("piece_rate_supplier_prs_description", "_piece_rate_supplier_prs_description", "")]
    [MapInfo("piece_rate_type_prt_code", "_piece_rate_type_prt_code", "")]
    [MapInfo("pr_effective_date", "_pr_effective_date", "")]
    [MapInfo("prs_key", "_prs_key", "")]
    [System.Serializable()]

	public class SchedulebSingleContract : Entity<SchedulebSingleContract>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private decimal?  _con_renewal_payment_value;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _gst_number;

		[DBField()]
		private decimal?  _piece_rate_pr_rate;

		[DBField()]
		private string  _piece_rate_type_prt_description;

		[DBField()]
		private string  _piece_rate_supplier_prs_description;

		[DBField()]
		private string  _piece_rate_type_prt_code;

        [DBField()]
        private DateTime? _pr_effective_date;

        [DBField()]
        private int? _prs_key;


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

		public virtual decimal? ConRenewalPaymentValue
		{
			get
			{
                CanReadProperty("ConRenewalPaymentValue", true);
				return _con_renewal_payment_value;
			}
			set
			{
                CanWriteProperty("ConRenewalPaymentValue", true);
				if ( _con_renewal_payment_value != value )
				{
					_con_renewal_payment_value = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConTitle
		{
			get
			{
                CanReadProperty("ConTitle", true);
				return _con_title;
			}
			set
			{
                CanWriteProperty("ConTitle", true);
				if ( _con_title != value )
				{
					_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string GstNumber
		{
			get
			{
                CanReadProperty("GstNumber", true);
				return _gst_number;
			}
			set
			{
                CanWriteProperty("GstNumber", true);
				if ( _gst_number != value )
				{
					_gst_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? PieceRatePrRate
		{
			get
			{
                CanReadProperty("PieceRatePrRate", true);
				return _piece_rate_pr_rate;
			}
			set
			{
                CanWriteProperty("PieceRatePrRate", true);
				if ( _piece_rate_pr_rate != value )
				{
					_piece_rate_pr_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PieceRateTypePrtDescription
		{
			get
			{
                CanReadProperty("PieceRateTypePrtDescription", true);
				return _piece_rate_type_prt_description;
			}
			set
			{
                CanWriteProperty("PieceRateTypePrtDescription", true);
				if ( _piece_rate_type_prt_description != value )
				{
					_piece_rate_type_prt_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PieceRateSupplierPrsDescription
		{
			get
			{
                CanReadProperty("PieceRateSupplierPrsDescription", true);
				return _piece_rate_supplier_prs_description;
			}
			set
			{
                CanWriteProperty("PieceRateSupplierPrsDescription", true);
				if ( _piece_rate_supplier_prs_description != value )
				{
					_piece_rate_supplier_prs_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PieceRateTypePrtCode
		{
			get
			{
                CanReadProperty("PieceRateTypePrtCode", true);
				return _piece_rate_type_prt_code;
			}
			set
			{
                CanWriteProperty("PieceRateTypePrtCode", true);
				if ( _piece_rate_type_prt_code != value )
				{
					_piece_rate_type_prt_code = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual DateTime? PrEffectiveDate
        {
            get
            {
                CanReadProperty("PrEffectiveDate", true);
                return _pr_effective_date;
            }
            set
            {
                CanWriteProperty("PrEffectiveDate", true);
                if (_pr_effective_date != value)
                {
                    _pr_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrsKey
        {
            get
            {
                CanReadProperty("PrsKey", true);
                return _prs_key;
            }
            set
            {
                CanWriteProperty("PrsKey", true);
                if (_prs_key != value)
                {
                    _prs_key = value;
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
		public static SchedulebSingleContract NewSchedulebSingleContract( int? incontract, int? inSequence )
		{
			return Create(incontract, inSequence);
		}

		public static SchedulebSingleContract[] GetAllSchedulebSingleContract( int? incontract, int? inSequence )
		{
			return Fetch(incontract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? incontract, int? inSequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_schedule_b";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "incontract", incontract);
					pList.Add(cm, "inSequence", inSequence);

					List<SchedulebSingleContract> _list = new List<SchedulebSingleContract>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							SchedulebSingleContract instance = new SchedulebSingleContract();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,1);
                            instance._con_renewal_payment_value = GetValueFromReader<decimal?>(dr,2);
                            instance._con_title = GetValueFromReader<string>(dr,3);
                            instance._gst_number = GetValueFromReader<string>(dr,4);
                            instance._piece_rate_pr_rate = GetValueFromReader<decimal?>(dr,5);
                            instance._piece_rate_type_prt_description = GetValueFromReader<string>(dr,6);
                            instance._piece_rate_supplier_prs_description = GetValueFromReader<string>(dr,7);
                            instance._piece_rate_type_prt_code = GetValueFromReader<string>(dr, 8);
                            instance._pr_effective_date = GetValueFromReader<DateTime?>(dr, 9);
                            instance._prs_key = GetValueFromReader<int?>(dr, 10);
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
