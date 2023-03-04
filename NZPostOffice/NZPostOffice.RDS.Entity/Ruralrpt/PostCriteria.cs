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
	[MapInfo("post_info", "_post_info", "")]
	[MapInfo("post_id", "_post_id", "")]
	[System.Serializable()]

	public class PostCriteria : Entity<PostCriteria>
	{
		#region Business Methods
		[DBField()]
		private string  _post_info;

		[DBField()]
		private int?  _post_id;


		public virtual string PostInfo
		{
			get
			{
                CanReadProperty("PostInfo", true);
				return _post_info;
			}
			set
			{
                CanWriteProperty("PostInfo", true);
				if ( _post_info != value )
				{
					_post_info = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PostId
		{
			get
			{
                CanReadProperty("PostId", true);
				return _post_id;
			}
			set
			{
                CanWriteProperty("PostId", true);
				if ( _post_id != value )
				{
					_post_id = value;
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
		public static PostCriteria NewPostCriteria(  )
		{
			return Create();
		}

		public static PostCriteria[] GetAllPostCriteria(  )
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
                    cm.CommandText = "rd.sp_postcode_list";
					ParameterCollection pList = new ParameterCollection();

					List<PostCriteria> _list = new List<PostCriteria>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PostCriteria instance = new PostCriteria();
                            instance._post_info = GetValueFromReader<string>(dr,0);
                            instance._post_id = GetValueFromReader<int?>(dr,1);
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
