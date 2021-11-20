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
	[MapInfo("nupto2litres", "_upto2litres", "")]
	[MapInfo("nat2litres", "_at2litres", "")]
	[MapInfo("nat2litres23litres", "_at2litres23litres", "")]
	[MapInfo("nover3litres", "_over3litres", "")]
	[MapInfo("nunknown", "_unknown", "")]
	[System.Serializable()]

	public class VehiclePerfCapacity : Entity<VehiclePerfCapacity>
	{
		#region Business Methods
		[DBField()]
		private int?  _upto2litres;

		[DBField()]
		private int?  _at2litres;

		[DBField()]
		private int?  _at2litres23litres;

		[DBField()]
		private int?  _over3litres;

		[DBField()]
		private int?  _unknown;


		public virtual int? Upto2litres
		{
			get
			{
                CanReadProperty("Upto2litres", true);
				return _upto2litres;
			}
			set
			{
                CanWriteProperty("Upto2litres", true);
				if ( _upto2litres != value )
				{
					_upto2litres = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? At2litres
		{
			get
			{
                CanReadProperty("At2litres", true);
				return _at2litres;
			}
			set
			{
                CanWriteProperty("At2litres", true);
				if ( _at2litres != value )
				{
					_at2litres = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? At2litres23litres
		{
			get
			{
                CanReadProperty("At2litres23litres", true);
				return _at2litres23litres;
			}
			set
			{
                CanWriteProperty("At2litres23litres", true);
				if ( _at2litres23litres != value )
				{
					_at2litres23litres = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Over3litres
		{
			get
			{
                CanReadProperty("Over3litres", true);
				return _over3litres;
			}
			set
			{
                CanWriteProperty("Over3litres", true);
				if ( _over3litres != value )
				{
					_over3litres = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Unknown
		{
			get
			{
                CanReadProperty("Unknown", true);
				return _unknown;
			}
			set
			{
                CanWriteProperty("Unknown", true);
				if ( _unknown != value )
				{
					_unknown = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[totalvehicles]
		//?	if(isnull(upto2litres),0,upto2litres) + if(isnull(at2litres),0,at2litres) + if(isnull(over3litres),0,over3litres) + if(isnull(unknown),0,unknown) + if(isnull( at2litres23litres ),0, at2litres23litres )


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static VehiclePerfCapacity NewVehiclePerfCapacity( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
		{
			return Create(inRegion, inOutlet, inrengroup, inContract_Type);
		}

		public static VehiclePerfCapacity[] GetAllVehiclePerfCapacity( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
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
                    cm.CommandText = "rd.sp_vehiclesum_capacityv2";
                    cm.CommandTimeout = 120;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegion", inRegion);
					pList.Add(cm, "inOutlet", inOutlet);
					pList.Add(cm, "inrengroup", inrengroup);
					pList.Add(cm, "inContract_Type", inContract_Type);

					List<VehiclePerfCapacity> _list = new List<VehiclePerfCapacity>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehiclePerfCapacity instance = new VehiclePerfCapacity();
                            instance._upto2litres = GetValueFromReader<int?>(dr,0);
                            instance._at2litres = GetValueFromReader<int?>(dr,1);
                            instance._at2litres23litres = GetValueFromReader<int?>(dr,2);
                            
                            //comment by hhuang,because the db has only 4 fields.
                            instance._over3litres = GetValueFromReader<int?>(dr, 3); // GetValueFromReader<int?>(dr, 2);
                            //!instance._unknown = GetValueFromReader<int?>(dr,3);
                            instance._unknown = 0;

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
