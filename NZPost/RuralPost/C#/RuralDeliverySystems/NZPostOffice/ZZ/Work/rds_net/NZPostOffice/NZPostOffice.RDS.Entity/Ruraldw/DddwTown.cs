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
	[MapInfo("tc_id", "_tc_id", "towncity")]
	[MapInfo("region_id", "_region_id", "towncity")]
	[MapInfo("tc_name", "_tc_name", "towncity")]
	[MapInfo("post_code", "_post_code", "post_code")]
	[MapInfo("post_code_id", "_post_code_id", "post_code")]
	[System.Serializable()]

	public class DddwTown : Entity<DddwTown>
	{
		#region Business Methods
		[DBField()]
		private int?  _tc_id;

		[DBField()]
		private int?  _region_id;

		[DBField()]
		private string  _tc_name;

		[DBField()]
		private string  _post_code;

		[DBField()]
		private int?  _post_code_id;


		public virtual int? TcId
		{
			get
			{
                CanReadProperty("TcId", true);
				return _tc_id;
			}
			set
			{
                CanWriteProperty("TcId", true);
				if ( _tc_id != value )
				{
					_tc_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionId
		{
			get
			{
                CanReadProperty("RegionId", true);
				return _region_id;
			}
			set
			{
                CanWriteProperty("RegionId", true);
				if ( _region_id != value )
				{
					_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string TcName
		{
			get
			{
                CanReadProperty("TcName", true);
				return _tc_name;
			}
			set
			{
                CanWriteProperty("TcName", true);
				if ( _tc_name != value )
				{
					_tc_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PostCode
		{
			get
			{
                CanReadProperty("PostCode", true);
				return _post_code;
			}
			set
			{
                CanWriteProperty("PostCode", true);
				if ( _post_code != value )
				{
					_post_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PostCodeId
		{
			get
			{
                CanReadProperty("PostCodeId", true);
				return _post_code_id;
			}
			set
			{
                CanWriteProperty("PostCodeId", true);
				if ( _post_code_id != value )
				{
					_post_code_id = value;
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
		public static DddwTown NewDddwTown(  )
		{
			return Create();
		}

		public static DddwTown[] GetAllDddwTown(  )
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
					cm.CommandText = "SELECT towncity.tc_id,  towncity.region_id,  towncity.tc_name,  post_code.post_code,  post_code.post_code_id  FROM rd.towncity LEFT OUTER JOIN rd.post_code ON towncity.tc_name = post_code.post_mail_town  ";
					ParameterCollection pList = new ParameterCollection();

					List<DddwTown> _list = new List<DddwTown>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwTown instance = new DddwTown();
                            instance._tc_id = GetValueFromReader<Int32?>(dr,0);
                            instance._region_id = GetValueFromReader<Int32?>(dr,1);
                            instance._tc_name = GetValueFromReader<String>(dr,2);
                            instance._post_code = GetValueFromReader<String>(dr,3);
                            instance._post_code_id = GetValueFromReader<Int32?>(dr,4);

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
