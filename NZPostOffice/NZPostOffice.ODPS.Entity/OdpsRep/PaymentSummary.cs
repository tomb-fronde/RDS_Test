using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("region", "_region", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("name", "_name", "")]
	[MapInfo("m_standard", "_m_standard", "")]
	[MapInfo("m_allowance", "_m_allowance", "")]
	[MapInfo("m_extension", "_m_extension", "")]
	[MapInfo("m_contract_adjustment", "_m_contract_adjustment", "")]
	[MapInfo("m_adpost", "_m_adpost", "")]
	[MapInfo("m_courierpost", "_m_courierpost", "")]
	[MapInfo("m_gst_value", "_m_gst_value", "")]
	[MapInfo("m_wtax_value", "_m_wtax_value", "")]
	[MapInfo("m_adj_notax", "_m_adj_notax", "")]
	[MapInfo("contract_type", "_contract_type", "")]
	[MapInfo("m_parcelpost", "_m_parcelpost", "")]
	[MapInfo("m_skyroad", "_m_skyroad", "")]
	[System.Serializable()]

	public class PaymentSummary : Entity<PaymentSummary>
	{
		#region Business Methods
		[DBField()]
		private string  _region;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _name;

		[DBField()]
		private decimal?  _m_standard;

		[DBField()]
		private decimal?  _m_allowance;

		[DBField()]
		private decimal?  _m_extension;

		[DBField()]
		private decimal?  _m_contract_adjustment;

		[DBField()]
		private decimal?  _m_adpost;

		[DBField()]
		private decimal?  _m_courierpost;

		[DBField()]
		private decimal?  _m_gst_value;

		[DBField()]
		private decimal?  _m_wtax_value;

		[DBField()]
		private decimal?  _m_adj_notax;

		[DBField()]
		private string  _contract_type;

		[DBField()]
		private decimal?  _m_parcelpost;

		[DBField()]
		private decimal?  _m_skyroad;

		public virtual string Region
		{
			get
			{
				CanReadProperty("Region",true);
				return _region;
			}
			set
			{
				CanWriteProperty("Region",true);
				if ( _region != value )
				{
					_region = value;
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

        public int REContractNo
        {
            get
            {
                return (int)_contract_no;
            }
         }

		public virtual string Name
		{
			get
			{
				CanReadProperty("Name",true);
				return _name;
			}
			set
			{
				CanWriteProperty("Name",true);
				if ( _name != value )
				{
					_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? MStandard
		{
			get
			{
				CanReadProperty("MStandard",true);
				return _m_standard;
			}
			set
			{
				CanWriteProperty("MStandard",true);
				if ( _m_standard != value )
				{
					_m_standard = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMStandard
        {
            get
            {
                return (decimal)_m_standard;
            }
        }
		
        public virtual decimal? MAllowance
		{
			get
			{
				CanReadProperty("MAllowance",true);
				return _m_allowance;
			}
			set
			{
				CanWriteProperty("MAllowance",true);
				if ( _m_allowance != value )
				{
					_m_allowance = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMAllowance
        {
            get
            {
                return (decimal)_m_allowance;
            }
        }

		public virtual decimal? MExtension
		{
			get
			{
				CanReadProperty("MExtension",true);
				return _m_extension;
			}
			set
			{
				CanWriteProperty("MExtension",true);
				if ( _m_extension != value )
				{
					_m_extension = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMExtension
        {
            get
            {
                return (decimal)_m_extension;
            }
        }

		public virtual decimal? MContractAdjustment
		{
			get
			{
				CanReadProperty("MContractAdjustment",true);
				return _m_contract_adjustment;
			}
			set
			{
				CanWriteProperty("MContractAdjustment",true);
				if ( _m_contract_adjustment != value )
				{
					_m_contract_adjustment = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMContractAdjustment
        {
            get
            {
                return (decimal)_m_contract_adjustment;
            }
           }

        public virtual decimal? MAdpost
		{
			get
			{
				CanReadProperty("MAdpost",true);
				return _m_adpost;
			}
			set
			{
				CanWriteProperty("MAdpost",true);
				if ( _m_adpost != value )
				{
					_m_adpost = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMAdpost
        {
            get
            {
                return (decimal)_m_adpost;
            }
   }

		public virtual decimal? MCourierpost
		{
			get
			{
				CanReadProperty("MCourierpost",true);
				return _m_courierpost;
			}
			set
			{
				CanWriteProperty("MCourierpost",true);
				if ( _m_courierpost != value )
				{
					_m_courierpost = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMCourierpost
        {
            get
            {
                return (decimal)_m_courierpost;
            }
        }

        public virtual decimal? MGstValue
		{
			get
			{
				CanReadProperty("MGstValue",true);
				return _m_gst_value;
			}
			set
			{
				CanWriteProperty("MGstValue",true);
				if ( _m_gst_value != value )
				{
					_m_gst_value = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMGstValue
        {
            get
            {
                return (decimal)_m_gst_value;
            }
          }
	
        public virtual decimal? MWtaxValue
		{
			get
			{
				CanReadProperty("MWtaxValue",true);
				return _m_wtax_value;
			}
			set
			{
				CanWriteProperty("MWtaxValue",true);
				if ( _m_wtax_value != value )
				{
					_m_wtax_value = value;
					PropertyHasChanged();
				}
			}
		}

        public  decimal REMWtaxValue
        {
            get
            {
                return (decimal)_m_wtax_value;
            }
        }

        public virtual decimal? MAdjNotax
		{
			get
			{
				CanReadProperty("MAdjNotax",true);
				return _m_adj_notax;
			}
			set
			{
				CanWriteProperty("MAdjNotax",true);
				if ( _m_adj_notax != value )
				{
					_m_adj_notax = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMAdjNotax
        {
            get
            {
                return (decimal)_m_adj_notax;
            }
        }

        public virtual string ContractType
		{
			get
			{
				CanReadProperty("ContractType",true);
				return _contract_type;
			}
			set
			{
				CanWriteProperty("ContractType",true);
				if ( _contract_type != value )
				{
					_contract_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? MParcelpost
		{
			get
			{
				CanReadProperty("MParcelpost",true);
				return _m_parcelpost;
			}
			set
			{
				CanWriteProperty("MParcelpost",true);
				if ( _m_parcelpost != value )
				{
					_m_parcelpost = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMParcelpost
        {
            get
            {
                return (decimal)_m_parcelpost;
            }
         }

		public virtual decimal? MSkyroad
		{
			get
			{
				CanReadProperty("MSkyroad",true);
				return _m_skyroad;
			}
			set
			{
				CanWriteProperty("MSkyroad",true);
				if ( _m_skyroad != value )
				{
					_m_skyroad = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REMSkyroad

        {
            get
            {
                return (decimal)_m_skyroad;
            }
        }

        // needs to implement compute expression manually:
			// compute control name=[total_adj]
			//m_adpost + m_courierpost + m_skyroad + m_parcelpost + m_extension + m_contract_adjustment

			// needs to implement compute expression manually:
			// compute control name=[taxable_gross]
			//m_standard + m_allowance + total_adj

			// needs to implement compute expression manually:
			// compute control name=[compute_3]
			//taxable_gross + m_gst_value - m_wtax_value - m_adj_notax

			// needs to implement compute expression manually:
			// compute control name=[m_piecerates]
			//m_adpost + m_courierpost + m_skyroad + m_parcelpost

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static PaymentSummary NewPaymentSummary( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Create(sdate, edate, inregion);
		}

		public static PaymentSummary[] GetAllPaymentSummary( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Fetch(sdate, edate, inregion).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( DateTime? sdate, DateTime? edate, int? inregion )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 100;
                    cm.CommandText = "odps.od_rps_pay_summary";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "inregion", inregion);

					List<PaymentSummary> _list = new List<PaymentSummary>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PaymentSummary instance = new PaymentSummary();
                            instance._region = GetValueFromReader<string>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._name = GetValueFromReader<string>(dr, 2);
                            instance._m_standard = GetValueFromReader<decimal?>(dr, 3);
                            instance._m_allowance = GetValueFromReader<decimal?>(dr, 4);
                            instance._m_extension = GetValueFromReader<decimal?>(dr, 5);
                            instance._m_contract_adjustment = GetValueFromReader<decimal?>(dr, 6);
                            instance._m_adpost = GetValueFromReader<decimal?>(dr, 7);
                            instance._m_courierpost = GetValueFromReader<decimal?>(dr, 8);
                            instance._m_gst_value = GetValueFromReader<decimal?>(dr, 9);
                            instance._m_wtax_value = GetValueFromReader<decimal?>(dr, 10);
                            instance._m_adj_notax = GetValueFromReader<decimal?>(dr, 11);
                            instance._contract_type = GetValueFromReader<string>(dr, 12);
                            instance._m_parcelpost = GetValueFromReader<decimal?>(dr, 13);
                            instance._m_skyroad = GetValueFromReader<decimal?>(dr, 14);
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
