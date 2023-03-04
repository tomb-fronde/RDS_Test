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
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("o_address", "_o_address", "")]
	[MapInfo("o_manager", "_o_manager", "")]
	[MapInfo("ot_outlet_type", "_ot_outlet_type", "")]
	[System.Serializable()]

	public class OutletLabel : Entity<OutletLabel>
	{
		#region Business Methods
		[DBField()]
		private string  _o_name;

		[DBField()]
		private string  _o_address;

		[DBField()]
		private string  _o_manager;

		[DBField()]
		private string  _ot_outlet_type;


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

		public virtual string OAddress
		{
			get
			{
                CanReadProperty("OAddress", true);
				return _o_address;
			}
			set
			{
                CanWriteProperty("OAddress", true);
				if ( _o_address != value )
				{
					_o_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OManager
		{
			get
			{
                CanReadProperty("OManager", true);
				return _o_manager;
			}
			set
			{
                CanWriteProperty("OManager", true);
				if ( _o_manager != value )
				{
					_o_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OtOutletType
		{
			get
			{
                CanReadProperty("OtOutletType", true);
				return _ot_outlet_type;
			}
			set
			{
                CanWriteProperty("OtOutletType", true);
				if ( _ot_outlet_type != value )
				{
					_ot_outlet_type = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_1]
		//?	o_name  + ' ' + if(lower(ot_outlet_type)='other','', ot_outlet_type )


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static OutletLabel NewOutletLabel( int? in_Region, int? in_phyFlag )
		{
			return Create(in_Region, in_phyFlag);
		}

		public static OutletLabel[] GetAllOutletLabel( int? in_Region, int? in_phyFlag )
		{
			return Fetch(in_Region, in_phyFlag).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Region, int? in_phyFlag )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_outlet_labels";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Region", in_Region);
					pList.Add(cm, "in_phyFlag", in_phyFlag);

					List<OutletLabel> _list = new List<OutletLabel>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OutletLabel instance = new OutletLabel();
                            instance._o_name = GetValueFromReader<string>(dr,0);
                            instance._o_address = GetValueFromReader<string>(dr,1);
                            instance._o_manager = GetValueFromReader<string>(dr,2);
                            instance._ot_outlet_type = GetValueFromReader<string>(dr,3);
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
