using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // TJB 23-.Oct-2013  AP Export File Reformat: New
    // Data definition for GL07 Header record
    //
    // NOTE: Fields are fixed-length strings, which isn't reflected here

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("batch_no", "_batch_no", "")]                // batch_id
	[MapInfo("interface_code", "_interface_code", "")]
	[MapInfo("voucher_type", "_voucher_type", "")]
	[MapInfo("trans_type", "_trans_type", "")]
	[MapInfo("client", "_client", "")]
	[MapInfo("ac_code", "_ac_code", "")]                  // account
	[MapInfo("unused_1", "_unused_1", "")]
	[MapInfo("dim_4", "_dim_4", "")]
	[MapInfo("unused_2", "_unused_2", "")]
	[MapInfo("dim_6", "_dim_6", "")]
	[MapInfo("unused_3", "_unused_3", "")]
	[MapInfo("tax_code", "_tax_code", "")]
	[MapInfo("unused_4", "_unused_4", "")]
	[MapInfo("currency", "_currency", "")]
	[MapInfo("unused_5", "_unused_5", "")]
	[MapInfo("cur_amount", "_cur_amount", "")]
    [MapInfo("unused_6", "_unused_6", "")]
    [MapInfo("description", "_description", "")]
    [MapInfo("unused_7", "_unused_7", "")]
    [MapInfo("invoice_date", "_invoice_date", "")]        // voucher_date
    [MapInfo("invoice_no", "_invoice_no", "")]            // voucher_no
    [MapInfo("unused_8", "_unused_8", "")]
    [MapInfo("rp_invoice_no", "_rp_invoice_no", "")]      // ext_inv_ref
    [MapInfo("unused_9", "_unused_9", "")]
	[MapInfo("pay_transfer", "_pay_transfer", "")]
	[MapInfo("status", "_status", "")]
	[MapInfo("apar_type", "_apar_type", "")]
	[MapInfo("supplier_no", "_supplier_no", "")]          // apar_id
	[MapInfo("unused_10", "_unused_10", "")]
	[MapInfo("bank_acc_type", "_bank_acc_type", "")]  
	[MapInfo("unused_11", "_unused_11", "")]

	[MapInfoIndex(new string[] { "batch_no", "interface_code", "voucher_type", "trans_type", "client",
        "ac_code", "unused_1", "dim_4", "unused_2", "dim_6", "unused_3", "tax_code", "unused_4", 
        "currency","unused_5","cur_amount","unused_6","description","unused_7","invoice_date","invoice_no",
        "unused_8","rp_invoice_no","unused_9","pay_transfer","status","apar_type","supplier_no","unused_10",
        "bank_acc_type","unused_11"})]
	[System.Serializable()]

	public class ApInterfaceGL07Records : Entity<ApInterfaceGL07Records>
	{
		#region Business Methods
		[DBField()]
		private string  _batch_no;

		[DBField()]
		private string  _interface_code;

		[DBField()]
		private string  _voucher_type;

		[DBField()]
		private string  _trans_type;

		[DBField()]
		private string  _client;

		[DBField()]
		private string  _ac_code;

		[DBField()]
		private string  _unused_1;

		[DBField()]
		private string  _dim_4;

		[DBField()]
		private string  _unused_2;

		[DBField()]
		private string  _dim_6;

		[DBField()]
		private string  _unused_3;

		[DBField()]
		private string  _tax_code;

		[DBField()]
		private string  _unused_4;

		[DBField()]
		private string  _currency;

		[DBField()]
		private string  _unused_5;

		[DBField()]
		private string  _cur_amount;

        [DBField()]
        private string _unused_6;

        [DBField()]
        private string _description;

        [DBField()]
		private string  _unused_7;

        [DBField()]
        private string _invoice_date;

        [DBField()]
        private string _invoice_no;

        [DBField()]
		private string  _unused_8;

        [DBField()]
        private string _rp_invoice_no;

        [DBField()]
        private string _unused_9;

        [DBField()]
		private string  _pay_transfer;

		[DBField()]
		private string  _status;

		[DBField()]
		private string  _apar_type;

		[DBField()]
		private string  _supplier_no;

		[DBField()]
		private string  _unused_10;

		[DBField()]
		private string  _bank_acc_type;
		
		[DBField()]
		private string  _unused_11;

//------------------------------------------------------------------------------------------

		public virtual string BatchNo
		{
			get
			{
				CanReadProperty("BatchNo",true);
				return _batch_no;
			}
			set
			{
				CanWriteProperty("BatchNo",true);
				if ( _batch_no != value )
				{
					_batch_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string InterfaceCode
		{
			get
			{
				CanReadProperty("InterfaceCode",true);
				return _interface_code;
			}
			set
			{
				CanWriteProperty("InterfaceCode",true);
				if ( _interface_code != value )
				{
					_interface_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VoucherType
		{
			get
			{
				CanReadProperty("VoucherType",true);
				return _voucher_type;
			}
			set
			{
				CanWriteProperty("VoucherType",true);
				if ( _voucher_type != value )
				{
					_voucher_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string TransType
		{
			get
			{
				CanReadProperty("TransType",true);
				return _trans_type;
			}
			set
			{
				CanWriteProperty("TransType",true);
				if ( _trans_type != value )
				{
					_trans_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Client
		{
			get
			{
				CanReadProperty("Client",true);
				return _client;
			}
			set
			{
				CanWriteProperty("Client",true);
				if ( _client != value )
				{
					_client = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AcCode
		{
			get
			{
                CanReadProperty("AcCode", true);
				return _ac_code;
			}
			set
			{
                CanWriteProperty("AcCode", true);
                if (_ac_code != value)
				{
                    _ac_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Dim4
		{
			get
			{
				CanReadProperty("Dim4",true);
				return _dim_4;
			}
			set
			{
				CanWriteProperty("Dim4",true);
				if ( _dim_4 != value )
				{
					_dim_4 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Dim6
		{
			get
			{
				CanReadProperty("Dim4",true);
				return _dim_6;
			}
			set
			{
				CanWriteProperty("Dim6",true);
				if ( _dim_6 != value )
				{
					_dim_6 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string TaxCode
		{
			get
			{
				CanReadProperty("TaxCode",true);
				return _tax_code;
			}
			set
			{
				CanWriteProperty("TaxCode",true);
				if ( _tax_code != value )
				{
					_tax_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Currency
		{
			get
			{
				CanReadProperty("Currency",true);
				return _currency;
			}
			set
			{
				CanWriteProperty("Currency",true);
				if ( _currency != value )
				{
					_currency = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CurAmount
		{
			get
			{
				CanReadProperty("CurAmount",true);
				return _cur_amount;
			}
			set
			{
				CanWriteProperty("CurAmount",true);
				if ( _cur_amount != value )
				{
					_cur_amount = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Description
        {
            get
            {
                CanReadProperty("Description", true);
                return _description;
            }
            set
            {
                CanWriteProperty("Description", true);
                if (_description != value)
                {
                    _description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string InvoiceDate
		{
			get
			{
				CanReadProperty("InvoiceDate",true);
				return _invoice_date;
			}
			set
			{
				CanWriteProperty("InvoiceDate",true);
				if ( _invoice_date != value )
				{
					_invoice_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string InvoiceNo
		{
			get
			{
				CanReadProperty("InvoiceNo",true);
				return _invoice_no;
			}
			set
			{
				CanWriteProperty("InvoiceNo",true);
				if ( _invoice_no != value )
				{
					_invoice_no = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string RPInvoiceNo
        {
            get
            {
                CanReadProperty("RPInvoiceNo", true);
                return _rp_invoice_no;
            }
            set
            {
                CanWriteProperty("RPInvoiceNo", true);
                if (_rp_invoice_no != value)
                {
                    _rp_invoice_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PayTransfer
		{
			get
			{
				CanReadProperty("PayTransfer",true);
				return _pay_transfer;
			}
			set
			{
				CanWriteProperty("PayTransfer",true);
				if ( _pay_transfer != value )
				{
					_pay_transfer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Status
		{
			get
			{
				CanReadProperty("Status",true);
				return _status;
			}
			set
			{
				CanWriteProperty("Status",true);
				if ( _status != value )
				{
					_status = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AparType
		{
			get
			{
				CanReadProperty("AparType",true);
				return _apar_type;
			}
			set
			{
				CanWriteProperty("AparType",true);
				if ( _apar_type != value )
				{
					_apar_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SupplierNo
		{
			get
			{
				CanReadProperty("SupplierNo",true);
				return _supplier_no;
			}
			set
			{
				CanWriteProperty("SupplierNo",true);
				if ( _supplier_no != value )
				{
					_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string BankAccType
		{
			get
			{
				CanReadProperty("BankAccType",true);
				return _bank_acc_type;
			}
			set
			{
				CanWriteProperty("BankAccType",true);
				if ( _bank_acc_type != value )
				{
					_bank_acc_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused1
		{
			get
			{
				CanReadProperty("Unused1",true);
				return _unused_1;
			}
			set
			{
				CanWriteProperty("Unused1",true);
				if ( _unused_1 != value )
				{
					_unused_1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused2
		{
			get
			{
				CanReadProperty("Unused2",true);
				return _unused_2;
			}
			set
			{
				CanWriteProperty("Unused2",true);
				if ( _unused_2 != value )
				{
					_unused_2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused3
		{
			get
			{
				CanReadProperty("Unused3",true);
				return _unused_3;
			}
			set
			{
				CanWriteProperty("Unused3",true);
				if ( _unused_3 != value )
				{
					_unused_3 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused4
		{
			get
			{
				CanReadProperty("Unused4",true);
				return _unused_4;
			}
			set
			{
				CanWriteProperty("Unused4",true);
				if ( _unused_4 != value )
				{
					_unused_4 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused5
		{
			get
			{
				CanReadProperty("Unused5",true);
				return _unused_5;
			}
			set
			{
				CanWriteProperty("Unused5",true);
				if ( _unused_5 != value )
				{
					_unused_5 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused6
		{
			get
			{
				CanReadProperty("Unused6",true);
				return _unused_6;
			}
			set
			{
				CanWriteProperty("Unused6",true);
				if ( _unused_6 != value )
				{
					_unused_6 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused7
		{
			get
			{
				CanReadProperty("Unused7",true);
				return _unused_7;
			}
			set
			{
				CanWriteProperty("Unused7",true);
				if ( _unused_7 != value )
				{
					_unused_7 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused8
		{
			get
			{
				CanReadProperty("Unused8",true);
				return _unused_8;
			}
			set
			{
				CanWriteProperty("Unused8",true);
				if ( _unused_8 != value )
				{
					_unused_8 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused9
		{
			get
			{
				CanReadProperty("Unused9",true);
				return _unused_9;
			}
			set
			{
				CanWriteProperty("Unused9",true);
				if ( _unused_9 != value )
				{
					_unused_9 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Unused10
		{
			get
			{
				CanReadProperty("Unused10",true);
				return _unused_10;
			}
			set
			{
				CanWriteProperty("Unused10",true);
				if ( _unused_10 != value )
				{
					_unused_10 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Unused11
        {
            get
            {
                CanReadProperty("Unused11", true);
                return _unused_11;
            }
            set
            {
                CanWriteProperty("Unused11", true);
                if (_unused_11 != value)
                {
                    _unused_11 = value;
                    PropertyHasChanged();
                }
            }
        }


//------------------------------------------------------------------------------------------
		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        		
		public static ApInterfaceGL07Records NewApInterfaceGL07Records( DateTime? ProcDate )
		{
			return Create(ProcDate);
		}

		public static ApInterfaceGL07Records[] GetAllApInterfaceGL07Records( DateTime? ProcDate )
		{
			return Fetch(ProcDate).list;
		}

        #endregion

        #region Data Access
        
		[ServerMethod]
		private void FetchEntity( DateTime? ProcDate )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_ap_gl07_records";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ProcDate", ProcDate);

                    List<ApInterfaceGL07Records> _list = new List<ApInterfaceGL07Records>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ApInterfaceGL07Records instance = new ApInterfaceGL07Records();
                            instance.TransType = GetValueFromReader<string>(dr, 0);
                            instance.RPInvoiceNo = GetValueFromReader<string>(dr, 1);
                            instance.InvoiceDate = GetValueFromReader<string>(dr, 2);
                            instance.CurAmount = GetValueFromReader<string>(dr, 3);
                            instance.SupplierNo = GetValueFromReader<string>(dr, 4);
                            instance.AcCode = GetValueFromReader<string>(dr, 5);
                            instance.Description = GetValueFromReader<string>(dr, 6);
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
		private void CreateEntity(  )
		{
		}
		#endregion
	}
}
