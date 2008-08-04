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
	[MapInfo("start_kms", "_start_kms", "")]
	[MapInfo("v_vehicle_make", "_v_vehicle_make", "")]
	[MapInfo("v_vehicle_model", "_v_vehicle_model", "")]
	[MapInfo("v_vehicle_year", "_v_vehicle_year", "")]
	[MapInfo("v_vehicle_registration_number", "_v_vehicle_registration_number", "")]
	[MapInfo("v_purchased_date", "_v_purchased_date", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("vehicle_number", "_vehicle_number", "")]
	[MapInfo("cv_vehical_status", "_cv_vehical_status", "")]
	[MapInfo("purchasestatus", "_purchasestatus", "")]
	[MapInfo("con_expiry_date", "_con_expiry_date", "")]
	[MapInfo("con_distance_at_renewal", "_con_distance_at_renewal", "")]
	[MapInfo("con_start_date", "_con_start_date", "")]
	[System.Serializable()]

	public class VehicleAgedetails : Entity<VehicleAgedetails>
	{
		#region Business Methods
		[DBField()]
		private int?  _start_kms;

		[DBField()]
		private string  _v_vehicle_make;

		[DBField()]
		private string  _v_vehicle_model;

		[DBField()]
		private int?  _v_vehicle_year;

		[DBField()]
		private string  _v_vehicle_registration_number;

		[DBField()]
		private DateTime?  _v_purchased_date;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private int?  _vehicle_number;

		[DBField()]
		private string  _cv_vehical_status;

		[DBField()]
		private string  _purchasestatus;

		[DBField()]
		private DateTime?  _con_expiry_date;

		[DBField()]
		private decimal?  _con_distance_at_renewal;

		[DBField()]
		private DateTime?  _con_start_date;


		public virtual int? StartKms
		{
			get
			{
                CanReadProperty("StartKms", true);
				return _start_kms;
			}
			set
			{
                CanWriteProperty("StartKms", true);
				if ( _start_kms != value )
				{
					_start_kms = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VVehicleMake
		{
			get
			{
                CanReadProperty("VVehicleMake", true);
				return _v_vehicle_make;
			}
			set
			{
                CanWriteProperty("VVehicleMake", true);
				if ( _v_vehicle_make != value )
				{
					_v_vehicle_make = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VVehicleModel
		{
			get
			{
                CanReadProperty("VVehicleModel", true);
				return _v_vehicle_model;
			}
			set
			{
                CanWriteProperty("VVehicleModel", true);
				if ( _v_vehicle_model != value )
				{
					_v_vehicle_model = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VVehicleYear
		{
			get
			{
                CanReadProperty("VVehicleYear", true);
				return _v_vehicle_year;
			}
			set
			{
                CanWriteProperty("VVehicleYear", true);
				if ( _v_vehicle_year != value )
				{
					_v_vehicle_year = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VVehicleRegistrationNumber
		{
			get
			{
                CanReadProperty("VVehicleRegistrationNumber", true);
				return _v_vehicle_registration_number;
			}
			set
			{
                CanWriteProperty("VVehicleRegistrationNumber", true);
				if ( _v_vehicle_registration_number != value )
				{
					_v_vehicle_registration_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? VPurchasedDate
		{
			get
			{
                CanReadProperty("VPurchasedDate", true);
				return _v_purchased_date;
			}
			set
			{
                CanWriteProperty("VPurchasedDate", true);
				if ( _v_purchased_date != value )
				{
					_v_purchased_date = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual int? ContractSeqNumber
		{
			get
			{
                CanReadProperty("ContractSeqNumber", true);
				return _contract_seq_number;
			}
			set
			{
                CanWriteProperty("ContractSeqNumber", true);
				if ( _contract_seq_number != value )
				{
					_contract_seq_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VehicleNumber
		{
			get
			{
                CanReadProperty("VehicleNumber", true);
				return _vehicle_number;
			}
			set
			{
                CanWriteProperty("VehicleNumber", true);
				if ( _vehicle_number != value )
				{
					_vehicle_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CvVehicalStatus
		{
			get
			{
                CanReadProperty("CvVehicalStatus", true);
				return _cv_vehical_status;
			}
			set
			{
                CanWriteProperty("CvVehicalStatus", true);
				if ( _cv_vehical_status != value )
				{
					_cv_vehical_status = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Purchasestatus
		{
			get
			{
                CanReadProperty("Purchasestatus", true);
				return _purchasestatus;
			}
			set
			{
                CanWriteProperty("Purchasestatus", true);
				if ( _purchasestatus != value )
				{
					_purchasestatus = value;
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

		public virtual DateTime? ConStartDate
		{
			get
			{
                CanReadProperty("ConStartDate", true);
				return _con_start_date;
			}
			set
			{
                CanWriteProperty("ConStartDate", true);
				if ( _con_start_date != value )
				{
					_con_start_date = value;
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
		public static VehicleAgedetails NewVehicleAgedetails( int? inContract, int? inSequence, int? inVehicleNo )
		{
			return Create(inContract, inSequence, inVehicleNo);
		}

		public static VehicleAgedetails[] GetAllVehicleAgedetails( int? inContract, int? inSequence, int? inVehicleNo )
		{
			return Fetch(inContract, inSequence, inVehicleNo).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence, int? inVehicleNo )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_vehicleagingdetails";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);
					pList.Add(cm, "inVehicleNo", inVehicleNo);

					List<VehicleAgedetails> _list = new List<VehicleAgedetails>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehicleAgedetails instance = new VehicleAgedetails();
                            instance._start_kms = GetValueFromReader<int?>(dr,0);
                            instance._v_vehicle_make = GetValueFromReader<string>(dr,1);
                            instance._v_vehicle_model = GetValueFromReader<string>(dr,2);
                            instance._v_vehicle_year = GetValueFromReader<int?>(dr,3);
                            instance._v_vehicle_registration_number = GetValueFromReader<string>(dr,4);
                            instance._v_purchased_date = GetValueFromReader<DateTime?>(dr,5);
                            instance._contract_no = GetValueFromReader<int?>(dr,6);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,7);
                            instance._vehicle_number = GetValueFromReader<int?>(dr,8);
                            instance._cv_vehical_status = GetValueFromReader<string>(dr,9);
                            instance._purchasestatus = GetValueFromReader<string>(dr,10);
                            instance._con_expiry_date = GetValueFromReader<DateTime?>(dr,11);
                            instance._con_distance_at_renewal = GetValueFromReader<decimal?>(dr,12);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr,13);
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
