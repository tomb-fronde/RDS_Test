using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB  ECL Data Import  June-2010: New
    //
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	// [MapInfo("ecl_driver_id", "_ecl_driver_id", "ecl_contract_mapping", true)]
	[MapInfo("ecl_driver_id", "_ecl_driver_id", "ecl_contract_mapping")]
	[MapInfo("contract_no", "_contract_no", "ecl_contract_mapping")]
	[System.Serializable()]

	public class EclContractMapping : Entity<EclContractMapping>
	{
		#region Business Methods
		[DBField()]
		private int?  _ecl_driver_id;

		[DBField()]
		private int?  _contract_no;

		public virtual int? EclDriverId
		{
			get
			{
				CanReadProperty(true);
				return _ecl_driver_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ecl_driver_id != value )
				{
					_ecl_driver_id = value;
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


		private EclContractMapping[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ecl_driver_id );
		}
		#endregion

		#region Factory Methods
		public static EclContractMapping NewEclContractMapping(int? ecl_driver_id)
		{
			return Create(ecl_driver_id);
		}

		public static EclContractMapping[] GetAllEclContractMapping(  )
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					GenerateSelectCommandText(cm, "ecl_contract_mapping");

					List<EclContractMapping> list = new List<EclContractMapping>();

					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							EclContractMapping instance = new EclContractMapping();
							instance.StoreFieldValues(dr, "ecl_contract_mapping");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new EclContractMapping[list.Count];
						list.CopyTo(dataList);
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
				if (GenerateUpdateCommandText(cm, "ecl_contract_mapping", ref pList))
				{
					cm.CommandText += " WHERE  ecl_contract_mapping.ecl_driver_id = @ecl_driver_id ";

					pList.Add(cm, "ecl_driver_id", GetInitialValue("_ecl_driver_id"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
				ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "ecl_contract_mapping", pList))
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
					cm.CommandText = "DELETE FROM ecl_contract_mapping " 
					                + "WHERE ecl_contract_mapping.ecl_driver_id = @ecl_driver_id ";
					                
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"ecl_driver_id", GetInitialValue("_ecl_driver_id"));
					
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ecl_driver_id )
		{
			_ecl_driver_id = ecl_driver_id;
		}
	}
}
