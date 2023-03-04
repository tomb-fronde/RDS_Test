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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("rgn_name", "_rgn_name", "")]
	[MapInfo("con_expiry_date", "_con_expiry_date", "")]
	[MapInfo("con_distance_at_renewal", "_con_distance_at_renewal", "")]
	[MapInfo("vehicle_no", "_vehicle_no", "")]
	[MapInfo("rg_description", "_rg_description", "")]
	[MapInfo("con_active_sequence", "_con_active_sequence", "")]
	[MapInfo("contract_type", "_contract_type", "")]
	[MapInfo("vage", "_vage", "")]
	[System.Serializable()]

	public class VehicleAge : Entity<VehicleAge>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private DateTime?  _con_expiry_date;

		[DBField()]
		private decimal?  _con_distance_at_renewal;

		[DBField()]
		private int?  _vehicle_no;

		[DBField()]
		private string  _rg_description;

		[DBField()]
		private int?  _con_active_sequence;

		[DBField()]
		private string  _contract_type;

		[DBField()]
		private int?  _vage;


		public virtual int? ContractNo
		{
			get
			{
                CanReadProperty("ContractNo", true);
				return _contract_no;
			}
			set
			{
                CanWriteProperty("ContractNo", true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnName
		{
			get
			{
                CanReadProperty("RgnName", true);
				return _rgn_name;
			}
			set
			{
                CanWriteProperty("RgnName", true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ConExpiryDate
		{
			get
			{
                CanReadProperty("ConExpiryDate", true);
				return _con_expiry_date;
			}
			set
			{
                CanWriteProperty("ConExpiryDate", true);
				if ( _con_expiry_date != value )
				{
					_con_expiry_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? ConDistanceAtRenewal
		{
			get
			{
                CanReadProperty("ConDistanceAtRenewal", true);
				return _con_distance_at_renewal;
			}
			set
			{
                CanWriteProperty("ConDistanceAtRenewal", true);
				if ( _con_distance_at_renewal != value )
				{
					_con_distance_at_renewal = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VehicleNo
		{
			get
			{
                CanReadProperty("VehicleNo", true);
				return _vehicle_no;
			}
			set
			{
                CanWriteProperty("VehicleNo", true);
				if ( _vehicle_no != value )
				{
					_vehicle_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgDescription
		{
			get
			{
                CanReadProperty("RgDescription", true);
				return _rg_description;
			}
			set
			{
                CanWriteProperty("RgDescription", true);
				if ( _rg_description != value )
				{
					_rg_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ConActiveSequence
		{
			get
			{
                CanReadProperty("ConActiveSequence", true);
				return _con_active_sequence;
			}
			set
			{
                CanWriteProperty("ConActiveSequence", true);
				if ( _con_active_sequence != value )
				{
					_con_active_sequence = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractType
		{
			get
			{
                CanReadProperty("ContractType", true);
				return _contract_type;
			}
			set
			{
                CanWriteProperty("ContractType", true);
				if ( _contract_type != value )
				{
					_contract_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Vage
		{
			get
			{
                CanReadProperty("Vage", true);
				return _vage;
			}
			set
			{
                CanWriteProperty("Vage", true);
				if ( _vage != value )
				{
					_vage = value;
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
		public static VehicleAge NewVehicleAge( int? inRegion, int? inOutlet, int? inRenewalGroup, int? inContractType )
		{
			return Create(inRegion, inOutlet, inRenewalGroup, inContractType);
		}

		public static VehicleAge[] GetAllVehicleAge( int? inRegion, int? inOutlet, int? inRenewalGroup, int? inContractType )
		{
			return Fetch(inRegion, inOutlet, inRenewalGroup, inContractType).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegion, int? inOutlet, int? inRenewalGroup, int? inContractType )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_vehicleaging";
                    cm.CommandTimeout = 100;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegion", inRegion);
					pList.Add(cm, "inOutlet", inOutlet);
					pList.Add(cm, "inRenewalGroup", inRenewalGroup);
					pList.Add(cm, "inContractType", inContractType);

					List<VehicleAge> _list = new List<VehicleAge>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehicleAge instance = new VehicleAge();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._rgn_name = GetValueFromReader<string>(dr,1);
                            instance._con_expiry_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._con_distance_at_renewal = GetValueFromReader<decimal?>(dr,3);
                            instance._vehicle_no = GetValueFromReader<int?>(dr,4);
                            instance._rg_description = GetValueFromReader<string>(dr,5);
                            instance._con_active_sequence = GetValueFromReader<int?>(dr,6);
                            instance._contract_type = GetValueFromReader<string>(dr,7);
                            instance._vage = GetValueFromReader<int?>(dr,8);
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
