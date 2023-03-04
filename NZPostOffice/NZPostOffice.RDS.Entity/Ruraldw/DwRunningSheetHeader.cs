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
	[MapInfo("contract_no", "_contract_no", "contract")]
	[MapInfo("con_old_mail_service_no", "_con_old_mail_service_no", "contract")]
	[MapInfo("con_title", "_con_title", "contract")]
	[MapInfo("rd_description_of_point", "_route_description_rd_description_of_poin", "route_description")]
	[MapInfo("rd_sequence", "_route_description_rd_sequence", "route_description")]
	[MapInfo("address_name", "_address_name", "address")]
	[System.Serializable()]

	public class RunningSheetHeader : Entity<RunningSheetHeader>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_old_mail_service_no;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _route_description_rd_description_of_poin;

		[DBField()]
		private int?  _route_description_rd_sequence;

		[DBField()]
		private string  _address_name;


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

		public virtual string ConOldMailServiceNo
		{
			get
			{
                CanReadProperty("ConOldMailServiceNo", true);
				return _con_old_mail_service_no;
			}
			set
			{
                CanWriteProperty("ConOldMailServiceNo", true);
				if ( _con_old_mail_service_no != value )
				{
					_con_old_mail_service_no = value;
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

		public virtual string RouteDescriptionRdDescriptionOfPoin
		{
			get
			{
                CanReadProperty("RouteDescriptionRdDescriptionOfPoin", true);
				return _route_description_rd_description_of_poin;
			}
			set
			{
                CanWriteProperty("RouteDescriptionRdDescriptionOfPoin", true);
				if ( _route_description_rd_description_of_poin != value )
				{
					_route_description_rd_description_of_poin = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RouteDescriptionRDSequence
		{
			get
			{
                CanReadProperty("RouteDescriptionRDSequence", true);
				return _route_description_rd_sequence;
			}
			set
			{
                CanWriteProperty("RouteDescriptionRDSequence", true);
				if ( _route_description_rd_sequence != value )
				{
					_route_description_rd_sequence = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AddressName
		{
			get
			{
                CanReadProperty("AddressName", true);
				return _address_name;
			}
			set
			{
                CanWriteProperty("AddressName", true);
				if ( _address_name != value )
				{
					_address_name = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[description]
			//if( route_description_rd_description_of_poin='',  address_name ,  route_description_rd_description_of_poin  )
        public virtual string Description
        {
            get
            {
                CanReadProperty("Description", true);
                return ( _route_description_rd_description_of_poin == "" ? _address_name :_route_description_rd_description_of_poin);
            }
        }

        protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static RunningSheetHeader NewRunningSheetHeader( int? incontract, int? insfkey, string indeldays )
		{
			return Create(incontract, insfkey, indeldays);
		}

		public static RunningSheetHeader[] GetAllRunningSheetHeader( int? incontract, int? insfkey, string indeldays )
		{
			return Fetch(incontract, insfkey, indeldays).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? incontract, int? insfkey, string indeldays )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT distinct contract.contract_no,  contract.con_old_mail_service_no,  contract.con_title,  route_description.rd_description_of_point,  route_description.rd_sequence,  (select case when adr_unit is null then NULL else adr_unit+'/'end +adr_no+adr_alpha+' '  +rd.road_name  +case when rt.rt_name is null then NULL else ' '+rt.rt_name end  + case when rs.rs_name is null then NULL else ' '+rs.rs_name end  from address addr join road rd on ( addr.road_id = rd.road_id) left outer join road_type rt on rd.rt_id = rt.rt_id left outer join road_suffix rs on rd.rs_id = rs.rs_id where addr.adr_id = route_description.adr_id)  as Address_name  FROM contract,  contract_renewals,  route_frequency,  route_description  WHERE  contract.contract_no = @incontract AND  route_description.sf_key = @insfkey AND  route_frequency.rf_delivery_days = @indeldays  AND  contract_renewals.contract_no = contract.contract_no  and  contract.con_active_sequence = contract_renewals.contract_seq_number  and  route_frequency.contract_no = contract.contract_no  and  route_description.contract_no = route_frequency.contract_no  and  route_description.sf_key = route_frequency.sf_key  and  route_description.rf_delivery_days = route_frequency.rf_delivery_days  ORDER BY route_description.rd_sequence ASC  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "incontract", incontract);
					pList.Add(cm, "insfkey", insfkey);
					pList.Add(cm, "indeldays", indeldays);

					List<RunningSheetHeader> _list = new List<RunningSheetHeader>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RunningSheetHeader instance = new RunningSheetHeader();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._con_old_mail_service_no = GetValueFromReader<String>(dr,1);
                            instance._con_title = GetValueFromReader<String>(dr,2);
                            instance._route_description_rd_description_of_poin = GetValueFromReader<String>(dr,3);
                            instance._route_description_rd_sequence = GetValueFromReader<Int16?>(dr,4);
                            instance._address_name = GetValueFromReader<String>(dr,5);
                            
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
