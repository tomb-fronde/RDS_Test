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
	[MapInfo("interest_desc", "_interest_desc", "")]
	[MapInfo("int_id", "_int_id", "")]
	[System.Serializable()]

	public class InterestCriteria : Entity<InterestCriteria>
	{
		#region Business Methods
		[DBField()]
		private string  _interest_desc;

		[DBField()]
		private int?  _int_id;


		public virtual string InterestDesc
		{
			get
			{
                CanReadProperty("InterestDesc", true);
				return _interest_desc;
			}
			set
			{
                CanWriteProperty("InterestDesc", true);
				if ( _interest_desc != value )
				{
					_interest_desc = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? IntId
		{
			get
			{
                CanReadProperty("IntId", true);
				return _int_id;
			}
			set
			{
                CanWriteProperty("IntId", true);
				if ( _int_id != value )
				{
					_int_id = value;
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
		public static InterestCriteria NewInterestCriteria(  )
		{
			return Create();
		}

		public static InterestCriteria[] GetAllInterestCriteria(  )
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
                    cm.CommandText = "rd.sp_interest_list";
					ParameterCollection pList = new ParameterCollection();

					List<InterestCriteria> _list = new List<InterestCriteria>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							InterestCriteria instance = new InterestCriteria();
                            instance._interest_desc = GetValueFromReader<string>(dr,0);
                            instance._int_id = GetValueFromReader<int?>(dr,1);
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
