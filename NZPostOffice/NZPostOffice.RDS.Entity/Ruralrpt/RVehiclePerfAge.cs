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
	[MapInfo("ageupto5years", "_ageupto5years", "")]
	[MapInfo("age5to10years", "_age5to10years", "")]
	[MapInfo("ageover10years", "_ageover10years", "")]
	[MapInfo("ageunknown", "_ageunknown", "")]
	[System.Serializable()]

	public class VehiclePerfAge : Entity<VehiclePerfAge>
	{
		#region Business Methods
		[DBField()]
		private int?  _ageupto5years;

		[DBField()]
		private int?  _age5to10years;

		[DBField()]
		private int?  _ageover10years;

		[DBField()]
		private int?  _ageunknown;


		public virtual int? Ageupto5years
		{
			get
			{
                CanReadProperty("Ageupto5years", true);
				return _ageupto5years;
			}
			set
			{
                CanWriteProperty("Ageupto5years", true);
				if ( _ageupto5years != value )
				{
					_ageupto5years = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Age5to10years
		{
			get
			{
                CanReadProperty("Age5to10years", true);
				return _age5to10years;
			}
			set
			{
                CanWriteProperty("Age5to10years", true);
				if ( _age5to10years != value )
				{
					_age5to10years = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Ageover10years
		{
			get
			{
                CanReadProperty("Ageover10years", true);
				return _ageover10years;
			}
			set
			{
                CanWriteProperty("Ageover10years", true);
				if ( _ageover10years != value )
				{
					_ageover10years = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Ageunknown
		{
			get
			{
                CanReadProperty("Ageunknown", true);
				return _ageunknown;
			}
			set
			{
                CanWriteProperty("Ageunknown", true);
				if ( _ageunknown != value )
				{
					_ageunknown = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[totalvehicles]
			//?if(isnull(ageupto5years),0,ageupto5years) + if(isnull(age5to10years),0,age5to10years) + if(isnull(ageover10years),0,ageover10years) + if(isnull(ageunknown),0,ageunknown)


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static VehiclePerfAge NewVehiclePerfAge( int? inRegion, int? inOutlet, int? inRengroup, int? inContract_type )
		{
			return Create(inRegion, inOutlet, inRengroup, inContract_type);
		}

		public static VehiclePerfAge[] GetAllVehiclePerfAge( int? inRegion, int? inOutlet, int? inRengroup, int? inContract_type )
		{
			return Fetch(inRegion, inOutlet, inRengroup, inContract_type).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegion, int? inOutlet, int? inRengroup, int? inContract_type )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_vehiclesum_agev2";
                    cm.CommandTimeout = 120;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegion", inRegion);
					pList.Add(cm, "inOutlet", inOutlet);
					pList.Add(cm, "inRengroup", inRengroup);
					pList.Add(cm, "inContract_type", inContract_type);

					List<VehiclePerfAge> _list = new List<VehiclePerfAge>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehiclePerfAge instance = new VehiclePerfAge();
                            instance._ageupto5years = GetValueFromReader<int?>(dr,0);
                            instance._age5to10years = GetValueFromReader<int?>(dr,1);
                            instance._ageover10years = GetValueFromReader<int?>(dr,2);
                            instance._ageunknown = GetValueFromReader<int?>(dr,3);
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
