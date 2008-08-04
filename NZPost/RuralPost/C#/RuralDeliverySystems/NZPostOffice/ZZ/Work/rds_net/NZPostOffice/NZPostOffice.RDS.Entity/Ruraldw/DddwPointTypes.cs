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
	[MapInfo("rfpt_id", "_rfpt_id", "")]
	[MapInfo("rfpt_description", "_rfpt_description", "")]
	[System.Serializable()]

	public class DddwPointTypes : Entity<DddwPointTypes>
	{
		#region Business Methods
		[DBField()]
		private int?  _rfpt_id;

		[DBField()]
		private string  _rfpt_description;


		public virtual int? RfptId
		{
			get
			{
                CanReadProperty("RfptId", true);
				return _rfpt_id;
			}
			set
			{
                CanWriteProperty("RfptId", true);
				if ( _rfpt_id != value )
				{
					_rfpt_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfptDescription
		{
			get
			{
                CanReadProperty("RfptDescription", true);
				return _rfpt_description;
			}
			set
			{
                CanWriteProperty("RfptDescription", true);
				if ( _rfpt_description != value )
				{
					_rfpt_description = value;
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
		public static DddwPointTypes NewDddwPointTypes(  )
		{
			return Create();
		}

		public static DddwPointTypes[] GetAllDddwPointTypes(  )
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
                    cm.CommandText = "sp_DDDW_PointTypes";
					List<DddwPointTypes> _list = new List<DddwPointTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwPointTypes instance = new DddwPointTypes();
                            instance._rfpt_id = GetValueFromReader<Int32?>(dr,0);
                            instance._rfpt_description = GetValueFromReader<String>(dr,1);
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
