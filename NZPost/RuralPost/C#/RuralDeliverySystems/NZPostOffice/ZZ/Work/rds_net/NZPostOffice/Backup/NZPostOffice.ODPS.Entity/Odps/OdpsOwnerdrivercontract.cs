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
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("odc_standard_tax_rate", "_odc_standard_tax_rate", "")]
	[MapInfo("odc_tax_percentage", "_odc_tax_percentage", "")]
	[System.Serializable()]

	public class OdpsOwnerdrivercontract : Entity<OdpsOwnerdrivercontract>
	{
		#region Business Methods
		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private string  _odc_standard_tax_rate;

		[DBField()]
		private decimal?  _odc_tax_percentage;


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

		public virtual string OdcStandardTaxRate
		{
			get
			{
				CanReadProperty("OdcStandardTaxRate",true);
				return _odc_standard_tax_rate;
			}
			set
			{
				CanWriteProperty("OdcStandardTaxRate",true);
				if ( _odc_standard_tax_rate != value )
				{
					_odc_standard_tax_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? OdcTaxPercentage
		{
			get
			{
                CanReadProperty("OdcTaxPercentage", true);
				return _odc_tax_percentage;
			}
			set
			{
				CanWriteProperty("OdcTaxPercentage",true);
				if ( _odc_tax_percentage != value )
				{
					_odc_tax_percentage = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _contractor_supplier_no,_contract_no,_contract_seq_number );
		}
		#endregion

		#region Factory Methods
		public static OdpsOwnerdrivercontract NewOdpsOwnerdrivercontract( int? in_ContractNo, int? in_ContractSeq, int? in_ContractorNo )
		{
			return Create(in_ContractNo, in_ContractSeq, in_ContractorNo);
		}

		public static OdpsOwnerdrivercontract[] GetAllOdpsOwnerdrivercontract( int? in_ContractNo, int? in_ContractSeq, int? in_ContractorNo )
		{
			return Fetch(in_ContractNo, in_ContractSeq, in_ContractorNo).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_ContractNo, int? in_ContractSeq, int? in_ContractorNo )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_odps_getownerdrivercontract";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_ContractNo", in_ContractNo);
					pList.Add(cm, "in_ContractSeq", in_ContractSeq);
					pList.Add(cm, "in_ContractorNo", in_ContractorNo);

					List<OdpsOwnerdrivercontract> _list = new List<OdpsOwnerdrivercontract>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OdpsOwnerdrivercontract instance = new OdpsOwnerdrivercontract();
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
		private void CreateEntity( int? contractor_supplier_no, int? contract_no, int? contract_seq_number )
		{
			_contractor_supplier_no = contractor_supplier_no;
			_contract_no = contract_no;
			_contract_seq_number = contract_seq_number;
		}
	}
}
