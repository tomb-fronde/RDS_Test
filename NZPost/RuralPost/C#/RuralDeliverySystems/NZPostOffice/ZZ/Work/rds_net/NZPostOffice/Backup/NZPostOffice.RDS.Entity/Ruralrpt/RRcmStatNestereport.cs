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
	[MapInfo("a", "_a", "")]
	[System.Serializable()]

	public class RcmStatNestedReport : Entity<RcmStatNestedReport>
	{
		#region Business Methods
		[DBField()]
		private string  _a;


		public virtual string A
		{
			get
			{
				CanReadProperty(true);
				return _a;
			}
			set
			{
				CanWriteProperty(true);
				if ( _a != value )
				{
					_a = value;
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
		public static RcmStatNestedReport NewRcmStatNestedReport(  )
		{
			return Create();
		}

		public static RcmStatNestedReport[] GetAllRcmStatNestedReport(  )
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
				//?	pList.Add(cm, " Type=",  Type=);

					List<RcmStatNestedReport> _list = new List<RcmStatNestedReport>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RcmStatNestedReport instance = new RcmStatNestedReport();
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
