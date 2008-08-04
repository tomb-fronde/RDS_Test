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
	[MapInfo("outlet_id", "_outlet_outlet_id", "outlet")]
	[MapInfo("ot_code", "_outlet_ot_code", "outlet")]
	[MapInfo("region_id", "_outlet_region_id", "outlet")]
	[MapInfo("o_name", "_outlet_o_name", "outlet")]
	[MapInfo("o_address", "_outlet_o_address", "outlet")]
	[MapInfo("o_telephone", "_outlet_o_telephone", "outlet")]
	[MapInfo("o_fax", "_outlet_o_fax", "outlet")]
	[MapInfo("o_manager", "_outlet_o_manager", "outlet")]
	[MapInfo("o_responsibility_code", "_outlet_o_responsibility_code", "outlet")]
	[MapInfo("ot_outlet_type", "_outlet_type", "outlet_type")]
	[MapInfo("rgn_name", "_region_rgn_name", "region")]
	[MapInfo("o_phy_address", "_o_phy_address", "outlet")]
	[System.Serializable()]

	public class OutletBaseOfficeReport : Entity<OutletBaseOfficeReport>
	{
		#region Business Methods
		[DBField()]
		private int?  _outlet_outlet_id;

		[DBField()]
		private int?  _outlet_ot_code;

		[DBField()]
		private int?  _outlet_region_id;

		[DBField()]
		private string  _outlet_o_name;

		[DBField()]
		private string  _outlet_o_address;

		[DBField()]
		private string  _outlet_o_telephone;

		[DBField()]
		private string  _outlet_o_fax;

		[DBField()]
		private string  _outlet_o_manager;

		[DBField()]
		private string  _outlet_o_responsibility_code;

		[DBField()]
		private string  _outlet_type;

		[DBField()]
		private string  _region_rgn_name;

		[DBField()]
		private string  _o_phy_address;


		public virtual int? OutletOutletId
		{
			get
			{
                CanReadProperty("OutletOutletId", true);
				return _outlet_outlet_id;
			}
			set
			{
                CanWriteProperty("OutletOutletId", true);
				if ( _outlet_outlet_id != value )
				{
					_outlet_outlet_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? OutletOtCode
		{
			get
			{
                CanReadProperty("OutletOtCode",true);
				return _outlet_ot_code;
			}
			set
			{
                CanWriteProperty("OutletOtCode", true);
				if ( _outlet_ot_code != value )
				{
					_outlet_ot_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? OutletRegionId
		{
			get
			{
                CanReadProperty("OutletRegionId", true);
				return _outlet_region_id;
			}
			set
			{
                CanWriteProperty("OutletRegionId", true);
				if ( _outlet_region_id != value )
				{
					_outlet_region_id = value;
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

		public virtual string OutletOAddress
		{
			get
			{
                CanReadProperty("OutletOAddress", true);
				return _outlet_o_address;
			}
			set
			{
                CanWriteProperty("OutletOAddress", true);
				if ( _outlet_o_address != value )
				{
					_outlet_o_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOTelephone
		{
			get
			{
                CanReadProperty("OutletOTelephone", true);
				return _outlet_o_telephone;
			}
			set
			{
                CanWriteProperty("OutletOTelephone", true);
				if ( _outlet_o_telephone != value )
				{
					_outlet_o_telephone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOFax
		{
			get
			{
                CanReadProperty("OutletOFax", true);
				return _outlet_o_fax;
			}
			set
			{
                CanWriteProperty("OutletOFax", true);
				if ( _outlet_o_fax != value )
				{
					_outlet_o_fax = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOManager
		{
			get
			{
                CanReadProperty("OutletOManager", true);
				return _outlet_o_manager;
			}
			set
			{
                CanWriteProperty("OutletOManager", true);
				if ( _outlet_o_manager != value )
				{
					_outlet_o_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletOResponsibilityCode
		{
			get
			{
                CanReadProperty("OutletOResponsibilityCode", true);
				return _outlet_o_responsibility_code;
			}
			set
			{
                CanWriteProperty("OutletOResponsibilityCode", true);
				if ( _outlet_o_responsibility_code != value )
				{
					_outlet_o_responsibility_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OutletType
		{
			get
			{
                CanReadProperty("OutletType", true);
				return _outlet_type;
			}
			set
			{
                CanWriteProperty("OutletType", true);
				if ( _outlet_type != value )
				{
					_outlet_type = value;
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

		public virtual string OPhyAddress
		{
			get
			{
                CanReadProperty("OPhyAddress", true);
				return _o_phy_address;
			}
			set
			{
                CanWriteProperty("OPhyAddress", true);
				if ( _o_phy_address != value )
				{
					_o_phy_address = value;
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
		public static OutletBaseOfficeReport NewOutletBaseOfficeReport( int? inRegion )
		{
			return Create(inRegion);
		}

		public static OutletBaseOfficeReport[] GetAllOutletBaseOfficeReport( int? inRegion )
		{
			return Fetch(inRegion).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegion )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT DISTINCT  outlet.outlet_id ,"
                        +" outlet.ot_code ,"
                        +" outlet.region_id ,"
                        +" outlet.o_name ,"
                        +" outlet.o_address ,"
                        +" outlet.o_telephone ,"
                        +" outlet.o_fax ,"
                        +" outlet.o_manager ,"
                        +" outlet.o_responsibility_code ,"
                        +" outlet_type.ot_outlet_type ,"
                        +" region.rgn_name ,"
                        +" outlet.o_phy_address"
                        +" FROM outlet ,"
                        +" outlet_type ,"
                        +" region ,"
                        +" contract ,"
                        +" types_for_contract"
                        +" WHERE ( outlet_type.ot_code = outlet.ot_code ) and          ( region.region_id = outlet.region_id ) and          ( contract.con_base_office = outlet.outlet_id ) and          ( types_for_contract.contract_no = contract.contract_no ) and          (outlet.region_id = :inRegion or          ( :inRegion = 0 ) ) And          ( outlet.o_name <> 'Non-RD Dummy' ) And          ( types_for_contract.ct_key = 1 ) and          ( contract.con_date_terminated is null )"
                        +" ORDER BY outlet.region_id          ASC,"
                        +" outlet.o_name          ASC";

					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegion", inRegion);

					List<OutletBaseOfficeReport> _list = new List<OutletBaseOfficeReport>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OutletBaseOfficeReport instance = new OutletBaseOfficeReport();
                            instance._outlet_outlet_id = GetValueFromReader<int?>(dr,0);
                            instance._outlet_ot_code = GetValueFromReader<int?>(dr,1);
                            instance._outlet_region_id = GetValueFromReader<int?>(dr,2);
                            instance._outlet_o_name = GetValueFromReader<string>(dr,3);
                            instance._outlet_o_address = GetValueFromReader<string>(dr,4);
                            instance._outlet_o_telephone = GetValueFromReader<string>(dr,5);
                            instance._outlet_o_fax = GetValueFromReader<string>(dr,6);
                            instance._outlet_o_manager = GetValueFromReader<string>(dr,7);
                            instance._outlet_o_responsibility_code = GetValueFromReader<string>(dr,8);
                            instance._outlet_type = GetValueFromReader<string>(dr,9);
                            instance._region_rgn_name = GetValueFromReader<string>(dr,10);
                            instance._o_phy_address = GetValueFromReader<string>(dr,11);
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
