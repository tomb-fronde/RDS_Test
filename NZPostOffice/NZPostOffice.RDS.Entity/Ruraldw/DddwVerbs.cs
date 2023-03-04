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
	[MapInfo("rfv_id", "_rfv_id", "")]
	[MapInfo("rfv_description", "_rfv_description", "")]
	[System.Serializable()]

	public class DddwVerbs : Entity<DddwVerbs>
	{
		#region Business Methods
		[DBField()]
		private int?  _rfv_id;

		[DBField()]
		private string  _rfv_description;


		public virtual int? RfvId
		{
			get
			{
                CanReadProperty("RfvId", true);
				return _rfv_id;
			}
			set
			{
                CanWriteProperty("RfvId", true);
				if ( _rfv_id != value )
				{
					_rfv_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfvDescription
		{
			get
			{
                CanReadProperty("RfvDescription", true);
				return _rfv_description;
			}
			set
			{
                CanWriteProperty("RfvDescription", true);
				if ( _rfv_description != value )
				{
					_rfv_description = value;
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
		public static DddwVerbs NewDddwVerbs(  )
		{
			return Create();
		}

		public static DddwVerbs[] GetAllDddwVerbs(  )
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
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "sp_DDDW_Verbs";

					List<DddwVerbs> _list = new List<DddwVerbs>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwVerbs instance = new DddwVerbs();
                            instance._rfv_id = GetValueFromReader<Int32?>(dr,0);
                            instance._rfv_description = GetValueFromReader<String>(dr,1);
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
