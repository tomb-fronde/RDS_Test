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
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("con_start_date", "_con_start_date", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("c_initials", "_c_initials", "")]
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("sf_description", "_sf_description", "")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
	[MapInfo("rfpt_description", "_rfpt_description", "")]
	[MapInfo("rd_time_at_point", "_rd_time_at_point", "")]
	[MapInfo("rd_description_of_point", "_rd_description_of_point", "")]
	[MapInfo("rf_distance_of_leg", "_rf_distance_of_leg", "")]
	[MapInfo("rfv_description", "_rfv_description", "")]
	[MapInfo("rfv_description_2", "_rfv_description_2", "")]
	[MapInfo("rf_running_total", "_rf_running_total", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("rgn_name", "_rgn_name", "")]
	[MapInfo("con_rd_ref_text", "_con_rd_ref_text", "")]
	[MapInfo("rf_annotation", "_rf_annotation", "")]
	[MapInfo("rf_annotation_print", "_rf_annotation_print", "")]
	[MapInfo("cust_id", "_cust_id", "")]
	[System.Serializable()]

	public class RouteDescriptionSingleContract : Entity<RouteDescriptionSingleContract>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private DateTime?  _con_start_date;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _sf_description;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private string  _rfpt_description;

		[DBField()]
		private  string  _rd_time_at_point;

		[DBField()]
		private string  _rd_description_of_point;

		[DBField()]
		private decimal?  _rf_distance_of_leg;

		[DBField()]
		private string  _rfv_description;

		[DBField()]
		private string  _rfv_description_2;

		[DBField()]
		private decimal?  _rf_running_total;

		[DBField()]
		private string  _o_name;

		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private string  _con_rd_ref_text;

		[DBField()]
		private string  _rf_annotation;

		[DBField()]
		private string  _rf_annotation_print;

		[DBField()]
		private int?  _cust_id;


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

		public virtual string ConTitle
		{
			get
			{
                CanReadProperty("ConTitle", true);
				return _con_title;
			}
			set
			{
                CanWriteProperty("ConTitle", true);
				if ( _con_title != value )
				{
					_con_title = value;
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

		public virtual string CSurnameCompany
		{
			get
			{
                CanReadProperty("CSurnameCompany", true);
				return _c_surname_company;
			}
			set
			{
                CanWriteProperty("CSurnameCompany", true);
				if ( _c_surname_company != value )
				{
					_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CFirstNames
		{
			get
			{
                CanReadProperty("CFirstNames", true);
				return _c_first_names;
			}
			set
			{
                CanWriteProperty("CFirstNames", true);
				if ( _c_first_names != value )
				{
					_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CInitials
		{
			get
			{
                CanReadProperty("CInitials", true);
				return _c_initials;
			}
			set
			{
                CanWriteProperty("CInitials", true);
				if ( _c_initials != value )
				{
					_c_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SfKey
		{
			get
			{
                CanReadProperty("SfKey", true);
				return _sf_key;
			}
			set
			{
                CanWriteProperty("SfKey", true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SfDescription
		{
			get
			{
                CanReadProperty("SfDescription", true);
				return _sf_description;
			}
			set
			{
                CanWriteProperty("SfDescription", true);
				if ( _sf_description != value )
				{
					_sf_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfDeliveryDays
		{
			get
			{
                CanReadProperty("RfDeliveryDays", true);
				return _rf_delivery_days;
			}
			set
			{
                CanWriteProperty("RfDeliveryDays", true);
				if ( _rf_delivery_days != value )
				{
					_rf_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfptDescription
		{
			get
			{
                CanReadProperty("RfptDescription", true);
				return _rfpt_description;
			}
			set
			{
                CanWriteProperty("RfptDescription", true);
				if ( _rfpt_description != value )
				{
					_rfpt_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdTimeAtPoint
		{
			get
			{
                CanReadProperty("RdTimeAtPoint", true);
				return _rd_time_at_point;
			}
			set
			{
                CanWriteProperty("RdTimeAtPoint", true);
				if ( _rd_time_at_point != value )
				{
					_rd_time_at_point = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdDescriptionOfPoint
		{
			get
			{
                CanReadProperty("RdDescriptionOfPoint", true);
				return _rd_description_of_point;
			}
			set
			{
                CanWriteProperty("RdDescriptionOfPoint", true);
				if ( _rd_description_of_point != value )
				{
					_rd_description_of_point = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RfDistanceOfLeg
		{
			get
			{
                CanReadProperty("RfDistanceOfLeg", true);
				return _rf_distance_of_leg;
			}
			set
			{
                CanWriteProperty("RfDistanceOfLeg", true);
				if ( _rf_distance_of_leg != value )
				{
					_rf_distance_of_leg = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfvDescription
		{
			get
			{
                CanReadProperty("RfvDescription", true);
				return _rfv_description;
			}
			set
			{
                CanWriteProperty("RfvDescription", true);
				if ( _rfv_description != value )
				{
					_rfv_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfvDescription2
		{
			get
			{
                CanReadProperty("RfvDescription2", true);
				return _rfv_description_2;
			}
			set
			{
                CanWriteProperty("RfvDescription2", true);
				if ( _rfv_description_2 != value )
				{
					_rfv_description_2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RfRunningTotal
		{
			get
			{
                CanReadProperty("RfRunningTotal", true);
				return _rf_running_total;
			}
			set
			{
                CanWriteProperty("RfRunningTotal", true);
				if ( _rf_running_total != value )
				{
					_rf_running_total = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OName
		{
			get
			{
                CanReadProperty("OName", true);
				return _o_name;
			}
			set
			{
                CanWriteProperty("OName", true);
				if ( _o_name != value )
				{
					_o_name = value;
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

		public virtual string ConRdRefText
		{
			get
			{
                CanReadProperty("ConRdRefText", true);
				return _con_rd_ref_text;
			}
			set
			{
                CanWriteProperty("ConRdRefText", true);
				if ( _con_rd_ref_text != value )
				{
					_con_rd_ref_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfAnnotation
		{
			get
			{
                CanReadProperty("RfAnnotation", true);
				return _rf_annotation;
			}
			set
			{
                CanWriteProperty("RfAnnotation", true);
				if ( _rf_annotation != value )
				{
					_rf_annotation = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfAnnotationPrint
		{
			get
			{
                CanReadProperty("RfAnnotationPrint", true);
				return _rf_annotation_print;
			}
			set
			{
                CanWriteProperty("RfAnnotationPrint", true);
				if ( _rf_annotation_print != value )
				{
					_rf_annotation_print = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CustId
		{
			get
			{
                CanReadProperty("CustId", true);
				return _cust_id;
			}
			set
			{
                CanWriteProperty("CustId", true);
				if ( _cust_id != value )
				{
					_cust_id = value;
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
		public static RouteDescriptionSingleContract NewRouteDescriptionSingleContract( int? inContract, int? inSequence )
		{
			return Create(inContract, inSequence);
		}

		public static RouteDescriptionSingleContract[] GetAllRouteDescriptionSingleContract( int? inContract, int? inSequence )
		{
			return Fetch(inContract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_RptRouteDescription2";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);

					List<RouteDescriptionSingleContract> _list = new List<RouteDescriptionSingleContract>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RouteDescriptionSingleContract instance = new RouteDescriptionSingleContract();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,1);
                            instance._con_title = GetValueFromReader<string>(dr,2);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr,3);
                            instance._c_surname_company = GetValueFromReader<string>(dr,4);
                            instance._c_first_names = GetValueFromReader<string>(dr,5);
                            instance._c_initials = GetValueFromReader<string>(dr,6);
                            instance._sf_key = GetValueFromReader<int?>(dr,7);
                            instance._sf_description = GetValueFromReader<string>(dr,8);
                            instance._rf_delivery_days = GetValueFromReader<string>(dr,9);
                            instance._rfpt_description = GetValueFromReader<string>(dr,10);
                            instance._rd_time_at_point = GetValueFromReader<string>(dr,11);
                            instance._rd_description_of_point = GetValueFromReader<string>(dr,12);
                            instance._rf_distance_of_leg = GetValueFromReader<decimal?>(dr,13);
                            instance._rfv_description = GetValueFromReader<string>(dr,14);
                            instance._rfv_description_2 = GetValueFromReader<string>(dr,15);
                            instance._rf_running_total = GetValueFromReader<decimal?>(dr,16);
                            instance._o_name = GetValueFromReader<string>(dr,17);
                            instance._rgn_name = GetValueFromReader<string>(dr,18);
                            instance._con_rd_ref_text = GetValueFromReader<string>(dr,19);
                            instance._rf_annotation = GetValueFromReader<string>(dr,20);
                            instance._rf_annotation_print = GetValueFromReader<string>(dr,21);
                            instance._cust_id = GetValueFromReader<int?>(dr,22);
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
