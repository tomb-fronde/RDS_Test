using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
	[MapInfo("contractor_name", "_contractor_name", "")]
	[MapInfo("con_renewal_payment_value", "_con_renewal_payment_value", "")]
	[MapInfo("adjustments", "_adjustments", "")]
	[MapInfo("oldextn", "_oldextn", "")]
	[MapInfo("newextn", "_newextn", "")]
	[MapInfo("allowances", "_allowances", "")]
	[MapInfo("piecerates", "_piecerates", "")]
	[System.Serializable()]

	public class PaymentProcess : Entity<PaymentProcess>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private string  _contractor_name;

		[DBField()]
		private decimal?  _con_renewal_payment_value;

		[DBField()]
		private decimal?  _adjustments;

		[DBField()]
		private decimal?  _oldextn;

		[DBField()]
		private decimal?  _newextn;

		[DBField()]
		private decimal?  _allowances;

		[DBField()]
		private decimal?  _piecerates;


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

		public virtual int? ContractorSupplierNo
		{
			get
			{
                CanReadProperty("ContractorSupplierNo", true);
				return _contractor_supplier_no;
			}
			set
			{
                CanWriteProperty("ContractorSupplierNo", true);
				if ( _contractor_supplier_no != value )
				{
					_contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorName
		{
			get
			{
                CanReadProperty("ContractorName", true);
				return _contractor_name;
			}
			set
			{
                CanWriteProperty("ContractorName", true);
				if ( _contractor_name != value )
				{
					_contractor_name = value;
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

		public virtual decimal? Adjustments
		{
			get
			{
                CanReadProperty("Adjustments", true);
				return _adjustments;
			}
			set
			{
                CanWriteProperty("Adjustments", true);
				if ( _adjustments != value )
				{
					_adjustments = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Oldextn
		{
			get
			{
                CanReadProperty("Oldextn", true);
				return _oldextn;
			}
			set
			{
                CanWriteProperty("Oldextn", true);
				if ( _oldextn != value )
				{
					_oldextn = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Newextn
		{
			get
			{
                CanReadProperty("Newextn", true);
				return _newextn;
			}
			set
			{
                CanWriteProperty("Newextn", true);
				if ( _newextn != value )
				{
					_newextn = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Allowances
		{
			get
			{
                CanReadProperty("Allowances", true);
				return _allowances;
			}
			set
			{
                CanWriteProperty("Allowances", true);
				if ( _allowances != value )
				{
					_allowances = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Piecerates
		{
			get
			{
                CanReadProperty("Piecerates", true);
				return _piecerates;
			}
			set
			{
                CanWriteProperty("Piecerates", true);
				if ( _piecerates != value )
				{
					_piecerates = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[con_val_old_extn]
			//?if(isnull(con_renewal_payment_value),0,con_renewal_payment_value) + if(isnull(oldextn),0,oldextn)

			// needs to implement compute expression manually:
			// compute control name=[monthly_amount]
			//?if(isnull(con_renewal_payment_value),0,con_renewal_payment_value) + if(isnull(oldextn),0,oldextn) + if(isnull(newextn),0,newextn) + if(isnull(allowances),0,allowances) + if(isnull(piecerates),0,piecerates)


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static PaymentProcess NewPaymentProcess( DateTime? inPayPeriod )
		{
			return Create(inPayPeriod);
		}

		public static PaymentProcess[] GetAllPaymentProcess( DateTime? inPayPeriod )
		{
			return Fetch(inPayPeriod).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( DateTime? inPayPeriod )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_PaymentProcess";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inPayPeriod", inPayPeriod);

					List<PaymentProcess> _list = new List<PaymentProcess>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PaymentProcess instance = new PaymentProcess();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,1);
                            instance._con_title = GetValueFromReader<string>(dr,2);
                            instance._contractor_supplier_no = GetValueFromReader<int?>(dr,3);
                            instance._contractor_name = GetValueFromReader<string>(dr,4);
                            instance._con_renewal_payment_value = GetValueFromReader<decimal?>(dr,5);
                            instance._adjustments = GetValueFromReader<decimal?>(dr,6);
                            instance._oldextn = GetValueFromReader<decimal?>(dr,7);
                            instance._newextn = GetValueFromReader<decimal?>(dr,8);
                            instance._allowances = GetValueFromReader<decimal?>(dr,9);
                            instance._piecerates = GetValueFromReader<decimal?>(dr,10);
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
