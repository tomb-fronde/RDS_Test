using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB Frequencies and Vehicles Jan-2021
    // Return a list of a contract's active vehicles

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("vehicle_number", "_vehicle_number", "contract_vehical")]
    [MapInfo("vehicle_name", "_vehicle_name", "contract_vehical")]
    [MapInfo("cv_vehicle_status", "_vehicle_status", "contract_vehical")]
    [MapInfo("default_vehicle", "_default_vehicle", "contract_vehical")]
    [System.Serializable()]

    public class SelectContractVehicle : Entity<SelectContractVehicle>
	{
		#region Business Methods
		[DBField()]
        private int _vehicle_number;

		[DBField()]
        private string _vehicle_name;

        [DBField()]
        private string _vehicle_status;

        [DBField()]
        private int _default_vehicle;


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

        public virtual int DefaultVehicle
        {
            get
            {
                CanReadProperty("DefaultVehicle", true);
                return _default_vehicle;
            }
            set
            {
                CanWriteProperty("DefaultVehicle", true);
                if (_default_vehicle != value)
                {
                    _default_vehicle = value;
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
        public static SelectContractVehicle NewContractVehicles()
		{
			return Create();
		}

		public static SelectContractVehicle[] GetAllSelectContractVehicle( int? in_Contract, int? in_Sequence )
		{
            return Fetch(in_Contract, in_Sequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? in_Contract, int? in_Sequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = "  select cv.vehicle_number "
                                   + "       , rd.f_VehicleName( cv.vehicle_number) "
                                   + "       , cv.cv_vehical_status"
                                   + "       , cv.default_vehicle"
                                   + "    from contract_vehical cv "
                                   + "   where cv.contract_no = @inContractNo "
                                   + "     and cv.contract_seq_number = @InConSeqNo "
                                   + "     and cv.cv_vehical_status = 'A' "
                                   + "   order by cv.default_vehicle desc, 2";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "@InContractNo", in_Contract);
                    pList.Add(cm, "@InConSeqNo",   in_Sequence);

					List<SelectContractVehicle> _list = new List<SelectContractVehicle>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							SelectContractVehicle instance = new SelectContractVehicle();
                            instance._vehicle_number = GetValueFromReader<int>(dr,0);
                            instance._vehicle_name = GetValueFromReader<String>(dr, 1);
                            instance._vehicle_status = GetValueFromReader<String>(dr, 2);
                            instance._default_vehicle = GetValueFromReader<int>(dr, 3);
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
