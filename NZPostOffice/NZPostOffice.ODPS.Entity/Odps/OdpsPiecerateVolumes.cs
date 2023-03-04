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
	[MapInfo("prv_key", "_prv_key", "")]
	[MapInfo("prv_effective_end_date", "_prv_effective_end_date", "")]
	[MapInfo("prv_quantity", "_prv_quantity", "")]
	[MapInfo("prv_paid", "_prv_paid", "")]
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
	[MapInfo("prst_id", "_prst_id", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[System.Serializable()]

	public class OdpsPiecerateVolumes : Entity<OdpsPiecerateVolumes>
	{
		#region Business Methods
		[DBField()]
		private int?  _prv_key;

		[DBField()]
		private DateTime?  _prv_effective_end_date;

		[DBField()]
		private decimal?  _prv_quantity;

		[DBField()]
		private string  _prv_paid;

		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private int?  _prst_id;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;


		public virtual int? PrvKey
		{
			get
			{
				CanReadProperty("PrvKey",true);
				return _prv_key;
			}
			set
			{
                CanWriteProperty("PrvKey", true);
				if ( _prv_key != value )
				{
					_prv_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? PrvEffectiveEndDate
		{
			get
			{
				CanReadProperty("PrvEffectiveEndDate",true);
				return _prv_effective_end_date;
			}
			set
			{
				CanWriteProperty("PrvEffectiveEndDate",true);
				if ( _prv_effective_end_date != value )
				{
					_prv_effective_end_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? PrvQuantity
		{
			get
			{
				CanReadProperty("PrvQuantity",true);
				return _prv_quantity;
			}
			set
			{
                CanWriteProperty("PrvQuantity", true);
				if ( _prv_quantity != value )
				{
					_prv_quantity = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrvPaid
		{
			get
			{
				CanReadProperty(true);
				return _prv_paid;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prv_paid != value )
				{
					_prv_paid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractorSupplierNo
		{
			get
			{
				CanReadProperty(true);
				return _contractor_supplier_no;
			}
			set
			{
				CanWriteProperty(true);
				if ( _contractor_supplier_no != value )
				{
					_contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PrstId
		{
			get
			{
				CanReadProperty(true);
				return _prst_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prst_id != value )
				{
					_prst_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractNo
		{
			get
			{
				CanReadProperty(true);
				return _contract_no;
			}
			set
			{
				CanWriteProperty(true);
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
				CanReadProperty(true);
				return _contract_seq_number;
			}
			set
			{
				CanWriteProperty(true);
				if ( _contract_seq_number != value )
				{
					_contract_seq_number = value;
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
		public static OdpsPiecerateVolumes NewOdpsPiecerateVolumes( int? in_Contract, int? in_Sequence, int? in_Contractor )
		{
			return Create(in_Contract, in_Sequence, in_Contractor);
		}

		public static OdpsPiecerateVolumes[] GetAllOdpsPiecerateVolumes( int? in_Contract, int? in_Sequence, int? in_Contractor )
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
                    cm.CommandText = "sp_odps_getpieceratevolumes";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Contract", in_Contract);
					pList.Add(cm, "in_Sequence", in_Sequence);
					pList.Add(cm, "in_Contractor", in_Contractor);

					List<OdpsPiecerateVolumes> _list = new List<OdpsPiecerateVolumes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OdpsPiecerateVolumes instance = new OdpsPiecerateVolumes();
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
