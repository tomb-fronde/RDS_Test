using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("ui_userid", "_ui_userid", "rds_user_id")]
	[MapInfo("u_name", "_u_name", "rds_user")]
	[System.Serializable()]

	public class Username : Entity<Username>
	{
		#region Business Methods
		[DBField()]
		private string  _ui_userid;

		[DBField()]
		private string  _u_name;


		public virtual string UiUserid
		{
			get
			{
				CanReadProperty(true);
				return _ui_userid;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_userid != value )
				{
					_ui_userid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UName
		{
			get
			{
				CanReadProperty(true);
				return _u_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _u_name != value )
				{
					_u_name = value;
					PropertyHasChanged();
				}
			}
		}
		private Username[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static Username NewDddwUsername(  )
		{
			return Create();
		}

		public static Username[] GetAllDddwUsername(  )
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();

					cm.CommandText += "SELECT  rds_user_id.ui_userid , " +
                       "rds_user.u_name     " +
                       "FROM rds_user_id ," +
                       "rds_user     " +
                       "WHERE ( rds_user.u_id = rds_user_id.u_id )  " +
                       "ORDER BY rds_user.u_name  ASC ";

					List<Username> list = new List<Username>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{ 
                    
						while (dr.Read())
						{
							Username instance = new Username();
							instance.StoreFieldValues(dr, "rds_user_id");
							instance.StoreFieldValues(dr, "rds_user");
                            if (instance._ui_userid != null)
                            {
                                instance._ui_userid = instance._ui_userid.Trim();
                            }
							instance.MarkOld();
							list.Add(instance);
						}
                        Username instance2 = new Username();
                        instance2._ui_userid = "default";
                        instance2._u_name = "default";
                        list.Add(instance2);
						dataList = new Username[list.Count];
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
