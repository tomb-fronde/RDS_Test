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
	[MapInfo("contract_no", "_contract_contract_no", "contract")]
	[MapInfo("con_title", "_contract_con_title", "contract")]
	[MapInfo("rgn_name", "_region_rgn_name", "region")]
	[MapInfo("o_name", "_outlet_o_name", "outlet")]
	[MapInfo("c_surname_company", "_contractor_c_surname_company", "contractor")]
	[MapInfo("c_first_names", "_contractor_c_first_names", "contractor")]
	[MapInfo("vehicle_number", "_vehicle_vehicle_number", "vehicle")]
	[MapInfo("v_vehicle_year", "_vehicle_v_vehicle_year", "vehicle")]
	[MapInfo("vs_description", "_vehicle_style_vs_description", "vehicle_style")]
	[MapInfo("v_vehicle_model", "_vehicle_v_vehicle_model", "vehicle")]
	[MapInfo("v_vehicle_cc_rating", "_vehicle_v_vehicle_cc_rating", "vehicle")]
	[MapInfo("v_vehicle_transmission", "_cv_vehicle_transmission", "vehicle")]
	[MapInfo("v_vehicle_registration_number", "_vehicle_v_vehicle_registration_number", "vehicle")]
	[MapInfo("v_purchase_value", "_vehicle_v_purchase_value", "vehicle")]
	[MapInfo("v_purchased_date", "_vehicle_v_purchased_date", "vehicle")]
	[MapInfo("con_rd_ref_text", "_contract_con_rd_ref_text", "contract")]
	[MapInfo("v_vehicle_make", "_vehicle_v_vehicle_make", "vehicle")]
	[MapInfo("ft_description", "_fuel_type_ft_description", "fuel_type")]
	[MapInfo("c_initials", "_contractor_c_initials", "contractor")]
	[MapInfo("start_kms", "_contract_vehical_start_kms", "contract_vehical")]
	[MapInfo("con_start_date", "_contract_renewals_con_start_date", "contract_renewals")]
	[MapInfo("v_vehicle_month", "_vehicle_v_vehicle_month", "vehicle")]
	[System.Serializable()]

	public class VehicleScheduleSingleContractv2 : Entity<VehicleScheduleSingleContractv2>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_contract_no;

		[DBField()]
		private string  _contract_con_title;

		[DBField()]
		private string  _region_rgn_name;

		[DBField()]
		private string  _outlet_o_name;

		[DBField()]
		private string  _contractor_c_surname_company;

		[DBField()]
		private string  _contractor_c_first_names;

		[DBField()]
		private int?  _vehicle_vehicle_number;

		[DBField()]
		private int?  _vehicle_v_vehicle_year;

		[DBField()]
		private string  _vehicle_style_vs_description;

		[DBField()]
		private string  _vehicle_v_vehicle_model;

		[DBField()]
		private int?  _vehicle_v_vehicle_cc_rating;

		[DBField()]
		private string  _cv_vehicle_transmission;

		[DBField()]
		private string  _vehicle_v_vehicle_registration_number;

		[DBField()]
		private int?  _vehicle_v_purchase_value;

		[DBField()]
		private DateTime?  _vehicle_v_purchased_date;

		[DBField()]
		private string  _contract_con_rd_ref_text;

		[DBField()]
		private string  _vehicle_v_vehicle_make;

		[DBField()]
		private string  _fuel_type_ft_description;

		[DBField()]
		private string  _contractor_c_initials;

		[DBField()]
		private int?  _contract_vehical_start_kms;

		[DBField()]
		private DateTime?  _contract_renewals_con_start_date;

		[DBField()]
		private int?  _vehicle_v_vehicle_month;


		public virtual int? ContractContractNo
		{
			get
			{
                CanReadProperty("ContractContractNo", true);
				return _contract_contract_no;
			}
			set
			{
                CanWriteProperty("ContractContractNo", true);
				if ( _contract_contract_no != value )
				{
					_contract_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractConTitle
		{
			get
			{
                CanReadProperty("ContractConTitle", true);
				return _contract_con_title;
			}
			set
			{
                CanWriteProperty("ContractConTitle", true);
				if ( _contract_con_title != value )
				{
					_contract_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionRgnName
		{
			get
			{
                CanReadProperty("RegionRgnName", true);
				return _region_rgn_name;
			}
			set
			{
                CanWriteProperty("RegionRgnName", true);
				if ( _region_rgn_name != value )
				{
					_region_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOName
		{
			get
			{
                CanReadProperty("OutletOName", true);
				return _outlet_o_name;
			}
			set
			{
                CanWriteProperty("OutletOName", true);
				if ( _outlet_o_name != value )
				{
					_outlet_o_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCSurnameCompany
		{
			get
			{
                CanReadProperty("ContractorCSurnameCompany", true);
				return _contractor_c_surname_company;
			}
			set
			{
                CanWriteProperty("ContractorCSurnameCompany", true);
				if ( _contractor_c_surname_company != value )
				{
					_contractor_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCFirstNames
		{
			get
			{
                CanReadProperty("ContractorCFirstNames", true);
				return _contractor_c_first_names;
			}
			set
			{
                CanWriteProperty("ContractorCFirstNames", true);
				if ( _contractor_c_first_names != value )
				{
					_contractor_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VehicleVehicleNumber
		{
			get
			{
                CanReadProperty("VehicleVehicleNumber", true);
				return _vehicle_vehicle_number;
			}
			set
			{
                CanWriteProperty("VehicleVehicleNumber", true);
				if ( _vehicle_vehicle_number != value )
				{
					_vehicle_vehicle_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VehicleVVehicleYear
		{
			get
			{
                CanReadProperty("VehicleVVehicleYear", true);
				return _vehicle_v_vehicle_year;
			}
			set
			{
                CanWriteProperty("VehicleVVehicleYear", true);
				if ( _vehicle_v_vehicle_year != value )
				{
					_vehicle_v_vehicle_year = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VehicleStyleVsDescription
		{
			get
			{
                CanReadProperty("VehicleStyleVsDescription", true);
				return _vehicle_style_vs_description;
			}
			set
			{
                CanWriteProperty("VehicleStyleVsDescription", true);
				if ( _vehicle_style_vs_description != value )
				{
					_vehicle_style_vs_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VehicleVVehicleModel
		{
			get
			{
                CanReadProperty("VehicleVVehicleModel", true);
				return _vehicle_v_vehicle_model;
			}
			set
			{
                CanWriteProperty("VehicleVVehicleModel", true);
				if ( _vehicle_v_vehicle_model != value )
				{
					_vehicle_v_vehicle_model = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VehicleVVehicleCcRating
		{
			get
			{
                CanReadProperty("VehicleVVehicleCcRating", true);
				return _vehicle_v_vehicle_cc_rating;
			}
			set
			{
                CanWriteProperty("VehicleVVehicleCcRating", true);
				if ( _vehicle_v_vehicle_cc_rating != value )
				{
					_vehicle_v_vehicle_cc_rating = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CvVehicleTransmission
		{
			get
			{
                CanReadProperty("CvVehicleTransmission", true);
				return _cv_vehicle_transmission;
			}
			set
			{
                CanWriteProperty("CvVehicleTransmission", true);
				if ( _cv_vehicle_transmission != value )
				{
					_cv_vehicle_transmission = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VehicleVVehicleRegistrationNumber
		{
			get
			{
                CanReadProperty("VehicleVVehicleRegistrationNumber", true);
				return _vehicle_v_vehicle_registration_number;
			}
			set
			{
                CanWriteProperty("VehicleVVehicleRegistrationNumber", true);
				if ( _vehicle_v_vehicle_registration_number != value )
				{
					_vehicle_v_vehicle_registration_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VehicleVPurchaseValue
		{
			get
			{
                CanReadProperty("VehicleVPurchaseValue", true);
				return _vehicle_v_purchase_value;
			}
			set
			{
                CanWriteProperty("VehicleVPurchaseValue", true);
				if ( _vehicle_v_purchase_value != value )
				{
					_vehicle_v_purchase_value = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? VehicleVPurchasedDate
		{
			get
			{
                CanReadProperty("VehicleVPurchasedDate", true);
				return _vehicle_v_purchased_date;
			}
			set
			{
                CanWriteProperty("VehicleVPurchasedDate", true);
				if ( _vehicle_v_purchased_date != value )
				{
					_vehicle_v_purchased_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractConRdRefText
		{
			get
			{
                CanReadProperty("ContractConRdRefText", true);
				return _contract_con_rd_ref_text;
			}
			set
			{
                CanWriteProperty("ContractConRdRefText", true);
				if ( _contract_con_rd_ref_text != value )
				{
					_contract_con_rd_ref_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VehicleVVehicleMake
		{
			get
			{
                CanReadProperty("VehicleVVehicleMake", true);
				return _vehicle_v_vehicle_make;
			}
			set
			{
                CanWriteProperty("VehicleVVehicleMake", true);
				if ( _vehicle_v_vehicle_make != value )
				{
					_vehicle_v_vehicle_make = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FuelTypeFtDescription
		{
			get
			{
                CanReadProperty("FuelTypeFtDescription", true);
				return _fuel_type_ft_description;
			}
			set
			{
                CanWriteProperty("FuelTypeFtDescription", true);
				if ( _fuel_type_ft_description != value )
				{
					_fuel_type_ft_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCInitials
		{
			get
			{
                CanReadProperty("ContractorCInitials", true);
				return _contractor_c_initials;
			}
			set
			{
                CanWriteProperty("ContractorCInitials", true);
				if ( _contractor_c_initials != value )
				{
					_contractor_c_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractVehicalStartKms
		{
			get
			{
                CanReadProperty("ContractVehicalStartKms", true);
				return _contract_vehical_start_kms;
			}
			set
			{
                CanWriteProperty("ContractVehicalStartKms", true);
				if ( _contract_vehical_start_kms != value )
				{
					_contract_vehical_start_kms = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ContractRenewalsConStartDate
		{
			get
			{
                CanReadProperty("ContractRenewalsConStartDate", true);
				return _contract_renewals_con_start_date;
			}
			set
			{
                CanWriteProperty("ContractRenewalsConStartDate", true);
				if ( _contract_renewals_con_start_date != value )
				{
					_contract_renewals_con_start_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? VehicleVVehicleMonth
		{
			get
			{
                CanReadProperty("VehicleVVehicleMonth", true);
				return _vehicle_v_vehicle_month;
			}
			set
			{
                CanWriteProperty("VehicleVVehicleMonth", true);
				if ( _vehicle_v_vehicle_month != value )
				{
					_vehicle_v_vehicle_month = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[vmonth]
			/*?if( vehicle_v_vehicle_month =1, 'January',if( vehicle_v_vehicle_month =2, 'February',if( vehicle_v_vehicle_month =3, 'March',if( vehicle_v_vehicle_month =4, 'April',if( vehicle_v_vehicle_month =5, 'May',if( vehicle_v_vehicle_month =6, 'June',if( vehicle_v_vehicle_month =7, 'July',if( vehicle_v_vehicle_month =8, 'August',if( vehicle_v_vehicle_month =9, 'September',if( vehicle_v_vehicle_month =10, 'October',if( vehicle_v_vehicle_month =11, 'November',if( vehicle_v_vehicle_month =12, 'December',''))))))))))))

			// needs to implement compute expression manually:
			// compute control name=[compute_3]
			vmonth  +' '+ string( vehicle_v_vehicle_year )

			// needs to implement compute expression manually:
			// compute control name=[transmission]
			if(cv_vehicle_transmission = 'A' ,'Automatic','Manual')*/


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static VehicleScheduleSingleContractv2 NewVehicleScheduleSingleContractv2( int? incontract, int? inSequence )
		{
			return Create(incontract, inSequence);
		}

		public static VehicleScheduleSingleContractv2[] GetAllVehicleScheduleSingleContractv2( int? incontract, int? inSequence )
		{
			return Fetch(incontract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? incontract, int? inSequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT DISTINCT contract.contract_no,  contract.con_title,  region.rgn_name, outlet.o_name, contractor.c_surname_company, contractor.c_first_names, vehicle.vehicle_number, vehicle.v_vehicle_year, vehicle_style.vs_description,vehicle.v_vehicle_model,vehicle.v_vehicle_cc_rating,vehicle.v_vehicle_transmission,vehicle.v_vehicle_registration_number,vehicle.v_purchase_value, vehicle.v_purchased_date,  contract.con_rd_ref_text, vehicle.v_vehicle_make,  fuel_type.ft_description,  contractor.c_initials,  contract_vehical.start_kms,  contract_renewals.con_start_date  ,  vehicle.v_vehicle_month  FROM contract,  contract_renewals,  contract_vehical,  outlet,  region,  contractor,  contractor_renewals,  vehicle,  vehicle_style,  fuel_type  WHERE ( contract.contract_no = contract_renewals.contract_no ) and  ( contract_renewals.contract_no = contract_vehical.contract_no ) and  ( contract_renewals.contract_seq_number = contract_vehical.contract_seq_number ) and  (region.region_id = outlet.region_id ) and  ( contract.con_base_office = outlet.outlet_id ) and  ( contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no ) and  ( contract_renewals.contract_no = contractor_renewals.contract_no ) and  ( contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number) and  (vehicle.vehicle_number= contract_vehical.vehicle_number) and  ( vehicle_style.vs_key = vehicle.vs_key) and  (fuel_type.ft_key = vehicle.ft_key ) and  ( contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date ) and  (  contract.contract_no = @incontract ) AND  ( contract_renewals.contract_seq_number = @inSequence ) AND  ( contract_vehical.vehicle_number = rd.f_GetLatestVehicle(@inContract, @inSequence)    )   ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "incontract", incontract);
					pList.Add(cm, "inSequence", inSequence);

					List<VehicleScheduleSingleContractv2> _list = new List<VehicleScheduleSingleContractv2>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehicleScheduleSingleContractv2 instance = new VehicleScheduleSingleContractv2();
                            instance._contract_contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_con_title = GetValueFromReader<string>(dr,1);
                            instance._region_rgn_name = GetValueFromReader<string>(dr,2);
                            instance._outlet_o_name = GetValueFromReader<string>(dr,3);
                            instance._contractor_c_surname_company = GetValueFromReader<string>(dr,4);
                            instance._contractor_c_first_names = GetValueFromReader<string>(dr,5);
                            instance._vehicle_vehicle_number = GetValueFromReader<int?>(dr,6);
                            instance._vehicle_v_vehicle_year = GetValueFromReader<int?>(dr,7);
                            instance._vehicle_style_vs_description = GetValueFromReader<string>(dr,8);
                            instance._vehicle_v_vehicle_model = GetValueFromReader<string>(dr,9);
                            instance._vehicle_v_vehicle_cc_rating = GetValueFromReader<int?>(dr,10);
                            instance._cv_vehicle_transmission = GetValueFromReader<string>(dr,11);
                            instance._vehicle_v_vehicle_registration_number = GetValueFromReader<string>(dr,12);
                            instance._vehicle_v_purchase_value = GetValueFromReader<int?>(dr,13);
                            instance._vehicle_v_purchased_date = GetValueFromReader<DateTime?>(dr,14);
                            instance._contract_con_rd_ref_text = GetValueFromReader<string>(dr,15);
                            instance._vehicle_v_vehicle_make = GetValueFromReader<string>(dr,16);
                            instance._fuel_type_ft_description = GetValueFromReader<string>(dr,17);
                            instance._contractor_c_initials = GetValueFromReader<string>(dr,18);
                            instance._contract_vehical_start_kms = GetValueFromReader<int?>(dr, 19);
                            instance._contract_renewals_con_start_date = GetValueFromReader<DateTime?>(dr,20);
                            instance._vehicle_v_vehicle_month = GetValueFromReader<int?>(dr,21);
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
