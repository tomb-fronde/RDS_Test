using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("gp_odps", "_user_groups_gp_odps", "rd.user_groups")]
	[System.Serializable()]

	public class UserId : Entity<UserId>
	{
		#region Business Methods
		[DBField()]
		private decimal?  _user_groups_gp_odps;


		public virtual decimal? UserGroupsGpOdps
		{
			get
			{
				CanReadProperty("UserGroupsGpOdps",true);
				return _user_groups_gp_odps;
			}
			set
			{
				CanWriteProperty("UserGroupsGpOdps",true);
				if ( _user_groups_gp_odps != value )
				{
					_user_groups_gp_odps = value;
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
		public static UserId NewUserId( string a_user_id, string a_password )
		{
			return Create(a_user_id, a_password);
		}

		public static UserId[] GetAllUserId( string a_user_id, string a_password )
		{
			return Fetch(a_user_id, a_password).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( string a_user_id, string a_password )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "a_user_id", a_user_id);
                    pList.Add(cm, "a_password", a_password);
                    cm.CommandText = @"  SELECT rd.user_groups.gp_odps  
                                        FROM rd.user_groups,   
                                        rd.userids  
                                        WHERE ( rd.userids.gp_code = rd.user_groups.gp_code ) and  
                                        ( ( rd.userids.u_userid = :a_user_id ) AND  
                                        ( rd.userids.u_password = :a_password ) )    
                                        ";
                    //GenerateSelectCommandText(cm, "rd.user_groups");
                    //GenerateSelectCommandText(cm, "rd.userids");
                    List<UserId> _list = new List<UserId>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            UserId instance = new UserId();
                            instance._user_groups_gp_odps = GetValueFromReader<decimal?>(dr, 0);
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
