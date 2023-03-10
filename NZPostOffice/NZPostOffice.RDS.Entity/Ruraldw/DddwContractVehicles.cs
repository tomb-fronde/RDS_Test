using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB Frequencies & Vehicles 16-Feb-2021
    // Dropped default_vehicle
    //
    // TJB Frequencies & Vehicles Dec-2020 NEW
    // Data for Frequencies tab's vehicle dropdown list
    // (originally used DddwContractorVehicles)

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("vehicle_number", "_vehicle_number", "contract_vehical")]
    [MapInfo("vehicle_name", "_vehicle_name", "contract_vehical")]
    [MapInfo("cv_vehicle_status", "_vehicle_status", "contract_vehical")]
    [System.Serializable()]

    public class DddwContractVehicles : Entity<DddwContractVehicles>
	{
		#region Business Methods
		[DBField()]
        private int _vehicle_number;

		[DBField()]
        private string _vehicle_name;

        [DBField()]
        private string _vehicle_status;


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

        public virtual string VehicleStatus
        {
            get
            {
                CanReadProperty("VehicleStatus", true);
                return _vehicle_status;
            }
            set
            {
                CanWriteProperty("VehicleStatus", true);
                if (_vehicle_status != value)
                {
                    _vehicle_status = value;
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
        public static DddwContractVehicles NewContractVehicles()
		{
			return Create();
		}

		public static DddwContractVehicles[] GetAllDddwContractVehicles( int? in_Contract )
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
                    cm.CommandText = "sp_DDDW_contract_vehicles";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "@inContractNo", in_Contract);

					List<DddwContractVehicles> _list = new List<DddwContractVehicles>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwContractVehicles instance = new DddwContractVehicles();
                            instance._vehicle_number = GetValueFromReader<int>(dr,0);
                            instance._vehicle_name = GetValueFromReader<String>(dr, 1);
                            instance._vehicle_status = GetValueFromReader<String>(dr, 2);
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
