using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "route_audit")]
	[MapInfo("ra_date_of_check", "_ra_date_of_check", "route_audit")]
	[MapInfo("ra_time_started_sort", "_ra_time_started_sort", "route_audit")]
	[MapInfo("ra_time_finished_sort", "_ra_time_finished_sort", "route_audit")]
	[MapInfo("ra_time_returned", "_ra_time_returned", "route_audit")]
	[MapInfo("ra_time_departed", "_ra_time_departed", "route_audit")]
	[MapInfo("ra_total_hours", "_ra_total_hours", "route_audit")]
	[MapInfo("ra_meal_breaks", "_ra_meal_breaks", "route_audit")]
	[MapInfo("ra_extra_time", "_ra_extra_time", "route_audit")]
	[MapInfo("ra_final_hours", "_ra_final_hours", "route_audit")]
	[MapInfo("ra_finish_odometer", "_ra_finish_odometer", "route_audit")]
	[MapInfo("ra_start_odometer", "_ra_start_odometer", "route_audit")]
	[MapInfo("ra_extra_distance", "_ra_extra_distance", "route_audit")]
	[MapInfo("ra_othr_gds_before", "_ra_othr_gds_before", "route_audit")]
	[MapInfo("ra_othr_gds_during", "_ra_othr_gds_during", "route_audit")]
	[MapInfo("ra_othr_gds_after", "_ra_othr_gds_after", "route_audit")]
	[MapInfo("ra_pr_before", "_ra_pr_before", "route_audit")]
	[MapInfo("ra_pr_during", "_ra_pr_during", "route_audit")]
	[MapInfo("ra_pr_after", "_ra_pr_after", "route_audit")]
	[MapInfo("ra_total_distance", "_ra_total_distance", "route_audit")]
	[MapInfo("ra_final_distance", "_ra_final_distance", "route_audit")]
	[MapInfo("ra_frequency", "_ra_frequency", "route_audit")]
	[MapInfo("ra_contractor", "_ra_contractor", "route_audit")]
	[MapInfo("ra_employee", "_ra_employee", "route_audit")]
	[MapInfo("ra_vehicle_make", "_ra_vehicle_make", "route_audit")]
	[MapInfo("ra_vehicle_model", "_ra_vehicle_model", "route_audit")]
	[MapInfo("ra_year", "_ra_year", "route_audit")]
	[MapInfo("ra_registration_no", "_ra_registration_no", "route_audit")]
	[MapInfo("ra_fuel", "_ra_fuel", "route_audit")]
	[MapInfo("ra_cc_rating", "_ra_cc_rating", "route_audit")]
	[MapInfo("ra_condition", "_ra_condition", "route_audit")]
	[MapInfo("ra_rec_replace", "_ra_rec_replace", "route_audit")]
	[MapInfo("ra_tyre_size", "_ra_tyre_size", "route_audit")]
	[MapInfo("ra_gds_service", "_ra_gds_service", "route_audit")]
	[MapInfo("ra_gds_service_sighted", "_ra_gds_service_sighted", "route_audit")]
	[MapInfo("ra_mv_insurance", "_ra_mv_insurance", "route_audit")]
	[MapInfo("ra_cr_insurance", "_ra_cr_insurance", "route_audit")]
	[MapInfo("ra_pl_insurance", "_ra_pl_insurance", "route_audit")]
	[MapInfo("ra_insurance_sighted", "_ra_insurance_sighted", "route_audit")]
	[MapInfo("ra_new_vehicle", "_ra_new_vehicle", "route_audit")]
	[MapInfo("ra_vehicle_price", "_ra_vehicle_price", "route_audit")]
	[MapInfo("ra_vehicle_purchased", "_ra_vehicle_purchased", "route_audit")]
	[MapInfo("ra_mail_volume", "_ra_mail_volume", "route_audit")]
	[MapInfo("ra_mv_comments", "_ra_mv_comments", "route_audit")]
	[MapInfo("ra_adpost_volume", "_ra_adpost_volume", "route_audit")]
	[MapInfo("ra_no_circular_drops", "_ra_no_circular_drops", "route_audit")]
	[MapInfo("ra_courierpost_volume", "_ra_courierpost_volume", "route_audit")]
	[MapInfo("ra_cp_comments", "_ra_cp_comments", "route_audit")]
	[MapInfo("ra_no_reg_custs", "_ra_no_reg_custs", "route_audit")]
	[MapInfo("ra_no_reg_custs_core_prods", "_ra_no_reg_custs_core_prods", "route_audit")]
	[MapInfo("ra_other_custs", "_ra_other_custs", "route_audit")]
	[MapInfo("ra_rural_private_bags", "_ra_rural_private_bags", "route_audit")]
	[MapInfo("ra_private_bags", "_ra_private_bags", "route_audit")]
	[MapInfo("ra_closed_mails", "_ra_closed_mails", "route_audit")]
	[MapInfo("ra_post_shops", "_ra_post_shops", "route_audit")]
	[MapInfo("ra_post_centres", "_ra_post_centres", "route_audit")]
	[MapInfo("ra_no_cmbs", "_ra_no_cmbs", "route_audit")]
	[MapInfo("ra_no_cmb_custs", "_ra_no_cmb_custs", "route_audit")]
	[MapInfo("ra_total_del_points", "_ra_total_del_points", "route_audit")]
	[MapInfo("ra_sorting_facilities", "_ra_sorting_facilities", "route_audit")]
	[MapInfo("ra_sorting_case", "_ra_sorting_case", "route_audit")]
	[MapInfo("ra_sorting_comments", "_ra_sorting_comments", "route_audit")]
	[MapInfo("ra_length_sealed", "_ra_length_sealed", "route_audit")]
	[MapInfo("ra_lenth_unsealed", "_ra_lenth_unsealed", "route_audit")]
	[MapInfo("ra_total_length", "_ra_total_length", "route_audit")]
	[MapInfo("ra_road_conditions", "_ra_road_conditions", "route_audit")]
	[MapInfo("ra_suggested_improvements", "_ra_suggested_improvements", "route_audit")]
	[MapInfo("ra_commencement_ok", "_ra_commencement_ok", "route_audit")]
	[MapInfo("ra_commencement_reason", "_ra_commencement_reason", "route_audit")]
	[MapInfo("ra_timetable_change", "_ra_timetable_change", "route_audit")]
	[MapInfo("ra_route_ok", "_ra_route_ok", "route_audit")]
	[MapInfo("ra_route_reason", "_ra_route_reason", "route_audit")]
	[MapInfo("ra_deviations", "_ra_deviations", "route_audit")]
	[MapInfo("ra_deviation_in_desc", "_ra_deviation_in_desc", "route_audit")]
	[MapInfo("ra_deviation_reason", "_ra_deviation_reason", "route_audit")]
	[MapInfo("ra_description_uotdated", "_ra_description_uotdated", "route_audit")]
	[MapInfo("ra_safty_access_addresses", "_ra_safty_access_addresses", "route_audit")]
	[MapInfo("ra_safty_access_resolved_date", "_ra_safty_access_resolved_date", "route_audit")]
	[MapInfo("ra_saftey_access_actions", "_ra_saftey_access_actions", "route_audit")]
	[MapInfo("ra_safty_plan_completed", "_ra_safty_plan_completed", "route_audit")]
	[MapInfo("ra_safty_plan_completed_date", "_ra_safty_plan_completed_date", "route_audit")]
	[MapInfo("ra_safty_plan_actions", "_ra_safty_plan_actions", "route_audit")]
	[MapInfo("ra_safty_practices_exists", "_ra_safty_practices_exists", "route_audit")]
	[MapInfo("ra_safty_practices_resolved_date", "_ra_safty_practices_resolved_date", "route_audit")]
	[MapInfo("ra_safty_practices_actions", "_ra_safty_practices_actions", "route_audit")]
	[System.Serializable()]

	public class RouteAuditDePrint : Entity<RouteAuditDePrint>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private DateTime?  _ra_date_of_check;

		[DBField()]
		private  DateTime?  _ra_time_started_sort;

		[DBField()]
		private   DateTime? _ra_time_finished_sort;

		[DBField()]
		private   DateTime? _ra_time_returned;

		[DBField()]
		private   DateTime? _ra_time_departed;

		[DBField()]
		private  DateTime?  _ra_total_hours;

		[DBField()]
		private  DateTime?  _ra_meal_breaks;

		[DBField()]
		private  DateTime?  _ra_extra_time;

		[DBField()]
		private   DateTime? _ra_final_hours;

		[DBField()]
		private decimal?  _ra_finish_odometer;

		[DBField()]
		private decimal?  _ra_start_odometer;

		[DBField()]
		private decimal?  _ra_extra_distance;

		[DBField()]
		private  DateTime?  _ra_othr_gds_before;

		[DBField()]
		private  DateTime?  _ra_othr_gds_during;

		[DBField()]
		private   DateTime? _ra_othr_gds_after;

		[DBField()]
		private  DateTime?  _ra_pr_before;

		[DBField()]
		private  DateTime?  _ra_pr_during;

		[DBField()]
		private   DateTime? _ra_pr_after;

		[DBField()]
		private decimal?  _ra_total_distance;

		[DBField()]
		private decimal?  _ra_final_distance;

		[DBField()]
		private string  _ra_frequency;

		[DBField()]
		private string  _ra_contractor;

		[DBField()]
		private string  _ra_employee;

		[DBField()]
		private string  _ra_vehicle_make;

		[DBField()]
		private string  _ra_vehicle_model;

		[DBField()]
		private int?  _ra_year;

		[DBField()]
		private string  _ra_registration_no;

		[DBField()]
		private string  _ra_fuel;

		[DBField()]
		private int?  _ra_cc_rating;

		[DBField()]
		private string  _ra_condition;

		[DBField()]
		private DateTime?  _ra_rec_replace;

		[DBField()]
		private string  _ra_tyre_size;

		[DBField()]
		private string  _ra_gds_service="N";

        [DBField()]
        private string _ra_gds_service_sighted = "N";

		[DBField()]
        private string _ra_mv_insurance = "N";

		[DBField()]
        private string _ra_cr_insurance = "N";

		[DBField()]
        private string _ra_pl_insurance = "N";

		[DBField()]
        private string _ra_insurance_sighted = "N";

		[DBField()]
        private string _ra_new_vehicle = "N";

		[DBField()]
		private int?  _ra_vehicle_price;

		[DBField()]
		private DateTime?  _ra_vehicle_purchased;

		[DBField()]
		private string  _ra_mail_volume="A";

		[DBField()]
		private string  _ra_mv_comments;

		[DBField()]
        private string _ra_adpost_volume = "A";

		[DBField()]
		private int?  _ra_no_circular_drops;

		[DBField()]
        private string _ra_courierpost_volume = "A";

		[DBField()]
		private string  _ra_cp_comments;

		[DBField()]
		private int?  _ra_no_reg_custs;

		[DBField()]
		private int?  _ra_no_reg_custs_core_prods;

		[DBField()]
		private int?  _ra_other_custs;

		[DBField()]
		private int?  _ra_rural_private_bags;

		[DBField()]
		private int?  _ra_private_bags;

		[DBField()]
		private int?  _ra_closed_mails;

		[DBField()]
		private int?  _ra_post_shops;

		[DBField()]
		private int?  _ra_post_centres;

		[DBField()]
		private int?  _ra_no_cmbs;

		[DBField()]
		private int?  _ra_no_cmb_custs;

		[DBField()]
		private int?  _ra_total_del_points;

		[DBField()]
		private string  _ra_sorting_facilities;

		[DBField()]
		private string  _ra_sorting_case;

		[DBField()]
		private string  _ra_sorting_comments;

		[DBField()]
		private decimal?  _ra_length_sealed;

		[DBField()]
		private decimal?  _ra_lenth_unsealed;

		[DBField()]
		private decimal?  _ra_total_length;

		[DBField()]
		private string  _ra_road_conditions;

		[DBField()]
		private string  _ra_suggested_improvements;

		[DBField()]
		private string  _ra_commencement_ok;

		[DBField()]
		private string  _ra_commencement_reason;

		[DBField()]
		private string  _ra_timetable_change;

		[DBField()]
		private string  _ra_route_ok;

		[DBField()]
		private string  _ra_route_reason;

		[DBField()]
		private string  _ra_deviations;

		[DBField()]
		private string  _ra_deviation_in_desc;

		[DBField()]
		private string  _ra_deviation_reason;

		[DBField()]
		private string  _ra_description_uotdated;

		[DBField()]
		private string  _ra_safty_access_addresses;

		[DBField()]
		private DateTime?  _ra_safty_access_resolved_date;

		[DBField()]
		private string  _ra_saftey_access_actions;

		[DBField()]
		private string  _ra_safty_plan_completed;

		[DBField()]
		private DateTime?  _ra_safty_plan_completed_date;

		[DBField()]
		private string  _ra_safty_plan_actions;

		[DBField()]
		private string  _ra_safty_practices_exists;

		[DBField()]
		private DateTime?  _ra_safty_practices_resolved_date;

		[DBField()]
		private string  _ra_safty_practices_actions;


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

		public virtual DateTime? RaDateOfCheck
		{
			get
			{
                CanReadProperty("RaDateOfCheck", true);
				return _ra_date_of_check;
			}
			set
			{
                CanWriteProperty("RaDateOfCheck", true);
				if ( _ra_date_of_check != value )
				{
					_ra_date_of_check = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaTimeStartedSort
		{
			get
			{
                CanReadProperty("RaTimeStartedSort", true);
				return _ra_time_started_sort;
			}
			set
			{
                CanWriteProperty("RaTimeStartedSort", true);
				if ( _ra_time_started_sort != value )
				{
					_ra_time_started_sort = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaTimeFinishedSort
		{
			get
			{
                CanReadProperty("RaTimeFinishedSort", true);
				return _ra_time_finished_sort;
			}
			set
			{
                CanWriteProperty("RaTimeFinishedSort", true);
				if ( _ra_time_finished_sort != value )
				{
					_ra_time_finished_sort = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaTimeReturned
		{
			get
			{
                CanReadProperty("RaTimeReturned", true);
				return _ra_time_returned;
			}
			set
			{
                CanWriteProperty("RaTimeReturned", true);
				if ( _ra_time_returned != value )
				{
					_ra_time_returned = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaTimeDeparted
		{
			get
			{
                CanReadProperty("RaTimeDeparted", true);
				return _ra_time_departed;
			}
			set
			{
                CanWriteProperty("RaTimeDeparted", true);
				if ( _ra_time_departed != value )
				{
					_ra_time_departed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaTotalHours
		{
			get
			{
                CanReadProperty("RaTotalHours", true);
				return _ra_total_hours;
			}
			set
			{
                CanWriteProperty("RaTotalHours", true);
				if ( _ra_total_hours != value )
				{
					_ra_total_hours = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime?  RaMealBreaks
		{
			get
			{
                CanReadProperty("RaMealBreaks", true);
				return _ra_meal_breaks;
			}
			set
			{
                CanWriteProperty("RaMealBreaks", true);
				if ( _ra_meal_breaks != value )
				{
					_ra_meal_breaks = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaExtraTime
		{
			get
			{
                CanReadProperty("RaExtraTime", true);
				return _ra_extra_time;
			}
			set
			{
                CanWriteProperty("RaExtraTime", true);
				if ( _ra_extra_time != value )
				{
					_ra_extra_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaFinalHours
		{
			get
			{
                CanReadProperty("RaFinalHours", true);
				return _ra_final_hours;
			}
			set
			{
                CanWriteProperty("RaFinalHours", true);
				if ( _ra_final_hours != value )
				{
					_ra_final_hours = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaFinishOdometer
		{
			get
			{
                CanReadProperty("RaFinishOdometer", true);
				return _ra_finish_odometer;
			}
			set
			{
                CanWriteProperty("RaFinishOdometer", true);
				if ( _ra_finish_odometer != value )
				{
					_ra_finish_odometer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaStartOdometer
		{
			get
			{
                CanReadProperty("RaStartOdometer", true);
				return _ra_start_odometer;
			}
			set
			{
                CanWriteProperty("RaStartOdometer", true);
				if ( _ra_start_odometer != value )
				{
					_ra_start_odometer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaExtraDistance
		{
			get
			{
                CanReadProperty("RaExtraDistance", true);
				return _ra_extra_distance;
			}
			set
			{
                CanWriteProperty("RaExtraDistance", true);
				if ( _ra_extra_distance != value )
				{
					_ra_extra_distance = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual  DateTime? RaOthrGdsBefore
		{
			get
			{
                CanReadProperty("RaOthrGdsBefore", true);
				return _ra_othr_gds_before;
			}
			set
			{
                CanWriteProperty("RaOthrGdsBefore", true);
				if ( _ra_othr_gds_before != value )
				{
					_ra_othr_gds_before = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaOthrGdsDuring
		{
			get
			{
                CanReadProperty("RaOthrGdsDuring", true);
				return _ra_othr_gds_during;
			}
			set
			{
                CanWriteProperty("RaOthrGdsDuring", true);
				if ( _ra_othr_gds_during != value )
				{
					_ra_othr_gds_during = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaOthrGdsAfter
		{
			get
			{
                CanReadProperty("RaOthrGdsAfter", true);
				return _ra_othr_gds_after;
			}
			set
			{
                CanWriteProperty("RaOthrGdsAfter", true);
				if ( _ra_othr_gds_after != value )
				{
					_ra_othr_gds_after = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaPrBefore
		{
			get
			{
                CanReadProperty("RaPrBefore", true);
				return _ra_pr_before;
			}
			set
			{
                CanWriteProperty("RaPrBefore", true);
				if ( _ra_pr_before != value )
				{
					_ra_pr_before = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaPrDuring
		{
			get
			{
                CanReadProperty("RaPrDuring", true);
				return _ra_pr_during;
			}
			set
			{
                CanWriteProperty("RaPrDuring", true);
				if ( _ra_pr_during != value )
				{
					_ra_pr_during = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual  DateTime? RaPrAfter
		{
			get
			{
                CanReadProperty("RaPrAfter", true);
				return _ra_pr_after;
			}
			set
			{
                CanWriteProperty("RaPrAfter", true);
				if ( _ra_pr_after != value )
				{
					_ra_pr_after = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaTotalDistance
		{
			get
			{
                CanReadProperty("RaTotalDistance", true);
				return _ra_total_distance;
			}
			set
			{
                CanWriteProperty("RaTotalDistance", true);
				if ( _ra_total_distance != value )
				{
					_ra_total_distance = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaFinalDistance
		{
			get
			{
                CanReadProperty("RaFinalDistance", true);
				return _ra_final_distance;
			}
			set
			{
                CanWriteProperty("RaFinalDistance", true);
				if ( _ra_final_distance != value )
				{
					_ra_final_distance = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaFrequency
		{
			get
			{
                CanReadProperty("RaFrequency", true);
				return _ra_frequency;
			}
			set
			{
                CanWriteProperty("RaFrequency", true);
				if ( _ra_frequency != value )
				{
					_ra_frequency = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaContractor
		{
			get
			{
                CanReadProperty("RaContractor", true);
				return _ra_contractor;
			}
			set
			{
                CanWriteProperty("RaContractor", true);
				if ( _ra_contractor != value )
				{
					_ra_contractor = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaEmployee
		{
			get
			{
                CanReadProperty("RaEmployee", true);
				return _ra_employee;
			}
			set
			{
                CanWriteProperty("RaEmployee", true);
				if ( _ra_employee != value )
				{
					_ra_employee = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaVehicleMake
		{
			get
			{
                CanReadProperty("RaVehicleMake", true);
				return _ra_vehicle_make;
			}
			set
			{
                CanWriteProperty("RaVehicleMake", true);
				if ( _ra_vehicle_make != value )
				{
					_ra_vehicle_make = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaVehicleModel
		{
			get
			{
                CanReadProperty("RaVehicleModel", true);
				return _ra_vehicle_model;
			}
			set
			{
                CanWriteProperty("RaVehicleModel", true);
				if ( _ra_vehicle_model != value )
				{
					_ra_vehicle_model = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaYear
		{
			get
			{
                CanReadProperty("RaYear", true);
				return _ra_year;
			}
			set
			{
                CanWriteProperty("RaYear", true);
				if ( _ra_year != value )
				{
					_ra_year = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaRegistrationNo
		{
			get
			{
                CanReadProperty("RaRegistrationNo", true);
				return _ra_registration_no;
			}
			set
			{
                CanWriteProperty("RaRegistrationNo", true);
				if ( _ra_registration_no != value )
				{
					_ra_registration_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaFuel
		{
			get
			{
                CanReadProperty("RaFuel", true);
				return _ra_fuel;
			}
			set
			{
                CanWriteProperty("RaFuel", true);
				if ( _ra_fuel != value )
				{
					_ra_fuel = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaCcRating
		{
			get
			{
                CanReadProperty("RaCcRating", true);
				return _ra_cc_rating;
			}
			set
			{
                CanWriteProperty("RaCcRating", true);
				if ( _ra_cc_rating != value )
				{
					_ra_cc_rating = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaCondition
		{
			get
			{
                CanReadProperty("RaCondition", true);
				return _ra_condition;
			}
			set
			{
                CanWriteProperty("RaCondition", true);
				if ( _ra_condition != value )
				{
					_ra_condition = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RaRecReplace
		{
			get
			{
                CanReadProperty("RaRecReplace", true);
				return _ra_rec_replace;
			}
			set
			{
                CanWriteProperty("RaRecReplace", true);
				if ( _ra_rec_replace != value )
				{
					_ra_rec_replace = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaTyreSize
		{
			get
			{
                CanReadProperty("RaTyreSize", true);
				return _ra_tyre_size;
			}
			set
			{
                CanWriteProperty("RaTyreSize", true);
				if ( _ra_tyre_size != value )
				{
					_ra_tyre_size = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaGdsService
		{
			get
			{
                CanReadProperty("RaGdsService", true);
				return _ra_gds_service;
			}
			set
			{
                CanWriteProperty("RaGdsService", true);
				if ( _ra_gds_service != value )
				{
					_ra_gds_service = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaGdsServiceSighted
		{
			get
			{
                CanReadProperty("RaGdsServiceSighted", true);
				return _ra_gds_service_sighted;
			}
			set
			{
                CanWriteProperty("RaGdsServiceSighted", true);
				if ( _ra_gds_service_sighted != value )
				{
					_ra_gds_service_sighted = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaMvInsurance
		{
			get
			{
                CanReadProperty("RaMvInsurance", true);
				return _ra_mv_insurance;
			}
			set
			{
                CanWriteProperty("RaMvInsurance", true);
				if ( _ra_mv_insurance != value )
				{
					_ra_mv_insurance = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaCrInsurance
		{
			get
			{
                CanReadProperty("RaCrInsurance", true);
				return _ra_cr_insurance;
			}
			set
			{
                CanWriteProperty("RaCrInsurance", true);
				if ( _ra_cr_insurance != value )
				{
					_ra_cr_insurance = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaPlInsurance
		{
			get
			{
                CanReadProperty("RaPlInsurance", true);
				return _ra_pl_insurance;
			}
			set
			{
                CanWriteProperty("RaPlInsurance", true);
				if ( _ra_pl_insurance != value )
				{
					_ra_pl_insurance = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaInsuranceSighted
		{
			get
			{
                CanReadProperty("RaInsuranceSighted", true);
				return _ra_insurance_sighted;
			}
			set
			{
                CanWriteProperty("RaInsuranceSighted", true);
				if ( _ra_insurance_sighted != value )
				{
					_ra_insurance_sighted = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaNewVehicle
		{
			get
			{
                CanReadProperty("RaNewVehicle", true);
				return _ra_new_vehicle;
			}
			set
			{
                CanWriteProperty("RaNewVehicle", true);
				if ( _ra_new_vehicle != value )
				{
					_ra_new_vehicle = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaVehiclePrice
		{
			get
			{
                CanReadProperty("RaVehiclePrice", true);
				return _ra_vehicle_price;
			}
			set
			{
                CanWriteProperty("RaVehiclePrice", true);
				if ( _ra_vehicle_price != value )
				{
					_ra_vehicle_price = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RaVehiclePurchased
		{
			get
			{
                CanReadProperty("RaVehiclePurchased", true);
				return _ra_vehicle_purchased;
			}
			set
			{
                CanWriteProperty("RaVehiclePurchased", true);
				if ( _ra_vehicle_purchased != value )
				{
					_ra_vehicle_purchased = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaMailVolume
		{
			get
			{
                CanReadProperty("RaMailVolume", true);
				return _ra_mail_volume;
			}
			set
			{
                CanWriteProperty("RaMailVolume", true);
				if ( _ra_mail_volume != value )
				{
					_ra_mail_volume = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaMvComments
		{
			get
			{
                CanReadProperty("RaMvComments", true);
				return _ra_mv_comments;
			}
			set
			{
                CanWriteProperty("RaMvComments", true);
				if ( _ra_mv_comments != value )
				{
					_ra_mv_comments = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaAdpostVolume
		{
			get
			{
                CanReadProperty("RaAdpostVolume", true);
				return _ra_adpost_volume;
			}
			set
			{
                CanWriteProperty("RaAdpostVolume", true);
				if ( _ra_adpost_volume != value )
				{
					_ra_adpost_volume = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaNoCircularDrops
		{
			get
			{
                CanReadProperty("RaNoCircularDrops", true);
				return _ra_no_circular_drops;
			}
			set
			{
                CanWriteProperty("RaNoCircularDrops", true);
				if ( _ra_no_circular_drops != value )
				{
					_ra_no_circular_drops = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaCourierpostVolume
		{
			get
			{
                CanReadProperty("RaCourierpostVolume", true);
				return _ra_courierpost_volume;
			}
			set
			{
                CanWriteProperty("RaCourierpostVolume", true);
				if ( _ra_courierpost_volume != value )
				{
					_ra_courierpost_volume = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaCpComments
		{
			get
			{
                CanReadProperty("RaCpComments", true);
				return _ra_cp_comments;
			}
			set
			{
                CanWriteProperty("RaCpComments", true);
				if ( _ra_cp_comments != value )
				{
					_ra_cp_comments = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaNoRegCusts
		{
			get
			{
                CanReadProperty("RaNoRegCusts", true);
				return _ra_no_reg_custs;
			}
			set
			{
                CanWriteProperty("RaNoRegCusts", true);
				if ( _ra_no_reg_custs != value )
				{
					_ra_no_reg_custs = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaNoRegCustsCoreProds
		{
			get
			{
                CanReadProperty("RaNoRegCustsCoreProds", true);
				return _ra_no_reg_custs_core_prods;
			}
			set
			{
                CanWriteProperty("RaNoRegCustsCoreProds", true);
				if ( _ra_no_reg_custs_core_prods != value )
				{
					_ra_no_reg_custs_core_prods = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaOtherCusts
		{
			get
			{
                CanReadProperty("RaOtherCusts", true);
				return _ra_other_custs;
			}
			set
			{
                CanWriteProperty("RaOtherCusts", true);
				if ( _ra_other_custs != value )
				{
					_ra_other_custs = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaRuralPrivateBags
		{
			get
			{
                CanReadProperty("RaRuralPrivateBags", true);
				return _ra_rural_private_bags;
			}
			set
			{
                CanWriteProperty("RaRuralPrivateBags", true);
				if ( _ra_rural_private_bags != value )
				{
					_ra_rural_private_bags = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaPrivateBags
		{
			get
			{
                CanReadProperty("RaPrivateBags", true);
				return _ra_private_bags;
			}
			set
			{
                CanWriteProperty("RaPrivateBags", true);
				if ( _ra_private_bags != value )
				{
					_ra_private_bags = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaClosedMails
		{
			get
			{
                CanReadProperty("RaClosedMails", true);
				return _ra_closed_mails;
			}
			set
			{
                CanWriteProperty("RaClosedMails", true);
				if ( _ra_closed_mails != value )
				{
					_ra_closed_mails = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaPostShops
		{
			get
			{
                CanReadProperty("RaPostShops", true);
				return _ra_post_shops;
			}
			set
			{
                CanWriteProperty("RaPostShops", true);
				if ( _ra_post_shops != value )
				{
					_ra_post_shops = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaPostCentres
		{
			get
			{
                CanReadProperty("RaPostCentres", true);
				return _ra_post_centres;
			}
			set
			{
                CanWriteProperty("RaPostCentres", true);
				if ( _ra_post_centres != value )
				{
					_ra_post_centres = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaNoCmbs
		{
			get
			{
                CanReadProperty("RaNoCmbs", true);
				return _ra_no_cmbs;
			}
			set
			{
                CanWriteProperty("RaNoCmbs", true);
				if ( _ra_no_cmbs != value )
				{
					_ra_no_cmbs = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaNoCmbCusts
		{
			get
			{
                CanReadProperty("RaNoCmbCusts", true);
				return _ra_no_cmb_custs;
			}
			set
			{
                CanWriteProperty("RaNoCmbCusts", true);
				if ( _ra_no_cmb_custs != value )
				{
					_ra_no_cmb_custs = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RaTotalDelPoints
		{
			get
			{
                CanReadProperty("RaTotalDelPoints", true);
				return _ra_total_del_points;
			}
			set
			{
                CanWriteProperty("RaTotalDelPoints", true);
				if ( _ra_total_del_points != value )
				{
					_ra_total_del_points = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSortingFacilities
		{
			get
			{
                CanReadProperty("RaSortingFacilities", true);
				return _ra_sorting_facilities;
			}
			set
			{
                CanWriteProperty("RaSortingFacilities", true);
				if ( _ra_sorting_facilities != value )
				{
					_ra_sorting_facilities = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSortingCase
		{
			get
			{
                CanReadProperty("RaSortingCase", true);
				return _ra_sorting_case;
			}
			set
			{
                CanWriteProperty("RaSortingCase", true);
				if ( _ra_sorting_case != value )
				{
					_ra_sorting_case = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSortingComments
		{
			get
			{
                CanReadProperty("RaSortingComments", true);
				return _ra_sorting_comments;
			}
			set
			{
                CanWriteProperty("RaSortingComments", true);
				if ( _ra_sorting_comments != value )
				{
					_ra_sorting_comments = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaLengthSealed
		{
			get
			{
                CanReadProperty("RaLengthSealed", true);
				return _ra_length_sealed;
			}
			set
			{
                CanWriteProperty("RaLengthSealed", true);
				if ( _ra_length_sealed != value )
				{
					_ra_length_sealed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaLenthUnsealed
		{
			get
			{
                CanReadProperty("RaLenthUnsealed", true);
				return _ra_lenth_unsealed;
			}
			set
			{
                CanWriteProperty("RaLenthUnsealed", true);
				if ( _ra_lenth_unsealed != value )
				{
					_ra_lenth_unsealed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RaTotalLength
		{
			get
			{
                CanReadProperty("RaTotalLength", true);
				return _ra_total_length;
			}
			set
			{
                CanWriteProperty("RaTotalLength", true);
				if ( _ra_total_length != value )
				{
					_ra_total_length = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaRoadConditions
		{
			get
			{
                CanReadProperty("RaRoadConditions", true);
				return _ra_road_conditions;
			}
			set
			{
                CanWriteProperty("RaRoadConditions", true);
				if ( _ra_road_conditions != value )
				{
					_ra_road_conditions = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSuggestedImprovements
		{
			get
			{
                CanReadProperty("RaSuggestedImprovements", true);
				return _ra_suggested_improvements;
			}
			set
			{
                CanWriteProperty("RaSuggestedImprovements", true);
				if ( _ra_suggested_improvements != value )
				{
					_ra_suggested_improvements = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaCommencementOk
		{
			get
			{
                CanReadProperty("RaCommencementOk", true);
				return _ra_commencement_ok;
			}
			set
			{
                CanWriteProperty("RaCommencementOk", true);
				if ( _ra_commencement_ok != value )
				{
					_ra_commencement_ok = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaCommencementReason
		{
			get
			{
                CanReadProperty("RaCommencementReason", true);
				return _ra_commencement_reason;
			}
			set
			{
                CanWriteProperty("RaCommencementReason", true);
				if ( _ra_commencement_reason != value )
				{
					_ra_commencement_reason = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaTimetableChange
		{
			get
			{
                CanReadProperty("RaTimetableChange", true);
				return _ra_timetable_change;
			}
			set
			{
                CanWriteProperty("RaTimetableChange", true);
				if ( _ra_timetable_change != value )
				{
					_ra_timetable_change = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaRouteOk
		{
			get
			{
                CanReadProperty("RaRouteOk", true);
				return _ra_route_ok;
			}
			set
			{
                CanWriteProperty("RaRouteOk", true);
				if ( _ra_route_ok != value )
				{
					_ra_route_ok = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaRouteReason
		{
			get
			{
                CanReadProperty("RaRouteReason", true);
				return _ra_route_reason;
			}
			set
			{
                CanWriteProperty("RaRouteReason", true);
				if ( _ra_route_reason != value )
				{
					_ra_route_reason = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaDeviations
		{
			get
			{
                CanReadProperty("RaDeviations", true);
				return _ra_deviations;
			}
			set
			{
                CanWriteProperty("RaDeviations", true);
				if ( _ra_deviations != value )
				{
					_ra_deviations = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaDeviationInDesc
		{
			get
			{
                CanReadProperty("RaDeviationInDesc", true);
				return _ra_deviation_in_desc;
			}
			set
			{
                CanWriteProperty("RaDeviationInDesc", true);
				if ( _ra_deviation_in_desc != value )
				{
					_ra_deviation_in_desc = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaDeviationReason
		{
			get
			{
                CanReadProperty("RaDeviationReason", true);
				return _ra_deviation_reason;
			}
			set
			{
                CanWriteProperty("RaDeviationReason", true);
				if ( _ra_deviation_reason != value )
				{
					_ra_deviation_reason = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaDescriptionUotdated
		{
			get
			{
                CanReadProperty("RaDescriptionUotdated", true);
				return _ra_description_uotdated;
			}
			set
			{
                CanWriteProperty("RaDescriptionUotdated", true);
				if ( _ra_description_uotdated != value )
				{
					_ra_description_uotdated = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSaftyAccessAddresses
		{
			get
			{
                CanReadProperty("RaSaftyAccessAddresses", true);
				return _ra_safty_access_addresses;
			}
			set
			{
                CanWriteProperty("RaSaftyAccessAddresses", true);
				if ( _ra_safty_access_addresses != value )
				{
					_ra_safty_access_addresses = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RaSaftyAccessResolvedDate
		{
			get
			{
                CanReadProperty("RaSaftyAccessResolvedDate", true);
				return _ra_safty_access_resolved_date;
			}
			set
			{
                CanWriteProperty("RaSaftyAccessResolvedDate", true);
				if ( _ra_safty_access_resolved_date != value )
				{
					_ra_safty_access_resolved_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSafteyAccessActions
		{
			get
			{
                CanReadProperty("RaSafteyAccessActions", true);
				return _ra_saftey_access_actions;
			}
			set
			{
                CanWriteProperty("RaSafteyAccessActions", true);
				if ( _ra_saftey_access_actions != value )
				{
					_ra_saftey_access_actions = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSaftyPlanCompleted
		{
			get
			{
                CanReadProperty("RaSaftyPlanCompleted", true);
				return _ra_safty_plan_completed;
			}
			set
			{
                CanWriteProperty("RaSaftyPlanCompleted", true);
				if ( _ra_safty_plan_completed != value )
				{
					_ra_safty_plan_completed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RaSaftyPlanCompletedDate
		{
			get
			{
                CanReadProperty("RaSaftyPlanCompletedDate", true);
				return _ra_safty_plan_completed_date;
			}
			set
			{
                CanWriteProperty("RaSaftyPlanCompletedDate", true);
				if ( _ra_safty_plan_completed_date != value )
				{
					_ra_safty_plan_completed_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSaftyPlanActions
		{
			get
			{
                CanReadProperty("RaSaftyPlanActions", true);
				return _ra_safty_plan_actions;
			}
			set
			{
                CanWriteProperty("RaSaftyPlanActions", true);
				if ( _ra_safty_plan_actions != value )
				{
					_ra_safty_plan_actions = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSaftyPracticesExists
		{
			get
			{
                CanReadProperty("RaSaftyPracticesExists", true);
				return _ra_safty_practices_exists;
			}
			set
			{
                CanWriteProperty("RaSaftyPracticesExists", true);
				if ( _ra_safty_practices_exists != value )
				{
					_ra_safty_practices_exists = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RaSaftyPracticesResolvedDate
		{
			get
			{
                CanReadProperty("RaSaftyPracticesResolvedDate", true);
				return _ra_safty_practices_resolved_date;
			}
			set
			{
                CanWriteProperty("RaSaftyPracticesResolvedDate", true);
				if ( _ra_safty_practices_resolved_date != value )
				{
					_ra_safty_practices_resolved_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaSaftyPracticesActions
		{
			get
			{
                CanReadProperty("RaSaftyPracticesActions", true);
				return _ra_safty_practices_actions;
			}
			set
			{
                CanWriteProperty("RaSaftyPracticesActions", true);
				if ( _ra_safty_practices_actions != value )
				{
					_ra_safty_practices_actions = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return _ra_finish_odometer - _ra_start_odometer;
            }
        }

        public virtual decimal? Compute2
        {
            get
            {
                CanReadProperty("Compute2", true);
                return (_ra_finish_odometer - _ra_start_odometer) - (_ra_extra_distance == null ? 0 : _ra_extra_distance);
            }
        }

        public virtual decimal? Compute3
        {
            get
            {
                CanReadProperty("Compute3", true);
                return (_ra_no_reg_custs == null ? 0 : _ra_no_reg_custs) + (_ra_rural_private_bags == null ? 0 : _ra_rural_private_bags) + (_ra_no_cmb_custs == null ? 0 : _ra_no_cmb_custs);
            }
        }

        public virtual decimal? Compute4
        {
            get
            {
                CanReadProperty("Compute4", true);
                return (_ra_length_sealed == null ? 0 : _ra_length_sealed) + (_ra_lenth_unsealed == null ? 0 : _ra_lenth_unsealed);
            }
        }
        
        protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}", _contract_no,_ra_date_of_check );
		}
		#endregion

		#region Factory Methods
		public static RouteAuditDePrint NewRouteAuditDePrint( int? contract, DateTime? auditdate )
		{
			return Create(contract, auditdate);
		}

		public static RouteAuditDePrint[] GetAllRouteAuditDePrint( int? contract, DateTime? auditdate )
		{
			return Fetch(contract, auditdate).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract, DateTime? auditdate )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT route_audit.contract_no,  route_audit.ra_date_of_check,  route_audit.ra_time_started_sort,  route_audit.ra_time_finished_sort,  route_audit.ra_time_returned,  route_audit.ra_time_departed,  route_audit.ra_total_hours,  route_audit.ra_meal_breaks,  route_audit.ra_extra_time,  route_audit.ra_final_hours,  route_audit.ra_finish_odometer,  route_audit.ra_start_odometer,  route_audit.ra_extra_distance,  route_audit.ra_othr_gds_before,  route_audit.ra_othr_gds_during,  route_audit.ra_othr_gds_after,  route_audit.ra_pr_before,  route_audit.ra_pr_during,  route_audit.ra_pr_after,  route_audit.ra_total_distance,  route_audit.ra_final_distance,  route_audit.ra_frequency,  route_audit.ra_contractor,  route_audit.ra_employee,  route_audit.ra_vehicle_make,  route_audit.ra_vehicle_model,  route_audit.ra_year,  route_audit.ra_registration_no,  route_audit.ra_fuel,  route_audit.ra_cc_rating,  route_audit.ra_condition,  route_audit.ra_rec_replace,  route_audit.ra_tyre_size,  route_audit.ra_gds_service,  route_audit.ra_gds_service_sighted,  route_audit.ra_mv_insurance,  route_audit.ra_cr_insurance,  route_audit.ra_pl_insurance,  route_audit.ra_insurance_sighted,  route_audit.ra_new_vehicle,  route_audit.ra_vehicle_price,  route_audit.ra_vehicle_purchased,  route_audit.ra_mail_volume,  route_audit.ra_mv_comments,  route_audit.ra_adpost_volume,  route_audit.ra_no_circular_drops,  route_audit.ra_courierpost_volume,  route_audit.ra_cp_comments,  route_audit.ra_no_reg_custs,  route_audit.ra_no_reg_custs_core_prods,  route_audit.ra_other_custs,  route_audit.ra_rural_private_bags,  route_audit.ra_private_bags,  route_audit.ra_closed_mails,  route_audit.ra_post_shops,  route_audit.ra_post_centres,  route_audit.ra_no_cmbs,  route_audit.ra_no_cmb_custs,  route_audit.ra_total_del_points,  route_audit.ra_sorting_facilities,  route_audit.ra_sorting_case,  route_audit.ra_sorting_comments,  route_audit.ra_length_sealed,  route_audit.ra_lenth_unsealed,  route_audit.ra_total_length,  route_audit.ra_road_conditions,  route_audit.ra_suggested_improvements,  route_audit.ra_commencement_ok,  route_audit.ra_commencement_reason,  route_audit.ra_timetable_change,  route_audit.ra_route_ok,  route_audit.ra_route_reason,  route_audit.ra_deviations,  route_audit.ra_deviation_in_desc,  route_audit.ra_deviation_reason,  route_audit.ra_description_uotdated  ,  route_audit.ra_safty_access_addresses,  route_audit.ra_safty_access_resolved_date,  route_audit.ra_saftey_access_actions,  route_audit.ra_safty_plan_completed,  route_audit.ra_safty_plan_completed_date,  route_audit.ra_safty_plan_actions,  route_audit.ra_safty_practices_exists,  route_audit.ra_safty_practices_resolved_date,  route_audit.ra_safty_practices_actions  FROM route_audit  WHERE ( route_audit.contract_no = @contract ) AND  ( route_audit.ra_date_of_check = @auditdate )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contract", contract);
					pList.Add(cm, "auditdate", auditdate);

					List<RouteAuditDePrint> _list = new List<RouteAuditDePrint>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RouteAuditDePrint instance = new RouteAuditDePrint();

                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._ra_date_of_check = GetValueFromReader<DateTime?>(dr,1);
                            instance._ra_time_started_sort = GetValueFromReader<DateTime>(dr,2);
                            instance._ra_time_finished_sort = GetValueFromReader<DateTime>(dr,3);
                            instance._ra_time_returned = GetValueFromReader<DateTime>(dr,4);

                            instance._ra_time_departed = GetValueFromReader<DateTime>(dr,5);
                            instance._ra_total_hours = GetValueFromReader<DateTime>(dr,6);
                            instance._ra_meal_breaks = GetValueFromReader<DateTime>(dr,7);
                            instance._ra_extra_time = GetValueFromReader<DateTime>(dr,8);
                            instance._ra_final_hours = GetValueFromReader<DateTime>(dr,9);

                            instance._ra_finish_odometer = GetValueFromReader<Decimal?>(dr,10);
                            instance._ra_start_odometer = GetValueFromReader<Decimal?>(dr,11);
                            instance._ra_extra_distance = GetValueFromReader<Decimal?>(dr,12);
                            instance._ra_othr_gds_before = GetValueFromReader<DateTime>(dr,13);
                            instance._ra_othr_gds_during = GetValueFromReader<DateTime>(dr,14);

                            instance._ra_othr_gds_after = GetValueFromReader<DateTime>(dr,15);
                            instance._ra_pr_before = GetValueFromReader<DateTime>(dr,16);
                            instance._ra_pr_during = GetValueFromReader<DateTime>(dr,17);
                            instance._ra_pr_after = GetValueFromReader<DateTime>(dr,18);
                            instance._ra_total_distance = GetValueFromReader<Decimal?>(dr,19);

                            instance._ra_final_distance = GetValueFromReader<Decimal?>(dr,20);
                            instance._ra_frequency = GetValueFromReader<String>(dr,21);
                            instance._ra_contractor = GetValueFromReader<String>(dr,22);
                            instance._ra_employee = GetValueFromReader<String>(dr,23);
                            instance._ra_vehicle_make = GetValueFromReader<String>(dr,24);

                            instance._ra_vehicle_model = GetValueFromReader<String>(dr,25);
                            instance._ra_year = GetValueFromReader<Int32?>(dr,26);
                            instance._ra_registration_no = GetValueFromReader<String>(dr,27);
                            instance._ra_fuel = GetValueFromReader<String>(dr,28);
                            instance._ra_cc_rating = GetValueFromReader<Int32?>(dr,29);

                            instance._ra_condition = GetValueFromReader<String>(dr,30);
                            instance._ra_rec_replace = GetValueFromReader<DateTime?>(dr,31);
                            instance._ra_tyre_size = GetValueFromReader<String>(dr,32);
                            instance._ra_gds_service = GetValueFromReader<String>(dr,33);
                            instance._ra_gds_service_sighted = GetValueFromReader<String>(dr,34);

                            instance._ra_mv_insurance = GetValueFromReader<String>(dr,35);
                            instance._ra_cr_insurance = GetValueFromReader<String>(dr,36);
                            instance._ra_pl_insurance = GetValueFromReader<String>(dr,37);
                            instance._ra_insurance_sighted = GetValueFromReader<String>(dr,38);
                            instance._ra_new_vehicle = GetValueFromReader<String>(dr,39);

                            instance._ra_vehicle_price = GetValueFromReader<Int32?>(dr,40);
                            instance._ra_vehicle_purchased = GetValueFromReader<DateTime?>(dr,41);
                            instance._ra_mail_volume = GetValueFromReader<String>(dr,42);
                            instance._ra_mv_comments = GetValueFromReader<String>(dr,43);
                            instance._ra_adpost_volume = GetValueFromReader<String>(dr,44);

                            instance._ra_no_circular_drops = GetValueFromReader<Int32?>(dr,45);
                            instance._ra_courierpost_volume = GetValueFromReader<String>(dr,46);
                            instance._ra_cp_comments = GetValueFromReader<String>(dr,47);
                            instance._ra_no_reg_custs = GetValueFromReader<Int32?>(dr,48);
                            instance._ra_no_reg_custs_core_prods = GetValueFromReader<Int32?>(dr,49);

                            instance._ra_other_custs = GetValueFromReader<Int32?>(dr,50);
                            instance._ra_rural_private_bags = GetValueFromReader<Int32?>(dr,51);
                            instance._ra_private_bags = GetValueFromReader<Int32?>(dr,52);
                            instance._ra_closed_mails = GetValueFromReader<Int32?>(dr,53);
                            instance._ra_post_shops = GetValueFromReader<Int32?>(dr,54);

                            instance._ra_post_centres = GetValueFromReader<Int32?>(dr,55);
                            instance._ra_no_cmbs = GetValueFromReader<Int32?>(dr,56);
                            instance._ra_no_cmb_custs = GetValueFromReader<Int32?>(dr,57);
                            instance._ra_total_del_points = GetValueFromReader<Int32?>(dr,58);
                            instance._ra_sorting_facilities = GetValueFromReader<String>(dr,59);
	
                            instance._ra_sorting_case = GetValueFromReader<String>(dr,60);
                            instance._ra_sorting_comments = GetValueFromReader<String>(dr,61);
                            instance._ra_length_sealed = GetValueFromReader<Decimal?>(dr,62);
                            instance._ra_lenth_unsealed = GetValueFromReader<Decimal?>(dr,63);
                            instance._ra_total_length = GetValueFromReader<Decimal?>(dr,64);

                            instance._ra_road_conditions = GetValueFromReader<String>(dr,65);
                            instance._ra_suggested_improvements = GetValueFromReader<String>(dr,66);
                            instance._ra_commencement_ok = GetValueFromReader<String>(dr,67);
                            instance._ra_commencement_reason = GetValueFromReader<String>(dr,68);
                            instance._ra_timetable_change = GetValueFromReader<String>(dr,69);

                            instance._ra_route_ok = GetValueFromReader<String>(dr,70);
                            instance._ra_route_reason = GetValueFromReader<String>(dr,71);
                            instance._ra_deviations = GetValueFromReader<String>(dr,72);
                            instance._ra_deviation_in_desc = GetValueFromReader<String>(dr,73);
                            instance._ra_deviation_reason = GetValueFromReader<String>(dr,74);

                            instance._ra_description_uotdated = GetValueFromReader<String>(dr,75);
                            instance._ra_safty_access_addresses = GetValueFromReader<String>(dr,76);
                            instance._ra_safty_access_resolved_date = GetValueFromReader<DateTime?>(dr,77);
                            instance._ra_saftey_access_actions = GetValueFromReader<String>(dr,78);
                            instance._ra_safty_plan_completed = GetValueFromReader<String>(dr,79);

                            instance._ra_safty_plan_completed_date = GetValueFromReader<DateTime?>(dr,80);
                            instance._ra_safty_plan_actions = GetValueFromReader<String>(dr,81);
                            instance._ra_safty_practices_exists = GetValueFromReader<String>(dr,82);
                            instance._ra_safty_practices_resolved_date = GetValueFromReader<DateTime?>(dr,83);
                            instance._ra_safty_practices_actions = GetValueFromReader<String>(dr,84);
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		[ServerMethod()]
		private void UpdateEntity()
		{
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "route_audit", ref pList))
				{
					cm.CommandText += " WHERE  route_audit.contract_no = @contract_no AND " + 
						"route_audit.ra_date_of_check = @ra_date_of_check ";

					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "ra_date_of_check", GetInitialValue("_ra_date_of_check"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "route_audit", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
			using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;
					cm.CommandType = CommandType.Text;
						ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm,"ra_date_of_check", GetInitialValue("_ra_date_of_check"));
						cm.CommandText = "DELETE FROM route_audit WHERE " +
						"route_audit.contract_no = @contract_no AND " + 
						"route_audit.ra_date_of_check = @ra_date_of_check ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract_no, DateTime? ra_date_of_check )
		{
			_contract_no = contract_no;
			_ra_date_of_check = ra_date_of_check;
		}
	}
}
