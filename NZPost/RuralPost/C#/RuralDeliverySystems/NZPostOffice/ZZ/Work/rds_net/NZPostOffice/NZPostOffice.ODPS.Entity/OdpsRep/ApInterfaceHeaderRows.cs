//qtdong
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
    // TJB 23-.Oct-2013  AP Export File Reformat
    // Add supplier_no to retrieved values (was unused Column29)

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("transaction_id_1", "_transaction_id_1", "")]
	[MapInfo("vendor_2", "_vendor_2", "")]
	[MapInfo("vendor_location_3", "_vendor_location_3", "")]
	[MapInfo("invoice_no_4", "_invoice_no_4", "")]
	[MapInfo("invoice_date_5", "_invoice_date_5", "")]
	[MapInfo("payment_number_6", "_payment_number_6", "")]
	[MapInfo("column_7", "_column_7", "")]
	[MapInfo("column_8", "_column_8", "")]
	[MapInfo("column_9", "_column_9", "")]
	[MapInfo("column_10", "_column_10", "")]
	[MapInfo("column_11", "_column_11", "")]
	[MapInfo("column_12", "_column_12", "")]
	[MapInfo("column_13", "_column_13", "")]
	[MapInfo("column_14", "_column_14", "")]
	[MapInfo("column_15", "_column_15", "")]
	[MapInfo("column_16", "_column_16", "")]
	[MapInfo("column_17", "_column_17", "")]
	[MapInfo("column_18", "_column_18", "")]
	[MapInfo("column_19", "_column_19", "")]
	[MapInfo("column_20", "_column_20", "")]
	[MapInfo("column_21", "_column_21", "")]
	[MapInfo("column_22", "_column_22", "")]
	[MapInfo("column_23", "_column_23", "")]
	[MapInfo("column_24", "_column_24", "")]
	[MapInfo("column_25", "_column_25", "")]
	[MapInfo("column_26", "_column_26", "")]
	[MapInfo("column_27", "_column_27", "")]
    [MapInfo("column_28", "_column_28", "")]
	[MapInfo("supplier_no_29", "_supplier_no_29", "")]  // was column_29
	[MapInfo("column_30", "_column_30", "")]
	[MapInfo("column_31", "_column_31", "")]
	[MapInfo("column_32", "_column_32", "")]
	[MapInfo("column_33", "_column_33", "")]
	[MapInfo("column_34", "_column_34", "")]
	[MapInfo("column_35", "_column_35", "")]
	[MapInfo("column_36", "_column_36", "")]
	[MapInfo("column_37", "_column_37", "")]
	[MapInfo("column_38", "_column_38", "")]
	[MapInfo("column_39", "_column_39", "")]
	[MapInfo("column_40", "_column_40", "")]
	[MapInfo("column_41", "_column_41", "")]
	[MapInfo("column_42", "_column_42", "")]
	[MapInfo("column_43", "_column_43", "")]
	[MapInfo("column_44", "_column_44", "")]
	[MapInfo("column_45", "_column_45", "")]
	[MapInfo("column_46", "_column_46", "")]
	[MapInfo("column_47", "_column_47", "")]
	[MapInfo("column_48", "_column_48", "")]
	[MapInfo("column_49", "_column_49", "")]
	[MapInfo("column_50", "_column_50", "")]
	[MapInfo("column_51", "_column_51", "")]
	[MapInfo("column_52", "_column_52", "")]
	[MapInfo("column_53", "_column_53", "")]
	[MapInfo("column_54", "_column_54", "")]
	[MapInfo("column_55", "_column_55", "")]
	[MapInfo("column_56", "_column_56", "")]
	[MapInfo("column_57", "_column_57", "")]
	[MapInfo("column_58", "_column_58", "")]

    [MapInfoIndex(new string[] { "transaction_id_1", "vendor_2", "vendor_location_3", "invoice_no_4", "invoice_date_5", "payment_number_6", "column_7", "column_8", "column_9", "column_10", "column_11", "column_12", "column_13", "column_14", "column_15", 
        "column_16", "column_17" , "column_18" , "column_19" , "column_20"  , "column_21" , "column_22" , "column_23" , "column_24" , "column_25" , "column_26" , "column_27" , "column_28" , "supplier_no_29" , "column_30",
        "column_31","column_32","column_33","column_34","column_35","column_36","column_37","column_38","column_39","column_40","column_41","column_42","column_43","column_44","column_45",
        "column_46","column_47","column_48","column_49","column_50","column_51","column_52","column_53","column_54","column_55","column_56","column_57","column_58"})]
	[System.Serializable()]

	public class ApInterfaceHeaderRows : Entity<ApInterfaceHeaderRows>
	{
		#region Business Methods
		[DBField()]
		private string  _transaction_id_1;

		[DBField()]
		private string  _vendor_2;

		[DBField()]
		private string  _vendor_location_3;

		[DBField()]
		private string  _invoice_no_4;

		[DBField()]
		private string  _invoice_date_5;

		[DBField()]
		private int?  _payment_number_6;

		[DBField()]
		private string  _column_7;

		[DBField()]
		private string  _column_8;

		[DBField()]
		private string  _column_9;

		[DBField()]
		private string  _column_10;

		[DBField()]
		private string  _column_11;

		[DBField()]
		private string  _column_12;

		[DBField()]
		private string  _column_13;

		[DBField()]
		private string  _column_14;

		[DBField()]
		private string  _column_15;

		[DBField()]
		private string  _column_16;

		[DBField()]
		private string  _column_17;

		[DBField()]
		private string  _column_18;

		[DBField()]
		private string  _column_19;

		[DBField()]
		private string  _column_20;

		[DBField()]
		private string  _column_21;

		[DBField()]
		private string  _column_22;

		[DBField()]
		private string  _column_23;

		[DBField()]
		private string  _column_24;

		[DBField()]
		private string  _column_25;

		[DBField()]
		private string  _column_26;

		[DBField()]
		private string  _column_27;

		[DBField()]
		private string  _column_28;

		[DBField()]
        private string  _supplier_no_29; // was _column_29;

		[DBField()]
		private string  _column_30;

		[DBField()]
		private string  _column_31;

		[DBField()]
		private string  _column_32;

		[DBField()]
		private string  _column_33;

		[DBField()]
		private string  _column_34;

		[DBField()]
		private string  _column_35;

		[DBField()]
		private string  _column_36;

		[DBField()]
		private string  _column_37;

		[DBField()]
		private string  _column_38;

		[DBField()]
		private string  _column_39;

		[DBField()]
		private string  _column_40;

		[DBField()]
		private string  _column_41;

		[DBField()]
		private string  _column_42;

		[DBField()]
		private string  _column_43;

		[DBField()]
		private string  _column_44;

		[DBField()]
		private string  _column_45;

		[DBField()]
		private string  _column_46;

		[DBField()]
		private string  _column_47;

		[DBField()]
		private string  _column_48;

		[DBField()]
		private string  _column_49;

		[DBField()]
		private string  _column_50;

		[DBField()]
		private string  _column_51;

		[DBField()]
		private string  _column_52;

		[DBField()]
		private string  _column_53;

		[DBField()]
		private string  _column_54;

		[DBField()]
		private string  _column_55;

		[DBField()]
		private string  _column_56;

		[DBField()]
		private string  _column_57;

		[DBField()]
		private string  _column_58;


		public virtual string TransactionId1
		{
			get
			{
				CanReadProperty("TransactionId1",true);
				return _transaction_id_1;
			}
			set
			{
				CanWriteProperty("TransactionId1",true);
				if ( _transaction_id_1 != value )
				{
					_transaction_id_1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Vendor2
		{
			get
			{
				CanReadProperty("Vendor2",true);
				return _vendor_2;
			}
			set
			{
				CanWriteProperty("Vendor2",true);
				if ( _vendor_2 != value )
				{
					_vendor_2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VendorLocation3
		{
			get
			{
				CanReadProperty("VendorLocation3",true);
				return _vendor_location_3;
			}
			set
			{
				CanWriteProperty("VendorLocation3",true);
				if ( _vendor_location_3 != value )
				{
					_vendor_location_3 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string InvoiceNo4
		{
			get
			{
				CanReadProperty("InvoiceNo4",true);
				return _invoice_no_4;
			}
			set
			{
				CanWriteProperty("InvoiceNo4",true);
				if ( _invoice_no_4 != value )
				{
					_invoice_no_4 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string InvoiceDate5
		{
			get
			{
				CanReadProperty("InvoiceDate5",true);
				return _invoice_date_5;
			}
			set
			{
				CanWriteProperty("InvoiceDate5",true);
				if ( _invoice_date_5 != value )
				{
					_invoice_date_5 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PaymentNumber6
		{
			get
			{
				CanReadProperty("PaymentNumber6",true);
				return _payment_number_6;
			}
			set
			{
				CanWriteProperty("PaymentNumber6",true);
				if ( _payment_number_6 != value )
				{
					_payment_number_6 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column7
		{
			get
			{
				CanReadProperty("Column7",true);
				return _column_7;
			}
			set
			{
				CanWriteProperty("Column7",true);
				if ( _column_7 != value )
				{
					_column_7 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column8
		{
			get
			{
				CanReadProperty("Column8",true);
				return _column_8;
			}
			set
			{
				CanWriteProperty("Column8",true);
				if ( _column_8 != value )
				{
					_column_8 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column9
		{
			get
			{
				CanReadProperty("Column9",true);
				return _column_9;
			}
			set
			{
				CanWriteProperty("Column9",true);
				if ( _column_9 != value )
				{
					_column_9 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column10
		{
			get
			{
				CanReadProperty("Column10",true);
				return _column_10;
			}
			set
			{
				CanWriteProperty("Column10",true);
				if ( _column_10 != value )
				{
					_column_10 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column11
		{
			get
			{
				CanReadProperty("Column11",true);
				return _column_11;
			}
			set
			{
				CanWriteProperty("Column11",true);
				if ( _column_11 != value )
				{
					_column_11 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column12
		{
			get
			{
				CanReadProperty("Column12",true);
				return _column_12;
			}
			set
			{
				CanWriteProperty("Column12",true);
				if ( _column_12 != value )
				{
					_column_12 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column13
		{
			get
			{
				CanReadProperty("Column13",true);
				return _column_13;
			}
			set
			{
				CanWriteProperty("Column13",true);
				if ( _column_13 != value )
				{
					_column_13 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column14
		{
			get
			{
				CanReadProperty("Column14",true);
				return _column_14;
			}
			set
			{
				CanWriteProperty("Column14",true);
				if ( _column_14 != value )
				{
					_column_14 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column15
		{
			get
			{
				CanReadProperty("Column15",true);
				return _column_15;
			}
			set
			{
				CanWriteProperty("Column15",true);
				if ( _column_15 != value )
				{
					_column_15 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column16
		{
			get
			{
				CanReadProperty("Column16",true);
				return _column_16;
			}
			set
			{
				CanWriteProperty("Column16",true);
				if ( _column_16 != value )
				{
					_column_16 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column17
		{
			get
			{
				CanReadProperty("Column17",true);
				return _column_17;
			}
			set
			{
				CanWriteProperty("Column17",true);
				if ( _column_17 != value )
				{
					_column_17 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column18
		{
			get
			{
				CanReadProperty("Column18",true);
				return _column_18;
			}
			set
			{
				CanWriteProperty("Column18",true);
				if ( _column_18 != value )
				{
					_column_18 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column19
		{
			get
			{
				CanReadProperty("Column19",true);
				return _column_19;
			}
			set
			{
				CanWriteProperty("Column19",true);
				if ( _column_19 != value )
				{
					_column_19 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column20
		{
			get
			{
				CanReadProperty("Column20",true);
				return _column_20;
			}
			set
			{
				CanWriteProperty("Column20",true);
				if ( _column_20 != value )
				{
					_column_20 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column21
		{
			get
			{
				CanReadProperty("Column21",true);
				return _column_21;
			}
			set
			{
				CanWriteProperty("Column21",true);
				if ( _column_21 != value )
				{
					_column_21 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column22
		{
			get
			{
				CanReadProperty("Column22",true);
				return _column_22;
			}
			set
			{
				CanWriteProperty("Column22",true);
				if ( _column_22 != value )
				{
					_column_22 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column23
		{
			get
			{
				CanReadProperty("Column23",true);
				return _column_23;
			}
			set
			{
				CanWriteProperty("Column23",true);
				if ( _column_23 != value )
				{
					_column_23 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column24
		{
			get
			{
				CanReadProperty("Column24",true);
				return _column_24;
			}
			set
			{
				CanWriteProperty("Column24",true);
				if ( _column_24 != value )
				{
					_column_24 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column25
		{
			get
			{
				CanReadProperty("Column25",true);
				return _column_25;
			}
			set
			{
				CanWriteProperty("Column25",true);
				if ( _column_25 != value )
				{
					_column_25 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column26
		{
			get
			{
				CanReadProperty("Column26",true);
				return _column_26;
			}
			set
			{
				CanWriteProperty("Column26",true);
				if ( _column_26 != value )
				{
					_column_26 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column27
		{
			get
			{
				CanReadProperty("Column27",true);
				return _column_27;
			}
			set
			{
				CanWriteProperty("Column27",true);
				if ( _column_27 != value )
				{
					_column_27 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Column28 
		{
			get
			{
                CanReadProperty("Column28", true);
                return _column_28;
			}
			set
			{
                CanWriteProperty("Column28", true);
                if (_column_28 != value)
				{
                    _column_28 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SupplierNo29   // was Column29
		{
			get
			{
                CanReadProperty("SupplierNo29", true);
				return _supplier_no_29;
			}
			set
			{
                CanWriteProperty("SupplierNo29", true);
                if (_supplier_no_29 != value)
				{
                    _supplier_no_29 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column30
		{
			get
			{
				CanReadProperty("Column30",true);
				return _column_30;
			}
			set
			{
				CanWriteProperty("Column30",true);
				if ( _column_30 != value )
				{
					_column_30 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column31
		{
			get
			{
				CanReadProperty("Column31",true);
				return _column_31;
			}
			set
			{
				CanWriteProperty("Column31",true);
				if ( _column_31 != value )
				{
					_column_31 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column32
		{
			get
			{
				CanReadProperty("Column32",true);
				return _column_32;
			}
			set
			{
				CanWriteProperty("Column32",true);
				if ( _column_32 != value )
				{
					_column_32 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column33
		{
			get
			{
				CanReadProperty("Column33",true);
				return _column_33;
			}
			set
			{
				CanWriteProperty("Column33",true);
				if ( _column_33 != value )
				{
					_column_33 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column34
		{
			get
			{
				CanReadProperty("Column34",true);
				return _column_34;
			}
			set
			{
				CanWriteProperty("Column34",true);
				if ( _column_34 != value )
				{
					_column_34 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column35
		{
			get
			{
				CanReadProperty("Column35",true);
				return _column_35;
			}
			set
			{
				CanWriteProperty("Column35",true);
				if ( _column_35 != value )
				{
					_column_35 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column36
		{
			get
			{
				CanReadProperty("Column36",true);
				return _column_36;
			}
			set
			{
				CanWriteProperty("Column36",true);
				if ( _column_36 != value )
				{
					_column_36 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column37
		{
			get
			{
				CanReadProperty("Column37",true);
				return _column_37;
			}
			set
			{
				CanWriteProperty("Column37",true);
				if ( _column_37 != value )
				{
					_column_37 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column38
		{
			get
			{
				CanReadProperty("Column38",true);
				return _column_38;
			}
			set
			{
				CanWriteProperty("Column38",true);
				if ( _column_38 != value )
				{
					_column_38 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column39
		{
			get
			{
				CanReadProperty("Column39",true);
				return _column_39;
			}
			set
			{
				CanWriteProperty("Column39",true);
				if ( _column_39 != value )
				{
					_column_39 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column40
		{
			get
			{
				CanReadProperty("Column40",true);
				return _column_40;
			}
			set
			{
				CanWriteProperty("Column40",true);
				if ( _column_40 != value )
				{
					_column_40 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column41
		{
			get
			{
				CanReadProperty("Column41",true);
				return _column_41;
			}
			set
			{
				CanWriteProperty("Column41",true);
				if ( _column_41 != value )
				{
					_column_41 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column42
		{
			get
			{
				CanReadProperty("Column42",true);
				return _column_42;
			}
			set
			{
				CanWriteProperty("Column42",true);
				if ( _column_42 != value )
				{
					_column_42 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column43
		{
			get
			{
				CanReadProperty("Column43",true);
				return _column_43;
			}
			set
			{
				CanWriteProperty("Column43",true);
				if ( _column_43 != value )
				{
					_column_43 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column44
		{
			get
			{
				CanReadProperty("Column44",true);
				return _column_44;
			}
			set
			{
				CanWriteProperty("Column44",true);
				if ( _column_44 != value )
				{
					_column_44 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column45
		{
			get
			{
				CanReadProperty("Column45",true);
				return _column_45;
			}
			set
			{
				CanWriteProperty("Column45",true);
				if ( _column_45 != value )
				{
					_column_45 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column46
		{
			get
			{
				CanReadProperty("Column46",true);
				return _column_46;
			}
			set
			{
				CanWriteProperty("Column46",true);
				if ( _column_46 != value )
				{
					_column_46 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column47
		{
			get
			{
				CanReadProperty("Column47",true);
				return _column_47;
			}
			set
			{
				CanWriteProperty("Column47",true);
				if ( _column_47 != value )
				{
					_column_47 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column48
		{
			get
			{
				CanReadProperty("Column48",true);
				return _column_48;
			}
			set
			{
				CanWriteProperty("Column48",true);
				if ( _column_48 != value )
				{
					_column_48 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column49
		{
			get
			{
				CanReadProperty("Column49",true);
				return _column_49;
			}
			set
			{
				CanWriteProperty("Column49",true);
				if ( _column_49 != value )
				{
					_column_49 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column50
		{
			get
			{
				CanReadProperty("Column50",true);
				return _column_50;
			}
			set
			{
				CanWriteProperty("Column50",true);
				if ( _column_50 != value )
				{
					_column_50 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column51
		{
			get
			{
				CanReadProperty("Column51",true);
				return _column_51;
			}
			set
			{
				CanWriteProperty("Column51",true);
				if ( _column_51 != value )
				{
					_column_51 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column52
		{
			get
			{
				CanReadProperty("Column52",true);
				return _column_52;
			}
			set
			{
				CanWriteProperty("Column52",true);
				if ( _column_52 != value )
				{
					_column_52 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column53
		{
			get
			{
				CanReadProperty("Column53",true);
				return _column_53;
			}
			set
			{
				CanWriteProperty("Column53",true);
				if ( _column_53 != value )
				{
					_column_53 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column54
		{
			get
			{
				CanReadProperty("Column54",true);
				return _column_54;
			}
			set
			{
				CanWriteProperty("Column54",true);
				if ( _column_54 != value )
				{
					_column_54 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column55
		{
			get
			{
				CanReadProperty("Column55",true);
				return _column_55;
			}
			set
			{
				CanWriteProperty("Column55",true);
				if ( _column_55 != value )
				{
					_column_55 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column56
		{
			get
			{
				CanReadProperty("Column56",true);
				return _column_56;
			}
			set
			{
				CanWriteProperty("Column56",true);
				if ( _column_56 != value )
				{
					_column_56 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column57
		{
			get
			{
				CanReadProperty("Column57",true);
				return _column_57;
			}
			set
			{
				CanWriteProperty("Column57",true);
				if ( _column_57 != value )
				{
					_column_57 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Column58
		{
			get
			{
				CanReadProperty("Column58",true);
				return _column_58;
			}
			set
			{
				CanWriteProperty("Column58",true);
				if ( _column_58 != value )
				{
					_column_58 = value;
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
		public static ApInterfaceHeaderRows NewApInterfaceHeaderRows( DateTime? ProcDate )
		{
			return Create(ProcDate);
		}

		public static ApInterfaceHeaderRows[] GetAllApInterfaceHeaderRows( DateTime? ProcDate )
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
                    cm.CommandText = "odps.od_rps_ap_interface_header";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ProcDate", ProcDate);

                    List<ApInterfaceHeaderRows> _list = new List<ApInterfaceHeaderRows>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ApInterfaceHeaderRows instance = new ApInterfaceHeaderRows();
                            instance.TransactionId1 = GetValueFromReader<string>(dr, 0);
                            instance.Vendor2 = GetValueFromReader<string>(dr, 1);
                            instance.VendorLocation3 = GetValueFromReader<string>(dr, 2);
                            instance.InvoiceNo4 = GetValueFromReader<string>(dr, 3);
                            instance.InvoiceDate5 = GetValueFromReader<string>(dr, 4);
                            instance.PaymentNumber6 = GetValueFromReader<Int32?>(dr, 5);
                            instance.Column7 = GetValueFromReader<string>(dr, 6);
                            instance.Column8 = GetValueFromReader<string>(dr, 7);
                            instance.Column9 = GetValueFromReader<string>(dr, 8);
                            instance.Column10 = GetValueFromReader<string>(dr, 9);
                            instance.Column11 = GetValueFromReader<string>(dr, 10);
                            instance.Column12 = GetValueFromReader<string>(dr, 11);
                            instance.Column13 = GetValueFromReader<string>(dr, 12);
                            instance.Column14 = GetValueFromReader<string>(dr, 13);
                            instance.Column15 = GetValueFromReader<string>(dr, 14);
                            instance.Column16 = GetValueFromReader<string>(dr, 15);
                            instance.Column17 = GetValueFromReader<string>(dr, 16);
                            instance.Column18 = GetValueFromReader<string>(dr, 17);
                            instance.Column19 = GetValueFromReader<string>(dr, 18);
                            instance.Column20 = GetValueFromReader<string>(dr, 19);
                            instance.Column21 = GetValueFromReader<string>(dr, 20);
                            instance.Column22 = GetValueFromReader<string>(dr, 21);
                            instance.Column23 = GetValueFromReader<string>(dr, 22);
                            instance.Column24 = GetValueFromReader<string>(dr, 23);
                            instance.Column25 = GetValueFromReader<string>(dr, 24);
                            instance.Column26 = GetValueFromReader<string>(dr, 25);
                            instance.Column27 = GetValueFromReader<string>(dr, 26);
                            instance.Column28 = GetValueFromReader<string>(dr, 27);
                            instance.SupplierNo29 = GetValueFromReader<string>(dr, 28);   // was Column29
                            instance.Column30 = GetValueFromReader<string>(dr, 29);
                            instance.Column31 = GetValueFromReader<string>(dr, 30);
                            instance.Column32 = GetValueFromReader<string>(dr, 31);
                            instance.Column33 = GetValueFromReader<string>(dr, 32);
                            instance.Column34 = GetValueFromReader<string>(dr, 33);
                            instance.Column35 = GetValueFromReader<string>(dr, 34);
                            instance.Column36 = GetValueFromReader<string>(dr, 35);
                            instance.Column37 = GetValueFromReader<string>(dr, 36);
                            instance.Column38 = GetValueFromReader<string>(dr, 37);
                            instance.Column39 = GetValueFromReader<string>(dr, 38);
                            instance.Column40 = GetValueFromReader<string>(dr, 39);
                            instance.Column41 = GetValueFromReader<string>(dr, 40);
                            instance.Column42 = GetValueFromReader<string>(dr, 41);
                            instance.Column43 = GetValueFromReader<string>(dr, 42);
                            instance.Column44 = GetValueFromReader<string>(dr, 43);
                            instance.Column45 = GetValueFromReader<string>(dr, 44);
                            instance.Column46 = GetValueFromReader<string>(dr, 45);
                            instance.Column47 = GetValueFromReader<string>(dr, 46);
                            instance.Column48 = GetValueFromReader<string>(dr, 47);
                            instance.Column49 = GetValueFromReader<string>(dr, 48);
                            instance.Column50 = GetValueFromReader<string>(dr, 49);
                            instance.Column51 = GetValueFromReader<string>(dr, 50);
                            instance.Column52 = GetValueFromReader<string>(dr, 51);
                            instance.Column53 = GetValueFromReader<string>(dr, 52);
                            instance.Column54 = GetValueFromReader<string>(dr, 53);
                            instance.Column55 = GetValueFromReader<string>(dr, 54);
                            instance.Column56 = GetValueFromReader<string>(dr, 55);
                            instance.Column57 = GetValueFromReader<string>(dr, 56);
                            instance.Column58 = GetValueFromReader<string>(dr, 57);
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
