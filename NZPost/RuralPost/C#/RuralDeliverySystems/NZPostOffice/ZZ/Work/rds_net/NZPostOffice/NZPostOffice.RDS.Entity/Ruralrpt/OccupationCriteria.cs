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
	[MapInfo("occupation_desc", "_occupation_desc", "")]
	[MapInfo("occ_id", "_occ_id", "")]
	[System.Serializable()]

	public class OccupationCriteria : Entity<OccupationCriteria>
	{
		#region Business Methods
		[DBField()]
		private string  _occupation_desc;

		[DBField()]
		private int?  _occ_id;


		public virtual string OccupationDesc
		{
			get
			{
                CanReadProperty("OccupationDesc", true);
				return _occupation_desc;
			}
			set
			{
                CanWriteProperty("OccupationDesc", true);
				if ( _occupation_desc != value )
				{
					_occupation_desc = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? OccId
		{
			get
			{
                CanReadProperty("OccId", true);
				return _occ_id;
			}
			set
			{
                CanWriteProperty("OccId", true);
				if ( _occ_id != value )
				{
					_occ_id = value;
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
		public static OccupationCriteria NewOccupationCriteria(  )
		{
			return Create();
		}

		public static OccupationCriteria[] GetAllOccupationCriteria(  )
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
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_occupation_list";
					ParameterCollection pList = new ParameterCollection();

					List<OccupationCriteria> _list = new List<OccupationCriteria>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OccupationCriteria instance = new OccupationCriteria();
                            instance._occupation_desc = GetValueFromReader<string>(dr,0);
                            instance._occ_id = GetValueFromReader<int?>(dr,1);
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
