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
	[MapInfo("vehicletype", "_vehicletype", "")]
	[MapInfo("novehicles", "_novehicles", "")]
	[System.Serializable()]

	public class VehiclePerfVehicletype : Entity<VehiclePerfVehicletype>
	{
		#region Business Methods
		[DBField()]
		private string  _vehicletype;

		[DBField()]
		private int?  _novehicles;


		public virtual string Vehicletype
		{
			get
			{
                CanReadProperty("Vehicletype", true);
				return _vehicletype;
			}
			set
			{
                CanWriteProperty("Vehicletype", true);
				if ( _vehicletype != value )
				{
					_vehicletype = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Novehicles
		{
			get
			{
                CanReadProperty("Novehicles", true);
				return _novehicles;
			}
			set
			{
                CanWriteProperty("Novehicles", true);
				if ( _novehicles != value )
				{
					_novehicles = value;
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
		public static VehiclePerfVehicletype NewVehiclePerfVehicletype( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
		{
			return Create(inRegion, inOutlet, inrengroup, inContract_Type);
		}

		public static VehiclePerfVehicletype[] GetAllVehiclePerfVehicletype( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
		{
			return Fetch(inRegion, inOutlet, inrengroup, inContract_Type).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_vehiclesum_vehicletypev2";
                    cm.CommandTimeout = 120;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegion", inRegion);
					pList.Add(cm, "inOutlet", inOutlet);
					pList.Add(cm, "inrengroup", inrengroup);
					pList.Add(cm, "inContract_Type", inContract_Type);

					List<VehiclePerfVehicletype> _list = new List<VehiclePerfVehicletype>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehiclePerfVehicletype instance = new VehiclePerfVehicletype();
                            instance._vehicletype = GetValueFromReader<string>(dr,0);
                            instance._novehicles = GetValueFromReader<int?>(dr,1);
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
