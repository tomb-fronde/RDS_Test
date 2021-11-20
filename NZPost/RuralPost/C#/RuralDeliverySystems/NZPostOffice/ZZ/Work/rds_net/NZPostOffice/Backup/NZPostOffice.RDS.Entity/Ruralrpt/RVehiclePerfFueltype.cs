using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using System.Data.SqlClient;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("fueltype", "_fueltype", "")]
	[MapInfo("novehicles", "_novehicles", "")]
	[System.Serializable()]

	public class VehiclePerfFueltype : Entity<VehiclePerfFueltype>
	{
		#region Business Methods
		[DBField()]
		private string  _fueltype;

		[DBField()]
		private int?  _novehicles;


		public virtual string Fueltype
		{
			get
			{
                CanReadProperty("Fueltype", true);
				return _fueltype;
			}
			set
			{
                CanWriteProperty("Fueltype", true);
				if ( _fueltype != value )
				{
					_fueltype = value;
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
		public static VehiclePerfFueltype NewVehiclePerfFueltype( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
		{
			return Create(inRegion, inOutlet, inrengroup, inContract_Type);
		}

		public static VehiclePerfFueltype[] GetAllVehiclePerfFueltype( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
		{
			return Fetch(inRegion, inOutlet, inrengroup, inContract_Type).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
		{
			//!using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))           
            using ( SqlConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO") as SqlConnection)           
			{
				//!using (DbCommand cm = cn.CreateCommand())
                using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_vehiclesum_fueltypev2";
                    cm.CommandTimeout = 120;
					//!ParameterCollection pList = new ParameterCollection();                    
					//!pList.Add(cm, "inRegion", inRegion);
					//!pList.Add(cm, "inOutlet", inOutlet);
					//!pList.Add(cm, "inrengroup", inrengroup);
					//!pList.Add(cm, "inContract_Type", inContract_Type);
                    cm.Parameters.Add("inRegion", SqlDbType.Int).Value = inRegion;
                    cm.Parameters.Add("inOutlet", SqlDbType.Int).Value = inOutlet;
                    cm.Parameters.Add("inrengroup", SqlDbType.Int).Value = inrengroup;
                    cm.Parameters.Add("inContract_Type", SqlDbType.Int).Value = inContract_Type;

					List<VehiclePerfFueltype> _list = new List<VehiclePerfFueltype>();
					//!using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    using (SqlDataReader dr = cm.ExecuteReader())
					{
						while (dr.Read())
						{
							VehiclePerfFueltype instance = new VehiclePerfFueltype();
                            instance._fueltype = dr.GetString(0);//!GetValueFromReader<string>(dr,0);
                            instance._novehicles = (int?)(dr.GetValue(1));//!GetValueFromReader<int?>(dr,1);
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
