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
	[MapInfo("mc_key", "_mc_key", "")]
	[MapInfo("mc_description", "_mc_description", "")]
	[System.Serializable()]

	public class DddwMailCategoryAll : Entity<DddwMailCategoryAll>
	{
		#region Business Methods
		[DBField()]
		private int?  _mc_key;

		[DBField()]
		private string  _mc_description;


		public virtual int? McKey
		{
			get
			{
                CanReadProperty("McKey", true);
				return _mc_key;
			}
			set
			{
                CanWriteProperty("McKey", true);
				if ( _mc_key != value )
				{
					_mc_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string McDescription
		{
			get
			{
                CanReadProperty("McDescription", true);
				return _mc_description;
			}
			set
			{
                CanWriteProperty("McDescription", true);
				if ( _mc_description != value )
				{
					_mc_description = value;
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
		public static DddwMailCategoryAll NewDddwMailCategoryAll(  )
		{
			return Create();
		}

		public static DddwMailCategoryAll[] GetAllDddwMailCategoryAll(  )
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
                    cm.CommandText = "rd.sp_dddw_rb_mailcategory";
					List<DddwMailCategoryAll> _list = new List<DddwMailCategoryAll>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwMailCategoryAll instance = new DddwMailCategoryAll();
                            instance._mc_key = GetValueFromReader<Int32?>(dr,0);
                            instance._mc_description = GetValueFromReader<String>(dr,1);
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
