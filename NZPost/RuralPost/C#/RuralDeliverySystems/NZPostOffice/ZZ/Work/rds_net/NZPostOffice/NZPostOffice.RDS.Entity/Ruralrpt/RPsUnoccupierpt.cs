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
	[MapInfo("road_no", "_road_no", "")]
	[MapInfo("road_name", "_road_name", "")]
	[MapInfo("locality", "_locality", "")]
	[MapInfo("town", "_town", "")]
	[MapInfo("rd_no", "_rd_no", "")]
	[MapInfo("con_no", "_con_no", "")]
	[MapInfo("con_det", "_con_det", "")]
	[System.Serializable()]

	public class PsUnoccupiedRpt : Entity<PsUnoccupiedRpt>
	{
		#region Business Methods
		[DBField()]
		private string  _road_no;

		[DBField()]
		private string  _road_name;

		[DBField()]
		private string  _locality;

		[DBField()]
		private string  _town;

		[DBField()]
		private string  _rd_no;

		[DBField()]
		private int?  _con_no;

		[DBField()]
		private string  _con_det;


		public virtual string RoadNo
		{
			get
			{
                CanReadProperty("RoadNo", true);
				return _road_no;
			}
			set
			{
                CanWriteProperty("RoadNo", true);
				if ( _road_no != value )
				{
					_road_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RoadName
		{
			get
			{
                CanReadProperty("RoadName", true);
				return _road_name;
			}
			set
			{
                CanWriteProperty("RoadName", true);
				if ( _road_name != value )
				{
					_road_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Locality
		{
			get
			{
                CanReadProperty("Locality", true);
				return _locality;
			}
			set
			{
                CanWriteProperty("Locality", true);
				if ( _locality != value )
				{
					_locality = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Town
		{
			get
			{
                CanReadProperty("Town", true);
				return _town;
			}
			set
			{
                CanWriteProperty("Town", true);
				if ( _town != value )
				{
					_town = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdNo
		{
			get
			{
                CanReadProperty("RdNo", true);
				return _rd_no;
			}
			set
			{
                CanWriteProperty("RdNo", true);
				if ( _rd_no != value )
				{
					_rd_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ConNo
		{
			get
			{
                CanReadProperty("ConNo", true);
				return _con_no;
			}
			set
			{
                CanWriteProperty("ConNo", true);
				if ( _con_no != value )
				{
					_con_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConDet
		{
			get
			{
                CanReadProperty("ConDet", true);
				return _con_det;
			}
			set
			{
                CanWriteProperty("ConDet", true);
				if ( _con_det != value )
				{
					_con_det = value;
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
		public static PsUnoccupiedRpt NewPsUnoccupiedRpt( int? con_id )
		{
			return Create(con_id);
		}

		public static PsUnoccupiedRpt[] GetAllPsUnoccupiedRpt( int? con_id )
		{
			return Fetch(con_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? con_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_getunoccupied";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "con_id", con_id);

					List<PsUnoccupiedRpt> _list = new List<PsUnoccupiedRpt>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PsUnoccupiedRpt instance = new PsUnoccupiedRpt();
                            instance._road_no = GetValueFromReader<string>(dr,0);
                            instance._road_name = GetValueFromReader<string>(dr,1);
                            instance._locality = GetValueFromReader<string>(dr,2);
                            instance._town = GetValueFromReader<string>(dr,3);
                            instance._rd_no = GetValueFromReader<string>(dr,4);
                            instance._con_no = GetValueFromReader<int?>(dr,5);
                            instance._con_det = GetValueFromReader<string>(dr,6);
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
