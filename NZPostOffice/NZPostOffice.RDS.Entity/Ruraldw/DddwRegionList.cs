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
	[MapInfo("region_id", "_region_region_id", "region")]
	[MapInfo("rgn_name", "_region_rgn_name", "region")]
	[MapInfo("tc_id", "_contract", "towncity")]
	[MapInfo("tc_name", "_region_list", "towncity")]
	[System.Serializable()]

	public class DddwRegionList : Entity<DddwRegionList>
	{
		#region Business Methods
		[DBField()]
		private int?  _region_region_id;

		[DBField()]
		private string  _region_rgn_name;

		[DBField()]
		private int?  _contract;

		[DBField()]
		private string  _region_list;


		public virtual int? RegionRegionId
		{
			get
			{
                CanReadProperty("RegionRegionId", true);
				return _region_region_id;
			}
			set
			{
                CanWriteProperty("RegionRegionId", true);
				if ( _region_region_id != value )
				{
					_region_region_id = value;
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

		public virtual int? Contract
		{
			get
			{
                CanReadProperty("Contract", true);
				return _contract;
			}
			set
			{
                CanWriteProperty("Contract", true);
				if ( _contract != value )
				{
					_contract = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegionList
		{
			get
			{
                if (_region_list == null)
                {
                    return "";
                }
                CanReadProperty("RegionList", true);
                return _region_list== "0" ?null :_region_list.Trim();
			}
			set
			{
                CanWriteProperty("RegionList", true);
				if ( _region_list != value )
				{
					_region_list = value;
					PropertyHasChanged();
				}
			}
		}

        private int? _RegionList1;
        public virtual int? RegionList1
        {
            get
            {
                return _RegionList1;
            }
            set
            {
                _RegionList1 = value;
            }
        }
		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static DddwRegionList NewDddwRegionList(  )
		{
			return Create();
		}

		public static DddwRegionList[] GetAllDddwRegionList(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT region.region_id," +
                        "region.rgn_name,towncity.tc_id,towncity.tc_name " +
                        "FROM towncity, region  " +
                        "WHERE ( region.region_id = towncity.region_id ) ";

					List<DddwRegionList> _list = new List<DddwRegionList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwRegionList instance = new DddwRegionList();
                            instance._region_region_id = GetValueFromReader<Int32?>(dr,0);
                            instance._region_rgn_name = GetValueFromReader<String>(dr,1);
                            instance._contract = GetValueFromReader<Int32?>(dr,2);
                            instance._region_list = GetValueFromReader<String>(dr,3);

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
