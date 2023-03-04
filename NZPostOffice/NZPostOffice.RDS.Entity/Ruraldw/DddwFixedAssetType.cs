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
	[MapInfo("fat_id", "_fat_id", "")]
	[MapInfo("fat_description", "_fat_description", "")]
	[System.Serializable()]

	public class DddwFixedAssetType : Entity<DddwFixedAssetType>
	{
		#region Business Methods
		[DBField()]
		private int?  _fat_id;

		[DBField()]
		private string  _fat_description;


		public virtual int? FatId
		{
			get
			{
                CanReadProperty("FatId", true);
				return _fat_id;
			}
			set
			{
                CanWriteProperty("FatId", true);
				if ( _fat_id != value )
				{
					_fat_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FatDescription
		{
			get
			{
                CanReadProperty("FatDescription", true);
				return _fat_description;
			}
			set
			{
                CanWriteProperty("FatDescription", true);
				if ( _fat_description != value )
				{
					_fat_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return _fat_id + " ";
		}
		#endregion

		#region Factory Methods
		public static DddwFixedAssetType NewDddwFixedAssetType(  )
		{
			return Create();
		}

		public static DddwFixedAssetType[] GetAllDddwFixedAssetType(  )
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
                    cm.CommandText = "sp_DDDW_FixedAssetTypes";

					List<DddwFixedAssetType> _list = new List<DddwFixedAssetType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwFixedAssetType instance = new DddwFixedAssetType();
                            instance._fat_id = GetValueFromReader<Int32?>(dr,0);
                            instance._fat_description = GetValueFromReader<String>(dr,1);
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
