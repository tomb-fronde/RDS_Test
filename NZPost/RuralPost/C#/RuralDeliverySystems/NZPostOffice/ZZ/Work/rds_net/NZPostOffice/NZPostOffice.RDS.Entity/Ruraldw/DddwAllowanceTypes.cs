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
	[MapInfo("alt_key", "_alt_key", "")]
	[MapInfo("alt_description", "_alt_description", "")]
	[System.Serializable()]

	public class DddwAllowanceTypes : Entity<DddwAllowanceTypes>
	{
		#region Business Methods
		[DBField()]
		private int?  _alt_key;

		[DBField()]
		private string  _alt_description;


		public virtual int? AltKey
		{
			get
			{
                CanReadProperty("AltKey", true);
				return _alt_key;
			}
			set
			{
                CanWriteProperty("AltKey", true);
				if ( _alt_key != value )
				{
					_alt_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AltDescription
		{
			get
			{
                CanReadProperty("AltDescription", true);
				return _alt_description;
			}
			set
			{
                CanWriteProperty("AltDescription", true);
				if ( _alt_description != value )
				{
					_alt_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return _alt_key + " ";
		}
		#endregion

		#region Factory Methods
		public static DddwAllowanceTypes NewDddwAllowanceTypes(  )
		{
			return Create();
		}

		public static DddwAllowanceTypes[] GetAllDddwAllowanceTypes(  )
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
                    cm.CommandText = "sp_DDDW_AllowanceType";
					List<DddwAllowanceTypes> _list = new List<DddwAllowanceTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwAllowanceTypes instance = new DddwAllowanceTypes();
                            instance._alt_key = GetValueFromReader<Int32?>(dr,0);
                            instance._alt_description = GetValueFromReader<String>(dr,1);
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
