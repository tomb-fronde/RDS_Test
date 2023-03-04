using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("sl_name", "_sl_name", "suburblocality")]
	[System.Serializable()]

	public class DddwSuburbNames : Entity<DddwSuburbNames>
	{
		#region Business Methods
		[DBField()]
		private string  _sl_name;

		public virtual string SlName
		{
			get
			{
                CanReadProperty("SlName", true);
				return _sl_name;
			}
			set
			{
                CanWriteProperty("SlName", true);
				if ( _sl_name != value )
				{
					_sl_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
            return string.Format("{0}", _sl_name) + " ";
		}

        List<DddwSuburbNames> stringList = new List<DddwSuburbNames>();
		#endregion

		#region Factory Methods
		public static DddwSuburbNames NewDddwSuburbNames(  )
		{
			return Create();
		}

		public static DddwSuburbNames[] GetAllDddwSuburbNames(  )
		{            
			return Fetch().list;
		}

        public static List<DddwSuburbNames> GetAllDddwSuburbNamesStrings()
        {
            return Fetch().stringList;
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
                    cm.CommandText = "SELECT DISTINCT sl_name " 
                                   +   "FROM suburblocality "
                                   +  "ORDER BY sl_name ASC";

					List<DddwSuburbNames> _list = new List<DddwSuburbNames>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwSuburbNames instance = new DddwSuburbNames();
                            instance._sl_name = dr.GetString(0);
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
