using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB Frequencies Nov-2020 NEW
    // Data for Frequencies tab's vehicle dropdown list

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("vehicle_number", "_vehicle_number", "")]
    [MapInfo("vehicle_name", "_vehicle_name", "")]
	[System.Serializable()]

    public class ContractorVehicles : Entity<ContractorVehicles>
	{
		#region Business Methods
		[DBField()]
        private int _vehicle_number;

		[DBField()]
        private string _vehicle_name;


        public virtual int VehicleNumber
		{
			get
			{
                CanReadProperty("VehicleNumber", true);
                return _vehicle_number;
			}
			set
			{
                CanWriteProperty("VehicleNumber", true);
                if (_vehicle_number != value)
				{
                    _vehicle_number = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string VehicleName
		{
			get
			{
                CanReadProperty("VehicleName", true);
                return _vehicle_name;
			}
			set
			{
                CanWriteProperty("VehicleName", true);
                if (_vehicle_name != value)
				{
                    _vehicle_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
            return _vehicle_number ;
		}
		#endregion

		#region Factory Methods
        public static ContractorVehicles NewContractorVehicles()
		{
			return Create();
		}

		public static ContractorVehicles[] GetAllContractorVehicles( int? in_Contract )
		{
			return Fetch(in_Contract).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Contract )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_DDDW_contractor_vehicles";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "@InContractNo", in_Contract);

					List<ContractorVehicles> _list = new List<ContractorVehicles>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractorVehicles instance = new ContractorVehicles();
                            instance._vehicle_number = GetValueFromReader<int>(dr,0);
                            instance._vehicle_name = GetValueFromReader<String>(dr,1);
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
