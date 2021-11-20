using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core.Security;using Metex.Core;

namespace NZPostOffice.Entity
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("region_id", "_region_id", "rd.rds_user_rights")]
	[System.Serializable()]

	public class UserComponentRegionlist : Entity<UserComponentRegionlist>
	{
		#region Business Methods
		[DBField()]
		private int?  _region_id;


		public virtual int? RegionId
		{
			get
			{
				CanReadProperty(true);
				return _region_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_id != value )
				{
					_region_id = value;
					PropertyHasChanged();
				}
			}
		}
		private UserComponentRegionlist[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static UserComponentRegionlist NewUserComponentRegionlist( string as_userid, string as_componentname )
		{
			return Create(as_userid, as_componentname);
		}

		public static UserComponentRegionlist[] GetAllUserComponentRegionlist( string as_userid, string as_componentname )
		{
			return Fetch(as_userid, as_componentname).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( string as_userid, string as_componentname )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "as_userid", as_userid);
					pList.Add(cm, "as_componentname", as_componentname);
                    //GenerateSelectCommandText(cm, "rd.rds_user_id_group");
                    //GenerateSelectCommandText(cm, "rd.rds_user_id");
                    //GenerateSelectCommandText(cm, "rd.rds_user_group");
                    //GenerateSelectCommandText(cm, "rd.rds_user_rights");
                    //GenerateSelectCommandText(cm, "rd.rds_component");

					List<UserComponentRegionlist> list = new List<UserComponentRegionlist>();
                    cm.CommandText = "  SELECT DISTINCT rds_user_rights.region_id  " +
                        "FROM rd.rds_user_id_group,   " +
                        "rd.rds_user_id,   " +
                        "         rd.rds_user_group,   " +
                        "         rd.rds_user_rights,   " +
                        "         rd.rds_component  " +
                        "   WHERE ( rd.rds_user_id.ui_id = rd.rds_user_id_group.ui_id ) and  " +
                        "         ( rd.rds_user_group.ug_id = rd.rds_user_id_group.ug_id ) and  " +
                        "         ( rd.rds_user_group.ug_id = rd.rds_user_rights.ug_id ) and  " +
                        "         ( rd.rds_user_rights.rc_id = rd.rds_component.rc_id ) and  " +
                        "         ( ( rd.rds_user_id.ui_userid = :as_userid ) ) AND  " +
                        "         upper(rd.rds_component.rc_name) = Upper(:as_componentname) ";


					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserComponentRegionlist instance = new UserComponentRegionlist();
                            instance._region_id = GetValueFromReader<Int32?>(dr, 0);
                            //instance.StoreFieldValues(dr, "rd.rds_user_id_group");
                            //instance.StoreFieldValues(dr, "rd.rds_user_id");
                            //instance.StoreFieldValues(dr, "rd.rds_user_group");
                            //instance.StoreFieldValues(dr, "rd.rds_user_rights");
                            //instance.StoreFieldValues(dr, "rd.rds_component");
							instance.MarkOld();
                            instance.StoreInitialValues();
							list.Add(instance);
						}
						dataList = new UserComponentRegionlist[list.Count];
						list.CopyTo(dataList);
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
