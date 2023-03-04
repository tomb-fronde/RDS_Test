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
	[MapInfo("region", "_region", "region")]
	[MapInfo("procurement", "_procurement", "procurement")]
	[MapInfo("contractors", "_contractors", "contractor_procurement")]
	[MapInfo("procid", "_procid", "procurement")]
	[MapInfo("region_id", "_region_id", "region")]
	[System.Serializable()]

	public class ContractorProcurementSummary : Entity<ContractorProcurementSummary>
	{
		#region Business Methods
		[DBField()]
		private string  _region;

		[DBField()]
		private string  _procurement;

		[DBField()]
		private int?  _contractors;

		[DBField()]
		private int?  _procid;

		[DBField()]
		private int?  _region_id;


		public virtual string Region
		{
			get
			{
                CanReadProperty("Region", true);
				return _region;
			}
			set
			{
                CanWriteProperty("Region", true);
				if ( _region != value )
				{
					_region = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Procurement
		{
			get
			{
                CanReadProperty("Procurement", true);
				return _procurement;
			}
			set
			{
                CanWriteProperty("Procurement", true);
				if ( _procurement != value )
				{
					_procurement = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Contractors
		{
			get
			{
                CanReadProperty("Contractors", true);
				return _contractors;
			}
			set
			{
                CanWriteProperty("Contractors", true);
				if ( _contractors != value )
				{
					_contractors = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Procid
		{
			get
			{
                CanReadProperty("Procid", true);
				return _procid;
			}
			set
			{
                CanWriteProperty("Procid", true);
				if ( _procid != value )
				{
					_procid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionId
		{
			get
			{
                CanReadProperty("RegionId", true);
				return _region_id;
			}
			set
			{
                CanWriteProperty("RegionId", true);
				if ( _region_id != value )
				{
					_region_id = value;
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
		public static ContractorProcurementSummary NewContractorProcurementSummary(  )
		{
			return Create();
		}

		public static ContractorProcurementSummary[] GetAllContractorProcurementSummary(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    //?cm.CommandText = "SELECT region.rgn_name           as region,  procurement.proc_name     as procurement,  count(contractor_procurement.contractor_supplier_no) as contractors,  procurement.proc_id       as procID,  region.region_id          as region_id  FROM contractor_procurement,  procurement,  contractor_renewals,  contract_renewals,  contract,  outlet,  region  WHERE procurement.proc_id = contractor_procurement.proc_id and  contractor_procurement.contractor_supplier_no = contractor_renewals.contractor_supplier_no and  contract_renewals.contract_no = contractor_renewals.contract_no and  contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and  contract.contract_no = contract_renewals.contract_no and  outlet.outlet_id = contract.con_base_office and  region.region_id = outlet.region_id and  contractor_renewals.cr_effective_date <;= today() and  contract_renewals.con_start_date <;= today() and  contract_renewals.con_expiry_date >;= today()  GROUP BY region_id, region, procID, procurement  UNION  SELECT 'ZZZZZ'                    as region,  procurement.proc_name     as procurement,  count(contractor_procurement.contractor_supplier_no) as contractors,  procurement.proc_id       as procID,  99999                     as region_id  FROM contractor_procurement,  procurement,  contractor_renewals,  contract_renewals,  contract,  outlet,  region  WHERE procurement.proc_id = contractor_procurement.proc_id and  contractor_procurement.contractor_supplier_no = contractor_renewals.contractor_supplier_no and  contract_renewals.contract_no = contractor_renewals.contract_no and  contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and  contract.contract_no = contract_renewals.contract_no and  outlet.outlet_id = contract.con_base_office and  region.region_id = outlet.region_id and  contractor_renewals.cr_effective_date <= getdate() and  contract_renewals.con_start_date <= getdate() and  contract_renewals.con_expiry_date >= getdate()  GROUP BY region_id, region, procID, procurement   ORDER BY region ASC,   procID ASC  ";
                    cm.CommandText = "SELECT region.rgn_name           as region,  procurement.proc_name     as procurement,  count(contractor_procurement.contractor_supplier_no) as contractors,  procurement.proc_id       as procID,  region.region_id          as region_id  FROM contractor_procurement,  procurement,  contractor_renewals,  contract_renewals,  contract,  outlet,  region  WHERE procurement.proc_id = contractor_procurement.proc_id and  contractor_procurement.contractor_supplier_no = contractor_renewals.contractor_supplier_no and  contract_renewals.contract_no = contractor_renewals.contract_no and  contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and  contract.contract_no = contract_renewals.contract_no and  outlet.outlet_id = contract.con_base_office and  region.region_id = outlet.region_id and  contractor_renewals.cr_effective_date <= getdate() and  contract_renewals.con_start_date <= getdate() and  contract_renewals.con_expiry_date >= getdate()  GROUP BY region.region_id, region.rgn_name, procurement.proc_id, procurement.proc_name  UNION  SELECT 'ZZZZZ'                    as region,  procurement.proc_name     as procurement,  count(contractor_procurement.contractor_supplier_no) as contractors,  procurement.proc_id       as procID,  99999                     as region_id  FROM contractor_procurement,  procurement,  contractor_renewals,  contract_renewals,  contract,  outlet,  region  WHERE procurement.proc_id = contractor_procurement.proc_id and  contractor_procurement.contractor_supplier_no = contractor_renewals.contractor_supplier_no and  contract_renewals.contract_no = contractor_renewals.contract_no and  contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and  contract.contract_no = contract_renewals.contract_no and  outlet.outlet_id = contract.con_base_office and  region.region_id = outlet.region_id and  contractor_renewals.cr_effective_date <= getdate() and  contract_renewals.con_start_date <= getdate() and  contract_renewals.con_expiry_date >= getdate()  GROUP BY procurement.proc_id, procurement.proc_name   ORDER BY region ASC,   procID ASC  ";
					ParameterCollection pList = new ParameterCollection();

					List<ContractorProcurementSummary> _list = new List<ContractorProcurementSummary>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractorProcurementSummary instance = new ContractorProcurementSummary();
                            instance._region = GetValueFromReader<string>(dr,0);
                            instance._procurement = GetValueFromReader<string>(dr,1);
                            instance._contractors = GetValueFromReader<int?>(dr,2);
                            instance._procid = GetValueFromReader<int?>(dr,3);
                            instance._region_id = GetValueFromReader<int?>(dr,4);
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
