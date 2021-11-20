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
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("sf_description", "_sf_description", "")]
	[MapInfo("sf_days_week", "_sf_days_week", "")]
	[System.Serializable()]

	public class DddwStandardFrequency : Entity<DddwStandardFrequency>
	{
		#region Business Methods
		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _sf_description;

		[DBField()]
		private int?  _sf_days_week;


		public virtual int? SfKey
		{
			get
			{
                CanReadProperty("SfKey", true);
				return _sf_key;
			}
			set
			{
                CanWriteProperty("SfKey", true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SfDescription
		{
			get
			{
                CanReadProperty("SfDescription", true);
				return _sf_description;
			}
			set
			{
                CanWriteProperty("SfDescription", true);
				if ( _sf_description != value )
				{
					_sf_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SfDaysWeek
		{
			get
			{
                CanReadProperty("SfDaysWeek", true);
				return _sf_days_week;
			}
			set
			{
                CanWriteProperty("SfDaysWeek", true);
				if ( _sf_days_week != value )
				{
					_sf_days_week = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
            return _sf_key + "";
		}
		#endregion

		#region Factory Methods
		public static DddwStandardFrequency NewDddwStandardFrequency(  )
		{
			return Create();
		}

		public static DddwStandardFrequency[] GetAllDddwStandardFrequency(  )
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
                    cm.CommandText = "sp_DDDW_StandardFrequency";

					List<DddwStandardFrequency> _list = new List<DddwStandardFrequency>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwStandardFrequency instance = new DddwStandardFrequency();
                            instance._sf_key = GetValueFromReader<Int32?>(dr,0);
                            instance._sf_description = GetValueFromReader<String>(dr,1);
                            instance._sf_days_week = GetValueFromReader<Int16?>(dr,2);
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
