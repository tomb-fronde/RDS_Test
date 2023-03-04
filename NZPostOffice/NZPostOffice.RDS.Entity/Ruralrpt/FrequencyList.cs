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
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("sf_desc", "_sf_desc", "")]
	[System.Serializable()]

	public class FrequencyList : Entity<FrequencyList>
	{
		#region Business Methods
		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _sf_desc;


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

		public virtual string SfDesc
		{
			get
			{
                CanReadProperty("SfDesc", true);
				return _sf_desc;
			}
			set
			{
                CanWriteProperty("SfDesc", true);
				if ( _sf_desc != value )
				{
					_sf_desc = value;
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
		public static FrequencyList NewFrequencyList(  )
		{
			return Create();
		}

		public static FrequencyList[] GetAllFrequencyList(  )
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
                    cm.CommandText = "rd.sp_getfrequency_list";
					ParameterCollection pList = new ParameterCollection();

					List<FrequencyList> _list = new List<FrequencyList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							FrequencyList instance = new FrequencyList();
                            instance._sf_key = GetValueFromReader<int?>(dr,0);
                            instance._sf_desc = GetValueFromReader<string>(dr,1);
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
