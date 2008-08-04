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
	[MapInfo("contract", "_contract", "contractor_procurement")]
	[MapInfo("contractor", "_contractor", "contractor_renewals")]
	[MapInfo("contractor_name", "_contractor_name", "contractor_procurement")]
	[MapInfo("region_id", "_region_region_id", "region")]
	[MapInfo("procid", "_procurement_procid", "procurement")]
	[System.Serializable()]

	public class ContractorProcurementDetail : Entity<ContractorProcurementDetail>
	{
		#region Business Methods
		[DBField()]
		private string  _region;

		[DBField()]
		private string  _procurement;

		[DBField()]
		private string  _contract;

		[DBField()]
		private int?  _contractor;

		[DBField()]
		private string  _contractor_name;

		[DBField()]
		private int?  _region_region_id;

		[DBField()]
		private int?  _procurement_procid;


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

		public virtual string Contract
		{
			get
			{
                CanReadProperty("Contract", true);
				return _contract;
			}
			set
			{
                CanWriteProperty("Contract", true);
				if ( _contract != value )
				{
					_contract = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Contractor
		{
			get
			{
                CanReadProperty("Contractor", true);
				return _contractor;
			}
			set
			{
                CanWriteProperty("Contractor", true);
				if ( _contractor != value )
				{
					_contractor = value;
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

		public virtual int? RegionRegionId
		{
			get
			{
                CanReadProperty("RegionRegionId", true);
				return _region_region_id;
			}
			set
			{
                CanWriteProperty("RegionRegionId", true);
				if ( _region_region_id != value )
				{
					_region_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ProcurementProcid
		{
			get
			{
                CanReadProperty("ProcurementProcid", true);
				return _procurement_procid;
			}
			set
			{
                CanWriteProperty("ProcurementProcid", true);
				if ( _procurement_procid != value )
				{
					_procurement_procid = value;
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
		public static ContractorProcurementDetail NewContractorProcurementDetail(  )
		{
			return Create();
		}

		public static ContractorProcurementDetail[] GetAllContractorProcurementDetail(  )
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
                    cm.CommandText = "SELECT region.rgn_name                   as region  , procurement.proc_name             as procurement  , rtrim(ltrim(str(contractor_renewals.contract_no)))  +'/'+rtrim(ltrim(str(contractor_renewals.contract_seq_number)))   as contract  , contractor_renewals.contractor_supplier_no as contractor  , isnull(contractor.c_title+' ','')  + isnull(contractor.c_first_names+' ','')  + contractor.c_surname_company as contractor_name  , region.region_id                  as region_id  , procurement.proc_id               as procID  FROM contractor_procurement,  procurement,  contractor_renewals,  contractor,  contract_renewals,  contract,  outlet,  region  WHERE procurement.proc_id = contractor_procurement.proc_id and  contractor_procurement.contractor_supplier_no = contractor_renewals.contractor_supplier_no and  contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no and  contract_renewals.contract_no = contractor_renewals.contract_no and  contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and  contract.contract_no = contract_renewals.contract_no and  outlet.outlet_id = contract.con_base_office and  region.region_id = outlet.region_id and  contractor_renewals.cr_effective_date <= getdate() and  contract_renewals.con_start_date <= getdate() and  contract_renewals.con_expiry_date >= getdate()  ORDER BY region_id ASC, procID ASC, contract ASC  ";
					ParameterCollection pList = new ParameterCollection();

					List<ContractorProcurementDetail> _list = new List<ContractorProcurementDetail>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractorProcurementDetail instance = new ContractorProcurementDetail();
                            instance._region = GetValueFromReader<string>(dr,0);
                            instance._procurement = GetValueFromReader<string>(dr,1);
                            instance._contract = GetValueFromReader<string>(dr,2);
                            instance._contractor = GetValueFromReader<int?>(dr,3);
                            instance._contractor_name = GetValueFromReader<string>(dr,4);
                            instance._region_region_id = GetValueFromReader<int?>(dr,5);
                            instance._procurement_procid = GetValueFromReader<int?>(dr,6);
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
